using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AssetBundleConfig : MonoBehaviour {

    //AssetBundle打包路径
    public static string ASSETBUNDLE_PATH = Application.dataPath + "/AssetBundle/";

    //资源地址
    public static string APPLICATION_PATH = Application.dataPath + "/";

    //工程地址
    public static string PROJECT_PATH = APPLICATION_PATH.Substring(0, APPLICATION_PATH.Length - 7);

    //AssetBundle存放的文件夹名
    public static string ASSETBUNDLE_FILENAM = "AssetBundle";

    //AssetBundle打包的后缀名
    public static string SUFFIX = "";

}
