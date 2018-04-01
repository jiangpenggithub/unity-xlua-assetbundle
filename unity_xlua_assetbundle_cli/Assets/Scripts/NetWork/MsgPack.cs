using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MsgPack {

    private int _position;
    private byte[] _buffer;

    public MsgPack(byte[] buf) {
        this._buffer = buf;
        if (this._buffer == null) this._buffer = new byte[64 * 1024];
        this._position = 0;
    }

    public void Reset() {
        this._position = 0;
    }

    public byte[] GetBuffer() {
        byte[] buf = new byte[this._position];
        Array.Copy(this._buffer, buf, this._position);
        return buf;
    }

    public void Realloc(int len) { 
        if (this._position + len > this._buffer.Length) {
            int newLength = this._buffer.Length + Math.Max(len, 64 * 1024);
            byte[] newBuffer = new byte[newLength];
            Array.Copy(this._buffer, newBuffer, this._buffer.Length);
            this._buffer = newBuffer;
		}
    }


    public void PackInt32(int value) {
        this.Realloc(4);
        byte[] intBuff = BitConverter.GetBytes(value);
        this._buffer[this._position] = intBuff[0];
        this._buffer[this._position + 1] = intBuff[1];
        this._buffer[this._position + 2] = intBuff[2];
        this._buffer[this._position + 3] = intBuff[3];

        this._position += 4;
    }

    public void PackProtoID(int value) {
        this.PackInt32(value);
    }

    public void PackString(string value) {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        this.PackInt32(bytes.Length);

        this.Realloc(bytes.Length);
        Array.Copy(bytes, 0, this._buffer, this._position, bytes.Length);
        this._position += bytes.Length;
    }


    public int UnPackInt32() {        
        int val = BitConverter.ToInt32(this._buffer, this._position);
        this._position += 4;
        return val;
    }

    public int UnPackProtoID() {
        return this.UnPackInt32();
    }

    public string UnPackString() {
        int len = this.UnPackInt32();
        string val = Encoding.UTF8.GetString(this._buffer, this._position, len);
        this._position += len;
        return val;
    }

}
