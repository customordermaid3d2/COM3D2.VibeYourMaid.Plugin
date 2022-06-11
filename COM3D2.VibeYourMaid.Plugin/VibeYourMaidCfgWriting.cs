using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CM3D2.VibeYourMaid.Plugin
{

    //GUIで設定保存したい変数はここ
    public class VibeYourMaidCfgWriting
    {  //@API実装//→API用にpublicに変更

        public VibeYourMaidCfgWriting()
        {
            //　表情テーブル　（バイブ）
            sFaceAnime20Vibe = new string[][] {
            new string[] { "困った" , "ダンス困り顔" , "恥ずかしい" , "苦笑い" , "エロ羞恥１" , "まぶたギュ" },
            new string[] { "困った" , "ダンス困り顔" , "恥ずかしい" , "苦笑い" , "エロ羞恥１" , "まぶたギュ" },
            new string[] { "怒り" , "興奮射精後１" , "発情" , "エロ痛み２" , "エロ羞恥２" , "エロ我慢３" },
            new string[] { "怒り" , "興奮射精後１" , "発情" , "エロ痛み２" , "エロ羞恥２" , "エロ我慢３" }
            };
            sFaceAnime30Vibe = new string[][] {
            new string[] { "エロ痛み１" , "エロ痛み２" , "エロ我慢１" , "エロ我慢２" , "泣き" , "怒り" },
            new string[] { "エロ痛み１" , "エロ痛み２" , "エロ我慢１" , "エロ我慢２" , "泣き" , "怒り" },
            new string[] { "エロ痛み我慢" , "エロ痛み我慢２" , "エロ痛み我慢３" , "エロメソ泣き" , "エロ羞恥３" , "エロ我慢３" },
            new string[] { "エロ痛み我慢" , "エロ痛み我慢２" , "エロ痛み我慢３" , "エロメソ泣き" , "エロ羞恥３" , "エロ我慢３" }
            };
            sFaceAnime40Vibe = new string[] { "少し怒り", "思案伏せ目", "まぶたギュ", "エロメソ泣き" };

            sFaceAnimeStun = new string[] { "絶頂射精後１", "興奮射精後１", "エロメソ泣き", "エロ痛み２", "エロ我慢３", "引きつり笑顔", "エロ通常３", "泣き" };


            //　シェイプキーアニメリスト
            ShapeListR = new string[] { "randamX", "randamY" };
            ShapeListW = new string[] { "X1", "Y1", "waveX", "waveY" };
            ShapeListW2 = new string[] { "逆反復" };
            ShapeListI = new string[] { "シェイプキーを記述" };

            // 一般設定
            keyPluginToggleV0 = KeyCode.I;        //　本プラグインの有効無効の切替キー（Ｉキー）
            keyPluginToggleV1 = KeyCode.O;        //　GUI表示切り替えキー（Ｏキー）
            keyPluginToggleV2 = KeyCode.J;        //　バイブ停止キー（Ｊキー）
            keyPluginToggleV3 = KeyCode.K;        //　バイブ弱キー（Ｋキー）
            keyPluginToggleV4 = KeyCode.L;        //　バイブ強キー（Ｌキー）
            keyPluginToggleV5 = KeyCode.P;        //　メイド切替（Ｐキー）
            keyPluginToggleV6 = KeyCode.N;        //　男表示切替（Ｎキー）
            keyPluginToggleV7 = KeyCode.Keypad1;        //　一人称視点切替（テンキー１）
            keyPluginToggleV8 = KeyCode.Keypad2;        //　快感値ロック（テンキー２）
            keyPluginToggleV9 = KeyCode.Keypad3;        //　絶頂値ロック（テンキー３）
            keyPluginToggleV10 = KeyCode.Keypad4;        //　オートモード切り替え
            keyPluginToggleV11 = KeyCode.Keypad9;        //　エンパイアズライフスタート

            bPluginEnabledV = true;                 //　本プラグインの有効状態（下記キーでON/OFFトグル）
            mainGuiFlag = 1;                            //　GUIの表示フラグ（0：非表示、1：表示、2：最小化）
            subGuiFlag = 1;                            //　サブキャラ操作画面の表示フラグ
            configGuiFlag = false;                      //　設定画面の表示フラグ
            unzipGuiFlag = false;                      //　命令画面の表示フラグ
            bVoiceOverrideEnabledV = true;          //　キス時の音声オーバライド（上書き）機能を使う
            iYodareAppearLevelV = 3;                 //　所定の興奮レベル以上でよだれをつける（１～４のどれかを入れる、０で無効） 
            vExciteLevelThresholdV1 = 100;           //　興奮レベル１→２閾値
            vExciteLevelThresholdV2 = 180;           //　興奮レベル２→３閾値
            vExciteLevelThresholdV3 = 250;           //　興奮レベル３→４閾値

            //改変　表情管理（バイブ）
            vStateAltTimeVBase = 180;                 //　フェイスアニメの変化時間（秒）
            vStateAltTimeVRandomExtend = 240;         //　変化時間へのランダム加算（秒）
            fAnimeFadeTimeV = 1.0f;                //　バイブモードのフェイスアニメ等のフェード時間（秒）

            voiceHoldTimeBase = 240;
            voiceHoldTimeRandomExtend = 360;

            //　バイブ弱時のアニメーション設定
            RandamMin1 = 0f;
            RandamMax1 = 30f;

            WaveMin1 = 0f;
            WaveMax1 = 100f;
            WaveSpead1 = 12f;

            IncreaseMax1 = 100f;
            IncreaseSpead1 = 5f;

            //　バイブ強時のアニメーション設定
            RandamMin2 = 0f;
            RandamMax2 = 60f;

            WaveMin2 = 0f;
            WaveMax2 = 100f;
            WaveSpead2 = 20f;

            IncreaseMax2 = 100f;
            IncreaseSpead2 = 10f;


            //　痙攣幅の設定
            orgasmValue1 = 15f;
            orgasmValue2 = 30f;
            orgasmValue3 = 40f;

            //　クリトリス勃起上限
            clitorisMax = 100;

            //　ちんぽ勃起設定
            ChinpoMax = 100f;
            ChinpoMin = 50f;
            SoriMax = 100f;
            SoriMin = 50f;
            TamaValue = 0f;

            //有効シーン設定
            SceneList = new int[] { 3, 20, 22, 5, 4, 15, 26, 24, 28, 27, 30, 31, 32, 34, 35, 36, 37, 43 };


            //演出有効フラグ
            NamidaEnabled = true;
            HohoEnabled = true;
            YodareEnabled = true;
            CliAnimeEnabled = true;
            OrgsmAnimeEnabled = false;
            SioEnabled = true;
            NyoEnabled = true;
            AheEnabled = true;
            aseAnimeEnabled = true;
            zViceWaitEnabled = true;

            MouthNomalEnabled = true;
            MouthKissEnabled = true;
            MouthFeraEnabled = true;
            MouthZeccyouEnabled = true;

            hibuAnime1Enabled = true;
            kupaWave = 5f;

            hibuAnime2Enabled = true;

            uDatsuEnabled = false;
            osawariEnabled = true;

            ClearEnabled = false;
            TaikiEnabled = true;
            CamChangeEnabled = true;

            camCheckEnabled = true;
            camCheckRange = 0.4f;

            autoManEnabled = true;
            autoMoveEnabled = true;

            andKeyEnabled = new bool[] { false, false, false };

            SelectSE = 2;

            ntrBlock = true;

            majEnabled = true;
            majItemClear = true;
            majKupaEnabled = true;

            faceUse = true;
            dressUse = true;
        }
        public string[][] sFaceAnime20Vibe;
        public string[][] sFaceAnime30Vibe;
        public string[] sFaceAnime40Vibe;
        public string[] sFaceAnimeStun;
        public string[] ShapeListR;
        public string[] ShapeListW;
        public string[] ShapeListW2;
        public string[] ShapeListI;
        public KeyCode keyPluginToggleV0;
        public KeyCode keyPluginToggleV1;
        public KeyCode keyPluginToggleV2;
        public KeyCode keyPluginToggleV3;
        public KeyCode keyPluginToggleV4;
        public KeyCode keyPluginToggleV5;
        public KeyCode keyPluginToggleV6;
        public KeyCode keyPluginToggleV7;
        public KeyCode keyPluginToggleV8;
        public KeyCode keyPluginToggleV9;
        public KeyCode keyPluginToggleV10;
        public KeyCode keyPluginToggleV11;
        public bool bPluginEnabledV;
        public int mainGuiFlag;
        public int subGuiFlag;
        public bool configGuiFlag;
        public bool unzipGuiFlag;
        public bool bVoiceOverrideEnabledV;
        public int iYodareAppearLevelV;
        public int vExciteLevelThresholdV1;
        public int vExciteLevelThresholdV2;
        public int vExciteLevelThresholdV3;
        public float vStateAltTimeVBase;
        public float vStateAltTimeVRandomExtend;
        public float fAnimeFadeTimeV;
        public float voiceHoldTimeBase;
        public float voiceHoldTimeRandomExtend;
        public float RandamMin1;
        public float RandamMax1;
        public float WaveMin1;
        public float WaveMax1;
        public float WaveSpead1;
        public float IncreaseMax1;
        public float IncreaseSpead1;
        public float RandamMin2;
        public float RandamMax2;
        public float WaveMin2;
        public float WaveMax2;
        public float WaveSpead2;
        public float IncreaseMax2;
        public float IncreaseSpead2;
        public float orgasmValue1;
        public float orgasmValue2;
        public float orgasmValue3;
        public int clitorisMax;
        public float ChinpoMax;
        public float ChinpoMin;
        public float SoriMax;
        public float SoriMin;
        public float TamaValue;
        public int[] SceneList;
        public bool NamidaEnabled;
        public bool HohoEnabled;
        public bool YodareEnabled;
        public bool CliAnimeEnabled;
        public bool OrgsmAnimeEnabled;
        public bool SioEnabled;
        public bool NyoEnabled;
        public bool AheEnabled;
        public bool aseAnimeEnabled;
        public bool zViceWaitEnabled;
        public bool MouthNomalEnabled;
        public bool MouthKissEnabled;
        public bool MouthFeraEnabled;
        public bool MouthZeccyouEnabled;
        public bool hibuAnime1Enabled;
        public float kupaWave;
        public bool hibuAnime2Enabled;
        public bool ClearEnabled;
        public bool TaikiEnabled;
        public bool CamChangeEnabled;
        public bool camCheckEnabled;
        public float camCheckRange;
        public bool autoManEnabled;
        public bool autoMoveEnabled;
        public bool[] andKeyEnabled;
        public int SelectSE;
        public bool ntrBlock;
        public bool majEnabled;
        public bool majItemClear;
        public bool majKupaEnabled;
        public bool uDatsuEnabled;
        public bool osawariEnabled;

        public bool faceUse;
        public bool dressUse;
    }
}
