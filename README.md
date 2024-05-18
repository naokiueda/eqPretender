# EQ Pretender
smallTool to use Traverse AZ mount as EQ mount

TRAVERSE経緯台を赤道儀として動かすWindowsアプリです。
通常、アプリからトラバースへ接続するところ、EQ Pretender が間に入って赤道儀のフリをします。

① 先にEP Pretenderをトラバースに繋ぎます。
ネットワーク（WiFi）かシリアル（USBケーブル）かを選択して、Runボタン を押すだけです。

![serialsetting](https://github.com/naokiueda/eqPretender/assets/6153725/2fa52220-a01a-4af9-bb7f-d5517071da97)
![networksetting](https://github.com/naokiueda/eqPretender/assets/6153725/8e2e9bc6-996c-43c4-a27c-b0b70f28e431)

 
② 次にアプリからEQ Pretenderに接続します。
そのために必要なアプリ側の設定は以下の3つ。
・リードタイムアウトは400に延ばす
・「デバイスを探す」はOFF
・固定IPには 「127.0.0.1」をセット

![synscanSetting](https://github.com/naokiueda/eqPretender/assets/6153725/ce72cc56-1fea-4c0d-9896-6334490948f4)

これで、アプリから「赤道儀」として接続してください。 
