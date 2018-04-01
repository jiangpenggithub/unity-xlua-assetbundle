using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using WebSocketSharp;
using XLua;

[CSharpCallLua]
public delegate void ConnectCallback(bool connect);
[CSharpCallLua]
public delegate void OnMessageCallback(string obj);
[LuaCallCSharp]
public class WsGame
{
    private MsgPack _packer;
    private WebSocket _ws;
    private ConnectCallback _callback;
    private OnMessageCallback _msgCallback;
    public WsGame(){
        this._packer = new MsgPack(null);
    }

    public void Connect(string url, ConnectCallback callback, OnMessageCallback msgHandler) {
        if (this._ws != null) {
            this._callback = null;
            this._ws.Close();
        }
        this._callback = callback;
        this._msgCallback = msgHandler;

        _ws = new WebSocket(url);
        _ws.OnOpen += OnOpen;
        _ws.OnMessage += OnMessage;
        _ws.OnError += OnError;
        _ws.OnClose += OnClose;

        _ws.ConnectAsync();
    }

    private void OnOpen(object sender, EventArgs e)
    {
        BoyApp.PushEvent(delegate (){
            this._callback(true);
        });
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        try
        {
            MsgPack packer = new MsgPack(e.RawData);
            int proto = packer.UnPackProtoID();
            if (proto != (int)COM_GAME_FRAMEWORK.eS2C_Json)
            {
                Debug.Log(proto + " id not support");
                return;
            }
            S2C_Json msg = new S2C_Json();
            msg.Unpack(packer);

            BoyApp.PushEvent(delegate (){
                this._msgCallback(msg.json);
            });
        }
        catch (Exception ee) {
            Debug.LogError(ee.Message);
        }

    }

    private void OnError(object sender, ErrorEventArgs e)
    {

    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        if (this._callback == null) return;
        BoyApp.PushEvent(delegate () {
            this._callback(false);
        });
    }

    public void SendMsg(ProtocolBase msg){
        msg.Pack(this._packer);
        this._ws.SendAsync(this._packer.GetBuffer(), null);
    }

}
