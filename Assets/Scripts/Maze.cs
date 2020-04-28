using System;
using UnityEngine;

public class Maze : MonoBehaviour
{
    BLEGATTClient plugin = new BLEGATTClient();

    void Start()
    {
        // micro:bitと接続します
        plugin.Start(1);
    }

    void Update()
    {
        // 加速度センサの値を取得します
        Int16 ax = plugin.accelerometerDataX;
        Int16 ay = plugin.accelerometerDataY;
        Int16 az = plugin.accelerometerDataZ;

        // x軸、z軸方向の傾きを求めます
        float roll = Mathf.Atan2(-ax, -az) * Mathf.Rad2Deg;
        float pitch = Mathf.Atan2(-ay, Mathf.Sqrt(ax * ax + az * az)) * Mathf.Rad2Deg;

        // 迷路の傾きを設定します
        transform.rotation = Quaternion.Euler(pitch, 0, roll);
    }
}
