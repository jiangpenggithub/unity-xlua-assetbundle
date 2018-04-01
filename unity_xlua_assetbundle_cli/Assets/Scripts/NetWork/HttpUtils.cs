using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

[CSharpCallLua]
public delegate void HttpMsgCallback(string err, string ret);

[LuaCallCSharp]
public class HttpUtils {
    public const int TimeOut = 5; 
    public static IEnumerator SendHttpMsg(string url, string method, Dictionary<string, object> param, HttpMsgCallback callback) {
        
        if (string.Compare(method, "get", true) == 0) {
            UnityWebRequest getTW = null;
            if (param == null || param.Count == 0) {
                getTW = UnityWebRequest.Get(url);
            }
            else {
                StringBuilder strParams = new StringBuilder();
                bool first = true;
                foreach (KeyValuePair<string, object> val in param) {
                    if (first == false) strParams.Append("&");
                    strParams.AppendFormat("{0}={1}", val.Key, val.Value.ToString());
                    first = false;
                }
                getTW = UnityWebRequest.Get(string.Format("{0}?{1}", url, strParams.ToString()));
            }
            getTW.method = UnityWebRequest.kHttpVerbGET;
            getTW.timeout = TimeOut;
            yield return getTW.SendWebRequest();

            if (getTW.isDone) {
                if (getTW.error != null) callback(getTW.error, null);
                else callback(null, getTW.downloadHandler.text);
            }
            else {
                callback("sendHttpMsg get not done", null);
            }
        }
        else if (string.Compare(method, "post", true) == 0) {
            WWWForm postForm = new WWWForm();
            if (param != null) {
                foreach (KeyValuePair<string, object> val in param) {
                    postForm.AddField(val.Key, val.Value.ToString());
                }
            }
            UnityWebRequest postTW = UnityWebRequest.Post(url, postForm);
            yield return postTW.SendWebRequest();

            if (postTW.isDone) {
                if (postTW.error != null) callback(postTW.error, null);
                else callback(null, postTW.downloadHandler.text);
            }
            else {
                callback("sendHttpMsg get not done", null);
            }
        }
        else {
            throw new Exception("HttpUtils->SendHttpMsg->not support " + method);
        }
    }

}
