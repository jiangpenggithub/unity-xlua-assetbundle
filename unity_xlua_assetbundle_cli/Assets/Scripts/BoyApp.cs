using Newtonsoft.Json;
using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using XLua;

[CSharpCallLua]
public delegate void LoadingCallback(System.Object asset);
[LuaCallCSharp]
public delegate void UpdateCallback(string name);
public delegate void DownloadCallback(AssetBundle asset);
[LuaCallCSharp]
public class BoyApp : MonoBehaviour{

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_rapidjson(System.IntPtr LL);

    [MonoPInvokeCallback(typeof(XLua.LuaDLL.lua_CSFunction))]
    public static int LoadRapidJson(System.IntPtr LL) {
        return luaopen_rapidjson(LL);
    }

    //更新相关
    public static AssetBundle manifestAssetBundle;
    public static AssetBundleManifest manifest;
    public static Dictionary<string, int> localFileVer = new Dictionary<string, int>();
    public static Dictionary<string, string> localFileInfo = new Dictionary<string,string>();
    private static Dictionary<string, AssetBundle> loadedInfo = new Dictionary<string,AssetBundle>();

    public static LuaEnv g_LuaEnv = new LuaEnv();
    public static WsGame wsGame = new WsGame();

    private static BoyApp Instance;
    private static System.Object m_queueLock = new System.Object();
    private static List<Action> m_queuedEvents = new List<Action>();
    private static List<Action> m_executingEvents = new List<Action>();
    private static bool isInit = false;

    public static void Initialize() {
        if (isInit) return;
        g_LuaEnv.AddBuildin("rapidjson", LoadRapidJson);
        g_LuaEnv.AddLoader((ref string filename) => {
            if (loadedInfo.ContainsKey(filename)) {
                AssetBundle asset = loadedInfo[filename];
                UnityEngine.Object objs = asset.LoadAllAssets()[0];
                return Encoding.UTF8.GetBytes(objs.ToString());
            }
            return null;
        });

        isInit = true;
    }

    void Awake(){
        Instance = this;
        Initialize();
    }

    void Start(){

    }

    void Update(){
        lock (m_queueLock){
            while (m_queuedEvents.Count > 0){
                Action action = m_queuedEvents[0];
                m_executingEvents.Add(action);
                m_queuedEvents.RemoveAt(0);
            }
        }

        while (m_executingEvents.Count > 0){
            Action action = m_executingEvents[0];
            m_executingEvents.RemoveAt(0);
            action();
        }
    }

    public static void PushEvent(Action action){
        lock (m_queueLock){
            m_queuedEvents.Add(action);
        }
    }

    public static void SendLoginMsg(string token) {
        C2S_Login msg = new C2S_Login();
        msg.token = token;
        wsGame.SendMsg(msg);
    }
    
    public delegate void HttpSrvResultCallback(string err, string ret);
    public static void SendHttpMsg(string url, string method, Dictionary<string, object> param, HttpMsgCallback callback) {
        Instance.StartCoroutine(HttpUtils.SendHttpMsg(url, method, param, callback));
    }

    public static void SendHttpMsgWithSign(string url, string method, Dictionary<string, object> param, HttpMsgCallback callback, string appkey) {
        if (param == null) param = new Dictionary<string, object>();
        param["ts"] = DateUtils.GetTimeStamp();

        string[] keys = new string[param.Keys.Count];
        param.Keys.CopyTo(keys, 0);

        Array.Sort(keys);

        StringBuilder noSignStr = new StringBuilder();
        foreach (var key in keys) {
            noSignStr.AppendFormat("{0}={1}&", key, param[key]);
        }
        noSignStr.AppendFormat("key={0}", appkey);

        param["sign"] = noSignStr.ToString().ToMD5();

        SendHttpMsg(url, method, param, callback);
    }

    //更新相关
    public static string GetAssetBundlePath(string name) {
        if (localFileInfo.ContainsKey(name)) return localFileInfo[name];
        return Application.streamingAssetsPath + "/" + name;
    }

    public static int GetAssetBundleVer(string name) {
        if (localFileVer.ContainsKey(name)) return localFileVer[name];
        return 0;
    }


    public static string GetTextAssetsFromResouces(string name) {
        TextAsset assert = (TextAsset)Resources.Load(name);
        return assert.text;
    }

    public static string GetTextAssetsFromPersistent(string name){
        string filename = string.Format("{0}/{1}", Application.persistentDataPath, name);
        if (!File.Exists(filename))
            return null;
        return File.ReadAllText(filename);
    }

    public static void SaveTextAssetsToPersistent(string name, string txt) {
        string filename = string.Format("{0}/{1}", Application.persistentDataPath, name);
        File.WriteAllBytes(filename, Encoding.UTF8.GetBytes(txt));
    }

    public static void SaveVersionInfo(int pkgver) {
        SaveTextAssetsToPersistent("loadfileinfo.txt", JsonConvert.SerializeObject(localFileInfo));
        SaveTextAssetsToPersistent("loadfilever.txt", JsonConvert.SerializeObject(localFileVer));
        SaveTextAssetsToPersistent("pkgver", pkgver.ToString());
    }

    public static void LoadAssetBundle(string name, LoadingCallback callback) {
        if (loadedInfo.ContainsKey(name)) {
            callback(loadedInfo[name]);
            return;
        }
        string path = GetAssetBundlePath(name);
        int ver = GetAssetBundleVer(name);
        Instance.StartCoroutine(DownloadAsseBundle(path,ver, (AssetBundle asset) => {
            callback(asset);
        }));
    }

    public static void UpdateAssetBundle(string name, string path, int ver, UpdateCallback callback) {
        localFileInfo[name] = path;
        localFileVer[name] = ver;
        if (name.CompareTo("AssetBundle") == 0) {
            manifestAssetBundle.Unload(false);
            Instance.StartCoroutine(DownloadAsseBundle(path, ver, (AssetBundle asset) => {
                manifestAssetBundle = asset;
                manifest = asset.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                if (callback != null) callback(name);
            }));
            return;
        }
        if (loadedInfo.ContainsKey(name)) {
            callback(name);
        }
        else {
            Instance.StartCoroutine(DownloadAsseBundle(path,ver, (AssetBundle asset) => {
                if (callback != null) callback(name);
            }));
        }
    }

    public static IEnumerator DownloadAsseBundle(string path,int ver, DownloadCallback callback) {
        UnityWebRequest req = UnityWebRequest.GetAssetBundle(path, (uint)ver, 0);
        yield return req.SendWebRequest();

        AssetBundle asset = DownloadHandlerAssetBundle.GetContent(req);
        loadedInfo[asset.name] = asset;
        if (callback != null) callback(asset);
    }

    public static void LoadAssetBundleAndAllDependencies(string name, LoadingCallback callback) {
        string[] loadingDps = BoyApp.manifest.GetAllDependencies(name);

        List<string> needLoading = new List<string>();
        foreach (var key in loadingDps) {
            needLoading.Add(key);
            BoyApp.LoadAssetBundle(key, (System.Object asset) => {
                needLoading.Remove(key);

                if (needLoading.Count == 0) {
                    BoyApp.LoadAssetBundle(name, callback);
                }
            });
        }

        if (loadingDps.Length == 0) {
            BoyApp.LoadAssetBundle(name, callback);
        }
    }

}
