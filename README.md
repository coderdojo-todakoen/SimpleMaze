# micro:bitで操作する迷路
Unityで作った迷路を、micro:bitで操作して、ゴールを目指します。  
[micro:bitの加速度センサの値をUnityで取得](https://github.com/coderdojo-todakoen/Accelerometer)と同じように、micro:bitからBluetoothで送られてくる加速度センサの値を、Mac上で動作するUnityで取得し、画面に表示した迷路を傾けることで、迷路の中を移動します。

## 動作環境
### MacOS
- MacOS Catalina 10.15.3
- Unity 2019.3.6f1

でのみ動作の確認をおこないました。  
BluetoothをONにしてください。micro:bitとペアリングする必要はありません。

### micro:bit
microbitフォルダにあるhexファイルを、micro:bitに書き込みます。

Unityのプログラムを開始すると、Bluetoothをスキャンして、最初に見つかったmicro:bitと接続します。必ずmicro:bitを先に電源に接続してください。    
Mac上のUnityのエディタ環境・スタンドアロン環境での動作を確認しました。
