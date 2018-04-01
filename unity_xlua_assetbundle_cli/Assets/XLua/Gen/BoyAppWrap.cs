#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class BoyAppWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BoyApp);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 18, 6, 6);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "luaopen_rapidjson", _m_luaopen_rapidjson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadRapidJson", _m_LoadRapidJson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Initialize", _m_Initialize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushEvent", _m_PushEvent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SendLoginMsg", _m_SendLoginMsg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SendHttpMsg", _m_SendHttpMsg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SendHttpMsgWithSign", _m_SendHttpMsgWithSign_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAssetBundlePath", _m_GetAssetBundlePath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAssetBundleVer", _m_GetAssetBundleVer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextAssetsFromResouces", _m_GetTextAssetsFromResouces_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextAssetsFromPersistent", _m_GetTextAssetsFromPersistent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SaveTextAssetsToPersistent", _m_SaveTextAssetsToPersistent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SaveVersionInfo", _m_SaveVersionInfo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadAssetBundle", _m_LoadAssetBundle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UpdateAssetBundle", _m_UpdateAssetBundle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DownloadAsseBundle", _m_DownloadAsseBundle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadAssetBundleAndAllDependencies", _m_LoadAssetBundleAndAllDependencies_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "manifestAssetBundle", _g_get_manifestAssetBundle);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "manifest", _g_get_manifest);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "localFileVer", _g_get_localFileVer);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "localFileInfo", _g_get_localFileInfo);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "g_LuaEnv", _g_get_g_LuaEnv);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "wsGame", _g_get_wsGame);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "manifestAssetBundle", _s_set_manifestAssetBundle);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "manifest", _s_set_manifest);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "localFileVer", _s_set_localFileVer);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "localFileInfo", _s_set_localFileInfo);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "g_LuaEnv", _s_set_g_LuaEnv);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "wsGame", _s_set_wsGame);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					BoyApp __cl_gen_ret = new BoyApp();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BoyApp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_luaopen_rapidjson_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    System.IntPtr LL = LuaAPI.lua_touserdata(L, 1);
                    
                        int __cl_gen_ret = BoyApp.luaopen_rapidjson( LL );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadRapidJson_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    System.IntPtr LL = LuaAPI.lua_touserdata(L, 1);
                    
                        int __cl_gen_ret = BoyApp.LoadRapidJson( LL );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Initialize_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    BoyApp.Initialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushEvent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Action action = translator.GetDelegate<System.Action>(L, 1);
                    
                    BoyApp.PushEvent( action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendLoginMsg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string token = LuaAPI.lua_tostring(L, 1);
                    
                    BoyApp.SendLoginMsg( token );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendHttpMsg_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string url = LuaAPI.lua_tostring(L, 1);
                    string method = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.Dictionary<string, object> param = (System.Collections.Generic.Dictionary<string, object>)translator.GetObject(L, 3, typeof(System.Collections.Generic.Dictionary<string, object>));
                    HttpMsgCallback callback = translator.GetDelegate<HttpMsgCallback>(L, 4);
                    
                    BoyApp.SendHttpMsg( url, method, param, callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendHttpMsgWithSign_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string url = LuaAPI.lua_tostring(L, 1);
                    string method = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.Dictionary<string, object> param = (System.Collections.Generic.Dictionary<string, object>)translator.GetObject(L, 3, typeof(System.Collections.Generic.Dictionary<string, object>));
                    HttpMsgCallback callback = translator.GetDelegate<HttpMsgCallback>(L, 4);
                    string appkey = LuaAPI.lua_tostring(L, 5);
                    
                    BoyApp.SendHttpMsgWithSign( url, method, param, callback, appkey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAssetBundlePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = BoyApp.GetAssetBundlePath( name );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAssetBundleVer_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        int __cl_gen_ret = BoyApp.GetAssetBundleVer( name );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextAssetsFromResouces_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = BoyApp.GetTextAssetsFromResouces( name );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextAssetsFromPersistent_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = BoyApp.GetTextAssetsFromPersistent( name );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveTextAssetsToPersistent_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    string txt = LuaAPI.lua_tostring(L, 2);
                    
                    BoyApp.SaveTextAssetsToPersistent( name, txt );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveVersionInfo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int pkgver = LuaAPI.xlua_tointeger(L, 1);
                    
                    BoyApp.SaveVersionInfo( pkgver );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAssetBundle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    LoadingCallback callback = translator.GetDelegate<LoadingCallback>(L, 2);
                    
                    BoyApp.LoadAssetBundle( name, callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAssetBundle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    string path = LuaAPI.lua_tostring(L, 2);
                    int ver = LuaAPI.xlua_tointeger(L, 3);
                    UpdateCallback callback = translator.GetDelegate<UpdateCallback>(L, 4);
                    
                    BoyApp.UpdateAssetBundle( name, path, ver, callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DownloadAsseBundle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string path = LuaAPI.lua_tostring(L, 1);
                    int ver = LuaAPI.xlua_tointeger(L, 2);
                    DownloadCallback callback = translator.GetDelegate<DownloadCallback>(L, 3);
                    
                        System.Collections.IEnumerator __cl_gen_ret = BoyApp.DownloadAsseBundle( path, ver, callback );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAssetBundleAndAllDependencies_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    LoadingCallback callback = translator.GetDelegate<LoadingCallback>(L, 2);
                    
                    BoyApp.LoadAssetBundleAndAllDependencies( name, callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_manifestAssetBundle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BoyApp.manifestAssetBundle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_manifest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BoyApp.manifest);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localFileVer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BoyApp.localFileVer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localFileInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BoyApp.localFileInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_g_LuaEnv(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BoyApp.g_LuaEnv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wsGame(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, BoyApp.wsGame);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_manifestAssetBundle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BoyApp.manifestAssetBundle = (UnityEngine.AssetBundle)translator.GetObject(L, 1, typeof(UnityEngine.AssetBundle));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_manifest(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BoyApp.manifest = (UnityEngine.AssetBundleManifest)translator.GetObject(L, 1, typeof(UnityEngine.AssetBundleManifest));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localFileVer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BoyApp.localFileVer = (System.Collections.Generic.Dictionary<string, int>)translator.GetObject(L, 1, typeof(System.Collections.Generic.Dictionary<string, int>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localFileInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BoyApp.localFileInfo = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 1, typeof(System.Collections.Generic.Dictionary<string, string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_g_LuaEnv(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BoyApp.g_LuaEnv = (XLua.LuaEnv)translator.GetObject(L, 1, typeof(XLua.LuaEnv));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wsGame(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    BoyApp.wsGame = (WsGame)translator.GetObject(L, 1, typeof(WsGame));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
