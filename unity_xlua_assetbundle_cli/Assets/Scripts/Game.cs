﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Caching.ClearCache();
        int FullPkgVer = Convert.ToInt32(BoyApp.GetTextAssetsFromResouces("pkgver"));
        string LocalPkgVer = BoyApp.GetTextAssetsFromPersistent("pkgver");
        if (LocalPkgVer != null && Convert.ToInt32(LocalPkgVer) < FullPkgVer) {
            Caching.ClearCache();
            File.Delete(Application.persistentDataPath + "/loadfileinfo.txt");
            File.Delete(Application.persistentDataPath + "/loadfilever.txt");
            File.Delete(Application.persistentDataPath + "/pkgver");
        }

        if (File.Exists(Application.persistentDataPath + "/loadfileinfo.txt")) {
            BoyApp.localFileInfo = (Dictionary<string, string>)JsonConvert.DeserializeObject(File.ReadAllText(Application.persistentDataPath + "/loadfileinfo.txt"), typeof(Dictionary<string, string>));
        }
        if (File.Exists(Application.persistentDataPath + "/loadfilever.txt")) {
            BoyApp.localFileVer = (Dictionary<string, int>)JsonConvert.DeserializeObject(File.ReadAllText(Application.persistentDataPath + "/loadfilever.txt"), typeof(Dictionary<string, int>));
        }

        StartCoroutine(LoadAssetBundleManifest());
	}

    IEnumerator LoadAssetBundleManifest() {
        string path = BoyApp.GetAssetBundlePath("AssetBundle");
        int ver = BoyApp.GetAssetBundleVer("AssetBundle");

        UnityWebRequest req = UnityWebRequest.GetAssetBundle(path, (uint)ver, 0);
        yield return req.SendWebRequest();

        AssetBundle asset = DownloadHandlerAssetBundle.GetContent(req);
        BoyApp.manifestAssetBundle = asset;
        BoyApp.manifest = asset.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        BoyApp.LoadAssetBundleAndAllDependencies("prefabs/loadingui", (System.Object loading) => {
            Instantiate(((AssetBundle)loading).LoadAsset("LoadingUI"));
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
