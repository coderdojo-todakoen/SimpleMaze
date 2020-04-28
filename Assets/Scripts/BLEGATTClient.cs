using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BLEGATTClient
{
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    // Mac OSX用のプラグインの
    [DllImport ("BLEPlugin")]
    private static extern void start(int enable);
    [DllImport ("BLEPlugin")]
    private static extern Int16 getAccelerometerDataX();
    [DllImport ("BLEPlugin")]
    private static extern Int16 getAccelerometerDataY();
    [DllImport ("BLEPlugin")]
    private static extern Int16 getAccelerometerDataZ();
    [DllImport ("BLEPlugin")]
    private static extern Int16 getMagnetometerDataX();
    [DllImport ("BLEPlugin")]
    private static extern Int16 getMagnetometerDataY();
    [DllImport ("BLEPlugin")]
    private static extern Int16 getMagnetometerDataZ();
    [DllImport ("BLEPlugin")]
    private static extern UInt16 getCompassBearing();
    [DllImport ("BLEPlugin")]
    private static extern byte getButtonAState();
    [DllImport ("BLEPlugin")]
    private static extern byte getButtonBState();

    public delegate void DebugLogDelegate(string str);
    DebugLogDelegate debugLogFunc = msg => Debug.Log(msg);

    [DllImport ("BLEPlugin")]
    public static extern void set_debug_log_func(DebugLogDelegate func);
#endif
#if !UNITY_EDITOR && UNITY_IOS
    [DllImport ("__Internal")]
    private static extern void start(int enable);
    [DllImport ("__Internal")]
    private static extern Int16 getAccelerometerDataX();
    [DllImport ("__Internal")]
    private static extern Int16 getAccelerometerDataY();
    [DllImport ("__Internal")]
    private static extern Int16 getAccelerometerDataZ();
    [DllImport ("__Internal")]
    private static extern Int16 getMagnetometerDataX();
    [DllImport ("__Internal")]
    private static extern Int16 getMagnetometerDataY();
    [DllImport ("__Internal")]
    private static extern Int16 getMagnetometerDataZ();
    [DllImport ("__Internal")]
    private static extern UInt16 getCompassBearing();
    [DllImport ("__Internal")]
    private static extern byte getButtonAState();
    [DllImport ("__Internal")]
    private static extern byte getButtonBState();

    void DebugLog(string msg)
    {
        Debug.Log(msg);
    }
#endif

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
    public Int16 accelerometerDataX
    {
        get { return getAccelerometerDataX(); }
    }
    public Int16 accelerometerDataY
    {
        get { return getAccelerometerDataY(); }
    }
    public Int16 accelerometerDataZ
    {
        get { return getAccelerometerDataZ(); }
    }
    public Int16 magnetometerDataX
    {
        get { return getMagnetometerDataX(); }
    }
    public Int16 magnetometerDataY
    {
        get { return getMagnetometerDataY(); }
    }
    public Int16 magnetometerDataZ
    {
        get { return getMagnetometerDataZ(); }
    }
    public UInt16 compassBearing
    {
        get { return getCompassBearing(); }
    }
    public Byte buttonAState
    {
        get { return getButtonAState(); }
    }
    public Byte buttonBState
    {
        get { return getButtonBState(); }
    }
#else
    // OSX、iOS以外の環境用のスタブ
    public Int16 accelerometerDataX = 0;
    public Int16 accelerometerDataY = 0;
    public Int16 accelerometerDataZ = 0;
    public Int16 magnetometerDataX = 0;
    public Int16 magnetometerDataY = 0;
    public Int16 magnetometerDataZ = 0;
    public UInt16 compassBearing = 0;
    public Byte buttonAState = 0;
    public Byte buttonBState = 0;
#endif

    public void Start(int enable)
    {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        set_debug_log_func(debugLogFunc);
#endif
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
        start(enable);
#endif
    }
}
