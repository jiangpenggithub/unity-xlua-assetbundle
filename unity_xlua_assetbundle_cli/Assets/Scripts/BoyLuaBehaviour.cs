using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using XLua;

[System.Serializable]
public class BoyInjection {
    public string name;
    public GameObject value;
}

[LuaCallCSharp]
class BoyLuaBehaviour : MonoBehaviour {
    public TextAsset luaScript;
    public BoyInjection[] injections;

    internal static float lastGCTime = 0;
    internal const float GCInterval = 1; //1 second 

    private Action luaStart;
    private Action luaUpdate;
    private Action luaOnDestroy;

    private LuaTable scriptEnv;

    void Awake()
    {
        
        scriptEnv = BoyApp.g_LuaEnv.NewTable();

        LuaTable meta = BoyApp.g_LuaEnv.NewTable();
        meta.Set("__index", BoyApp.g_LuaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();


        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        BoyApp.g_LuaEnv.DoString(luaScript.text, "LuaBehaviour", scriptEnv);

        Action luaAwake = scriptEnv.Get<Action>("awake");
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("ondestroy", out luaOnDestroy);

        if (luaAwake != null)
        {
            luaAwake();
        }
    }

	// Use this for initialization
	void Start ()
    {
        if (luaStart != null)
        {
            luaStart();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
        if (Time.time - BoyLuaBehaviour.lastGCTime > GCInterval)
        {
            BoyApp.g_LuaEnv.Tick();
            BoyLuaBehaviour.lastGCTime = Time.time;
        }
	}

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
        injections = null;
    }
}

