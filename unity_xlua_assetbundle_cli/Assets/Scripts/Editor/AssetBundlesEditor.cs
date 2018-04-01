using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NewAssetBundleEditor : Editor {

    [MenuItem("New AB Editor/Build AssetBundles")]
    static void BuildMainAssetBundles() {
        //第一个参数获取的是AssetBundle存放的相对地址。
       BuildPipeline.BuildAssetBundles(
         AssetBundleConfig.ASSETBUNDLE_PATH.Substring(AssetBundleConfig.PROJECT_PATH.Length),
         BuildAssetBundleOptions.UncompressedAssetBundle |
         BuildAssetBundleOptions.DeterministicAssetBundle,
         BuildTarget.StandaloneWindows64);
    }


    [MenuItem("New AB Editor/SetAssetBundleName")]
    static void SetResourcesAssetBundleName()
    {
        UnityEngine.Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), 
                            SelectionMode.Assets | SelectionMode.ExcludePrefab );
        //此处添加需要命名的资源后缀名,注意大小写。
        string[] Filtersuffix = new string[] { ".txt", ".unity", ".prefab", ".jpg", ".png" };   

        if (!(SelectedAsset.Length == 1)) return;

        string fullPath = AssetBundleConfig.PROJECT_PATH + 
        AssetDatabase.GetAssetPath(SelectedAsset[0]);

        if (Directory.Exists(fullPath))
        {
            DirectoryInfo dir = new DirectoryInfo(fullPath);

            var files = dir.GetFiles("*", SearchOption.AllDirectories);
            ;
            for (var i = 0; i < files.Length; ++i)
            {
                var fileInfo = files[i];
                EditorUtility.DisplayProgressBar("设置AssetName名称", "正在设置AssetName名称中...", 
                    1f * i / files.Length);
                foreach (string suffix in Filtersuffix)
                {
                    if (fileInfo.Name.EndsWith(suffix))
                    {
                        string path = fileInfo.FullName.Replace('\\', 
                        '/').Substring(AssetBundleConfig.PROJECT_PATH.Length);
                        var importer = AssetImporter.GetAtPath(path);
                        if (importer)
                        {
                            string name = path.Substring(fullPath.Substring(
                            AssetBundleConfig.PROJECT_PATH.Length).Length + 1);
                            importer.assetBundleName = name.Substring(0,
                            name.LastIndexOf('.')) + AssetBundleConfig.SUFFIX;
                        }
                    }
                }
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("New AB Editor/GetAllAssetBundleName")]
    static void GetAllAssetBundleName() {

        string[] names = AssetDatabase.GetAllAssetBundleNames();

        foreach (var name in names) {
            Debug.Log(name);
        }

    }

    [MenuItem("New AB Editor/ClearAssetBundleName")]
    static void ClearResourcesAssetBundleName() {
        UnityEngine.Object[] SelectedAsset = Selection.GetFiltered(typeof(Object),
                                SelectionMode.Assets | SelectionMode.ExcludePrefab);
        //此处添加需要命名的资源后缀名,注意大小写。
        string[] Filtersuffix = new string[] { ".txt", ".unity", ".prefab", ".jpg", ".png" };

        if (!(SelectedAsset.Length == 1)) return;

        string fullPath = AssetBundleConfig.PROJECT_PATH + AssetDatabase.GetAssetPath(SelectedAsset[0]);

        if (Directory.Exists(fullPath)) {
            DirectoryInfo dir = new DirectoryInfo(fullPath);

            var files = dir.GetFiles("*", SearchOption.AllDirectories);
            ;
            for (var i = 0; i < files.Length; ++i) {
                var fileInfo = files[i];
                EditorUtility.DisplayProgressBar("清除AssetName名称",
                "正在清除AssetName名称中...", 1f * i / files.Length);
                foreach (string suffix in Filtersuffix) {
                    if (fileInfo.Name.EndsWith(suffix)) {
                        string path = fileInfo.FullName.Replace('\\',
                        '/').Substring(AssetBundleConfig.PROJECT_PATH.Length);
                        var importer = AssetImporter.GetAtPath(path);
                        if (importer) {
                            importer.assetBundleName = null;
                        }
                    }
                }
            }
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.RemoveUnusedAssetBundleNames();
    }
}
