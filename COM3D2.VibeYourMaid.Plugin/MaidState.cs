using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CM3D2.VibeYourMaid.Plugin
{
    public class MaidState
    {

        public MaidState()
        {
            maidHead = null;
            maidMune = null;
            maidHara = null;
            maidXxx = null;
            vStateMajor = 10;
            vStateMajorOld = 10;
            vLevel = 0;
            linkEnabled = false;
            linkID = -1;
            visibleBack = false;
            sVibeFlag = false;
            voiceMode = 0;
            voiceMode2 = 0;
            pAutoSelect = 0;
            pAutoTime = 0f;
            eAutoSelect = false;
            eAutoTime = 0f;
            mAutoTimeL = 0f;
            mAutoTimeS = 0f;
            iRandomVoiceBackup = 0;
            voiceHoldTime = 0f;
            faceHoldTime = 0f;
            yoinHoldTime = 0f;
            stateAltTime1 = 0;
            stateAltTime2 = 0;
            faceAnimeBackup = "";
            faceBlendBackup = "";
            sekimenValue = 0f;
            kaikanLevel = 0;
            editVoiceSetName = "";
            editVoiceSet = new List<string[]>();
            vsTime = 0f;
            vsFlag = 0;
            vsInterval = 1000f;
            aheValue = 0;
            aheValue2 = 0;
            fAheDefEyeL = -9999f;
            fAheDefEyeR = -9999f;
            aheResetFlag = false;
            exciteLevel = 1;
            exciteValue = 0f;
            resistBase = 10f;
            resistBonus = 0f;
            resistValue = 0f;
            boostBase = 0.5f;
            boostBonus = 0f;
            boostValue = 0f;
            jirashi = 0f;
            maidStamina = 3000f;
            stunFlag = false;
            orgasmValue = 0f;
            orgasmCount = 0;
            orgasmCmb = 0;
            orgasmHoldTime = 0f;
            orgasmVoice = 0;
            orgasmStart = false;
            continuationTime = 0f;
            bIsBlowjobing = 0;
            zAnimeFileName = "";
            motionHoldTime = 0f;
            motionAltTime = 0;
            mcFlag = -1;
            maidMotionBackup = "";
            motionID = -1;
            baceMotion = "";
            inMotion = "Non";
            outMotion = "Non";
            syaseiMotion = "Non";
            analMotion = "Non";
            motionSissinMove = "Non";
            motionSissinTaiki = "Non";
            senyouTokusyuMotion = new List<string>();
            analMode = false;
            majHiBack = 0f;
            majFwBack = 0f;
            majRollBack = 0f;
            majMaidRollBack = 0;
            majManRollBack = 0;
            syaseiMarks = new int[] { 0, 0, 0, 0, 0 };
            giveSexual = new bool[] { false, false, false, false, false, false, false, false, false, false };
            elItazuraFlag = false;
            editMotionSetName = "";
            editMotionSet = new List<List<string>>();
            msTime1 = 0f;
            msTime2 = 0f;
            msCategory = 0;
            mOnceFlag = false;
            mOnceBack = "";
            bokkiValue1 = 0f;
            cliMode = 0;
            uDatsu = 0;
            bokkiResetFlag = false;
            labiaValue = 0;
            pikuFlag = false;
            pikuTime = 0;
            pikuTime2 = 0;
            hibuValue = 0;
            analValue = 0;
            uDatsuValue1 = 0;
            uDatsuValue2 = 0;
            uDatsuStock = 0;
            uDatsuWait = 90f;
            hibuSlider1Value = 10f;
            analSlider1Value = 10f;
            hibuSlider2Value = 3f;
            analSlider2Value = 3f;
            gakupikuResetFlag = false;
            gakupikuTime = 0;
            gakupikuFlag = true;
            gakupikuOn = false;
            gakupikuValue = 0f;
            chinpoValue1 = 0f;
            soriValue1 = 0f;
            aseResetFlag = false;
            aseTime = 0f;
            cameraCheck = false;
            eyeToCamOld = false;
            headToCamOld = false;
            MouthHoldTime = 0f;
            MouthMode = 0;
            OldMode = 0;
            MaValue = 0f;
            MiValue = 0f;
            MdwValue = 0f;
            TupValue = 0f;
            ToutValue = 0f;
            TopenValue = 0f;
            TupValue2 = 0.3f;
            ToutValue2 = 0.3f;
            TopenValue2 = 0.4f;
            maVBack = 1f;
            miVBack = 1f;
            mdwVBack = 1f;
            fToiki1 = false;
            fToiki2 = false;
            fAieki1 = false;
            fAieki2 = false;
            fAieki3 = false;
            fSio = false;
            fSio2 = false;
            sioTime = 0f;
            sioTime2 = 0f;
            sioVolume = 0f;
            nyoVolume = 0f;
            kupaWaveValue = 0f;
            kupaWaveRe = 1f;
            shapeKeyWaveValue = 0f;
            shapeKeyWaveRe = 1f;
            shapeKeyIncreaseValue = 0f;
            shapeKeyRandomInterval = 0.01f;
            shapeKeyRandomDelta = 0f;
            itemV = "";
            itemA = "";
            cliHidai = 0f;
            chikubiHidai = 0.2f;
            orgTotal = 0;
            orgMax = 0;
            orgTotalChitsu = 0;
            orgTotalAnal = 0;
            orgTotalEtc = 0;
            syaseiTotal1 = new int[] { 0, 0, 0, 0 };
            syaseiTotal2 = new float[] { 0f, 0f, 0f, 0f };
            sioTotal1 = 0;
            nyoTotal1 = 0;
            sioTotal2 = 0f;
            nyoTotal2 = 0f;
            stanTotal = 0;
            uDatsuTotal = 0;
            bodyName = "";
            targetSphere_mouth = null;
            targetSphere_muneR = null;
            targetSphere_muneL = null;
            targetSphere_vagina = null;
            targetSphere_hipL = null;
            targetSphere_hipR = null;
            targetSphere_anal = null;
            IK_mouth = null;
            IK_muneR = null;
            IK_muneL = null;
            IK_vagina = null;
            IK_hipL = null;
            Hip_L = null;
            IK_hipR = null;
            Hip_R = null;
            IK_anal = null;
            chikubi_View = -1;
            chikubiEnabled = false;
            chikubiBokkiEnabled = true;
            tits_chikubi_def = new float[] { 0f, 0f };
            tits_chikubi_perky = new float[] { 0f, 0f };
            tits_chikubi_cow = new float[] { 0f, 0f };
            tits_chikubi_observe = new float[] { 0f, 0f };
            tits_chikubi_wide = new float[] { 0f, 0f };
            tits_chikubi_ultralong = new float[] { 0f, 0f };
            tits_chikubi_ultrawide = new float[] { 0f, 0f };
            tits_chikubi_ultratare = new float[] { 0f, 0f };
            tits_chikubi_kanbotsu_n = new float[] { 0f, 0f };
            tits_chikubi_kanbotsu_s = new float[] { 0f, 0f };
            tits_chikubi_kanbotsu_p = new float[] { 0f, 0f };
            tits_nipple_def = new float[] { 0f, 0f };
            tits_nipple_perky1 = new float[] { 0f, 0f };
            tits_nipple_perky2 = new float[] { 0f, 0f };
            tits_nipple_long1 = new float[] { 0f, 0f };
            tits_nipple_long2 = new float[] { 0f, 0f };
            tits_nipple_wide = new float[] { 0f, 0f };
            tits_nipple_puffy = new float[] { 0f, 0f };
            tits_nipple_kupa = new float[] { 0f, 0f };
            tits_munel_chippai = new float[] { 0f, 0f };
        }

        public Transform maidHead = null;  //メイドの頭位置取得用
        public Transform maidMune = null;  //メイドの胸位置取得用
        public Transform maidHara = null;  //メイドの股間位置取得用
        public Transform maidXxx = null;  //メイドの股間位置取得用

        public int vStateMajor = 10;        //強弱によるステート
        public int vStateMajorOld = 10;     //強弱によるステート（前回値）
        public int vLevel = 0;                //バイブ状態
        public bool linkEnabled = false;  //メインメイドとリンクさせるかどうか
        public int linkID = -1;  //リンクメイドのID
        public bool visibleBack = false;  //メイドがもともと表示されていたかのチェック

        public bool sVibeFlag = false;

        //ボイスモードのセレクト用
        public int voiceMode = 0;
        public int voiceMode2 = 0;
        public bool autoVoiceEnabled = true;
        public int iRandomVoiceBackup = 0;

        //オートモード用
        public int pAutoSelect = 0;
        public float pAutoTime = 0f;  //責めのオート変更時間
        public bool eAutoSelect = false;
        public float eAutoTime = 0f;  //目線のオート変更時間
        public float mAutoTimeL = 0f;  //大カテゴリモーションのオート変更時間
        public float mAutoTimeS = 0f;  //小カテゴリモーションのオート変更時間

        //表情・音声管理
        public float voiceHoldTime;
        public float faceHoldTime;
        public float yoinHoldTime;
        public int stateAltTime1;
        public int stateAltTime2;
        public string faceAnimeBackup = "";
        public string faceBlendBackup = "";
        public float sekimenValue = 0f;
        public int kaikanLevel;

        //ボイスセット用
        public string editVoiceSetName = "";
        public List<string[]> editVoiceSet = new List<string[]>();
        public float vsTime = 0f;
        public int vsFlag = 0;
        public float vsInterval = 1000f;

        //瞳操作関連
        public float aheValue = 0f;
        public float aheValue2 = 0f;
        public float fAheDefEyeL = -9999f;
        public float fAheDefEyeR = -9999f;
        public bool aheResetFlag = false;


        //興奮度管理
        public int exciteLevel = 1;            //0～300の興奮度を、1～4の興奮レベルに変換した値
        public float exciteValue = 0f;       //現在興奮値

        public float resistBase = 0f;          //抵抗値のベース値
        public float resistBonus = 0f;          //抵抗の特別加算値
        public float resistValue = 0f;          //現在抵抗値

        public float boostBase = 0.5f;            //感度のベース値
        public float boostBonus = 0f;           //感度の特別加算値
        public float boostValue = 0f;           //現在感度
        public float jirashi = 0;            //焦らし度

        public float maidStamina = 3000f;        //スタミナ
        public bool stunFlag = false;

        public float orgasmValue = 0f;            //現在絶頂値　100になると絶頂
        public int orgasmCount = 0;               //絶頂回数
        public int orgasmCmb = 0;                 //連続絶頂回数
        public float orgasmHoldTime = 0f;          //絶頂後のボーナスタイム
        public int orgasmVoice = 0;               //絶頂時音声フラグ
        public bool orgasmStart = false;          //絶頂開始フラグ
        public float continuationTime;             //バイブ責めの継続時間

        //フェラ状態チェック
        public int bIsBlowjobing = 0;
        public string zAnimeFileName = "";

        //モーション変更関連
        public float motionHoldTime = 0f;
        public int motionAltTime = 0;
        public int mcFlag = -1;
        public string maidMotionBackup = "";
        public int motionID = -1;
        public string baceMotion = "";
        public string inMotion = "Non";
        public string outMotion = "Non";
        public string syaseiMotion = "Non";
        public string analMotion = "Non";
        public string motionSissinMove = "Non";
        public string motionSissinTaiki = "Non";
        public List<string> senyouTokusyuMotion = new List<string>();
        public bool analMode = false;
        public float majHiBack = 0f;
        public float majFwBack = 0f;
        public float majRollBack = 0f;
        public int majMaidRollBack = 0;
        public int majManRollBack = 0;
        public int[] syaseiMarks = new int[] { 0, 0, 0, 0, 0 };
        public bool[] giveSexual = new bool[] { false, false, false, false, false, false, false, false, false, false };
        public bool elItazuraFlag = false;

        //モーションセット関連
        public string editMotionSetName = "";
        public List<List<string>> editMotionSet = new List<List<string>>();
        public float msTime1 = 0f;
        public float msTime2 = 0f;
        public int msCategory = 0;
        public bool mOnceFlag = false;
        public string mOnceBack = "";

        //秘部操作関連
        public float bokkiValue1 = 0f;              //　クリ勃起値
        public int cliMode = 0;                     //クリモード(1:通常、2:巨クリ、3:ふたなり)
        public int uDatsu = 0;  //子宮脱フラグ
        public bool bokkiResetFlag = false;
        public float labiaValue = 0;
        public bool pikuFlag = false;
        public float pikuTime = 0;
        public float pikuTime2 = 0;
        public float hibuValue = 0;
        public float analValue = 0;
        public float uDatsuValue1 = 0;
        public float uDatsuValue2 = 0;
        public float uDatsuStock = 0;
        public float uDatsuWait = 90f;
        public float hibuSlider1Value = 12f;
        public float analSlider1Value = 12f;
        public float hibuSlider2Value = 3f;
        public float analSlider2Value = 3f;

        //痙攣関係
        public bool gakupikuResetFlag = false;
        public float gakupikuTime = 0;                          //痙攣時間判定
        public bool gakupikuFlag = true;                        //痙攣動作フラグ
        public bool gakupikuOn = false;
        public float gakupikuValue = 0f;

        //ちんぽ操作関連
        public float chinpoValue1 = 0f;              //　ちんぽ勃起値
        public float soriValue1 = 0f;                //　ちんぽ反り値

        //汗関連
        public bool aseResetFlag = false;
        public float aseTime = 0f;

        //カメラが顔に近づいているかどうか
        public bool cameraCheck = false;
        public bool eyeToCamOld = false;
        public bool headToCamOld = false;

        //メイドの口元変更
        public float MouthHoldTime = 0f;
        public int MouthMode = 0;
        public int OldMode = 0;
        public float MaValue = 0f;
        public float MiValue = 0f;
        public float MdwValue = 0f;
        public float TupValue = 0f;
        public float ToutValue = 0f;
        public float TopenValue = 0f;
        public float TupValue2 = 0.3f;
        public float ToutValue2 = 0.3f;
        public float TopenValue2 = 0.4f;
        public float maVBack = 1f;
        public float miVBack = 1f;
        public float mdwVBack = 1f;

        //演出関係
        public bool fToiki1 = false;
        public bool fToiki2 = false;
        public bool fAieki1 = false;
        public bool fAieki2 = false;
        public bool fAieki3 = false;
        public bool fSio = false;
        public bool fSio2 = false;
        public float sioTime = 0f;
        public float sioTime2 = 0f;
        public float sioVolume = 0f;
        public float nyoVolume = 0f;

        //シェイプキー関連
        public float kupaWaveValue = 0f;
        public float kupaWaveRe = 1f;
        public float shapeKeyWaveValue = 0f;
        public float shapeKeyWaveRe = 1f;
        public float shapeKeyIncreaseValue = 0f;
        public float shapeKeyRandomInterval = 0.01f; // 動作間隔(秒)
        public float shapeKeyRandomDelta = 0f;       // 前回動作からの経過時間

        //アイテム関連
        public string itemV = "";
        public string itemA = "";

        //エロステータス・経験値関連
        public float cliHidai = 0f; //クリトリス肥大度
        public float chikubiHidai = 0.2f; //乳首肥大度

        public int orgTotal = 0; //トータル絶頂数
        public int orgMax = 0; //最大連続絶頂数

        public int orgTotalChitsu = 0; //トータル絶頂数（膣）
        public int orgTotalAnal = 0; //トータル絶頂数（アナル）
        public int orgTotalEtc = 0; //トータル絶頂数（その他）

        public int[] syaseiTotal1 = new int[] { 0, 0, 0, 0 }; //射精回数（膣、アナル、口、外）
        public float[] syaseiTotal2 = new float[] { 0f, 0f, 0f, 0f }; //射精量（膣、アナル、口、外）

        public int sioTotal1 = 0; //潮吹き回数
        public int nyoTotal1 = 0; //放尿回数
        public float sioTotal2 = 0f; //潮吹き量
        public float nyoTotal2 = 0f; //放尿量

        public int stanTotal = 0; //失神回数
        public int uDatsuTotal = 0; //子宮脱回数

        //お触り関連
        public string bodyName = "";
        public GameObject targetSphere_mouth = null;
        public GameObject targetSphere_muneR = null;
        public GameObject targetSphere_muneL = null;
        public GameObject targetSphere_vagina = null;
        public GameObject targetSphere_hipL = null;
        public GameObject targetSphere_hipR = null;
        public GameObject targetSphere_anal = null;
        public Transform IK_mouth = null;
        public Transform IK_muneR = null;
        public Transform IK_muneL = null;
        public Transform IK_vagina = null;
        public Transform IK_hipL = null;
        public Transform Hip_L = null;
        public Transform IK_hipR = null;
        public Transform Hip_R = null;
        public Transform IK_anal = null;

        //乳首関連
        public int chikubi_View = -1;
        public bool chikubiEnabled = false;
        public bool chikubiBokkiEnabled = true;
        public float[] tits_chikubi_def = new float[] { 0f, 0f };  //デフォルト乳首と同じような形。先端だけ。
        public float[] tits_chikubi_perky = new float[] { 0f, 0f };  //乳首が少し長くなる。ツンツン乳首
        public float[] tits_chikubi_cow = new float[] { 0f, 0f };  //乳首が伸びる、うしちちっぽく。
        public float[] tits_chikubi_observe = new float[] { 0f, 0f };  //乳首周囲がへこむ。服と胸との隙間を作るキー。
        public float[] tits_chikubi_wide = new float[] { 0f, 0f };  //乳首が少し広がる。
        public float[] tits_chikubi_ultralong = new float[] { 0f, 0f };  //乳首がすごく長くなるキー。
        public float[] tits_chikubi_ultrawide = new float[] { 0f, 0f };  //乳首がすごく膨らむキー。
        public float[] tits_chikubi_ultratare = new float[] { 0f, 0f };  //乳首がすごく垂れるキー。
        public float[] tits_chikubi_kanbotsu_n = new float[] { 0f, 0f };  //陥没乳首ノーマル。
        public float[] tits_chikubi_kanbotsu_s = new float[] { 0f, 0f };  //陥没乳首、少し。
        public float[] tits_chikubi_kanbotsu_p = new float[] { 0f, 0f };  //陥没乳首、ポンカン型、perkyキーですこし乳首が伸ばせるタイプ。
        public float[] tits_nipple_def = new float[] { 0f, 0f };  //デフォルト乳首と同じような形を再現するキー。乳輪あたりも。
        public float[] tits_nipple_perky1 = new float[] { 0f, 0f };  //ツンツン乳輪、乳首も少し出ます。
        public float[] tits_nipple_perky2 = new float[] { 0f, 0f };  //ツンツン乳輪、乳首は出ないタイプ。
        public float[] tits_nipple_long1 = new float[] { 0f, 0f };  //乳首周辺が伸びる。
        public float[] tits_nipple_long2 = new float[] { 0f, 0f };  //乳首周辺が伸びる2。
        public float[] tits_nipple_wide = new float[] { 0f, 0f };  //乳輪が広がる。
        public float[] tits_nipple_puffy = new float[] { 0f, 0f };  //ぷっくり乳首。
        public float[] tits_nipple_kupa = new float[] { 0f, 0f };  //乳首くぱ。
        public float[] tits_munel_chippai = new float[] { 0f, 0f };  //ちっぱい
    }
}
