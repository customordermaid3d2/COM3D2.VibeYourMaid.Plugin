using System;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using UnityEngine;
using UnityInjector.Attributes;
using PluginExt;
using UnityInjector;
using System.Xml;
using System.Threading;
using CM3D2.ExternalSaveData.Managed;


// コンパイル用コマンド　"C:\Windows\Microsoft.NET\Framework\v3.5\csc" /t:library /lib:..\CM3D2x64_Data（環境に合わせて変更）\Managed /r:UnityEngine.dll /r:UnityInjector.dll /r:Assembly-CSharp.dll /r:Assembly-CSharp-firstpass.dll /r:ExIni.dll /r:..\COM3D2.ExternalSaveData.Managed.dll COM3D2.VibeYourMaid.Plugin.cs

namespace CM3D2.VibeYourMaid.Plugin
{

    [
        PluginFilter("COM3D2x64"),
      PluginFilter("COM3D2VRx64"),
      PluginFilter("COM3D2OHx64"),
      PluginFilter("COM3D2OHVRx64"),
      PluginName("VibeYourMaid"),
      PluginVersion("2.0.5.2")]


    public class VibeYourMaid : ExPluginBase
    {

        public BasicVoiceSet[] bvs = new BasicVoiceSet[20]; //性格追加時に更新
        public class BasicVoiceSet
        {

            public BasicVoiceSet(string[][] v1, string[][] v2, string[][] v3, string[][] v4, string[][] v5, string[][] v6, string[] v7)
            {
                sLoopVoice20Vibe = v1;
                sLoopVoice20Fera = v2;
                sLoopVoice30Vibe = v3;
                sLoopVoice30Fera = v4;
                sOrgasmVoice30Vibe = v5;
                sOrgasmVoice30Fera = v6;
                sLoopVoice40Vibe = v7;
            }
            public BasicVoiceSet()
            {
                sLoopVoice20Vibe = new string[][] { };
                sLoopVoice20Fera = new string[][] { };
                sLoopVoice30Vibe = new string[][] { };
                sLoopVoice30Fera = new string[][] { };
                sOrgasmVoice30Vibe = new string[][] { };
                sOrgasmVoice30Fera = new string[][] { };
                sLoopVoice40Vibe = new string[] { };
            }

            //弱バイブ　通常
            public string[][] sLoopVoice20Vibe;
            //弱バイブ　フェラ
            public string[][] sLoopVoice20Fera;
            //強バイブ　通常
            public string[][] sLoopVoice30Vibe;
            //強バイブ　フェラ
            public string[][] sLoopVoice30Fera;
            //絶頂　通常
            public string[][] sOrgasmVoice30Vibe;
            //絶頂　フェラ
            public string[][] sOrgasmVoice30Fera;
            //停止時
            public string[] sLoopVoice40Vibe;
        }



        //性格別声テーブル　ツンデレ---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20PrideVibe = new string[][] {
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20PrideFera = new string[][] {
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30PrideVibe = new string[][] {
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30PrideFera = new string[][] {
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30PrideVibe = new string[][] {
              new string[] { "s0_01898.ogg" , "s0_01899.ogg" , "s0_01902.ogg" , "s0_01900.ogg" },
              new string[] { "s0_01913.ogg" , "s0_01918.ogg" , "s0_01919.ogg" , "s0_01917.ogg" },
              new string[] { "s0_09072.ogg" , "s0_09070.ogg" , "s0_09099.ogg" , "s0_09059.ogg" },
              new string[] { "s0_09067.ogg" , "s0_09068.ogg" , "s0_09069.ogg" , "s0_09071.ogg" , "s0_09085.ogg" , "s0_09086.ogg" , "s0_09087.ogg" , "s0_09091.ogg" },
              new string[] { "s0_01898.ogg" , "s0_01899.ogg" , "s0_01902.ogg" , "s0_01900.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30PrideFera = new string[][] {
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" },
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" },
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" },
              new string[] { "S0_11361.ogg" , "S0_01931.ogg" , "S0_11350.ogg" , "S0_11349.ogg" },
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" }
              };
        //停止時
        public string[] sLoopVoice40PrideVibe = new string[] { "S0_01967.ogg", "S0_01967.ogg", "S0_01968.ogg", "S0_01969.ogg", "S0_01969.ogg" };



        //性格別声テーブル　クーデレ---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20CoolVibe = new string[][] {
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20CoolFera = new string[][] {
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30CoolVibe = new string[][] {
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30CoolFera = new string[][] {
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30CoolVibe = new string[][] {
              new string[] { "s1_03223.ogg" , "s1_03246.ogg" , "s1_03247.ogg" , "s1_03210.ogg" },
              new string[] { "s1_03214.ogg" , "s1_03215.ogg" , "s1_03216.ogg" , "s1_03209.ogg" },
              new string[] { "s1_03207.ogg" , "s1_03205.ogg" , "s1_08993.ogg" , "s1_08971.ogg" },
              new string[] { "s1_09344.ogg" , "s1_09370.ogg" , "s1_09371.ogg" , "s1_09372.ogg" , "s1_09374.ogg" , "s1_09398.ogg" , "s1_09392.ogg" , "s1_09365.ogg" },
              new string[] { "s1_03223.ogg" , "s1_03246.ogg" , "s1_03247.ogg" , "s1_03210.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30CoolFera = new string[][] {
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" },
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" },
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" },
              new string[] { "S1_11440.ogg" , "S1_11429.ogg" , "S1_11952.ogg" , "S1_19221.ogg" },
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" }
              };
        //停止時
        public string[] sLoopVoice40CoolVibe = new string[] { "S1_03264.ogg", "S1_03264.ogg", "S1_03265.ogg", "S1_03266.ogg", "S1_03266.ogg" };



        //性格別声テーブル　純真---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20PureVibe = new string[][] {
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20PureFera = new string[][] {
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30PureVibe = new string[][] {
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30PureFera = new string[][] {
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30PureVibe = new string[][] {
              new string[] { "s2_01478.ogg" , "s2_01477.ogg" , "s2_01476.ogg" , "s2_01475.ogg" },
              new string[] { "s2_01432.ogg" , "s2_01433.ogg" , "s2_01434.ogg" , "s2_01436.ogg" },
              new string[] { "s2_09039.ogg" , "s2_09067.ogg" , "s2_09052.ogg" , "s2_08502.ogg" },
              new string[] { "s2_09047.ogg" , "s2_09048.ogg" , "s2_09049.ogg" , "s2_09050.ogg" , "s2_09051.ogg" , "s2_09066.ogg" , "s2_09069.ogg" , "s2_09073.ogg" },
              new string[] { "s2_01478.ogg" , "s2_01477.ogg" , "s2_01476.ogg" , "s2_01475.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30PureFera = new string[][] {
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" },
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" },
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" },
              new string[] { "S2_11371.ogg" , "S2_11370.ogg" , "S2_11358.ogg" , "S2_11347.ogg" },
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" }
              };
        //停止時
        public string[] sLoopVoice40PureVibe = new string[] { "s2_01491.ogg", "s2_01491.ogg", "s2_01492.ogg", "s2_01493.ogg", "s2_01493.ogg" };



        //性格別声テーブル　ヤンデレ---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20YandereVibe = new string[][] {
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20YandereFera = new string[][] {
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" }
              };

        //強バイブ　通常
        public string[][] sLoopVoice30YandereVibe = new string[][] {
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30YandereFera = new string[][] {
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30YandereVibe = new string[][] {
              new string[] { "s3_02908.ogg" , "s3_02950.ogg" , "s3_02923.ogg" , "s3_02932.ogg" },
              new string[] { "s3_02909.ogg" , "s3_02910.ogg" , "s3_02915.ogg" , "s3_02914.ogg" },
              new string[] { "s3_02905.ogg" , "s3_02906.ogg" , "s3_02907.ogg" , "s3_05540.ogg" },
              new string[] { "s3_05657.ogg" , "s3_05658.ogg" , "s3_05659.ogg" , "s3_05660.ogg" , "s3_05661.ogg" , "s3_05678.ogg" , "s3_05651.ogg" , "s3_05656.ogg" },
              new string[] { "s3_02908.ogg" , "s3_02950.ogg" , "s3_02923.ogg" , "s3_02932.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30YandereFera = new string[][] {
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" },
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" },
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" },
              new string[] { "S3_03084.ogg" , "S3_03184.ogg" , "S3_03162.ogg" , "S3_18748.ogg" },
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" }
              };
        //停止時
        public string[] sLoopVoice40YandereVibe = new string[] { "S3_02964.ogg", "S3_02964.ogg", "S3_02965.ogg", "S3_02966.ogg", "S3_02966.ogg" };



        //性格別声テーブル　お姉ちゃん---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20AnesanVibe = new string[][] {
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20AnesanFera = new string[][] {
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30AnesanVibe = new string[][] {
              new string[] { "s4_08140.ogg" , "s4_08141.ogg" , "s4_08142.ogg" , "s4_08145.ogg" },
              new string[] { "s4_08140.ogg" , "s4_08141.ogg" , "s4_08142.ogg" , "s4_08145.ogg" },
              new string[] { "s4_08140.ogg" , "s4_08141.ogg" , "s4_08149.ogg" , "s4_08150.ogg" },
              new string[] { "s4_08140.ogg" , "s4_08134.ogg" , "s4_08149.ogg" , "s4_08150.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30AnesanFera = new string[][] {
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30AnesanVibe = new string[][] {
              new string[] { "s4_08348.ogg" , "s4_08354.ogg" , "s4_08365.ogg" , "s4_08374.ogg" },
              new string[] { "s4_08345.ogg" , "s4_08346.ogg" , "s4_08349.ogg" , "s4_08350.ogg" },
              new string[] { "s4_08347.ogg" , "s4_08355.ogg" , "s4_08356.ogg" , "s4_11658.ogg" },
              new string[] { "s4_11684.ogg" , "s4_11677.ogg" , "s4_11680.ogg" , "s4_11683.ogg" , "s4_11661.ogg" , "s4_11659.ogg" , "s4_11654.ogg" , "s4_11660.ogg" },
              new string[] { "s4_08348.ogg" , "s4_08354.ogg" , "s4_08365.ogg" , "s4_08374.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30AnesanFera = new string[][] {
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" },
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" },
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" },
              new string[] { "S4_05728.ogg" , "S4_05726.ogg" , "S4_05680.ogg" , "S4_05668.ogg" },
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" }
              };
        //停止時
        public string[] sLoopVoice40AnesanVibe = new string[] { "s4_08424.ogg", "s4_08426.ogg", "s4_08427.ogg", "s4_08428.ogg", "s4_08428.ogg" };



        //性格別声テーブル　ボクっ娘---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20GenkiVibe = new string[][] {
              new string[] { "s5_04127.ogg" , "s5_04129.ogg" , "s5_04130.ogg" , "s5_04131.ogg" },
              new string[] { "s5_04127.ogg" , "s5_04048.ogg" , "s5_04130.ogg" , "s5_04048.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04048.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04131.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04131.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20GenkiFera = new string[][] {
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "S5_04181.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "S5_04181.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30GenkiVibe = new string[][] {
              new string[] { "s5_04133.ogg" , "s5_04058.ogg" , "s5_04055.ogg" , "s5_04050.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04058.ogg" , "s5_04055.ogg" , "s5_04050.ogg" },
              new string[] { "s5_04051.ogg" , "s5_04055.ogg" , "s5_04054.ogg" , "s5_04052.ogg" },
              new string[] { "s5_04055.ogg" , "s5_04061.ogg" , "s5_04054.ogg" , "s5_04052.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04131.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30GenkiFera = new string[][] {
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30GenkiVibe = new string[][] {
              new string[] { "s5_04264.ogg" , "s5_04258.ogg" , "s5_04256.ogg" , "s5_04255.ogg" },
              new string[] { "s5_04265.ogg" , "s5_04270.ogg" , "s5_04267.ogg" , "s5_04268.ogg" },
              new string[] { "s5_04266.ogg" , "s5_18375.ogg" , "s5_18380.ogg" , "s5_18393.ogg" },
              new string[] { "s5_18379.ogg" , "s5_18380.ogg" , "s5_18382.ogg" , "s5_18384.ogg" , "s5_18385.ogg" , "s5_18400.ogg" , "s5_18402.ogg" , "s5_18119.ogg" },
              new string[] { "s5_04264.ogg" , "s5_04258.ogg" , "s5_04256.ogg" , "s5_04255.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30GenkiFera = new string[][] {
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" },
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" },
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" },
              new string[] { "S5_07752.ogg" , "S5_07753.ogg" , "s5_04273.ogg" , "s5_04271.ogg" },
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" }
              };
        //停止時
        public string[] sLoopVoice40GenkiVibe = new string[] { "s5_04127.ogg", "s5_04129.ogg", "s5_04131.ogg", "s5_04134.ogg", "s5_04134.ogg" };



        //性格別声テーブル　ドＳ---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20SadistVibe = new string[][] {
              new string[] { "S6_02244.ogg" , "S6_02180.ogg" , "S6_02181.ogg" , "S6_02245.ogg" },
              new string[] { "S6_02179.ogg" , "S6_02243.ogg" , "S6_02246.ogg" , "S6_02182.ogg" },
              new string[] { "S6_02179.ogg" , "S6_02183.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02183.ogg" , "S6_02184.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02179.ogg" , "S6_02180.ogg" , "S6_02181.ogg" , "S6_02182.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20SadistFera = new string[][] {
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30SadistVibe = new string[][] {
              new string[] { "S6_02183.ogg" , "S6_02184.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02183.ogg" , "S6_02184.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02248.ogg" , "S6_02184.ogg" , "S6_02185.ogg" , "S6_02249.ogg" },
              new string[] { "S6_02249.ogg" , "S6_02250.ogg" , "S6_02185.ogg" , "S6_02186.ogg" },
              new string[] { "S6_02243.ogg" , "S6_02244.ogg" , "S6_02245.ogg" , "S6_02246.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30SadistFera = new string[][] {
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30SadistVibe = new string[][] {
              new string[] { "s6_01744.ogg" , "s6_02700.ogg" , "s6_02450.ogg" , "s6_02357.ogg" },
              new string[] { "S6_28847.ogg" , "S6_28853.ogg" , "S6_28814.ogg" , "S6_02397.ogg" },
              new string[] { "S6_28817.ogg" , "S6_02398.ogg" , "S6_02399.ogg" , "s6_02402.ogg" },
              new string[] { "S6_09048.ogg" , "S6_01984.ogg" , "S6_01988.ogg" , "S6_01991.ogg" , "S6_02000.ogg" , "S6_01996.ogg" , "S6_01997.ogg" , "S6_01998.ogg" , "S6_01999.ogg" , "S6_02001.ogg" , "s6_05796.ogg" , "s6_05797.ogg" , "s6_05798.ogg" , "s6_05799.ogg" , "s6_05800.ogg" , "s6_05801.ogg" },
              new string[] { "s6_01744.ogg" , "s6_02700.ogg" , "s6_02450.ogg" , "s6_02357.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30SadistFera = new string[][] {
              new string[] { "S6_28832.ogg" , "s6_02403.ogg" , "S6_28835.ogg" },
              new string[] { "S6_28835.ogg" , "s6_02403.ogg" , "s6_02404.ogg" },
              new string[] { "S6_28838.ogg" , "s6_02404.ogg" , "s6_02405.ogg" },
              new string[] { "S6_02420.ogg" , "S6_08109.ogg" , "S6_08112.ogg" , "S6_08114.ogg" , "s6_02404.ogg" , "s6_02405.ogg"  },
              new string[] { "S6_28832.ogg" , "s6_02403.ogg" , "S6_28835.ogg" }
              };
        //停止時
        public string[] sLoopVoice40SadistVibe = new string[] { "s6_02477.ogg", "s6_02478.ogg", "s6_02479.ogg", "s6_02481.ogg", "s6_02480.ogg" };



        //性格別声テーブル　無垢---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20MukuVibe = new string[][] {
              new string[] { "H0_00053.ogg" , "H0_00054.ogg" , "H0_09210.ogg" , "H0_09211.ogg" },
              new string[] { "H0_00069.ogg" , "H0_00070.ogg" , "H0_00229.ogg" , "H0_00230.ogg" },
              new string[] { "H0_00055.ogg" , "H0_00056.ogg" , "H0_09212.ogg" , "H0_09213.ogg" },
              new string[] { "H0_00071.ogg" , "H0_00072.ogg" , "H0_00231.ogg" , "H0_00232.ogg" },
              new string[] { "H0_00085.ogg" , "H0_00086.ogg" , "H0_00087.ogg" , "H0_00088.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20MukuFera = new string[][] {
              new string[] { "H0_00093.ogg" , "H0_00094.ogg" , "H0_00101.ogg" , "H0_00102.ogg" },
              new string[] { "H0_00093.ogg" , "H0_00094.ogg" , "H0_00101.ogg" , "H0_00102.ogg" },
              new string[] { "H0_00095.ogg" , "H0_00096.ogg" , "H0_00103.ogg" , "H0_00104.ogg" },
              new string[] { "H0_00095.ogg" , "H0_00096.ogg" , "H0_00103.ogg" , "H0_00104.ogg" },
              new string[] { "H0_00093.ogg" , "H0_00094.ogg" , "H0_00101.ogg" , "H0_00102.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30MukuVibe = new string[][] {
              new string[] { "H0_00057.ogg" , "H0_00058.ogg" , "H0_09214.ogg" , "H0_09215.ogg" },
              new string[] { "H0_00073.ogg" , "H0_00074.ogg" , "H0_00233.ogg" , "H0_00234.ogg" },
              new string[] { "H0_00059.ogg" , "H0_00060.ogg" , "H0_09216.ogg" , "H0_09217.ogg" },
              new string[] { "H0_00075.ogg" , "H0_00076.ogg" , "H0_00235.ogg" , "H0_00236.ogg" },
              new string[] { "H0_00089.ogg" , "H0_00090.ogg" , "H0_00087.ogg" , "H0_00088.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30MukuFera = new string[][] {
              new string[] { "H0_00105.ogg" , "H0_00106.ogg" , "H0_00097.ogg" , "H0_00098.ogg" },
              new string[] { "H0_00105.ogg" , "H0_00106.ogg" , "H0_00097.ogg" , "H0_00098.ogg" },
              new string[] { "H0_00107.ogg" , "H0_00108.ogg" , "H0_00099.ogg" , "H0_00100.ogg" },
              new string[] { "H0_00107.ogg" , "H0_00108.ogg" , "H0_00099.ogg" , "H0_00100.ogg" },
              new string[] { "H0_00105.ogg" , "H0_00106.ogg" , "H0_00097.ogg" , "H0_00098.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30MukuVibe = new string[][] {
              new string[] { "H0_00289.ogg" , "H0_00290.ogg" , "H0_00291.ogg" , "H0_00292.ogg" },
              new string[] { "H0_07822.ogg" , "H0_07826.ogg" , "H0_10642.ogg" , "H0_10619.ogg" , "H0_07825.ogg" },
              new string[] { "H0_10874.ogg" , "H0_10860.ogg" , "H0_10957.ogg" , "H0_10960.ogg" , "H0_10869.ogg" },
              new string[] { "H0_06353.ogg" , "H0_06358.ogg" , "H0_10859.ogg" , "H0_10870.ogg" , "H0_10860.ogg" , "H0_10961.ogg" , "H0_10962.ogg" , "H0_10963.ogg" , "H0_07695.ogg" , "H0_09708.ogg" , "H0_09713.ogg" , "H0_10470.ogg" , "H0_10471.ogg" , "H0_10476.ogg" , "H0_10479.ogg" , "H0_10480.ogg" , "H0_13669.ogg" , "H0_00567.ogg" , "H0_05H_15068.ogg" , "H0_05H_15079.ogg" , "H0_05H_15080.ogg" , "H0_05H_15081.ogg" , "H0_06062.ogg" , "H0_10473.ogg" , "H0_10474.ogg" , "H0_10475.ogg" , "H0_10477.ogg" , "H0_10478.ogg" , "H0_10926.ogg" , "H0_11359.ogg" , "H0_12625.ogg" , "H0_FEB_20458.ogg" },
              new string[] { "H0_07604.ogg" , "H0_07603.ogg" , "H0_07614.ogg" , "H0_07644.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30MukuFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40MukuVibe = new string[] { "H0_00134.ogg", "H0_00136.ogg", "H0_09239.ogg", "H0_09240.ogg", "H0_00142.ogg" };



        //性格別声テーブル　真面目---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20MajimeVibe = new string[][] {
              new string[] { "H1_00225.ogg" , "H1_00226.ogg" , "H1_08952.ogg" , "H1_08953.ogg" },
              new string[] { "H1_00241.ogg" , "H1_00242.ogg" , "H1_00401.ogg" , "H1_00402.ogg" },
              new string[] { "H1_00227.ogg" , "H1_00228.ogg" , "H1_08954.ogg" , "H1_08955.ogg" },
              new string[] { "H1_00243.ogg" , "H1_00244.ogg" , "H1_00403.ogg" , "H1_00404.ogg" },
              new string[] { "H1_00257.ogg" , "H1_00258.ogg" , "H1_00259.ogg" , "H1_00260.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20MajimeFera = new string[][] {
              new string[] { "H1_00265.ogg" , "H1_00266.ogg" , "H1_00273.ogg" , "H1_00274.ogg" },
              new string[] { "H1_00265.ogg" , "H1_00266.ogg" , "H1_00273.ogg" , "H1_00274.ogg" },
              new string[] { "H1_00267.ogg" , "H1_00268.ogg" , "H1_00275.ogg" , "H1_00276.ogg" },
              new string[] { "H1_00267.ogg" , "H1_00268.ogg" , "H1_00275.ogg" , "H1_00276.ogg" },
              new string[] { "H1_00265.ogg" , "H1_00266.ogg" , "H1_00273.ogg" , "H1_00274.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30MajimeVibe = new string[][] {
              new string[] { "H1_00229.ogg" , "H1_00230.ogg" , "H1_08956.ogg" , "H1_08957.ogg" },
              new string[] { "H1_00245.ogg" , "H1_00246.ogg" , "H1_00405.ogg" , "H1_00406.ogg" },
              new string[] { "H1_00231.ogg" , "H1_00232.ogg" , "H1_08958.ogg" , "H1_08959.ogg" },
              new string[] { "H1_00247.ogg" , "H1_00248.ogg" , "H1_00407.ogg" , "H1_00408.ogg" },
              new string[] { "H1_00262.ogg" , "H1_00263.ogg" , "H1_00264.ogg" , "H1_00261.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30MajimeFera = new string[][] {
              new string[] { "H1_00269.ogg" , "H1_00270.ogg" , "H1_00277.ogg" , "H1_00278.ogg" },
              new string[] { "H1_00269.ogg" , "H1_00270.ogg" , "H1_00277.ogg" , "H1_00278.ogg" },
              new string[] { "H1_00271.ogg" , "H1_00272.ogg" , "H1_00279.ogg" , "H1_00280.ogg" },
              new string[] { "H1_00271.ogg" , "H1_00272.ogg" , "H1_00279.ogg" , "H1_00280.ogg" },
              new string[] { "H1_00269.ogg" , "H1_00270.ogg" , "H1_00277.ogg" , "H1_00278.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30MajimeVibe = new string[][] {
              new string[] { "H1_11482.ogg" , "H1_13858.ogg" , "H1_13879.ogg" , "H1_13918.ogg" },
              new string[] { "H1_11492.ogg" , "H1_11514.ogg" , "H1_10519.ogg" , "H1_10516.ogg" },
              new string[] { "H1_11427.ogg" , "H1_11513.ogg" , "H1_05640.ogg" , "H1_09232.ogg" },
              new string[] { "H1_11425.ogg" , "H1_11424.ogg" , "H1_11427.ogg" , "H1_09232.ogg" , "H1_10397.ogg" , "H1_11645.ogg" , "H1_11654.ogg" , "H1_11747.ogg" , "H1_10313.ogg" , "H1_11254.ogg" , "H1_11402.ogg" , "H1_09829.ogg" , "H1_04547.ogg" , "H1_12675.ogg" , "H1_01477.ogg" , "H1_00739.ogg" , "H1_06987.ogg" , "H1_13138.ogg" , "H1_13372.ogg" , "H1_12929.ogg" , "H1_11404.ogg" , "H1_05638.ogg" , "H1_09837.ogg" , "H1_03615.ogg" , "H1_11513.ogg" , "H1_05640.ogg" },
              new string[] { "H1_10493.ogg" , "H1_10482.ogg" , "H1_10523.ogg" , "H1_10732.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30MajimeFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { "H1_09840.ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { "H1_12857.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40MajimeVibe = new string[] { "H1_00305.ogg", "H1_08979.ogg", "H1_08980.ogg", "H1_08982.ogg", "H1_00313.ogg" };



        //性格別声テーブル　凛デレ---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20RindereVibe = new string[][] {
              new string[] { "H2_00027.ogg" , "H2_00028.ogg" , "H2_09827.ogg" , "H2_09828.ogg" },
              new string[] { "H2_00043.ogg" , "H2_00044.ogg" , "H2_00203.ogg" , "H2_00204.ogg" },
              new string[] { "H2_00029.ogg" , "H2_00030.ogg" , "H2_09829.ogg" , "H2_09830.ogg" },
              new string[] { "H2_00045.ogg" , "H2_00046.ogg" , "H2_00205.ogg" , "H2_00206.ogg" },
              new string[] { "H2_00059.ogg" , "H2_00060.ogg" , "H2_00061.ogg" , "H2_00062.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20RindereFera = new string[][] {
              new string[] { "H2_00067.ogg" , "H2_00068.ogg" , "H2_00075.ogg" , "H2_00076.ogg" },
              new string[] { "H2_00067.ogg" , "H2_00068.ogg" , "H2_00075.ogg" , "H2_00076.ogg" },
              new string[] { "H2_00069.ogg" , "H2_00070.ogg" , "H2_00077.ogg" , "H2_00078.ogg" },
              new string[] { "H2_00069.ogg" , "H2_00070.ogg" , "H2_00077.ogg" , "H2_00078.ogg" },
              new string[] { "H2_00067.ogg" , "H2_00068.ogg" , "H2_00075.ogg" , "H2_00076.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30RindereVibe = new string[][] {
              new string[] { "H2_00031.ogg" , "H2_00032.ogg" , "H2_09831.ogg" , "H2_09832.ogg" },
              new string[] { "H2_00047.ogg" , "H2_00048.ogg" , "H2_00207.ogg" , "H2_00208.ogg" },
              new string[] { "H2_00033.ogg" , "H2_00034.ogg" , "H2_09833.ogg" , "H2_09834.ogg" },
              new string[] { "H2_00049.ogg" , "H2_00050.ogg" , "H2_00209.ogg" , "H2_00210.ogg" },
              new string[] { "H2_00063.ogg" , "H2_00064.ogg" , "H2_00061.ogg" , "H2_00062.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30RindereFera = new string[][] {
              new string[] { "H2_00071.ogg" , "H2_00072.ogg" , "H2_00079.ogg" , "H2_00080.ogg" },
              new string[] { "H2_00071.ogg" , "H2_00072.ogg" , "H2_00079.ogg" , "H2_00080.ogg" },
              new string[] { "H2_00073.ogg" , "H2_00074.ogg" , "H2_00081.ogg" , "H2_00082.ogg" },
              new string[] { "H2_00073.ogg" , "H2_00074.ogg" , "H2_00081.ogg" , "H2_00082.ogg" },
              new string[] { "H2_00071.ogg" , "H2_00072.ogg" , "H2_00079.ogg" , "H2_00080.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30RindereVibe = new string[][] {
              new string[] { "H2_06092.ogg" , "H2_00252.ogg" , "H2_00285.ogg" , "H2_00277.ogg" },
              new string[] { "H2_10293.ogg" , "H2_10381.ogg" , "H2_10444.ogg" , "H2_11040.ogg" , "H2_07976.ogg" },
              new string[] { "H2_08156.ogg" , "H2_10980.ogg" , "H2_11120.ogg" , "H2_11141.ogg" , "H2_11143.ogg" , "H2_11229.ogg" },
              new string[] { "H2_10580.ogg" , "H2_10581.ogg" , "H2_10584.ogg" , "H2_10585.ogg" , "H2_10586.ogg" , "H2_10587.ogg" , "H2_10064.ogg" , "H2_13912.ogg" , "H2_11118.ogg" , "H2_11119.ogg" , "H2_08338.ogg" , "H2_11371.ogg" , "H2_11464.ogg" , "H2_13449.ogg" , "H2_10971.ogg" , "H2_06130.ogg" , "H2_01902.ogg" , "H2_03017.ogg" , "H2_02782.ogg" , "H2_02861.ogg" , "H2_10573.ogg" , "H2_00865.ogg" , "H2_02550.ogg" , "H2_02603.ogg" , "H2_02606.ogg" , "H2_08156.ogg" , "H2_10980.ogg" , "H2_11120.ogg" , "H2_11141.ogg" , "H2_11143.ogg" , "H2_11229.ogg" },
              new string[] { "H2_08095.ogg" , "H2_08116.ogg" , "H2_08121.ogg" , "H2_08126.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30RindereFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40RindereVibe = new string[] { "H2_00108.ogg", "H2_00110.ogg", "H2_00111.ogg", "H2_00113.ogg", "H2_00118.ogg" };



        //性格別声テーブル　無口---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20SilentVibe = new string[][] {
              new string[] { "H3_00518.ogg" , "H3_00519.ogg" , "H3_00526.ogg" , "H3_00527.ogg" },
              new string[] { "H3_00534.ogg" , "H3_00535.ogg" , "H3_00734.ogg" , "H3_00735.ogg" },
              new string[] { "H3_00520.ogg" , "H3_00521.ogg" , "H3_00528.ogg" , "H3_00529.ogg" },
              new string[] { "H3_00536.ogg" , "H3_00537.ogg" , "H3_00736.ogg" , "H3_00737.ogg" },
              new string[] { "H3_00558.ogg" , "H3_00559.ogg" , "H3_00734.ogg" , "H3_00735.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20SilentFera = new string[][] {
              new string[] { "H3_00566.ogg" , "H3_00567.ogg" , "H3_00702.ogg" , "H3_00703.ogg" },
              new string[] { "H3_00566.ogg" , "H3_00567.ogg" , "H3_00702.ogg" , "H3_00703.ogg" },
              new string[] { "H3_00568.ogg" , "H3_00569.ogg" , "H3_00704.ogg" , "H3_00705.ogg" },
              new string[] { "H3_00568.ogg" , "H3_00569.ogg" , "H3_00704.ogg" , "H3_00705.ogg" },
              new string[] { "H3_00566.ogg" , "H3_00567.ogg" , "H3_00568.ogg" , "H3_00569.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30SilentVibe = new string[][] {
              new string[] { "H3_00522.ogg" , "H3_00523.ogg" , "H3_00530.ogg" , "H3_00531.ogg" },
              new string[] { "H3_00538.ogg" , "H3_00539.ogg" , "H3_00738.ogg" , "H3_00739.ogg" },
              new string[] { "H3_00524.ogg" , "H3_00525.ogg" , "H3_00532.ogg" , "H3_00533.ogg" },
              new string[] { "H3_00540.ogg" , "H3_00541.ogg" , "H3_00740.ogg" , "H3_00741.ogg" },
              new string[] { "H3_00560.ogg" , "H3_00561.ogg" , "H3_00562.ogg" , "H3_00563.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30SilentFera = new string[][] {
              new string[] { "H3_00570.ogg" , "H3_00571.ogg" , "H3_00706.ogg" , "H3_00707.ogg" },
              new string[] { "H3_00570.ogg" , "H3_00571.ogg" , "H3_00706.ogg" , "H3_00707.ogg" },
              new string[] { "H3_00572.ogg" , "H3_00573.ogg" , "H3_00708.ogg" , "H3_00709.ogg" },
              new string[] { "H3_00572.ogg" , "H3_00573.ogg" , "H3_00708.ogg" , "H3_00709.ogg" },
              new string[] { "H3_00570.ogg" , "H3_00571.ogg" , "H3_00706.ogg" , "H3_00707.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30SilentVibe = new string[][] {
              new string[] { "H3_00779.ogg" , "H3_00783.ogg" , "H3_00785.ogg" , "H3_00800.ogg" },
              new string[] { "H3_08926.ogg" , "H3_08112.ogg" , "H3_04262.ogg" , "H3_05125.ogg" , "H3_08926.ogg" },
              new string[] { "H3_02523.ogg" , "H3_04910.ogg" , "H3_07704.ogg" , "H3_04967.ogg" , "H3_04974.ogg" , "H3_05026.ogg" },
              new string[] { "H3_07068.ogg" , "H3_02584.ogg" , "H3_01906.ogg" , "H3_07314.ogg" , "H3_07315.ogg" , "H3_07316.ogg" , "H3_06965.ogg" , "H3_01858.ogg" , "H3_01906.ogg" , "H3_01925.ogg" , "H3_04252.ogg" , "H3_04228.ogg" , "H3_04639.ogg" , "H3_07121.ogg" , "H3_03827.ogg" , "H3_01928.ogg" , "H3_02336.ogg" , "H3_07069.ogg" , "H3_07996.ogg" , "H3_08950.ogg" },
              new string[] { "H3_00779.ogg" , "H3_00783.ogg" , "H3_00785.ogg" , "H3_00800.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30SilentFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40SilentVibe = new string[] { "H3_00622.ogg", "H3_00625.ogg", "H3_00627.ogg", "H3_00628.ogg", "H3_00641.ogg" };



        //性格別声テーブル　小悪魔---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20DevilishVibe = new string[][] {
              new string[] { "H4_00853.ogg" , "H4_00854.ogg" , "H4_00861.ogg" , "H4_00862.ogg" },
              new string[] { "H4_00869.ogg" , "H4_00870.ogg" , "H4_01069.ogg" , "H4_01070.ogg" },
              new string[] { "H4_00855.ogg" , "H4_00856.ogg" , "H4_00863.ogg" , "H4_00864.ogg" },
              new string[] { "H4_00871.ogg" , "H4_00872.ogg" , "H4_01071.ogg" , "H4_01072.ogg" },
              new string[] { "H4_00893.ogg" , "H4_00894.ogg" , "H4_01069.ogg" , "H4_01070.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20DevilishFera = new string[][] {
              new string[] { "H4_00901.ogg" , "H4_00902.ogg" , "H4_01037.ogg" , "H4_01038.ogg" },
              new string[] { "H4_00901.ogg" , "H4_00902.ogg" , "H4_01037.ogg" , "H4_01038.ogg" },
              new string[] { "H4_00903.ogg" , "H4_00904.ogg" , "H4_01039.ogg" , "H4_01040.ogg" },
              new string[] { "H4_00903.ogg" , "H4_00904.ogg" , "H4_01039.ogg" , "H4_01040.ogg" },
              new string[] { "H4_00901.ogg" , "H4_00902.ogg" , "H4_00903.ogg" , "H4_00904.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30DevilishVibe = new string[][] {
              new string[] { "H4_00857.ogg" , "H4_00858.ogg" , "H4_00865.ogg" , "H4_00866.ogg" },
              new string[] { "H4_00873.ogg" , "H4_00874.ogg" , "H4_01073.ogg" , "H4_01074.ogg" },
              new string[] { "H4_00859.ogg" , "H4_00860.ogg" , "H4_00867.ogg" , "H4_00868.ogg" },
              new string[] { "H4_00875.ogg" , "H4_00876.ogg" , "H4_01075.ogg" , "H4_01076.ogg" },
              new string[] { "H4_00895.ogg" , "H4_00896.ogg" , "H4_00897.ogg" , "H4_00898.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30DevilishFera = new string[][] {
              new string[] { "H4_00905.ogg" , "H4_00906.ogg" , "H4_01041.ogg" , "H4_01042.ogg" },
              new string[] { "H4_00905.ogg" , "H4_00906.ogg" , "H4_01041.ogg" , "H4_01042.ogg" },
              new string[] { "H4_00907.ogg" , "H4_00908.ogg" , "H4_01043.ogg" , "H4_01044.ogg" },
              new string[] { "H4_00907.ogg" , "H4_00908.ogg" , "H4_01043.ogg" , "H4_01044.ogg" },
              new string[] { "H4_00905.ogg" , "H4_00906.ogg" , "H4_01041.ogg" , "H4_01042.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30DevilishVibe = new string[][] {
              new string[] { "H4_01200.ogg" , "H4_01204.ogg" , "H4_01209.ogg" , "H4_01208.ogg" },
              new string[] { "H4_03190.ogg" , "H4_02024.ogg" , "H4_02026.ogg" , "H4_02030.ogg" , "H4_02018.ogg" },
              new string[] { "H4_01907.ogg" , "H4_01908.ogg" , "H4_05097.ogg" , "H4_05098.ogg" , "H4_03190.ogg" , "H4_03290.ogg" ,"H4_02020.ogg" , "H4_00583.ogg" , "H4_08568.ogg" },
              new string[] { "H4_03413.ogg" , "H4_08495.ogg" , "H4_08182.ogg" , "H4_02777.ogg" , "H4_03019.ogg" , "H4_06292.ogg" , "H4_06308.ogg" , "H4_06328.ogg" , "H4_08574.ogg" , "H4_08578.ogg" , "H4_08579.ogg" , "H4_08580.ogg" , "H4_08607.ogg" , "H4_08608.ogg" , "H4_08568.ogg" , "H4_08591.ogg" , "H4_04328.ogg" , "H4_03190.ogg" , "H4_06136.ogg" , "H4_00537.ogg" , "H4_00583.ogg" , "H4_08568.ogg" , "H4_02024.ogg" , "H4_02026.ogg" , "H4_02030.ogg" , "H4_02018.ogg" , "H4_04840.ogg" , "H4_05503.ogg" , "H4_08165.ogg" , "H4_08169.ogg" , "H4_PMD_14155.ogg" , "H4_PMD_14156.ogg" , "H4_PMD_14157.ogg" , "H4_Y_13333.ogg" , "H4_Y_13335.ogg" , "H4_Y_13336.ogg" , "H4_Y_13337.ogg" , "H4_Y_13338.ogg" , "H4_Y_13339.ogg" , "H4_Y_13340.ogg" , "H4_Y_13342.ogg" , "H4_Y_13343.ogg" , "H4_Y_13353.ogg" , "H4_Y_13355.ogg" , "H4_Y_13356.ogg" , "H4_Y_13360.ogg" , "H4_Y_13371.ogg", "H4_ADD_10717.ogg", "H4_ADD_10718.ogg", "H4_ADD_10721.ogg", "H4_ADD_10722.ogg", "H4_ADD_10723.ogg", "H4_ADD_11330.ogg", "H4_ADD_11331.ogg", "H4_ADD_11332.ogg", "H4_ADD_11333.ogg", "H4_ADD_11334.ogg", "H4_ADD_11344.ogg", "H4_ADD_11345.ogg", "H4_ADD_11346.ogg", "H4_ADD_11348.ogg", "H4_ADD_11349.ogg", "H4_ADD_11356.ogg", "H4_ADD_11359.ogg", "H4_ADD_11360.ogg", "H4_ADD_11361.ogg", "H4_ADD_11362.ogg" },
              new string[] { "H4_01200.ogg" , "H4_01204.ogg" , "H4_01209.ogg" , "H4_01208.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30DevilishFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40DevilishVibe = new string[] { "H4_00959.ogg", "H4_00962.ogg", "H4_00963.ogg", "H4_00977.ogg", "H4_00980.ogg" };



        //性格別声テーブル　おしとやか---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20LadylikeVibe = new string[][] {
              new string[] { "H5_00592.ogg" , "H5_00593.ogg" , "H5_00600.ogg" , "H5_00601.ogg" },
              new string[] { "H5_00808.ogg" , "H5_00809.ogg" , "H5_00608.ogg" , "H5_00609.ogg" },
              new string[] { "H5_00594.ogg" , "H5_00595.ogg" , "H5_00602.ogg" , "H5_00603.ogg" },
              new string[] { "H5_00810.ogg" , "H5_00811.ogg" , "H5_00610.ogg" , "H5_00611.ogg" },
              new string[] { "H5_00624.ogg" , "H5_00625.ogg" , "H5_00632.ogg" , "H5_00633.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20LadylikeFera = new string[][] {
              new string[] { "H5_00640.ogg" , "H5_00641.ogg" , "H5_00648.ogg" , "H5_00649.ogg" },
              new string[] { "H5_00640.ogg" , "H5_00641.ogg" , "H5_00648.ogg" , "H5_00649.ogg" },
              new string[] { "H5_00642.ogg" , "H5_00643.ogg" , "H5_00650.ogg" , "H5_00651.ogg" },
              new string[] { "H5_00642.ogg" , "H5_00643.ogg" , "H5_00650.ogg" , "H5_00651.ogg" },
              new string[] { "H5_00640.ogg" , "H5_00641.ogg" , "H5_00642.ogg" , "H5_00643.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30LadylikeVibe = new string[][] {
              new string[] { "H5_00596.ogg" , "H5_00597.ogg" , "H5_00604.ogg" , "H5_00605.ogg" },
              new string[] { "H5_00812.ogg" , "H5_00813.ogg" , "H5_00612.ogg" , "H5_00613.ogg" },
              new string[] { "H5_00598.ogg" , "H5_00599.ogg" , "H5_00606.ogg" , "H5_00607.ogg" },
              new string[] { "H5_00814.ogg" , "H5_00815.ogg" , "H5_00614.ogg" , "H5_00615.ogg" },
              new string[] { "H5_00626.ogg" , "H5_00627.ogg" , "H5_00634.ogg" , "H5_00635.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30LadylikeFera = new string[][] {
              new string[] { "H5_00644.ogg" , "H5_00645.ogg" , "H5_00652.ogg" , "H5_00653.ogg" },
              new string[] { "H5_00644.ogg" , "H5_00645.ogg" , "H5_00652.ogg" , "H5_00653.ogg" },
              new string[] { "H5_00646.ogg" , "H5_00647.ogg" , "H5_00654.ogg" , "H5_00655.ogg" },
              new string[] { "H5_00646.ogg" , "H5_00647.ogg" , "H5_00654.ogg" , "H5_00655.ogg" },
              new string[] { "H5_00644.ogg" , "H5_00645.ogg" , "H5_00646.ogg" , "H5_00647.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30LadylikeVibe = new string[][] {
              new string[] { "H5_00943.ogg" , "H5_00944.ogg" , "H5_00948.ogg" , "H5_00874.ogg" },
              new string[] { "H5_00859.ogg" , "H5_00857.ogg" , "H5_00858.ogg" , "H5_00855.ogg" , "H5_02835.ogg" },
              new string[] { "H5_08487.ogg" , "H5_00250.ogg" , "H5_00259.ogg" , "H5_00270.ogg" , "H5_00290.ogg" , "H5_00370.ogg" , "H5_02835.ogg" , "H5_03009.ogg" , "H5_00479.ogg" },
              new string[] { "H5_08158.ogg" , "H5_08153.ogg" , "H5_08155.ogg" , "H5_08482.ogg" , "H5_08484.ogg" , "H5_08485.ogg" , "H5_08486.ogg" , "H5_08487.ogg" , "H5_08488.ogg" , "H5_03789.ogg" , "H5_02561.ogg" , "H5_00370.ogg" , "H5_00379.ogg" , "H5_00398.ogg" , "H5_00399.ogg" , "H5_03009.ogg" , "H5_00479.ogg" , "H5_03462.ogg" , "H5_03464.ogg" , "H5_03465.ogg" , "H5_03468.ogg" , "H5_04142.ogg" , "H5_04144.ogg" , "H5_01588.ogg" , "H5_01596.ogg" , "H5_01597.ogg" , "H5_01598.ogg" },
              new string[] { "H5_00943.ogg" , "H5_00944.ogg" , "H5_00948.ogg" , "H5_00874.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30LadylikeFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40LadylikeVibe = new string[] { "H5_00922.ogg", "H5_00923.ogg", "H5_00916.ogg", "H5_00917.ogg", "H5_00920.ogg" };



        //性格別声テーブル　メイド秘書---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20SecretaryVibe = new string[][] {
              new string[] { "H6_00158.ogg" , "H6_00159.ogg" , "H6_00166.ogg" , "H6_00167.ogg" },
              new string[] { "H6_00374.ogg" , "H6_00375.ogg" , "H6_00174.ogg" , "H6_00175.ogg" },
              new string[] { "H6_00160.ogg" , "H6_00161.ogg" , "H6_00168.ogg" , "H6_00169.ogg" },
              new string[] { "H6_00376.ogg" , "H6_00377.ogg" , "H6_00176.ogg" , "H6_00177.ogg" },
              new string[] { "H6_00190.ogg" , "H6_00191.ogg" , "H6_00192.ogg" , "H6_00193.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20SecretaryFera = new string[][] {
              new string[] { "H6_00206.ogg" , "H6_00207.ogg" , "H6_00214.ogg" , "H6_00215.ogg" },
              new string[] { "H6_00206.ogg" , "H6_00207.ogg" , "H6_00214.ogg" , "H6_00215.ogg" },
              new string[] { "H6_00208.ogg" , "H6_00209.ogg" , "H6_00216.ogg" , "H6_00217.ogg" },
              new string[] { "H6_00208.ogg" , "H6_00209.ogg" , "H6_00216.ogg" , "H6_00217.ogg" },
              new string[] { "H6_00198.ogg" , "H6_00199.ogg" , "H6_00200.ogg" , "H6_00201.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30SecretaryVibe = new string[][] {
              new string[] { "H6_00162.ogg" , "H6_00163.ogg" , "H6_00170.ogg" , "H6_00171.ogg" },
              new string[] { "H6_00378.ogg" , "H6_00379.ogg" , "H6_00178.ogg" , "H6_00179.ogg" },
              new string[] { "H6_00164.ogg" , "H6_00165.ogg" , "H6_00172.ogg" , "H6_00173.ogg" },
              new string[] { "H6_00380.ogg" , "H6_00381.ogg" , "H6_00180.ogg" , "H6_00181.ogg" },
              new string[] { "H6_00194.ogg" , "H6_00195.ogg" , "H6_00196.ogg" , "H6_00197.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30SecretaryFera = new string[][] {
              new string[] { "H6_00210.ogg" , "H6_00211.ogg" , "H6_00218.ogg" , "H6_00219.ogg" },
              new string[] { "H6_00210.ogg" , "H6_00211.ogg" , "H6_00218.ogg" , "H6_00219.ogg" },
              new string[] { "H6_00212.ogg" , "H6_00213.ogg" , "H6_00220.ogg" , "H6_00221.ogg" },
              new string[] { "H6_00212.ogg" , "H6_00213.ogg" , "H6_00220.ogg" , "H6_00221.ogg" },
              new string[] { "H6_00202.ogg" , "H6_00203.ogg" , "H6_00204.ogg" , "H6_00205.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30SecretaryVibe = new string[][] {
              new string[] { "H6_00421.ogg" , "H6_00429.ogg" , "H6_00448.ogg" , "H6_00409.ogg" },
              new string[] { "H6_08956.ogg" , "H6_08721.ogg" , "H6_08731.ogg" , "H6_09052.ogg" , "H6_00413.ogg" },
              new string[] { "H6_04166.ogg" , "H6_04305.ogg" , "H6_05273.ogg" , "H6_06550.ogg" , "H6_06555.ogg" , "H6_05185.ogg" , "H6_08956.ogg" , "H6_08721.ogg" , "H6_08731.ogg" , "H6_02949.ogg" , "H6_03938.ogg" , "H6_00936.ogg" , "H6_05653.ogg" },
              new string[] { "H6_08869.ogg" , "H6_06946.ogg" , "H6_06610.ogg" , "H6_06615.ogg" , "H6_06627.ogg" , "H6_08868.ogg" , "H6_08948.ogg" , "H6_09026.ogg" , "H6_05578.ogg" , "H6_06985.ogg" , "H6_05688.ogg" , "H6_01064.ogg" , "H6_03986.ogg" , "H6_01165.ogg" , "H6_04233.ogg" , "H6_08717.ogg" , "H6_08718.ogg" , "H6_08719.ogg" , "H6_08721.ogg" , "H6_08867.ogg" , "H6_08953.ogg" , "H6_08956.ogg" , "H6_08958.ogg" , "H6_09001.ogg" , "H6_09002.ogg" , "H6_09008.ogg" , "H6_09023.ogg" , "H6_09025.ogg" , "H6_09028.ogg" , "H6_06006.ogg" , "H6_04130.ogg" },
              new string[] { "H6_09028.ogg" , "H6_09023.ogg" , "H6_09002.ogg" , "H6_08956.ogg" , "H6_00421.ogg" , "H6_00429.ogg" , "H6_00448.ogg" , "H6_00409.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30SecretaryFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40SecretaryVibe = new string[] { "H6_00263.ogg", "H6_00264.ogg", "H6_00267.ogg", "H6_00268.ogg", "H6_00284.ogg" };



        //性格別声テーブル　ふわふわ妹---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20SisterVibe = new string[][] {
              new string[] { "H7_02762.ogg" , "H7_02763.ogg" , "H7_02770.ogg" , "H7_02771.ogg" },
              new string[] { "H7_02978.ogg" , "H7_02979.ogg" , "H7_02850.ogg" , "H7_02851.ogg" },
              new string[] { "H7_02764.ogg" , "H7_02765.ogg" , "H7_02772.ogg" , "H7_02773.ogg" },
              new string[] { "H7_02980.ogg" , "H7_02981.ogg" , "H7_02852.ogg" , "H7_02853.ogg" },
              new string[] { "H7_02962.ogg" , "H7_02963.ogg" , "H7_02802.ogg" , "H7_02803.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20SisterFera = new string[][] {
              new string[] { "H7_02810.ogg" , "H7_02811.ogg" , "H7_02818.ogg" , "H7_02819.ogg" },
              new string[] { "H7_02810.ogg" , "H7_02811.ogg" , "H7_02818.ogg" , "H7_02819.ogg" },
              new string[] { "H7_02812.ogg" , "H7_02813.ogg" , "H7_02820.ogg" , "H7_02821.ogg" },
              new string[] { "H7_02812.ogg" , "H7_02813.ogg" , "H7_02820.ogg" , "H7_02821.ogg" },
              new string[] { "H7_02810.ogg" , "H7_02811.ogg" , "H7_02818.ogg" , "H7_02819.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30SisterVibe = new string[][] {
              new string[] { "H7_02766.ogg" , "H7_02767.ogg" , "H7_02774.ogg" , "H7_02775.ogg" },
              new string[] { "H7_02982.ogg" , "H7_02983.ogg" , "H7_02854.ogg" , "H7_02855.ogg" },
              new string[] { "H7_02768.ogg" , "H7_02769.ogg" , "H7_02776.ogg" , "H7_02777.ogg" },
              new string[] { "H7_02984.ogg" , "H7_02985.ogg" , "H7_02856.ogg" , "H7_02857.ogg" },
              new string[] { "H7_02964.ogg" , "H7_02965.ogg" , "H7_02804.ogg" , "H7_02805.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30SisterFera = new string[][] {
              new string[] { "H7_02814.ogg" , "H7_02815.ogg" , "H7_02822.ogg" , "H7_02823.ogg" },
              new string[] { "H7_02814.ogg" , "H7_02815.ogg" , "H7_02822.ogg" , "H7_02823.ogg" },
              new string[] { "H7_02816.ogg" , "H7_02817.ogg" , "H7_02824.ogg" , "H7_02825.ogg" },
              new string[] { "H7_02816.ogg" , "H7_02817.ogg" , "H7_02824.ogg" , "H7_02825.ogg" },
              new string[] { "H7_02812.ogg" , "H7_02813.ogg" , "H7_02820.ogg" , "H7_02821.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30SisterVibe = new string[][] {
              new string[] { "H7_03163.ogg" , "H7_03167.ogg" , "H7_03164.ogg" , "H7_03172.ogg" },
              new string[] { "H7_08797.ogg" , "H7_07791.ogg" , "H7_02309.ogg" , "H7_02353.ogg" , "H7_01991.ogg" , "H7_02498.ogg" },
              new string[] { "H7_05958.ogg" , "H7_02353.ogg" , "H7_02410.ogg" , "H7_04331.ogg" , "H7_01699.ogg" , "H7_02060.ogg" , "H7_05359.ogg" , "H7_02506.ogg" , "H7_01821.ogg" , "H7_02301.ogg" , "H7_01744.ogg" , "H7_02498.ogg" },
              new string[] { "H7_04244.ogg" , "H7_00531.ogg" , "H7_01330.ogg" , "H7_01334.ogg" , "H7_02130.ogg" , "H7_02210.ogg" , "H7_01029.ogg" , "H7_05585.ogg" , "H7_01341.ogg" , "H7_01349.ogg" , "H7_04080.ogg" , "H7_01989.ogg" , "H7_07979.ogg" , "H7_05958.ogg" , "H7_02353.ogg" , "H7_04331.ogg" , "H7_02060.ogg" , "H7_02506.ogg" , "H7_01821.ogg" , "H7_02301.ogg" , "H7_01744.ogg" , "H7_02498.ogg" , "H7_08797.ogg" , "H7_07791.ogg" , "H7_02309.ogg" , "H7_02353.ogg" , "H7_01991.ogg" , "H7_02498.ogg" },
              new string[] { "H7_03163.ogg" , "H7_03167.ogg" , "H7_03164.ogg" , "H7_03172.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30SisterFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40SisterVibe = new string[] { "H7_03086.ogg", "H7_03087.ogg", "H7_03102.ogg", "H7_03103.ogg", "H7_02889.ogg" };




        //性格別声テーブル　無愛想---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20CurtnessVibe = new string[][] {
              new string[] { "H8_01331.ogg" , "H8_01332.ogg" , "H8_01139.ogg" , "H8_01140.ogg" },
              new string[] { "H8_01347.ogg" , "H8_01348.ogg" , "H8_01131.ogg" , "H8_01132.ogg" },
              new string[] { "H8_01333.ogg" , "H8_01334.ogg" , "H8_01141.ogg" , "H8_01142.ogg" },
              new string[] { "H8_01349.ogg" , "H8_01350.ogg" , "H8_01133.ogg" , "H8_01134.ogg" },
              new string[] { "H8_01163.ogg" , "H8_01164.ogg" , "H8_01171.ogg" , "H8_01172.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20CurtnessFera = new string[][] {
              new string[] { "H8_01179.ogg" , "H8_01180.ogg" , "H8_01187.ogg" , "H8_01188.ogg" },
              new string[] { "H8_01179.ogg" , "H8_01180.ogg" , "H8_01187.ogg" , "H8_01188.ogg" },
              new string[] { "H8_01181.ogg" , "H8_01182.ogg" , "H8_01189.ogg" , "H8_01190.ogg" },
              new string[] { "H8_01181.ogg" , "H8_01182.ogg" , "H8_01189.ogg" , "H8_01190.ogg" },
              new string[] { "H8_01179.ogg" , "H8_01180.ogg" , "H8_01187.ogg" , "H8_01188.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30CurtnessVibe = new string[][] {
              new string[] { "H8_01335.ogg" , "H8_01336.ogg" , "H8_01143.ogg" , "H8_01144.ogg" },
              new string[] { "H8_01351.ogg" , "H8_01352.ogg" , "H8_01135.ogg" , "H8_01136.ogg" },
              new string[] { "H8_01337.ogg" , "H8_01338.ogg" , "H8_01145.ogg" , "H8_01146.ogg" },
              new string[] { "H8_01353.ogg" , "H8_01354.ogg" , "H8_01137.ogg" , "H8_01138.ogg" },
              new string[] { "H8_01165.ogg" , "H8_01166.ogg" , "H8_01173.ogg" , "H8_01174.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30CurtnessFera = new string[][] {
              new string[] { "H8_01183.ogg" , "H8_01184.ogg" , "H8_01191.ogg" , "H8_01192.ogg" },
              new string[] { "H8_01183.ogg" , "H8_01184.ogg" , "H8_01191.ogg" , "H8_01192.ogg" },
              new string[] { "H8_01185.ogg" , "H8_01186.ogg" , "H8_01193.ogg" , "H8_01194.ogg" },
              new string[] { "H8_01185.ogg" , "H8_01186.ogg" , "H8_01193.ogg" , "H8_01194.ogg" },
              new string[] { "H8_01181.ogg" , "H8_01182.ogg" , "H8_01189.ogg" , "H8_01190.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30CurtnessVibe = new string[][] {
              new string[] { "H8_08466.ogg" , "H8_01430.ogg" , "H8_01421.ogg" , "H8_01382.ogg" , "H8_01396.ogg" , "H8_01398.ogg" },
              new string[] { "H8_08440.ogg" , "H8_08455.ogg" , "H8_08456.ogg" , "H8_08485.ogg" , "H8_08497.ogg" , "H8_08499.ogg" , "H8_02017.ogg" },
              new string[] { "H8_08471.ogg" , "H8_08473.ogg" , "H8_08500.ogg" , "H8_05361.ogg" , "H8_01936.ogg" , "H8_00646.ogg" , "H8_00648.ogg" , "H8_00657.ogg" , "H8_02023.ogg" , "H8_02025.ogg" , "H8_00717.ogg" , "H8_05547.ogg" },
              new string[] { "H8_08463.ogg" , "H8_08464.ogg" , "H8_08465.ogg" , "H8_08486.ogg" , "H8_08492.ogg" , "H8_08505.ogg" , "H8_07064.ogg" , "H8_09399.ogg" , "H8_09402.ogg" , "H8_09474.ogg" , "H8_02953.ogg" , "H8_05361.ogg" , "H8_02971.ogg" , "H8_01936.ogg" , "H8_03201.ogg" , "H8_03206.ogg" , "H8_00617.ogg" , "H8_00646.ogg" , "H8_00657.ogg" , "H8_02025.ogg" , "H8_00747.ogg" , "H8_00768.ogg" , "H8_01626.ogg" , "H8_00830.ogg" , "H8_07061.ogg" , "H8_07062.ogg" , "H8_00918.ogg" , "H8_05277.ogg" , "H8_04988.ogg" , "H8_05006.ogg" , "H8_05322.ogg" , "H8_05214.ogg" , "H8_05249.ogg" , "H8_05252.ogg" , "H8_09710.ogg" , "H8_09711.ogg" , "H8_09712.ogg" , "H8_01396.ogg" },
              new string[] { "H8_01427.ogg" , "H8_01382.ogg" , "H8_01421.ogg" , "H8_01401.ogg" , "H8_01396.ogg" , "H8_01398.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30CurtnessFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40CurtnessVibe = new string[] { "H8_01455.ogg", "H8_01456.ogg", "H8_01457.ogg", "H8_01472.ogg", "H8_01459.ogg" };





        //性格別声テーブル　お嬢様---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20MissyVibe = new string[][] {
              new string[] { "H9_00586.ogg" , "H9_00587.ogg" , "H9_00578.ogg" , "H9_00579.ogg" },
              new string[] { "H9_00786.ogg" , "H9_00787.ogg" , "H9_00570.ogg" , "H9_00571.ogg" },
              new string[] { "H9_00588.ogg" , "H9_00589.ogg" , "H9_00580.ogg" , "H9_00581.ogg" },
              new string[] { "H9_00788.ogg" , "H9_00789.ogg" , "H9_00572.ogg" , "H9_00573.ogg" },
              new string[] { "H9_00612.ogg" , "H9_00613.ogg" , "H9_00610.ogg" , "H9_00611.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20MissyFera = new string[][] {
              new string[] { "H9_00618.ogg" , "H9_00619.ogg" , "H9_00626.ogg" , "H9_00627.ogg" },
              new string[] { "H9_00618.ogg" , "H9_00619.ogg" , "H9_00626.ogg" , "H9_00627.ogg" },
              new string[] { "H9_00620.ogg" , "H9_00621.ogg" , "H9_00628.ogg" , "H9_00629.ogg" },
              new string[] { "H9_00620.ogg" , "H9_00621.ogg" , "H9_00628.ogg" , "H9_00629.ogg" },
              new string[] { "H9_00618.ogg" , "H9_00619.ogg" , "H9_00626.ogg" , "H9_00627.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30MissyVibe = new string[][] {
              new string[] { "H9_00590.ogg" , "H9_00591.ogg" , "H9_00582.ogg" , "H9_00583.ogg" },
              new string[] { "H9_00790.ogg" , "H9_00791.ogg" , "H9_00574.ogg" , "H9_00575.ogg" },
              new string[] { "H9_00592.ogg" , "H9_00593.ogg" , "H9_00584.ogg" , "H9_00585.ogg" },
              new string[] { "H9_00792.ogg" , "H9_00793.ogg" , "H9_00576.ogg" , "H9_00577.ogg" },
              new string[] { "H9_00614.ogg" , "H9_00615.ogg" , "H9_00617.ogg" , "H9_00616.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30MissyFera = new string[][] {
              new string[] { "H9_00622.ogg" , "H9_00623.ogg" , "H9_00630.ogg" , "H9_00631.ogg" },
              new string[] { "H9_00622.ogg" , "H9_00623.ogg" , "H9_00630.ogg" , "H9_00631.ogg" },
              new string[] { "H9_00624.ogg" , "H9_00625.ogg" , "H9_00632.ogg" , "H9_00633.ogg" },
              new string[] { "H9_00624.ogg" , "H9_00625.ogg" , "H9_00632.ogg" , "H9_00633.ogg" },
              new string[] { "H9_00622.ogg" , "H9_00623.ogg" , "H9_00630.ogg" , "H9_00631.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30MissyVibe = new string[][] {
              new string[] { "H9_00825.ogg" , "H9_00833.ogg" , "H9_00841.ogg" , "H9_00824.ogg" , "H9_00966.ogg" , "H9_00860.ogg" , "H9_00987.ogg" },
              new string[] { "H9_09425.ogg" , "H9_04328.ogg" , "H9_09398.ogg" , "H9_00837.ogg" , "H9_04410.ogg" , "H9_07850.ogg" , "H9_04310.ogg" , "H9_04320.ogg" , "H9_04391.ogg" , "H9_09446.ogg" , "H9_04408.ogg" },
              new string[] { "H9_07848.ogg" , "H9_06457.ogg" , "H9_06388.ogg" , "H9_06428.ogg" , "H9_06468.ogg" , "H9_09446.ogg" , "H9_07851.ogg" , "H9_04310.ogg" , "H9_04287.ogg" , "H9_09438.ogg" , "H9_04187.ogg" , "H9_09303.ogg" , "H9_04114.ogg" , "H9_06929.ogg" , "H9_03989.ogg" , ".ogg" , ".ogg" },
              new string[] { "H9_09304.ogg" , "H9_03822.ogg" , "H9_02024.ogg" , "H9_06487.ogg" , "H9_05299.ogg" , "H9_09423.ogg" , "H9_08378.ogg" , "H9_09362.ogg" , "H9_07836.ogg" , "H9_04325.ogg" , "H9_08215.ogg" , "H9_06562.ogg" , "H9_06426.ogg" , "H9_07096.ogg" , "H9_07848.ogg" , "H9_03812.ogg" , "H9_03439.ogg" , "H9_06428.ogg" , "H9_05297.ogg" , "H9_09440.ogg" , "H9_09433.ogg" , "H9_06589.ogg" , "H9_04054.ogg" , "H9_04328.ogg" , "H9_00333.ogg" , "H9_03821.ogg" , "H9_06407.ogg" , "H9_03574.ogg" , "H9_09439.ogg" , "H9_07837.ogg" , "H9_07851.ogg" , "H9_06586.ogg" , "H9_04049.ogg" , "H9_05794.ogg" , "H9_04310.ogg" , "H9_05711.ogg" , "H9_04324.ogg" , "H9_03491.ogg" , "H9_06573.ogg" , "H9_07826.ogg" , "H9_09430.ogg" , "H9_09353.ogg" , "H9_04287.ogg" , "H9_04326.ogg" , "H9_09303.ogg" , "H9_04187.ogg" , "H9_03571.ogg" , "H9_03842.ogg" , "H9_03834.ogg" , "H9_07847.ogg" , "H9_06553.ogg" , "H9_04327.ogg" , "H9_03506.ogg" },
              new string[] { "H9_00825.ogg" , "H9_00833.ogg" , "H9_00841.ogg" , "H9_00824.ogg" , "H9_00966.ogg" , "H9_00860.ogg" , "H9_00987.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30MissyFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40MissyVibe = new string[] { "H9_00894.ogg", "H9_00909.ogg", "H9_00895.ogg", "H9_00910.ogg", "H9_04413.ogg" };





        //性格別声テーブル　幼馴染---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20ChildhoodVibe = new string[][] {
              new string[] { "H10_03849.ogg" , "H10_03850.ogg" , "H10_03857.ogg" , "H10_03858.ogg" },
              new string[] { "H10_03841.ogg" , "H10_03842.ogg" , "H10_04057.ogg" , "H10_04058.ogg" },
              new string[] { "H10_03851.ogg" , "H10_03852.ogg" , "H10_03859.ogg" , "H10_03860.ogg" },
              new string[] { "H10_03843.ogg" , "H10_03844.ogg" , "H10_04059.ogg" , "H10_04060.ogg" },
              new string[] { "H10_03881.ogg" , "H10_03882.ogg" , "H10_03883.ogg" , "H10_03884.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20ChildhoodFera = new string[][] {
              new string[] { "H10_03889.ogg" , "H10_03890.ogg" , "H10_03897.ogg" , "H10_03898.ogg" },
              new string[] { "H10_03889.ogg" , "H10_03890.ogg" , "H10_03897.ogg" , "H10_03898.ogg" },
              new string[] { "H10_03891.ogg" , "H10_03892.ogg" , "H10_03899.ogg" , "H10_03900.ogg" },
              new string[] { "H10_03891.ogg" , "H10_03892.ogg" , "H10_03899.ogg" , "H10_03900.ogg" },
              new string[] { "H10_03889.ogg" , "H10_03890.ogg" , "H10_03897.ogg" , "H10_03898.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30ChildhoodVibe = new string[][] {
              new string[] { "H10_03853.ogg" , "H10_03854.ogg" , "H10_03861.ogg" , "H10_03862.ogg" },
              new string[] { "H10_03845.ogg" , "H10_03846.ogg" , "H10_04061.ogg" , "H10_04062.ogg" },
              new string[] { "H10_03855.ogg" , "H10_03856.ogg" , "H10_03863.ogg" , "H10_03864.ogg" },
              new string[] { "H10_03847.ogg" , "H10_03848.ogg" , "H10_04063.ogg" , "H10_04064.ogg" },
              new string[] { "H10_03885.ogg" , "H10_03886.ogg" , "H10_03887.ogg" , "H10_03888.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30ChildhoodFera = new string[][] {
              new string[] { "H10_03893.ogg" , "H10_03894.ogg" , "H10_03901.ogg" , "H10_03902.ogg" },
              new string[] { "H10_03893.ogg" , "H10_03894.ogg" , "H10_03901.ogg" , "H10_03902.ogg" },
              new string[] { "H10_03895.ogg" , "H10_03896.ogg" , "H10_03903.ogg" , "H10_03904.ogg" },
              new string[] { "H10_03895.ogg" , "H10_03896.ogg" , "H10_03903.ogg" , "H10_03904.ogg" },
              new string[] { "H10_03893.ogg" , "H10_03894.ogg" , "H10_03901.ogg" , "H10_03902.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30ChildhoodVibe = new string[][] {
              new string[] { "H10_04104.ogg" , "H10_04120.ogg" , "H10_04108.ogg" , "H10_04092.ogg" , "H10_04112.ogg" , "H10_04242.ogg" , "H10_04253.ogg" },
              new string[] { "H10_08819.ogg" , "H10_09457.ogg" , "H10_09058.ogg" , "H10_07196.ogg" , "H10_07216.ogg" , "H10_08271.ogg" , "H10_09813.ogg" },
              new string[] { "H10_09415.ogg" , "H10_09993.ogg" , "H10_08334.ogg" , "H10_01736.ogg" , "H10_01739.ogg" , "H10_03656.ogg" , "H10_03475.ogg" , "H10_03050.ogg" , "H10_03714.ogg" , "H10_03717.ogg" , "H10_03504.ogg" , "H10_03752.ogg" , "H10_04738.ogg" , "H10_08819.ogg" , "H10_09457.ogg" , "H10_09058.ogg" , "H10_07196.ogg" , "H10_07216.ogg" , "H10_08271.ogg" , "H10_09813.ogg" },
              new string[] { "H10_09415.ogg" , "H10_09993.ogg" , "H10_08334.ogg" , "H10_01736.ogg" , "H10_01739.ogg" , "H10_03656.ogg" , "H10_03475.ogg" , "H10_03050.ogg" , "H10_03714.ogg" , "H10_03717.ogg" , "H10_03504.ogg" , "H10_03752.ogg" , "H10_04738.ogg" , "H10_08819.ogg" , "H10_09457.ogg" , "H10_09058.ogg" , "H10_07196.ogg" , "H10_07216.ogg" , "H10_08271.ogg" , "H10_09813.ogg" , "H10_07212.ogg" , "H10_09173.ogg" , "H10_01079.ogg" , "H10_01553.ogg" , "H10_00671.ogg" , "H10_03456.ogg" , "H10_09207.ogg" , "H10_05225.ogg" , "H10_05228.ogg" , "H10_05231.ogg" , "H10_05617.ogg" , "H10_05393.ogg" , "H10_06041.ogg" , "H10_06229.ogg" , "H10_06066.ogg" , "H10_07020.ogg" , "H10_07021.ogg" },
              new string[] { "H10_04104.ogg" , "H10_04120.ogg" , "H10_04108.ogg" , "H10_04092.ogg" , "H10_04112.ogg" , "H10_04242.ogg" , "H10_04253.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30ChildhoodFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40ChildhoodVibe = new string[] { "H10_04171.ogg", "H10_04165.ogg", "H10_04166.ogg", "H10_04168.ogg", "H10_04170.ogg" };





        //性格別声テーブル　ドＭ---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20MasochistVibe = new string[][] {
              new string[] { "H11_00673.ogg" , "H11_00674.ogg" , "H11_00681.ogg" , "H11_00682.ogg" },
              new string[] { "H11_00865.ogg" , "H11_00866.ogg" , "H11_00689.ogg" , "H11_00690.ogg" },
              new string[] { "H11_00675.ogg" , "H11_00676.ogg" , "H11_00683.ogg" , "H11_00684.ogg" },
              new string[] { "H11_00867.ogg" , "H11_00868.ogg" , "H11_00691.ogg" , "H11_00692.ogg" },
              new string[] { "H11_00705.ogg" , "H11_00706.ogg" , "H11_00729.ogg" , "H11_00730.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20MasochistFera = new string[][] {
              new string[] { "H11_00713.ogg" , "H11_00714.ogg" , "H11_00721.ogg" , "H11_00722.ogg" },
              new string[] { "H11_00713.ogg" , "H11_00714.ogg" , "H11_00721.ogg" , "H11_00722.ogg" },
              new string[] { "H11_00715.ogg" , "H11_00716.ogg" , "H11_00723.ogg" , "H11_00724.ogg" },
              new string[] { "H11_00715.ogg" , "H11_00716.ogg" , "H11_00723.ogg" , "H11_00724.ogg" },
              new string[] { "H11_00713.ogg" , "H11_00714.ogg" , "H11_00721.ogg" , "H11_00722.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30MasochistVibe = new string[][] {
              new string[] { "H11_00677.ogg" , "H11_00678.ogg" , "H11_00685.ogg" , "H11_00686.ogg" },
              new string[] { "H11_00869.ogg" , "H11_00870.ogg" , "H11_00693.ogg" , "H11_00694.ogg" },
              new string[] { "H11_00679.ogg" , "H11_00680.ogg" , "H11_00687.ogg" , "H11_00688.ogg" },
              new string[] { "H11_00871.ogg" , "H11_00872.ogg" , "H11_00695.ogg" , "H11_00696.ogg" },
              new string[] { "H11_00708.ogg" , "H11_00707.ogg" , "H11_00731.ogg" , "H11_00732.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30MasochistFera = new string[][] {
              new string[] { "H11_00717.ogg" , "H11_00718.ogg" , "H11_00725.ogg" , "H11_00726.ogg" },
              new string[] { "H11_00717.ogg" , "H11_00718.ogg" , "H11_00725.ogg" , "H11_00726.ogg" },
              new string[] { "H11_00719.ogg" , "H11_00720.ogg" , "H11_00727.ogg" , "H11_00728.ogg" },
              new string[] { "H11_00719.ogg" , "H11_00720.ogg" , "H11_00727.ogg" , "H11_00728.ogg" },
              new string[] { "H11_00717.ogg" , "H11_00718.ogg" , "H11_00725.ogg" , "H11_00726.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30MasochistVibe = new string[][] {
              new string[] { "H11_00902.ogg" , "H11_00905.ogg" , "H11_00923.ogg" , "H11_00924.ogg" },
              new string[] { "H11_04914.ogg" , "H11_04738.ogg" , "H11_04915.ogg" , "H11_04983.ogg" ,"H11_05086.ogg" },
              new string[] { "H11_01458.ogg" , "H11_02000.ogg" , "H11_01850.ogg" , "H11_01963.ogg" , "H11_04177.ogg" , "H11_04265.ogg" , "H11_01980.ogg" , "H11_01988.ogg" , "H11_02029.ogg" , "H11_04914.ogg" , "H11_04738.ogg" , "H11_04915.ogg" , "H11_04983.ogg" ,"H11_05086.ogg" },
              new string[] { "H11_04902.ogg" , "H11_05069.ogg" , "H11_05104.ogg" , "H11_05150.ogg" , "H11_04450.ogg" , "H11_01875.ogg" , "H11_01880.ogg" , "H11_01883.ogg" , "H11_01885.ogg" , "H11_02204.ogg" , "H11_01945.ogg" , "H11_04253.ogg" , "H11_03646.ogg" , "H11_03545.ogg" , "H11_03414.ogg" , "H11_03548.ogg" , "H11_03596.ogg" , "H11_05093.ogg" , "H11_01988.ogg" , "H11_04914.ogg" , "H11_04738.ogg" , "H11_04915.ogg" , "H11_04983.ogg" ,"H11_05086.ogg" },
              new string[] { "H11_00902.ogg" , "H11_00905.ogg" , "H11_00923.ogg" , "H11_00924.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30MasochistFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40MasochistVibe = new string[] { "H11_00957.ogg", "H11_00969.ogg", "H11_00958.ogg", "H11_00970.ogg", "H11_02817.ogg" };





        //性格別声テーブル　腹黒---------------------------------------------------------------
        //弱バイブ　通常
        public string[][] sLoopVoice20CraftyVibe = new string[][] {
              new string[] { "H12_01213.ogg" , "H12_01214.ogg" , "H12_01221.ogg" , "H12_01222.ogg" },
              new string[] { "H12_01205.ogg" , "H12_01206.ogg" , "H12_01421.ogg" , "H12_01422.ogg" },
              new string[] { "H12_01215.ogg" , "H12_01216.ogg" , "H12_01223.ogg" , "H12_01227.ogg" },
              new string[] { "H12_01207.ogg" , "H12_01208.ogg" , "H12_01423.ogg" , "H12_01424.ogg" },
              new string[] { "H12_01245.ogg" , "H12_01247.ogg" , "H12_01248.ogg" , "H12_01249.ogg" }
              };
        //弱バイブ　フェラ
        public string[][] sLoopVoice20CraftyFera = new string[][] {
              new string[] { "H12_01253.ogg" , "H12_01254.ogg" , "H12_01261.ogg" , "H12_01262.ogg" },
              new string[] { "H12_01253.ogg" , "H12_01254.ogg" , "H12_01261.ogg" , "H12_01262.ogg" },
              new string[] { "H12_01255.ogg" , "H12_01256.ogg" , "H12_01263.ogg" , "H12_01264.ogg" },
              new string[] { "H12_01255.ogg" , "H12_01256.ogg" , "H12_01263.ogg" , "H12_01264.ogg" },
              new string[] { "H12_01253.ogg" , "H12_01254.ogg" , "H12_01261.ogg" , "H12_01262.ogg" }
              };
        //強バイブ　通常
        public string[][] sLoopVoice30CraftyVibe = new string[][] {
              new string[] { "H12_01217.ogg" , "H12_01218.ogg" , "H12_01225.ogg" , "H12_01226.ogg" },
              new string[] { "H12_01209.ogg" , "H12_01210.ogg" , "H12_01425.ogg" , "H12_01426.ogg" },
              new string[] { "H12_01219.ogg" , "H12_01220.ogg" , "H12_01227.ogg" , "H12_01228.ogg" },
              new string[] { "H12_01211.ogg" , "H12_01212.ogg" , "H12_01427.ogg" , "H12_01428.ogg" },
              new string[] { "H12_01249.ogg" , "H12_01250.ogg" , "H12_01251.ogg" , "H12_01252.ogg" }
              };
        //強バイブ　フェラ
        public string[][] sLoopVoice30CraftyFera = new string[][] {
              new string[] { "H12_01257.ogg" , "H12_01258.ogg" , "H12_01265.ogg" , "H12_01266.ogg" },
              new string[] { "H12_01257.ogg" , "H12_01258.ogg" , "H12_01265.ogg" , "H12_01266.ogg" },
              new string[] { "H12_01259.ogg" , "H12_01260.ogg" , "H12_01267.ogg" , "H12_01268.ogg" },
              new string[] { "H12_01259.ogg" , "H12_01260.ogg" , "H12_01267.ogg" , "H12_01268.ogg" },
              new string[] { "H12_01257.ogg" , "H12_01258.ogg" , "H12_01265.ogg" , "H12_01266.ogg" }
              };
        //絶頂　通常
        public string[][] sOrgasmVoice30CraftyVibe = new string[][] {
              new string[] { "H12_01487.ogg" , "H12_01488.ogg" , "H12_01487.ogg" , "H12_01488.ogg" },
              new string[] { "H12_01488.ogg" , "H12_01663.ogg" , "H12_03082.ogg" , "H12_03084.ogg" ,"H12_03115.ogg" },
              new string[] { "H12_03082.ogg" , "H12_01725.ogg" , "H12_03082.ogg" , "H12_01870.ogg" , "H12_01799.ogg" , "H12_01787.ogg", "H12_01488.ogg" , "H12_01663.ogg" , "H12_03084.ogg" ,"H12_03115.ogg" },
              new string[] { "H12_01487.ogg" , "H12_01665.ogg" , "H12_01870.ogg" , "H12_01799.ogg" , "H12_01725.ogg" , "H12_03084.ogg" , "H12_03096.ogg" , "H12_03115.ogg" , "H12_01663.ogg" , "H12_01787.ogg" , "H12_01666.ogg"  },
              new string[] { "H12_01487.ogg" , "H12_01488.ogg" , "H12_01487.ogg" , "H12_01488.ogg" }
              };
        //絶頂　フェラ
        public string[][] sOrgasmVoice30CraftyFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public string[] sLoopVoice40CraftyVibe = new string[] { "H12_01529.ogg", "H12_01544.ogg", "H12_01530.ogg", "H12_01545.ogg", "H12_01534.ogg" };










        //　性格別声テーブル　こっち来て
        public string[] sCallVoice = new string[] { "S0_13972.ogg", "S1_03893.ogg", "s2_08163.ogg", "S3_11386.ogg", "s4_15255.ogg", "s5_16924.ogg", "s6_18089.ogg", "", "" };



        //カスタム音声テーブル　弱バイブ版---------------------------------------------------------------
        //カスタムボイス１
        public string[][] sLoopVoice20Custom1 = new string[][] {
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" }
              };
        //カスタムボイス２
        public string[][] sLoopVoice20Custom2 = new string[][] {
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" }
              };
        //カスタムボイス３
        public string[][] sLoopVoice20Custom3 = new string[][] {
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" }
              };
        //カスタムボイス４
        public string[][] sLoopVoice20Custom4 = new string[][] {
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" }
              };

        //カスタム音声テーブル　強バイブ版---------------------------------------------------------------
        public string[][] sLoopVoice30Custom1 = new string[][] {
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" }
              };
        public string[][] sLoopVoice30Custom2 = new string[][] {
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" }
              };
        public string[][] sLoopVoice30Custom3 = new string[][] {
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" }
              };
        public string[][] sLoopVoice30Custom4 = new string[][] {
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" }
              };

        //カスタム音声テーブル　絶頂時---------------------------------------------------------------
        public string[][] sOrgasmVoice30Custom1 = new string[][] {
              new string[] { "N0_00424.ogg" , "N0_00459.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" },
              new string[] { "N0_00424.ogg" , "N0_00459.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" },
              new string[] { "N0_00424.ogg" , "N0_00457.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" },
              new string[] { "N0_00456.ogg" , "N0_00457.ogg" , "N0_00458.ogg" , "N0_00534.ogg" , "N0_00288.ogg" , "N0_00292.ogg" , "N0_00293.ogg" },
              new string[] { "N0_00424.ogg" , "N0_00459.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" }
              };
        public string[][] sOrgasmVoice30Custom2 = new string[][] {
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" },
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" },
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" },
              new string[] { "N7_00284.ogg" , "N7_00291.ogg" , "N7_00293.ogg" , "N7_00294.ogg" , "N7_00295.ogg" , "N7_00275.ogg" , "n7_00295.ogg" },
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" }
              };
        public string[][] sOrgasmVoice30Custom3 = new string[][] {
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00198.ogg" , "N1_00199.ogg" , "N1_00205.ogg" , "N1_00217.ogg" , "N1_00333.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" }
              };
        public string[][] sOrgasmVoice30Custom4 = new string[][] {
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" },
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" },
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" },
              new string[] { "N3_00376.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00197.ogg" , "N3_00203.ogg" , "N3_00328.ogg" , "N3_00330.ogg" , "N3_00379.ogg" },
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" }
              };

        //カスタム音声テーブル　停止時---------------------------------------------------------------
        public string[] sLoopVoice40Custom1 = new string[] { "N0_00460.ogg", "N0_00460.ogg", "N0_00460.ogg", "N0_00460.ogg", "N0_00460.ogg" };
        public string[] sLoopVoice40Custom2 = new string[] { "N7_00277.ogg", "N7_00277.ogg", "N7_00277.ogg", "N7_00277.ogg", "N7_00277.ogg" };
        public string[] sLoopVoice40Custom3 = new string[] { "N1_00382.ogg", "N1_00382.ogg", "N1_00382.ogg", "N1_00382.ogg", "N1_00382.ogg" };
        public string[] sLoopVoice40Custom4 = new string[] { "N3_00205.ogg", "N3_00205.ogg", "N3_00205.ogg", "N3_00205.ogg", "N3_00205.ogg" };

        //改変終了---------------------------------------



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
        }

        private GameObject gameObject_ui;

        private bool StartFlag = false; //　シーンがかわってから操作されたかどうか

        private CameraMain mainCamera;

        //メイド取得フラグ
        private bool reGetMaid = false;

        //男モデル
        private Maid man;
        private Maid[] SubMans = new Maid[5];
        private int[] MansTg = new int[5];
        private string[] SubMansName = new string[] { "ご主人様", "モブ男Ａ", "モブ男Ｂ", "モブ男Ｃ", "モブ男Ｄ" };
        private float[] syaseiValue = new float[] { 0f, 0f, 0f, 0f, 0f };
        private int[] mansLevel = new int[] { 0, 0, 0, 0, 0 };
        private bool[] syaseiLock = new bool[] { false, false, false, false, false };
        private int MansFGet = 0;

        //　音声・表情のモード切り替え用
        private string[] ModeSelectList = new string[] { "通常固定", "フェラ固定", "カスタム１", "カスタム２", "カスタム３", "カスタム４" };

        private string[][] ModeSelectList2 = new string[][] { //性格追加時に更新
          new string[]{ "デフォルト" , "ツンデレ" , "クーデレ" , "純真" , "ヤンデレ" , "姉ちゃん" , "僕っ娘" , "ドＳ" , "無垢" , "真面目" , "凛デレ" , "無口" , "小悪魔" , "おしとやか" , "メイド秘書" , "ふわふわ妹" , "無愛想" , "お嬢様" , "幼馴染" , "ドＭ" , "腹黒" },
          new string[]{ "" , "Pride" , "Cool" , "Pure" , "Yandere" , "Anesan" , "Genki" , "Sadist" , "Muku" , "Majime" , "Rindere" , "Silent" , "Devilish" , "Ladylike" , "Secretary" , "Sister" , "Curtness" , "Missy" , "Masochist" , "Crafty" }
        };
        private string[][] personalList = new string[][] { //性格追加時に更新
          new string[]{ "ツンデレ" , "クーデレ" , "純真" , "ヤンデレ" , "姉ちゃん" , "僕っ娘" , "ドＳ" , "無垢" , "真面目" , "凛デレ" , "無口" , "小悪魔" , "お淑やか" , "ﾒｲﾄﾞ秘書" , "ふわ妹" , "無愛想" , "お嬢様" , "幼馴染" , "ドＭ" , "腹黒" , "指定無" },
          new string[]{ "Pride" , "Cool" , "Pure" , "Yandere" , "Anesan" , "Genki" , "Sadist" , "Muku" , "Majime" , "Rindere" , "Silent" , "Devilish" , "Ladylike" , "Secretary" , "Sister" , "Curtness" , "Missy" , "Childhood" , "Masochist" , "Crafty" }
        };

        public string[][] reactionVoice = new string[][] { //性格追加時に更新
          new string[] { "s0_01898.ogg" , "s0_01899.ogg" , "s0_01902.ogg" , "s0_01900.ogg" },
          new string[] { "s1_03223.ogg" , "s1_03246.ogg" , "s1_03247.ogg" , "s1_03210.ogg" },
          new string[] { "s2_01478.ogg" , "s2_01477.ogg" , "s2_01476.ogg" , "s2_01475.ogg" },
          new string[] { "s3_02908.ogg" , "s3_02950.ogg" , "s3_02923.ogg" , "s3_02932.ogg" },
          new string[] { "s4_08348.ogg" , "s4_08354.ogg" , "s4_08365.ogg" , "s4_08374.ogg" },
          new string[] { "s5_04264.ogg" , "s5_04258.ogg" , "s5_04256.ogg" , "s5_04255.ogg" },
          new string[] { "s6_01744.ogg" , "s6_02700.ogg" , "s6_02450.ogg" , "s6_02357.ogg" },
          new string[] { "H0_00289.ogg" , "H0_00290.ogg" , "H0_00291.ogg" , "H0_00292.ogg" },
          new string[] { "H1_11482.ogg" , "H1_13858.ogg" , "H1_13879.ogg" , "H1_13918.ogg" },
          new string[] { "H2_06092.ogg" , "H2_00252.ogg" , "H2_00285.ogg" , "H2_00277.ogg" },
          new string[] { "H3_00779.ogg" , "H3_00783.ogg" , "H3_00785.ogg" , "H3_00800.ogg" },
          new string[] { "H4_01200.ogg" , "H4_01204.ogg" , "H4_01209.ogg" , "H4_01208.ogg" },
          new string[] { "H5_00943.ogg" , "H5_00944.ogg" , "H5_00948.ogg" , "H5_00874.ogg" },
          new string[] { "H6_00421.ogg" , "H6_00429.ogg" , "H6_00448.ogg" , "H6_00409.ogg" },
          new string[] { "H7_03163.ogg" , "H7_03167.ogg" , "H7_03164.ogg" , "H7_03172.ogg" },
          new string[] { "H8_08466.ogg" , "H8_01430.ogg" , "H8_01421.ogg" , "H8_01382.ogg" , "H8_01396.ogg" , "H8_01398.ogg" },
          new string[] { "H9_00825.ogg" , "H9_00833.ogg" , "H9_00841.ogg" , "H9_00824.ogg" , "H9_00966.ogg" , "H9_00860.ogg" , "H9_00987.ogg" },
          new string[] { "H10_04104.ogg" , "H10_04120.ogg" , "H10_04108.ogg" , "H10_04092.ogg" , "H10_04112.ogg" , "H10_04242.ogg" , "H10_04253.ogg" },
          new string[] { "H11_00902.ogg" , "H11_00905.ogg" , "H11_00923.ogg" , "H11_00924.ogg" },
          new string[] { "H12_01467.ogg" , "H12_01468.ogg" , "H12_01475.ogg" , "H12_01460.ogg" }
        };


        //SE切替関連
        private string[][] SeFileList = new string[][] {
          new string[] { "バイブ音" , "抽挿音" , "オート" },
          new string[] { "se020.ogg" , "se028.ogg" },
          new string[] { "se019.ogg" , "se029.ogg" }
        };



        //脱衣処理用
        private bool isWear = true;      //トップス
        private bool isOnepiece = true;  //ワンピース
        private bool isMizugi = true;      //水着
        private bool isSkirt = true;     //ボトムス
        private bool isBra = true;       //ブラジャー
        private bool isPanz = true;      //ショーツ
        private bool isHeadset = true;   //頭
        private bool isAccUde = true;    //腕
        private bool isStkg = true;      //靴下
        private bool isShoes = true;     //靴
        private bool isGlove = true;     //手袋
        private bool isMegane = true;    //メガネ
        private bool isAccSenaka = true; //背中
        private bool isAccXxx = true;    //あそこ
        private bool isKubi = true;    //首
        private bool isMimi = true;    //耳
        private bool isAshi = true;    //足首
        private bool isShippo = true;    //しっぽ
        private bool isUhair = true;    //アンダーヘア
        private bool isAccSonota = true; //その他アクセ
        private bool isItem = true; //メイドアイテム


        //アヘ関連
        private float fEyePosToSliderMul = 5000f;

        //ロック関連
        private bool ExciteLock = false;
        private bool OrgasmLock = false;

        private float ShapeKeySpeedRate = 60f;              // 60fps を基本倍率とする
        private int shapeTgNum1 = 0;
        private int shapeTgNum2 = 0;


        private float WaitTime = 0;                         //　シーン15開始時の待機時間用
        private float timerRate = Time.deltaTime * 60;

        private bool scKeyOff = false;

        //　Chu-B Lip / VR
        private bool bChuBLip;
        private bool bOculusVR;
        private bool installed = false;


        private int vSceneLevel = 0;
        private bool SceneLevelEnable = false;



        //ステータス表示用
        private string[] SucoreText1 = new string[] { "☆ ☆ ☆", "★ ☆ ☆", "★ ★ ☆", "★ ★ ★" };
        private string[] SucoreText2 = new string[] { "☆ ☆ ☆", "★ ☆ ☆", "★ ★ ☆", "★ ★ ★" };
        private string[] SucoreText3 = new string[] { "☆ ☆ ☆", "★ ☆ ☆", "★ ★ ☆", "★ ★ ★" };






        //--------------------------------------------
        //ゲーム起動時の処理--------------------------
        //VibeYourMaidConfig cfg;
        VibeYourMaidCfgWriting cfgw = new VibeYourMaidCfgWriting();
        public void Awake()
        {

            // フォルダ確認
            if (!System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\"))
            {
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(@"Sybaris\UnityInjector\Config\VibeYourMaid"); //ない場合はフォルダ作成
            }
            if (!System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\BasicVoiseSet\"))
            {
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(@"Sybaris\UnityInjector\Config\VibeYourMaid\BasicVoiseSet"); //ない場合はフォルダ作成
            }
            if (!System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\CommonDressSet\"))
            {
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(@"Sybaris\UnityInjector\Config\VibeYourMaid\CommonDressSet"); //ない場合はフォルダ作成
            }

            if (!File.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt"))
            {
                StreamWriter sw = File.CreateText(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt");
                sw.Close();
            }


            GameObject.DontDestroyOnLoad(this);
            string path = UnityEngine.Application.dataPath;

            /*
            // Iniファイル読み込み
            cfg = ReadConfig<VibeYourMaidConfig>("Config");
            // Iniファイル書き出し
            SaveConfig(cfg, "Config");
            */

            //Configファイルのロードとセーブ
            ConfigFileLoad();
            ConfigFileSave();

            // ChuBLip判別
            bChuBLip = path.Contains("COM3D2OHx64") || path.Contains("COM3D2OHx86") || path.Contains("COM3D2OHVRx64");
            // VR判別
            bOculusVR = path.Contains("COM3D2OHVRx64") || path.Contains("COM3D2VRx64") || Environment.CommandLine.ToLower().Contains("/vr");


            //UNZIP用モーションリスト作成
            MajFileLoad();
            UnzipMotionLoad();
            MajFileSave();
            //イタズラ用モーションリスト作成
            ItazuraMotionLoad();

            //性格追加時に更新
            bvs[0] = new BasicVoiceSet(sLoopVoice20PrideVibe, sLoopVoice20PrideFera, sLoopVoice30PrideVibe, sLoopVoice30PrideFera, sOrgasmVoice30PrideVibe, sOrgasmVoice30PrideFera, sLoopVoice40PrideVibe);
            bvs[1] = new BasicVoiceSet(sLoopVoice20CoolVibe, sLoopVoice20CoolFera, sLoopVoice30CoolVibe, sLoopVoice30CoolFera, sOrgasmVoice30CoolVibe, sOrgasmVoice30CoolFera, sLoopVoice40CoolVibe);
            bvs[2] = new BasicVoiceSet(sLoopVoice20PureVibe, sLoopVoice20PureFera, sLoopVoice30PureVibe, sLoopVoice30PureFera, sOrgasmVoice30PureVibe, sOrgasmVoice30PureFera, sLoopVoice40PureVibe);
            bvs[3] = new BasicVoiceSet(sLoopVoice20YandereVibe, sLoopVoice20YandereFera, sLoopVoice30YandereVibe, sLoopVoice30YandereFera, sOrgasmVoice30YandereVibe, sOrgasmVoice30YandereFera, sLoopVoice40YandereVibe);
            bvs[4] = new BasicVoiceSet(sLoopVoice20AnesanVibe, sLoopVoice20AnesanFera, sLoopVoice30AnesanVibe, sLoopVoice30AnesanFera, sOrgasmVoice30AnesanVibe, sOrgasmVoice30AnesanFera, sLoopVoice40AnesanVibe);
            bvs[5] = new BasicVoiceSet(sLoopVoice20GenkiVibe, sLoopVoice20GenkiFera, sLoopVoice30GenkiVibe, sLoopVoice30GenkiFera, sOrgasmVoice30GenkiVibe, sOrgasmVoice30GenkiFera, sLoopVoice40GenkiVibe);
            bvs[6] = new BasicVoiceSet(sLoopVoice20SadistVibe, sLoopVoice20SadistFera, sLoopVoice30SadistVibe, sLoopVoice30SadistFera, sOrgasmVoice30SadistVibe, sOrgasmVoice30SadistFera, sLoopVoice40SadistVibe);
            bvs[7] = new BasicVoiceSet(sLoopVoice20MukuVibe, sLoopVoice20MukuFera, sLoopVoice30MukuVibe, sLoopVoice30MukuFera, sOrgasmVoice30MukuVibe, sOrgasmVoice30MukuFera, sLoopVoice40MukuVibe);
            bvs[8] = new BasicVoiceSet(sLoopVoice20MajimeVibe, sLoopVoice20MajimeFera, sLoopVoice30MajimeVibe, sLoopVoice30MajimeFera, sOrgasmVoice30MajimeVibe, sOrgasmVoice30MajimeFera, sLoopVoice40MajimeVibe);
            bvs[9] = new BasicVoiceSet(sLoopVoice20RindereVibe, sLoopVoice20RindereFera, sLoopVoice30RindereVibe, sLoopVoice30RindereFera, sOrgasmVoice30RindereVibe, sOrgasmVoice30RindereFera, sLoopVoice40RindereVibe);
            bvs[10] = new BasicVoiceSet(sLoopVoice20SilentVibe, sLoopVoice20SilentFera, sLoopVoice30SilentVibe, sLoopVoice30SilentFera, sOrgasmVoice30SilentVibe, sOrgasmVoice30SilentFera, sLoopVoice40SilentVibe);
            bvs[11] = new BasicVoiceSet(sLoopVoice20DevilishVibe, sLoopVoice20DevilishFera, sLoopVoice30DevilishVibe, sLoopVoice30DevilishFera, sOrgasmVoice30DevilishVibe, sOrgasmVoice30DevilishFera, sLoopVoice40DevilishVibe);
            bvs[12] = new BasicVoiceSet(sLoopVoice20LadylikeVibe, sLoopVoice20LadylikeFera, sLoopVoice30LadylikeVibe, sLoopVoice30LadylikeFera, sOrgasmVoice30LadylikeVibe, sOrgasmVoice30LadylikeFera, sLoopVoice40LadylikeVibe);
            bvs[13] = new BasicVoiceSet(sLoopVoice20SecretaryVibe, sLoopVoice20SecretaryFera, sLoopVoice30SecretaryVibe, sLoopVoice30SecretaryFera, sOrgasmVoice30SecretaryVibe, sOrgasmVoice30SecretaryFera, sLoopVoice40SecretaryVibe);
            bvs[14] = new BasicVoiceSet(sLoopVoice20SisterVibe, sLoopVoice20SisterFera, sLoopVoice30SisterVibe, sLoopVoice30SisterFera, sOrgasmVoice30SisterVibe, sOrgasmVoice30SisterFera, sLoopVoice40SisterVibe);
            bvs[15] = new BasicVoiceSet(sLoopVoice20CurtnessVibe, sLoopVoice20CurtnessFera, sLoopVoice30CurtnessVibe, sLoopVoice30CurtnessFera, sOrgasmVoice30CurtnessVibe, sOrgasmVoice30CurtnessFera, sLoopVoice40CurtnessVibe);
            bvs[16] = new BasicVoiceSet(sLoopVoice20MissyVibe, sLoopVoice20MissyFera, sLoopVoice30MissyVibe, sLoopVoice30MissyFera, sOrgasmVoice30MissyVibe, sOrgasmVoice30MissyFera, sLoopVoice40MissyVibe);
            bvs[17] = new BasicVoiceSet(sLoopVoice20ChildhoodVibe, sLoopVoice20ChildhoodFera, sLoopVoice30ChildhoodVibe, sLoopVoice30ChildhoodFera, sOrgasmVoice30ChildhoodVibe, sOrgasmVoice30ChildhoodFera, sLoopVoice40ChildhoodVibe);
            bvs[18] = new BasicVoiceSet(sLoopVoice20MasochistVibe, sLoopVoice20MasochistFera, sLoopVoice30MasochistVibe, sLoopVoice30MasochistFera, sOrgasmVoice30MasochistVibe, sOrgasmVoice30MasochistFera, sLoopVoice40MasochistVibe);
            bvs[19] = new BasicVoiceSet(sLoopVoice20CraftyVibe, sLoopVoice20CraftyFera, sLoopVoice30CraftyVibe, sLoopVoice30CraftyFera, sOrgasmVoice30CraftyVibe, sOrgasmVoice30CraftyFera, sLoopVoice40CraftyVibe);

            BvsFileLoad();
            BvsFileSave();
            BvsCheck(); //存在しないファイルをチェック

            XmlFilesCheck();

        }
        //--------------------------------------------





        public void Start()
        {

        }

        public void OnDestroy()
        {

        }


        //--------------------------------------------
        //シーン開始時の処理--------------------------
        void OnLevelWasLoaded(int level)
        {

            //レベルの取得
            vSceneLevel = level;

            //有効シーンにある場合プラグインを有効化（現在は基本的に、メイドさんがいれば全てのシーンで有効）
            SceneLevelEnable = true;

            //SEの再生をストップ
            GameMain.Instance.SoundMgr.StopSe();

            //メインカメラの取得
            mainCamera = GameMain.Instance.MainCamera;

            //メイドさんの取得
            GetStockMaids();

            //アクティブなメイドさんのIDを取得
            VisibleMaidCheck();

            //エンパイアズライフのフラグ初期化
            lifeStart = 0;
            if (vSceneLevel == 3) gameObject_ui = GameObject.Find("UI Root"); //UIオブジェクトの取得


            //男モデル取得
            for (int i = 0; i < SubMans.Length; i++)
            {
                SubMans[i] = GameMain.Instance.CharacterMgr.GetMan(i);
            }
            //男Body取得のため、一度呼び出しておく
            if (vSceneLevel == 15 && MansFGet < 2)
            {
                ++MansFGet;
                foreach (Maid m in SubMans)
                {
                    m.Visible = true;
                    m.transform.position = new Vector3(0f, -10f, 0f);
                }
            }

            man = SubMans[0];
        }
        //--------------------------------------------





        //--------------------------------------------
        //GUI表示処理---------------------------------
        Rect node = new Rect(UnityEngine.Screen.width - 250, UnityEngine.Screen.height - 370, 220, 220);
        Rect node2 = new Rect(UnityEngine.Screen.width - 250, UnityEngine.Screen.height - 820, 220, 450);
        Rect node3 = new Rect(UnityEngine.Screen.width - 870, UnityEngine.Screen.height - 820, 620, 450);
        Rect node4 = new Rect(UnityEngine.Screen.width - 870, UnityEngine.Screen.height - 370, 620, 220);
        Rect node4a = new Rect(UnityEngine.Screen.width - 1090, UnityEngine.Screen.height - 370, 220, 220);
        Rect node5 = new Rect(UnityEngine.Screen.width - 870, UnityEngine.Screen.height - 990, 840, 170);

        void OnGUI()
        {
            GUIStyle gsWin = new GUIStyle("box");
            gsWin.fontSize = 12;
            gsWin.alignment = TextAnchor.UpperLeft;

            if (cfgw.bPluginEnabledV && cfgw.mainGuiFlag > 0 && tgID != -1)
            {

                if (SceneLevelEnable)
                {

                    if (vSceneLevel == 15 && WaitTime < 120)
                    {

                        WaitTime += timerRate;

                    }
                    else
                    {

                        if (cfgw.mainGuiFlag == 1)
                        {
                            node.height = 220;
                        }
                        else if (cfgw.mainGuiFlag == 2)
                        {
                            node.height = 20;
                        }

                        node = GUI.Window(324101, node, WindowCallback, "リモコンスイッチ  Ver2.0.5.2", gsWin);

                        if (cfgw.configGuiFlag) node3 = GUI.Window(324103, node3, WindowCallback3, "VibeYourMaid 設定画面", gsWin);

                        if (cfgw.unzipGuiFlag)
                        {
                            node4 = GUI.Window(324104, node4, WindowCallback4, "ムラムラしたのでメイドさんを押し倒す", gsWin);

                            /*調整中
                            if(maidsState[tgID].senyouTokusyuMotion.Count > 0){
                              node4a = new Rect( node4.x - 220 , node4.y , 220 , 220 );
                              node4a = GUI.Window(3241042, node4a, WindowCallback4a, "特殊モーション", gsWin);
                            }*/

                        }

                    }
                }
            }

            if (cfgw.bPluginEnabledV && cfgw.mainGuiFlag > 0 && (tgID != -1 || (lifeStart > 0 && !elFade)))
            {
                if (cfgw.subGuiFlag == 2)
                {
                    node2 = GUI.Window(324102, node2, WindowCallback2b, "メイド呼び出し", gsWin);
                }
                else
                {
                    node2 = GUI.Window(324102, node2, WindowCallback2a, "サブキャラ操作", gsWin);
                }
            }

            if (cfgw.bPluginEnabledV && cfgw.mainGuiFlag > 0 && lifeStart > 0 && !elFade) node5 = GUI.Window(324105, node5, WindowCallback5, "エンパイアズライフ", gsWin);

        }
        //--------------------------------------------





        //--------------------------------------------
        //フレーム毎の処理----------------------------
        void Update()
        {

            timerRate = Time.deltaTime * 60;

            //画面がフェードアウトするたびに、メイド情報の再取得フラグを立てる
            if (FadeMgr.GetFadeIn() && !reGetMaid) reGetMaid = true;

            //フェードイン後、再取得フラグが立っていたらメイド情報取得
            if (reGetMaid && !FadeMgr.GetFadeIn())
            {
                GetStockMaids(); //メイドさんの取得
                VisibleMaidCheck(); //アクティブなメイドさんのIDを取得
                reGetMaid = false;
            }



            //メイン処理---
            if (tgID != -1 && SceneLevelEnable && cfgw.bPluginEnabledV)
            {

                foreach (int maidID in vmId)
                {

                    //非表示のメイドがいたらアクティブメイドをチェックし直す
                    if (!stockMaids[maidID].mem.Visible)
                    {
                        VisibleMaidCheck();
                        if (tgID == -1) GameMain.Instance.SoundMgr.StopSe();
                        continue;
                    }

                    Maid maid = stockMaids[maidID].mem;

                    //オートモード処理
                    PowerAutoChange(maidID);

                    //モーションアジャスト アイテムセット（双頭バイブのみ）
                    if (maidsState[maidID].sVibeFlag)
                    {
                        maid.SetProp("handitem", "HandItemH_SoutouVibe_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.HandItemR, true);
                        maid.AllProcPropSeqStart();
                        maidsState[maidID].sVibeFlag = false;
                    }

                    StateMajorCheck(maidID);  //バイブステート変更処理実行

                    ExciteCheck(maidID);  //メイドの興奮判定

                    StatusFluctuation(maidID);  //メイドのステータス変更処理実行

                    //絶頂音声が終わった時の処理
                    if (maidsState[maidID].orgasmVoice == 2 && !stockMaids[maidID].mem.AudioMan.audiosource.isPlaying)
                    {
                        maidsState[maidID].orgasmVoice = 0;          //絶頂時音声フラグOFF
                        maidsState[maidID].voiceHoldTime = 0;       //音声をすぐ再生するため、タイマーリセット
                        maidsState[maidID].faceHoldTime = 0;
                        if (maidsState[maidID].vStateMajor == 40) maidsState[maidID].vStateMajorOld = 30;  //再生中にバイブ停止していた場合に、余韻状態に移行させるため
                    }

                    //ボイスセット再生処理
                    VoiceSetPlay(maidID);

                    //モーションセット処理
                    MotionSetChange(maidID);

                    //目線と顔の自動変更
                    EyeAutoChange(maidID);

                    //お触り位置取得
                    if (cfgw.osawariEnabled) targetInstallation(maidID);

                    //乳首設定処理
                    if (maidsState[maidID].chikubiEnabled)
                    {
                        int cv = ChikubiCheck(maidID);
                        if (maidsState[maidID].chikubi_View != cv || maidsState[maidID].vStateMajor != 10)
                        {
                            ChikubiSet(maidID, cv);
                            maidsState[maidID].chikubi_View = cv;
                        }
                    }

                    //ステート10が継続している場合はここで処理終了
                    if (maidsState[maidID].vStateMajor == 10 && maidsState[maidID].vStateMajorOld == 10) continue;

                    //絶頂スタートフラグのチェック
                    if (!maidsState[maidID].orgasmStart)
                    {
                        if (OrgasmCheck(maidID))
                        {
                            foreach (int ID in vmId)
                            {
                                if (ID != maidID && !LinkMaidCheck(maidID, ID)) continue;
                                maidsState[ID].orgasmStart = true;
                            }
                        }
                    }

                    OrgasmProcess(maidID);  //絶頂していた場合の処理実行
                    OrgasmBonus(maidID);  //絶頂後ボーナスタイム中の処理


                    //射精値MAX時の処理
                    if (maidsState[maidID].syaseiMotion != "Non" && SyaseiCheck(maidID, 100f) && maidsState[maidID].orgasmCmb <= 3)
                    {
                        string lastMotion = stockMaids[maidID].mem.body0.LastAnimeFN;  //現在のモーションを取得

                        MotionChange(stockMaids[maidID].mem, maidsState[maidID].syaseiMotion + ".anm", false, 0.7f, 1f);
                        MotionChangeAf(stockMaids[maidID].mem, lastMotion, true, 0.5f, 1f); // 終わったら再生する

                        ManMotionChange(maidsState[maidID].syaseiMotion + ".anm", maidID, false, 0.7f, 1f);
                        ManMotionChangeAf(lastMotion, maidID, true, 0.5f, 1f); // 終わったら再生する

                        ReactionPlay(maidID);
                    }


                    StunCheck(maidID);  //メイドの放心判定

                    //カメラと顔の位置チェック
                    if (mainCamera && Camera.main) CameraPosCheck(maidID);

                    //演出関係
                    maidsState[maidID].kaikanLevel = kaikanLevelCheck(maidID);  //フェイスブレンドレベルチェック
                    EffectSio(maidID);  //潮吹き
                    EffectToiki(maidID);  //吐息
                    EffectAieki(maidID);  //愛液


                    maidsState[maidID].continuationTime += timerRate;  //バイブ責めの継続時間加算
                    if (maidsState[maidID].faceHoldTime > 0) maidsState[maidID].faceHoldTime -= timerRate;  //表情変更タイマー減少
                    if (maidsState[maidID].motionHoldTime > 0) maidsState[maidID].motionHoldTime -= timerRate;  //モーション変更タイマー減少
                    if (maidsState[maidID].yoinHoldTime > 0) maidsState[maidID].yoinHoldTime -= timerRate;  //余韻タイマー減少
                    if (maidsState[maidID].orgasmHoldTime > 0 && maidsState[maidID].orgasmValue < 100) maidsState[maidID].orgasmHoldTime -= timerRate;  //絶頂後のボーナスタイマー減少


                    //モーション変更処理
                    if (maidsState[maidID].motionHoldTime <= 0)
                    {
                        MotionAdjustPsv(maidID);

                        if (maidsState[maidID].orgasmVoice == 1 || maidsState[maidID].orgasmVoice == 3)
                        {  //絶頂時モーション変更実行
                            ZeccyoMotionSelect(maidID);
                            if (maidsState[maidID].orgasmVoice == 3) maidsState[maidID].orgasmVoice = 2;

                        }
                        else
                        {  //通常時モーション変更実行
                            MaidMotionChange(maidID, true);
                        }
                        maidsState[maidID].motionHoldTime = UnityEngine.Random.Range(200f, 600f);  //次のモーション変更タイマーセット
                    }


                    //表情の変更処理
                    if (maidsState[maidID].faceHoldTime <= 0)
                    {
                        ChangeFaceAnime(maidID);  //表情変更実行
                        ChangeFaceBlend(maidID);  //フェイスブレンド変更実行
                        maidsState[maidID].faceHoldTime = cfgw.vStateAltTimeVBase + UnityEngine.Random.Range(0f, cfgw.vStateAltTimeVRandomExtend); //次の表情変更タイマーセット
                    }


                    //音声の変更処理
                    if (maidsState[maidID].voiceHoldTime <= 0 && (maidsState[maidID].orgasmVoice != 2 || !cfgw.zViceWaitEnabled) && (stockMaids[maidID].mem.AudioMan.audiosource.loop || !stockMaids[maidID].mem.AudioMan.audiosource.isPlaying || lifeStart != 0))
                    {
                        MaidVoicePlay(maidID);  //音声変更実行
                        maidsState[maidID].voiceHoldTime = cfgw.voiceHoldTimeBase + UnityEngine.Random.Range(0f, cfgw.voiceHoldTimeRandomExtend); //次の音声変更タイマーセット
                    }

                    if (maidsState[maidID].voiceHoldTime > 0 && maidsState[maidID].vsFlag != 2) maidsState[maidID].voiceHoldTime -= timerRate;  //音声変更タイマー減少
                    if (maidsState[maidID].voiceHoldTime <= 0 && stockMaids[maidID].mem.AudioMan.audiosource.loop && (maidsState[maidID].vStateMajor == 20 || maidsState[maidID].vStateMajor == 30))
                    {
                        stockMaids[maidID].mem.AudioMan.Stop(0f);  //ADVのオートモードが機能するよう、ループ音声を切り替える前に一旦止める
                    }


                    //余韻状態の処理
                    if (maidsState[maidID].yoinHoldTime <= 0)
                    {
                        if (maidsState[maidID].vStateMajor == 40)
                        {
                            if (maidsState[maidID].vStateMajorOld != 40)
                            {  //余韻状態開始時の場合は、感度や連続絶頂回数によって余韻時間増加させる
                               //maidsState[maidID].yoinHoldTime = cfgw.voiceHoldTimeBase + UnityEngine.Random.Range(0f , cfgw.vStateAltTimeVRandomExtend) + Mathf.CeilToInt(maidsState[maidID].boostValue * 20) + Mathf.CeilToInt(Mathf.Sqrt((float)maidsState[maidID].orgasmCmb)) * 60 + Mathf.CeilToInt(maidsState[maidID].orgasmValue) + Mathf.CeilToInt(maidsState[maidID].exciteValue / 120) ;
                                maidsState[maidID].yoinHoldTime = 300f + Mathf.CeilToInt(maidsState[maidID].boostValue * 20) + (float)maidsState[maidID].orgasmCmb * 100 + Mathf.CeilToInt(maidsState[maidID].orgasmValue) * 5 + Mathf.CeilToInt(maidsState[maidID].exciteValue / 30);
                                if (maidsState[maidID].yoinHoldTime > 5000f) maidsState[maidID].yoinHoldTime = 5000f;

                            }
                            else if (maidsState[maidID].kaikanLevel <= 1)
                            {  //前回も余韻状態だった場合かつ、勃起値とスタミナが正常値なら完全停止
                                maidsState[maidID].vStateMajor = 50;

                                //各種タイマーも同時にリセット
                                maidsState[maidID].motionHoldTime = 0;
                                maidsState[maidID].faceHoldTime = 0;
                                maidsState[maidID].voiceHoldTime = 0;

                            }
                        }
                    }

                }

                //男の射精値増加処理
                for (int im = 0; im < SubMans.Length; im++)
                {
                    if (syaseiLock[im]) continue;
                    if (!SubMans[im].Visible || MansTg[im] == -1) mansLevel[im] = 0;
                    if (mansLevel[im] == 0)
                    {
                        syaseiValue[im] -= 0.02f * timerRate;
                    }
                    else if (mansLevel[im] == 1)
                    {
                        syaseiValue[im] += 0.01f * timerRate;
                    }
                    else
                    {
                        syaseiValue[im] += 0.017f * timerRate;
                    }
                    if (syaseiValue[im] < 0f) syaseiValue[im] = 0f;
                    if (syaseiValue[im] > 100f) syaseiValue[im] = 100f;
                }

                //一人称視点処理
                FpsModeChange();

                //カメラのメイド追従処理
                MaidFollowingCamera(tgID);


                //ダブルクリック判定
                DClicCheck();

                //ショートカットキー
                ShortCutKey();

                //お触り処理
                if (cfgw.osawariEnabled) osawariHand();

            }
            //メイン処理終了---



            //プラグインの有効無効切替
            if (Input.GetKeyDown(cfgw.keyPluginToggleV0) && !scKeyOff && AndKey())
            {
                cfgw.bPluginEnabledV = !cfgw.bPluginEnabledV;
                if (cfgw.bPluginEnabledV)
                {
                    Console.WriteLine("VibeYourMaid Plugin 有効化");
                }
                else
                {
                    Console.WriteLine("VibeYourMaid Plugin 無効化");
                }
            }


            //エンパイアズライフ開始
            if (Input.GetKeyDown(cfgw.keyPluginToggleV11) && vSceneLevel == 3)
            {

                //背景が存在するかどうかチェック
                UnityEngine.Object @object = GameMain.Instance.BgMgr.CreateAssetBundle("Shitsumu_ChairRot");
                if (@object == null)
                {
                    @object = Resources.Load("BG/Shitsumu_ChairRot");
                    if (@object == null)
                    {
                        @object = Resources.Load("BG/2_0/Shitsumu_ChairRot");
                    }
                }

                if (@object != null)
                {
                    if (lifeStart == 0)
                    {
                        if (!bOculusVR) Camera.main.fieldOfView = 50.0f;
                        gameObject_ui.SetActive(false);
                        flagN = GameMain.Instance.CharacterMgr.status.GetFlag("時間帯") == 3;

                        ElStart();

                        if (!flagN) StartCoroutine("ElChange", 0);
                        if (flagN) StartCoroutine("ElChange", 1);
                    }
                    else
                    {
                        gameObject_ui.SetActive(true);
                        ElEnd();

                    }
                }
            }


            //エンパイアズライフモードの処理
            if (vSceneLevel == 3) StartCoroutine("EmpiresLife");



        }
        //--------------------------------------------





        //--------------------------------------------
        //フレーム終了時の処理------------------------
        void LateUpdate()
        {

            int mc = maidCount;
            if (mc >= 8)
            {
                mc = 4;
            }
            else if (mc >= 6)
            {
                mc = 3;
            }
            else if (mc >= 4)
            {
                mc = 2;
            }

            if (tgID != -1 && SceneLevelEnable)
            {

                foreach (int maidID in vmId)
                {

                    Maid maid = stockMaids[maidID].mem;

                    //口元の変更処理
                    MouthChange(maidID);

                    //シェイプキー操作
                    if (maidID == tgID) EffectGakupiku(maidID);  //痙攣操作

                    if (maidsState[maidID].vStateMajor == 20)
                    {
                        ShapeKeyRandam(maidID, cfgw.ShapeListR, cfgw.RandamMin1, cfgw.RandamMax1);
                        ShapeKeyWave(maidID, cfgw.ShapeListW, cfgw.ShapeListW2, cfgw.WaveMin1, cfgw.WaveMax1, cfgw.WaveSpead1);
                        ShapeKeyIncrease(maidID, cfgw.ShapeListI, cfgw.IncreaseMax1, cfgw.IncreaseSpead1);
                    }
                    if (maidsState[maidID].vStateMajor == 30)
                    {
                        ShapeKeyRandam(maidID, cfgw.ShapeListR, cfgw.RandamMin2, cfgw.RandamMax2);
                        ShapeKeyWave(maidID, cfgw.ShapeListW, cfgw.ShapeListW2, cfgw.WaveMin2, cfgw.WaveMax2, cfgw.WaveSpead2);
                        ShapeKeyIncrease(maidID, cfgw.ShapeListI, cfgw.IncreaseMax2, cfgw.IncreaseSpead2);
                    }

                    //以下の処理はメイドが複数いた場合、処理するフレームを分割する（最大４分割）
                    if (shapeTgNum1 == shapeTgNum2)
                    {
                        EffectAse(maidID);  //汗
                        EffectBokki(maidID);  //勃起操作
                        EffectHibuAnime(maidID, mc);  //秘部アニメ操作
                        if (maidsState[maidID].vStateMajor == 20)
                        {
                            ShapeKeyKupaWave(maidID, cfgw.WaveMin1, cfgw.WaveMax1, cfgw.WaveSpead1 * mc / 2);
                        }
                        if (maidsState[maidID].vStateMajor == 30)
                        {
                            ShapeKeyKupaWave(maidID, cfgw.WaveMin2, cfgw.WaveMax2, cfgw.WaveSpead2 * mc / 2);
                        }
                    }

                    EffectAhe(maidID, mc);  //瞳操作
                    EffectUterusDatsu(maidID); //子宮脱操作

                    shapeTgNum1++;
                    if (shapeTgNum1 >= mc) shapeTgNum1 = 0;


                    //赤面処理
                    if (maidsState[maidID].sekimenValue > 0f) try { VertexMorph_FromProcItem(maid.body0, "hoho2", maidsState[maidID].sekimenValue); } catch { /*LogError(ex);*/ }


                    //バイブステートのバックアップ
                    maidsState[maidID].vStateMajorOld = maidsState[maidID].vStateMajor;


                }


                //変更シェイプキーの適用
                VertexMorph_FixBlendValues();

                shapeTgNum2++;
                if (shapeTgNum2 >= mc) shapeTgNum2 = 0;
                shapeTgNum1 = 0;


                //メインメイドが変わったときの処理
                if (tgID != tgIDBack)
                {
                    if (man.Visible && cfgw.autoMoveEnabled)
                    {
                        MansTg[0] = tgID;
                        man.transform.position = stockMaids[tgID].mem.transform.position;
                        man.transform.eulerAngles = stockMaids[tgID].mem.transform.eulerAngles;
                        ManMotionChange(tgID, true, 0.5f, 1.0f);
                    }

                    ChangeSE(tgID, true);
                }
            }
            if (tgID != tgIDBack) tgIDBack = tgID;

        }
        //--------------------------------------------








        //---------------------------------------------------
        //メイドのデータ取得関連-----------------------------
        public List<MaidInfo> stockMaids = new List<MaidInfo>();
        public List<MaidState> maidsState = new List<MaidState>();
        public List<int> vmId = new List<int>();
        public int tgID = -1;
        public int tgIDBack = -1;
        public int maidCount = 0;

        public class MaidInfo
        {
            public MaidInfo(Maid m, int n, string fn, string ln, string ps, string con)
            {
                mem = m;
                id = n;
                fName = fn;
                lName = ln;
                personal = ps;
                contract = con;
            }

            public Maid mem = null;
            public int id = 0;
            public string fName = "";
            public string lName = "";
            public string personal = ""; //性格
            public string contract = ""; //契約
        }

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


        //メイドデータをストック
        void GetStockMaids()
        {
            stockMaids.Clear();
            for (int i = 0; i < GameMain.Instance.CharacterMgr.GetStockMaidCount(); i++)
            {
                Maid sm = GameMain.Instance.CharacterMgr.GetStockMaid(i);
                string fn = sm.status.firstName;
                string ln = sm.status.lastName;
                string ps = sm.status.personal.uniqueName;
                string con = sm.status.contract.ToString();

                stockMaids.Add(new MaidInfo(sm, i, fn, ln, ps, con));

                //State枠がまだ作られていないメイドの場合は追加
                if (maidsState.Count <= i) maidsState.Add(new MaidState());
            }
        }

        //アクティブメイドのIDをリスト化する
        void VisibleMaidCheck()
        {
            vmId.Clear();
            foreach (var sm in stockMaids)
            {
                if (sm.mem.Visible)
                {
                    vmId.Add(sm.id); //メイドIDをリストに追加

                    if (!maidsState[sm.id].visibleBack)
                    { //新たにメイドが表示されていた場合の処理
                      //メイドさんの顔と胸を取得する
                        Transform[] objList = sm.mem.transform.GetComponentsInChildren<Transform>();
                        if (objList.Count() != 0)
                        {
                            maidsState[sm.id].maidHead = null;
                            maidsState[sm.id].maidMune = null;
                            maidsState[sm.id].maidHara = null;
                            maidsState[sm.id].maidXxx = null;
                            foreach (var gameobject in objList)
                            {
                                if (gameobject.name == "Bone_Face" && maidsState[sm.id].maidHead == null) maidsState[sm.id].maidHead = gameobject;
                                if (gameobject.name == "Bip01 Spine1" && maidsState[sm.id].maidMune == null) maidsState[sm.id].maidMune = gameobject;
                                if (gameobject.name == "Bip01 Spine" && maidsState[sm.id].maidHara == null) maidsState[sm.id].maidHara = gameobject;
                                if (gameobject.name == "Bip01 Pelvis" && maidsState[sm.id].maidXxx == null) maidsState[sm.id].maidXxx = gameobject;
                            }
                        }

                        //お触り用ターゲットセット
                        targetSet(sm.id);

                        //エロステータス読み込み
                        LoadEroState(sm.id);

                        //乳首設定読込
                        ChikubiLoad(sm.id, 0);
                        ChikubiLoad(sm.id, 1);

                        maidsState[sm.id].visibleBack = true;
                    }

                }
                else
                {
                    if (maidsState[sm.id].visibleBack)
                    { //表示されていたメイドが消えた場合の処理
                        targetDestroy(sm.id); //お触り用ターゲット消去
                        maidsState[sm.id] = new MaidState();
                        maidsState[sm.id].visibleBack = false;
                    }
                }
            }

            //メイドが存在する場合にフラグを有効化
            if (vmId.Count > 0)
            {
                if (vmId.IndexOf(tgID) == -1) tgID = vmId[0];
            }
            else
            {
                tgID = -1;
            }

            maidCount = vmId.Count;
        }


        //エロステータスLOAD
        private void LoadEroState(int maidID)
        {
            Maid maid = stockMaids[maidID].mem;
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "cliMode", "0") != "") maidsState[maidID].cliMode = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "cliMode", "0"));

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "cliHidai", "0") != "") maidsState[maidID].cliHidai = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "cliHidai", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "chikubiHidai", "0") != "") maidsState[maidID].chikubiHidai = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "chikubiHidai", "0"));

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotal", "0") != "") maidsState[maidID].orgTotal = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotal", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgMax", "0") != "") maidsState[maidID].orgMax = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgMax", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalChitsu", "0") != "") maidsState[maidID].orgTotalChitsu = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalChitsu", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalAnal", "0") != "") maidsState[maidID].orgTotalAnal = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalAnal", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalEtc", "0") != "") maidsState[maidID].orgTotalEtc = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalEtc", "0"));

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiChitsu1", "0") != "") maidsState[maidID].syaseiTotal1[0] = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiChitsu1", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiAnal1", "0") != "") maidsState[maidID].syaseiTotal1[1] = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiAnal1", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiKuti1", "0") != "") maidsState[maidID].syaseiTotal1[2] = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiKuti1", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiSoto1", "0") != "") maidsState[maidID].syaseiTotal1[3] = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiSoto1", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiChitsu2", "0") != "") maidsState[maidID].syaseiTotal2[0] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiChitsu2", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiAnal2", "0") != "") maidsState[maidID].syaseiTotal2[1] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiAnal2", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiKuti2", "0") != "") maidsState[maidID].syaseiTotal2[2] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiKuti2", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiSoto2", "0") != "") maidsState[maidID].syaseiTotal2[3] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiSoto2", "0"));

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "sioTotal1", "0") != "") maidsState[maidID].sioTotal1 = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "sioTotal1", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "nyoTotal1", "0") != "") maidsState[maidID].nyoTotal1 = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "nyoTotal1", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "sioTotal2", "0") != "") maidsState[maidID].sioTotal2 = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "sioTotal2", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "nyoTotal2", "0") != "") maidsState[maidID].nyoTotal2 = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "nyoTotal2", "0"));

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "stanTotal", "0") != "") maidsState[maidID].stanTotal = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "stanTotal", "0"));
            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "uDatsuTotal", "0") != "") maidsState[maidID].uDatsuTotal = intCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "uDatsuTotal", "0"));
        }

        //エロステータスSAVE
        private void SaveEroState(int maidID)
        {
            Maid maid = stockMaids[maidID].mem;
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "cliMode", maidsState[maidID].cliMode.ToString(), true);

            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "cliHidai", maidsState[maidID].cliHidai.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "chikubiHidai", maidsState[maidID].chikubiHidai.ToString(), true);

            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotal", maidsState[maidID].orgTotal.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "orgMax", maidsState[maidID].orgMax.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalChitsu", maidsState[maidID].orgTotalChitsu.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalAnal", maidsState[maidID].orgTotalAnal.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "orgTotalEtc", maidsState[maidID].orgTotalEtc.ToString(), true);

            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiChitsu1", maidsState[maidID].syaseiTotal1[0].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiAnal1", maidsState[maidID].syaseiTotal1[1].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiKuti1", maidsState[maidID].syaseiTotal1[2].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiSoto1", maidsState[maidID].syaseiTotal1[3].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiChitsu2", maidsState[maidID].syaseiTotal2[0].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiAnal2", maidsState[maidID].syaseiTotal2[1].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiKuti2", maidsState[maidID].syaseiTotal2[2].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "seiekiSoto2", maidsState[maidID].syaseiTotal2[3].ToString(), true);

            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "sioTotal1", maidsState[maidID].sioTotal1.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "nyoTotal1", maidsState[maidID].nyoTotal1.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "sioTotal2", maidsState[maidID].sioTotal2.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "nyoTotal2", maidsState[maidID].nyoTotal2.ToString(), true);

            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "stanTotal", maidsState[maidID].stanTotal.ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "uDatsuTotal", maidsState[maidID].uDatsuTotal.ToString(), true);
        }


        //メイド呼び出し（夜伽のサブメイド読み込み&PlacementWindowのActiveMaidを参考にした）
        private void LoadMaid(Maid newmaid)
        {
            int k = 0;
            while (k < GameMain.Instance.CharacterMgr.GetMaidCount())
            {
                if (GameMain.Instance.CharacterMgr.GetMaid(k) == null || GameMain.Instance.CharacterMgr.GetMaid(k) == newmaid)
                {
                    break;
                }
                k++;
            }
            if (k > 20) //アクティブメイドの最大数は21
            {
                Console.WriteLine("アクティブメイド登録 インデックスエラー: " + k);
                return;
            }

            GameMain.Instance.CharacterMgr.SetActiveMaid(newmaid, k/*MaidList.Count+1*/);
            newmaid.Visible = true;
            newmaid.AllProcProp();
            newmaid.boMabataki = true;
        }


        //メイドの衣装めくれ処理
        private void MekureChanged(int maidID, string mekure, bool autoMode)
        {
            Maid maid = stockMaids[maidID].mem;
            string skirt = isPropChanged(maidID, "skirt");
            string onepiece = isPropChanged(maidID, "onepiece");
            string panz = isPropChanged(maidID, "panz");
            string mizugi = isPropChanged(maidID, "mizugi");

            if (mekure == "前")
            {
                if (skirt == "本：めくれ前" || onepiece == "本：めくれ前")
                { //本衣装のめくれ（前）状態だった場合
                    if (autoMode)
                    {
                        if (maid.body0.GetMask(TBody.SlotID.skirt)) maid.ResetProp("skirt", false);
                        if (maid.body0.GetMask(TBody.SlotID.onepiece)) maid.ResetProp("onepiece", false);
                    }
                }
                else if (skirt == "仮：めくれ前" || onepiece == "仮：めくれ前")
                { //仮衣装のめくれ（前）状態だった場合
                    if (autoMode)
                    {
                        if (maid.body0.GetMask(TBody.SlotID.skirt)) maid.SetProp(MPN.skirt, maid.GetProp(MPN.skirt).strTempFileName.Replace("_mekure", ""), 0, true, false);
                        if (maid.body0.GetMask(TBody.SlotID.onepiece)) maid.SetProp(MPN.onepiece, maid.GetProp(MPN.onepiece).strTempFileName.Replace("_mekure", ""), 0, true, false);
                    }
                }
                else if (skirt == "仮：めくれ後" || onepiece == "仮：めくれ後")
                { //仮衣装のめくれ（後）状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.skirt)) ItemChangeTemp(maidID, "skirt", "後");
                    if (maid.body0.GetMask(TBody.SlotID.onepiece)) ItemChangeTemp(maidID, "onepiece", "後");

                }
                else if (skirt == "仮：通常" || onepiece == "仮：通常")
                { //仮衣装の通常状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.skirt)) ItemChangeTemp(maidID, "skirt", "めくれスカート", true);
                    if (maid.body0.GetMask(TBody.SlotID.onepiece)) ItemChangeTemp(maidID, "onepiece", "めくれスカート", true);

                }
                else if (skirt != "無し" || onepiece != "無し")
                { //本衣装の通常状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.skirt)) ItemChangeTemp(maidID, "skirt", "めくれスカート", false);
                    if (maid.body0.GetMask(TBody.SlotID.onepiece)) ItemChangeTemp(maidID, "onepiece", "めくれスカート", false);

                }
            }

            if (mekure == "後")
            {
                if (skirt == "本：めくれ後" || onepiece == "本：めくれ後")
                { //本衣装のめくれ（後）状態だった場合
                    if (autoMode)
                    {
                        if (maid.body0.GetMask(TBody.SlotID.skirt)) maid.ResetProp("skirt", false);
                        if (maid.body0.GetMask(TBody.SlotID.onepiece)) maid.ResetProp("onepiece", false);
                    }
                }
                else if (skirt == "仮：めくれ後" || onepiece == "仮：めくれ後")
                { //仮衣装のめくれ（後）状態だった場合
                    if (autoMode)
                    {
                        if (maid.body0.GetMask(TBody.SlotID.skirt)) maid.SetProp(MPN.skirt, maid.GetProp(MPN.skirt).strTempFileName.Replace("_mekure_back", ""), 0, true, false);
                        if (maid.body0.GetMask(TBody.SlotID.onepiece)) maid.SetProp(MPN.onepiece, maid.GetProp(MPN.onepiece).strTempFileName.Replace("_mekure_back", ""), 0, true, false);
                    }
                }
                else if (skirt == "仮：めくれ前" || onepiece == "仮：めくれ前")
                { //仮衣装のめくれ（前）状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.skirt)) ItemChangeTemp(maidID, "skirt", "前");
                    if (maid.body0.GetMask(TBody.SlotID.onepiece)) ItemChangeTemp(maidID, "onepiece", "前");

                }
                else if (skirt == "仮：通常" || onepiece == "仮：通常")
                { //仮衣装の通常状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.skirt)) ItemChangeTemp(maidID, "skirt", "めくれスカート後ろ", true);
                    if (maid.body0.GetMask(TBody.SlotID.onepiece)) ItemChangeTemp(maidID, "onepiece", "めくれスカート後ろ", true);

                }
                else if (skirt != "無し" || onepiece != "無し")
                { //本衣装の通常状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.skirt)) ItemChangeTemp(maidID, "skirt", "めくれスカート後ろ", false);
                    if (maid.body0.GetMask(TBody.SlotID.onepiece)) ItemChangeTemp(maidID, "onepiece", "めくれスカート後ろ", false);

                }
            }

            if (mekure == "ずらし")
            {

                if (panz == "本：ずらし" || mizugi == "本：ずらし")
                { //本衣装のずらし状態だった場合
                    if (autoMode)
                    {
                        if (maid.body0.GetMask(TBody.SlotID.panz)) maid.ResetProp("panz", false);
                        if (maid.body0.GetMask(TBody.SlotID.mizugi)) maid.ResetProp("mizugi", false);
                    }
                }
                else if (panz == "仮：ずらし" || mizugi == "仮：ずらし")
                { //仮衣装のずらし状態だった場合
                    if (autoMode)
                    {
                        if (maid.body0.GetMask(TBody.SlotID.panz)) maid.SetProp(MPN.panz, maid.GetProp(MPN.panz).strTempFileName.Replace("_zurashi", ""), 0, true, false);
                        if (maid.body0.GetMask(TBody.SlotID.mizugi)) maid.SetProp(MPN.mizugi, maid.GetProp(MPN.mizugi).strTempFileName.Replace("_zurashi", ""), 0, true, false);
                    }
                }
                else if (panz == "仮：通常" || mizugi == "仮：通常")
                { //仮衣装の通常状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.panz)) ItemChangeTemp(maidID, "panz", "パンツずらし", true);
                    if (maid.body0.GetMask(TBody.SlotID.mizugi)) ItemChangeTemp(maidID, "mizugi", "パンツずらし", true);

                }
                else if (panz != "無し" || mizugi != "無し")
                { //本衣装の通常状態だった場合
                    if (maid.body0.GetMask(TBody.SlotID.panz)) ItemChangeTemp(maidID, "panz", "パンツずらし", false);
                    if (maid.body0.GetMask(TBody.SlotID.mizugi)) ItemChangeTemp(maidID, "mizugi", "パンツずらし", false);

                }
            }
            maid.AllProcPropSeqStart();
            dCheck = true;
        }


        //メイドの衣装状態チェック（めくれ、パンツずらし）
        private string isPropChanged(int maidID, string mpn)
        {
            MaidProp prop = stockMaids[maidID].mem.GetProp(mpn);
            SortedDictionary<string, string> sortedDictionary;
            string text;
            string result;

            if (prop.nFileNameRID != 0 && Menu.m_dicResourceRef.TryGetValue(prop.nFileNameRID, out sortedDictionary) && sortedDictionary.TryGetValue("めくれスカート", out text))
            {
                if (text.Equals(prop.strTempFileName))
                {
                    result = "本：めくれ前";
                    Console.WriteLine(mpn + result);
                    return result;
                }
            }
            if (prop.nFileNameRID != 0 && Menu.m_dicResourceRef.TryGetValue(prop.nFileNameRID, out sortedDictionary) && sortedDictionary.TryGetValue("めくれスカート後ろ", out text))
            {
                if (text.Equals(prop.strTempFileName))
                {
                    result = "本：めくれ後";
                    Console.WriteLine(mpn + result);
                    return result;
                }
            }
            if (prop.nFileNameRID != 0 && Menu.m_dicResourceRef.TryGetValue(prop.nFileNameRID, out sortedDictionary) && sortedDictionary.TryGetValue("パンツずらし", out text))
            {
                if (text.Equals(prop.strTempFileName))
                {
                    result = "本：ずらし";
                    Console.WriteLine(mpn + result);
                    return result;
                }
            }

            if (prop.nTempFileNameRID != 0)
            {
                if (prop.strTempFileName.Contains("_mekure_back"))
                {
                    result = "仮：めくれ後";
                    Console.WriteLine(mpn + result);
                    return result;
                }
                if (prop.strTempFileName.Contains("_mekure"))
                {
                    result = "仮：めくれ前";
                    Console.WriteLine(mpn + result);
                    return result;
                }
                if (prop.strTempFileName.Contains("_zurashi"))
                {
                    result = "仮：ずらし";
                    Console.WriteLine(mpn + result);
                    return result;
                }

                if (prop.strTempFileName.Contains("del.menu"))
                {
                    result = "無し";
                    return result;
                }
                result = "仮：通常";
                Console.WriteLine(mpn + result);
                return result;
            }

            if (prop.strFileName.Contains("del.menu"))
            {
                result = "無し";
                return result;
            }

            result = "本：通常";  //本衣装の普通状態だった場合
            Console.WriteLine(mpn + result);
            return result;

        }

        //めくれ、ずらし処理
        public void ItemChangeTemp(int maidID, string mpn, string name, bool temp)
        {
            Maid maid = stockMaids[maidID].mem;
            MaidProp prop = maid.GetProp(mpn);
            SortedDictionary<string, string> sortedDictionary;
            string filename;
            if (temp)
            {
                if (prop.nTempFileNameRID != 0 && global::Menu.m_dicResourceRef.TryGetValue(prop.nTempFileNameRID, out sortedDictionary) && sortedDictionary.TryGetValue(name, out filename))
                {
                    maid.SetProp(mpn, filename, 0, true, false);
                }
            }
            else
            {
                if (prop.nFileNameRID != 0 && global::Menu.m_dicResourceRef.TryGetValue(prop.nFileNameRID, out sortedDictionary) && sortedDictionary.TryGetValue(name, out filename))
                {
                    maid.SetProp(mpn, filename, 0, true, false);
                }
            }
        }
        public void ItemChangeTemp(int maidID, string mpn, string temp)
        {
            Maid maid = stockMaids[maidID].mem;
            MaidProp prop = maid.GetProp(mpn);
            if (temp == "前")
            {
                maid.SetProp(mpn, prop.strTempFileName.Replace("_mekure", "_mekure_back"), 0, true, false);
            }
            if (temp == "後")
            {
                maid.SetProp(mpn, prop.strTempFileName.Replace("_mekure_back", "_mekure"), 0, true, false);
            }
        }



        //フェラしてるかチェック
        private void checkBlowjobing(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;
            string sLastAnimeFileName = "";

            if (maidsState[maidID].orgasmVoice == 0)
            {
                sLastAnimeFileName = maid.body0.LastAnimeFN;
            }
            else
            {
                sLastAnimeFileName = maidsState[maidID].zAnimeFileName;
            }

            checkBlowjobing(maidID, sLastAnimeFileName);

        }

        private void checkBlowjobing(int maidID, string motion)
        {

            Maid maid = stockMaids[maidID].mem;
            string sLastAnimeFileName = motion;

            //メイドさんのモーションファイル名に含まれる文字列で判別させる
            if (sLastAnimeFileName != null)
            {

                maidsState[maidID].bIsBlowjobing = CheckMouthMode(sLastAnimeFileName);

                //メインメイドの場合はマウスモードを切り替える
                if (maidsState[maidID].bIsBlowjobing == 0 && maidsState[maidID].orgasmCmb <= 3)
                {  //0の時は連続絶頂中じゃなければ切り替える
                    int r = UnityEngine.Random.Range(0, 10);
                    if (maidsState[maidID].boostBase > 40 && maidsState[maidID].kaikanLevel > 4)
                    {  //感度が40以上の時はランダムでアヘか食いしばり 
                        if (r < 4)
                        {
                            maidsState[maidID].MouthMode = UnityEngine.Random.Range(2, 5);
                            if (maidsState[maidID].MouthMode < 3) maidsState[maidID].MouthMode = 0;
                        }
                    }
                    else if (maidsState[maidID].boostBase > 8 && maidsState[maidID].kaikanLevel > 3)
                    {  //感度が8以上の時はランダムで歯を食いしばる
                        if (r < 4)
                        {
                            maidsState[maidID].MouthMode = 0;
                        }
                        else
                        {
                            maidsState[maidID].MouthMode = 4;
                        }
                    }
                    else
                    {
                        maidsState[maidID].MouthMode = maidsState[maidID].bIsBlowjobing;
                    }
                }

                if (maidsState[maidID].bIsBlowjobing == 1 && cfgw.MouthKissEnabled) maidsState[maidID].MouthMode = maidsState[maidID].bIsBlowjobing; //1の時はキスが有効なら切り替える
                if (maidsState[maidID].bIsBlowjobing == 2 && cfgw.MouthFeraEnabled) maidsState[maidID].MouthMode = maidsState[maidID].bIsBlowjobing; //2の時はフェラが有効なら切り替える

                if (maidsState[maidID].stunFlag) maidsState[maidID].MouthMode = 3;  //放心中は無条件でアヘらせる


                //カメラが顔に近づいている場合、キスに変更
                if (maidsState[maidID].bIsBlowjobing == 0 && (maidsState[maidID].cameraCheck || (maidID == osawariID && osawariPoint == "mouth")))
                {
                    maidsState[maidID].bIsBlowjobing = 1;
                    if (cfgw.MouthKissEnabled && !maidsState[maidID].stunFlag)
                    {
                        maidsState[maidID].MouthMode = 1;
                    }
                }

                //フェラの時は顔をカメラに向けないようにする
                if (maidsState[maidID].bIsBlowjobing == 2)
                {
                    maid.body0.boHeadToCam = false;
                }

            }
        }

        //マウスモードのチェック
        private int CheckMouthMode(string motion)
        {

            int mm = 0;

            if (motion.Contains("fera")) mm = 2; //フェラ
            if (motion.Contains("sixnine")) mm = 2; //シックスナイン
            if (motion.Contains("_ir_")) mm = 2; //イラマ
            if (motion.Contains("_ir2_")) mm = 2; //イラマ
            if (motion.Contains("_ir2v_")) mm = 2; //イラマ
            if (motion.Contains("_irruma_")) mm = 2; //イラマ
            if (motion.Contains("_kuti")) mm = 2; //乱交３Ｐ
            if (motion.Contains("housi")) mm = 2; //乱交奉仕
            if (motion.Contains("kiss")) mm = 1; //キス
            if (motion.Contains("ran4p")) mm = 2; //乱交４Ｐ
            if (motion.Contains("3ana")) mm = 2; //三つ穴
            if (motion.Contains("feranasi")) mm = 0; //フェラ無し

            if (motion.Contains("taiki")) mm = 0; //待機中は含めない
            if (motion.Contains("shaseigo")) mm = 0; //射精後は含めない
            if (motion.Contains("surituke")) mm = 1; //乱交３Ｐ擦り付け時は咥えないのでは含めない
            if (motion.Contains("siriname")) mm = 2; //尻舐めはフェラ扱い
            if (motion.Contains("asiname")) mm = 2; //足舐めはフェラ扱い
            if (motion.Contains("tikubiname")) mm = 2; //乳首舐めはフェラ扱い

            if (motion.Contains("ir_in_taiki")) mm = 2; //咥え始めはフェラに含める
            if (motion.Contains("dt_in_taiki")) mm = 2; //咥え始めはフェラに含める
            if (motion.Contains("kuti_in_taiki")) mm = 2; //咥え始めはフェラに含める
            if (motion.Contains("kutia_in_taiki")) mm = 2; //咥え始めはフェラに含める

            if (motion.Contains("yuri_kunni") && motion.Contains("f2")) mm = 2; //百合のクンニする側をフェラに
            if (motion.Contains("harem_haimenzai") && motion.Contains("f2")) mm = 1; //ハーレムのキス担当
            if (motion.Contains("harem_housi_aibu")) mm = 0;
            if (motion.Contains("2vibe_vibe")) mm = 0;
            if (motion.Contains("onani_ona_")) mm = 0;
            if (motion.Contains("ran4p_kijyoui")) mm = 0;

            return mm;
        }



        //カメラとメイドさんの距離判定
        private float cameraCheckTime = 0f;
        private void CameraPosCheck(int maidID)
        {

            if (cameraCheckTime > 0)
            {
                cameraCheckTime -= timerRate;
                return;
            }
            cameraCheckTime = 60f;

            if (!cfgw.camCheckEnabled)
            {
                if (maidsState[maidID].cameraCheck)
                {
                    maidsState[maidID].cameraCheck = false;
                    stockMaids[maidID].mem.body0.boEyeToCam = maidsState[maidID].eyeToCamOld;
                    stockMaids[maidID].mem.body0.boHeadToCam = maidsState[maidID].headToCamOld;
                }
                return;
            }
            if (maidsState[maidID].bIsBlowjobing == 2) return;


            if (DistanceToMaid(maidID, cfgw.camCheckRange) && !maidsState[maidID].cameraCheck)
            {
                maidsState[maidID].eyeToCamOld = stockMaids[maidID].mem.body0.boEyeToCam;
                maidsState[maidID].headToCamOld = stockMaids[maidID].mem.body0.boHeadToCam;
                maidsState[maidID].cameraCheck = true;

                if (!fpsModeEnabled) stockMaids[maidID].mem.EyeToCamera((Maid.EyeMoveType)5, 0.8f); //一人称視点でない場合のみ、顔と目の追従を自動で有効にする
                if (maidsState[maidID].stunFlag) stockMaids[maidID].mem.body0.boEyeToCam = false;

                if (maidsState[maidID].bIsBlowjobing != 1)
                {
                    stockMaids[maidID].mem.AudioMan.Stop();     //現在の音声停止
                    maidsState[maidID].voiceHoldTime = 0;     //音声タイマーリセット
                }

            }
            else if (!DistanceToMaid(maidID, cfgw.camCheckRange) && maidsState[maidID].cameraCheck)
            {
                stockMaids[maidID].mem.body0.boEyeToCam = maidsState[maidID].eyeToCamOld;
                stockMaids[maidID].mem.body0.boHeadToCam = maidsState[maidID].headToCamOld;
                maidsState[maidID].cameraCheck = false;
                maidsState[maidID].voiceHoldTime = 0;
            }

        }

        private bool LinkMaidCheck(int maidID, int checkID)
        {
            if (checkID < 0) return false;
            if (maidsState[maidID].linkID == -1 && maidsState[checkID].linkID == -1) return false;
            if (maidID != maidsState[checkID].linkID && maidsState[maidID].linkID != checkID && maidsState[checkID].linkID != maidsState[maidID].linkID) return false;
            return true;
        }


        //メイドのデータ取得関連終了-------------------------





        //-------------------------------------------------
        //ステータス変更関係-------------------------------


        //バイブステートの変更
        private void StateMajorCheck(int maidID)
        {

            int level = maidsState[maidID].vLevel;
            if ((maidID == osawariID || LinkMaidCheck(maidID, osawariID)) && level < osawariLevel) level = osawariLevel;

            if (level == 2)
            { //　「バイブ強」
                if (maidsState[maidID].vStateMajor != 30)
                {
                    if (maidID == tgID) ChangeSE(tgID, true);
                    maidsState[maidID].vStateMajor = 30;
                }
            }
            else if (level == 1)
            { //　「バイブ弱」
                if (maidsState[maidID].vStateMajor != 20)
                {
                    if (maidID == tgID) ChangeSE(tgID, true);
                    maidsState[maidID].vStateMajor = 20;
                }
            }
            else if (level == 0)
            { //　「バイブ停止」        
                if (osawariID == maidID)
                {
                    if (maidID == tgID) GameMain.Instance.SoundMgr.StopSe();
                    maidsState[maidID].vStateMajor = 40;
                    maidsState[maidID].yoinHoldTime = 120f;
                }
                else if (maidsState[maidID].vStateMajor == 50)
                {
                    maidsState[maidID].vStateMajor = 10;
                }
                else if (maidsState[maidID].vStateMajor != 10 && maidsState[maidID].vStateMajor != 40)
                {
                    if (maidID == tgID) GameMain.Instance.SoundMgr.StopSe();
                    maidsState[maidID].vStateMajor = 40;
                    maidsState[maidID].yoinHoldTime = 0f;
                }
            }


            //バイブステートが変わったら、時間カウンタをリセットする。同時に男の責レベルも設定する
            if (maidsState[maidID].vStateMajor != maidsState[maidID].vStateMajorOld)
            {
                //時間カウンタのリセット
                maidsState[maidID].voiceHoldTime = 0;
                maidsState[maidID].faceHoldTime = 0;
                maidsState[maidID].continuationTime = 0;
                maidsState[maidID].motionHoldTime = 0;
                int im2 = 1;
                for (int im = 0; im < SubMans.Length; im++)
                {
                    if (!SubMans[im].Visible || MansTg[im] != maidID) continue;
                    float fDistance = Vector3.Distance(stockMaids[maidID].mem.transform.position, SubMans[im].transform.position);
                    if (fDistance > 1f) continue;
                    if (maidsState[maidID].giveSexual[im2])
                    {
                        mansLevel[im] = level;
                    }
                    else
                    {
                        mansLevel[im] = 0;
                    }
                    ++im2;
                }
            }
        }


        //興奮度の判定
        private void ExciteCheck(int maidID)
        {
            if (maidsState[maidID].exciteValue < cfgw.vExciteLevelThresholdV1 * 60)
            {
                maidsState[maidID].exciteLevel = 1;
            }
            else if (maidsState[maidID].exciteValue < cfgw.vExciteLevelThresholdV2 * 60)
            {
                maidsState[maidID].exciteLevel = 2;
            }
            else if (maidsState[maidID].exciteValue < cfgw.vExciteLevelThresholdV3 * 60)
            {
                maidsState[maidID].exciteLevel = 3;
            }
            else
            {
                maidsState[maidID].exciteLevel = 4;
            }
        }


        //ステータスの変更処理
        private void StatusFluctuation(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            float excitePlusBase = 0;     //興奮のベース加算値
            if (maidsState[maidID].vStateMajor == 20) excitePlusBase = 13;
            if (maidsState[maidID].vStateMajor == 30) excitePlusBase = 20;


            //抵抗値変動処理（同じバイブの強度を続けると抵抗値が上がる）
            if (maidsState[maidID].vStateMajor != maidsState[maidID].vStateMajorOld)
            {
                maidsState[maidID].resistBonus = 0; //強度が変わった時はリセット

            }
            else if (maidsState[maidID].vStateMajor != 10)
            { //強度が同じ時は、経過時間により加算
                if (maidsState[maidID].continuationTime < 120)
                {  //開始2秒は減少
                    maidsState[maidID].resistBonus -= 0.02f * timerRate;
                }
                else
                {
                    if (maidsState[maidID].vStateMajor == 20)
                    {
                        maidsState[maidID].resistBonus += 0.01f * maidsState[maidID].exciteLevel * timerRate;
                    }
                    else if (maidsState[maidID].vStateMajor == 30)
                    {
                        maidsState[maidID].resistBonus += 0.03f * maidsState[maidID].exciteLevel * timerRate;
                    }
                }
            }


            //ベース感度の上限設定
            if (maidsState[maidID].orgasmCount < 15)
            {
                if (maidsState[maidID].boostBase > 15) maidsState[maidID].boostBase = 15;
            }
            else
            {
                if (maidsState[maidID].boostBase > 50) maidsState[maidID].boostBase = 50;
            }
            maidsState[maidID].boostValue = maidsState[maidID].boostBase + maidsState[maidID].boostBonus;   //現在感度を計算
            maidsState[maidID].resistValue = maidsState[maidID].resistBase + maidsState[maidID].resistBonus + maidsState[maidID].exciteLevel * maidsState[maidID].exciteLevel - maidsState[maidID].boostValue; //現在抵抗値を計算


            //興奮加算値を計算
            float excitePlus = (excitePlusBase - maidsState[maidID].resistValue) * Mathf.Sqrt(maidsState[maidID].boostValue);
            if (excitePlus < -1)
            {
                excitePlus = -1;
            }
            else if (excitePlus > 10 && maidsState[maidID].orgasmCmb == 0)
            {
                excitePlus = 10;
            }
            else if (excitePlus > 20 && maidsState[maidID].orgasmCmb >= 1)
            {
                excitePlus = 20;
            }
            else if (excitePlus > 30 && maidsState[maidID].orgasmCmb >= 5)
            {
                excitePlus = 30;
            }


            //興奮値、勃起値、変動処理
            int randamValue;
            if (maidsState[maidID].vStateMajor == 10 || maidsState[maidID].vStateMajor == 40 || (!maidsState[maidID].giveSexual[0] && maidsState[maidID].exciteValue > (cfgw.vExciteLevelThresholdV1 + 10) * 60) && maidsState[maidID].itemV == "" && maidsState[maidID].itemA == "" && maidID != osawariID)
            { //　バイブ停止時　現在抵抗値に従って減少

                //興奮値を減算
                if (maidsState[maidID].exciteValue > 0 && !ExciteLock) maidsState[maidID].exciteValue -= 10 * maidsState[maidID].exciteLevel * timerRate;
                if (maidsState[maidID].exciteValue < 0) maidsState[maidID].exciteValue = 0;

                //絶頂値を減算
                if (maidsState[maidID].orgasmValue > 0 && !OrgasmLock)
                {
                    if (maidsState[maidID].stunFlag) maidsState[maidID].orgasmValue -= 0.04f * timerRate;
                    if (!maidsState[maidID].stunFlag) maidsState[maidID].orgasmValue -= 0.1f * timerRate;
                }

                //勃起値減算
                maidsState[maidID].bokkiValue1 -= 0.05f * timerRate;
                if (maidsState[maidID].bokkiValue1 < 0) maidsState[maidID].bokkiValue1 = 0f;

                //スタミナ回復
                //if(maidsState[maidID].stunFlag)maidsState[maidID].maidStamina +=  25 * Time.deltaTime;
                //if(!maidsState[maidID].stunFlag)maidsState[maidID].maidStamina +=  15 * Time.deltaTime;
                maidsState[maidID].maidStamina += (3500 - maidsState[maidID].maidStamina) * 0.008f * Time.deltaTime;
                if (maidsState[maidID].maidStamina > 3000) maidsState[maidID].maidStamina = 3000;


            }
            else if (maidsState[maidID].vStateMajor == 20)
            { //　バイブ弱時

                //興奮値を加算
                if (!ExciteLock) maidsState[maidID].exciteValue += excitePlus * timerRate;
                if (maidsState[maidID].exciteValue > 18000) maidsState[maidID].exciteValue = 18000;
                if (maidsState[maidID].exciteValue < 0) maidsState[maidID].exciteValue = 0;

                //感度加算判定　300分の1の確率で加算（現在興奮度により上昇値変動）
                randamValue = UnityEngine.Random.Range(0, (int)(300 / timerRate));
                if (randamValue < 1 && maidsState[maidID].exciteValue > 0)
                {
                    if (!ExciteLock && !OrgasmLock) maidsState[maidID].boostBase = maidsState[maidID].boostBase + 0.2f * maidsState[maidID].exciteLevel;

                    if (maid.body0.LastAnimeFN.Contains("cli")) maidsState[maidID].cliHidai += (maidsState[maidID].boostValue + maidsState[maidID].bokkiValue1) / (15000f * (maidsState[maidID].cliHidai / 2 + 1)); //クリ肥大値加算
                    if (maidsState[maidID].cliHidai > 100) maidsState[maidID].cliHidai = 100f;
                    //if(maid.body0.LastAnimeFN.Contains( "tikubi" ))maidsState[maidID].chikubiHidai += (Mathf.Sqrt(maidsState[maidID].boostValue) + Mathf.Sqrt(maidsState[maidID].orgasmValue)) / 2000f;
                }

                //絶頂値加算処理
                if (maidsState[maidID].exciteLevel > 1 && maidsState[maidID].orgasmValue > 30 && !OrgasmLock)
                {
                    if (maidsState[maidID].stunFlag) maidsState[maidID].orgasmValue -= 0.02f * timerRate;
                    if (!maidsState[maidID].stunFlag) maidsState[maidID].orgasmValue -= 0.05f * timerRate;
                    maidsState[maidID].jirashi += Mathf.Sqrt(maidsState[maidID].boostValue) * maidsState[maidID].orgasmValue * 0.001f * timerRate;
                }
                //勃起値加算
                maidsState[maidID].bokkiValue1 += 0.02f * timerRate;

                //スタミナ回復
                //if(maidsState[maidID].stunFlag)maidsState[maidID].maidStamina +=  10 * Time.deltaTime;
                //if(!maidsState[maidID].stunFlag)maidsState[maidID].maidStamina +=  6 * Time.deltaTime;
                maidsState[maidID].maidStamina += (3500 - maidsState[maidID].maidStamina) * 0.003f * Time.deltaTime;
                if (maidsState[maidID].maidStamina > 3000) maidsState[maidID].maidStamina = 3000;


            }
            else if (maidsState[maidID].vStateMajor == 30)
            { //　バイブ強時

                //興奮値を加算
                if (!ExciteLock) { maidsState[maidID].exciteValue += excitePlus * timerRate; }
                if (maidsState[maidID].exciteValue > 18000) { maidsState[maidID].exciteValue = 18000; }
                if (maidsState[maidID].exciteValue < 0) { maidsState[maidID].exciteValue = 0; }


                //感度加算判定　300分の1の確率で0.1加算
                randamValue = UnityEngine.Random.Range(0, (int)(300 / timerRate));
                if (randamValue < 1 && maidsState[maidID].exciteValue > 0)
                {
                    if (!ExciteLock && !OrgasmLock) maidsState[maidID].boostBase = maidsState[maidID].boostBase + 0.1f;

                    if (maid.body0.LastAnimeFN.Contains("cli")) maidsState[maidID].cliHidai += (maidsState[maidID].boostValue + maidsState[maidID].bokkiValue1) / (10000f * (maidsState[maidID].cliHidai / 2 + 1)); //クリ肥大値加算
                    if (maidsState[maidID].cliHidai > 100) maidsState[maidID].cliHidai = 100f;
                    //if(maid.body0.LastAnimeFN.Contains( "tikubi" ))maidsState[maidID].chikubiHidai += (Mathf.Sqrt(maidsState[maidID].boostValue) + Mathf.Sqrt(maidsState[maidID].orgasmValue)) / 1000f;
                    maidsState[maidID].sioVolume += maidsState[maidID].boostValue * maidsState[maidID].orgasmValue * 0.002f;
                    maidsState[maidID].nyoVolume += maidsState[maidID].boostValue * maidsState[maidID].orgasmValue * 0.002f;
                }


                //絶頂値加算処理
                if (maidsState[maidID].exciteLevel > 1 && !OrgasmLock && (maidsState[maidID].giveSexual[0] || maidsState[maidID].itemV != "" || maidsState[maidID].itemA != "" || maidID == osawariID))
                {
                    if (maidsState[maidID].stunFlag) maidsState[maidID].orgasmValue += Mathf.Sqrt(maidsState[maidID].boostValue) * 0.012f * timerRate;
                    if (!maidsState[maidID].stunFlag) maidsState[maidID].orgasmValue += Mathf.Sqrt(maidsState[maidID].boostValue) * 0.03f * timerRate;
                }
                //勃起値加算
                maidsState[maidID].bokkiValue1 += 0.03f * timerRate;

                //スタミナ減少
                maidsState[maidID].maidStamina -= (excitePlus + maidsState[maidID].resistBase) * 0.25f * Time.deltaTime;
                if (maidsState[maidID].maidStamina > 3000) maidsState[maidID].maidStamina = 3000;
                if (maidsState[maidID].maidStamina < 0) maidsState[maidID].maidStamina = 0;
            }

        }


        //絶頂スタートのチェック
        private bool OrgasmCheck(int maidID)
        {
            if (maidsState[maidID].vStateMajor != 30) return false;  //バイブ強じゃない場合は不可
            bool ov = false;
            foreach (int ID in vmId)
            {
                if (ID != maidID && !LinkMaidCheck(maidID, ID)) continue;
                if ((maidsState[ID].orgasmValue < 100 || maidsState[maidID].exciteLevel < 2) && (maidsState[ID].giveSexual[0] || maidsState[ID].itemV != "" || maidsState[ID].itemA != "")) return false;  //絶頂値と興奮値チェック
                                                                                                                                                                                                           //if((maidsState[maidID].orgasmVoice >= 2 || maidsState[maidID].vsFlag == 2) && cfgw.zViceWaitEnabled)return false;  //音声フラグチェック
                if (!stockMaids[maidID].mem.AudioMan.audiosource.loop && stockMaids[maidID].mem.AudioMan.audiosource.isPlaying && cfgw.zViceWaitEnabled) return false;  //音声フラグチェック

                if (maidsState[ID].orgasmValue >= 100) ov = true; //絶頂値100超えがいるかどうか
            }

            if (ov) return true;
            return false;
        }


        //絶頂時の処理
        private void OrgasmProcess(int maidID)
        {

            if (!maidsState[maidID].orgasmStart) return;
            maidsState[maidID].orgasmStart = false;
            /*if (maidsState[maidID].orgasmValue < 100 || (maidsState[maidID].exciteLevel < 2 && maidsState[maidID].giveSexual[0]) || maidsState[maidID].vStateMajor != 30 || ((maidsState[maidID].orgasmVoice >= 2 || maidsState[maidID].vsFlag == 2) && cfgw.zViceWaitEnabled) )return;
            if(tgID == maidID || maidsState[maidID].linkEnabled){  //リンクメイドがいる場合は、全員が条件を満たしていないと絶頂しない
              foreach(int ID in vmId){
                if(tgID != ID && !maidsState[ID].linkEnabled)continue;
                if(maidsState[ID].orgasmHoldTime > 590)continue;
                maidsState[ID].orgasmValue = 110;

                if((maidsState[ID].orgasmVoice == 2 || maidsState[ID].vsFlag == 2) && cfgw.zViceWaitEnabled){
                  maidsState[ID].motionHoldTime = 0;
                  maidsState[ID].orgasmVoice = 3;
                }
              }
            }*/

            Maid maid = stockMaids[maidID].mem;

            //絶頂時の音声処理
            maid.AudioMan.Stop();     //現在の音声停止
            maidsState[maidID].orgasmVoice = 1;         //絶頂時音声フラグON
            maidsState[maidID].voiceHoldTime = 0;       //音声・表情タイマーリセット（即再生のため）
            maidsState[maidID].faceHoldTime = 0;
            maidsState[maidID].motionHoldTime = 0;      //モーション用タイマーリセット（即再生のため）


            if (maidsState[maidID].giveSexual[0] || maidsState[maidID].itemV != "" || maidsState[maidID].itemA != "" || maidID == osawariID)
            {
                maidsState[maidID].orgasmCount += 1;  //絶頂カウント加算
                maidsState[maidID].orgasmCmb += 1;      //連続絶頂数加算
                maidsState[maidID].uDatsuStock += 1;   //子宮脱用
                maidsState[maidID].resistBonus = 0;    //抵抗加算値初期化
                if (!ExciteLock && !OrgasmLock) maidsState[maidID].boostBase += 1;  //感度加算

                //エロステータス加算
                maidsState[maidID].orgTotal += 1;
                if (maidsState[maidID].orgasmCmb > maidsState[maidID].orgMax) maidsState[maidID].orgMax = maidsState[maidID].orgasmCmb;

                //スタミナ減少
                maidsState[maidID].maidStamina -= maidsState[maidID].boostValue;
                if (maidsState[maidID].maidStamina < 0) maidsState[maidID].maidStamina = 0;

                maidsState[maidID].orgasmValue = 0f;  //絶頂値リセット
                maidsState[maidID].orgasmHoldTime = 600;   //絶頂後のボーナスタイム設定

                //潮吹きとおしっこ
                float sr = UnityEngine.Random.Range(0f, maidsState[maidID].sioVolume);
                if (sr >= 30f)
                {
                    maidsState[maidID].fSio = true;
                    maidsState[maidID].sioTime = sr * 10f;
                    maidsState[maidID].sioVolume -= sr;
                }
                float nr = UnityEngine.Random.Range(0f, maidsState[maidID].nyoVolume);
                if ((!maidsState[maidID].stunFlag && nr >= 120f) || (maidsState[maidID].stunFlag && nr >= 50f))
                {
                    EffectNyo(maidID, nr);
                }
            }

            //興奮値を削減
            if (!ExciteLock)
            {
                if (maidsState[maidID].orgasmCmb > 3)
                {
                    maidsState[maidID].exciteValue = maidsState[maidID].exciteValue * 0.8f;
                }
                else
                {
                    maidsState[maidID].exciteValue = maidsState[maidID].exciteValue * 0.5f;
                }
            }


            //連続絶頂の場合マウスモードをランダム変更
            if (maidsState[maidID].orgasmCmb > 3)
            {
                maidsState[maidID].MouthMode = UnityEngine.Random.Range(2, 5);
                if (maidsState[maidID].MouthMode < 3) maidsState[maidID].MouthMode = 0;
            }

            //アヘ値の変更
            maidsState[maidID].aheValue2 = maidsState[maidID].orgasmCmb * 10;
            if (maidsState[maidID].aheValue2 > 60) maidsState[maidID].aheValue2 = UnityEngine.Random.Range(0, 60);


            //オートモード時、絶頂後すぐにモーションが変わらないように時間追加
            if (maidsState[maidID].pAutoSelect != 0 && maidsState[maidID].pAutoTime < 200f) maidsState[maidID].pAutoTime += 200f;
            if (maidsState[maidID].eAutoSelect == true && maidsState[maidID].eAutoTime < 200f) maidsState[maidID].eAutoTime += 200f;
            if (maidsState[maidID].editMotionSetName != "")
            {
                if (maidsState[maidID].msTime1 < 300f) maidsState[maidID].msTime1 += 300f;
                if (maidsState[maidID].msTime2 < 300f) maidsState[maidID].msTime2 += 300f;
            }

            //エロステータス更新
            SaveEroState(maidID);

        }


        //絶頂ボーナスタイムの処理
        private void OrgasmBonus(int maidID)
        {
            if (maidsState[maidID].orgasmHoldTime > 0)
            {
                maidsState[maidID].boostBonus = maidsState[maidID].jirashi / 20 + 3 * maidsState[maidID].orgasmCmb;  //感度ボーナス設定
                                                                                                                     //if(maidsState[maidID].boostBonus > 200)maidsState[maidID].boostBonus = 200;

            }
            else if (maidsState[maidID].orgasmCmb > 0)
            { //ボーナスタイム終了時の処理
                maidsState[maidID].jirashi = 0;
                maidsState[maidID].boostBonus = 0;
                maidsState[maidID].orgasmCmb = 0;
                maidsState[maidID].orgasmValue = maidsState[maidID].orgasmValue / 3;

            }
        }


        //メイドの放心判定
        private void StunCheck(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            //放心状態にする
            if (!maidsState[maidID].stunFlag && maidsState[maidID].maidStamina < 500)
            {
                maidsState[maidID].stunFlag = true;
                maidsState[maidID].orgasmValue = 0;  //絶頂値リセット
                maid.EyeToCamera((Maid.EyeMoveType)0, 0.8f);  //メイドの視線を外す
                maidsState[maidID].stanTotal += 1; //失神回数
                                                   //エロステータス更新
                SaveEroState(maidID);

                maid.SetProp("eye_hi", "_I_SkinHi002.menu", 0, true, false); //ハイライトを消す
                maid.SetProp("eye_hi_r", "_I_SkinHi002.menu", 0, true, false);
                maid.AllProcPropSeqStart();
            }

            //放心から回復する
            if (maidsState[maidID].stunFlag && maidsState[maidID].maidStamina > 1500)
            {
                maidsState[maidID].stunFlag = false;
                maidsState[maidID].voiceHoldTime = 0;  //音声・表情タイマーリセット（即再生のため）
                maidsState[maidID].faceHoldTime = 0;
                maidsState[maidID].vStateMajorOld = 30;  //バイブが停止していた場合に余韻状態に移行させるため

                maid.ResetProp("eye_hi", false);//ハイライトを戻す
                maid.ResetProp("eye_hi_r", false);
                maid.AllProcPropSeqStart();
            }
        }


        //フェイスブレンド等のレベルチェック
        private int kaikanLevelCheck(int maidID)
        {

            //クリ勃起値、スタミナ、連続絶頂数によってフェイスブレンドレベルを変更
            int kaikanLevel = 0;
            if (maidsState[maidID].bokkiValue1 > 90)
            {
                kaikanLevel = 5;
            }
            else if (maidsState[maidID].bokkiValue1 > 70)
            {
                kaikanLevel = 4;
            }
            else if (maidsState[maidID].bokkiValue1 > 50)
            {
                kaikanLevel = 3;
            }
            else if (maidsState[maidID].bokkiValue1 > 30)
            {
                kaikanLevel = 2;
            }
            else
            {
                kaikanLevel = 1;
            }
            if (maidsState[maidID].maidStamina < 1500)
            {
                kaikanLevel += 5;
            }
            else if (maidsState[maidID].maidStamina < 1800)
            {
                kaikanLevel += 4;
            }
            else if (maidsState[maidID].maidStamina < 2100)
            {
                kaikanLevel += 3;
            }
            else if (maidsState[maidID].maidStamina < 2400)
            {
                kaikanLevel += 2;
            }
            else if (maidsState[maidID].maidStamina < 2700)
            {
                kaikanLevel += 1;
            }
            kaikanLevel += maidsState[maidID].orgasmCmb;
            if (maidsState[maidID].stunFlag) kaikanLevel += 2;

            return kaikanLevel;
        }


        //ステータス変更関係終了---------------------------





        //-------------------------------------------------
        //表情変更関係-------------------------------------

        //フェイスアニメ変更処理
        private void ChangeFaceAnime(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;
            int iRandomFace = 0;
            string faceAnimeName = "";

            //「バイブ停止」から遷移してくる時には、その時点での表情をバックアップしておく
            if (maidsState[maidID].vStateMajor != 10 && maidsState[maidID].vStateMajorOld == 10) maidsState[maidID].faceAnimeBackup = maid.ActiveFace;

            //変更するフェイスアニメを決定
            if (maidsState[maidID].stunFlag)
            {
                iRandomFace = UnityEngine.Random.Range(0, cfgw.sFaceAnimeStun.Length);
                faceAnimeName = cfgw.sFaceAnimeStun[iRandomFace];

            }
            else if (maidsState[maidID].vStateMajor == 20)
            {
                iRandomFace = UnityEngine.Random.Range(0, cfgw.sFaceAnime20Vibe[maidsState[maidID].exciteLevel - 1].Length);
                faceAnimeName = cfgw.sFaceAnime20Vibe[maidsState[maidID].exciteLevel - 1][iRandomFace];

            }
            else if (maidsState[maidID].vStateMajor == 40)
            {
                if (maidsState[maidID].orgasmCmb > 0)
                {
                    faceAnimeName = cfgw.sFaceAnime40Vibe[3];
                }
                else
                {
                    faceAnimeName = cfgw.sFaceAnime40Vibe[maidsState[maidID].exciteLevel - 1];
                }

            }
            else if (maidsState[maidID].vStateMajor == 30)
            {
                iRandomFace = UnityEngine.Random.Range(0, cfgw.sFaceAnime30Vibe[maidsState[maidID].exciteLevel - 1].Length);
                faceAnimeName = cfgw.sFaceAnime30Vibe[maidsState[maidID].exciteLevel - 1][iRandomFace];

            }
            else if (maidsState[maidID].vStateMajor == 10 && maidsState[maidID].vStateMajorOld == 50)
            {
                faceAnimeName = maidsState[maidID].faceAnimeBackup;
                maidsState[maidID].faceAnimeBackup = "";

            }

            //""か"変更しない"でなければ、フェイスアニメを適用する
            if (faceAnimeName != "" && faceAnimeName != "変更しない") maid.FaceAnime(faceAnimeName, cfgw.fAnimeFadeTimeV, 0);

        }



        //フェイスブレンド変更処理
        private void ChangeFaceBlend(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            //「バイブ停止」から遷移してくる時には、その時点でのブレンドをバックアップしておく
            if (maidsState[maidID].vStateMajor != 10 && maidsState[maidID].vStateMajorOld == 10) maidsState[maidID].faceBlendBackup = maid.FaceName3;

            string faceBlendCurrent = maidsState[maidID].faceBlendBackup;
            string sChangeCheek = "";
            string sChangeTears = "";
            int iChangeCheek = 0;
            int iChangeTears = 0;
            string sChangeYodare = "";
            string sChangeBlend = "";

            int iOverrideCheek = 0;
            int iOverrideTears = 0;
            bool bOverrideYodare = false;
            bool bOverrideSekimen = false;


            if (maidsState[maidID].kaikanLevel > 9)
            {
                iOverrideCheek = 3;       //"頬３"
                iOverrideTears = 3;       //"涙３"
                bOverrideYodare = true;   //よだれ
                bOverrideSekimen = true;  //赤面
            }
            else if (maidsState[maidID].kaikanLevel > 6)
            {
                iOverrideCheek = 3;       //"頬３"
                iOverrideTears = 3;       //"涙３"
                bOverrideYodare = true;   //よだれ
            }
            else if (maidsState[maidID].kaikanLevel > 5)
            {
                iOverrideCheek = 3;       //"頬３"
                iOverrideTears = 3;       //"涙３"
            }
            else if (maidsState[maidID].kaikanLevel > 4)
            {
                iOverrideCheek = 3;       //"頬３"
                iOverrideTears = 2;       //"涙２"
            }
            else if (maidsState[maidID].kaikanLevel > 3)
            {
                iOverrideCheek = 3;       //"頬３"
                iOverrideTears = 1;       //"涙１"
            }
            else if (maidsState[maidID].kaikanLevel > 2)
            {
                iOverrideCheek = 2;       //"頬２"
                iOverrideTears = 1;       //"涙１"
            }
            else if (maidsState[maidID].kaikanLevel > 1)
            {
                iOverrideCheek = 2;       //"頬１"
                iOverrideTears = 0;       //"涙１"
            }
            else
            {
                iOverrideCheek = 1;       //"頬１"
                iOverrideTears = 0;       //"涙０"
            }



            faceBlendCurrent = faceBlendCurrent.Replace("オリジナル", ""); //取得したフェイスブレンド情報から「オリジナル」の記述を削除
            if (faceBlendCurrent == "") faceBlendCurrent = "頬０涙０";  // 背景選択時、スキル選択時は、"" が返ってきてエラーが出るため

            sChangeCheek = faceBlendCurrent.Substring(0, 2);
            sChangeTears = faceBlendCurrent.Substring(2, 2);
            if (faceBlendCurrent.Length == 7) sChangeYodare = "よだれ";

            //元々のフェイスブレンドと比較する
            if (cfgw.HohoEnabled)
            {
                if (sChangeCheek == "頬０") iChangeCheek = 0;
                if (sChangeCheek == "頬１") iChangeCheek = 1;
                if (sChangeCheek == "頬２") iChangeCheek = 2;
                if (sChangeCheek == "頬３") iChangeCheek = 3;
                if (iOverrideCheek > iChangeCheek) iChangeCheek = iOverrideCheek;
                if (iChangeCheek == 0) sChangeCheek = "頬０";
                if (iChangeCheek == 1) sChangeCheek = "頬１";
                if (iChangeCheek == 2) sChangeCheek = "頬２";
                if (iChangeCheek == 3) sChangeCheek = "頬３";
            }
            if (cfgw.NamidaEnabled)
            {
                if (sChangeTears == "涙０") iChangeTears = 0;
                if (sChangeTears == "涙１") iChangeTears = 1;
                if (sChangeTears == "涙２") iChangeTears = 2;
                if (sChangeTears == "涙３") iChangeTears = 3;
                if (iOverrideTears > iChangeTears) iChangeTears = iOverrideTears;
                if (iChangeTears == 0) sChangeTears = "涙０";
                if (iChangeTears == 1) sChangeTears = "涙１";
                if (iChangeTears == 2) sChangeTears = "涙２";
                if (iChangeTears == 3) sChangeTears = "涙３";
            }
            if (cfgw.YodareEnabled && bOverrideYodare) sChangeYodare = "よだれ";


            //フェイスブレンドを適用
            sChangeBlend = sChangeCheek + sChangeTears + sChangeYodare;
            maid.FaceBlend(sChangeBlend);

            //赤面処理
            if (cfgw.HohoEnabled && bOverrideSekimen)
            {
                maidsState[maidID].sekimenValue = 1f;
            }
            else
            {
                maidsState[maidID].sekimenValue = 0f;
            }

        }


        //表情変更関係終了---------------------------------





        //-------------------------------------------------
        //サウンド処理関係---------------------------------

        //メイドの音声再生処理
        private void MaidVoicePlay(int maidID)
        {

            //フェラしているかのチェック
            checkBlowjobing(maidID);

            if (maidsState[maidID].autoVoiceEnabled)
            {
                if (maidsState[maidID].bIsBlowjobing > 0)
                {
                    maidsState[maidID].voiceMode = 1;
                }
                else
                {
                    maidsState[maidID].voiceMode = 0;
                }
            }

            Maid maid = stockMaids[maidID].mem;
            int iPersonal = Array.IndexOf(personalList[1], stockMaids[maidID].personal);
            if (iPersonal < 0) iPersonal = 0;
            if (maidsState[maidID].voiceMode2 > 0) iPersonal = maidsState[maidID].voiceMode2 - 1;
            string[] VoiceList = new string[1];
            int vi = 0;

            Console.WriteLine(stockMaids[maidID].personal);

            //バイブ弱の音声
            if (maidsState[maidID].vStateMajor == 20)
            {
                if (maidsState[maidID].stunFlag)
                {
                    vi = 4;
                }
                else
                {
                    vi = maidsState[maidID].exciteLevel - 1;
                }

                if (maidsState[maidID].voiceMode == 0)
                { //通常音声
                    VoiceList = bvs[iPersonal].sLoopVoice20Vibe[vi];

                }
                else if (maidsState[maidID].voiceMode == 1)
                { //フェラ音声
                    VoiceList = bvs[iPersonal].sLoopVoice20Fera[vi];

                }
                else if (maidsState[maidID].voiceMode == 2)
                { //カスタム音声１
                    VoiceList = sLoopVoice20Custom1[vi];
                }
                else if (maidsState[maidID].voiceMode == 3)
                { //カスタム音声２
                    VoiceList = sLoopVoice20Custom2[vi];
                }
                else if (maidsState[maidID].voiceMode == 4)
                { //カスタム音声３
                    VoiceList = sLoopVoice20Custom3[vi];
                }
                else if (maidsState[maidID].voiceMode == 5)
                { //カスタム音声４
                    VoiceList = sLoopVoice20Custom4[vi];
                }
            }

            //バイブ強の音声
            if (maidsState[maidID].vStateMajor == 30)
            {
                if (maidsState[maidID].orgasmVoice == 0)
                {

                    if (maidsState[maidID].stunFlag)
                    {
                        vi = 4;
                    }
                    else
                    {
                        vi = maidsState[maidID].exciteLevel - 1;
                    }

                    if (maidsState[maidID].voiceMode == 0)
                    { //通常音声
                        VoiceList = bvs[iPersonal].sLoopVoice30Vibe[vi];

                    }
                    else if (maidsState[maidID].voiceMode == 1)
                    { //フェラ音声
                        VoiceList = bvs[iPersonal].sLoopVoice30Fera[vi];

                    }
                    else if (maidsState[maidID].voiceMode == 2)
                    { //カスタム音声１
                        VoiceList = sLoopVoice30Custom1[vi];
                    }
                    else if (maidsState[maidID].voiceMode == 3)
                    { //カスタム音声２
                        VoiceList = sLoopVoice30Custom2[vi];
                    }
                    else if (maidsState[maidID].voiceMode == 4)
                    { //カスタム音声３
                        VoiceList = sLoopVoice30Custom3[vi];
                    }
                    else if (maidsState[maidID].voiceMode == 5)
                    { //カスタム音声４
                        VoiceList = sLoopVoice30Custom4[vi];
                    }

                }
                else
                {  //絶頂時音声

                    if (maidsState[maidID].stunFlag)
                    {
                        vi = 4;
                    }
                    else if (maidsState[maidID].orgasmCmb < 4)
                    {
                        vi = maidsState[maidID].exciteLevel - 2;
                        if (vi < 0) vi = 0;
                    }
                    else
                    {
                        vi = 3;
                    }

                    if (maidsState[maidID].voiceMode == 0)
                    { //通常音声
                        VoiceList = bvs[iPersonal].sOrgasmVoice30Vibe[vi];

                    }
                    else if (maidsState[maidID].voiceMode == 1)
                    { //フェラ音声
                        VoiceList = bvs[iPersonal].sOrgasmVoice30Fera[vi];

                    }
                    else if (maidsState[maidID].voiceMode == 2)
                    { //カスタム音声１
                        VoiceList = sOrgasmVoice30Custom1[vi];
                    }
                    else if (maidsState[maidID].voiceMode == 3)
                    { //カスタム音声２
                        VoiceList = sOrgasmVoice30Custom2[vi];
                    }
                    else if (maidsState[maidID].voiceMode == 4)
                    { //カスタム音声３
                        VoiceList = sOrgasmVoice30Custom3[vi];
                    }
                    else if (maidsState[maidID].voiceMode == 5)
                    { //カスタム音声４
                        VoiceList = sOrgasmVoice30Custom4[vi];
                    }
                }
            }


            int iRandomVoice = UnityEngine.Random.Range(0, VoiceList.Length);

            //絶頂音声が重複しないようにする
            if (maidsState[maidID].orgasmVoice != 0)
            {
                while (iRandomVoice == maidsState[maidID].iRandomVoiceBackup && VoiceList.Length > 1)
                {
                    iRandomVoice = UnityEngine.Random.Range(0, VoiceList.Length);
                }
                maidsState[maidID].iRandomVoiceBackup = iRandomVoice;
            }


            //バイブ動作時の音声を実際に再生する
            if (maidsState[maidID].vStateMajor == 30 || maidsState[maidID].vStateMajor == 20)
            {
                if (maidsState[maidID].orgasmVoice == 0)
                {
                    maid.AudioMan.LoadPlay(VoiceList[iRandomVoice], 0f, false, true);
                }
                else
                {
                    maid.AudioMan.LoadPlay(VoiceList[iRandomVoice], 0f, false, false);
                    maidsState[maidID].orgasmVoice = 2;   //絶頂音声再生中のフラグ
                }
            }


            //バイブ停止時の音声
            if (maidsState[maidID].vStateMajor == 40)
            {
                int VoiceValue;

                if (maidsState[maidID].stunFlag)
                {
                    vi = 1;
                }
                else
                {
                    vi = 0;
                }

                if (maidsState[maidID].orgasmCmb > 0)
                {
                    VoiceValue = 3 + vi;
                }
                else
                {
                    VoiceValue = maidsState[maidID].exciteLevel - 1 + vi;
                }

                if (maidsState[maidID].voiceMode == 2)
                {
                    maid.AudioMan.LoadPlay(sLoopVoice40Custom1[VoiceValue], 0f, false, true);
                }
                else if (maidsState[maidID].voiceMode == 3)
                {
                    maid.AudioMan.LoadPlay(sLoopVoice40Custom2[VoiceValue], 0f, false, true);
                }
                else if (maidsState[maidID].voiceMode == 4)
                {
                    maid.AudioMan.LoadPlay(sLoopVoice40Custom3[VoiceValue], 0f, false, true);
                }
                else if (maidsState[maidID].voiceMode == 5)
                {
                    maid.AudioMan.LoadPlay(sLoopVoice40Custom4[VoiceValue], 0f, false, true);
                }
                else
                {
                    maid.AudioMan.LoadPlay(bvs[iPersonal].sLoopVoice40Vibe[VoiceValue], 0f, false, true);
                }
            }


            //余韻終了時
            if (maidsState[maidID].vStateMajor == 10 && maidsState[maidID].vStateMajorOld == 50)
            {
                maid.AudioMan.Stop(1.5f);
            }

        }

        //リアクション音声・表情の再生
        private void ReactionPlay(int maidID)
        {
            Maid maid = stockMaids[maidID].mem;
            int iPersonal = Array.IndexOf(personalList[1], stockMaids[maidID].personal);
            if (maidsState[maidID].voiceMode2 > 0) iPersonal = maidsState[maidID].voiceMode2 - 1;
            string[] VoiceList = reactionVoice[iPersonal];
            int iRandom = UnityEngine.Random.Range(0, VoiceList.Length);

            maid.AudioMan.LoadPlay(VoiceList[iRandom], 0f, false, false);
            //maidsState[maidID].vsFlag = 2;
            maidsState[maidID].orgasmVoice = 2;

            iRandom = UnityEngine.Random.Range(0, cfgw.sFaceAnime30Vibe[3].Length);
            maid.FaceAnime(cfgw.sFaceAnime30Vibe[3][iRandom], 0.5f, 0);
            maidsState[maidID].faceHoldTime = cfgw.vStateAltTimeVBase + UnityEngine.Random.Range(0f, cfgw.vStateAltTimeVRandomExtend); //次の表情変更タイマーセット
        }




        //SE変更処理
        private string seFileBack = "";
        private void ChangeSE(int maidID, bool mode)
        {

            int iSE1 = maidsState[maidID].vLevel;
            int iSE2 = maidsState[maidID].vLevel;
            if (maidID == osawariID && iSE1 < osawariLevel) iSE1 = osawariLevel;

            if (iSE1 != 0)
            {
                bool vibe = false;
                string motion = stockMaids[maidID].mem.body0.LastAnimeFN;
                string seFile = "";

                if (cfgw.SelectSE != 2)
                {
                    seFile = SeFileList[iSE1][cfgw.SelectSE];
                }
                else
                {
                    seFile = SeFileList[iSE1][1];
                    if (maidsState[maidID].itemV != "" || maidsState[maidID].itemA != "") vibe = true;
                }

                if (seFile != seFileBack || mode)
                {
                    GameMain.Instance.SoundMgr.StopSe();
                    GameMain.Instance.SoundMgr.PlaySe(seFile, true);
                    if (vibe && iSE2 > 0) GameMain.Instance.SoundMgr.PlaySe(SeFileList[iSE2][0], true);
                    seFileBack = seFile;
                }

            }
        }



        //サウンド処理関係了-------------------------------





        //-------------------------------------------------
        //モーションファイルの読み込み関係-----------------

        //チェック用モーションリスト変数
        private List<string> MotionList_tati = new List<string>();
        private List<string> MotionList_suwari = new List<string>();
        private List<string> MotionList_zoukin = new List<string>();
        private List<string> MotionList_kyuuzi = new List<string>();
        private List<string> MotionList_fukisouji = new List<string>();
        private List<string> MotionList_mop = new List<string>();
        private List<string> MotionList_vibe = new List<string>();

        private List<string> allFiles = new List<string>();
        private List<string> allFilesOld = new List<string>();

        private List<List<string>> YotogiList = new List<List<string>>();
        private List<List<string>> YotogiListName = new List<List<string>>();
        private List<string> YotogiListBase = new List<string>();
        private List<List<string>> YotogiListSabun = new List<List<string>>();
        private List<string> YotogiGroup = new List<string>();
        private int YotogiMenu = 0;


        //UNZIP用のモーションリスト作成
        void UnzipMotionLoad()
        {
            Console.WriteLine("モーションファイル読み込み開始");

            //全ファイルの中から.anmファイルの抜き出す
            string[] Files = GameUty.FileSystem.GetList("motion", AFileSystemBase.ListType.AllFile);
            string[] FilesOld = GameUty.FileSystemOld.GetList("motion", AFileSystemBase.ListType.AllFile);

            string[] FilesMod = GameUty.FileSystemMod.GetList("", AFileSystemBase.ListType.AllFile);

            foreach (string file in Files)
            {
                if (Path.GetExtension(file) == ".anm") allFiles.Add(Path.GetFileNameWithoutExtension(file));
            }
            foreach (string file in FilesOld)
            {
                if (Path.GetExtension(file) == ".anm") allFilesOld.Add(Path.GetFileNameWithoutExtension(file));
            }
            foreach (string file in FilesMod)
            {
                if (Path.GetExtension(file) == ".anm") allFiles.Add(Path.GetFileNameWithoutExtension(file));
            }
            //ファイル名でソート
            allFiles.Sort();
            allFilesOld.Sort();

            /*
            モーションファイル一覧を出力したいときに使うだけ
            foreach (string file in allFiles){
              File.AppendAllText(@"F:\game\オダメ解凍ファイル\モーションリスト.csv", file + Environment.NewLine);
            }
            foreach (string file in allFilesOld){
              File.AppendAllText(@"F:\game\オダメ解凍ファイル\モーションリスト.csv", file + Environment.NewLine);
            }*/

            Console.WriteLine("モーションファイル読み込み終了");


            //読み込んだモーションファイルの中からモーション変更可能なものを抽出
            Console.WriteLine("夜伽リスト抽出開始");
            string m2 = "";
            string m3 = "";
            string hatu = "";

            List<string> ListF = new List<string>();
            List<string> ListF2 = new List<string>();
            List<string> ListN = new List<string>();

            List<string> YotogiList0 = new List<string>();
            List<string> YotogiList1 = new List<string>();
            List<string> YotogiList2 = new List<string>();
            List<string> YotogiList3 = new List<string>();
            List<string> YotogiList4 = new List<string>();
            List<string> YotogiList5 = new List<string>();
            List<string> YotogiList6 = new List<string>();
            List<string> YotogiList7 = new List<string>();
            List<string> YotogiList8 = new List<string>();
            List<string> YotogiList9 = new List<string>();
            List<string> YotogiList10 = new List<string>();
            List<string> YotogiList11 = new List<string>();
            List<string> YotogiList12 = new List<string>();

            List<string> YotogiListName0 = new List<string>();
            List<string> YotogiListName1 = new List<string>();
            List<string> YotogiListName2 = new List<string>();
            List<string> YotogiListName3 = new List<string>();
            List<string> YotogiListName4 = new List<string>();
            List<string> YotogiListName5 = new List<string>();
            List<string> YotogiListName6 = new List<string>();
            List<string> YotogiListName7 = new List<string>();
            List<string> YotogiListName8 = new List<string>();
            List<string> YotogiListName9 = new List<string>();
            List<string> YotogiListName10 = new List<string>();
            List<string> YotogiListName11 = new List<string>();
            List<string> YotogiListName12 = new List<string>();

            List<string> _YotogiListSabun = new List<string>();


            foreach (string file in allFiles)
            {

                if (Regex.IsMatch(file, "_[1234]") && ((Regex.IsMatch(file, @"^[a-zA-Z]_") && !Regex.IsMatch(file, "m_")) || Regex.IsMatch(file, @"[a-zA-Z][0-9][0-9]")) && (file.EndsWith("_f") || file.EndsWith("_f2") || file.EndsWith("_f3")))
                {

                    string basefile = file + ".anm";
                    if (!Regex.IsMatch(basefile, "m_")) basefile = Regex.Replace(basefile, @"^[a-zA-Z]_", "");
                    basefile = Regex.Replace(basefile, @"[a-zA-Z][0-9][0-9]", "");

                    int i = YotogiListBase.IndexOf(basefile);
                    if (i < 0)
                    {
                        YotogiListBase.Add(basefile);
                        _YotogiListSabun.Add(basefile);
                        _YotogiListSabun.Add(file + ".anm");
                    }
                    else
                    {
                        _YotogiListSabun.Add(file + ".anm");
                    }
                }

                if (file.Contains("_1") && (!Regex.IsMatch(file, @"^[a-zA-Z]_") || Regex.IsMatch(file, "x_manguri") || Regex.IsMatch(file, "m_")) && !Regex.IsMatch(file, @"[a-zA-Z][0-9][0-9]") && (file.EndsWith("_f") || file.EndsWith("_f2") || file.EndsWith("_f3")))
                {
                    m2 = file.Replace("_1", "_2");
                    m3 = file.Replace("_1", "_3");
                    hatu = file.Replace("_1", "_hatu_3");

                    if (allFiles.Contains(m2) && allFiles.Contains(m3) && !ListF.Contains(file))
                    {

                        string name = MotionNameChange(file);

                        if (allFiles.Contains(hatu) || allFilesOld.Contains(hatu)) name = name + " [H]";
                        int mid = maj.motionName.IndexOf(file);
                        if (mid == -1 || maj.hkupa1[mid] == -1) name = "★" + name;

                        ListF.Add(file);
                        ListN.Add(name);

                    }
                }
            }

            foreach (string file in allFilesOld)
            {

                if (Regex.IsMatch(file, "_[1234]") && ((Regex.IsMatch(file, @"^[a-zA-Z]_") && !Regex.IsMatch(file, "m_")) || Regex.IsMatch(file, @"[a-zA-Z][0-9][0-9]")) && (file.EndsWith("_f") || file.EndsWith("_f2") || file.EndsWith("_f3")))
                {

                    string basefile = file + ".anm";
                    if (!Regex.IsMatch(basefile, "m_")) basefile = Regex.Replace(basefile, @"^[a-zA-Z]_", "");
                    basefile = Regex.Replace(basefile, @"[a-zA-Z][0-9][0-9]", "");

                    int i = YotogiListBase.IndexOf(basefile);
                    if (i < 0)
                    {
                        YotogiListBase.Add(basefile);
                        _YotogiListSabun.Add(basefile);
                        _YotogiListSabun.Add(file + ".anm");
                    }
                    else
                    {
                        _YotogiListSabun.Add(file + ".anm");
                    }
                }

                if (file.Contains("_1") && (!Regex.IsMatch(file, @"^[a-zA-Z]_") || Regex.IsMatch(file, "x_manguri") || Regex.IsMatch(file, "m_")) && !Regex.IsMatch(file, @"[a-zA-Z][0-9][0-9]") && (file.EndsWith("_f") || file.EndsWith("_f2") || file.EndsWith("_f3")))
                {
                    m2 = file.Replace("_1", "_2");
                    m3 = file.Replace("_1", "_3");
                    hatu = file.Replace("_1", "_hatu_3");

                    if (allFilesOld.Contains(m2) && allFilesOld.Contains(m3) && !ListF.Contains(file))
                    {

                        string name = MotionNameChange(file);

                        int mid = maj.motionName.IndexOf(file);
                        if (mid == -1 || maj.hkupa1[mid] == -1) name = "★" + name;

                        ListF.Add(file);
                        ListN.Add(name);

                    }
                }
            }


            List<string> ListN2 = new List<string>(ListN);
            ListN2.Sort();
            for (int i = 0; i < ListN2.Count; i++)
            {
                int n = ListN.IndexOf(ListN2[i]);
                string file = ListF[n];

                if (file.Contains("ganmenkijyoui"))
                {//１１：その他
                    YotogiList11.Add(file);
                    YotogiListName11.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("yuri"))
                {//８：百合
                    YotogiList8.Add(file);
                    YotogiListName8.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("harem") || file.Contains("wfera"))
                {//９：ハーレム
                    YotogiList9.Add(file);
                    YotogiListName9.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("ran") || file.Contains("3p_") || file.Contains("6p_"))
                {//１０：乱交
                    YotogiList10.Add(file);
                    YotogiListName10.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("kousoku") || file.Contains("mokuba") || file.Contains("harituke") || file.Contains("turusi"))
                {//７：ＳＭ
                    YotogiList7.Add(file);
                    YotogiListName7.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("fera") || file.Contains("paizuri") || file.Contains("tekoki") || file.Contains("arai") || file.Contains("asiname"))
                {//６：奉仕
                    YotogiList6.Add(file);
                    YotogiListName6.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("onani"))
                {//５：オナニー
                    YotogiList5.Add(file);
                    YotogiListName5.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("daijyou") || file.Contains("kyousitu") || file.Contains("atama") || file.Contains("table"))
                {//４：台上
                    YotogiList4.Add(file);
                    YotogiListName4.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("ritui") || file.Contains("tati") || file.Contains("hekimen") || file.Contains("tikan") || file.Contains("ekiben") || file.Contains("poseizi"))
                {//３：立ち・壁面
                    YotogiList3.Add(file);
                    YotogiListName3.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("aibu") || file.Contains("vibe") || file.Contains("kunni"))
                {//０：愛撫
                    YotogiList0.Add(file);
                    YotogiListName0.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("haimen") || file.Contains("kouhaii") || file.Contains("sokui") || file.Contains("sukebeisu_sex") || file.Contains("kakaemzi"))
                {//２：挿入 後
                    YotogiList2.Add(file);
                    YotogiListName2.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else if (file.Contains("sex") || file.Contains("manguri") || file.Contains("seijyoui") || file.Contains("kijyoui") || file.Contains("taimenzai") || file.Contains("matuba") || file.Contains("kakaekomizai"))
                {//１：挿入 前
                    YotogiList1.Add(file);
                    YotogiListName1.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }
                else
                {//１１：その他
                    YotogiList11.Add(file);
                    YotogiListName11.Add(ListN2[i]);
                    //Console.WriteLine(file);

                }

                if (ListN2[i].Contains("[H]"))
                {//１２：発情有り
                    YotogiList12.Add(file);
                    YotogiListName12.Add(ListN2[i]);
                }

                //モーションアジャスト用の初期値設定
                if (!maj.motionName.Contains(file))
                {
                    maj.motionName.Add(file);
                    maj.baceMotion.Add("");
                    maj.basicHeight.Add(0f);
                    maj.basicRoll.Add(0f);
                    maj.basicForward.Add(0f);
                    maj.mansHeight.Add(0f);
                    maj.mansForward.Add(0f);
                    maj.mansRight.Add(0f);
                    maj.hkupa1.Add(-1f);
                    maj.akupa1.Add(-1f);
                    maj.hkupa2.Add(-1f);
                    maj.akupa2.Add(-1f);
                    maj.mVoiceSet.Add("");
                    maj.iTargetLH.Add(0);
                    maj.iTargetRH.Add(0);

                    int[] ni = new int[] { 0, 0, 0, 0, 0 };
                    maj.syaseiMarks.Add(ni);

                    maj.giveSexual.Add(GiveSexualSet(file));

                    bool[] nb = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                    maj.itemSet.Add(nb);
                    maj.prefabSet.Add(0);
                    maj.maidRoll.Add(0);
                    maj.manRoll.Add(0);
                    maj.rollSettei.Add(0);
                    maj.analEnabled.Add(false);
                    maj.analHeight.Add(0f);
                    maj.analForward.Add(0f);
                    maj.analRight.Add(0f);
                }
            }


            YotogiList.Add(YotogiList0);
            YotogiList.Add(YotogiList1);
            YotogiList.Add(YotogiList2);
            YotogiList.Add(YotogiList3);
            YotogiList.Add(YotogiList4);
            YotogiList.Add(YotogiList5);
            YotogiList.Add(YotogiList6);
            YotogiList.Add(YotogiList7);
            YotogiList.Add(YotogiList8);
            YotogiList.Add(YotogiList9);
            YotogiList.Add(YotogiList10);
            YotogiList.Add(YotogiList11);
            YotogiList.Add(YotogiList12);

            YotogiListName.Add(YotogiListName0);
            YotogiListName.Add(YotogiListName1);
            YotogiListName.Add(YotogiListName2);
            YotogiListName.Add(YotogiListName3);
            YotogiListName.Add(YotogiListName4);
            YotogiListName.Add(YotogiListName5);
            YotogiListName.Add(YotogiListName6);
            YotogiListName.Add(YotogiListName7);
            YotogiListName.Add(YotogiListName8);
            YotogiListName.Add(YotogiListName9);
            YotogiListName.Add(YotogiListName10);
            YotogiListName.Add(YotogiListName11);
            YotogiListName.Add(YotogiListName12);

            YotogiGroup.Add("愛撫");
            YotogiGroup.Add("挿入 前");
            YotogiGroup.Add("挿入 後");
            YotogiGroup.Add("立ち/壁面");
            YotogiGroup.Add("台上");
            YotogiGroup.Add("オナニー");
            YotogiGroup.Add("奉仕");
            YotogiGroup.Add("ＳＭ");
            YotogiGroup.Add("百合");
            YotogiGroup.Add("ハーレム");
            YotogiGroup.Add("乱交");
            YotogiGroup.Add("その他");
            YotogiGroup.Add("発情有り");
            YotogiGroup.Add("ランダム");


            //差分ファイル振り分け
            foreach (string file in YotogiListBase)
            {
                List<string> list = new List<string>();

                foreach (string sabun in _YotogiListSabun)
                {

                    string basefile = sabun;
                    if (!Regex.IsMatch(basefile, "m_")) basefile = Regex.Replace(basefile, @"^[a-zA-Z]_", "");
                    basefile = Regex.Replace(basefile, @"[a-zA-Z][0-9][0-9]", "");

                    if (file == basefile && !Regex.IsMatch(sabun, "b[0-9][0-9]"))
                    {
                        list.Add(sabun);
                    }
                }

                YotogiListSabun.Add(list);
            }

            Console.WriteLine("夜伽リスト抽出終了");

        }


        //イタズラ用モーションリストの読み込み
        void ItazuraMotionLoad()
        {

            MotionList_tati = ReadTextFaile(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt", "tati_list");  //立ちモーション
            MotionList_suwari = ReadTextFaile(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt", "suwari_list");  //座りモーション
            MotionList_zoukin = ReadTextFaile(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt", "zoukin_list");  //雑巾がけモーション
            MotionList_kyuuzi = ReadTextFaile(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt", "kyuuzi_list");  //給仕モーション
            MotionList_fukisouji = ReadTextFaile(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt", "fukisouji_list");  //拭き掃除モーション
            MotionList_mop = ReadTextFaile(@"Sybaris\UnityInjector\Config\VibeYourMaid\MList.txt", "mop_list");  //モップ掛けモーション

            //チェック様にイタズラモーションをひとまとめにする
            Console.WriteLine("イタズラモーションリスト結合開始");
            foreach (string[] x in MotionList20)
            {
                foreach (string xx in x)
                {
                    MotionList_vibe.Add(xx);
                }
            }
            foreach (string[] x in MotionList30)
            {
                foreach (string xx in x)
                {
                    MotionList_vibe.Add(xx);
                }
            }
            foreach (string[] x in MotionList40)
            {
                foreach (string xx in x)
                {
                    MotionList_vibe.Add(xx);
                }
            }
            Console.WriteLine("イタズラモーションリスト結合終了");
        }


        //派生モーション抽出
        /*public List<string[]> haseiMotionList = new List<string[]>();
        private void HaseiMotionCheck(string motion){
          haseiMotionList.Clear();
          Match match = regZeccyou.Match(motion);
          string kihonMotion = match.Groups[2].Value;
          
          List<string> files;
          if(MotionOldCheckB(motion)){
            files = allFiles;
          }else{
            files = allFilesOld;
          }
          
          foreach (string file in files){
            if(file.Contains(kihonMotion)){
              string[] m = new string[] { file, MotionNameChange(file) };
              haseiMotionList.Add(m);
            }
          }
        }*/




        //モーション名の日本語変換
        private string MotionNameChange(string motion)
        {

            string name = motion.Replace("seijyoui", "正常位").Replace("sexsofa", "ソファ").Replace("aibu", "愛撫").Replace("kyousitu", "教室").Replace("poseizi", "ポーズ維持").Replace("vibe", "バイブ").Replace("yorisoi", "寄添い").Replace("deep", "ディープ").Replace("hizadati", "膝立ち")
            .Replace("settai", "接待").Replace("turusi", "吊し").Replace("hasamikomi", "挟み込み").Replace("kaiwa", "会話").Replace("ryoutenaburi", "両手").Replace("furo", "風呂").Replace("kakaekomi", "抱え込み").Replace("table", "テーブル").Replace("tetunagi", "手繋ぎ")
            .Replace("manguri", "まんぐり").Replace("ritui", "立位").Replace("taimen", "対面").Replace("kijyoui", "騎乗位").Replace("haimen", "背面").Replace("tikan", "痴漢").Replace("ekiben", "駅弁").Replace("kasane", "重ね").Replace("pantskoki", "ぱんつコキ")
            .Replace("kouhaii", "後背位").Replace("kubisime", "首絞め").Replace("sokui", "側位").Replace("sukebeisu", "スケベ椅子").Replace("udemoti", "腕持ち").Replace("utubuse", "俯せ").Replace("onani", "オナニー").Replace("kotikake", "腰掛け").Replace("yotunbai", "四つん這い")
            .Replace("tekoki", "手コキ").Replace("toilet", "トイレ").Replace("zikkyou", "実況").Replace("asiname", "足舐め").Replace("fera", "フェラ").Replace("arai", "洗い").Replace("paizuri", "パイズリ").Replace("kougo", "交互").Replace("tukamu", "掴む")
            .Replace("siriname", "尻舐め").Replace("tinguri", "チングリ").Replace("siriyubi", "尻指").Replace("umanori", "馬乗り").Replace("harituke", "磔").Replace("kousokudai", "拘束台").Replace("nonosiru", "罵り").Replace("ryoute", "両手").Replace("sakate", "逆手")
            .Replace("maeyubi", "前指").Replace("kousoku", "拘束").Replace("mokuba", "木馬").Replace("harem", "ハーレム").Replace("housi", "奉仕").Replace("naburu", "嬲る").Replace("ran3p", "乱交3P").Replace("misetuke", "見せつけ")
            .Replace("2ana", "二穴").Replace("onedari", "おねだり").Replace("ran4p", "乱交4P").Replace("ganmen", "顔面").Replace("omocya", "玩具").Replace("sixnine", "シックスナイン").Replace("asikoki", "足コキ")
            .Replace("tekoona", "手コキオナニー").Replace("rosyutu", "露出").Replace("yuri", "百合").Replace("kiss", "キス").Replace("kaiawase", "貝合せ").Replace("kunni", "クンニ").Replace("momi", "揉み")
            .Replace("soutou", "双頭").Replace("cli", "クリ").Replace("hibu", "秘部").Replace("kuti", "くち").Replace("sex", "SEX").Replace("muri_3p", "無理矢理3P").Replace("muri_6p", "無理矢理6P").Replace("daki", "抱き")
            .Replace("tikubi", "乳首").Replace("itya", "ｲﾁｬｲﾁｬ").Replace("name", "舐め").Replace("daijyou", "台上").Replace("kakae", "抱え").Replace("sumata", "素股").Replace("osaetuke", "押え付け").Replace("osae", "押え").Replace("bedside", "ベッドサイド").Replace("satuei", "撮影").Replace("kosikake", "腰掛け")
            .Replace("hold", "ホールド").Replace("fusagu", "塞ぎ").Replace("zai", "座位").Replace("siriage", "尻上げ").Replace("siri", "尻").Replace("tati", "立ち").Replace("hiraki", "開き")
            .Replace("yubi", "指").Replace("mune", "胸").Replace("isu", "椅子").Replace("ude", "腕").Replace("inu", "犬").Replace("iziri", "弄り").Replace("irruma", "ｲﾗﾏﾁｵ").Replace("ir", "ｲﾗﾏﾁｵ").Replace("uma", "馬乗").Replace("gr", "ｸﾞﾗｲﾝﾄﾞ")
            .Replace("pai", "ﾊﾟｲｽﾞﾘ").Replace("hekimen", "壁面").Replace("dildo", "ディルド").Replace("mzi", "M字").Replace("kyou", "強").Replace("peace", "ピース").Replace("self", "セルフ").Replace("oku", "最奥").Replace("anal", "アナル").Replace("amayakasi", "甘やかし")
            .Replace("mp", "MP").Replace("lead", "リード").Replace("le", "左").Replace("ri", "右").Replace("_1_f2", "_女B").Replace("_f2", "_女B").Replace("_1_f3", "_女C").Replace("_f3", "_女C").Replace("_1_f", "").Replace("_f", "").Replace("x_", "").Replace("om_", "").Replace("m_", "M豚").Replace("matuba", "松葉崩し").Replace("yukadon", "床ドン")
            .Replace("mitumeau", "見合う").Replace("houti", "放置").Replace("onahokoki", "オナホこき").Replace("iya", "嫌").Replace("denma", "電マ").Replace("atama", "頭掴み").Replace("tawasi", "タワシ").Replace("tubo", "壺").Replace("ana", "穴").Replace("nasi", "無し").Replace("pose", "ポーズ").Replace("ubi", "指").Replace("wp", "Ｗピース").Replace("onna", "女").Replace(".anm", "");

            if (Regex.IsMatch(motion, "om_")) name = name + "_New";

            return name;

        }


        //モーションアジャスト関係
        private string[][] boneList = new string[][] {
          new string[] { "" , "無し" },
          new string[] { "_IK_muneL" , "左胸" },
          new string[] { "_IK_muneR" , "右胸" },
          new string[] { "_IK_vagina" , "あそこ" },
          new string[] { "_IK_hipL" , "お尻左" },
          new string[] { "_IK_hipR" , "お尻右" },
          new string[] { "_IK_anal" , "アナル" },
        };
        private string[] marksList = new string[] { "指定無し", "挿入 前", "挿入 後", "フェラ", "手コキ", "足コキ", "射精しない", "アナル 前", "アナル 後" };
        private string[][] prefabList = new string[][] {
          new string[] { "無し" , "スケベ椅子"      , "拘束騎乗位椅子"            , "椅子拘束台"                , "ラブソファ"     , "マット"    , "ギロチン台01"     , "ギロチン台02"     , "ディルド＆台"   , "拘束台"           , "拘束台座H型"           , "三角木馬" },
          new string[] { ""     , "Odogu_Sukebeisu" , "Odogu_KousokuKijyouiChair" , "Odogu_KousokuKijyouiChair" , "Odogu_LoveSofa" , "Odogu_Mat" , "Odogu_Girochin_A" , "Odogu_Girochin_B" , "Odogu_DildoBox" , "Odogu_Kousokudai" , "Odogu_KousokudaiHgata" , "Odogu_Sankakumokuba" }
        };
        private float[] prefabAdjust = new float[] { 0f, 0f, 0f, 0f, 0.0011f, 0f, 0f, 0f, 0.0008f, 0.00105f, 0.00105f, 0.00185f };

        public MotionAdjust maj = new MotionAdjust();
        public class MotionAdjust
        {
            public MotionAdjust()
            {
                motionName = new List<string>();
                baceMotion = new List<string>();
                basicHeight = new List<float>();
                basicRoll = new List<float>();
                maidRoll = new List<int>();
                manRoll = new List<int>();
                rollSettei = new List<int>();
                basicForward = new List<float>();
                mansHeight = new List<float>();
                mansForward = new List<float>();
                mansRight = new List<float>();
                hkupa1 = new List<float>();
                akupa1 = new List<float>();
                hkupa2 = new List<float>();
                akupa2 = new List<float>();
                mVoiceSet = new List<string>();
                iTargetLH = new List<int>();
                iTargetRH = new List<int>();
                syaseiMarks = new List<int[]>();
                giveSexual = new List<bool[]>();
                itemSet = new List<bool[]>();
                prefabSet = new List<int>();
                analEnabled = new List<bool>();
                analHeight = new List<float>();
                analForward = new List<float>();
                analRight = new List<float>();
            }

            public List<string> motionName;
            public List<string> baceMotion;
            public List<float> basicHeight;
            public List<float> basicRoll;
            public List<int> maidRoll;
            public List<int> manRoll;
            public List<int> rollSettei;
            public List<float> basicForward;
            public List<float> mansHeight;
            public List<float> mansForward;
            public List<float> mansRight;
            public List<float> hkupa1;
            public List<float> akupa1;
            public List<float> hkupa2;
            public List<float> akupa2;
            public List<string> mVoiceSet;
            public List<int> iTargetLH;
            public List<int> iTargetRH;
            public List<int[]> syaseiMarks;
            public List<bool[]> giveSexual;
            public List<bool[]> itemSet;
            public List<int> prefabSet;
            public List<bool> analEnabled;
            public List<float> analHeight;
            public List<float> analForward;
            public List<float> analRight;
        }

        private bool[] GiveSexualSet(string motion)
        {
            bool[] nb = new bool[] { false, false, false, false, false, false, false, false, false, false };
            string manMotion = Regex.Replace(motion, @"_f(|[0-9])$", "_m");
            manMotion = Regex.Replace(manMotion, @"_f(|[0-9])_", "_m_");
            if (motion.Contains("aibu") || motion.Contains("vibe") || motion.Contains("kunni") || motion.Contains("ganmenkijyoui") || motion.Contains("denma"))
            {
                nb[0] = true;

            }
            else if (motion.Contains("fera") || motion.Contains("paizuri") || motion.Contains("tekoki") || motion.Contains("arai") || motion.Contains("asiname") || motion.Contains("onahokoki") || motion.Contains("pantskoki") || motion.Contains("asikoki"))
            {
                int im2 = 1;
                for (int im = 0; im < SubMans.Length; im++)
                {
                    if (allFiles.Contains(manMotion, StringComparer.OrdinalIgnoreCase) || allFilesOld.Contains(manMotion, StringComparer.OrdinalIgnoreCase))
                    {
                        nb[im2] = true;

                        ++im2;
                        manMotion = Regex.Replace(manMotion, @"_m(|[0-9])$", "_m" + im2);
                        manMotion = Regex.Replace(manMotion, @"_m(|[0-9])_", "_m" + im2 + "_");

                    }
                    else
                    {
                        break;
                    }
                }

            }
            else
            {
                nb[0] = true;
                int im2 = 1;
                for (int im = 0; im < SubMans.Length; im++)
                {
                    if (allFiles.Contains(manMotion, StringComparer.OrdinalIgnoreCase) || allFilesOld.Contains(manMotion, StringComparer.OrdinalIgnoreCase))
                    {
                        nb[im2] = true;

                        ++im2;
                        manMotion = Regex.Replace(manMotion, @"_m(|[0-9])$", "_m" + im2);
                        manMotion = Regex.Replace(manMotion, @"_m(|[0-9])_", "_m" + im2 + "_");

                    }
                    else
                    {
                        break;
                    }
                }
            }
            nb[9] = true;  //9は初期設定がされているかどうかのフラグ
            return nb;
        }


        private int MotionIdCheck(string motion)
        {
            motion = motion.Replace(".anm", "");
            motion = Regex.Replace(motion, "_[23](?!ana)(?!p_)(?!vibe)", "_1");
            motion = Regex.Replace(motion, "_hatu_", "_");
            //if(!Regex.IsMatch(motion, "m_"))motion = Regex.Replace(motion, @"^[a-zA-Z]_", "");
            motion = Regex.Replace(motion, @"[a-zA-Z][0-9][0-9]", "");

            return maj.motionName.IndexOf(motion.ToLower());
        }


        private void MotionAdjustDo(int maidID, string motion, bool item, int mainID)
        {

            string motionMan = Regex.Replace(motion, @"_f(|[0-9])\.", "_m.");
            motionMan = Regex.Replace(motionMan, @"_f(|[0-9])_", "_m_");
            motion = motion.Replace(".anm", "");
            motion = Regex.Replace(motion, "_[23](?!ana)(?!p_)(?!vibe)", "_1");
            motion = Regex.Replace(motion, "_hatu_", "_");
            //if(!Regex.IsMatch(motion, "m_"))motion = Regex.Replace(motion, @"^[a-zA-Z]_", "");
            motion = Regex.Replace(motion, @"[a-zA-Z][0-9][0-9]", "");

            maidsState[maidID].motionID = maj.motionName.IndexOf(motion.ToLower());
            int mid = maidsState[maidID].motionID;

            if (mid < 0) return;

            maidsState[maidID].baceMotion = maj.baceMotion[mid]; //ベースモーションの指定があれば取得
            maidsState[maidID].outMotion = MotionCheckTokusyu(motion, sOutMaidMotion); //抜きモーションがあるかチェック
            maidsState[maidID].syaseiMotion = MotionCheckTokusyu(motion, syaseiMaidMotion); //射精モーションがあるかチェック
            maidsState[maidID].analMotion = MotionCheckTokusyu(motion, sInAnalMotion); //アナル挿入モーションがあるかチェック
            maidsState[maidID].motionSissinMove = MotionCheckTokusyu(motion, sMotionSissinMove);   //失神モーションがあるかチェック
            maidsState[maidID].motionSissinTaiki = MotionCheckTokusyu(motion, sMotionSissinTaiki);
            maidsState[maidID].senyouTokusyuMotion = MotionCheckTokusyuList(motion, sSenyouTokusyuMotion);  //特殊モーションがあるかチェック
            if (!maj.analEnabled[mid]) maidsState[maidID].analMode = false;

            //射精設定と快感上昇設定を取得する
            maidsState[maidID].syaseiMarks = maj.syaseiMarks[mid];
            maidsState[maidID].giveSexual = maj.giveSexual[mid];

            if (!cfgw.majEnabled) return;

            Maid maid = stockMaids[maidID].mem;
            Vector3 vm = maid.transform.position;
            if (mainID >= 0) vm = stockMaids[mainID].mem.transform.position; //サブメイドの場合はメインメイドの位置を参照
            Vector3 em = maid.transform.eulerAngles;
            int sintyou = maid.GetProp(MPN.sintyou).value;
            float majHi = vm.y + (maj.basicHeight[maidsState[maidID].motionID] - maidsState[maidID].majHiBack) * maid.status.body.height;
            //float majRoll = maj.basicRoll[maidsState[maidID].motionID] - maidsState[maidID].majRollBack;
            if (maj.basicRoll[maidsState[maidID].motionID] != maidsState[maidID].majRollBack) maidsState[maidID].majFwBack = maidsState[maidID].majFwBack * -1;
            float majFw = (maj.basicForward[maidsState[maidID].motionID] - maidsState[maidID].majFwBack) * maid.status.body.height;

            if (cfgw.majItemClear)
            {
                if (!maj.itemSet[mid][0] && maidsState[maidID].itemV == "") maid.DelProp(MPN.accvag, true);
                if (!maj.itemSet[mid][2] && maidsState[maidID].itemA == "") maid.DelProp(MPN.accanl, true);
                if (!maj.itemSet[mid][1] && !maj.itemSet[mid][3] && !maj.itemSet[mid][4]) maid.DelProp(MPN.handitem, true);
                maid.DelProp(MPN.kousoku_upper, true);
                maid.DelProp(MPN.kousoku_lower, true);
                maid.AllProcPropSeqStart();
                for (int im = 0; im < SubMans.Length; im++)
                {
                    if (!SubMans[im].Visible || MansTg[im] != maidID) continue;
                    man.DelProp(MPN.handitem, true);
                    man.AllProcPropSeqStart();
                }
            }

            //メイドの向き調整
            if (mainID == -1)
            {
                if (maj.rollSettei[maidsState[maidID].motionID] != 2)
                {
                    float emValue = em.y;
                    if (Array.IndexOf(MansTg, maidID) == -1 || !SubMans[Array.IndexOf(MansTg, maidID)].Visible || maj.rollSettei[maidsState[maidID].motionID] == 1)
                    {
                        if (maj.maidRoll[maidsState[maidID].motionID] != maidsState[maidID].majMaidRollBack) emValue += 180f;
                    }
                    else
                    {
                        if (maj.manRoll[maidsState[maidID].motionID] != maidsState[maidID].majManRollBack) emValue += 180f;
                    }
                    if (emValue >= 360f) emValue -= 360f;
                    maid.transform.eulerAngles = new Vector3(em.x, emValue, em.z);
                }
            }
            else
            {
                maid.transform.eulerAngles = stockMaids[mainID].mem.transform.eulerAngles;
            }

            //メイドの位置調整
            Vector3 maidForward = Vector3.Scale(maid.transform.forward, new Vector3(1, 1, 1)).normalized;
            Vector3 maidRight = Vector3.Scale(maid.transform.right, new Vector3(1, 1, 1)).normalized;
            Vector3 moveForward = maidForward * majFw;
            if (mainID < 0) maid.transform.position = new Vector3(vm.x, majHi, vm.z) + moveForward;

            if (mainID >= 0)
            { //百合やハーレムのサブメイド用の位置調整
                int tmid = maidsState[tgID].motionID;
                int tgSintyou = stockMaids[tgID].mem.GetProp(MPN.sintyou).value;
                float subHi = maj.mansHeight[tmid] * (50 - tgSintyou) - maj.mansHeight[mid] * (50 - sintyou);
                float subFw = maj.mansForward[tmid] * (50 - tgSintyou) - maj.mansForward[mid] * (50 - sintyou);
                float subRi = maj.mansRight[tmid] * (50 - tgSintyou) - maj.mansRight[mid] * (50 - sintyou);
                moveForward = maidForward * subFw + maidRight * subRi;
                maid.transform.position = new Vector3(vm.x, vm.y + subHi, vm.z) + moveForward;
            }


            //男の高さと向きをメイドに合わせる
            int im2 = 1;
            for (int im = 0; im < SubMans.Length; im++)
            {
                if (MotionOldCheck(motionMan) == -1) break; //男モーションがない場合は処理中断
                if (!SubMans[im].Visible || MansTg[im] != maidID) continue;
                Vector3 vm2 = SubMans[im].transform.position;
                Vector3 em2 = SubMans[im].transform.eulerAngles;

                float fDistance = Vector3.Distance(vm, vm2);
                if (fDistance > 1f) continue;

                SubMans[im].transform.eulerAngles = maid.transform.eulerAngles;
                //男位置差分調整
                float vm2Value = majHi + maj.mansHeight[mid] * (50 - sintyou);
                float mansFw = maj.mansForward[mid] * (50 - sintyou);
                float mansRi = maj.mansRight[mid] * (50 - sintyou);
                moveForward = maidForward * mansFw + maidRight * mansRi;
                vm = maid.transform.position;
                SubMans[im].transform.position = new Vector3(vm.x, vm2Value, vm.z) + moveForward;
                if (maidsState[maidID].analMode)
                { //analモード時の調整
                    moveForward = maidForward * maj.analForward[mid] + maidRight * maj.analRight[mid];
                    vm = SubMans[im].transform.position;
                    SubMans[im].transform.position = new Vector3(vm.x, vm.y + maj.analHeight[mid], vm.z) + moveForward;
                }

                //男のアイテム装備
                if (im2 == 1)
                {
                    if (maj.itemSet[mid][10])
                    { //手　バイブ
                        SubMans[im].SetProp("handitem", "HandItemR_VibePink_I_.menu", 0, true, false);
                    }
                    else if (maj.itemSet[mid][11])
                    {//手　Aバイブ
                        SubMans[im].SetProp("handitem", "HandItemR_AnalVibe_I_.menu", 0, true, false);
                    }
                    else if (maj.itemSet[mid][12])
                    {//電マ
                        SubMans[im].SetProp("handitem", "HandItemR_Denma_I_.menu", 0, true, false);
                    }
                    SubMans[im].AllProcPropSeqStart();
                }
                if (im2 == 2)
                {
                    if (maj.itemSet[mid][15])
                    { //手　バイブ
                        SubMans[im].SetProp("handitem", "HandItemR_VibePink_I_.menu", 0, true, false);
                    }
                    else if (maj.itemSet[mid][16])
                    {//手　Aバイブ
                        SubMans[im].SetProp("handitem", "HandItemR_AnalVibe_I_.menu", 0, true, false);
                    }
                    else if (maj.itemSet[mid][17])
                    {//電マ
                        SubMans[im].SetProp("handitem", "HandItemR_Denma_I_.menu", 0, true, false);
                    }
                    SubMans[im].AllProcPropSeqStart();
                }

                ++im2;
                motionMan = Regex.Replace(motionMan, @"_m(|[0-9])\.", "_m" + im2 + ".");
                motionMan = Regex.Replace(motionMan, @"_m(|[0-9])_", "_m" + im2 + "_");
            }

            //kupa値適用
            if (cfgw.majKupaEnabled)
            {
                if (!maidsState[maidID].analMode)
                {
                    if (maj.hkupa1[mid] >= 0) maidsState[maidID].hibuSlider1Value = maj.hkupa1[mid];
                    if (maj.akupa1[mid] >= 0) maidsState[maidID].analSlider1Value = maj.akupa1[mid];
                    if (maj.hkupa2[mid] >= 0) maidsState[maidID].hibuSlider2Value = maj.hkupa2[mid];
                    if (maj.akupa2[mid] >= 0) maidsState[maidID].analSlider2Value = maj.akupa2[mid];
                }
                else
                {
                    if (maj.hkupa1[mid] >= 0) maidsState[maidID].hibuSlider1Value = maj.akupa1[mid];
                    if (maj.akupa1[mid] >= 0) maidsState[maidID].analSlider1Value = maj.hkupa1[mid] + 10f;
                    if (maj.hkupa2[mid] >= 0) maidsState[maidID].hibuSlider2Value = maj.akupa2[mid];
                    if (maj.akupa2[mid] >= 0) maidsState[maidID].analSlider2Value = maj.hkupa2[mid] + 10f;
                }
                if (maid.GetProp(MPN.accvag).strTempFileName == "accVag_VibePink_I_.menu" || maid.GetProp(MPN.handitem).strTempFileName == "HandItemH_SoutouVibe_I_.menu")
                {
                    if (maidsState[tgID].hibuSlider1Value < 60f) maidsState[tgID].hibuSlider1Value = 60f;
                    if (maidsState[tgID].hibuSlider2Value < 60f) maidsState[tgID].hibuSlider2Value = 60f;
                }
                if (maid.GetProp(MPN.accanl).strTempFileName == "accAnl_AnalVibe_I_.menu")
                {
                    if (maidsState[maidID].analSlider1Value < 30f) maidsState[maidID].analSlider1Value = 30f;
                    if (maidsState[maidID].analSlider2Value < 30f) maidsState[maidID].analSlider2Value = 30f;
                }
            }


            //ボイスセット適用
            voiceSetLoad("evs_" + maj.mVoiceSet[mid] + ".xml", tgID);


            //メイドのアイテム装備
            if (item)
            {
                if (maj.itemSet[mid][0])
                { //バイブ
                    maid.SetProp("accvag", "accVag_VibePink_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.accVag, true);
                }
                if (maj.itemSet[mid][2])
                { //Aバイブ
                    maid.SetProp("accanl", "accAnl_AnalVibe_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.accAnl, true);
                }

                if (maj.itemSet[mid][1])
                { //手　バイブ
                    maid.SetProp("handitem", "HandItemR_VibePink_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.HandItemR, true);

                }
                else if (maj.itemSet[mid][3])
                {//手　Aバイブ
                    maid.SetProp("handitem", "HandItemR_AnalVibe_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.HandItemR, true);

                }
                else if (maj.itemSet[mid][4])
                {//双頭バイブ
                 //maid.SetProp("handitem" , "HandItemH_SoutouVibe_I_.menu", 0, true, false);
                 //maid.body0.SetMask(TBody.SlotID.HandItemR, true);
                    maidsState[maidID].sVibeFlag = true;
                }

                if (maj.itemSet[mid][5])
                {
                    maid.SetProp("kousoku_upper", "KousokuU_TekaseOne_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.kousoku_upper, true);
                }
                else if (maj.itemSet[mid][7])
                {
                    maid.SetProp("kousoku_upper", "KousokuU_SMRoom_Haritsuke_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.kousoku_upper, true);
                }
                if (maj.itemSet[mid][6])
                {
                    maid.SetProp("kousoku_lower", "KousokuL_AshikaseUp_I_.menu", 0, true, false);
                    maid.body0.SetMask(TBody.SlotID.kousoku_lower, true);
                }

                maid.AllProcPropSeqStart();

                //設置アイテム
                for (int si = 1; si < prefabList[0].Length; si++)
                {
                    if (si == maj.prefabSet[mid])
                    {
                        Vector3 zero = maid.transform.position;
                        zero.y = zero.y - (prefabAdjust[si] * (50 - maid.GetProp(MPN.sintyou).value)) - (maj.basicHeight[maidsState[maidID].motionID] * maid.status.body.height);
                        Vector3 zero2 = maid.transform.eulerAngles;
                        zero2.x = -90f;
                        GameMain.Instance.BgMgr.AddPrefabToBg(prefabList[1][si], prefabList[0][si] + maidID, null, zero, zero2);
                    }
                    else
                    {
                        GameMain.Instance.BgMgr.DelPrefabFromBg(prefabList[0][si] + maidID);
                    }
                }

            }

            //IKアタッチ適用
            /*if(SubMans[0].Visible){
              if(maj.iTargetLH[mid] == 0){
                SubMans[0].IKTargetToBone("左手", null, "無し", Vector3.zero, IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);
              }else{
                SubMans[0].IKTargetToBone("左手", maid, boneList[maj.iTargetLH[mid]][0], new Vector3(0f, 0f, 0f), IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);
              }
              if(maj.iTargetRH[mid] == 0){
                SubMans[0].IKTargetToBone("右手", null, "無し", Vector3.zero, IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);
              }else{
                SubMans[0].IKTargetToBone("右手", maid, boneList[maj.iTargetRH[mid]][0], new Vector3(0f, 0f, 0f), IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);
              }
            }*/
            //if(maj.hkupa1[mid] >= 60f)SubMans[0].IKTargetToBone("_IK_chinko1", maid, "_IK_vagina", new Vector3(0f, 0f, 0f), IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);

            //調整値のバックアップを取る
            maidsState[maidID].majHiBack = maj.basicHeight[mid];
            maidsState[maidID].majRollBack = maj.basicRoll[mid];
            maidsState[maidID].majMaidRollBack = maj.maidRoll[mid];
            maidsState[maidID].majManRollBack = maj.manRoll[mid];
            maidsState[maidID].majFwBack = maj.basicForward[mid];
        }


        void MotionAdjustPsv(int maidID)
        {
            Maid maid = stockMaids[maidID].mem;

            string motion = maid.body0.LastAnimeFN;
            motion = regZeccyouBackup.Match(motion).Groups[1].Value;  // 「 - Que…」を除く

            motion = Regex.Replace(motion, "_[23](?!ana)(?!p_)(?!vibe)", "_1");
            motion = Regex.Replace(motion, "_hatu_", "_");
            //if(!Regex.IsMatch(motion, "m_"))motion = Regex.Replace(motion, @"^[a-zA-Z]_", "");
            motion = Regex.Replace(motion, @"[a-zA-Z][0-9][0-9]", "");
            motion = motion.Replace(".anm", "");
            /*Match match = regZeccyou.Match(motion);
            motion = match.Groups[2].Value;  //現在モーションファイル名の先頭部分取得
            motion = motion + "_1_f";*/

            int mid = maj.motionName.IndexOf(motion.ToLower());
            if (mid < 0 || mid == maidsState[maidID].motionID) return;  //モーションファイルがマッチしない、もしくは現在と同じなら終了

            maidsState[maidID].motionID = mid;

            maidsState[maidID].inMotion = MotionCheckTokusyu(motion, sInMaidMotion); //挿入モーションがあるかチェック
            maidsState[maidID].outMotion = MotionCheckTokusyu(motion, sOutMaidMotion); //抜きモーションがあるかチェック
            maidsState[maidID].syaseiMotion = MotionCheckTokusyu(motion, syaseiMaidMotion); //射精モーションがあるかチェック
            maidsState[maidID].analMotion = MotionCheckTokusyu(motion, sInAnalMotion); //アナル挿入モーションがあるかチェック
            maidsState[maidID].motionSissinMove = MotionCheckTokusyu(motion, sMotionSissinMove);   //失神モーションがあるかチェック
            maidsState[maidID].motionSissinTaiki = MotionCheckTokusyu(motion, sMotionSissinTaiki);
            maidsState[maidID].senyouTokusyuMotion = MotionCheckTokusyuList(motion, sSenyouTokusyuMotion);  //特殊モーションがあるかチェック
            if (!maj.analEnabled[mid]) maidsState[maidID].analMode = false;

            //射精設定と快感上昇設定を取得する
            maidsState[maidID].syaseiMarks = maj.syaseiMarks[mid];
            maidsState[maidID].giveSexual = maj.giveSexual[mid];

            if (!cfgw.majEnabled) return;

            //kupa値適用
            if (!maidsState[maidID].analMode)
            {
                if (maj.hkupa1[mid] >= 0) maidsState[maidID].hibuSlider1Value = maj.hkupa1[mid];
                if (maj.akupa1[mid] >= 0) maidsState[maidID].analSlider1Value = maj.akupa1[mid];
                if (maj.hkupa2[mid] >= 0) maidsState[maidID].hibuSlider2Value = maj.hkupa2[mid];
                if (maj.akupa2[mid] >= 0) maidsState[maidID].analSlider2Value = maj.akupa2[mid];
            }
            else
            {
                if (maj.hkupa1[mid] >= 0) maidsState[maidID].hibuSlider1Value = maj.akupa1[mid];
                if (maj.akupa1[mid] >= 0) maidsState[maidID].analSlider1Value = maj.hkupa1[mid] + 10f;
                if (maj.hkupa2[mid] >= 0) maidsState[maidID].hibuSlider2Value = maj.akupa2[mid];
                if (maj.akupa2[mid] >= 0) maidsState[maidID].analSlider2Value = maj.hkupa2[mid] + 10f;
            }
            if (maid.GetProp(MPN.accvag).strTempFileName == "accVag_VibePink_I_.menu" || maid.GetProp(MPN.handitem).strTempFileName == "HandItemH_SoutouVibe_I_.menu")
            {
                if (maidsState[tgID].hibuSlider1Value < 60f) maidsState[tgID].hibuSlider1Value = 60f;
                if (maidsState[tgID].hibuSlider2Value < 60f) maidsState[tgID].hibuSlider2Value = 60f;
            }
            if (maid.GetProp(MPN.accanl).strTempFileName == "accAnl_AnalVibe_I_.menu")
            {
                if (maidsState[maidID].analSlider1Value < 30f) maidsState[maidID].analSlider1Value = 30f;
                if (maidsState[maidID].analSlider2Value < 30f) maidsState[maidID].analSlider2Value = 30f;
            }

        }

        //モーションファイルの読み込み関係終了-----------------





        //-------------------------------------------------
        //モーションチェンジ関係---------------------------

        private Regex regZeccyou = new Regex(@"^([jtk]_)?(.*)_[1234].*");  // モーション名から基本となる部分を取り出す（不安）
        private Regex regZeccyouBackup = new Regex(@"^(.*\.anm).*");  // たまにモーション名の後についてる「 - Queほにゃらら」を除く（適当）

        private string[] sZeccyouMaidMotion1 = new string[] { "_ryouhou_zeccyou_f_once_", "zeccyou_ryouhou_f_once_", "_seikantaizeccyou_f_once_", "_zeccyou_f_once_", "_shasei_kuti_f_once_", "_shasei_naka_f_once_", "_shasei_kao_f_once_", "_shasei_soto_f_once_" };
        private string[] sZeccyouMaidMotion2 = new string[] { "_shasei_kuti_f_once_", "_shasei_naka_f_once_", "_shasei_kao_f_once_", "_shasei_soto_f_once_", "_seikantaizeccyou_f_once_", "_zeccyou_f_once_" };
        private string[] syaseiMaidMotion = new string[] { "_shasei_kuti_f_once_", "_shasei_naka_f_once_", "_shasei_kao_f_once_", "_shasei_soto_f_once_" };
        private string[] sInMaidMotion = new string[] { "_in_f_once_" };
        private string[] sInAnalMotion = new string[] { "a_in_m_once_" };
        private string[] sOutMaidMotion = new string[] { "_shasei_kao_f_once_", "_shasei_soto_f_once_" };
        private string[] sShaseigoMaidMotion = new string[] { "_shaseigo_kao_f", "_shaseigo_soto_f" };
        private string[] sMotionSissinMove = new string[] { "_sissin_f", "_sissin_1_f", "_sissin_2_f" };
        private string[] sMotionSissinTaiki = new string[] { "_sissin_taiki_f" };
        private string[] sHighExciteMaidMotion = new string[] { "_3_f", "_3a01_f", "_3b01_f", "_3b02_f" };
        private string[] sSenyouTokusyuMotion = new string[] {
                    "3_down1_f", "3_down2_f",
                    "_aibu_f", "_anal_f", "_cli_f", "_dk_f", "_dt_f", "_3_down1_f", "_3_down2_f", "_fukujyuu_f", "_fseme_f", "_gaman_f", "_ganmenkijyoui_f", "_gikotinai_f", "_gr_f", "_gr2_f", "_gr_momi_f",
                    "_hagesiku_f", "_hentaipose_f", "_hibuhiroge_f", "_hibu_f", "_hibuhiraki_1_f", "_hiroge_f","_hounyou_f_once_", "_humituke_f",
                    "_in_mae_aibu_f", "_izirase_f",
                    "_kansou_f", "_kataosi_f", "_kakusu_taiki_f", "_kitou_f", "_kiss_f", "_kosurituke_f", "_kousoku_f", "_kougo_f", "_kunne_f", "_kunni_f", "_kusuguri_f", "_kuti_f","_kutihusagi_f", "_kutuname_f", "_kuwae_f", "_kuwaezu_f",
                    "_mae_aibu_f", "_miage_1_kiss_f", "_miage_1_sentan_f", "_miccyaku_f", "_mitumeau_f", "_misetuke_f", "_momi_f", "_momikiss_1_f", "_momi_mune_f", "_momo_name_f", "_momi_siri_f", "_mseme_f", "_mseme2_f", "_munesirimomi_f", "_muti_hibu_f_once_", "_muti_mune_f_once_", "_mzi_f",
                    "_nade_f", "_nade_1_f", "_name_f", "_name_ura_f", "_nazirare_f", "_nigirase_f", "_nodo_f", "_nodo_tome_f", "_nomasu_f_once_", "_nonosiru_f",
                    "_oku_f", "_okuseme_f", "_onani_f", "_onani_syutyu_f", "_onedari_f",
                    "_pose_f", "_pose01_f", "_pose02_f", "_pose03_f", "_pose04_f", "_pose05_f", "_pose06_f",
                    "_ranbou_f", "_rou_hibu_f_once_", "_rou_mune_f_once_", "_rou_senaka_f_once_", "_rou_siri_f_once_", "_ryouasi_f", "_ryoute_f", "_ryoumomi_f",
                    "_sakasaarai_f", "_sasayaku_f", "_seki_1_f_once_", "_sentan_f", "_siri_f", "_sirikoki_f", "_sirinade_f", "_siriyubi_f", "_siri_name_f", "_siri_nade_f", "_siri_seme_f", "_siriana_nade_f", "_suihei_f", "_sumata_f", "_surituke_f", "_shaseigo_naka_hounyou_f_once_", "_syutyu_f",
                    "_taiki_kaisi_f", "_taiki_ikou_f_once_", "_taiki_kaisi_ikou_f_once_", "_tama_f", "_tamaizirifera_f", /*"_tataki_f_once_", "_tataki_hoho_f_once_", "_tataki_mune_f_once_", */"_tataki_siri_f_once_", "_tataki_siri_1_f_once_", "_tawasi_f", "_tati_f", "_tati_fumi_f", "_tekoki_f", "_teman_low_f", "_teman_high_f", "_tikubi_f", "_tintin_f", "_tintinpose_f", "_tubo_f", "_tuboarai_f",
                    "_udemoti_f", "_uraname_f",
                    "_vibe_kuwae_f", "_vibe_kuwaezu_f", "_in_hibumise_f_once_", "_in_hibumise_modori_f_once_",
                    "_zeccyou_gaman_f", "_zikkyou_f", "_zirasu_f","_zirasi_taiki_f", "_zirasi_surituke_f", "_zirasi_surituke_in_f_once_",
                    };

        //　バイブ弱時のモーションリスト
        private string[][] MotionList20 = new string[][] {
          new string[] { "rosyutu_omocya_1_f.anm" , "rosyutu_tati_vibe_onani_1_f.anm" }, //立ち
          new string[] { "settai_vibe_in_kaiwa_jaku_a01_f.anm" , "settai_vibe_in_kaiwa_jaku_f.anm" }, //椅子座り
          new string[] { "soji_zoukin_vibe.anm" }, //雑巾
          new string[] { "work_kyuuzi_vibe_b01.anm" , "work_kyuuzi_vibe_b02.anm" }, //給仕
          new string[] { "fukisouji1_vibe.anm" }, //拭き掃除
          new string[] { "soji_mop_vibe.anm" }, //モップ
          new string[] { "tati_kiss_loop_f.anm" }, //立ちキス
          new string[] { "k_aibu_kiss_2_f.anm" } //椅子座りキス
        };

        //　バイブ強時のモーションリスト
        private string[][] MotionList30 = new string[][] {
          new string[] { "rosyutu_omocya_2_f.anm" , "rosyutu_omocya_3_f.anm" , "rosyutu_tati_vibe_onani_2_f.anm" }, //立ち
          new string[] { "settai_vibe_in_kaiwa_kyou_a01_f.anm" , "settai_vibe_in_kaiwa_kyou_f.anm" }, //椅子座り
          new string[] { "soji_zoukin_vibe_a01.anm" }, //雑巾
          new string[] { "work_kyuuzi_vibe_a01.anm" }, //給仕
          new string[] { "fukisouji1_vibe_a01.anm" }, //拭き掃除
          new string[] { "soji_mop_vibe_a01.anm" }, //モップ
          new string[] { "tati_kiss_loop_f.anm" }, //立ちキス
          new string[] { "k_aibu_kiss_3_f.anm" } //椅子座りキス
        };

        //　バイブ停止時のモーションリスト
        private string[][] MotionList40 = new string[][] {
          new string[] { "rosyutu_omocya_taiki_f.anm" }, //立ち
          new string[] { "settai_vibe_in_taiki_f.anm" },  //椅子座り
          new string[] { "maid_orz.anm" }, //雑巾
          new string[] { "work_kyuuzi_vibe.anm" }, //給仕
          new string[] { "fukisouji1_vibe.anm" }, //拭き掃除
          new string[] { "soji_mop_vibe.anm" }, //モップ
          new string[] { "tati_kiss_taiki_f.anm" }, //立ちキス
          new string[] { "k_aibu_kiss_1_f.anm" } //椅子座りキス
        };


        private string MotionCheckTokusyu(string motion, string[] list)
        {

            string t = motion;
            Match match = regZeccyou.Match(t);

            //現在モーションファイル名の先頭部分取得
            t = match.Groups[2].Value;

            //特殊モーションのファイル名が有るかどうかチェック
            bool check = false;
            string checkMotion = "";

            Console.WriteLine("モーションチェック：" + motion);

            foreach (string m in list)
            {
                checkMotion = t + m;
                if (Regex.IsMatch(motion, "harem_") || Regex.IsMatch(motion, "yuri_"))
                {
                    if (0 <= motion.IndexOf("_f.") || motion.EndsWith("_f"))
                    {
                        checkMotion = t + m;
                        Console.WriteLine("【f1】:" + checkMotion);

                    }
                    else if (0 <= motion.IndexOf("_f2.") || motion.EndsWith("_f2"))
                    {
                        checkMotion = t + m.Replace("_f_", "_f2_");
                        checkMotion = Regex.Replace(checkMotion, "_f$", "_f2");
                    }
                    else if (0 <= motion.IndexOf("_f3.") || motion.EndsWith("_f3"))
                    {
                        checkMotion = t + m.Replace("_f_", "_f2_");
                        checkMotion = Regex.Replace(checkMotion, "_f$", "_f3");
                    }
                }

                if (MotionOldCheck(checkMotion) != -1)
                {
                    check = true;
                    Console.WriteLine("【有り】" + checkMotion);
                    break;
                }
                Console.WriteLine("【無し】" + checkMotion);
            }

            //上記チェックで引っかからなかった場合、「cli」や「kiss」などの文字列を除去してもう一度チェック
            if (!check)
            {
                string motion2 = "";
                int mid = MotionIdCheck(motion);
                if (mid != -1) motion2 = maj.baceMotion[mid];

                if (motion2 == "")
                {
                    //t = t.Replace("_hibu", "").Replace("_kiss", "").Replace("_cli", "").Replace("_momi", "").Replace("_gr", "").Replace("_kuti", "").Replace("_kuti", "").Replace("_kuti", "").Replace("_kuti", "");
                    t = Regex.Replace(t, @"_[^_]{1,}$", ""); //モーション名の最後尾の一節を削除
                }
                else
                {
                    t = motion2;
                }
                foreach (string m in list)
                {
                    checkMotion = t + m;
                    if (Regex.IsMatch(motion, "harem_") || Regex.IsMatch(motion, "yuri_"))
                    {
                        if (0 <= motion.IndexOf("_f.") || motion.EndsWith("_f"))
                        {
                            checkMotion = t + m;

                        }
                        else if (0 <= motion.IndexOf("_f2.") || motion.EndsWith("_f2"))
                        {
                            checkMotion = t + m.Replace("_f_", "_f2_");
                            checkMotion = Regex.Replace(checkMotion, "_f$", "_f2");
                        }
                        else if (0 <= motion.IndexOf("_f3.") || motion.EndsWith("_f3"))
                        {
                            checkMotion = t + m.Replace("_f_", "_f3_");
                            checkMotion = Regex.Replace(checkMotion, "_f$", "_f3");
                        }
                    }

                    if (MotionOldCheck(checkMotion) != -1)
                    {
                        check = true;
                        Console.WriteLine("【有り】" + checkMotion);
                        break;
                    }
                    Console.WriteLine("【無し】" + checkMotion);
                }
            }

            if (check)
            {
                return checkMotion;
            }
            else
            {
                return "Non";
            }
        }


        private List<string> MotionCheckTokusyuList(string motion, string[] list)
        {

            string t = motion;
            Match match = regZeccyou.Match(t);

            //現在モーションファイル名の先頭部分取得
            t = match.Groups[2].Value;

            //特殊モーションのファイル名が有るかどうかチェック
            bool check = false;
            string checkMotion = "";
            List<string> motionList = new List<string>();

            Console.WriteLine("モーションチェック：" + motion);

            foreach (string m in list)
            {
                checkMotion = t + m;
                if (Regex.IsMatch(motion, "harem_") || Regex.IsMatch(motion, "yuri_"))
                {
                    if (0 <= motion.IndexOf("_f.") || motion.EndsWith("_f"))
                    {
                        checkMotion = t + m;
                        Console.WriteLine("【f1】:" + checkMotion);

                    }
                    else if (0 <= motion.IndexOf("_f2.") || motion.EndsWith("_f2"))
                    {
                        checkMotion = t + m.Replace("_f_", "_f2_");
                        checkMotion = Regex.Replace(checkMotion, "_f$", "_f2");
                    }
                    else if (0 <= motion.IndexOf("_f3.") || motion.EndsWith("_f3"))
                    {
                        checkMotion = t + m.Replace("_f_", "_f3_");
                        checkMotion = Regex.Replace(checkMotion, "_f$", "_f3");
                    }
                }

                if (MotionOldCheck(checkMotion) != -1)
                {
                    check = true;
                    motionList.Add(checkMotion);
                }
            }

            //上記チェックで引っかからなかった場合、「cli」や「kiss」などの文字列を除去してもう一度チェック
            if (!check)
            {
                string motion2 = "";
                int mid = MotionIdCheck(motion);
                if (mid != -1) motion2 = maj.baceMotion[mid];

                if (motion2 == "")
                {
                    t = Regex.Replace(t, @"_[^_]{1,}$", ""); //モーション名の最後尾の一節を削除
                }
                else
                {
                    t = motion2;
                }
                foreach (string m in list)
                {
                    checkMotion = t + m;
                    if (Regex.IsMatch(motion, "harem_") || Regex.IsMatch(motion, "yuri_"))
                    {
                        if (0 <= motion.IndexOf("_f.") || motion.EndsWith("_f"))
                        {
                            checkMotion = t + m;

                        }
                        else if (0 <= motion.IndexOf("_f2.") || motion.EndsWith("_f2"))
                        {
                            checkMotion = t + m.Replace("_f_", "_f2_");
                            checkMotion = Regex.Replace(checkMotion, "_f$", "_f2");
                        }
                        else if (0 <= motion.IndexOf("_f3.") || motion.EndsWith("_f3"))
                        {
                            checkMotion = t + m.Replace("_f", "_f3").Replace("_f_", "_f3_");
                            checkMotion = Regex.Replace(checkMotion, "_f$", "_f3");
                        }
                    }

                    if (MotionOldCheck(checkMotion) != -1)
                    {
                        check = true;
                        motionList.Add(checkMotion);
                    }
                }
            }

            return motionList;
        }


        //メイドのモーション変更（通常時） abs:強制的にモーションチェンジするかどうか（falseで強制）
        private void MaidMotionChange(int maidID, bool abs)
        {

            float cs = 0.5f;
            float ls = 1f;
            if (maidsState[maidID].vStateMajor == 10 && maidsState[maidID].vStateMajorOld == 50) cs = 1f;

            Maid maid = stockMaids[maidID].mem;
            //現在のモーションを取得
            string motion = maid.body0.LastAnimeFN;
            motion = regZeccyouBackup.Match(motion).Groups[1].Value;  // 「 - Que…」を除く
            if (Regex.IsMatch(motion, "_sissin")) motion = maj.motionName[maidsState[maidID].motionID] + "_1_f.anm"; //失神モーションから遷移させる場合は、基本モーションを取得する

            bool cc = maidsState[maidID].cameraCheck;
            if (maidID == osawariID && osawariPoint == "mouth") cc = true;


            //モーションカテゴリのチェック
            int check = MaidMotionCheck(motion, cc);
            if (check == -1) return;

            //変更モーションに変換
            motion = MaidMotionSelect(motion, check, maidID);

            //モーションが同じ場合は変更しない
            if (maid.body0.LastAnimeFN == motion) return;

            //実際にモーションを変更
            int old = MotionOldCheck(motion);
            if (old == 0)
            {
                if (abs) MotionChange(maid, motion, true, false, cs, ls);
                if (!abs) MotionChangeAf(maid, motion, true, false, cs, ls);
                ManMotionChange(motion, maidID, true, false, abs, cs, ls);
            }
            else if (old == 1)
            {
                if (abs) MotionChange(maid, motion, true, true, cs, ls);
                if (!abs) MotionChangeAf(maid, motion, true, true, cs, ls);
                ManMotionChange(motion, maidID, true, true, abs, cs, ls);
            }


            //百合・ハーレム用モーションチェンジ
            /*if(Regex.IsMatch(motion, "yuri_") || Regex.IsMatch(motion, "harem_")){
              SubMotionChange(maidID, motion, true, true, cs, ls);
            }*/
        }



        //モーションカテゴリのチェック
        private int MaidMotionCheck(string motion, bool cc)
        {

            int check = -1;

            if (MotionList_tati.Contains(motion))
            { //立ちモーションの場合
                check = 0;
                if (cc) check = 6;

            }
            else if (MotionList_suwari.Contains(motion))
            { //座りモーションの場合
                check = 1;
                if (cc) check = 7;

            }
            else if (MotionList_zoukin.Contains(motion))
            { //雑巾がけモーションの場合
                check = 2;

            }
            else if (MotionList_kyuuzi.Contains(motion))
            { //給仕モーションの場合
                check = 3;

            }
            else if (MotionList_fukisouji.Contains(motion))
            { //拭き掃除モーションの場合
                check = 4;

            }
            else if (MotionList_mop.Contains(motion))
            { //モップ掛けモーションの場合
                check = 5;

            }
            else if (Regex.IsMatch(motion, "_[123]"))
            { //変更可能な夜伽モーションの場合
                check = 10;

            }
            else
            {
                check = -1;

            }

            return check;
        }



        //通常時の変更モーションを調べて返す
        private string MaidMotionSelect(string motion, int check, int maidID)
        {

            string t = motion;

            if (maidsState[maidID].stunFlag && maidsState[maidID].motionSissinMove != "Non")
            { //失神している場合は失神モーションに変更
                if (maidsState[maidID].vStateMajor == 40 || maidsState[maidID].vStateMajor == 10)
                {
                    t = maidsState[maidID].motionSissinTaiki + ".anm";
                }
                else
                {
                    t = maidsState[maidID].motionSissinMove + ".anm";
                }

            }
            else if (check == 10)
            {

                //一段階目のモーションをバックアップとして取る
                string motionBack = Regex.Replace(t, "_[123]", "_1");
                motionBack = Regex.Replace(motionBack, "_hatu_", "_");
                if (!Regex.IsMatch(t, "m_")) motionBack = Regex.Replace(motionBack, @"^[a-zA-Z]_", "");
                maidsState[maidID].maidMotionBackup = Regex.Replace(motionBack, @"[a-zA-Z][0-9][0-9]", "");

                //バイブ強度に合わせてモーション名を変換
                if (maidsState[maidID].vStateMajor == 20)
                {
                    t = Regex.Replace(t, "_[13](?!ana)(?!p_)(?!vibe)", "_2");
                    t = Regex.Replace(t, "_hatu_", "_");
                    if (!Regex.IsMatch(t, "m_")) t = Regex.Replace(t, @"^[a-zA-Z]_", "");
                    t = Regex.Replace(t, @"[a-zA-Z][0-9][0-9]", "");

                }
                else if (maidsState[maidID].vStateMajor == 30)
                {
                    if (maidsState[maidID].orgasmCmb <= 3)
                    {
                        t = Regex.Replace(t, "_[12](?!ana)(?!p_)(?!vibe)", "_3");
                        t = Regex.Replace(t, "_hatu_3", "_3");
                    }
                    else
                    {
                        t = Regex.Replace(t, "_[12](?!ana)(?!p_)(?!vibe)", "_3");
                    }
                    if (!Regex.IsMatch(t, "m_")) t = Regex.Replace(t, @"^[a-zA-Z]_", "");
                    t = Regex.Replace(t, @"[a-zA-Z][0-9][0-9]", "");

                }
                else if (maidsState[maidID].vStateMajor == 40 || maidsState[maidID].vStateMajor == 10)
                {
                    t = Regex.Replace(t, "_[23](?!ana)(?!p_)(?!vibe)", "_1");
                    t = Regex.Replace(t, "_hatu_", "_");
                    if (!Regex.IsMatch(t, "m_")) t = Regex.Replace(t, @"^[a-zA-Z]_", "");
                    t = Regex.Replace(t, @"[a-zA-Z][0-9][0-9]", "");
                }

                //差分モーションが有るかどうかチェック
                if (!Regex.IsMatch(motion, "yuri_") && !Regex.IsMatch(motion, "harem_"))
                {
                    int i = YotogiListBase.IndexOf(t.ToLower());
                    if (i >= 0)
                    {
                        int r = UnityEngine.Random.Range(0, YotogiListSabun[i].Count);
                        t = YotogiListSabun[i][r];
                    }
                }

                //まんぐりバイブだけはファイルがおかしいため変更
                if (t == "manguri_vibe_1_f.anm") t = "x_manguri_vibe_1_f.anm";
                if (t == "manguri_vibe_2_f.anm") t = "x_manguri_vibe_2_f.anm";
                if (t == "manguri_vibe_3_f.anm") t = "x_manguri_vibe_3_f.anm";
                if (t == "manguri_vibe_oku_1_f.anm") t = "x_manguri_vibe_oku_1_f.anm";
                if (t == "manguri_vibe_oku_2_f.anm") t = "x_manguri_vibe_oku_2_f.anm";
                if (t == "manguri_vibe_oku_3_f.anm") t = "x_manguri_vibe_oku_3_f.anm";


            }
            else if (check >= 0)
            {

                int i20 = UnityEngine.Random.Range(0, MotionList20[check].Length);
                int i30 = UnityEngine.Random.Range(0, MotionList30[check].Length);
                int i40 = UnityEngine.Random.Range(0, MotionList40[check].Length);

                //通常モーションから遷移する場合にバックアップを取る
                if (!MotionList_vibe.Contains(t) && (0 > t.IndexOf("_once_")))
                {
                    maidsState[maidID].maidMotionBackup = t;
                }

                //変更モーションを決定
                if (maidsState[maidID].vStateMajor == 20 && t != MotionList20[check][i20])
                {
                    t = MotionList20[check][i20];
                }
                else if (maidsState[maidID].vStateMajor == 30 && t != MotionList30[check][i30])
                {
                    t = MotionList30[check][i30];
                }
                else if (maidsState[maidID].vStateMajor == 40)
                {
                    t = MotionList40[check][i40];
                }
                else if (maidsState[maidID].vStateMajor == 10 && maidsState[maidID].vStateMajorOld == 50)
                {
                    t = maidsState[maidID].maidMotionBackup;
                }

            }

            return t;

        }

        //メイドのモーション変更（絶頂時）
        private void ZeccyoMotionSelect(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;
            //現在のモーションを取得
            string motion = maid.body0.LastAnimeFN;
            motion = regZeccyouBackup.Match(motion).Groups[1].Value;  // 「 - Que…」を除く

            ZeccyoMotionSelect(motion, maidID);
        }

        private void ZeccyoMotionSelect(string motion, int maidID)
        {

            Maid maid = stockMaids[maidID].mem;
            string t = motion;

            //連続絶頂中の場合、専用モーション（_hatu_3）があるかどうか調べて変更する
            if (Regex.IsMatch(t, "_hatu_3"))
            {
                if (SyaseiCheck(maidID, 100f))
                {
                    t = Regex.Replace(t, "_hatu_3", "_3");
                }
                else
                {
                    return;
                }
            }
            else if (maidsState[maidID].orgasmCmb > 3)
            {
                t = Regex.Replace(t, "_[12](?!ana)(?!p_)(?!vibe)", "_3");
                if (!Regex.IsMatch(t, "m_") && !Regex.IsMatch(t, "x_manguri_vibe")) t = Regex.Replace(t, @"^[a-zA-Z]_", "");
                t = Regex.Replace(t, @"[a-zA-Z][0-9][0-9]", "");

                if (MotionOldCheck(t.Replace("_3", "_hatu_3")) != -1)
                {
                    t = Regex.Replace(t, "_3", "_hatu_3");
                    MotionChange(maid, t, true, 0.5f, 1f);

                    maidsState[maidID].zAnimeFileName = t + ".anm";

                    ManMotionChange(t, maidID, true, 0.5f, 1f);

                    return;

                }
            }

            Match match = regZeccyou.Match(t);
            string sHighExciteMotionBackup = regZeccyouBackup.Match(t).Groups[1].Value;  // 「 - Que…」を除く

            //通常の絶頂モーション変更処理
            if (match.Success || sHighExciteMotionBackup == "settai_vibe_in_kaiwa_kyou_a01_f.anm" || sHighExciteMotionBackup == "settai_vibe_in_kaiwa_kyou_f.anm")
            {

                //現在モーションファイル名の先頭部分取得
                string sZeccyouMotion = match.Groups[2].Value;

                //ポーズ維持、接待バイブのモーション名の場合は変換
                if (sZeccyouMotion == "poseizi_hibu")
                {
                    sZeccyouMotion = "poseizi";
                }
                else if (sZeccyouMotion == "poseizi2_hibu")
                {
                    sZeccyouMotion = "poseizi2";
                }
                else if (sHighExciteMotionBackup == "settai_vibe_in_kaiwa_kyou_a01_f.anm" || sHighExciteMotionBackup == "settai_vibe_in_kaiwa_kyou_f.anm")
                {
                    sZeccyouMotion = "settai_vibe_in";
                }


                //絶頂モーションのファイル名が有るかどうかチェック
                bool zf = false;
                string sZeccyouMotionMaid = "";
                string[] sZeccyouMaidMotion = sZeccyouMaidMotion1;
                if ((SyaseiCheck(maidID, 85f) && maidsState[maidID].orgasmCmb <= 3) || (SyaseiCheck(maidID, 100f) && maidsState[maidID].orgasmCmb > 3)) sZeccyouMaidMotion = sZeccyouMaidMotion2;

                foreach (string z in sZeccyouMaidMotion)
                {
                    sZeccyouMotionMaid = sZeccyouMotion + z;

                    if (Regex.IsMatch(sZeccyouMotion, "harem_") || Regex.IsMatch(sZeccyouMotion, "yuri_"))
                    {
                        if (0 <= sHighExciteMotionBackup.IndexOf("_f."))
                        {
                            sZeccyouMotionMaid = sZeccyouMotion + z;

                        }
                        else if (0 <= sHighExciteMotionBackup.IndexOf("_f2."))
                        {
                            sZeccyouMotionMaid = sZeccyouMotion + z.Replace("_f_", "_f2_");

                        }
                        else if (0 <= sHighExciteMotionBackup.IndexOf("_f3."))
                        {
                            sZeccyouMotionMaid = sZeccyouMotion + z.Replace("_f_", "_f3_");

                        }
                    }

                    if (MotionOldCheck(sZeccyouMotionMaid) != -1)
                    {
                        zf = true;
                        break;
                    }
                }

                //上記チェックで引っかからなかった場合、「cli」や「kiss」などの文字列を除去してもう一度チェック
                if (!zf)
                {
                    string motion2 = "";
                    int mid = MotionIdCheck(motion);

                    if (maidsState[maidID].baceMotion == "")
                    {
                        //sZeccyouMotion = sZeccyouMotion.Replace("_hibu", "").Replace("_kiss", "").Replace("_cli", "").Replace("_momi", "").Replace("_gr", "");
                        sZeccyouMotion = Regex.Replace(sZeccyouMotion, @"_[^_]{1,}$", ""); //モーション名の最後尾の一節を削除
                    }
                    else
                    {
                        sZeccyouMotion = maidsState[maidID].baceMotion;
                    }

                    foreach (string z in sZeccyouMaidMotion)
                    {
                        sZeccyouMotionMaid = sZeccyouMotion + z;

                        if (Regex.IsMatch(sZeccyouMotion, "harem_") || Regex.IsMatch(sZeccyouMotion, "yuri_"))
                        {
                            if (0 <= sHighExciteMotionBackup.IndexOf("_f."))
                            {
                                sZeccyouMotionMaid = sZeccyouMotion + z;

                            }
                            else if (0 <= sHighExciteMotionBackup.IndexOf("_f2."))
                            {
                                sZeccyouMotionMaid = sZeccyouMotion + z.Replace("_f_", "_f2_");

                            }
                            else if (0 <= sHighExciteMotionBackup.IndexOf("_f3."))
                            {
                                sZeccyouMotionMaid = sZeccyouMotion + z.Replace("_f_", "_f3_");

                            }
                        }

                        if (MotionOldCheck(sZeccyouMotionMaid) != -1)
                        {
                            zf = true;
                            break;
                        }
                    }

                }


                //絶頂モーションに変更
                if (zf)
                {
                    // 強制的に再生
                    //メイドモーション変更
                    MotionChange(maid, sZeccyouMotionMaid + ".anm", false, 0.5f, 1f);
                    maidsState[maidID].zAnimeFileName = sZeccyouMotionMaid + ".anm";

                    MotionChangeAf(maid, sHighExciteMotionBackup, true, 0.5f, 1f); // 終わったら再生する

                    //男のモーション変更
                    ManMotionChange(sZeccyouMotionMaid + ".anm", maidID, false, 0.5f, 1f);
                    ManMotionChangeAf(sHighExciteMotionBackup, maidID, true, 0.5f, 1f); // 終わったら再生する

                }
                else
                {
                    //絶頂モーションがない場合は、現在モーションをフェラ判別用に挿入する
                    maidsState[maidID].zAnimeFileName = maid.body0.LastAnimeFN;
                }
            }
        }


        //複数・百合相手用モーション変更処理
        private void SubMotionChange(int id, string motion, bool loop, bool abs, float cs, float ls)
        {

            int im = 1;
            int im2 = 1;
            if (Regex.IsMatch(motion, "_f2")) im2 = 2;
            if (Regex.IsMatch(motion, "_f3")) im2 = 3;
            if (Regex.IsMatch(motion, "_f4")) im2 = 4;
            foreach (int maidID in vmId)
            {

                if (id == maidID || !LinkMaidCheck(id, maidID)) continue;

                Maid maid = stockMaids[maidID].mem;
                if (im == im2) ++im;
                string t = Regex.Replace(motion, @"_f(|[0-9])\.", "_f" + im + ".");
                t = Regex.Replace(t, @"_f(|[0-9])_once_", "_f" + im + "_once_");
                if (im == 1) t = t.Replace("_f1", "_f");

                if (MotionOldCheck(t) != -1)
                {
                    if (abs)
                    {
                        MotionChange(maid, t, loop, cs, ls);
                    }
                    else
                    {
                        MotionChangeAf(maid, t, loop, cs, ls);
                    }
                    MotionAdjustDo(maidID, t, true, id); //モーションアジャスト実行
                    if (lifeStart >= 5) maidsState[maidID].elItazuraFlag = true;

                }
                else
                {
                    t = Regex.Replace(t, "[a-zA-Z][0-9][0-9]", "");
                    if (MotionOldCheck(t) != -1)
                    {
                        if (abs)
                        {
                            MotionChange(maid, t, loop, cs, ls);
                        }
                        else
                        {
                            MotionChangeAf(maid, t, loop, cs, ls);
                        }
                        MotionAdjustDo(maidID, t, true, id); //モーションアジャスト実行
                        if (lifeStart >= 5) maidsState[maidID].elItazuraFlag = true;

                    }
                    else
                    {
                        break;

                    }
                }
                //タイマーリセット
                maidsState[maidID].motionHoldTime = 0f;
                maidsState[maidID].voiceHoldTime = 0f;
                maidsState[maidID].faceHoldTime = 0;
                maidsState[maidID].MouthHoldTime = 0f;

                ++im;
            }
        }


        //男通常モーション変更処理
        private void ManMotionChange(string motion, int maidID, bool loop, bool old, bool abs, float cs, float ls)
        {

            string t = motion;
            t = Regex.Replace(t, @"_f(|[0-9])\.", "_m.");
            t = Regex.Replace(t, @"_f(|[0-9])_", "_m_");

            //アナルモードの場合、男モーションをアナル用に変更
            if (maidsState[maidID].analMode)
            {
                string bm = maidsState[maidID].analMotion.Replace("a_in_m_once_", "");
                string am = maidsState[maidID].analMotion.Replace("_in_m_once_", "");
                string analMotion = t.Replace(bm, am);
                if (MotionOldCheck(analMotion) != -1)
                {
                    t = analMotion;
                }
                else
                {
                    analMotion = Regex.Replace(analMotion, "[a-zA-Z][0-9][0-9]", "");
                    if (MotionOldCheck(analMotion) != -1) t = analMotion;
                }
            }

            int im2 = 2;
            for (int im = 0; im < SubMans.Length; im++)
            {

                if (!SubMans[im].Visible || MansTg[im] != maidID) continue;
                float fDistance = Vector3.Distance(stockMaids[maidID].mem.transform.position, SubMans[im].transform.position);
                if (fDistance > 1f) continue;

                if ((allFiles.Contains(t.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase) && !old) || (allFilesOld.Contains(t.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase) && old))
                {
                    if (abs)
                    {
                        MotionChange(SubMans[im], t, loop, old, cs, ls);
                    }
                    else
                    {
                        MotionChangeAf(SubMans[im], t, loop, old, cs, ls);
                    }
                }
                else
                {
                    t = Regex.Replace(t, "[a-zA-Z][0-9][0-9]", "");
                    if ((allFiles.Contains(t.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase) && !old) || (allFilesOld.Contains(t.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase) && old))
                    {
                        if (abs)
                        {
                            MotionChange(SubMans[im], t, loop, old, cs, ls);
                        }
                        else
                        {
                            MotionChangeAf(SubMans[im], t, loop, old, cs, ls);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //射精処理
                if (syaseiValue[im] >= 85f)
                {
                    string[] marks = new string[] { "秘部", "秘部", "太股" };
                    if (t.Contains("_shasei"))
                    {
                        bool naka = false;
                        int marksInt = 0;
                        if (t.Contains("_shasei_naka") || t.Contains("_shasei_kuti")) naka = true;
                        if (maidsState[maidID].motionID >= 0) marksInt = maj.syaseiMarks[maidsState[maidID].motionID][im];
                        if (marksInt == 0)
                        {
                            if (t.Contains("asikoki"))
                            {
                                marksInt = 5;
                            }
                            else if (t.Contains("fera") || t.Contains("sixnine"))
                            {
                                marksInt = 3;
                            }
                            else if (t.Contains("tekoki") || t.Contains("paizuri"))
                            {
                                marksInt = 4;
                            }
                            else if (t.Contains("haimen") || t.Contains("kouhaii") || t.Contains("sokui") || t.Contains("sukebeisu_sex") || t.Contains("kakaemzi"))
                            {
                                marksInt = 2;
                            }
                            else
                            {
                                marksInt = 1;
                            }
                        }

                        EffectSyasei(maidID, marksInt, naka);
                        if (!syaseiLock[im]) syaseiValue[im] = 0f;
                    }
                }

                t = Regex.Replace(t, @"_m(|[0-9])\.", "_m" + im2 + ".");
                t = Regex.Replace(t, @"_m(|[0-9])_", "_m" + im2 + "_");
                ++im2;
            }
        }

        //男通常モーション変更処理（新旧自動判別）
        private void ManMotionChange(string motion, int maidID, bool loop, float cs, float ls)
        {

            bool old = MotionOldCheckB(motion);
            ManMotionChange(motion, maidID, loop, old, true, cs, ls);

        }

        //男通常モーション変更処理（メイドモーション自動取得）
        private void ManMotionChange(int maidID, bool loop, float cs, float ls)
        {

            Maid maid = stockMaids[maidID].mem;
            string motion = maid.body0.LastAnimeFN;
            ManMotionChange(motion, maidID, loop, cs, ls);

        }

        //男通常モーション変更処理（現在のモーション再生が終了したあと・新旧自動判別）
        private void ManMotionChangeAf(string motion, int maidID, bool loop, float cs, float ls)
        {

            bool old = MotionOldCheckB(motion);
            ManMotionChange(motion, maidID, loop, old, false, cs, ls);

        }

        //男通常モーション変更処理（現在のモーション再生が終了したあと・メイドモーション自動取得）
        private void ManMotionChangeAf(int maidID, bool loop, float cs, float ls)
        {

            Maid maid = stockMaids[maidID].mem;
            string motion = maid.body0.LastAnimeFN;
            ManMotionChangeAf(motion, maidID, loop, cs, ls);

        }



        //実際にモーションを変更する（新旧自動判断）
        private void MotionChange(Maid maid, string motion, bool loop, float cs, float ls)
        {

            int old = MotionOldCheck(motion);

            if (old == 0)
            {
                maid.CrossFadeAbsolute(motion, GameUty.FileSystem, false, loop, false, cs, ls);
                Console.WriteLine("オダメモーション：" + motion);
            }
            else if (old == 1)
            {
                maid.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, loop, false, cs, ls);
                Console.WriteLine("カスメモーション：" + motion);
            }
            else
            {
                maid.CrossFadeAbsolute(motion, GameUty.FileSystem, false, loop, false, cs, ls);
                Console.WriteLine("対応モーション無し：" + motion);
            }
        }
        //実際にモーションを変更する（新旧指定）
        private void MotionChange(Maid maid, string motion, bool loop, bool old, float cs, float ls)
        {

            if (!old)
            {
                maid.CrossFadeAbsolute(motion, GameUty.FileSystem, false, loop, false, cs, ls);
                Console.WriteLine("オダメモーション：" + motion);
            }
            else
            {
                maid.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, loop, false, cs, ls);
                Console.WriteLine("カスメモーション：" + motion);
            }
        }

        //現在のモーション再生が終了したあとにモーションを変更する（新旧自動判断）
        private void MotionChangeAf(Maid maid, string motion, bool loop, float cs, float ls)
        {

            if (allFiles.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                maid.CrossFade(motion, GameUty.FileSystem, false, loop, true, cs, ls);

            }
            else if (allFilesOld.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                maid.CrossFade(motion, GameUty.FileSystemOld, false, loop, true, cs, ls);

            }
        }
        //現在のモーション再生が終了したあとにモーションを変更する（新旧指定）
        private void MotionChangeAf(Maid maid, string motion, bool loop, bool old, float cs, float ls)
        {

            if (!old)
            {
                maid.CrossFade(motion, GameUty.FileSystem, false, loop, true, cs, ls);
            }
            else
            {
                maid.CrossFade(motion, GameUty.FileSystemOld, false, loop, true, cs, ls);
            }
        }

        //モーションの新旧をチェックする
        private int MotionOldCheck(string motion)
        {

            if (allFiles.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                return 0;
            }
            else if (allFilesOld.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        private bool MotionOldCheckB(string motion)
        {

            if (allFiles.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //アニメーションステータスを取得する
        private AnimationState GetCurrentAnimationState(Maid maid)
        {
            AnimationState state = null;

            // アニメーション取得
            Animation anime = maid.body0.GetAnimation();
            if (anime != null)
            {
                // アニメーション状態取得
                state = anime[maid.body0.LastAnimeFN];
            }
            return state;
        }

        //モーションの速度を変更する
        private bool AnimationSpeedChange(Maid maid, float changeSpeed)
        {

            AnimationState maidAniState = GetCurrentAnimationState(maid);
            if (maidAniState != null)
            {
                if (maidAniState.enabled && (maidAniState.wrapMode == WrapMode.Loop || maidAniState.wrapMode == WrapMode.Once || maidAniState.wrapMode == WrapMode.Default))
                {
                    maidAniState.speed = changeSpeed;
                    return true;
                }
            }
            return false;
        }


        //モーションチェンジ関係終了-----------------------




        //-------------------------------------------------
        //モーションセット関係-----------------------------
        private bool ms_Overwrite = false;
        private int msCategory = 0;
        private int msErrer = 0;
        private string[] msErrerText = new string[] { "", "モーションセット名が空白のため保存できません", "上書きする場合は『上書／ｸﾘｱ』にチェックを入れて下さい", "クリアする場合は『上書／ｸﾘｱ』にチェックを入れて下さい" };

        MotionSet_Xml MSX = new MotionSet_Xml();
        public class MotionSet_Xml
        {
            public string saveMotionSetName = "";
            public List<List<string>> saveMotionSet = new List<List<string>>();

        }

        //モーションセットXMLファイルを読み込む
        private void MotionSetLoad(string xml, int maidID)
        {

            MotionSetLoad(xml);

            //読み込んだ情報を挿入
            maidsState[maidID].editMotionSetName = MSX.saveMotionSetName;
            maidsState[maidID].editMotionSet = new List<List<string>>(MSX.saveMotionSet);
        }

        private void MotionSetLoad(string xml)
        {

            //保存先のファイル名
            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EditMotionSet\" + xml;
            Console.WriteLine(fileName);

            if (System.IO.File.Exists(fileName))
            {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MotionSet_Xml));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));

                //XMLファイルから読み込み、逆シリアル化する
                MSX = (MotionSet_Xml)serializer.Deserialize(sr);

                //ファイルを閉じる
                sr.Close();
                Console.WriteLine("読み込み完了");
            }
        }

        //モーションセットをXMLファイルに保存する
        private void MotionSetSave()
        {

            // フォルダ確認
            if (!System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditMotionSet\"))
            {
                //ない場合はフォルダ作成
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditMotionSet");
            }


            if (MSX.saveMotionSetName == "")
            {  //ボイスセット名が空白の場合保存しない
                msErrer = 1;

            }
            else
            {
                //保存先のファイル名
                string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EditMotionSet\ems_" + MSX.saveMotionSetName + @".xml";

                if (System.IO.File.Exists(fileName) && !ms_Overwrite)
                {  //上書きのチェック
                    msErrer = 2;

                }
                else
                {

                    //XmlSerializerオブジェクトを作成
                    //オブジェクトの型を指定する
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MotionSet_Xml));

                    //書き込むファイルを開く（UTF-8 BOM無し）
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));

                    //シリアル化し、XMLファイルに保存する
                    serializer.Serialize(sw, MSX);
                    //ファイルを閉じる
                    sw.Close();

                    ms_Overwrite = false;
                    msErrer = 0;
                }
            }
        }

        //モーションセット再生処理
        private void MotionSetPlay(int maidID, string s, float t)
        {

            Maid maid = stockMaids[maidID].mem;
            string motion = s.Replace("[S]", "").Replace("[L]", "").Replace("_ONCE_", "_once_");

            MotionAdjustDo(maidID, motion, true, -1);

            if (s.Contains("[S]") || motion.Contains("_once_"))
            {
                maidsState[maidID].mOnceFlag = true;
                maidsState[maidID].mOnceBack = motion;
                if (motion.Contains("_once_") && MotionOldCheck(motion.Replace("f_once_", "taiki_f")) != -1)
                {
                    maidsState[maidID].mOnceBack = motion.Replace("f_once_", "taiki_f");
                }
            }
            else
            {
                maidsState[maidID].mOnceFlag = false;
                maidsState[maidID].mOnceBack = "";
                if (maidsState[maidID].vStateMajor == 20)
                { //強度に合わせて変更
                    motion = motion.Replace("_1_", "_2_");
                }
                else if (maidsState[maidID].vStateMajor == 30)
                {
                    motion = motion.Replace("_1_", "_3_");
                }
            }

            MotionChange(maid, motion, !maidsState[maidID].mOnceFlag, t, 1f);
            ManMotionChange(motion, maidID, !maidsState[maidID].mOnceFlag, t, 1f);
            if ((motion.Contains("yuri") || motion.Contains("harem") || motion.Contains("wfera"))) SubMotionChange(maidID, motion, !maidsState[maidID].mOnceFlag, true, t, 1f);

            //タイマーリセット
            maidsState[maidID].motionHoldTime = UnityEngine.Random.Range(200f, 600f);
            maidsState[maidID].voiceHoldTime = 0f;
            maidsState[maidID].faceHoldTime = 0f;
            maidsState[maidID].MouthHoldTime = 0f;

        }


        private void MotionSetChange(int maidID)
        {

            if (maidsState[maidID].editMotionSetName == "") return;
            maidsState[maidID].msTime1 -= timerRate;

            //シングルモーション後の処理
            if (maidsState[maidID].mOnceFlag)
            {
                Animation anim = stockMaids[maidID].mem.body0.GetAnimation();
                if (!anim.isPlaying)
                {
                    maidsState[maidID].msTime2 = 1f;
                    maidsState[maidID].mOnceFlag = false;
                    if (MotionOldCheckB(maidsState[maidID].mOnceBack))
                    {
                        stockMaids[maidID].mem.CrossFadeAbsolute(maidsState[maidID].mOnceBack, GameUty.FileSystemOld, false, true, false, 0f, 1f);
                    }
                    else
                    {
                        stockMaids[maidID].mem.CrossFadeAbsolute(maidsState[maidID].mOnceBack, GameUty.FileSystem, false, true, false, 0f, 1f);
                    }
                }
                return;
            }

            //カテゴリ変更
            if (maidsState[maidID].msTime1 < 0)
            {
                maidsState[maidID].msCategory = UnityEngine.Random.Range(0, maidsState[maidID].editMotionSet.Count);
                maidsState[maidID].msTime1 = UnityEngine.Random.Range(4000f, 6000f) + ((maidsState[maidID].editMotionSet[maidsState[maidID].msCategory].Count - 5) * 600);

                //強度に合わせてモーション名を変更
                string cMotion = maidsState[maidID].editMotionSet[maidsState[maidID].msCategory][0];
                if (maidsState[maidID].vStateMajor == 20)
                {
                    cMotion = cMotion.Replace("_1_", "_2_");
                }
                else if (maidsState[maidID].vStateMajor == 30)
                {
                    cMotion = cMotion.Replace("_1_", "_3_");
                }

                string inMotion = MotionCheckTokusyu(maidsState[maidID].editMotionSet[maidsState[maidID].msCategory][0], sInMaidMotion); //挿入モーションがあるかチェック
                if (inMotion == "Non" || inMotion == maidsState[maidID].inMotion)
                {
                    MotionSetPlay(maidID, cMotion, 0.7f);
                    maidsState[maidID].msTime2 = 90f;

                }
                else
                {
                    MotionAdjustDo(maidID, maidsState[maidID].editMotionSet[maidsState[maidID].msCategory][0], true, -1);

                    MotionChange(stockMaids[maidID].mem, inMotion + ".anm", false, 0.7f, 1f);
                    ManMotionChange(inMotion + ".anm", maidID, false, 0.7f, 1f);

                    // 終わったら再生する
                    MotionChangeAf(stockMaids[maidID].mem, cMotion, true, 0.7f, 1f);
                    ManMotionChangeAf(cMotion, maidID, true, 0.7f, 1f);

                    //百合・ハーレム相手のモーション変更
                    if ((inMotion.Contains("yuri") || inMotion.Contains("harem") || inMotion.Contains("wfera")))
                    {
                        SubMotionChange(maidID, inMotion + ".anm", false, true, 0.7f, 1f);
                        SubMotionChange(maidID, cMotion, true, false, 0.7f, 1f);
                    }
                    if (maidsState[maidID].uDatsu == 2 && maj.hkupa1[maidsState[maidID].motionID] > 50f)
                    {
                        maidsState[maidID].uDatsuValue1 = 0f;
                        maidsState[maidID].uDatsu = 0;
                        try { VertexMorph_FromProcItem(stockMaids[maidID].mem.body0, "pussy_uterus_prolapse", 0f); } catch { /*LogError(ex);*/ }
                    }
                    maidsState[maidID].msTime2 = 600f;

                    //タイマーリセット
                    maidsState[maidID].motionHoldTime = UnityEngine.Random.Range(200f, 600f);
                    maidsState[maidID].voiceHoldTime = 0f;
                    maidsState[maidID].faceHoldTime = 0f;
                    maidsState[maidID].MouthHoldTime = 0f;
                }
                maidsState[maidID].inMotion = inMotion;
            }

            //モーション変更
            if (maidsState[maidID].msTime2 < 0)
            {
                int i = UnityEngine.Random.Range(0, maidsState[maidID].editMotionSet[maidsState[maidID].msCategory].Count);
                MotionSetPlay(maidID, maidsState[maidID].editMotionSet[maidsState[maidID].msCategory][i], 0.7f);

                maidsState[maidID].msTime2 = UnityEngine.Random.Range(1500f, 2000f);
                if (maidsState[maidID].msTime1 < maidsState[maidID].msTime2) maidsState[maidID].msTime1 = maidsState[maidID].msTime2 - 10f;
            }

            maidsState[maidID].msTime2 -= timerRate;

        }

        private void MotionSetClear(int maidID)
        {
            maidsState[maidID].editMotionSetName = "";
            maidsState[maidID].editMotionSet = new List<List<string>>();
            maidsState[maidID].msTime1 = 0f;
            maidsState[maidID].msTime2 = 0f;
            maidsState[maidID].msCategory = 0;
            maidsState[maidID].mOnceFlag = false;
            maidsState[maidID].mOnceBack = "";
        }


        //モーションセット関係終了----------------------------




        //-------------------------------------------------
        //演出関係-----------------------------------------

        //吐息
        private void EffectToiki(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            if (maidsState[maidID].kaikanLevel > 3 && !maidsState[maidID].fToiki1)
            {
                maid.AddPrefab("Particle/pToiki", "夜伽_吐息", "Bip01 Head", new Vector3(0.042f, 0.076f, 0f), new Vector3(-90f, 90f, 0f));
                maidsState[maidID].fToiki1 = true;
            }
            if (maidsState[maidID].vStateMajor == 10 && maidsState[maidID].fToiki1)
            {
                maid.DelPrefab("夜伽_吐息");
                maidsState[maidID].fToiki1 = false;
            }

            if (maidsState[maidID].kaikanLevel > 6)
            {
                if (!maidsState[maidID].fToiki2)
                {
                    maid.AddPrefab("Particle/pToiki", "夜伽_吐息2", "Bip01 Head", new Vector3(0.042f, 0.076f, 0f), new Vector3(-90f, 90f, 0f));
                    maidsState[maidID].fToiki2 = true;
                }
            }
            else if (maidsState[maidID].fToiki2)
            {
                maid.DelPrefab("夜伽_吐息2");
                maidsState[maidID].fToiki2 = false;
            }
        }


        //愛液
        private void EffectAieki(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            if (maidsState[maidID].exciteLevel > 1 && !maidsState[maidID].fAieki1)
            {
                maid.AddPrefab("Particle/pPistonEasy_cm3D2", "夜伽_愛液1", "_IK_vagina", new Vector3(0f, 0f, 0.01f), new Vector3(0f, -180f, 90f));
                maidsState[maidID].fAieki1 = true;
            }
            else if (maidsState[maidID].exciteLevel <= 1 && maidsState[maidID].fAieki1)
            {
                maid.DelPrefab("夜伽_愛液1");
                maidsState[maidID].fAieki1 = false;
            }

            if (maidsState[maidID].exciteLevel > 2 && !maidsState[maidID].fAieki2)
            {
                maid.AddPrefab("Particle/pPistonNormal_cm3D2", "夜伽_愛液2", "_IK_vagina", new Vector3(0f, 0f, 0.01f), new Vector3(0f, -180f, 90f));
                maidsState[maidID].fAieki2 = true;
            }
            else if (maidsState[maidID].exciteLevel <= 2 && maidsState[maidID].fAieki2)
            {
                maid.DelPrefab("夜伽_愛液2");
                maidsState[maidID].fAieki2 = false;
            }

            if (maidsState[maidID].exciteLevel > 3 && !maidsState[maidID].fAieki3)
            {
                maid.AddPrefab("Particle/pPistonHard_cm3D2", "夜伽_愛液3", "_IK_vagina", new Vector3(0f, 0f, 0.01f), new Vector3(0f, -180f, 90f));
                maidsState[maidID].fAieki3 = true;
            }
            else if (maidsState[maidID].exciteLevel <= 3 && maidsState[maidID].fAieki3)
            {
                maid.DelPrefab("夜伽_愛液3");
                maidsState[maidID].fAieki3 = false;
            }

            if (maidsState[maidID].vStateMajor == 10 || maidsState[maidID].vStateMajor == 40)
            {
                if (maidsState[maidID].fAieki1)
                {
                    maid.DelPrefab("夜伽_愛液1");
                    maidsState[maidID].fAieki1 = false;
                }
                if (maidsState[maidID].fAieki2)
                {
                    maid.DelPrefab("夜伽_愛液2");
                    maidsState[maidID].fAieki2 = false;
                }
                if (maidsState[maidID].fAieki3)
                {
                    maid.DelPrefab("夜伽_愛液3");
                    maidsState[maidID].fAieki3 = false;
                }
            }
        }


        //おしっこ
        private void EffectNyo(int maidID, float volume)
        {
            if (!cfgw.NyoEnabled) return;
            Maid maid = stockMaids[maidID].mem;
            maid.AddPrefab("Particle/pNyou_cm3D2", "pNyou_cm3D2", "_IK_vagina", new Vector3(0f, -0.047f, 0.011f), new Vector3(20.0f, -180.0f, 180.0f));
            GameMain.Instance.SoundMgr.PlaySe("SE011.ogg", false);

            maidsState[maidID].nyoTotal1 += 1;
            maidsState[maidID].nyoTotal2 += volume;
            maidsState[maidID].nyoVolume -= volume;
        }


        //潮吹き
        private void EffectSio(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            if (!cfgw.SioEnabled || !maidsState[maidID].fSio) return;

            if (!maidsState[maidID].fSio2)
            {
                maidsState[maidID].fSio2 = true;
                maidsState[maidID].sioTotal1 += 1;
            }
            if (maidsState[maidID].sioTime2 <= 0)
            {
                maid.AddPrefab("Particle/pSio2_cm3D2", "pSio2_cm3D2", "_IK_vagina", new Vector3(0f, 0f, -0.01f), new Vector3(0f, 180.0f, 0f));
                maidsState[maidID].sioTime2 = UnityEngine.Random.Range(10f, 90f);
                //GameMain.Instance.SoundMgr.PlaySe("se061.ogg", false);

                maidsState[maidID].sioTotal2 += UnityEngine.Random.Range(3f, 5f);
            }

            float value = 60f;
            try
            {
                VertexMorph_FromProcItem(maid.body0, "nyodokupa", value / 100f);
            }
            catch { /*LogError(ex);*/ }

            maidsState[maidID].sioTime -= timerRate;
            maidsState[maidID].sioTime2 -= timerRate;

            if (maidsState[maidID].sioTime <= 0)
            {
                maidsState[maidID].fSio = false;
                maidsState[maidID].fSio2 = false;
                maidsState[maidID].sioTime2 = 0;
                try
                {
                    VertexMorph_FromProcItem(maid.body0, "nyodokupa", 0f);
                }
                catch { /*LogError(ex);*/ }
            }
        }


        //射精
        private void EffectSyasei(int maidID, int mode, bool naka)
        {

            if (mode == 6) return;
            string[] marks = new string[] { "", "", "" };
            int i = 3;

            switch (mode)
            {
                default: //指定無し
                    if (naka)
                    {
                        if (!maidsState[maidID].analMode)
                        {
                            marks = new string[] { "", "秘部", "秘部" };
                            i = 0;
                        }
                        if (maidsState[maidID].analMode)
                        {
                            marks = new string[] { "", "尻", "尻" };
                            i = 1;
                        }
                    }
                    if (!naka) marks = new string[] { "太股", "腹", "胸" };
                    break;

                case 1: //挿入 前
                    if (naka)
                    {
                        if (!maidsState[maidID].analMode)
                        {
                            marks = new string[] { "", "秘部", "秘部" };
                            i = 0;
                        }
                        if (maidsState[maidID].analMode)
                        {
                            marks = new string[] { "", "尻", "尻" };
                            i = 1;
                        }
                    }
                    if (!naka) marks = new string[] { "太股", "腹", "胸" };
                    break;

                case 2: //挿入 後
                    if (naka)
                    {
                        if (!maidsState[maidID].analMode)
                        {
                            marks = new string[] { "", "秘部", "秘部" };
                            i = 0;
                        }
                        if (maidsState[maidID].analMode)
                        {
                            marks = new string[] { "", "尻", "尻" };
                            i = 1;
                        }
                    }
                    if (!naka) marks = new string[] { "太股", "尻", "背中" };
                    break;

                case 3: //フェラ
                    if (naka)
                    {
                        marks = new string[] { "", "口元", "口元" };
                        i = 2;
                    }
                    if (!naka) marks = new string[] { "顔", "顔", "胸" };
                    break;

                case 4: //手コキ
                    marks = new string[] { "顔", "胸", "腹" };
                    break;

                case 5: //足コキ
                    marks = new string[] { "太股", "太股", "" };
                    break;

                case 7: //アナル 前
                    if (naka)
                    {
                        marks = new string[] { "", "尻", "尻" };
                        i = 1;
                    }
                    if (!naka) marks = new string[] { "太股", "腹", "胸" };
                    break;

                case 8: //アナル 後
                    if (naka)
                    {
                        marks = new string[] { "", "尻", "尻" };
                        i = 1;
                    }
                    if (!naka) marks = new string[] { "太股", "尻", "背中" };
                    break;
            }

            StartCoroutine(EffectSyasei(maidID, marks, i));
        }


        private IEnumerator EffectSyasei(int maidID, string[] marks, int i)
        {

            maidsState[maidID].syaseiTotal1[i] += 1;
            foreach (string m in marks)
            {
                yield return new WaitForSeconds(1f);  // 1秒待つ

                GameMain.Instance.SoundMgr.PlaySe("se016.ogg", false);
                maidsState[maidID].syaseiTotal2[i] += UnityEngine.Random.Range(1f, 2f);
                if (m == "太股")
                {
                    EffectSeieki(maidID, m);
                    EffectSeieki(maidID, m);
                    EffectSeieki(maidID, m);
                }
                else if (m == "背中" || m == "尻" || m == "腹" || m == "胸")
                {
                    EffectSeieki(maidID, m);
                    EffectSeieki(maidID, m);
                }
                else
                {
                    EffectSeieki(maidID, m);
                }
            }

            //エロステータス更新
            SaveEroState(maidID);
        }

        private bool SyaseiCheck(int maidID, float check)
        {
            for (int im = 0; im < SubMans.Length; im++)
            {
                if (!SubMans[im].Visible || MansTg[im] != maidID) continue;
                float fDistance = Vector3.Distance(stockMaids[maidID].mem.transform.position, SubMans[im].transform.position);
                if (fDistance > 1f) continue;
                if (syaseiValue[im] >= check) return true;
            }
            return false;
        }


        public class SeiekiInfo
        {

            private String slotName;
            private int matNo;
            private int layer;
            private String res;
            private int minX;
            private int maxX;
            private int minY;
            private int maxY;
            private float minRot;
            private float maxRot;
            private float minScale;
            private float maxScale;

            public SeiekiInfo(String slotName, int matNo, int layer, String res, int minX, int maxX, int minY, int maxY, float minRot, float maxRot, float minScale, float maxScale)
            {
                this.slotName = slotName;
                this.matNo = matNo;
                this.layer = layer;
                this.res = res;
                this.minX = minX;
                this.maxX = maxX;
                this.minY = minY;
                this.maxY = maxY;
                this.minRot = minRot;
                this.maxRot = maxRot;
                this.minScale = minScale;
                this.maxScale = maxScale;
            }


            public String SlotName
            {
                get { return this.slotName; }
            }
            public int MatNo
            {
                get { return this.matNo; }
            }
            public int Layer
            {
                get { return this.layer; }
            }
            public String Res
            {
                get { return this.res; }
            }

            public String GetFilName()
            {
                string[] strArray = this.res.Split(':');
                return "res:" + strArray[UnityEngine.Random.Range(0, strArray.Length)];
            }

            public int MinX
            {
                get { return this.minX; }
            }

            public int MaxX
            {
                get { return this.maxX; }
            }

            public int GetX()
            {
                return UnityEngine.Random.Range(this.minX, this.maxX);
            }

            public int MinY
            {
                get { return this.minY; }
            }

            public int MaxY
            {
                get { return this.maxY; }
            }

            public int GetY()
            {
                return (int)UnityEngine.Random.Range(this.minY, this.maxY);
            }

            public float MinRot
            {
                get { return this.minRot; }
            }

            public float MaxRot
            {
                get { return this.maxRot; }
            }

            public float GetRot()
            {
                return UnityEngine.Random.Range(this.minRot, this.maxRot);
            }

            public float MinScale
            {
                get { return this.minScale; }
            }

            public float MaxScale
            {
                get { return this.maxScale; }
            }

            public float GetScale()
            {
                return UnityEngine.Random.Range(this.minScale, this.maxScale);
            }
        }

        private static readonly List<SeiekiInfo> KaoMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("head", 5, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003", 378, 452, 628, 820, 330, 360, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r", 572, 646, 628, 820, 0, 30, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe004:Seieki/spe005", 429, 593, 575, 672, 340, 380, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe006:Seieki/spe007", 452, 572, 414, 566, 340, 380, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001:Seieki/spe001r:Seieki/spe002:Seieki/spe002R:Seieki/spe004", 469, 558, 706, 864, 340, 380, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003", 378, 452, 628, 820, 315, 405, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r", 572, 646, 628, 820, 315, 405, 1.5f, 1.5f),
        };

        private static readonly List<SeiekiInfo> MuneMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009", 412, 449, 428, 470, 10, 20, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009", 397, 404, 444, 487, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r", 455, 492, 428, 470, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009", 532, 569, 428, 470, 10, 20, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r", 575, 612, 428, 470, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009", 620, 627, 444, 487, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005:Seieki/spe008:Seieki/spe008r:Seieki/spe010:Seieki/spe012:Seieki/spe012r", 509, 515, 420, 479, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe011:Seieki/spe014", 415, 443, 492, 517, 350, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe011r:Seieki/spe014r", 461, 500, 492, 517, 0, 10, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe011:Seieki/spe014", 524, 563, 492, 517, 350, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe011r:Seieki/spe014r", 581, 609, 492, 517, 0, 10, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009", 412, 449, 428, 470, 10, 20, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r", 455, 492, 428, 470, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009", 532, 569, 428, 470, 10, 20, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r", 575, 612, 428, 470, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005:Seieki/spe008:Seieki/spe008r:Seieki/spe010:Seieki/spe012:Seieki/spe012r", 509, 515, 420, 479, 350, 370, 0.5f, 0.5f),
        };

        private static readonly List<SeiekiInfo> KuchimotoMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("head", 5, 18, "Seieki/spe001:Seieki/spe008:Seieki/spe009", 438, 483, 742, 857, 350, 360, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001:Seieki/spe008:Seieki/spe009", 398, 442, 768, 876, 350, 360, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001r:Seieki/spe008r:Seieki/spe009r", 541, 586, 742, 857, 0, 10, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe001r:Seieki/spe008r:Seieki/spe009r", 582, 626, 768, 876, 0, 10, 1.5f, 1.5f),
            new SeiekiInfo("head", 5, 18, "Seieki/spe006:Seieki/spe007", 473, 550, 826, 861, 0, 0, 1.5f, 1.5f),
        };

        private static readonly List<SeiekiInfo> SenakaMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 424, 479, 183, 236, 170, 210, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 414, 469, 256, 314, 170, 210, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 483, 503, 248, 318, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 429, 458, 77, 169, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 470, 499, 77, 169, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 521, 541, 248, 318, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 555, 610, 256, 314, 150, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 545, 600, 183, 236, 150, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 525, 554, 77, 169, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 566, 595, 77, 169, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe004r:Seieki/spe013:Seieki/spe013r:Seieki/spe014:Seieki/spe014r", 498, 525, 174, 241, 180, 180, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 483, 503, 248, 318, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 521, 541, 248, 318, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe004r:Seieki/spe013:Seieki/spe013r:Seieki/spe014:Seieki/spe014r", 498, 525, 174, 241, 180, 180, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 470, 499, 77, 169, 170, 190, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 525, 554, 77, 169, 170, 190, 0.7f, 0.7f),
        };

        private static readonly List<SeiekiInfo> SiriMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005:Seieki/spe010:Seieki/spe012:Seieki/spe013", 229, 240, 870, 877, 325, 345, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005r:Seieki/spe010r:Seieki/spe012:Seieki/spe013:Seieki/spe014", 215, 243, 836, 847, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe005r:Seieki/spe010r:Seieki/spe012r:Seieki/spe013r:Seieki/spe014r", 257, 285, 828, 839, 330, 360, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 218, 254, 778, 823, 330, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe007r:Seieki/spe013r:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015", 232, 258, 760, 768, 330, 360, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe005r:Seieki/spe010r:Seieki/spe012r:Seieki/spe013r", 784, 795, 870, 877, 15, 35, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe005:Seieki/spe010:Seieki/spe012r:Seieki/spe013r:Seieki/spe014r", 781, 809, 836, 847, 360, 330, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005:Seieki/spe010:Seieki/spe012:Seieki/spe013:Seieki/spe014", 739, 767, 828, 839, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014r", 733, 769, 778, 817, 0, 30, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe007:Seieki/spe013:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015", 766, 792, 760, 768, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 255, 291, 778, 817, 330, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014r", 771, 806, 778, 823, 0, 30, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 263, 275, 850, 860, 330, 360, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014r", 749, 761, 850, 860, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005r:Seieki/spe010r:Seieki/spe012:Seieki/spe013:Seieki/spe014", 215, 243, 836, 847, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe005r:Seieki/spe010r:Seieki/spe012r:Seieki/spe013r:Seieki/spe014r", 257, 285, 828, 839, 330, 360, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 218, 254, 778, 823, 330, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe007r:Seieki/spe013r:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015", 232, 258, 760, 768, 330, 360, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004r:Seieki/spe005:Seieki/spe010:Seieki/spe012r:Seieki/spe013r:Seieki/spe014r", 781, 809, 836, 847, 360, 330, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe005:Seieki/spe010:Seieki/spe012:Seieki/spe013:Seieki/spe014", 739, 767, 828, 839, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014r", 733, 769, 778, 817, 0, 30, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe007:Seieki/spe013:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015:Seieki/spe015", 766, 792, 760, 768, 0, 30, 0.4f, 0.4f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 255, 291, 778, 817, 330, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014r", 771, 806, 778, 823, 0, 30, 0.5f, 0.5f),
        };

        private static readonly List<SeiekiInfo> HaraMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("body", 0, 18, "Seieki/spe004:Seieki/spe004r:Seieki/spe005:Seieki/spe005r:Seieki/spe010:Seieki/spe010r:Seieki/spe012:Seieki/spe012r:Seieki/spe013:Seieki/spe013r", 466, 558, 712, 774, 350, 370, 1.0f, 1.0f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014", 458, 489, 735, 801, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014", 412, 441, 722, 774, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014", 455, 482, 663, 705, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe002:Seieki/spe002r:Seieki/spe007:Seieki/spe007r:Seieki/spe013:Seieki/spe013r", 466, 558, 808, 821, 350, 370, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 535, 566, 735, 801, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 583, 612, 722, 774, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 542, 569, 663, 705, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe001r:Seieki/spe002:Seieki/spe002r:Seieki/spe007:Seieki/spe007r:Seieki/spe008:Seieki/spe008r:Seieki/spe009:Seieki/spe009r:Seieki/spe011:Seieki/spe011r:Seieki/spe014:Seieki/spe014r", 501, 523, 655, 694, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe014", 472, 494, 609, 648, 350, 370, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe014r", 530, 552, 609, 648, 350, 370, 0.7f, 0.7f),
        };

        private static readonly List<SeiekiInfo> HutomomoMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe009:Seieki/spe014", 97, 110, 73, 124, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe013:Seieki/spe014", 117, 130, 68, 119, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe013r:Seieki/spe014r", 137, 150, 68, 119, 350, 370, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe013r:Seieki/spe014r", 159, 172, 75, 126, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe009r:Seieki/spe014r", 179, 192, 65, 116, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe009:Seieki/spe014", 114, 127, 127, 178, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 137, 150, 136, 187, 355, 360, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe013r:Seieki/spe014r", 157, 170, 134, 182, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe009:Seieki/spe014", 121, 134, 184, 235, 10, 25, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 148, 161, 190, 241, 10, 20, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe013r:Seieki/spe014r", 173, 186, 178, 229, 10, 20, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe009:Seieki/spe014", 134, 147, 249, 287, 350, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 163, 176, 249, 287, 10, 20, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe009r:Seieki/spe014r", 190, 201, 129, 170, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 230, 243, 44, 95, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe014", 258, 277, 34, 74, 340, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe014", 255, 268, 80, 122, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe007:Seieki/spe008:Seieki/spe014", 267, 280, 125, 152, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 239, 248, 113, 142, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe008:Seieki/spe009:Seieki/spe014", 253, 261, 151, 181, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 225, 231, 125, 147, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe008:Seieki/spe014", 266, 285, 175, 213, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe007:Seieki/spe008:Seieki/spe014", 246, 259, 211, 247, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe007:Seieki/spe008:Seieki/spe014", 22, 29, 66, 122, 340, 360, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe009r:Seieki/spe014r", 914, 927, 73, 124, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe011r:Seieki/spe013r:Seieki/spe014r", 894, 907, 68, 119, 0, 10, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe013r:Seieki/spe014", 874, 887, 68, 119, 350, 370, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe013:Seieki/spe014", 852, 865, 75, 126, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe009:Seieki/spe014", 832, 845, 65, 116, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe009r:Seieki/spe014r", 897, 910, 127, 178, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 874, 887, 136, 187, 0, 5, 0.7f, 0.7f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe013:Seieki/spe014", 854, 867, 134, 182, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe009r:Seieki/spe014r", 890, 903, 184, 235, 335, 350, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe006r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 863, 876, 190, 241, 340, 350, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe011:Seieki/spe013:Seieki/spe014", 838, 851, 178, 229, 340, 350, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe009r:Seieki/spe014r", 877, 890, 249, 287, 0, 10, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe006:Seieki/spe007:Seieki/spe008:Seieki/spe009:Seieki/spe014", 848, 861, 249, 287, 340, 350, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe003:Seieki/spe007:Seieki/spe009:Seieki/spe014", 823, 834, 129, 170, 350, 360, 0.6f, 0.6f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 781, 794, 44, 95, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe014r", 747, 766, 34, 74, 0, 20, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe014r", 756, 769, 80, 122, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe007r:Seieki/spe008r:Seieki/spe014r", 744, 757, 125, 152, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 776, 785, 113, 142, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 763, 771, 151, 181, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe003r:Seieki/spe007r:Seieki/spe008r:Seieki/spe009r:Seieki/spe014r", 793, 799, 125, 147, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe008r:Seieki/spe014r", 739, 785, 175, 213, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe007r:Seieki/spe008r:Seieki/spe014r", 765, 778, 211, 247, 350, 370, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe007r:Seieki/spe008r:Seieki/spe014r", 995, 1002, 66, 122, 0, 20, 0.5f, 0.5f),
        };

        private static readonly List<SeiekiInfo> HibuMarks = new List<SeiekiInfo>(){
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe002:Seieki/spe009:Seieki/spe014", 472, 497, 874, 921, 355, 365, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001r:Seieki/spe002r:Seieki/spe009r:Seieki/spe014r", 527, 552, 874, 921, 355, 365, 0.5f, 0.5f),
            new SeiekiInfo("body", 0, 18, "Seieki/spe001:Seieki/spe001r:Seieki/spe002:Seieki/spe002r:Seieki/spe009:Seieki/spe009r:Seieki/spe014:Seieki/spe014r", 503, 520, 866, 906, 355, 365, 0.5f, 0.5f),
        };

        private void EffectSeieki(int maidID, string marks)
        {

            int random;
            SeiekiInfo info = null;
            Maid maid = stockMaids[maidID].mem;

            switch (marks)
            {
                case "顔":
                    random = UnityEngine.Random.Range(0, KaoMarks.Count);
                    info = KaoMarks[random];
                    break;

                case "胸":
                    random = UnityEngine.Random.Range(0, MuneMarks.Count);
                    info = MuneMarks[random];
                    break;

                case "口元":
                    random = UnityEngine.Random.Range(0, KuchimotoMarks.Count);
                    info = KuchimotoMarks[random];
                    break;

                case "背中":
                    random = UnityEngine.Random.Range(0, SenakaMarks.Count);
                    info = SenakaMarks[random];
                    break;

                case "尻":
                    random = UnityEngine.Random.Range(0, SiriMarks.Count);
                    info = SiriMarks[random];
                    break;

                case "腹":
                    random = UnityEngine.Random.Range(0, HaraMarks.Count);
                    info = HaraMarks[random];
                    break;

                case "太股":
                    random = UnityEngine.Random.Range(0, HutomomoMarks.Count);
                    info = HutomomoMarks[random];
                    break;

                case "秘部":
                    random = UnityEngine.Random.Range(0, HibuMarks.Count);
                    info = HibuMarks[random];
                    break;

                default:
                    return;
            }


            int x = info.GetX();
            int y = info.GetY();
            float r = info.GetRot();
            float s = info.GetScale();
            String fileName = info.GetFilName();

            maid.body0.MulTexSet(
                info.SlotName,
                info.MatNo,
                "_MainTex",
                info.Layer,
                fileName,
                GameUty.SystemMaterial.Alpha,
                true,
                x,
                y,
                r,
                s,
                false,
                null,
                1f,
                1024);

            maid.body0.MulTexSet(
                info.SlotName,
                info.MatNo,
                "_ShadowTex",
                info.Layer,
                fileName,
                GameUty.SystemMaterial.Alpha,
                true,
                x,
                y,
                r,
                s,
                false,
                null,
                1f,
                1024);

            maid.body0.MulTexProc(info.SlotName);

        }


        //瞳操作
        private void EffectAhe(int maidID, float sp)
        {

            Vector3 vl;
            Vector3 vr;
            Maid maid = stockMaids[maidID].mem;
            float aheValue3 = maidsState[maidID].aheValue2;

            if (!cfgw.AheEnabled || maidsState[maidID].vStateMajor == 10)
            {
                if (maidsState[maidID].aheResetFlag)
                {
                    vl = maid.body0.trsEyeL.localPosition;
                    vr = maid.body0.trsEyeR.localPosition;
                    maid.body0.trsEyeL.localPosition = new Vector3(vl.x, Math.Max((maidsState[maidID].fAheDefEyeL + 0f) / fEyePosToSliderMul, 0f), vl.z);
                    maid.body0.trsEyeR.localPosition = new Vector3(vr.x, Math.Min((maidsState[maidID].fAheDefEyeR - 0f) / fEyePosToSliderMul, 0f), vr.z);
                    maidsState[maidID].fAheDefEyeL = -9999f;
                    maidsState[maidID].fAheDefEyeR = -9999f;
                    maidsState[maidID].aheResetFlag = false;
                }
                return;
            }

            if (maidsState[maidID].fAheDefEyeL < -1000) maidsState[maidID].fAheDefEyeL = maid.body0.trsEyeL.localPosition.y * fEyePosToSliderMul;
            if (maidsState[maidID].fAheDefEyeR < -1000) maidsState[maidID].fAheDefEyeR = maid.body0.trsEyeR.localPosition.y * fEyePosToSliderMul;

            if (maidsState[maidID].orgasmCmb > 0)
            {
                if (maidsState[maidID].boostValue - 15 > 0 && maidsState[maidID].exciteLevel >= 2)
                {
                    aheValue3 = maidsState[maidID].aheValue2 + maidsState[maidID].boostValue / 3;
                    if (maidsState[maidID].stunFlag) aheValue3 += 25;
                }
                if (aheValue3 > 60) aheValue3 = 60;

                if (maidsState[maidID].aheValue < aheValue3)
                {
                    maidsState[maidID].aheValue += 0.1f * timerRate * sp;
                }
                else if (maidsState[maidID].aheValue > aheValue3)
                {
                    maidsState[maidID].aheValue -= 0.1f * timerRate * sp;
                }
            }
            else if ((maidsState[maidID].boostValue - 15 > 0 && maidsState[maidID].exciteLevel >= 2) || maidsState[maidID].stunFlag)
            {
                aheValue3 = maidsState[maidID].boostValue / 2;
                if (maidsState[maidID].stunFlag) aheValue3 += 25;

                if (maidsState[maidID].aheValue < aheValue3)
                {
                    maidsState[maidID].aheValue += 0.1f * timerRate * sp;
                }
                else if (maidsState[maidID].aheValue > aheValue3)
                {
                    maidsState[maidID].aheValue -= 0.1f * timerRate * sp;
                }
            }
            else if (maidsState[maidID].aheValue > 0)
            {
                maidsState[maidID].aheValue -= 0.05f * timerRate * sp;
            }

            if (maidsState[maidID].aheValue < 0f) maidsState[maidID].aheValue = 0f;

            vl = maid.body0.trsEyeL.localPosition;
            vr = maid.body0.trsEyeR.localPosition;
            maid.body0.trsEyeL.localPosition = new Vector3(vl.x, Math.Max((maidsState[maidID].fAheDefEyeL + maidsState[maidID].aheValue) / fEyePosToSliderMul, 0f), vl.z);
            maid.body0.trsEyeR.localPosition = new Vector3(vr.x, Math.Min((maidsState[maidID].fAheDefEyeR - maidsState[maidID].aheValue) / fEyePosToSliderMul, 0f), vr.z);

            if (!maidsState[maidID].aheResetFlag) maidsState[maidID].aheResetFlag = true;

        }


        //痙攣操作
        private void EffectGakupiku(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            //リセットフラグが立っていて、痙攣中でなければ痙攣シェイプキーをリセット
            if (maidsState[maidID].gakupikuResetFlag && (!maidsState[maidID].gakupikuOn || !cfgw.OrgsmAnimeEnabled))
            {
                try { VertexMorph_FromProcItem(maid.body0, "orgasm", 0f); } catch { /*LogError(ex);*/ }
                maidsState[maidID].gakupikuResetFlag = false;
                maidsState[maidID].gakupikuOn = false;
                maidsState[maidID].gakupikuValue = 0f;
                return;
            }

            if (!cfgw.OrgsmAnimeEnabled) return;

            if (maidsState[maidID].orgasmCmb > 3)
            { //絶頂痙攣 強
                if (!maidsState[maidID].gakupikuOn) maidsState[maidID].gakupikuOn = true;

                if (maidsState[maidID].gakupikuTime <= 0)
                {
                    maidsState[maidID].gakupikuFlag = !maidsState[maidID].gakupikuFlag;
                    if (maidsState[maidID].gakupikuFlag)
                    {
                        maidsState[maidID].gakupikuTime = UnityEngine.Random.Range(0, 120);
                    }
                    else
                    {
                        maidsState[maidID].gakupikuTime = UnityEngine.Random.Range(0, 30);
                    }

                }
                else
                {
                    if (maidsState[maidID].gakupikuFlag)
                    {
                        maidsState[maidID].gakupikuValue = UnityEngine.Random.Range(-cfgw.orgasmValue3, cfgw.orgasmValue3);
                    }
                    maidsState[maidID].gakupikuTime -= timerRate;
                }

            }
            else if (maidsState[maidID].orgasmCmb > 0)
            { //絶頂痙攣 弱
                if (!maidsState[maidID].gakupikuOn) maidsState[maidID].gakupikuOn = true;

                if (maidsState[maidID].gakupikuTime <= 0)
                {
                    maidsState[maidID].gakupikuFlag = !maidsState[maidID].gakupikuFlag;
                    if (maidsState[maidID].gakupikuFlag)
                    {
                        maidsState[maidID].gakupikuTime = UnityEngine.Random.Range(0, 120);
                    }
                    else
                    {
                        maidsState[maidID].gakupikuTime = UnityEngine.Random.Range(0, 30);
                    }

                }
                else
                {
                    if (maidsState[maidID].gakupikuFlag)
                    {
                        maidsState[maidID].gakupikuValue = UnityEngine.Random.Range(-cfgw.orgasmValue2, cfgw.orgasmValue2);
                    }
                    maidsState[maidID].gakupikuTime -= timerRate;
                }

            }
            else if (maidsState[maidID].stunFlag)
            { //痙攣 放心中
                if (!maidsState[maidID].gakupikuOn) maidsState[maidID].gakupikuOn = true;

                if (maidsState[maidID].gakupikuTime <= 0)
                {
                    maidsState[maidID].gakupikuFlag = !maidsState[maidID].gakupikuFlag;
                    if (maidsState[maidID].gakupikuFlag)
                    {
                        maidsState[maidID].gakupikuTime = UnityEngine.Random.Range(0, 40);
                    }
                    else
                    {
                        maidsState[maidID].gakupikuTime = UnityEngine.Random.Range(0, 300);
                    }

                }
                else
                {
                    if (maidsState[maidID].gakupikuFlag)
                    {
                        maidsState[maidID].gakupikuValue = UnityEngine.Random.Range(-cfgw.orgasmValue3, cfgw.orgasmValue3);
                    }
                    maidsState[maidID].gakupikuTime -= timerRate;
                }

            }
            else if (maidsState[maidID].orgasmValue > 90)
            { //絶頂前痙攣
                if (!maidsState[maidID].gakupikuOn) maidsState[maidID].gakupikuOn = true;
                maidsState[maidID].gakupikuValue = UnityEngine.Random.Range(-cfgw.orgasmValue1, cfgw.orgasmValue1);

            }
            else if (maidsState[maidID].gakupikuOn)
            { //痙攣終了時の処理
                maidsState[maidID].gakupikuOn = false;

            }

            //痙攣のシェイプキー操作を実行
            if (maidsState[maidID].gakupikuOn)
            {
                try { VertexMorph_FromProcItem(maid.body0, "orgasm", maidsState[maidID].gakupikuValue / 100f); } catch { /*LogError(ex);*/ }
                if (!maidsState[maidID].gakupikuResetFlag) maidsState[maidID].gakupikuResetFlag = true;
            }

        }


        //勃起操作
        private void EffectBokki(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            if (!cfgw.CliAnimeEnabled)
            {
                if (maidsState[maidID].bokkiResetFlag)
                {
                    try { VertexMorph_FromProcItem(maid.body0, "clitoris", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_large", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_penis", 0f); } catch { /*LogError(ex);*/ }

                    try { VertexMorph_FromProcItem(maid.body0, "pussy_bira1", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_bira2", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "labiakupa", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "chikubi_bokki", 0f); } catch { /*LogError(ex);*/ }

                    maidsState[maidID].bokkiResetFlag = false;
                }
                return;
            }
            if (maidsState[maidID].vStateMajor == 10) return;


            float bokkiValue2 = 25 + maidsState[maidID].boostValue * 3 + maidsState[maidID].orgasmCount * 3;
            if (bokkiValue2 > 100) bokkiValue2 = 100;
            if (maidsState[maidID].bokkiValue1 > bokkiValue2) maidsState[maidID].bokkiValue1 = bokkiValue2;
            float bokki = maidsState[maidID].bokkiValue1 * cfgw.clitorisMax / 100f;

            maidsState[maidID].labiaValue = bokki;
            if (maidsState[maidID].labiaValue > 40f) maidsState[maidID].labiaValue = 40f;

            if (maidsState[maidID].cliMode == 2)
            {
                try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_penis", bokki / 100f + maidsState[maidID].gakupikuValue / 2000f); } catch { /*LogError(ex);*/ }
            }
            else if (maidsState[maidID].cliMode == 1)
            {
                try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_large", bokki / 100f + maidsState[maidID].gakupikuValue / 600f); } catch { /*LogError(ex);*/ }
            }
            else
            {
                try { VertexMorph_FromProcItem(maid.body0, "clitoris", bokki / 100f * (1f - maidsState[maidID].cliHidai / 100f) + maidsState[maidID].gakupikuValue / 400f); } catch { /*LogError(ex);*/ }
                try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_large", bokki / 100f * maidsState[maidID].cliHidai / 100f); } catch { /*LogError(ex);*/ }
            }

            try { VertexMorph_FromProcItem(maid.body0, "labiakupa", maidsState[maidID].labiaValue / 200f); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "pussy_bira1", bokki / 200f + maidsState[maidID].gakupikuValue / 400f); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "pussy_bira2", maidsState[maidID].gakupikuValue / 400f + (1f + maidsState[maidID].kupaWaveValue / 10000f) * bokki / 300f); } catch { /*LogError(ex);*/ }
            if (maid.body0.GetMask(TBody.SlotID.bra))
            {
                try { VertexMorph_FromProcItem(maid.body0, "chikubi_bokki", 0f); } catch { /*LogError(ex);*/ }
            }
            else
            {
                try { VertexMorph_FromProcItem(maid.body0, "chikubi_bokki", bokki / 100f * maidsState[maidID].chikubiHidai + maidsState[maidID].gakupikuValue / 2000f); } catch { /*LogError(ex);*/ }
            }
            if (!maidsState[maidID].bokkiResetFlag) maidsState[maidID].bokkiResetFlag = true;
        }


        //汗かき処理
        private void EffectAse(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;

            if (!cfgw.aseAnimeEnabled)
            {
                if (maidsState[maidID].aseResetFlag)
                {
                    try { VertexMorph_FromProcItem(maid.body0, "dry", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "swet", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "swet_tare", 0f); } catch { /*LogError(ex);*/ }
                    maidsState[maidID].aseResetFlag = false;
                }
                return;
            }
            //if(maidsState[maidID].vStateMajor == 10)return;

            float aseValue1;
            float aseValue2;
            float aseValue3;

            aseValue1 = (float)Math.Floor(110 - ((maidsState[maidID].boostValue * 2) + (maidsState[maidID].exciteValue / 360)));
            aseValue2 = (float)Math.Floor((3000 - maidsState[maidID].maidStamina) / 100);
            aseValue3 = (float)Math.Floor(maidsState[maidID].orgasmValue / 3);
            if (lifeStart > 0 && (bgID == 11 || bgID == 22 || bgID == 23) && aseValue1 > 20) aseValue1 = 20;
            if (aseValue1 < 0) aseValue1 = 0;
            if (aseValue1 > 100) aseValue1 = 100;

            try { VertexMorph_FromProcItem(maid.body0, "dry", aseValue1 / 100f); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "swet", aseValue2 / 100f); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "swet_tare", aseValue3 / 100f); } catch { /*LogError(ex);*/ }

            if (!maidsState[maidID].aseResetFlag) maidsState[maidID].aseResetFlag = true;
            //maidsState[maidID].aseTime = UnityEngine.Random.Range(5, 10);
        }


        //秘部アニメ処理
        private void EffectHibuAnime(int maidID, float sp)
        {

            if (!cfgw.hibuAnime1Enabled && (maidsState[maidID].vStateMajor == 20 || maidsState[maidID].vStateMajor == 30)) return;
            if (!cfgw.hibuAnime2Enabled && maidsState[maidID].vStateMajor == 40) return;
            if (maidsState[maidID].vStateMajor == 10 || maidsState[maidID].vStateMajor == 50) return;

            Maid maid = stockMaids[maidID].mem;
            float hValue = 0f;
            float aValue = 0f;
            float uValue = 0f;
            float pikuValue = 0f;
            float pikuValue2 = 0f;

            float hibuSlider1Value = maidsState[maidID].hibuSlider1Value;
            float analSlider1Value = maidsState[maidID].analSlider1Value;
            float hibuSlider2Value = maidsState[maidID].hibuSlider2Value;
            float analSlider2Value = maidsState[maidID].analSlider2Value;
            if (maidID == osawariID)
            {
                if (osawariPoint == "vagina")
                {
                    if (hibuSlider1Value < 20f) hibuSlider1Value = 20f;
                    if (hibuSlider2Value < 20f) hibuSlider2Value = 20f;
                }
                else if (osawariPoint == "anal")
                {
                    if (analSlider1Value < 25f) analSlider1Value = 25f;
                    if (analSlider2Value < 25f) analSlider2Value = 25f;
                }
            }

            if (maidsState[maidID].pikuTime <= 0)
            {
                maidsState[maidID].pikuFlag = !maidsState[maidID].pikuFlag;
                if (maidsState[maidID].pikuFlag)
                { //ピク実行時間設定
                    if (maidsState[maidID].vStateMajor == 20 || maidsState[maidID].vStateMajor == 30) maidsState[maidID].pikuTime = UnityEngine.Random.Range(0, 90);
                    if (maidsState[maidID].vStateMajor == 40) maidsState[maidID].pikuTime = UnityEngine.Random.Range(0, 60);
                }
                else
                { //ピク待機時間設定
                    if (maidsState[maidID].vStateMajor == 20 || maidsState[maidID].vStateMajor == 30) maidsState[maidID].pikuTime = UnityEngine.Random.Range(30, 210);
                    if (maidsState[maidID].vStateMajor == 40) maidsState[maidID].pikuTime = UnityEngine.Random.Range(30, 90);
                }
            }
            else
            {
                maidsState[maidID].pikuTime -= timerRate;
            }

            if (cfgw.hibuAnime1Enabled && (maidsState[maidID].vStateMajor == 20 || maidsState[maidID].vStateMajor == 30))
            {
                if (maidsState[maidID].hibuValue < hibuSlider1Value)
                {
                    maidsState[maidID].hibuValue += 2f * sp;
                    if (maidsState[maidID].hibuValue > hibuSlider1Value) maidsState[maidID].hibuValue = hibuSlider1Value;
                }
                if (maidsState[maidID].hibuValue > hibuSlider1Value)
                {
                    maidsState[maidID].hibuValue -= 0.7f * sp;
                    if (maidsState[maidID].hibuValue < hibuSlider1Value) maidsState[maidID].hibuValue = hibuSlider1Value;
                }

                if (maidsState[maidID].uDatsu != 0)
                { //子宮脱時
                    maidsState[maidID].hibuValue -= maidsState[maidID].uDatsuValue1;
                    if (maidsState[maidID].hibuValue < 0) maidsState[maidID].hibuValue = 0;
                }
                hValue = maidsState[maidID].hibuValue + maidsState[maidID].kupaWaveValue / 100f * cfgw.kupaWave;
                if (maidID == osawariID && osawariPoint == "vagina") hValue = maidsState[maidID].hibuValue + Move_atp_y * 20f; //お触り時の処理

                if (maidsState[maidID].analValue < analSlider1Value)
                {
                    maidsState[maidID].analValue += 2f * sp;
                    if (maidsState[maidID].analValue > analSlider1Value) maidsState[maidID].analValue = analSlider1Value;
                }
                if (maidsState[maidID].analValue > analSlider1Value)
                {
                    maidsState[maidID].analValue -= 0.7f * sp;
                    if (maidsState[maidID].analValue < analSlider1Value) maidsState[maidID].analValue = analSlider1Value;
                }
                aValue = maidsState[maidID].analValue + maidsState[maidID].kupaWaveValue / 100f * cfgw.kupaWave;
                if (maidID == osawariID && osawariPoint == "anal") aValue = maidsState[maidID].analValue + Move_atp_y * 15f; //お触り時の処理

                if (maidsState[maidID].pikuFlag) pikuValue2 = UnityEngine.Random.Range(0, 20);
                uValue = maidsState[maidID].hibuValue / 2 + maidsState[maidID].kupaWaveValue / 100f * cfgw.kupaWave + pikuValue2;


            }
            else if (cfgw.hibuAnime2Enabled && maidsState[maidID].vStateMajor == 40)
            {
                if (maidsState[maidID].uDatsu == 0)
                {
                    if (maidsState[maidID].hibuValue > hibuSlider2Value)
                    {
                        maidsState[maidID].hibuValue -= 0.7f * sp;
                        if (maidsState[maidID].hibuValue < hibuSlider2Value) maidsState[maidID].hibuValue = hibuSlider2Value;
                    }
                    if (maidsState[maidID].hibuValue < hibuSlider2Value)
                    {
                        maidsState[maidID].hibuValue += 2f * sp;
                        if (maidsState[maidID].hibuValue > hibuSlider2Value) maidsState[maidID].hibuValue = hibuSlider2Value;
                    }
                }
                else
                {
                    if (maidsState[maidID].hibuValue > 0f) maidsState[maidID].hibuValue -= 0.7f * sp;
                    if (maidsState[maidID].hibuValue < 0f) maidsState[maidID].hibuValue = 0f;
                }

                if (maidsState[maidID].analValue > analSlider2Value)
                {
                    maidsState[maidID].analValue -= 0.7f * sp;
                    if (maidsState[maidID].analValue < analSlider2Value) maidsState[maidID].analValue = analSlider2Value;
                }
                if (maidsState[maidID].analValue < analSlider2Value)
                {
                    maidsState[maidID].analValue += 2f * sp;
                    if (maidsState[maidID].analValue > analSlider2Value) maidsState[maidID].analValue = analSlider2Value;
                }

                if (maidsState[maidID].pikuFlag)
                {
                    pikuValue = UnityEngine.Random.Range(0, 5);
                    pikuValue2 = UnityEngine.Random.Range(0, 20);
                }
                hValue = maidsState[maidID].hibuValue + pikuValue;
                if (maidID == osawariID && osawariPoint == "vagina") hValue = maidsState[maidID].hibuValue + Move_atp_y * 20f; //お触り時の処理

                aValue = maidsState[maidID].analValue + pikuValue;
                if (maidID == osawariID && osawariPoint == "anal") aValue = maidsState[maidID].analValue + Move_atp_y * 15f; //お触り時の処理
                uValue = maidsState[maidID].hibuValue / 2 + pikuValue2;

            }

            try { VertexMorph_FromProcItem(maid.body0, "kupa", hValue / 100f); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "analkupa", aValue / 100f); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "pussy_uterus_piku", uValue / 100f); } catch { /*LogError(ex);*/ }

        }


        //子宮脱アニメ処理
        private void EffectUterusDatsu(int maidID)
        {
            if (maidsState[maidID].uDatsu == 0) return;
            Maid maid = stockMaids[maidID].mem;

            if (maidsState[maidID].uDatsu == 1)
            { //子宮脱判定
                if (maidsState[maidID].boostBase + maidsState[maidID].uDatsuStock < 65 || !cfgw.uDatsuEnabled)
                { //65以下なら子宮脱しない
                    maidsState[maidID].uDatsu = 3;

                }
                else if (maidsState[maidID].uDatsuWait < 0)
                { //子宮脱開始
                    maidsState[maidID].uDatsuValue2 = maidsState[maidID].boostBase + maidsState[maidID].uDatsuStock;
                    if (maidsState[maidID].uDatsuValue2 > 100f) maidsState[maidID].uDatsuValue2 = 100f;
                    maidsState[maidID].uDatsuStock = 0;
                    maidsState[maidID].uDatsu = 2;
                    maidsState[maidID].uDatsuWait = 90f;
                    maidsState[maidID].uDatsuTotal += 1; //子宮脱回数

                }
                else
                {
                    maidsState[maidID].uDatsuWait -= timerRate;
                }
            }

            if (maidsState[maidID].uDatsu == 2)
            { //子宮脱アニメ処理
                if (maidsState[maidID].uDatsuValue1 < maidsState[maidID].uDatsuValue2)
                {
                    maidsState[maidID].uDatsuValue1 += (maidsState[maidID].uDatsuValue2 - maidsState[maidID].uDatsuValue1) * 0.015f + 0.001f;
                    if (maidsState[maidID].uDatsuValue1 > 90f) maidsState[maidID].uDatsuValue1 = 90f;
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_uterus_prolapse", maidsState[maidID].uDatsuValue1 / 100f + maidsState[maidID].kupaWaveValue / 10000f * 3 - Move_atp_y * 0.1f); } catch { /*LogError(ex);*/ }

                    if (maidsState[maidID].uDatsuValue1 >= maidsState[maidID].uDatsuValue2)
                    {
                        if (maidsState[maidID].uDatsuValue2 > 20f)
                        {
                            maidsState[maidID].uDatsuValue2 -= UnityEngine.Random.Range(5, 10);
                        }
                    }

                }
                else if (maidsState[maidID].uDatsuValue1 > maidsState[maidID].uDatsuValue2)
                {
                    maidsState[maidID].uDatsuValue1 -= (maidsState[maidID].uDatsuValue1 - maidsState[maidID].uDatsuValue2) * 0.015f + 0.001f;
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_uterus_prolapse", maidsState[maidID].uDatsuValue1 / 100f + maidsState[maidID].kupaWaveValue / 10000f * 3 - Move_atp_y * 0.1f); } catch { /*LogError(ex);*/ }

                    if (maidsState[maidID].uDatsuValue1 <= maidsState[maidID].uDatsuValue2)
                    {
                        if (maidsState[maidID].uDatsuValue2 > 20f)
                        {
                            maidsState[maidID].uDatsuValue2 += UnityEngine.Random.Range(5, 10);
                        }
                    }
                }
            }

        }



        //メイドの口元変更
        private void MouthChange(int maidID)
        {

            Maid maid = stockMaids[maidID].mem;
            if (cfgw.MouthNomalEnabled || cfgw.MouthKissEnabled || cfgw.MouthFeraEnabled || cfgw.MouthZeccyouEnabled)
            {
                if (maidsState[maidID].vStateMajor == 20 || maidsState[maidID].vStateMajor == 30)
                {
                    if (!cfgw.MouthKissEnabled && maidsState[maidID].MouthMode == 1) maidsState[maidID].MouthMode = 0;
                    if (!cfgw.MouthFeraEnabled && maidsState[maidID].MouthMode == 2) maidsState[maidID].MouthMode = 0;
                    if (!cfgw.MouthZeccyouEnabled && maidsState[maidID].MouthMode >= 3) maidsState[maidID].MouthMode = 0;
                }
                else if (maidsState[maidID].vStateMajor == 40 && cfgw.MouthNomalEnabled)
                {
                    if (maidsState[maidID].stunFlag) maidsState[maidID].MouthMode = 3;
                    if (!maidsState[maidID].stunFlag) maidsState[maidID].MouthMode = 5;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            if (maidsState[maidID].MouthMode != maidsState[maidID].OldMode)
            {
                maidsState[maidID].MouthHoldTime = 0;
                maidsState[maidID].OldMode = maidsState[maidID].MouthMode;
            }

            float maV = maid.body0.Face.morph.GetBlendValues((int)maid.body0.Face.morph.hash[(object)"moutha"]); //口あ
            float miV = maid.body0.Face.morph.GetBlendValues((int)maid.body0.Face.morph.hash[(object)"mouthi"]); //口い
            float mcV; //口う
            float msV; //笑顔
            float mdwV = maid.body0.Face.morph.GetBlendValues((int)maid.body0.Face.morph.hash[(object)"mouthdw"]); //口角上げ
            float mupV; //口角下げ


            if (maidsState[maidID].MouthHoldTime <= 0)
            {
                maidsState[maidID].MouthHoldTime = UnityEngine.Random.Range(180f, 360f);

                if (maidsState[maidID].MouthMode == 0)
                {  //通常時
                    maidsState[maidID].MaValue = UnityEngine.Random.Range(0f, 30f) / 100f;
                    maidsState[maidID].MdwValue = UnityEngine.Random.Range(0f, 30f) / 100f;
                }
                if (maidsState[maidID].MouthMode == 1)
                {  //キス時
                    maidsState[maidID].MaValue = UnityEngine.Random.Range(20f, 60f) / 100f;
                    maidsState[maidID].MdwValue = UnityEngine.Random.Range(0f, 50f) / 100f;
                }
                if (maidsState[maidID].MouthMode == 2)
                {  //フェラ時
                    maidsState[maidID].MaValue = UnityEngine.Random.Range(80f, 100f) / 100f;
                }
                if (maidsState[maidID].MouthMode == 3)
                {  //連続絶頂時１
                    maidsState[maidID].MaValue = UnityEngine.Random.Range(70f, 90f) / 100f;
                    maidsState[maidID].MdwValue = UnityEngine.Random.Range(30f, 90f) / 100f;
                }
                if (maidsState[maidID].MouthMode == 4)
                {  //連続絶頂時２
                    maidsState[maidID].MiValue = UnityEngine.Random.Range(40f, 60f) / 100f;
                    maidsState[maidID].MdwValue = UnityEngine.Random.Range(20f, 40f) / 100f;
                }
                if (maidsState[maidID].MouthMode == 5)
                {  //余韻時
                    maidsState[maidID].MaValue = UnityEngine.Random.Range(10f, 40f) / 100f;
                    maidsState[maidID].MdwValue = UnityEngine.Random.Range(0f, 30f) / 100f;
                }

            }

            maidsState[maidID].MouthHoldTime -= timerRate;
            if (maidsState[maidID].MouthMode == 0 && !cfgw.MouthNomalEnabled) return;

            if (maidsState[maidID].maVBack > maV)
            {
                maV += maidsState[maidID].MaValue;
                maidsState[maidID].maVBack = maV;
            }
            if (maidsState[maidID].miVBack > miV)
            {
                miV += maidsState[maidID].MiValue;
                maidsState[maidID].miVBack = miV;
            }

            mcV = maid.body0.Face.morph.GetBlendValues((int)maid.body0.Face.morph.hash[(object)"mouthc"]);
            msV = maid.body0.Face.morph.GetBlendValues((int)maid.body0.Face.morph.hash[(object)"mouths"]);
            if (maidsState[maidID].mdwVBack > mdwV)
            {
                mdwV += maidsState[maidID].MdwValue;
                maidsState[maidID].mdwVBack = mdwV;
            }
            mupV = maid.body0.Face.morph.GetBlendValues((int)maid.body0.Face.morph.hash[(object)"mouthup"]);


            //舌の動き処理
            //キス時とフェラ時
            if (maidsState[maidID].MouthMode == 1 || maidsState[maidID].MouthMode == 2)
            {
                if (maidsState[maidID].TupValue < maidsState[maidID].TupValue2)
                {
                    maidsState[maidID].TupValue += Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TupValue >= maidsState[maidID].TupValue2) maidsState[maidID].TupValue2 = UnityEngine.Random.Range(0f, 60f) / 100f;
                }
                else
                {
                    maidsState[maidID].TupValue -= Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TupValue <= maidsState[maidID].TupValue2) maidsState[maidID].TupValue2 = UnityEngine.Random.Range(0f, 60f) / 100f;
                }

                if (maidsState[maidID].ToutValue < maidsState[maidID].ToutValue2)
                {
                    maidsState[maidID].ToutValue += Time.deltaTime * 0.8f;
                    if (maidsState[maidID].ToutValue >= maidsState[maidID].ToutValue2) maidsState[maidID].ToutValue2 = UnityEngine.Random.Range(-20f, 70f) / 100f;
                }
                else
                {
                    maidsState[maidID].ToutValue -= Time.deltaTime * 0.8f;
                    if (maidsState[maidID].ToutValue <= maidsState[maidID].ToutValue2) maidsState[maidID].ToutValue2 = UnityEngine.Random.Range(-20f, 70f) / 100f;
                }

                if (maidsState[maidID].TopenValue < maidsState[maidID].TopenValue2)
                {
                    maidsState[maidID].TopenValue += Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TopenValue >= maidsState[maidID].TopenValue2) maidsState[maidID].TopenValue2 = UnityEngine.Random.Range(0f, 40f) / 100f;
                }
                else
                {
                    maidsState[maidID].TopenValue -= Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TopenValue <= maidsState[maidID].TopenValue2) maidsState[maidID].TopenValue2 = UnityEngine.Random.Range(0f, 40f) / 100f;
                }
            }
            //連続絶頂時
            if (maidsState[maidID].MouthMode == 3)
            {
                if (maidsState[maidID].TupValue < maidsState[maidID].TupValue2)
                {
                    maidsState[maidID].TupValue += Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TupValue >= maidsState[maidID].TupValue2) maidsState[maidID].TupValue2 = UnityEngine.Random.Range(0f, 40f) / 100f;
                }
                else
                {
                    maidsState[maidID].TupValue -= Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TupValue <= maidsState[maidID].TupValue2) maidsState[maidID].TupValue2 = UnityEngine.Random.Range(0f, 40f) / 100f;
                }

                if (maidsState[maidID].ToutValue < maidsState[maidID].ToutValue2)
                {
                    maidsState[maidID].ToutValue += Time.deltaTime * 0.5f;
                    if (maidsState[maidID].ToutValue >= maidsState[maidID].ToutValue2) maidsState[maidID].ToutValue2 = UnityEngine.Random.Range(60f, 100f) / 100f;
                }
                else
                {
                    maidsState[maidID].ToutValue -= Time.deltaTime * 0.5f;
                    if (maidsState[maidID].ToutValue <= maidsState[maidID].ToutValue2) maidsState[maidID].ToutValue2 = UnityEngine.Random.Range(60f, 100f) / 100f;
                }

                if (maidsState[maidID].TopenValue < maidsState[maidID].TopenValue2)
                {
                    maidsState[maidID].TopenValue += Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TopenValue >= maidsState[maidID].TopenValue2) maidsState[maidID].TopenValue2 = UnityEngine.Random.Range(0f, 60f) / 100f;
                }
                else
                {
                    maidsState[maidID].TopenValue -= Time.deltaTime * 0.5f;
                    if (maidsState[maidID].TopenValue <= maidsState[maidID].TopenValue2) maidsState[maidID].TopenValue2 = UnityEngine.Random.Range(0f, 60f) / 100f;
                }
            }


            //口元破綻の抑制とシェイプキー操作
            if (maidsState[maidID].MouthMode == 0)
            {  //通常時
                try { VertexMorph_FromProcItem(maid.body0, "moutha", maV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthdw", mdwV); } catch { }

            }
            if (maidsState[maidID].MouthMode == 1)
            {  //キス時
                if (miV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouthi", 0.1f); } catch { }
                if (maV > 0.6f) maV = 0.6f;
                try { VertexMorph_FromProcItem(maid.body0, "moutha", maV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthdw", mdwV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangup", maidsState[maidID].TupValue); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangout", maidsState[maidID].ToutValue); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangopen", maidsState[maidID].TopenValue); } catch { }

            }
            if (maidsState[maidID].MouthMode == 2)
            {  //フェラ時
                if (miV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouthi", 0.1f); } catch { }
                if (mcV > 0.2f) try { VertexMorph_FromProcItem(maid.body0, "mouthc", 0.2f); } catch { }
                if (msV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouths", 0.1f); } catch { }
                if (mupV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouthup", 0.1f); } catch { }
                if (maV > 1.0f) maV = 1.0f;
                try { VertexMorph_FromProcItem(maid.body0, "moutha", maV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthdw", mdwV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangup", maidsState[maidID].TupValue); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangout", maidsState[maidID].ToutValue); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangopen", maidsState[maidID].TopenValue); } catch { }

            }
            if (maidsState[maidID].MouthMode == 3)
            {  //連続絶頂時１
                if (miV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouthi", 0.1f); } catch { }
                if (mcV > 0.2f) try { VertexMorph_FromProcItem(maid.body0, "mouthc", 0.2f); } catch { }
                if (msV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouths", 0.1f); } catch { }
                if (mupV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouthup", 0.1f); } catch { }
                if (maV > 1.0f) maV = 1.0f;
                try { VertexMorph_FromProcItem(maid.body0, "moutha", maV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthdw", mdwV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangup", maidsState[maidID].TupValue); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangout", maidsState[maidID].ToutValue); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "tangopen", maidsState[maidID].TopenValue); } catch { }

            }
            if (maidsState[maidID].MouthMode == 4)
            {  //連続絶頂時２
                if (mupV > 0f) try { VertexMorph_FromProcItem(maid.body0, "mouthup", 0f); } catch { }
                if (msV > 0.1f) try { VertexMorph_FromProcItem(maid.body0, "mouths", 0f); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "moutha", maV / 4 + 0.05f); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthc", mcV / 4); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthi", miV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthdw", mdwV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthhe", 0.3f); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "toothoff", 0f); } catch { }

            }
            if (maidsState[maidID].MouthMode == 5)
            {  //余韻時
                try { VertexMorph_FromProcItem(maid.body0, "moutha", maV); } catch { }
                try { VertexMorph_FromProcItem(maid.body0, "mouthdw", mdwV); } catch { }

            }
        }



        //演出関係終了-------------------------------------




        //-------------------------------------------------
        //乳首設定関係---------------------------------

        //服装と乳首のチェック
        private int ChikubiCheck(int maidID)
        {
            Maid maid = stockMaids[maidID].mem;
            bool isWear = true;
            bool isOnepiece = true;
            bool isMizugi = true;
            bool isBra = true;


            //服装の状態チェック
            if (!maid.body0.GetMask(TBody.SlotID.wear) || maid.GetProp(MPN.wear).strTempFileName == "_I_wear_del.menu" || (maid.GetProp(MPN.wear).strTempFileName == "" && maid.GetProp(MPN.wear).strFileName == "_I_wear_del.menu")) isWear = false;
            if (!maid.body0.GetMask(TBody.SlotID.onepiece) || maid.GetProp(MPN.onepiece).strTempFileName == "_I_onepiece_del.menu" || (maid.GetProp(MPN.onepiece).strTempFileName == "" && maid.GetProp(MPN.onepiece).strFileName == "_I_onepiece_del.menu")) isOnepiece = false;
            if (!maid.body0.GetMask(TBody.SlotID.mizugi) || maid.GetProp(MPN.mizugi).strTempFileName == "_I_mizugi_del.menu" || (maid.GetProp(MPN.mizugi).strTempFileName == "" && maid.GetProp(MPN.mizugi).strFileName == "_I_mizugi_del.menu")) isMizugi = false;
            if (!maid.body0.GetMask(TBody.SlotID.bra) || maid.GetProp(MPN.bra).strTempFileName == "_i_bra_del.menu" || (maid.GetProp(MPN.bra).strTempFileName == "" && maid.GetProp(MPN.bra).strFileName == "_i_bra_del.menu")) isBra = false;

            if (isWear || isOnepiece || isMizugi || isBra)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        // 乳首設定反映
        void ChikubiSet(int maidID, int cv)
        {
            Maid maid = stockMaids[maidID].mem;

            float n_def = maidsState[maidID].tits_nipple_def[cv];
            float kanbotsu_n = maidsState[maidID].tits_chikubi_kanbotsu_n[cv];
            float kanbotsu_s = maidsState[maidID].tits_chikubi_kanbotsu_s[cv];
            float kanbotsu_p = maidsState[maidID].tits_chikubi_kanbotsu_p[cv];
            float bokki2 = 1f;
            if (cv == 1 && maidsState[maidID].chikubiBokkiEnabled)
            {
                float bokki = maidsState[maidID].bokkiValue1 * 0.01f;
                bokki2 += bokki * 0.4f;
                n_def += bokki * 1.4f;
                kanbotsu_n -= bokki * maidsState[maidID].tits_chikubi_kanbotsu_n[cv];
                kanbotsu_s -= bokki * maidsState[maidID].tits_chikubi_kanbotsu_s[cv];
                kanbotsu_p -= bokki * maidsState[maidID].tits_chikubi_kanbotsu_p[cv];
            }

            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_cow", maidsState[maidID].tits_chikubi_cow[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_observe", maidsState[maidID].tits_chikubi_observe[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_wide", maidsState[maidID].tits_chikubi_wide[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_ultralong", maidsState[maidID].tits_chikubi_ultralong[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_ultrawide", maidsState[maidID].tits_chikubi_ultrawide[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_ultratare", maidsState[maidID].tits_chikubi_ultratare[cv]); } catch { /*LogError(ex);*/ }

            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_long1", maidsState[maidID].tits_nipple_long1[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_long2", maidsState[maidID].tits_nipple_long2[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_wide", maidsState[maidID].tits_nipple_wide[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_kupa", maidsState[maidID].tits_nipple_kupa[cv]); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_munel_chippai", maidsState[maidID].tits_munel_chippai[cv]); } catch { /*LogError(ex);*/ }

            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_kanbotsu_n", kanbotsu_n); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_kanbotsu_s", kanbotsu_s); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_kanbotsu_p", kanbotsu_p); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_def", n_def); } catch { /*LogError(ex);*/ }

            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_def", maidsState[maidID].tits_chikubi_def[cv] * bokki2); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_chikubi_perky", maidsState[maidID].tits_chikubi_perky[cv] * bokki2); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_perky1", maidsState[maidID].tits_nipple_perky1[cv] * bokki2); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_perky2", maidsState[maidID].tits_nipple_perky2[cv] * bokki2); } catch { /*LogError(ex);*/ }
            try { VertexMorph_FromProcItem(maid.body0, "tits_nipple_puffy", maidsState[maidID].tits_nipple_puffy[cv] * bokki2); } catch { /*LogError(ex);*/ }
        }

        // 乳首設定の保存
        void ChikubiSave(int maidID, int cv)
        {
            Maid maid = stockMaids[maidID].mem;

            if (maidsState[maidID].chikubiEnabled)
            {
                ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "chikubiEnabled", "1", true);
            }
            else
            {
                ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "chikubiEnabled", "0", true);
            }

            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_def[" + cv + "]", maidsState[maidID].tits_chikubi_def[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_perky[" + cv + "]", maidsState[maidID].tits_chikubi_perky[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_cow[" + cv + "]", maidsState[maidID].tits_chikubi_cow[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_observe[" + cv + "]", maidsState[maidID].tits_chikubi_observe[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_wide[" + cv + "]", maidsState[maidID].tits_chikubi_wide[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_ultralong[" + cv + "]", maidsState[maidID].tits_chikubi_ultralong[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_ultrawide[" + cv + "]", maidsState[maidID].tits_chikubi_ultrawide[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_ultratare[" + cv + "]", maidsState[maidID].tits_chikubi_ultratare[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_kanbotsu_n[" + cv + "]", maidsState[maidID].tits_chikubi_kanbotsu_n[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_kanbotsu_s[" + cv + "]", maidsState[maidID].tits_chikubi_kanbotsu_s[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_kanbotsu_p[" + cv + "]", maidsState[maidID].tits_chikubi_kanbotsu_p[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_def[" + cv + "]", maidsState[maidID].tits_nipple_def[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_perky1[" + cv + "]", maidsState[maidID].tits_nipple_perky1[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_perky2[" + cv + "]", maidsState[maidID].tits_nipple_perky2[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_long1[" + cv + "]", maidsState[maidID].tits_nipple_long1[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_long2[" + cv + "]", maidsState[maidID].tits_nipple_long2[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_wide[" + cv + "]", maidsState[maidID].tits_nipple_wide[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_puffy[" + cv + "]", maidsState[maidID].tits_nipple_puffy[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_kupa[" + cv + "]", maidsState[maidID].tits_nipple_kupa[cv].ToString(), true);
            ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "tits_munel_chippai[" + cv + "]", maidsState[maidID].tits_munel_chippai[cv].ToString(), true);

        }

        // 乳首設定の読込
        void ChikubiLoad(int maidID, int cv)
        {
            Maid maid = stockMaids[maidID].mem;

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "chikubiEnabled", "0") == "0")
            {
                maidsState[maidID].chikubiEnabled = false;
            }
            else
            {
                maidsState[maidID].chikubiEnabled = true;
            }

            if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_def[" + cv + "]", "0") != "")
            {

                maidsState[maidID].tits_chikubi_def[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_def[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_perky[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_perky[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_cow[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_cow[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_observe[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_observe[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_wide[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_wide[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_ultralong[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_ultralong[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_ultrawide[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_ultrawide[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_ultratare[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_ultratare[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_kanbotsu_n[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_kanbotsu_n[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_kanbotsu_s[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_kanbotsu_s[" + cv + "]", "0"));
                maidsState[maidID].tits_chikubi_kanbotsu_p[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_chikubi_kanbotsu_p[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_def[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_def[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_perky1[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_perky1[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_perky2[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_perky2[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_long1[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_long1[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_long2[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_long2[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_wide[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_wide[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_puffy[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_puffy[" + cv + "]", "0"));
                maidsState[maidID].tits_nipple_kupa[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_nipple_kupa[" + cv + "]", "0"));
                maidsState[maidID].tits_munel_chippai[cv] = floatCnv(ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "tits_munel_chippai[" + cv + "]", "0"));

            }

        }


        // 乳首設定のリセット
        void ChikubiReset(int maidID, int cv)
        {

            maidsState[maidID].tits_chikubi_def[cv] = 0;
            maidsState[maidID].tits_chikubi_perky[cv] = 0;
            maidsState[maidID].tits_chikubi_cow[cv] = 0;
            maidsState[maidID].tits_chikubi_observe[cv] = 0;
            maidsState[maidID].tits_chikubi_wide[cv] = 0;
            maidsState[maidID].tits_chikubi_ultralong[cv] = 0;
            maidsState[maidID].tits_chikubi_ultrawide[cv] = 0;
            maidsState[maidID].tits_chikubi_ultratare[cv] = 0;
            maidsState[maidID].tits_chikubi_kanbotsu_n[cv] = 0;
            maidsState[maidID].tits_chikubi_kanbotsu_s[cv] = 0;
            maidsState[maidID].tits_chikubi_kanbotsu_p[cv] = 0;
            maidsState[maidID].tits_nipple_def[cv] = 0;
            maidsState[maidID].tits_nipple_perky1[cv] = 0;
            maidsState[maidID].tits_nipple_perky2[cv] = 0;
            maidsState[maidID].tits_nipple_long1[cv] = 0;
            maidsState[maidID].tits_nipple_long2[cv] = 0;
            maidsState[maidID].tits_nipple_wide[cv] = 0;
            maidsState[maidID].tits_nipple_puffy[cv] = 0;
            maidsState[maidID].tits_nipple_kupa[cv] = 0;
            maidsState[maidID].tits_nipple_kupa[cv] = 0;

        }


        // 乳首設定のコピー
        void ChikubiCopy(int maidID, int a, int b)
        {

            maidsState[maidID].tits_chikubi_def[a] = maidsState[maidID].tits_chikubi_def[b];
            maidsState[maidID].tits_chikubi_perky[a] = maidsState[maidID].tits_chikubi_perky[b];
            maidsState[maidID].tits_chikubi_cow[a] = maidsState[maidID].tits_chikubi_cow[b];
            maidsState[maidID].tits_chikubi_observe[a] = maidsState[maidID].tits_chikubi_observe[b];
            maidsState[maidID].tits_chikubi_wide[a] = maidsState[maidID].tits_chikubi_wide[b];
            maidsState[maidID].tits_chikubi_ultralong[a] = maidsState[maidID].tits_chikubi_ultralong[b];
            maidsState[maidID].tits_chikubi_ultrawide[a] = maidsState[maidID].tits_chikubi_ultrawide[b];
            maidsState[maidID].tits_chikubi_ultratare[a] = maidsState[maidID].tits_chikubi_ultratare[b];
            maidsState[maidID].tits_chikubi_kanbotsu_n[a] = maidsState[maidID].tits_chikubi_kanbotsu_n[b];
            maidsState[maidID].tits_chikubi_kanbotsu_s[a] = maidsState[maidID].tits_chikubi_kanbotsu_s[b];
            maidsState[maidID].tits_chikubi_kanbotsu_p[a] = maidsState[maidID].tits_chikubi_kanbotsu_p[b];
            maidsState[maidID].tits_nipple_def[a] = maidsState[maidID].tits_nipple_def[b];
            maidsState[maidID].tits_nipple_perky1[a] = maidsState[maidID].tits_nipple_perky1[b];
            maidsState[maidID].tits_nipple_perky2[a] = maidsState[maidID].tits_nipple_perky2[b];
            maidsState[maidID].tits_nipple_long1[a] = maidsState[maidID].tits_nipple_long1[b];
            maidsState[maidID].tits_nipple_long2[a] = maidsState[maidID].tits_nipple_long2[b];
            maidsState[maidID].tits_nipple_wide[a] = maidsState[maidID].tits_nipple_wide[b];
            maidsState[maidID].tits_nipple_puffy[a] = maidsState[maidID].tits_nipple_puffy[b];
            maidsState[maidID].tits_nipple_kupa[a] = maidsState[maidID].tits_nipple_kupa[b];
            maidsState[maidID].tits_munel_chippai[a] = maidsState[maidID].tits_munel_chippai[b];


        }


        //乳首関係終了-------------------------------------




        //-------------------------------------------------
        //シェイプキー関係---------------------------------

        static List<TMorph> m_NeedFixTMorphs = new List<TMorph>();

        //シェイプキー操作
        //戻り値はsTagの存在有無にしているので必要に応じて変更してください
        public static bool VertexMorph_FromProcItem(TBody body, string sTag, float f)
        {
            bool result = false;
            if (!body || sTag == null || sTag == "")
            {
                return false;
            }
            for (int i = 0; i < body.goSlot.Count; i++)
            {
                TMorph morph = body.goSlot[i].morph;
                if (morph != null && morph.Contains(sTag))
                {
                    result = true;
                    int f_nIdx = (int)morph.hash[sTag];
                    morph.SetBlendValues(f_nIdx, f);
                    if (!VibeYourMaid.m_NeedFixTMorphs.Contains(morph))
                    {
                        VibeYourMaid.m_NeedFixTMorphs.Add(morph);
                    }
                }
            }
            return result;
        }

        //シェイプキー操作Fix(基本はUpdate等の最後に一度呼ぶだけで良いはず）
        static public void VertexMorph_FixBlendValues()
        {

            foreach (TMorph tm in m_NeedFixTMorphs)
            {
                tm.FixBlendValues();
            }
            m_NeedFixTMorphs.Clear();
        }


        //シェイプキーが存在するかのチェック
        private bool isExistVertexMorph(TBody body, string sTag)
        {

            for (int i = 0; i < body.goSlot.Count; i++)
            {
                TMorph morph = body.goSlot[i].morph;
                if (morph != null)
                {
                    if (morph.Contains(sTag))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //kupaウェイブ
        private void ShapeKeyKupaWave(int maidID, float min, float max, float sp)
        {

            sp *= Time.deltaTime * ShapeKeySpeedRate;

            if (maidsState[maidID].kupaWaveValue > max)
            {
                maidsState[maidID].kupaWaveRe = -1f;
            }
            else if (maidsState[maidID].kupaWaveValue < min)
            {
                maidsState[maidID].kupaWaveRe = 1f;
            }

            maidsState[maidID].kupaWaveValue = maidsState[maidID].kupaWaveValue + sp * maidsState[maidID].kupaWaveRe;
        }


        //シェイプウェイブ
        private void ShapeKeyWave(int maidID, string[] name, string[] name2, float min, float max, float sp)
        {

            Maid maid = stockMaids[maidID].mem;
            sp *= Time.deltaTime * ShapeKeySpeedRate;

            if (maidsState[maidID].shapeKeyWaveValue > max)
            {
                maidsState[maidID].shapeKeyWaveRe = -1f;
            }
            else if (maidsState[maidID].shapeKeyWaveValue < min)
            {
                maidsState[maidID].shapeKeyWaveRe = 1f;
            }

            maidsState[maidID].shapeKeyWaveValue = maidsState[maidID].shapeKeyWaveValue + sp * maidsState[maidID].shapeKeyWaveRe;

            for (int i = 0; i < name.Length; i++)
            {
                try { VertexMorph_FromProcItem(maid.body0, name[i], maidsState[maidID].shapeKeyWaveValue / 100f); } catch { /*LogError(ex);*/ }
            }

            float rValue = max - maidsState[maidID].shapeKeyWaveValue;
            for (int i = 0; i < name2.Length; i++)
            {
                try { VertexMorph_FromProcItem(maid.body0, name2[i], rValue / 100f); } catch { /*LogError(ex);*/ }
            }
        }


        //シェイプ増加
        private void ShapeKeyIncrease(int maidID, string[] name, float max, float sp)
        {

            Maid maid = stockMaids[maidID].mem;
            sp *= Time.deltaTime * ShapeKeySpeedRate;

            maidsState[maidID].shapeKeyIncreaseValue = maidsState[maidID].shapeKeyIncreaseValue + sp;

            if (maidsState[maidID].shapeKeyIncreaseValue > max)
            {
                maidsState[maidID].shapeKeyIncreaseValue = 0f;
            }
            else if (maidsState[maidID].shapeKeyIncreaseValue < 0f)
            {
                maidsState[maidID].shapeKeyIncreaseValue = max;
            }

            for (int i = 0; i < name.Length; i++)
            {
                try { VertexMorph_FromProcItem(maid.body0, name[i], maidsState[maidID].shapeKeyIncreaseValue / 100f); } catch { /*LogError(ex);*/ }
            }
        }


        //シェイプランダム
        private void ShapeKeyRandam(int maidID, string[] name, float min, float max)
        {

            Maid maid = stockMaids[maidID].mem;
            maidsState[maidID].shapeKeyRandomDelta -= timerRate;

            if (maidsState[maidID].shapeKeyRandomDelta > 0) return;
            maidsState[maidID].shapeKeyRandomDelta = 0.1f;

            for (int i = 0; i < name.Length; i++)
            {
                float value = UnityEngine.Random.Range(min, max);
                try { VertexMorph_FromProcItem(maid.body0, name[i], value / 100f); } catch { /*LogError(ex);*/ }
            }
        }


        //シェイプキー関係終了------------------------------




        //--------------------------------------------------
        //オートモード関係----------------------------------

        //責めの激しさを自動で変える
        public string[] autoSelectList = new string[] { "オート無効", "じっくり", "激しく", "ほどほど" };
        private void PowerAutoChange(int maidID)
        {

            if (maidsState[maidID].pAutoSelect == 0) return;
            if (maidsState[maidID].pAutoTime > 0 || (maidsState[maidID].orgasmCmb != 0 && maidsState[maidID].pAutoSelect == 2))
            {
                maidsState[maidID].pAutoTime -= timerRate;
                return;
            }

            if (maidsState[maidID].vLevel == 0 || maidsState[maidID].vLevel == 2)
            {
                maidsState[maidID].vLevel = 1;

                if (maidsState[maidID].pAutoSelect == 1)
                {//じっくりモード
                    maidsState[maidID].pAutoTime = UnityEngine.Random.Range(600, 1000);
                }
                if (maidsState[maidID].pAutoSelect == 2)
                {//激しくモード
                    maidsState[maidID].pAutoTime = UnityEngine.Random.Range(250, 400);
                }
                if (maidsState[maidID].pAutoSelect == 3)
                {//ほどほどモード
                    maidsState[maidID].pAutoTime = UnityEngine.Random.Range(400, 700);
                }

            }
            else if (maidsState[maidID].vLevel == 1)
            {
                maidsState[maidID].vLevel = 2;

                if (maidsState[maidID].pAutoSelect == 1)
                {//じっくりモード
                    if (UnityEngine.Random.Range(0, 100) < 15)
                    {
                        maidsState[maidID].vLevel = 0;
                        maidsState[maidID].pAutoTime = UnityEngine.Random.Range(250, 600);
                    }
                    else
                    {
                        maidsState[maidID].pAutoTime = UnityEngine.Random.Range(300, 480);
                    }
                }
                if (maidsState[maidID].pAutoSelect == 2)
                {//激しくモード
                    maidsState[maidID].pAutoTime = UnityEngine.Random.Range(600, 1000);
                }
                if (maidsState[maidID].pAutoSelect == 3)
                {//ほどほどりモード
                    if (UnityEngine.Random.Range(0, 100) < 15)
                    {
                        maidsState[maidID].vLevel = 0;
                    }
                    maidsState[maidID].pAutoTime = UnityEngine.Random.Range(400, 700);
                }
            }

            /*if(maidID == tgID){
              foreach(int id in vmId){
                if(id == tgID || !maidsState[id].linkEnabled)continue;
                maidsState[id].vLevel = maidsState[tgID].vLevel;
              }
            }*/

            foreach (int id in vmId)
            {
                if (id == maidID || !LinkMaidCheck(maidID, id)) continue;
                maidsState[id].vLevel = maidsState[maidID].vLevel;
                maidsState[id].pAutoTime = maidsState[maidID].pAutoTime;
            }

        }

        //顔と目線の向きを自動で変える
        private void EyeAutoChange(int maidID)
        {

            if (!maidsState[maidID].eAutoSelect) return;
            if (maidsState[maidID].eAutoTime > 0)
            {
                maidsState[maidID].eAutoTime -= timerRate;
                return;
            }

            Maid maid = stockMaids[maidID].mem;
            if (!DistanceToMaid(maidID, 8f))
            {
                maid.body0.boEyeToCam = false;
                maid.body0.boHeadToCam = false;
                return;
            }

            if (UnityEngine.Random.Range(0, 100) < 50) maid.body0.boEyeToCam = !maid.body0.boEyeToCam;
            if (maid.body0.boHeadToCam)
            {
                if (UnityEngine.Random.Range(0, 100) < 70) maid.body0.boHeadToCam = !maid.body0.boHeadToCam;
            }
            else
            {
                if (UnityEngine.Random.Range(0, 100) < 30) maid.body0.boHeadToCam = !maid.body0.boHeadToCam;
            }

            if (maidsState[maidID].stunFlag) maid.body0.boEyeToCam = false;
            if (maidsState[maidID].stunFlag || maidsState[maidID].bIsBlowjobing == 2 || maidsState[maidID].bIsBlowjobing == 1) maid.body0.boHeadToCam = false;

            maidsState[maidID].eAutoTime = UnityEngine.Random.Range(400, 600);

        }




        //オートモード関係終了------------------------------






        //-------------------------------------------------
        //外部データ読み込み関係---------------------------------

        //XMLファイルのリストアップ処理
        private List<string> bvsFiles = new List<string>();
        private List<string> evsFiles = new List<string>();
        private List<string> emsFiles = new List<string>();
        private List<string> cdsFiles = new List<string>();
        private void XmlFilesCheck()
        {

            List<string> _files = new List<string>();
            string fileName = "";
            string[] files;

            //基本ボイスセットのフォルダ確認
            if (System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\BasicVoiseSet\"))
            {
                _files.Clear();
                files = Directory.GetFiles(@"Sybaris\UnityInjector\Config\VibeYourMaid\BasicVoiseSet\", "*.xml");

                foreach (string file in files)
                {
                    fileName = Path.GetFileName(file);
                    if (Regex.IsMatch(fileName, "^bvs_")) _files.Add(fileName);
                }
                bvsFiles = new List<string>(_files);
            }

            //エディットボイスセットのフォルダ確認
            if (System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditVoiseSet\"))
            {
                _files.Clear();
                files = Directory.GetFiles(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditVoiseSet\", "*.xml");

                foreach (string file in files)
                {
                    fileName = Path.GetFileName(file);
                    if (Regex.IsMatch(fileName, "^evs_")) _files.Add(fileName);
                }
                evsFiles = new List<string>(_files);
            }

            //エディットモーションセットのフォルダ確認
            if (System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditMotionSet\"))
            {
                _files.Clear();
                files = Directory.GetFiles(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditMotionSet\", "*.xml");

                foreach (string file in files)
                {
                    fileName = Path.GetFileName(file);
                    if (Regex.IsMatch(fileName, "^ems_")) _files.Add(fileName);
                }
                emsFiles = new List<string>(_files);
            }

            //共通衣装セットのフォルダ確認
            if (System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\CommonDressSet\"))
            {
                _files.Clear();
                files = Directory.GetFiles(@"Sybaris\UnityInjector\Config\VibeYourMaid\CommonDressSet\", "*.xml");

                foreach (string file in files)
                {
                    fileName = Path.GetFileName(file);
                    if (Regex.IsMatch(fileName, "^cds_")) _files.Add(fileName);
                }
                cdsFiles = new List<string>(_files);
            }

        }


        //テキストファイル読み込み処理
        private List<string> ReadTextFaile(string file, string section)
        {

            System.IO.StreamReader sr = new System.IO.StreamReader(file);
            bool ReadFlag = false;
            List<string> _ListData = new List<string>();

            while (sr.Peek() > -1)
            {
                string m = sr.ReadLine();

                if (!ReadFlag && m == "[" + section + "]")
                {
                    ReadFlag = true;
                    continue;
                }
                if (ReadFlag && m == "[end]")
                {
                    ReadFlag = false;
                    break;
                }

                if (ReadFlag)
                {
                    _ListData.Add(m);
                }

            }
            return _ListData;
        }


        //ConfigXMLファイルの保存・読み込み
        private void ConfigFileSave()
        {

            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\config.xml"; //保存先のファイル名

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(VibeYourMaidCfgWriting)); //XmlSerializerオブジェクトを作成。オブジェクトの型を指定する

            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false)); //書き込むファイルを開く（UTF-8 BOM無し）

            serializer.Serialize(sw, cfgw); //シリアル化し、XMLファイルに保存する

            sw.Close(); //ファイルを閉じる
        }
        private void ConfigFileLoad()
        {

            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\config.xml"; //保存先のファイル名
            Console.WriteLine(fileName);
            if (!System.IO.File.Exists(fileName)) return;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(VibeYourMaidCfgWriting)); //XmlSerializerオブジェクトを作成

            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false)); //読み込むファイルを開く

            cfgw = (VibeYourMaidCfgWriting)serializer.Deserialize(sr); //XMLファイルから読み込み、逆シリアル化する

            sr.Close(); //ファイルを閉じる
            Console.WriteLine("読み込み完了");
        }


        //基本ボイスセットの保存・読み込み
        private void BvsFileSave()
        {

            for (int i = 0; i < personalList[1].Length; i++)
            {
                string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\BasicVoiseSet\bvs_" + i.ToString("d2") + personalList[1][i] + ".xml";  //保存先のファイル名

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(BasicVoiceSet));  //XmlSerializerオブジェクトを作成。オブジェクトの型を指定する

                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));  //書き込むファイルを開く（UTF-8 BOM無し）

                serializer.Serialize(sw, bvs[i]);  //シリアル化し、XMLファイルに保存する

                Console.WriteLine("ボイスセット保存完了：" + personalList[1][i]);
                sw.Close(); //ファイルを閉じる
            }
        }
        private void BvsFileLoad()
        {

            for (int i = 0; i < personalList[1].Length; i++)
            {
                string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\BasicVoiseSet\bvs_" + i.ToString("d2") + personalList[1][i] + ".xml";  //保存先のファイル名
                if (!System.IO.File.Exists(fileName)) continue;

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(BasicVoiceSet));  //XmlSerializerオブジェクトを作成。オブジェクトの型を指定する            

                System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));  //読み込むファイルを開く

                //XMLファイルから読み込み、逆シリアル化する
                bvs[i] = (BasicVoiceSet)serializer.Deserialize(sr);

                sr.Close(); //ファイルを閉じる
            }

        }

        //基本ボイスセットから、存在しないファイルを除外
        private void BvsCheck()
        {

            var _vf = new List<string>();
            for (int i = 0; i < bvs.Length; i++)
            {

                for (int i2 = 0; i2 < 5; i2++)
                {
                    _vf = new List<string>();
                    _vf.AddRange(bvs[i].sLoopVoice20Vibe[i2]);
                    for (int i3 = 0; i3 < _vf.Count; i3++)
                    {
                        if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                        {
                            Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                            _vf.RemoveAt(i3);
                            i3--;
                        }
                    }
                    bvs[i].sLoopVoice20Vibe[i2] = _vf.ToArray();
                }

                for (int i2 = 0; i2 < 5; i2++)
                {
                    _vf = new List<string>();
                    _vf.AddRange(bvs[i].sLoopVoice20Fera[i2]);
                    for (int i3 = 0; i3 < _vf.Count; i3++)
                    {
                        if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                        {
                            Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                            _vf.RemoveAt(i3);
                            i3--;
                        }
                    }
                    bvs[i].sLoopVoice20Fera[i2] = _vf.ToArray();
                }

                for (int i2 = 0; i2 < 5; i2++)
                {
                    _vf = new List<string>();
                    _vf.AddRange(bvs[i].sLoopVoice30Vibe[i2]);
                    for (int i3 = 0; i3 < _vf.Count; i3++)
                    {
                        if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                        {
                            Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                            _vf.RemoveAt(i3);
                            i3--;
                        }
                    }
                    bvs[i].sLoopVoice30Vibe[i2] = _vf.ToArray();
                }

                for (int i2 = 0; i2 < 5; i2++)
                {
                    _vf = new List<string>();
                    _vf.AddRange(bvs[i].sLoopVoice30Fera[i2]);
                    for (int i3 = 0; i3 < _vf.Count; i3++)
                    {
                        if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                        {
                            Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                            _vf.RemoveAt(i3);
                            i3--;
                        }
                    }
                    bvs[i].sLoopVoice30Fera[i2] = _vf.ToArray();
                }

                for (int i2 = 0; i2 < 5; i2++)
                {
                    _vf = new List<string>();
                    _vf.AddRange(bvs[i].sOrgasmVoice30Vibe[i2]);
                    for (int i3 = 0; i3 < _vf.Count; i3++)
                    {
                        if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                        {
                            Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                            _vf.RemoveAt(i3);
                            i3--;
                        }
                    }
                    bvs[i].sOrgasmVoice30Vibe[i2] = _vf.ToArray();
                }

                for (int i2 = 0; i2 < 5; i2++)
                {
                    _vf = new List<string>();
                    _vf.AddRange(bvs[i].sOrgasmVoice30Fera[i2]);
                    for (int i3 = 0; i3 < _vf.Count; i3++)
                    {
                        if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                        {
                            Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                            _vf.RemoveAt(i3);
                            i3--;
                        }
                    }
                    bvs[i].sOrgasmVoice30Fera[i2] = _vf.ToArray();
                }


                _vf = new List<string>();
                _vf.AddRange(bvs[i].sLoopVoice40Vibe);
                for (int i3 = 0; i3 < _vf.Count; i3++)
                {
                    if (!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg")
                    {
                        Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                        _vf.RemoveAt(i3);
                        i3--;
                    }
                }
                bvs[i].sLoopVoice40Vibe = _vf.ToArray();

            }

        }


        //MotionAdjustXMLファイルの保存・読み込み
        private void MajFileSave()
        {

            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\MotionAdjust.xml"; //保存先のファイル名

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MotionAdjust)); //XmlSerializerオブジェクトを作成。オブジェクトの型を指定する

            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false)); //書き込むファイルを開く（UTF-8 BOM無し）

            serializer.Serialize(sw, maj); //シリアル化し、XMLファイルに保存する

            sw.Close(); //ファイルを閉じる
        }
        private void MajFileLoad()
        {

            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\MotionAdjust.xml"; //保存先のファイル名
            Console.WriteLine(fileName);
            if (!System.IO.File.Exists(fileName)) return;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MotionAdjust)); //XmlSerializerオブジェクトを作成

            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false)); //読み込むファイルを開く

            maj = (MotionAdjust)serializer.Deserialize(sr); //XMLファイルから読み込み、逆シリアル化する

            sr.Close(); //ファイルを閉じる
            Console.WriteLine("読み込み完了");

            //新規に追加された項目があれば初期値を設定
            int nameC = maj.motionName.Count;
            for (int i = maj.iTargetLH.Count; i < nameC; i++)
            {
                maj.iTargetLH.Add(0);
            }
            for (int i = maj.iTargetRH.Count; i < nameC; i++)
            {
                maj.iTargetRH.Add(0);
            }
            for (int i = maj.syaseiMarks.Count; i < nameC; i++)
            {
                int[] ni = new int[] { 0, 0, 0, 0, 0 };
                maj.syaseiMarks.Add(ni);
            }
            for (int i = maj.giveSexual.Count; i < nameC; i++)
            {
                bool[] nb = new bool[] { false, false, false, false, false, false, false, false, false, false };
                maj.giveSexual.Add(nb);
            }
            for (int i = maj.itemSet.Count; i < nameC; i++)
            {
                bool[] nb = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                maj.itemSet.Add(nb);
            }
            for (int i = maj.prefabSet.Count; i < nameC; i++)
            {
                maj.prefabSet.Add(0);
            }
            for (int i = maj.baceMotion.Count; i < nameC; i++)
            {
                maj.baceMotion.Add("");
            }
            for (int i = maj.basicForward.Count; i < nameC; i++)
            {
                maj.basicForward.Add(0f);
            }
            for (int i = maj.mansForward.Count; i < nameC; i++)
            {
                maj.mansForward.Add(0f);
            }
            for (int i = maj.mansRight.Count; i < nameC; i++)
            {
                maj.mansRight.Add(0f);
            }
            for (int i = maj.maidRoll.Count; i < nameC; i++)
            {
                maj.maidRoll.Add(0);
            }
            for (int i = maj.manRoll.Count; i < nameC; i++)
            {
                maj.manRoll.Add(0);
            }
            for (int i = maj.rollSettei.Count; i < nameC; i++)
            {
                maj.rollSettei.Add(0);
            }
            for (int i = maj.analEnabled.Count; i < nameC; i++)
            {
                maj.analEnabled.Add(false);
            }
            for (int i = maj.analHeight.Count; i < nameC; i++)
            {
                maj.analHeight.Add(0f);
            }
            for (int i = maj.analForward.Count; i < nameC; i++)
            {
                maj.analForward.Add(0f);
            }
            for (int i = maj.analRight.Count; i < nameC; i++)
            {
                maj.analRight.Add(0f);
            }
        }


        //共通衣装データ
        public CommonDressSet cds = new CommonDressSet();
        public class CommonDressSet
        {
            public CommonDressSet()
            {
                acchat = "";
                headset = "";
                wear = "";
                skirt = "";
                onepiece = "";
                mizugi = "";
                bra = "";
                panz = "";
                stkg = "";
                shoes = "";
                megane = "";
                acchead = "";
                glove = "";
                accude = "";
                acchana = "";
                accmimi = "";
                accnip = "";
                acckubi = "";
                acckubiwa = "";
                accheso = "";
                accashi = "";
                accsenaka = "";
                accshippo = "";
                accxxx = "";
            }
            public string acchat;
            public string headset;
            public string wear;
            public string skirt;
            public string onepiece;
            public string mizugi;
            public string bra;
            public string panz;
            public string stkg;
            public string shoes;
            public string megane;
            public string acchead;
            public string glove;
            public string accude;
            public string acchana;
            public string accmimi;
            public string accnip;
            public string acckubi;
            public string acckubiwa;
            public string accheso;
            public string accashi;
            public string accsenaka;
            public string accshippo;
            public string accxxx;
        }

        //共通衣装XMLファイルの保存・読み込み
        private void CdsFileSave(string name)
        {

            Maid maid = stockMaids[tgID].mem;

            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\CommonDressSet\cds_" + name + ".xml";  //保存先のファイル名
            if (name == "")
            {
                dsErrer = 1;
                return;
            }
            if (System.IO.File.Exists(fileName) && !ds_Overwrite[4])
            {
                dsErrer = 2;
                return;
            }

            //現在の衣装データを読み込み
            if (setAcchat) cds.acchat = maid.GetProp(MPN.acchat).strFileName;
            if (setHeadset) cds.headset = maid.GetProp(MPN.headset).strFileName;
            if (setWear) cds.wear = maid.GetProp(MPN.wear).strFileName;
            if (setSkirt) cds.skirt = maid.GetProp(MPN.skirt).strFileName;
            if (setOnepiece) cds.onepiece = maid.GetProp(MPN.onepiece).strFileName;
            if (setMizugi) cds.mizugi = maid.GetProp(MPN.mizugi).strFileName;
            if (setBra) cds.bra = maid.GetProp(MPN.bra).strFileName;
            if (setPanz) cds.panz = maid.GetProp(MPN.panz).strFileName;
            if (setStkg) cds.stkg = maid.GetProp(MPN.stkg).strFileName;
            if (setShoes) cds.shoes = maid.GetProp(MPN.shoes).strFileName;
            if (setMegane) cds.megane = maid.GetProp(MPN.megane).strFileName;
            if (setAcchead) cds.acchead = maid.GetProp(MPN.acchead).strFileName;
            if (setGlove) cds.glove = maid.GetProp(MPN.glove).strFileName;
            if (setAccude) cds.accude = maid.GetProp(MPN.accude).strFileName;
            if (setAcchana) cds.acchana = maid.GetProp(MPN.acchana).strFileName;
            if (setAccmimi) cds.accmimi = maid.GetProp(MPN.accmimi).strFileName;
            if (setAccnip) cds.accnip = maid.GetProp(MPN.accnip).strFileName;
            if (setAcckubi) cds.acckubi = maid.GetProp(MPN.acckubi).strFileName;
            if (setAcckubiwa) cds.acckubiwa = maid.GetProp(MPN.acckubiwa).strFileName;
            if (setAccheso) cds.accheso = maid.GetProp(MPN.accheso).strFileName;
            if (setAccashi) cds.accashi = maid.GetProp(MPN.accashi).strFileName;
            if (setAccsenaka) cds.accsenaka = maid.GetProp(MPN.accsenaka).strFileName;
            if (setAccshippo) cds.accshippo = maid.GetProp(MPN.accshippo).strFileName;
            if (setAccxxx) cds.accxxx = maid.GetProp(MPN.accxxx).strFileName;
            if (!setAcchat) cds.acchat = "";
            if (!setHeadset) cds.headset = "";
            if (!setWear) cds.wear = "";
            if (!setSkirt) cds.skirt = "";
            if (!setOnepiece) cds.onepiece = "";
            if (!setMizugi) cds.mizugi = "";
            if (!setBra) cds.bra = "";
            if (!setPanz) cds.panz = "";
            if (!setStkg) cds.stkg = "";
            if (!setShoes) cds.shoes = "";
            if (!setMegane) cds.megane = "";
            if (!setAcchead) cds.acchead = "";
            if (!setGlove) cds.glove = "";
            if (!setAccude) cds.accude = "";
            if (!setAcchana) cds.acchana = "";
            if (!setAccmimi) cds.accmimi = "";
            if (!setAccnip) cds.accnip = "";
            if (!setAcckubi) cds.acckubi = "";
            if (!setAcckubiwa) cds.acckubiwa = "";
            if (!setAccheso) cds.accheso = "";
            if (!setAccashi) cds.accashi = "";
            if (!setAccsenaka) cds.accsenaka = "";
            if (!setAccshippo) cds.accshippo = "";
            if (!setAccxxx) cds.accxxx = "";

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonDressSet));  //XmlSerializerオブジェクトを作成。オブジェクトの型を指定する

            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));  //書き込むファイルを開く（UTF-8 BOM無し）

            serializer.Serialize(sw, cds);  //シリアル化し、XMLファイルに保存する

            Console.WriteLine("共通衣装セット保存完了：" + name);
            dsErrer = 0;
        }
        private void CdsFileLoad(string xml)
        {

            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\CommonDressSet\" + xml;  //保存先のファイル名
            if (!System.IO.File.Exists(fileName)) return;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommonDressSet));  //XmlSerializerオブジェクトを作成。オブジェクトの型を指定する            

            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));  //読み込むファイルを開く

            //XMLファイルから読み込み、逆シリアル化する
            cds = (CommonDressSet)serializer.Deserialize(sr);

            sr.Close(); //ファイルを閉じる

            //衣装データを適用
            Maid maid = stockMaids[tgID].mem;
            if (cds.acchat != "") maid.SetProp(MPN.acchat, cds.acchat, 0, true, false);
            if (cds.headset != "") maid.SetProp(MPN.headset, cds.headset, 0, true, false);
            if (cds.wear != "") maid.SetProp(MPN.wear, cds.wear, 0, true, false);
            if (cds.skirt != "") maid.SetProp(MPN.skirt, cds.skirt, 0, true, false);
            if (cds.onepiece != "") maid.SetProp(MPN.onepiece, cds.onepiece, 0, true, false);
            if (cds.mizugi != "") maid.SetProp(MPN.mizugi, cds.mizugi, 0, true, false);
            if (cds.bra != "") maid.SetProp(MPN.bra, cds.bra, 0, true, false);
            if (cds.panz != "") maid.SetProp(MPN.panz, cds.panz, 0, true, false);
            if (cds.stkg != "") maid.SetProp(MPN.stkg, cds.stkg, 0, true, false);
            if (cds.shoes != "") maid.SetProp(MPN.shoes, cds.shoes, 0, true, false);
            if (cds.megane != "") maid.SetProp(MPN.megane, cds.megane, 0, true, false);
            if (cds.acchead != "") maid.SetProp(MPN.acchead, cds.acchead, 0, true, false);
            if (cds.glove != "") maid.SetProp(MPN.glove, cds.glove, 0, true, false);
            if (cds.accude != "") maid.SetProp(MPN.accude, cds.accude, 0, true, false);
            if (cds.acchana != "") maid.SetProp(MPN.acchana, cds.acchana, 0, true, false);
            if (cds.accmimi != "") maid.SetProp(MPN.accmimi, cds.accmimi, 0, true, false);
            if (cds.accnip != "") maid.SetProp(MPN.accnip, cds.accnip, 0, true, false);
            if (cds.acckubi != "") maid.SetProp(MPN.acckubi, cds.acckubi, 0, true, false);
            if (cds.acckubiwa != "") maid.SetProp(MPN.acckubiwa, cds.acckubiwa, 0, true, false);
            if (cds.accheso != "") maid.SetProp(MPN.accheso, cds.accheso, 0, true, false);
            if (cds.accashi != "") maid.SetProp(MPN.accashi, cds.accashi, 0, true, false);
            if (cds.accsenaka != "") maid.SetProp(MPN.accsenaka, cds.accsenaka, 0, true, false);
            if (cds.accshippo != "") maid.SetProp(MPN.accshippo, cds.accshippo, 0, true, false);
            if (cds.accxxx != "") maid.SetProp(MPN.accxxx, cds.accxxx, 0, true, false);

            AllDressVisible(tgID, true);
            maid.AllProcPropSeqStart();
            Console.WriteLine("共通衣装 セット完了");
        }


        private void AllDressVisible(int maidID, bool b)
        {

            Maid maid = stockMaids[maidID].mem;

            maid.body0.SetMask(TBody.SlotID.headset, b);
            maid.body0.SetMask(TBody.SlotID.hairAho, b);
            maid.body0.SetMask(TBody.SlotID.accHana, b);
            maid.body0.SetMask(TBody.SlotID.accMiMiR, b);
            maid.body0.SetMask(TBody.SlotID.accNipR, b);
            maid.body0.SetMask(TBody.SlotID.accMiMiL, b);
            maid.body0.SetMask(TBody.SlotID.accNipL, b);
            maid.body0.SetMask(TBody.SlotID.accHeso, b);
            maid.body0.SetMask(TBody.SlotID.accAshi, b);
            maid.body0.SetMask(TBody.SlotID.accSenaka, b);
            maid.body0.SetMask(TBody.SlotID.accShippo, b);
            maid.body0.SetMask(TBody.SlotID.megane, b);
            maid.body0.SetMask(TBody.SlotID.accXXX, b);
            maid.body0.SetMask(TBody.SlotID.accHat, b);
            maid.body0.SetMask(TBody.SlotID.wear, b);
            maid.body0.SetMask(TBody.SlotID.mizugi, b);
            maid.body0.SetMask(TBody.SlotID.onepiece, b);
            maid.body0.SetMask(TBody.SlotID.bra, b);
            maid.body0.SetMask(TBody.SlotID.skirt, b);
            maid.body0.SetMask(TBody.SlotID.panz, b);
            maid.body0.SetMask(TBody.SlotID.glove, b);
            maid.body0.SetMask(TBody.SlotID.accUde, b);
            maid.body0.SetMask(TBody.SlotID.stkg, b);
            maid.body0.SetMask(TBody.SlotID.shoes, b);
            maid.body0.SetMask(TBody.SlotID.accKubi, b);
            maid.body0.SetMask(TBody.SlotID.accKubiwa, b);
        }


        //外部データ読み込み関係終了----------------------------




        //-------------------------------------------------
        //ボイスセット関係---------------------------------
        private bool vs_Overwrite = false;
        private int vsErrer = 0;
        private string[] vsErrerText = new string[] { "", "ボイスセット名が空白のため保存できません", "上書きする場合は『上書／ｸﾘｱ』にチェックを入れて下さい", "クリアする場合は『上書／ｸﾘｱ』にチェックを入れて下さい" };
        private List<int> iPersonal = new List<int>();
        private string[] vsState = new string[] { "弱", "強", "余韻時", "停止時", "指定無" };
        private string[] vsCondition = new string[] { "通常", "キス", "フェラ", "絶頂後", "放心", "指定無" };
        private string[] vsLevel = new string[] { "0", "1", "2", "3", "－" };
        private int[] fVoiceSet = new int[] { 15, 4, 4, 4, 5 };
        private int[] fVoiceSet2 = new int[] { 0, 0 };

        VoiceSet_Xml VSX = new VoiceSet_Xml();
        public class VoiceSet_Xml
        {
            public string saveVoiceSetName = "";
            public List<string[]> saveVoiceSet = new List<string[]>{
            new string[] { "" , "0" , "0" , "3" , "0" , "3" , "0" , "0" } //ファイル名、性格、興奮低、興奮高、絶頂低、絶頂高、強度、メイド状態
          };

        }

        //ボイスセットXMLファイルを読み込む
        private void voiceSetLoad(string xml, int maidID)
        {

            //保存先のファイル名
            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EditVoiseSet\" + xml;
            Console.WriteLine(fileName);

            if (System.IO.File.Exists(fileName))
            {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(VoiceSet_Xml));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));

                //XMLファイルから読み込み、逆シリアル化する
                VSX = (VoiceSet_Xml)serializer.Deserialize(sr);

                //ファイルを閉じる
                sr.Close();
                Console.WriteLine("読み込み完了");

                //読み込んだ情報を挿入
                maidsState[maidID].editVoiceSetName = VSX.saveVoiceSetName;
                maidsState[maidID].editVoiceSet = new List<string[]>(VSX.saveVoiceSet);
            }
        }

        //ボイスセットをXMLファイルに保存する
        private void voiceSetSave()
        {

            // フォルダ確認
            if (!System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditVoiseSet\"))
            {
                //ない場合はフォルダ作成
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(@"Sybaris\UnityInjector\Config\VibeYourMaid\EditVoiseSet");
            }


            if (VSX.saveVoiceSetName == "")
            {  //ボイスセット名が空白の場合保存しない
                vsErrer = 1;

            }
            else
            {
                //保存先のファイル名
                string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EditVoiseSet\evs_" + VSX.saveVoiceSetName + @".xml";

                if (System.IO.File.Exists(fileName) && !vs_Overwrite)
                {  //上書きのチェック
                    vsErrer = 2;

                }
                else
                {

                    //XmlSerializerオブジェクトを作成
                    //オブジェクトの型を指定する
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(VoiceSet_Xml));

                    //書き込むファイルを開く（UTF-8 BOM無し）
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));

                    //シリアル化し、XMLファイルに保存する
                    serializer.Serialize(sw, VSX);
                    //ファイルを閉じる
                    sw.Close();

                    vs_Overwrite = false;
                    vsErrer = 0;
                }
            }
        }

        //ボイスセット再生処理
        private void VoiceSetPlay(int maidID)
        {

            string[] vsFile;
            Maid maid = stockMaids[maidID].mem;

            //音声が終わった時の処理
            if (maidsState[maidID].vsFlag == 2 && !maid.AudioMan.audiosource.isPlaying)
            {
                maidsState[maidID].vsFlag = 0;        //再生中フラグOFF
                maidsState[maidID].voiceHoldTime = 0;  //音声をすぐ再生するため、タイマーリセット
            }

            if (maidsState[maidID].orgasmVoice != 0 || VSX.saveVoiceSetName == "") return;

            if (maidsState[maidID].vsFlag == 0) maidsState[maidID].vsTime -= timerRate; //再生していないときだけタイマーを動かす

            if (maidsState[maidID].vsTime < 0)
            {
                vsFile = VoiceSetCheck(maidID); //該当する音声ファイルをリストアップ

                Console.WriteLine("ボイスセット再生開始：" + maidsState[maidID].vsFlag);

                //音声再生
                if (maidsState[maidID].vsFlag == 1)
                {
                    int iRandomVoice = UnityEngine.Random.Range(0, vsFile.Length);
                    maid.AudioMan.LoadPlay(vsFile[iRandomVoice], 0f, false, false);

                    if (maid.AudioMan.FileName == vsFile[iRandomVoice])
                    {
                        maidsState[maidID].vsFlag = 2; //再生中フラグON
                    }
                    else
                    {
                        maidsState[maidID].vsFlag = 0; //再生フラグOFF
                    }
                }
                maidsState[maidID].vsTime = UnityEngine.Random.Range(maidsState[maidID].vsInterval - 200f, maidsState[maidID].vsInterval + 200f);
            }
        }


        //ボイスセットの該当チェック
        private string[] VoiceSetCheck(int maidID)
        {

            int iPersonal = Array.IndexOf(personalList[1], stockMaids[maidID].personal);
            if (maidsState[maidID].voiceMode2 > 0) iPersonal = maidsState[maidID].voiceMode2 - 1;

            int eLevel = maidsState[maidID].exciteLevel - 1;

            int oLevel;
            if (Math.Floor(maidsState[maidID].orgasmValue) < 30)
            {
                oLevel = 0;
            }
            else if (Math.Floor(maidsState[maidID].orgasmValue) < 50)
            {
                oLevel = 1;
            }
            else if (Math.Floor(maidsState[maidID].orgasmValue) < 80)
            {
                oLevel = 2;
            }
            else
            {
                oLevel = 3;
            }

            int iState = -1;
            if (maidsState[maidID].vStateMajor == 20) iState = 0;
            if (maidsState[maidID].vStateMajor == 30) iState = 1;
            if (maidsState[maidID].vStateMajor == 40) iState = 2;
            if (maidsState[maidID].vStateMajor == 10) iState = 3;

            checkBlowjobing(maidID);
            int iCondition = maidsState[maidID].bIsBlowjobing;
            if (maidsState[maidID].orgasmHoldTime > 0) iCondition = 3;
            if (maidsState[maidID].stunFlag) iCondition = 4;

            List<string> _vsFile = new List<string>();
            List<string[]> vsList = maidsState[maidID].editVoiceSet;
            foreach (string[] vs in vsList)
            {
                if (Regex.IsMatch(vs[2], "[^0-3]")) vs[2] = "0";
                if (Regex.IsMatch(vs[3], "[^0-3]")) vs[3] = "3";
                if (Regex.IsMatch(vs[4], "[^0-3]")) vs[4] = "0";
                if (Regex.IsMatch(vs[5], "[^0-3]")) vs[5] = "3";

                if (vs[0] != "" && (intCnv(vs[1]) == iPersonal || intCnv(vs[1]) == personalList[0].Length - 1)
                   && (intCnv(vs[2]) <= eLevel && eLevel <= intCnv(vs[3]))
                   && (intCnv(vs[4]) <= oLevel && oLevel <= intCnv(vs[5]))
                   && (intCnv(vs[6]) == iState || intCnv(vs[6]) == 4)
                   && (intCnv(vs[7]) == iCondition || intCnv(vs[7]) == 5))
                {
                    _vsFile.Add(vs[0]);
                    if (maidsState[maidID].vsFlag == 0) maidsState[maidID].vsFlag = 1;
                }
            }
            return _vsFile.ToArray();
        }



        //ボイスセット関係終了----------------------------




        //-------------------------------------------------
        //データ変換関係---------------------------------

        //int変換
        private int intCnv(string s)
        {
            if (Regex.IsMatch(s, "[^0-9]")) s = "0";
            int i = int.Parse(s);

            return i;
        }

        //float変換
        private float floatCnv(string s)
        {
            if (!Regex.IsMatch(s, @"^[-+]?[0-9]*\.?[0-9]+$")) s = "0";
            float i = float.Parse(s);

            return i;
        }


        //データ変換関係終了----------------------------





        //-------------------------------------------------
        //その他処理---------------------------------------

        //フェードアウトチェック
        private class FadeMgr
        {
            public static bool isFade { get; private set; }
            public static bool isFadeMySelf { get; set; }

            public static void FadeOut()
            {
                isFadeMySelf = true;
                GameMain.Instance.LoadIcon.force_draw_new = true;
                GameMain.Instance.MainCamera.FadeOut(0f, false, null, true, default(Color));
            }

            public static void FadeIn()
            {
                if (GameMain.Instance.MainCamera.IsFadeProc() && isFadeMySelf)
                    return;

                isFadeMySelf = false;
                GameMain.Instance.LoadIcon.force_draw_new = false;
                GameMain.Instance.MainCamera.FadeIn(0f, false, null, true, true, default(Color));

            }

            public static bool GetFadeIn()
            {
                if (GameMain.Instance.MainCamera.IsFadeProc())
                    isFade = true;
                else if (isFade && !GameMain.Instance.MainCamera.IsFadeProc())
                {
                    isFade = false;
                    return true;
                }
                return false;
            }
        }


        //ダブルクリック判定処理
        private bool dClickL = false;
        private bool dClickR = false;
        private float delayTime1 = 0f;
        private float delayTime2 = 0f;
        private void DClicCheck()
        {
            if (delayTime1 > 0 && Input.GetMouseButtonDown(0)) dClickL = true;
            if (delayTime2 > 0 && Input.GetMouseButtonDown(1)) dClickR = true;

            if (delayTime1 <= 0 && Input.GetMouseButtonDown(0)) delayTime1 = 0.15f;
            if (delayTime2 <= 0 && Input.GetMouseButtonDown(1)) delayTime2 = 0.15f;

            if (!Input.GetMouseButtonDown(0) && dClickL) dClickL = false;
            if (!Input.GetMouseButtonDown(1) && dClickR) dClickR = false;
            if (delayTime1 > 0) delayTime1 -= Time.deltaTime;
            if (delayTime2 > 0) delayTime2 -= Time.deltaTime;
        }


        //男表示切替
        private IEnumerator MansVisible(int i)
        {
            SubMans[i].Visible = !SubMans[i].Visible;

            if (SubMans[i].Visible)
            {
                yield return new WaitForSeconds(1f);  // 1秒待つ

                MansTg[i] = tgID;
                SubMans[i].transform.position = stockMaids[MansTg[i]].mem.transform.position;
                SubMans[i].transform.eulerAngles = stockMaids[MansTg[i]].mem.transform.eulerAngles;
            }
        }

        private bool MansTgCheck(int maidID)
        {
            for (int im = 0; im < SubMans.Length; im++)
            {
                if (!SubMans[im]) SubMans[im] = GameMain.Instance.CharacterMgr.GetMan(im);
                if (MansTg[im] != maidID || !SubMans[im].Visible) continue;
                return true;
            }
            return false;
        }


        private bool AndKey()
        {
            bool andKey = false;
            int index1 = Array.IndexOf(cfgw.andKeyEnabled, true);
            if (index1 == -1)
            {
                if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) andKey = true;
            }
            else if (index1 == 0)
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) andKey = true;
            }
            else if (index1 == 1)
            {
                if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) andKey = true;
            }
            else if (index1 == 2)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) andKey = true;
            }

            return andKey;
        }

        //ショートカットキー
        private void ShortCutKey()
        {

            if ((ConfigFlag == 0 || ConfigFlag == 1 || !cfgw.configGuiFlag) && scKeyOff) scKeyOff = false;

            if (!scKeyOff && AndKey())
            {

                //　バイブの切替
                if (Input.GetKeyDown(cfgw.keyPluginToggleV4))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                        maidsState[maidID].vLevel = 2;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    Console.WriteLine("バイブ強");
                }

                if (Input.GetKeyDown(cfgw.keyPluginToggleV3))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                        maidsState[maidID].vLevel = 1;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    Console.WriteLine("バイブ弱");
                }

                if (Input.GetKeyDown(cfgw.keyPluginToggleV2))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                        maidsState[maidID].vLevel = 0;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    Console.WriteLine("バイブ停止");
                }

                //　メイド切替
                if (Input.GetKeyDown(cfgw.keyPluginToggleV5))
                {
                    int i = vmId.IndexOf(tgID) + 1;
                    if (i >= vmId.Count) i = 0;

                    tgID = vmId[i];
                    CameraChange(tgID);
                }

                //　男表示切替
                if (Input.GetKeyDown(cfgw.keyPluginToggleV6))
                {
                    if (!man) man = GameMain.Instance.CharacterMgr.GetMan(0);
                    if (man) StartCoroutine("MansVisible", 0);
                }


                //　感度全開（デバッグ用）
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    maidsState[tgID].orgasmCount = 50;
                    maidsState[tgID].boostValue = 50;
                    Console.WriteLine("感度全開");
                }


                //　GUI表示の切り替え
                if (Input.GetKeyDown(cfgw.keyPluginToggleV1))
                {
                    cfgw.mainGuiFlag = cfgw.mainGuiFlag + 1;
                    if (cfgw.mainGuiFlag > 2) cfgw.mainGuiFlag = 0;
                }

                //　一人称視点切り替え
                if (Input.GetKeyDown(cfgw.keyPluginToggleV7))
                {
                    fpsModeEnabled = !fpsModeEnabled;
                }

                //マウスホイールによる高さ調整
                if (!fpsModeEnabled)
                {
                    if (Input.GetMouseButton(0))
                    {
                        foreach (int maidID in vmId)
                        {
                            if (tgID != maidID && !LinkMaidCheck(tgID, maidID)) continue;
                            Vector3 vm = stockMaids[maidID].mem.transform.position;
                            stockMaids[maidID].mem.transform.position = new Vector3(vm.x, vm.y + Input.GetAxis("Mouse ScrollWheel") / 10, vm.z);
                        }
                        for (int i = 0; i < SubMans.Length; i++)
                        {
                            if (!SubMans[i].Visible || MansTg[i] != tgID) continue;
                            Vector3 vm = SubMans[i].transform.position;
                            SubMans[i].transform.position = new Vector3(vm.x, vm.y + Input.GetAxis("Mouse ScrollWheel") / 10, vm.z);
                        }
                    }

                    if (Input.GetMouseButton(1))
                    {
                        for (int i = 0; i < SubMans.Length; i++)
                        {
                            if (!SubMans[i].Visible || MansTg[i] != tgID) continue;
                            Vector3 vm = SubMans[i].transform.position;
                            SubMans[i].transform.position = new Vector3(vm.x, vm.y + Input.GetAxis("Mouse ScrollWheel") / 20, vm.z);
                        }
                    }
                }

                //　快感値ロック
                if (Input.GetKeyDown(cfgw.keyPluginToggleV8)) ExciteLock = !ExciteLock;

                //　絶頂値ロック
                if (Input.GetKeyDown(cfgw.keyPluginToggleV9)) OrgasmLock = !OrgasmLock;

                //　オートモード切り替え
                if (Input.GetKeyDown(cfgw.keyPluginToggleV10))
                {

                }

                //ランダムモーション変更
                if (maidsState[tgID].editMotionSetName != "")
                {
                    if (dClickL) maidsState[tgID].msTime1 = 0;  //左ダブルクリックでカテゴリチェンジ
                    if (dClickR) maidsState[tgID].msTime2 = 0;  //右ダブルクリックでモーションチェンジ
                }

            }

        }


        //一人称視点の処理
        private int frameCount;
        private float scrollValue = 0f;
        private float scrollValue2 = 0f;
        private Vector3 bManHeadPos = Vector3.zero;
        private GameObject manHead;
        private Renderer manHeadRen;
        private Transform manBipHead;
        private bool fpsModeEnabled = false; //一人称視点フラグ
        private bool bfpsMode = false;
        private float fieldOfViewBack = 35.0f;
        private bool vacationEnabled = false;
        private void FpsModeChange()
        {

            if (!fpsModeEnabled || !man.Visible)
            {
                if (bfpsMode)
                {
                    bfpsMode = false;
                    fpsModeEnabled = false;
                    if (!bOculusVR) Camera.main.fieldOfView = fieldOfViewBack;
                    manHeadRen.enabled = true;
                }
                return;
            }
            if (!bfpsMode)
            {
                bfpsMode = true;
                if (!bOculusVR)
                {
                    fieldOfViewBack = Camera.main.fieldOfView;
                    Camera.main.fieldOfView = 60.0f;
                }
                frameCount = 0;
            }

            Vector3 vNewPosition = Vector3.zero;

            if (frameCount <= 0)
            {

                //ご主人様の頭を取得する
                ManHeadGet();

                //ご主人様の頭を消す
                if (manHeadRen.enabled) manHeadRen.enabled = false;

                //カメラの移動チェック
                float fDistanceToMandHead = Vector3.Distance(bManHeadPos, mainCamera.transform.position);

                //大きく移動していれば向きを調整
                if (fDistanceToMandHead > 0.3f)
                {
                    if (100 < manHead.transform.eulerAngles.z && manHead.transform.eulerAngles.z < 260)
                    {
                        float cy = manHead.transform.eulerAngles.y + 180f;
                        if (cy >= 360) cy -= 360;
                        mainCamera.transform.eulerAngles = new Vector3(manHead.transform.eulerAngles.x, cy, 0.0f);
                    }
                    else
                    {
                        float cx = manHead.transform.eulerAngles.x + 90f;
                        if (cx >= 360) cx -= 360;
                        mainCamera.transform.eulerAngles = new Vector3(cx, manHead.transform.eulerAngles.y, 0.0f);
                    }
                    Console.WriteLine("カメラ向き変更");

                    scrollValue = 0f;  //ホイール値リセット
                }

                bManHeadPos = mainCamera.transform.position;

                frameCount = 30;
            }
            else
            {
                --frameCount;
            }


            //頭の位置を挿入
            vNewPosition = manHead.transform.position;

            //マウスホイールでカメラ位置の前後調整
            if (Input.GetMouseButton(0)) scrollValue += Input.GetAxis("Mouse ScrollWheel") / 10;
            if (Input.GetMouseButton(1)) scrollValue2 += Input.GetAxis("Mouse ScrollWheel") / 10;
            if (scrollValue > 0.2f) scrollValue = 0.2f;
            if (scrollValue < -0.2f) scrollValue = -0.2f;
            if (Input.GetMouseButtonDown(2))
            {
                scrollValue = 0f;
                scrollValue2 = 0f;
            }
            if (scrollValue != 0 || scrollValue2 != 0)
            {
                Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;
                Vector3 moveForward = cameraForward * scrollValue + Camera.main.transform.up * scrollValue2;
                vNewPosition += moveForward;
            }

            //カメラ位置の移動
            if (!bOculusVR)
            {
                mainCamera.SetPos(vNewPosition);
                if (!vacationEnabled)
                {
                    mainCamera.SetTargetPos(vNewPosition, true);
                    mainCamera.SetDistance(0f, true);
                }
            }
            else
            {
                mainCamera.SetPos(vNewPosition);
            }
        }

        //ご主人様の頭取得
        private void ManHeadGet()
        {
            if (!manHead)
            {

                Transform[] objList = man.transform.GetComponentsInChildren<Transform>();
                if (objList.Count() != 0)
                {
                    manHead = null;
                    foreach (var gameobject in objList)
                    {
                        if (gameobject.name == "ManBip Head" && manHead == null)
                        {
                            manBipHead = gameobject;

                            foreach (Transform mh in manBipHead)
                            {
                                if (mh.name.IndexOf("_SM_mhead") > -1)
                                {
                                    GameObject smManHead = mh.gameObject;
                                    foreach (Transform smmh in smManHead.transform)
                                    {
                                        if (smmh.name.IndexOf("ManHead") > -1)
                                        {
                                            manHead = smmh.gameObject;
                                            manHeadRen = manHead.GetComponent<Renderer>();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //メイド切替時にカメラ追従
        private void CameraChange(int maidID)
        {
            if (!fpsModeEnabled)
            {
                Vector3 vNewPosition = Vector3.zero;

                //カメラの移動先決定
                vNewPosition = maidsState[maidID].maidMune.transform.position;

                //カメラ移動
                mainCamera.SetPos(vNewPosition);
                mainCamera.SetTargetPos(vNewPosition, true);
                mainCamera.SetDistance(1.4f, true);

            }
        }

        //カメラを常にメイドに追従させる
        private bool maidFollowEnabled = false;
        private Vector3 vNewPosition = Vector3.zero;

        private int lookPoint = 0;
        private string[] lookList = new string[] { "胸", "顔", "股" };
        private bool aoutLook = false;
        private float lookTime = 0f;
        private Vector3 lookVelocity;

        private bool aoutTarget = false;
        private float targetTime = 3f;

        private bool aoutAngle = false;
        private int xi = 1;

        private bool aoutZoom = false;
        private float zoomTg = 1f;
        private float zoomValue = 1f;
        private float zoomTime = 3f;
        private float zoomVelocity;

        private void MaidFollowingCamera(int maidID)
        {
            if (fpsModeEnabled || !maidFollowEnabled) return;

            var cameraTm = mainCamera.transform;

            //視点の設定
            if (aoutLook)
            { //オート変更
                if (lookTime <= 0f)
                {
                    lookPoint = UnityEngine.Random.Range(0, lookList.Length);
                    lookTime = UnityEngine.Random.Range(240f, 480f);
                }
                else
                {
                    lookTime -= timerRate;
                }
            }
            var maidTm = maidsState[maidID].maidMune.transform;
            if (lookPoint == 1) maidTm = maidsState[maidID].maidHead.transform;
            if (lookPoint == 2) maidTm = maidsState[maidID].maidXxx.transform;


            //ターゲットメイドのオート変更
            if (aoutTarget)
            {
                if (targetTime <= 0f)
                {
                    int ti = UnityEngine.Random.Range(0, vmId.Count);
                    tgID = vmId[ti];
                    targetTime = UnityEngine.Random.Range(600f, 1200f);
                }
                else
                {
                    targetTime -= timerRate;
                }
            }


            //カメラアングルのオート変更
            if (aoutAngle)
            {
                var angleY = 360 - maidTm.rotation.eulerAngles.y;
                var angleZ = 360 - maidTm.rotation.eulerAngles.z;
                var x = 0f;
                var y = 0f;
                var z = 0f;

                if (lookPoint >= 1) angleZ += 90f;
                x = Mathf.Cos(angleY * Mathf.Deg2Rad);
                y = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                z = Mathf.Sin(angleY * Mathf.Deg2Rad);


                if (lookPoint == 0) cameraTm.position = new Vector3(maidTm.position.x + x, maidTm.position.y + y, maidTm.position.z + z);
                if (lookPoint == 1) cameraTm.position = new Vector3(maidTm.position.x - x, maidTm.position.y - y, maidTm.position.z - z);
                if (lookPoint == 2)
                {
                    if (xi == 1)
                    {
                        if (130f < maidTm.rotation.eulerAngles.z && maidTm.rotation.eulerAngles.z < 200f) xi = -1;
                    }
                    else
                    {
                        if (50f > maidTm.rotation.eulerAngles.z || maidTm.rotation.eulerAngles.z > 280f) xi = 1;
                    }
                    cameraTm.position = new Vector3(maidTm.position.x + x * xi, maidTm.position.y + y, maidTm.position.z + z * xi);
                }
                var relativePos = maidTm.position - cameraTm.position;
                var rotation = Quaternion.LookRotation(relativePos);
                cameraTm.rotation = Quaternion.Slerp(cameraTm.rotation, rotation, Time.deltaTime);
            }


            //ズームのオート変更
            if (aoutZoom)
            {
                zoomValue = Mathf.SmoothDamp(mainCamera.GetDistance(), zoomTg, ref zoomVelocity, zoomTime);
                mainCamera.SetDistance(zoomValue, true);
                float d = Mathf.Abs(zoomTg - mainCamera.GetDistance());
                if (d < 0.01)
                {
                    zoomTg = UnityEngine.Random.Range(0.22f, 2f);
                    zoomTime = UnityEngine.Random.Range(0.7f, 2.8f) * timerRate;
                }
            }


            //カメラの移動先決定
            float fDistance = Vector3.Distance(maidTm.position, vNewPosition);
            vNewPosition = Vector3.SmoothDamp(mainCamera.GetTargetPos(), maidTm.position, ref lookVelocity, Time.deltaTime, fDistance * 7 * timerRate);

            //カメラ移動
            mainCamera.SetPos(vNewPosition);
            mainCamera.SetTargetPos(vNewPosition, true);

        }

        //メイドの移動処理
        private void MaidMove(int maidID, string mode, float move, bool all)
        {
            foreach (int ID in vmId)
            {
                if (ID == maidID || (maidID == tgID && LinkMaidCheck(maidID, ID) && all))
                {
                    Vector3 vm = stockMaids[ID].mem.transform.position;
                    Vector3 em = stockMaids[ID].mem.transform.eulerAngles;
                    if (mode == "px") stockMaids[ID].mem.transform.position = new Vector3(vm.x + move, vm.y, vm.z);
                    if (mode == "py") stockMaids[ID].mem.transform.position = new Vector3(vm.x, vm.y + move, vm.z);
                    if (mode == "pz") stockMaids[ID].mem.transform.position = new Vector3(vm.x, vm.y, vm.z + move);

                    if (mode == "ex") stockMaids[ID].mem.transform.eulerAngles = new Vector3(move, em.y, em.z);
                    if (mode == "ey") stockMaids[ID].mem.transform.eulerAngles = new Vector3(em.x, move, em.z);
                    if (mode == "ez") stockMaids[ID].mem.transform.eulerAngles = new Vector3(em.x, em.y, move);
                }
            }

            if (all)
            {
                for (int i = 0; i < SubMans.Length; i++)
                {
                    if (!SubMans[i].Visible || MansTg[i] != maidID) continue;
                    Vector3 vm = SubMans[i].transform.position;
                    Vector3 em = SubMans[i].transform.eulerAngles;
                    if (mode == "px") SubMans[i].transform.position = new Vector3(vm.x + move, vm.y, vm.z);
                    if (mode == "py") SubMans[i].transform.position = new Vector3(vm.x, vm.y + move, vm.z);
                    if (mode == "pz") SubMans[i].transform.position = new Vector3(vm.x, vm.y, vm.z + move);

                    if (mode == "ex") SubMans[i].transform.eulerAngles = new Vector3(move, em.y, em.z);
                    if (mode == "ey") SubMans[i].transform.eulerAngles = new Vector3(em.x, move, em.z);
                    if (mode == "ez") SubMans[i].transform.eulerAngles = new Vector3(em.x, em.y, move);
                }
            }
        }



        //その他処理終了----------------------------------





        //-------------------------------------------------
        //GUI関係------------------------------------------

        //リモコンスイッチGUI---------------
        void WindowCallback(int id)
        {

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsButton2 = new GUIStyle("button");
            gsButton2.fontSize = 10;
            gsButton2.alignment = TextAnchor.MiddleCenter;



            //現在ステータス表示
            int SucoreLevel2 = 0;
            if (Math.Floor(maidsState[tgID].orgasmValue) < 30)
            {
                SucoreLevel2 = 0;
            }
            else if (Math.Floor(maidsState[tgID].orgasmValue) < 50)
            {
                SucoreLevel2 = 1;
            }
            else if (Math.Floor(maidsState[tgID].orgasmValue) < 80)
            {
                SucoreLevel2 = 2;
            }
            else
            {
                SucoreLevel2 = 3;
            }

            int SucoreLevel3 = 0;
            if (Math.Floor(maidsState[tgID].resistValue) < 6)
            {
                SucoreLevel3 = 0;
            }
            else if (Math.Floor(maidsState[tgID].resistValue) < 13)
            {
                SucoreLevel3 = 1;
            }
            else if (Math.Floor(maidsState[tgID].resistValue) < 20)
            {
                SucoreLevel3 = 2;
            }
            else
            {
                SucoreLevel3 = 3;
            }

            if (GUI.Button(new Rect(200, 0, 20, 20), "x", gsButton))
            {
                cfgw.mainGuiFlag = 0;
                Console.WriteLine("GUI非表示");
            }

            if (cfgw.mainGuiFlag == 1)
            {
                if (GUI.Button(new Rect(180, 0, 20, 20), "－", gsButton))
                {
                    cfgw.mainGuiFlag = 2;
                    Console.WriteLine("GUI最小化");
                }


                if (GUI.Button(new Rect(5, 25, 30, 20), "<", gsButton))
                {
                    int i = vmId.IndexOf(tgID) - 1;
                    if (i < 0) i = vmId.Count - 1;

                    tgID = vmId[i];
                    CameraChange(tgID);
                }

                if (GUI.Button(new Rect(40, 25, 30, 20), ">", gsButton))
                {
                    int i = vmId.IndexOf(tgID) + 1;
                    if (i >= vmId.Count) i = 0;

                    tgID = vmId[i];
                    CameraChange(tgID);
                }

                string MaidName = stockMaids[tgID].lName + " " + stockMaids[tgID].fName;
                GUI.Label(new Rect(75, 25, 140, 20), MaidName, gsLabel);



                if (GUI.Button(new Rect(150, 50, 60, 20), "設定", gsButton))
                {
                    cfgw.configGuiFlag = !cfgw.configGuiFlag;
                    if (cfgw.configGuiFlag)
                    {
                        node3.y = node.y - 450;
                        node3.x = node.x - 620;
                    }
                }


                if (GUI.Button(new Rect(150, 75, 60, 20), "UNZIP!", gsButton))
                {
                    cfgw.unzipGuiFlag = !cfgw.unzipGuiFlag;
                    if (cfgw.unzipGuiFlag)
                    {
                        node4.y = node.y;
                        node4.x = node.x - 620;
                    }
                }


                if (!ExciteLock)
                {
                    GUI.Label(new Rect(5, 50, 190, 20), "【 快 感 】 " + SucoreText1[maidsState[tgID].exciteLevel - 1], gsLabel);
                }
                else
                {
                    GUI.Label(new Rect(5, 50, 190, 20), "【 Lock 】 " + SucoreText1[maidsState[tgID].exciteLevel - 1], gsLabel);
                }

                if (!OrgasmLock)
                {
                    GUI.Label(new Rect(5, 70, 190, 20), "【 絶 頂 】 " + SucoreText2[SucoreLevel2], gsLabel);
                }
                else
                {
                    GUI.Label(new Rect(5, 70, 190, 20), "【 Lock 】 " + SucoreText2[SucoreLevel2], gsLabel);
                }

                GUI.Label(new Rect(5, 90, 190, 20), "【 抵 抗 】 " + SucoreText3[SucoreLevel3], gsLabel);

                if (GUI.Button(new Rect(112, 52, 18, 16), "L", gsButton2))
                {
                    ExciteLock = !ExciteLock;
                }
                if (GUI.Button(new Rect(112, 72, 18, 16), "L", gsButton2))
                {
                    OrgasmLock = !OrgasmLock;
                }

                if (GUI.Button(new Rect(10, 115, 95, 20), "弱　[ " + cfgw.keyPluginToggleV3 + " ]", gsButton))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                        maidsState[maidID].vLevel = 1;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    Console.WriteLine("バイブ弱");
                }
                if (GUI.Button(new Rect(115, 115, 95, 20), "強　[ " + cfgw.keyPluginToggleV4 + " ]", gsButton))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                        maidsState[maidID].vLevel = 2;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    Console.WriteLine("バイブ強");
                }

                if (GUI.Button(new Rect(10, 140, 200, 20), "停　止　[ " + cfgw.keyPluginToggleV2 + " ]", gsButton))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID == tgID || LinkMaidCheck(tgID, maidID))
                            maidsState[maidID].vLevel = 0;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    Console.WriteLine("バイブ停止");
                }

                if (GUI.Button(new Rect(125, 165, 85, 20), autoSelectList[maidsState[tgID].pAutoSelect], gsButton))
                {
                    if (maidsState[tgID].pAutoSelect == 0) maidsState[tgID].pAutoTime = 0f;
                    ++maidsState[tgID].pAutoSelect;
                    if (maidsState[tgID].pAutoSelect > 3) maidsState[tgID].pAutoSelect = 0;
                }


                if (stockMaids[tgID].mem.body0.LastAnimeFN.Contains("_shaseigo_"))
                {
                    if (GUI.Button(new Rect(125, 190, 40, 20), "挿入", gsButton))
                    {
                        string baseMotion = maj.motionName[maidsState[tgID].motionID];

                        if (maidsState[tgID].inMotion == "Non")
                        {
                            MotionChange(stockMaids[tgID].mem, baseMotion + ".anm", true, 0.7f, 1f);
                        }
                        else
                        {
                            MotionChange(stockMaids[tgID].mem, maidsState[tgID].inMotion + ".anm", false, 0.7f, 1f);
                            MotionChangeAf(stockMaids[tgID].mem, baseMotion + ".anm", true, 0.7f, 1f); // 終わったら再生する
                        }

                        if (!maidsState[tgID].analMode)
                        {
                            maidsState[tgID].uDatsuValue1 = 0f;
                            maidsState[tgID].uDatsu = 0;
                            try { VertexMorph_FromProcItem(stockMaids[tgID].mem.body0, "pussy_uterus_prolapse", 0f); } catch { /*LogError(ex);*/ }
                        }

                        //男のモーション変更
                        if (maidsState[tgID].inMotion == "Non")
                        {
                            ManMotionChange(tgID, true, 0.7f, 1.0f);
                        }
                        else
                        {
                            ManMotionChange(maidsState[tgID].inMotion + ".anm", tgID, false, 0.7f, 1f);
                            ManMotionChangeAf(baseMotion + ".anm", tgID, true, 0.7f, 1f); // 終わったら再生する

                        }
                    }

                }
                else if (maidsState[tgID].outMotion != "Non" && SyaseiCheck(tgID, 85f))
                {
                    if (GUI.Button(new Rect(125, 190, 40, 20), "抜く", gsButton))
                    {

                        MotionChange(stockMaids[tgID].mem, maidsState[tgID].outMotion + ".anm", false, 0.7f, 1f);
                        MotionChangeAf(stockMaids[tgID].mem, maidsState[tgID].outMotion.Replace("_shasei_soto_f_once_", "_shaseigo_soto_f").Replace("_shasei_kao_f_once_", "_shaseigo_kao_f") + ".anm", true, 0.5f, 1f); // 終わったら再生する

                        ManMotionChange(maidsState[tgID].outMotion + ".anm", tgID, false, 0.7f, 1f);
                        ManMotionChangeAf(maidsState[tgID].outMotion.Replace("_shasei_soto_f_once_", "_shaseigo_soto_f").Replace("_shasei_kao_f_once_", "_shaseigo_kao_f") + ".anm", tgID, true, 0.5f, 1f); // 終わったら再生する

                        ReactionPlay(tgID);

                        if (!maidsState[tgID].analMode)
                        {
                            maidsState[tgID].vLevel = 0;
                            maidsState[tgID].pAutoSelect = 0;
                            maidsState[tgID].uDatsu = 1;
                        }
                    }
                }
                else if (maidsState[tgID].motionID != -1 && maj.analEnabled[maidsState[tgID].motionID] && !maidsState[tgID].stunFlag)
                {
                    string bName = "後ろを使う";
                    if (maidsState[tgID].analMode) bName = "前を使う";
                    if (GUI.Button(new Rect(125, 190, 85, 20), bName, gsButton))
                    {
                        maidsState[tgID].analMode = !maidsState[tgID].analMode;

                        string baseMotion = maj.motionName[maidsState[tgID].motionID];
                        MotionAdjustDo(tgID, baseMotion, true, -1);

                        if (maidsState[tgID].inMotion == "Non")
                        {
                            MotionChange(stockMaids[tgID].mem, baseMotion + ".anm", true, 0.7f, 1f);
                        }
                        else
                        {
                            MotionChange(stockMaids[tgID].mem, maidsState[tgID].inMotion + ".anm", false, 0.7f, 1f);
                            MotionChangeAf(stockMaids[tgID].mem, baseMotion + ".anm", true, 0.7f, 1f); // 終わったら再生する
                        }

                        //男のモーション変更
                        if (maidsState[tgID].inMotion == "Non")
                        {
                            ManMotionChange(tgID, true, 0.7f, 1.0f);
                        }
                        else
                        {
                            ManMotionChange(maidsState[tgID].inMotion + ".anm", tgID, false, 0.7f, 1f);
                            ManMotionChangeAf(baseMotion + ".anm", tgID, true, 0.7f, 1f); // 終わったら再生する
                        }

                        if (maidsState[tgID].analMode)
                        {
                            maidsState[tgID].pAutoSelect = 0;
                            maidsState[tgID].uDatsu = 1;
                        }
                        else
                        {
                            maidsState[tgID].uDatsuValue1 = 0f;
                            maidsState[tgID].uDatsu = 0;
                            try { VertexMorph_FromProcItem(stockMaids[tgID].mem.body0, "pussy_uterus_prolapse", 0f); } catch { /*LogError(ex);*/ }
                        }

                    }
                }


                if (maidsState[tgID].stunFlag)
                {
                    if (GUI.Button(new Rect(170, 190, 40, 20), "叩く", gsButton))
                    {
                        maidsState[tgID].stunFlag = false;
                        maidsState[tgID].maidStamina = 3000;
                        GameMain.Instance.SoundMgr.PlaySe("se013.ogg", false);
                        ReactionPlay(tgID);

                        stockMaids[tgID].mem.ResetProp("eye_hi", false);//ハイライトを戻す
                        stockMaids[tgID].mem.ResetProp("eye_hi_r", false);
                        stockMaids[tgID].mem.AllProcPropSeqStart();
                    }
                }


                GUI.Label(new Rect(5, 165, 210, 20), " ﾌﾟﾗｸﾞｲﾝ無効： [ " + cfgw.keyPluginToggleV0 + " ]", gsLabel);
                GUI.Label(new Rect(5, 185, 210, 20), " GUI表示切替： [ " + cfgw.keyPluginToggleV1 + " ]", gsLabel);



            }
            else if (cfgw.mainGuiFlag == 2)
            {
                if (GUI.Button(new Rect(180, 0, 20, 20), "+", gsButton))
                {
                    cfgw.mainGuiFlag = 1;
                    Console.WriteLine("GUI表示");
                }
            }


            GUI.DragWindow();
        }


        //サブキャラ操作GUI---------------
        Vector2 subGUIScrollPos = Vector2.zero;

        void WindowCallback2a(int id)
        {

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsLabel3 = new GUIStyle("label");
            gsLabel3.fontSize = 12;
            gsLabel3.alignment = TextAnchor.MiddleLeft;
            gsLabel3.fontStyle = FontStyle.Bold;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsButton2 = new GUIStyle("button");
            gsButton2.fontSize = 10;
            gsButton2.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsToggle = new GUIStyle("toggle");
            gsToggle.fontSize = 12;
            gsToggle.alignment = TextAnchor.MiddleLeft;

            Vector3 vm;
            int y = 0;
            int h = 0;


            for (int i = 0; i < SubMans.Length; i++)
            {
                if (tgID != -1)
                {
                    if (!vmId.Contains(MansTg[i])) MansTg[i] = tgID;
                }
                else
                {
                    MansTg[i] = -1;
                }
            }


            if (cfgw.subGuiFlag != 0)
            {
                if (GUI.Button(new Rect(200, 0, 20, 20), "－", gsButton))
                {
                    cfgw.subGuiFlag = 0;
                    node2.height = 20;
                    node2.y += 430;
                }

                if (GUI.Button(new Rect(105, 5, 85, 20), "メイド呼出", gsButton))
                {
                    cfgw.subGuiFlag = 2;
                }

                y += 30;

                //ご主人様操作用
                GUI.Label(new Rect(5, y, 95, 20), "【 " + SubMansName[0] + " 】", gsLabel3);
                vm = SubMans[0].transform.position;

                if (GUI.Button(new Rect(5, y + 25, 85, 20), "表示切替", gsButton))
                {
                    if (!SubMans[0]) SubMans[0] = GameMain.Instance.CharacterMgr.GetMan(0);
                    if (SubMans[0]) StartCoroutine("MansVisible", 0);
                }

                if (SubMans[0].Visible)
                {
                    if (GUI.Button(new Rect(5, y + 50, 85, 20), "位置合せ", gsButton))
                    {
                        SubMans[0].transform.position = stockMaids[MansTg[0]].mem.transform.position;
                        SubMans[0].transform.eulerAngles = stockMaids[MansTg[0]].mem.transform.eulerAngles;
                    }

                    if (GUI.Button(new Rect(105, y + 25, 25, 20), "X↑", gsButton))
                    {
                        SubMans[0].transform.position = new Vector3(vm.x + 0.01f, vm.y, vm.z);
                    }
                    if (GUI.Button(new Rect(135, y + 25, 25, 20), "Y↑", gsButton))
                    {
                        SubMans[0].transform.position = new Vector3(vm.x, vm.y + 0.01f, vm.z);
                    }
                    if (GUI.Button(new Rect(165, y + 25, 25, 20), "Z↑", gsButton))
                    {
                        SubMans[0].transform.position = new Vector3(vm.x, vm.y, vm.z + 0.01f);
                    }
                    if (GUI.Button(new Rect(105, y + 50, 25, 20), "X↓", gsButton))
                    {
                        SubMans[0].transform.position = new Vector3(vm.x - 0.01f, vm.y, vm.z);
                    }
                    if (GUI.Button(new Rect(135, y + 50, 25, 20), "Y↓", gsButton))
                    {
                        SubMans[0].transform.position = new Vector3(vm.x, vm.y - 0.01f, vm.z);
                    }
                    if (GUI.Button(new Rect(165, y + 50, 25, 20), "Z↓", gsButton))
                    {
                        SubMans[0].transform.position = new Vector3(vm.x, vm.y, vm.z - 0.01f);
                    }

                    GUI.Label(new Rect(5, y + 75, 90, 20), "射精値：" + Math.Floor(syaseiValue[0]), gsLabel);
                    if (GUI.Button(new Rect(75, y + 75, 18, 20), "L", gsButton2))
                    {
                        syaseiLock[0] = !syaseiLock[0];
                    }
                    syaseiValue[0] = GUI.HorizontalSlider(new Rect(100, y + 80, 95, 20), syaseiValue[0], 0f, 95f);

                    cfgw.autoManEnabled = GUI.Toggle(new Rect(5, y + 95, 190, 20), cfgw.autoManEnabled, "UNZIP時に男を自動表示", gsToggle);
                    cfgw.autoMoveEnabled = GUI.Toggle(new Rect(5, y + 115, 190, 20), cfgw.autoMoveEnabled, "対象をメインメイドに固定する", gsToggle);

                    if (GUI.Button(new Rect(5, y + 140, 60, 20), "対象", gsButton))
                    {
                        if (cfgw.autoMoveEnabled) cfgw.autoMoveEnabled = false;
                        int mi = vmId.IndexOf(MansTg[0]) + 1;
                        if (mi >= vmId.Count) mi = 0;
                        MansTg[0] = vmId[mi];

                        SubMans[0].transform.position = stockMaids[MansTg[0]].mem.transform.position;
                        SubMans[0].transform.eulerAngles = stockMaids[MansTg[0]].mem.transform.eulerAngles;

                        //男のモーション変更
                        ManMotionChange(MansTg[0], true, 0.5f, 1.0f);
                        maidsState[MansTg[0]].motionHoldTime = 0f; //モーションタイマーリセット
                    }

                    string TargetName = "対象無し";
                    if (MansTg[0] != -1) TargetName = stockMaids[MansTg[0]].lName + " " + stockMaids[MansTg[0]].fName;
                    GUI.Label(new Rect(70, y + 140, 125, 20), TargetName, gsLabel);

                    y += 100;
                }
                else
                {
                    cfgw.autoManEnabled = GUI.Toggle(new Rect(5, y + 50, 190, 20), cfgw.autoManEnabled, "UNZIP時に男を自動表示", gsToggle);
                    y += 25;
                }
                y += 60;

                GUI.Label(new Rect(0, y, 195, 20), "―――――――――――", gsLabel2);
                y += 25;

                h += (vmId.Count - 1) * 135;
                for (int i = 1; i < SubMans.Length; i++)
                {
                    if (SubMans[i].Visible) h += 75;
                    h += 60;
                }
                if (h < 450 - y) h = 450 - y;

                Rect scrlRect = new Rect(5, y, 214, 445 - y);
                Rect contentRect = new Rect(0, 0, 195, h);
                subGUIScrollPos = GUI.BeginScrollView(scrlRect, subGUIScrollPos, contentRect, false, true);
                y = 0;

                foreach (int maidID in vmId)
                {
                    if (maidID == tgID) continue;

                    GUI.Label(new Rect(5, y, 190, 20), "【 " + stockMaids[maidID].lName + " " + stockMaids[maidID].fName + " 】", gsLabel3);
                    vm = stockMaids[maidID].mem.transform.position;

                    if (GUI.Button(new Rect(5, y + 25, 25, 20), "弱", gsButton))
                    {
                        maidsState[maidID].vLevel = 1;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    if (GUI.Button(new Rect(35, y + 25, 25, 20), "強", gsButton))
                    {
                        maidsState[maidID].vLevel = 2;
                        maidsState[maidID].pAutoSelect = 0;
                    }
                    if (GUI.Button(new Rect(65, y + 25, 25, 20), "止", gsButton))
                    {
                        maidsState[maidID].vLevel = 0;
                        maidsState[maidID].pAutoSelect = 0;
                    }

                    if (maidsState[maidID].linkEnabled)
                    {
                        maidsState[maidID].pAutoSelect = 0;
                        maidsState[maidID].pAutoTime = 0f;
                        GUI.Label(new Rect(5, y + 50, 85, 20), "リンク中", gsLabel);
                    }
                    else
                    {
                        if (GUI.Button(new Rect(5, y + 50, 85, 20), autoSelectList[maidsState[maidID].pAutoSelect], gsButton))
                        {
                            if (maidsState[maidID].pAutoSelect == 0) maidsState[maidID].pAutoTime = 0f;
                            ++maidsState[maidID].pAutoSelect;
                            if (maidsState[maidID].pAutoSelect > 3) maidsState[maidID].pAutoSelect = 0;
                        }
                    }

                    if (GUI.Button(new Rect(105, y + 25, 25, 20), "X↑", gsButton))
                    {
                        stockMaids[maidID].mem.transform.position = new Vector3(vm.x + 0.01f, vm.y, vm.z);
                    }
                    if (GUI.Button(new Rect(135, y + 25, 25, 20), "Y↑", gsButton))
                    {
                        stockMaids[maidID].mem.transform.position = new Vector3(vm.x, vm.y + 0.01f, vm.z);
                    }
                    if (GUI.Button(new Rect(165, y + 25, 25, 20), "Z↑", gsButton))
                    {
                        stockMaids[maidID].mem.transform.position = new Vector3(vm.x, vm.y, vm.z + 0.01f);
                    }

                    if (GUI.Button(new Rect(105, y + 50, 25, 20), "X↓", gsButton))
                    {
                        stockMaids[maidID].mem.transform.position = new Vector3(vm.x - 0.01f, vm.y, vm.z);
                    }
                    if (GUI.Button(new Rect(135, y + 50, 25, 20), "Y↓", gsButton))
                    {
                        stockMaids[maidID].mem.transform.position = new Vector3(vm.x, vm.y - 0.01f, vm.z);
                    }
                    if (GUI.Button(new Rect(165, y + 50, 25, 20), "Z↓", gsButton))
                    {
                        stockMaids[maidID].mem.transform.position = new Vector3(vm.x, vm.y, vm.z - 0.01f);
                    }

                    //maidsState[maidID].linkEnabled = GUI.Toggle(new Rect(5, y + 75, 190, 20), maidsState[maidID].linkEnabled, "メインメイドとリンクさせる", gsToggle);
                    if (GUI.Button(new Rect(5, y + 75, 60, 20), "リンク", gsButton))
                    {
                        int mi = vmId.IndexOf(maidsState[maidID].linkID) + 1;
                        if (mi >= vmId.Count) mi = 0;
                        if (maidID == vmId[mi])
                        {
                            ++mi;
                            if (mi >= vmId.Count) mi = 0;
                        }
                        maidsState[maidID].linkID = vmId[mi];

                        stockMaids[maidID].mem.transform.position = stockMaids[maidsState[maidID].linkID].mem.transform.position;
                        stockMaids[maidID].mem.transform.eulerAngles = stockMaids[maidsState[maidID].linkID].mem.transform.eulerAngles;
                    }
                    string TargetName = "対象無し";
                    if (maidsState[maidID].linkID != -1)
                    {
                        TargetName = stockMaids[maidsState[maidID].linkID].lName + " " + stockMaids[maidsState[maidID].linkID].fName;
                        if (GUI.Button(new Rect(170, y + 75, 25, 20), "解", gsButton)) { maidsState[maidID].linkID = -1; }
                    }
                    GUI.Label(new Rect(70, y + 75, 125, 20), TargetName, gsLabel);



                    stockMaids[maidID].mem.body0.boEyeToCam = GUI.Toggle(new Rect(5, y + 100, 50, 20), stockMaids[maidID].mem.body0.boEyeToCam, "目線", gsToggle);
                    stockMaids[maidID].mem.body0.boHeadToCam = GUI.Toggle(new Rect(65, y + 100, 45, 20), stockMaids[maidID].mem.body0.boHeadToCam, "顔", gsToggle);
                    maidsState[maidID].eAutoSelect = GUI.Toggle(new Rect(110, y + 100, 90, 20), maidsState[maidID].eAutoSelect, "自動変更", gsToggle);

                    y += 135;
                }


                for (int i = 1; i < SubMans.Length; i++)
                {

                    GUI.Label(new Rect(5, y, 95, 20), "【 " + SubMansName[i] + " 】", gsLabel3);
                    vm = SubMans[i].transform.position;

                    if (GUI.Button(new Rect(5, y + 25, 85, 20), "表示切替", gsButton))
                    {
                        if (!SubMans[i]) SubMans[i] = GameMain.Instance.CharacterMgr.GetMan(i);
                        if (SubMans[i]) StartCoroutine("MansVisible", i);
                    }

                    if (SubMans[i].Visible)
                    {
                        if (GUI.Button(new Rect(5, y + 50, 85, 20), "位置合せ", gsButton))
                        {
                            SubMans[i].transform.position = stockMaids[MansTg[i]].mem.transform.position;
                            SubMans[i].transform.eulerAngles = stockMaids[MansTg[i]].mem.transform.eulerAngles;
                        }

                        if (GUI.Button(new Rect(105, y + 25, 25, 20), "X↑", gsButton))
                        {
                            SubMans[i].transform.position = new Vector3(vm.x + 0.01f, vm.y, vm.z);
                        }
                        if (GUI.Button(new Rect(135, y + 25, 25, 20), "Y↑", gsButton))
                        {
                            SubMans[i].transform.position = new Vector3(vm.x, vm.y + 0.01f, vm.z);
                        }
                        if (GUI.Button(new Rect(165, y + 25, 25, 20), "Z↑", gsButton))
                        {
                            SubMans[i].transform.position = new Vector3(vm.x, vm.y, vm.z + 0.01f);
                        }

                        if (GUI.Button(new Rect(105, y + 50, 25, 20), "X↓", gsButton))
                        {
                            SubMans[i].transform.position = new Vector3(vm.x - 0.01f, vm.y, vm.z);
                        }
                        if (GUI.Button(new Rect(135, y + 50, 25, 20), "Y↓", gsButton))
                        {
                            SubMans[i].transform.position = new Vector3(vm.x, vm.y - 0.01f, vm.z);
                        }
                        if (GUI.Button(new Rect(165, y + 50, 25, 20), "Z↓", gsButton))
                        {
                            SubMans[i].transform.position = new Vector3(vm.x, vm.y, vm.z - 0.01f);
                        }

                        GUI.Label(new Rect(5, y + 75, 90, 20), "射精値：" + Math.Floor(syaseiValue[i]), gsLabel);
                        if (GUI.Button(new Rect(75, y + 75, 18, 20), "L", gsButton2))
                        {
                            syaseiLock[i] = !syaseiLock[i];
                        }
                        syaseiValue[i] = GUI.HorizontalSlider(new Rect(100, y + 80, 95, 20), syaseiValue[i], 0f, 95f);


                        if (GUI.Button(new Rect(5, y + 100, 60, 20), "対象", gsButton))
                        {
                            int mi = vmId.IndexOf(MansTg[i]) + 1;
                            if (mi >= vmId.Count) mi = 0;
                            MansTg[i] = vmId[mi];

                            SubMans[i].transform.position = stockMaids[MansTg[i]].mem.transform.position;
                            SubMans[i].transform.eulerAngles = stockMaids[MansTg[i]].mem.transform.eulerAngles;

                            //男のモーション変更
                            ManMotionChange(MansTg[i], true, 0.5f, 1.0f);
                            maidsState[MansTg[i]].motionHoldTime = 0f; //モーションタイマーリセット
                        }

                        string TargetName = "対象無し";
                        if (MansTg[i] != -1) TargetName = stockMaids[MansTg[i]].lName + " " + stockMaids[MansTg[i]].fName;
                        GUI.Label(new Rect(70, y + 100, 125, 20), TargetName, gsLabel);

                        y += 75;
                    }
                    y += 60;
                }


                GUI.EndScrollView();
                GUI.DragWindow();

            }
            else
            {
                node2.x = node.x;
                node2.y = node.y - 20;
                if (GUI.Button(new Rect(200, 0, 20, 20), "＋", gsButton))
                {
                    cfgw.subGuiFlag = 1;
                    node2.height = 450;
                    node2.y -= 430;
                    if (node5.y > node2.y - 170)
                    {
                        node5.y = node2.y - 170;
                        if (node5.y < 0) node5.y = 0;
                    }
                }
            }
        }

        void WindowCallback2b(int id)
        {

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsToggle = new GUIStyle("toggle");
            gsToggle.fontSize = 12;
            gsToggle.alignment = TextAnchor.MiddleLeft;

            if (cfgw.subGuiFlag != 0)
            {
                if (GUI.Button(new Rect(200, 0, 20, 20), "－", gsButton))
                {
                    cfgw.subGuiFlag = 0;
                    node2.height = 20;
                    node2.y += 430;
                }

                if (GUI.Button(new Rect(105, 5, 85, 20), "ｻﾌﾞｷｬﾗ操作", gsButton))
                {
                    cfgw.subGuiFlag = 1;
                }

                Maid maid = null;
                if (tgID != -1) maid = stockMaids[tgID].mem;

                int y = 35;
                int h = 65 * stockMaids.Count + 20;
                Rect scrlRect = new Rect(5, y, 214, 445 - y);
                Rect contentRect = new Rect(0, 0, 195, h);
                subGUIScrollPos = GUI.BeginScrollView(scrlRect, subGUIScrollPos, contentRect, false, true);
                y = 0;

                foreach (var sm in stockMaids)
                {
                    Maid getmaid = sm.mem;
                    if (getmaid.Visible)
                    {
                        string MaidName = getmaid.status.lastName + " " + getmaid.status.firstName;

                        GUI.Label(new Rect(5, y, 125, 20), MaidName, gsLabel);
                        if (GUI.Button(new Rect(130, y, 65, 20), "非表示", gsButton))
                        {
                            getmaid.Visible = false;
                        }
                        y += 22;
                    }
                }

                GUI.Label(new Rect(0, y, 195, 20), "―――――――――――", gsLabel2);
                y += 20;

                foreach (var sm in stockMaids)
                {
                    Maid getmaid = sm.mem;
                    if (!getmaid.Visible)
                    {

                        GUI.DrawTexture(new Rect(0, y, 50, 60), getmaid.GetThumIcon());

                        string MaidName = getmaid.status.lastName + " " + getmaid.status.firstName;
                        if (GUI.Button(new Rect(50, y, 145, 60), MaidName, gsButton))
                        {
                            LoadMaid(getmaid);
                            GameMain.Instance.MainCamera.FadeOut(0f, false, null, true, default(Color)); //NormalizeVoice.Pluginにメイドチェック処理をさせるため一旦フェードアウトさせる
                            GameMain.Instance.MainCamera.FadeIn(1f, false, null, true, true, default(Color));

                        }
                        y += 65;
                    }
                }

                GUI.EndScrollView();
                GUI.DragWindow();

            }
            else
            {
                node2.x = node.x;
                node2.y = node.y - 20;
                if (GUI.Button(new Rect(200, 0, 20, 20), "＋", gsButton))
                {
                    cfgw.subGuiFlag = 1;
                    node2.height = 450;
                    node2.y -= 430;
                }
            }
        }



        //設定画面GUI---------------
        private int ConfigFlag = 0;
        private int cv = 0;
        private Vector2 EditScroll = Vector2.zero;
        private float moveValue = 0.1f;
        private Vector2 vsScrollPos1 = Vector2.zero;
        private Vector2 vsScrollPos2 = Vector2.zero;
        private Vector2 dsScrollPos = Vector2.zero;
        private string cbsName = "";
        private bool[] hs_Overwrite = new bool[] { false, false, false, false };
        private bool[] ds_Overwrite = new bool[] { false, false, false, false, false };
        private string[] dsErrerText = new string[] { "", "衣装セット名が空白のため保存できません", "上書きする場合は『上書』にチェックを入れて下さい" };
        private int dsErrer = 0;
        private bool setWear = true;
        private bool setSkirt = true;
        private bool setOnepiece = true;
        private bool setMizugi = true;
        private bool setBra = true;
        private bool setPanz = true;
        private bool setStkg = true;
        private bool setShoes = true;
        private bool setAcchat = true;
        private bool setHeadset = true;
        private bool setGlove = true;
        private bool setAcchead = true;
        private bool setAcchana = true;
        private bool setAccmimi = true;
        private bool setAccnip = true;
        private bool setAcckubi = true;
        private bool setAcckubiwa = true;
        private bool setAccheso = true;
        private bool setAccude = true;
        private bool setAccashi = true;
        private bool setAccsenaka = true;
        private bool setAccshippo = true;
        private bool setMegane = true;
        private bool setAccxxx = true;
        private string[] bvsText1 = new string[] { "弱　通常音声", "弱　フェラ音声", "強　通常音声", "強　フェラ音声", "絶頂　通常音声", "絶頂　フェラ音声", "停止時音声" };
        private string[] bvsText2 = new string[] { "【快感０の音声】", "【快感１の音声】", "【快感２の音声】", "【快感３の音声】", "【放心時の音声】" };
        private string[] bvsText3 = new string[] { "【快感１絶頂の音声】", "【快感２絶頂の音声】", "【快感３絶頂の音声】", "【連続絶頂の音声】", "【放心時の音声】" };
        private string[] cliModeText = new string[] { "通常", "巨クリ", "ふたなり" };
        private string[] mukiText1 = new string[] { "男に合わせる", "メイドに合わせる", "回転させない" };
        private string[] mukiText2 = new string[] { "表", "裏" };
        private string[] chikubiText = new string[] { "着衣時", "肌時" };
        void WindowCallback3(int id)
        {

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsLabel3 = new GUIStyle("label");
            gsLabel3.fontSize = 12;
            gsLabel3.alignment = TextAnchor.MiddleCenter;
            styleState = new GUIStyleState();
            styleState.textColor = Color.yellow;
            gsLabel3.normal = styleState;

            GUIStyle gsLabel4 = new GUIStyle("label");
            gsLabel4.fontSize = 12;
            gsLabel4.alignment = TextAnchor.UpperLeft;
            styleState = new GUIStyleState();
            styleState.textColor = Color.red;
            gsLabel4.normal = styleState;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsToggle = new GUIStyle("toggle");
            gsToggle.fontSize = 12;
            gsToggle.alignment = TextAnchor.MiddleLeft;

            Vector3 vm;
            Vector3 vml;
            Vector3 em;
            Vector3 vm2;
            Vector3 em2;
            int x = 0;
            int y = 0;
            float emValue;
            Maid maid = stockMaids[tgID].mem;


            if (GUI.Button(new Rect(600, 0, 20, 20), "x", gsButton))
            {
                cfgw.configGuiFlag = false;
            }
            if (ConfigFlag == 0 || ConfigFlag == 1)
            {
                if (GUI.Button(new Rect(445, 10, 60, 20), "再読込", gsButton))
                {
                    //cfg = ReadConfig<VibeYourMaidConfig>("Config");
                    //cfgw = ReadConfig<VibeYourMaidCfgWriting>("CfgWriting");
                    ConfigFileLoad();
                }

                if (GUI.Button(new Rect(510, 10, 80, 20), "設定保存", gsButton))
                {
                    //SaveConfig(cfgw, "CfgWriting");
                    ConfigFileSave();
                }
            }


            if (GUI.Button(new Rect(160, 10, 125, 20), "メインメイド操作", gsButton))
            {
                ConfigFlag = 0;
            }
            if (GUI.Button(new Rect(300, 10, 80, 20), "各種設定", gsButton))
            {
                ConfigFlag = 1;
            }


            if (ConfigFlag == 0)
            {


                GUI.Label(new Rect(5, 35, 200, 20), "【脱衣】", gsLabel);

                isWear = maid.body0.GetMask(TBody.SlotID.wear);
                isOnepiece = maid.body0.GetMask(TBody.SlotID.onepiece);
                isMizugi = maid.body0.GetMask(TBody.SlotID.mizugi);
                isBra = maid.body0.GetMask(TBody.SlotID.bra);
                isSkirt = maid.body0.GetMask(TBody.SlotID.skirt);
                isPanz = maid.body0.GetMask(TBody.SlotID.panz);
                isHeadset = maid.body0.GetMask(TBody.SlotID.headset);
                isGlove = maid.body0.GetMask(TBody.SlotID.glove);
                isAccSenaka = maid.body0.GetMask(TBody.SlotID.accSenaka);
                isStkg = maid.body0.GetMask(TBody.SlotID.stkg);
                isShoes = maid.body0.GetMask(TBody.SlotID.shoes);
                isMegane = maid.body0.GetMask(TBody.SlotID.megane);
                isAccXxx = maid.body0.GetMask(TBody.SlotID.accXXX);

                isKubi = maid.body0.GetMask(TBody.SlotID.accKubi);
                isMimi = maid.body0.GetMask(TBody.SlotID.accMiMiR);
                isAshi = maid.body0.GetMask(TBody.SlotID.accAshi);
                isShippo = maid.body0.GetMask(TBody.SlotID.accShippo);
                isUhair = maid.body0.GetMask(TBody.SlotID.underhair);


                if (GUI.Button(new Rect(10, 60, 85, 20), "全着衣", gsButton))
                {
                    maid.body0.SetMask(TBody.SlotID.wear, true);
                    maid.body0.SetMask(TBody.SlotID.mizugi, true);
                    maid.body0.SetMask(TBody.SlotID.onepiece, true);
                    maid.body0.SetMask(TBody.SlotID.bra, true);
                    maid.body0.SetMask(TBody.SlotID.skirt, true);
                    maid.body0.SetMask(TBody.SlotID.panz, true);
                    maid.body0.SetMask(TBody.SlotID.glove, true);
                    maid.body0.SetMask(TBody.SlotID.accUde, true);
                    maid.body0.SetMask(TBody.SlotID.stkg, true);
                    maid.body0.SetMask(TBody.SlotID.shoes, true);
                    maid.body0.SetMask(TBody.SlotID.accKubi, true);
                    maid.body0.SetMask(TBody.SlotID.accKubiwa, true);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(10, 85, 85, 20), "全裸", gsButton))
                {
                    maid.body0.SetMask(TBody.SlotID.wear, false);
                    maid.body0.SetMask(TBody.SlotID.mizugi, false);
                    maid.body0.SetMask(TBody.SlotID.onepiece, false);
                    maid.body0.SetMask(TBody.SlotID.bra, false);
                    maid.body0.SetMask(TBody.SlotID.skirt, false);
                    maid.body0.SetMask(TBody.SlotID.panz, false);
                    maid.body0.SetMask(TBody.SlotID.glove, false);
                    maid.body0.SetMask(TBody.SlotID.accUde, false);
                    maid.body0.SetMask(TBody.SlotID.stkg, false);
                    maid.body0.SetMask(TBody.SlotID.shoes, false);
                    maid.body0.SetMask(TBody.SlotID.accKubi, false);
                    maid.body0.SetMask(TBody.SlotID.accKubiwa, false);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(105, 60, 85, 20), "トップス", gsButton))
                {
                    isWear = !isWear;
                    maid.body0.SetMask(TBody.SlotID.wear, isWear);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(105, 85, 85, 20), "ワンピース", gsButton))
                {
                    dCheck = true;
                    isOnepiece = !isOnepiece;
                    maid.body0.SetMask(TBody.SlotID.onepiece, isOnepiece);
                }

                if (GUI.Button(new Rect(105, 110, 85, 20), "水着", gsButton))
                {
                    dCheck = true;
                    isMizugi = !isMizugi;
                    maid.body0.SetMask(TBody.SlotID.mizugi, isMizugi);
                }

                if (GUI.Button(new Rect(200, 60, 80, 20), "ブラジャー", gsButton))
                {
                    isBra = !isBra;
                    maid.body0.SetMask(TBody.SlotID.bra, isBra);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(200, 85, 85, 20), "スカート脱", gsButton))
                {
                    isSkirt = !isSkirt;
                    maid.body0.SetMask(TBody.SlotID.skirt, isSkirt);
                    dCheck = true;
                }
                if (GUI.Button(new Rect(200, 110, 38, 20), "前", gsButton))
                {
                    MekureChanged(tgID, "前", true);
                }

                if (GUI.Button(new Rect(242, 110, 38, 20), "後", gsButton))
                {
                    MekureChanged(tgID, "後", true);
                }

                if (GUI.Button(new Rect(290, 60, 60, 20), "ショーツ", gsButton))
                {
                    isPanz = !isPanz;
                    maid.body0.SetMask(TBody.SlotID.panz, isPanz);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(360, 60, 40, 20), "頭", gsButton))
                {
                    isHeadset = !isHeadset;
                    maid.body0.SetMask(TBody.SlotID.headset, isHeadset);
                    maid.body0.SetMask(TBody.SlotID.accHat, isHeadset);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(410, 60, 40, 20), "手", gsButton))
                {
                    isGlove = !isGlove;
                    maid.body0.SetMask(TBody.SlotID.glove, isGlove);
                    maid.body0.SetMask(TBody.SlotID.accUde, isGlove);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(460, 60, 60, 20), "背中", gsButton))
                {
                    isAccSenaka = !isAccSenaka;
                    maid.body0.SetMask(TBody.SlotID.accSenaka, isAccSenaka);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(530, 60, 60, 20), "あそこ", gsButton))
                {
                    isAccXxx = !isAccXxx;
                    maid.body0.SetMask(TBody.SlotID.accXXX, isAccXxx);
                    dCheck = true;
                }


                if (GUI.Button(new Rect(290, 85, 60, 20), "ずらし", gsButton))
                {
                    MekureChanged(tgID, "ずらし", true);
                }

                if (GUI.Button(new Rect(360, 85, 40, 20), "靴下", gsButton))
                {
                    isStkg = !isStkg;
                    maid.body0.SetMask(TBody.SlotID.stkg, isStkg);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(410, 85, 40, 20), "靴", gsButton))
                {
                    isShoes = !isShoes;
                    maid.body0.SetMask(TBody.SlotID.shoes, isShoes);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(460, 85, 60, 20), "メガネ", gsButton))
                {
                    isMegane = !isMegane;
                    maid.body0.SetMask(TBody.SlotID.megane, isMegane);
                    maid.body0.SetMask(TBody.SlotID.accHead, isMegane);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(530, 85, 60, 20), "Uヘアー", gsButton))
                {
                    isUhair = !isUhair;
                    maid.body0.SetMask(TBody.SlotID.underhair, isUhair);
                    dCheck = true;
                }



                if (GUI.Button(new Rect(290, 110, 60, 20), "首", gsButton))
                {
                    isKubi = !isKubi;
                    maid.body0.SetMask(TBody.SlotID.accKubi, isKubi);
                    maid.body0.SetMask(TBody.SlotID.accKubiwa, isKubi);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(360, 110, 40, 20), "耳", gsButton))
                {
                    isMimi = !isMimi;
                    maid.body0.SetMask(TBody.SlotID.accMiMiR, isMimi);
                    maid.body0.SetMask(TBody.SlotID.accMiMiL, isMimi);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(410, 110, 40, 20), "足首", gsButton))
                {
                    isAshi = !isAshi;
                    maid.body0.SetMask(TBody.SlotID.accAshi, isAshi);
                    dCheck = true;
                }

                if (GUI.Button(new Rect(460, 110, 60, 20), "しっぽ", gsButton))
                {
                    isShippo = !isShippo;
                    maid.body0.SetMask(TBody.SlotID.accShippo, isShippo);
                    dCheck = true;
                }


                if (GUI.Button(new Rect(530, 110, 60, 20), "その他", gsButton))
                {
                    isAccSonota = !isAccSonota;
                    maid.body0.SetMask(TBody.SlotID.accHana, isAccSonota);
                    maid.body0.SetMask(TBody.SlotID.accNipR, isAccSonota);
                    maid.body0.SetMask(TBody.SlotID.accNipL, isAccSonota);
                    maid.body0.SetMask(TBody.SlotID.accHeso, isAccSonota);
                    dCheck = true;
                }




                GUI.Label(new Rect(5, 140, 200, 20), "【メインメイドを移動】", gsLabel);

                vm = maid.transform.position;
                vml = maid.transform.localPosition;
                em = maid.transform.eulerAngles;
                if (GUI.Button(new Rect(5, 165, 25, 20), "X↑", gsButton))
                {
                    MaidMove(tgID, "px", moveValue, true);
                }
                if (GUI.Button(new Rect(35, 165, 25, 20), "Y↑", gsButton))
                {
                    MaidMove(tgID, "py", moveValue, true);
                }
                if (GUI.Button(new Rect(65, 165, 25, 20), "Z↑", gsButton))
                {
                    MaidMove(tgID, "pz", moveValue, true);
                }
                if (GUI.Button(new Rect(95, 165, 50, 20), "合体", gsButton))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && LinkMaidCheck(tgID, maidID))
                        {
                            stockMaids[maidID].mem.transform.position = maid.transform.position;
                            stockMaids[maidID].mem.transform.eulerAngles = maid.transform.eulerAngles;
                            maidsState[maidID].majHiBack = maidsState[tgID].majHiBack;
                            maidsState[maidID].majFwBack = maidsState[tgID].majFwBack;
                        }
                    }
                    for (int i = 0; i < SubMans.Length; i++)
                    {
                        if (!SubMans[i].Visible || MansTg[i] != tgID) continue;
                        SubMans[i].transform.position = maid.transform.position;
                        SubMans[i].transform.eulerAngles = maid.transform.eulerAngles;
                    }
                }

                if (GUI.Button(new Rect(5, 190, 25, 20), "X↓", gsButton))
                {
                    MaidMove(tgID, "px", -moveValue, true);
                }
                if (GUI.Button(new Rect(35, 190, 25, 20), "Y↓", gsButton))
                {
                    MaidMove(tgID, "py", -moveValue, true);
                }
                if (GUI.Button(new Rect(65, 190, 25, 20), "Z↓", gsButton))
                {
                    MaidMove(tgID, "pz", -moveValue, true);
                }
                if (GUI.Button(new Rect(95, 190, 50, 20), "ﾘｾｯﾄ", gsButton))
                {
                    foreach (int maidID in vmId)
                    {
                        if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                        stockMaids[maidID].mem.transform.position = new Vector3(0f, 0f, 0f);
                        maidsState[maidID].majHiBack = 0f;
                        maidsState[maidID].majFwBack = 0f;
                    }
                    for (int i = 0; i < SubMans.Length; i++)
                    {
                        if (!SubMans[i].Visible || MansTg[i] != tgID) continue;
                        SubMans[i].transform.position = new Vector3(0f, 0f, 0f);
                    }
                }

                if (GUI.Button(new Rect(155, 165, 45, 20), "左回", gsButton))
                {
                    emValue = em.y + 10f;
                    if (emValue >= 360f) emValue -= 360f;
                    MaidMove(tgID, "ey", emValue, true);
                }
                if (GUI.Button(new Rect(205, 165, 45, 20), "右回", gsButton))
                {
                    emValue = em.y - 10f;
                    if (emValue < 0f) emValue += 360f;
                    MaidMove(tgID, "ey", emValue, true);
                }
                if (GUI.Button(new Rect(255, 165, 45, 20), "反転", gsButton))
                {
                    emValue = em.y + 180f;
                    if (emValue >= 360f) emValue -= 360f;
                    MaidMove(tgID, "ey", emValue, true);
                }

                if (GUI.Button(new Rect(155, 190, 45, 20), "上回", gsButton))
                {
                    emValue = em.x - 10f;
                    if (emValue < 0f) emValue += 360f;
                    if (emValue > 90f && emValue < 270f) emValue = 270f;
                    MaidMove(tgID, "ex", emValue, true);
                }
                if (GUI.Button(new Rect(205, 190, 45, 20), "下回", gsButton))
                {
                    emValue = em.x + 10f;
                    if (emValue >= 360f) emValue -= 360f;
                    if (emValue > 90f && emValue < 270f) emValue = 90f;
                    MaidMove(tgID, "ex", emValue, true);
                }
                if (GUI.Button(new Rect(255, 190, 45, 20), "ﾘｾｯﾄ", gsButton))
                {
                    MaidMove(tgID, "ex", 0f, true);
                }


                GUI.Label(new Rect(310, 145, 100, 20), "【目と顔の向き】", gsLabel);
                maid.body0.boEyeToCam = GUI.Toggle(new Rect(415, 145, 50, 20), maid.body0.boEyeToCam, "目線", gsToggle);
                maid.body0.boHeadToCam = GUI.Toggle(new Rect(475, 145, 45, 20), maid.body0.boHeadToCam, "顔向", gsToggle);
                maidsState[tgID].eAutoSelect = GUI.Toggle(new Rect(520, 145, 90, 20), maidsState[tgID].eAutoSelect, "自動変更", gsToggle);


                GUI.Label(new Rect(310, 170, 95, 20), "移動距離：" + Math.Floor(moveValue * 100), gsLabel);
                moveValue = GUI.HorizontalSlider(new Rect(410, 175, 180, 20), moveValue, 0.01f, 0.3F);

                GUI.Label(new Rect(310, 195, 95, 20), "地面判定：" + Math.Floor(maid.body0.BoneHitHeightY * 100), gsLabel);
                maid.body0.BoneHitHeightY = GUI.HorizontalSlider(new Rect(410, 200, 180, 20), maid.body0.BoneHitHeightY, -2f, 2F);



                //一列目
                GUI.Label(new Rect(5, 220, 190, 20), "【視点変更】", gsLabel);
                GUI.Label(new Rect(5, 240, 90, 20), "視野角：" + Math.Floor(Camera.main.fieldOfView), gsLabel);
                if (!bOculusVR) Camera.main.fieldOfView = GUI.HorizontalSlider(new Rect(95, 245, 100, 20), Camera.main.fieldOfView, 35.0F, 90.0F);
                if (bOculusVR) Camera.main.fieldOfView = GUI.HorizontalSlider(new Rect(95, 245, 100, 20), Camera.main.fieldOfView, 90.0F, 130.0F);

                if (man.Visible) fpsModeEnabled = GUI.Toggle(new Rect(5, 260, 95, 20), fpsModeEnabled, "一人称視点", gsToggle);
                if (!man.Visible) GUI.Label(new Rect(5, 260, 190, 20), "×一人称視点", gsLabel);

                maidFollowEnabled = GUI.Toggle(new Rect(105, 260, 95, 20), maidFollowEnabled, "メイド固定", gsToggle);

                y = 260;
                if (maidFollowEnabled)
                {
                    y += 25;

                    if (GUI.Button(new Rect(10, y, 85, 20), "注視点", gsButton))
                    {
                        lookPoint += 1;
                        if (lookPoint >= lookList.Length) lookPoint = 0;
                    }
                    GUI.Label(new Rect(105, y, 85, 20), lookList[lookPoint], gsLabel);
                    y += 25;

                    GUI.Label(new Rect(5, y, 190, 20), "▼オート変更", gsLabel);
                    y += 20;
                    aoutLook = GUI.Toggle(new Rect(10, y, 85, 20), aoutLook, "注視点", gsToggle);
                    aoutTarget = GUI.Toggle(new Rect(100, y, 95, 20), aoutTarget, "ターゲット", gsToggle);
                    y += 20;
                    aoutAngle = GUI.Toggle(new Rect(10, y, 85, 20), aoutAngle, "アングル", gsToggle);
                    aoutZoom = GUI.Toggle(new Rect(100, y, 95, 20), aoutZoom, "ズーム", gsToggle);
                }
                y += 30;


                GUI.Label(new Rect(5, y, 190, 20), "【サウンド関係】", gsLabel);
                y += 25;

                if (GUI.Button(new Rect(10, y, 85, 20), "SE切替", gsButton))
                {
                    cfgw.SelectSE += 1;
                    if (cfgw.SelectSE >= SeFileList[0].Length) cfgw.SelectSE = 0;
                }
                GUI.Label(new Rect(105, y, 85, 20), SeFileList[0][cfgw.SelectSE], gsLabel);
                y += 25;

                GUI.Label(new Rect(10, y, 145, 20), "▼ボイスセット" + maidsState[tgID].editVoiceSetName, gsLabel);
                y += 20;

                int h1 = evsFiles.Count * 22;
                if (maidsState[tgID].editVoiceSetName != "") h1 += 30;
                if (h1 < 445 - y) h1 = 445 - y;
                Rect scrlRect1 = new Rect(10, y, 190, 445 - y);
                Rect contentRect1 = new Rect(0, 0, 170, h1);
                vsScrollPos1 = GUI.BeginScrollView(scrlRect1, vsScrollPos1, contentRect1, false, true);
                y = 0;

                if (maidsState[tgID].editVoiceSetName != "")
                {
                    if (GUI.Button(new Rect(0, y, 170, 20), "ボイスセット解除", gsButton))
                    {
                        maidsState[tgID].editVoiceSetName = "";
                        maidsState[tgID].editVoiceSet = new List<string[]>();
                    }
                    y += 30;
                }

                foreach (string f in evsFiles)
                {
                    string FileName = f.Replace("evs_", "").Replace(".xml", "");
                    if (GUI.Button(new Rect(0, y, 170, 20), FileName, gsButton))
                    {
                        voiceSetLoad(f, tgID);
                    }
                    y += 22;
                }
                GUI.EndScrollView();



                //音声モード切替
                /*
                GUI.Label (new Rect (5, 370, 190, 20), "【音声モード切替】" , gsLabel);
                if(maidsState[tgID].autoVoiceEnabled){
                  if(GUI.Button(new Rect (10, 395, 85, 20), "オートモード", gsButton)) {
                    maidsState[tgID].autoVoiceEnabled = false;
                    maidsState[tgID].voiceMode = 0;
                  }
                } else {
                  if(GUI.Button(new Rect (10, 395, 85, 20), ModeSelectList[maidsState[tgID].voiceMode], gsButton)) {
                    ++maidsState[tgID].voiceMode;
                    if(maidsState[tgID].voiceMode > 5)maidsState[tgID].autoVoiceEnabled = true;
                  }
                }
                if(GUI.Button(new Rect (105, 395, 85, 20), ModeSelectList2[0][maidsState[tgID].voiceMode2], gsButton)) {
                  ++maidsState[tgID].voiceMode2;
                  if(maidsState[tgID].voiceMode2 >= ModeSelectList2[0].Length)maidsState[tgID].voiceMode2 = 0;
                }
                */


                //二列目
                GUI.Label(new Rect(205, 220, 200, 20), "【Hアイテム装着】", gsLabel);

                if (GUI.Button(new Rect(210, 245, 80, 20), "バイブ", gsButton))
                {
                    if (maid.GetProp(MPN.accvag).strTempFileName == "accVag_VibePink_I_.menu")
                    {
                        maid.DelProp(MPN.accvag, true);
                        maidsState[tgID].itemV = "";
                    }
                    else
                    {
                        maid.SetProp("accvag", "accVag_VibePink_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.accVag, true);
                        try { VertexMorph_FromProcItem(maid.body0, "kupa", 0.6f); } catch { /*LogError(ex);*/ }
                        if (maidsState[tgID].hibuSlider1Value < 60f) maidsState[tgID].hibuSlider1Value = 60f;
                        if (maidsState[tgID].hibuSlider2Value < 60f) maidsState[tgID].hibuSlider2Value = 60f;
                        MekureChanged(tgID, "ずらし", false);
                        ReactionPlay(tgID);
                        maidsState[tgID].itemV = "accVag_VibePink_I_.menu";
                    }
                    maid.AllProcPropSeqStart();
                }
                if (GUI.Button(new Rect(300, 245, 40, 20), "手", gsButton))
                {
                    if (maid.GetProp(MPN.handitem).strTempFileName == "HandItemR_VibePink_I_.menu")
                    {
                        maid.DelProp(MPN.handitem, true);
                    }
                    else
                    {
                        maid.SetProp("handitem", "HandItemR_VibePink_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.HandItemR, true);
                    }
                    maid.AllProcPropSeqStart();
                }
                if (GUI.Button(new Rect(350, 245, 40, 20), "男", gsButton))
                {
                    if (man.GetProp(MPN.handitem).strTempFileName == "HandItemR_VibePink_I_.menu")
                    {
                        man.DelProp(MPN.handitem, true);
                    }
                    else
                    {
                        man.SetProp("handitem", "HandItemR_VibePink_I_.menu", 0, true, false);
                    }
                    man.AllProcPropSeqStart();
                }

                if (GUI.Button(new Rect(210, 270, 80, 20), "Aバイブ", gsButton))
                {
                    if (maid.GetProp(MPN.accanl).strTempFileName == "accAnl_AnalVibe_I_.menu")
                    {
                        maid.DelProp(MPN.accanl, true);
                        maidsState[tgID].itemA = "";
                    }
                    else
                    {
                        maid.SetProp("accanl", "accAnl_AnalVibe_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.accAnl, true);
                        try { VertexMorph_FromProcItem(maid.body0, "analkupa", 0.3f); } catch { /*LogError(ex);*/ }
                        if (maidsState[tgID].analSlider1Value < 30f) maidsState[tgID].analSlider1Value = 30f;
                        if (maidsState[tgID].analSlider2Value < 30f) maidsState[tgID].analSlider2Value = 30f;
                        MekureChanged(tgID, "ずらし", false);
                        ReactionPlay(tgID);
                        maidsState[tgID].itemA = "accAnl_AnalVibe_I_.menu";
                    }
                    maid.AllProcPropSeqStart();
                }
                if (GUI.Button(new Rect(300, 270, 40, 20), "手", gsButton))
                {
                    if (maid.GetProp(MPN.handitem).strTempFileName == "HandItemR_AnalVibe_I_.menu")
                    {
                        maid.DelProp(MPN.handitem, true);
                    }
                    else
                    {
                        maid.SetProp("handitem", "HandItemR_AnalVibe_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.HandItemR, true);
                    }
                    maid.AllProcPropSeqStart();
                }
                if (GUI.Button(new Rect(350, 270, 40, 20), "男", gsButton))
                {
                    if (man.GetProp(MPN.handitem).strTempFileName == "HandItemR_AnalVibe_I_.menu")
                    {
                        man.DelProp(MPN.handitem, true);
                    }
                    else
                    {
                        man.SetProp("handitem", "HandItemR_AnalVibe_I_.menu", 0, true, false);
                    }
                    man.AllProcPropSeqStart();
                }

                if (GUI.Button(new Rect(210, 295, 85, 20), "双頭バイブ", gsButton))
                {
                    if (maid.GetProp(MPN.handitem).strTempFileName == "HandItemH_SoutouVibe_I_.menu")
                    {
                        maid.DelProp(MPN.handitem, true);
                    }
                    else
                    {
                        maid.SetProp("handitem", "HandItemH_SoutouVibe_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.HandItemR, true);
                        try { VertexMorph_FromProcItem(maid.body0, "kupa", 0.6f); } catch { /*LogError(ex);*/ }
                        if (maidsState[tgID].hibuSlider1Value < 60f) maidsState[tgID].hibuSlider1Value = 60f;
                        if (maidsState[tgID].hibuSlider2Value < 60f) maidsState[tgID].hibuSlider2Value = 60f;
                        MekureChanged(tgID, "ずらし", false);
                        ReactionPlay(tgID);
                    }
                    maid.AllProcPropSeqStart();
                }
                if (GUI.Button(new Rect(305, 295, 85, 20), "電マ", gsButton))
                {
                    if (man.GetProp(MPN.handitem).strTempFileName == "HandItemR_Denma_I_.menu")
                    {
                        man.DelProp(MPN.handitem, true);
                    }
                    else
                    {
                        man.SetProp("handitem", "HandItemR_Denma_I_.menu", 0, true, false);
                    }
                    man.AllProcPropSeqStart();
                }

                if (GUI.Button(new Rect(210, 320, 85, 20), "拘束(手)", gsButton))
                {
                    if (maid.GetProp(MPN.kousoku_upper).strTempFileName == "KousokuU_TekaseOne_I_.menu")
                    {
                        maid.DelProp(MPN.kousoku_upper, true);
                    }
                    else
                    {
                        maid.SetProp("kousoku_upper", "KousokuU_TekaseOne_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.kousoku_upper, true);
                    }
                    maid.AllProcPropSeqStart();
                }
                if (GUI.Button(new Rect(305, 320, 85, 20), "拘束(足)", gsButton))
                {
                    if (maid.GetProp(MPN.kousoku_lower).strTempFileName == "KousokuL_AshikaseUp_I_.menu")
                    {
                        maid.DelProp(MPN.kousoku_lower, true);
                    }
                    else
                    {
                        maid.SetProp("kousoku_lower", "KousokuL_AshikaseUp_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.kousoku_lower, true);
                    }
                    maid.AllProcPropSeqStart();
                }

                if (GUI.Button(new Rect(210, 345, 85, 20), "磔", gsButton))
                {
                    if (maid.GetProp(MPN.kousoku_upper).strTempFileName == "KousokuU_SMRoom_Haritsuke_I_.menu")
                    {
                        maid.DelProp(MPN.kousoku_upper, true);
                    }
                    else
                    {
                        maid.SetProp("kousoku_upper", "KousokuU_SMRoom_Haritsuke_I_.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.kousoku_upper, true);
                    }
                    maid.AllProcPropSeqStart();
                }

                if (GUI.Button(new Rect(210, 370, 85, 20), "ディルド台", gsButton))
                {
                    GameObject prefabFromBg = GameObject.Find("ディルド＆台");
                    if (prefabFromBg != null)
                    {
                        GameMain.Instance.BgMgr.DelPrefabFromBg("ディルド＆台");
                    }
                    else
                    {
                        Vector3 zero = maid.transform.position;
                        zero.y = zero.y - 0.0007f * (50 - maid.GetProp(MPN.sintyou).value);
                        Vector3 zero2 = maid.transform.eulerAngles;
                        zero2.x = -90f;
                        GameMain.Instance.BgMgr.AddPrefabToBg("Odogu_DildoBox", "ディルド＆台", null, zero, zero2);
                    }
                }

                if (GUI.Button(new Rect(305, 370, 85, 20), "三角木馬", gsButton))
                {

                    GameObject prefabFromBg = GameObject.Find("三角木馬");
                    if (prefabFromBg != null)
                    {
                        Console.WriteLine("Odogu_SankakuMokuba有り");
                        GameMain.Instance.BgMgr.DelPrefabFromBg("三角木馬");
                    }
                    else
                    {
                        Console.WriteLine("Odogu_SankakuMokuba無し");
                        Vector3 zero = maid.transform.position;
                        zero.y = zero.y - 0.00185f * (50 - maid.GetProp(MPN.sintyou).value);
                        Vector3 zero2 = maid.transform.eulerAngles;
                        zero2.x = -90f;
                        GameMain.Instance.BgMgr.AddPrefabToBg("Odogu_SankakuMokuba", "三角木馬", null, zero, zero2);
                    }
                }


                if (GUI.Button(new Rect(305, 395, 85, 20), "全て外す", gsButton))
                {
                    maid.DelProp(MPN.accvag, true);
                    maid.DelProp(MPN.accanl, true);
                    maid.DelProp(MPN.handitem, true);
                    maid.DelProp(MPN.kousoku_upper, true);
                    maid.DelProp(MPN.kousoku_lower, true);
                    maid.DelProp(MPN.accxxx, true);//自分用
                    maid.AllProcPropSeqStart();

                    man.DelProp(MPN.handitem, true);
                    man.AllProcPropSeqStart();

                    GameMain.Instance.BgMgr.DelPrefabFromBgAll();
                }

                //自分用
                if (GUI.Button(new Rect(210, 395, 85, 20), "ふたなり", gsButton))
                {
                    if (maid.GetProp(MPN.accxxx).strTempFileName == "chinko_nae_m.menu")
                    {
                        maid.DelProp(MPN.accxxx, true);
                    }
                    else
                    {
                        maid.SetProp("accxxx", "chinko_nae_m.menu", 0, true, false);
                        maid.body0.SetMask(TBody.SlotID.accXXX, true);
                    }
                    maid.AllProcPropSeqStart();
                }


                if (GUI.Button(new Rect(210, 425, 185, 20), "髪型と衣装を基本に戻す", gsButton))
                {
                    maid.ResetProp("hairf", false);
                    maid.ResetProp("hairr", false);
                    maid.ResetProp("hairs", false);
                    maid.ResetProp("hairt", false);
                    maid.ResetProp("hairaho", false);
                    maid.ResetProp("acckami", false);
                    maid.ResetProp("acckamisub", false);
                    maid.ResetProp("acchat", false);
                    maid.ResetProp("headset", false);
                    maid.ResetProp("wear", false);
                    maid.ResetProp("skirt", false);
                    maid.ResetProp("onepiece", false);
                    maid.ResetProp("mizugi", false);
                    maid.ResetProp("bra", false);
                    maid.ResetProp("panz", false);
                    maid.ResetProp("stkg", false);
                    maid.ResetProp("shoes", false);
                    maid.ResetProp("megane", false);
                    maid.ResetProp("acchead", false);
                    maid.ResetProp("glove", false);
                    maid.ResetProp("accude", false);
                    maid.ResetProp("acchana", false);
                    maid.ResetProp("accmimi", false);
                    maid.ResetProp("accnip", false);
                    maid.ResetProp("acckubi", false);
                    maid.ResetProp("acckubiwa", false);
                    maid.ResetProp("accheso", false);
                    maid.ResetProp("accashi", false);
                    maid.ResetProp("accsenaka", false);
                    maid.ResetProp("accxxx", false);
                    maid.AllProcPropSeqStart();
                }


                //三列目
                GUI.Label(new Rect(405, 220, 120, 20), "【髪型の変更】", gsLabel);

                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairF"))
                {
                    if (GUI.Button(new Rect(410, 245, 85, 20), "髪型１", gsButton))
                    {
                        maid.SetProp(MPN.hairf, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairF", "0"), 0, true, false);
                        maid.SetProp(MPN.hairr, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairR", "0"), 0, true, false);
                        maid.SetProp(MPN.hairs, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairS", "0"), 0, true, false);
                        maid.SetProp(MPN.hairt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairT", "0"), 0, true, false);
                        maid.SetProp(MPN.hairaho, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairAho", "0"), 0, true, false);
                        maid.SetProp(MPN.acckami, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accKami", "0"), 0, true, false);
                        maid.SetProp(MPN.acckamisub, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accKamiSub", "0"), 0, true, false);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("髪型１ セット完了");
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairF"))
                {
                    if (GUI.Button(new Rect(505, 245, 85, 20), "髪型２", gsButton))
                    {
                        maid.SetProp(MPN.hairf, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairF", "0"), 0, true, false);
                        maid.SetProp(MPN.hairr, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairR", "0"), 0, true, false);
                        maid.SetProp(MPN.hairs, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairS", "0"), 0, true, false);
                        maid.SetProp(MPN.hairt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairT", "0"), 0, true, false);
                        maid.SetProp(MPN.hairaho, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairAho", "0"), 0, true, false);
                        maid.SetProp(MPN.acckami, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accKami", "0"), 0, true, false);
                        maid.SetProp(MPN.acckamisub, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accKamiSub", "0"), 0, true, false);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("髪型２ セット完了");
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairF"))
                {
                    if (GUI.Button(new Rect(410, 270, 85, 20), "髪型３", gsButton))
                    {
                        maid.SetProp(MPN.hairf, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairF", "0"), 0, true, false);
                        maid.SetProp(MPN.hairr, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairR", "0"), 0, true, false);
                        maid.SetProp(MPN.hairs, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairS", "0"), 0, true, false);
                        maid.SetProp(MPN.hairt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairT", "0"), 0, true, false);
                        maid.SetProp(MPN.hairaho, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairAho", "0"), 0, true, false);
                        maid.SetProp(MPN.acckami, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accKami", "0"), 0, true, false);
                        maid.SetProp(MPN.acckamisub, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accKamiSub", "0"), 0, true, false);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("髪型３ セット完了");
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairF"))
                {
                    if (GUI.Button(new Rect(505, 270, 85, 20), "髪型４", gsButton))
                    {
                        maid.SetProp(MPN.hairf, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairF", "0"), 0, true, false);
                        maid.SetProp(MPN.hairr, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairR", "0"), 0, true, false);
                        maid.SetProp(MPN.hairs, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairS", "0"), 0, true, false);
                        maid.SetProp(MPN.hairt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairT", "0"), 0, true, false);
                        maid.SetProp(MPN.hairaho, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairAho", "0"), 0, true, false);
                        maid.SetProp(MPN.acckami, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accKami", "0"), 0, true, false);
                        maid.SetProp(MPN.acckamisub, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accKamiSub", "0"), 0, true, false);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("髪型４ セット完了");
                    }
                }


                GUI.Label(new Rect(405, 300, 190, 20), "【衣装の変更】", gsLabel);

                h1 = cdsFiles.Count * 22 + 55;
                if (h1 < 115) h1 = 115;
                scrlRect1 = new Rect(410, 325, 210, 115);
                contentRect1 = new Rect(0, 0, 190, h1);
                dsScrollPos = GUI.BeginScrollView(scrlRect1, dsScrollPos, contentRect1, false, true);
                x = 0;
                y = 0;

                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat"))
                {
                    if (GUI.Button(new Rect(x, y, 85, 20), "衣装１", gsButton))
                    {
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat", "0") != "") maid.SetProp(MPN.acchat, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_headset", "0") != "") maid.SetProp(MPN.headset, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_headset", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_wear", "0") != "") maid.SetProp(MPN.wear, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_wear", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_skirt", "0") != "") maid.SetProp(MPN.skirt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_skirt", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_onepiece", "0") != "") maid.SetProp(MPN.onepiece, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_onepiece", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_mizugi", "0") != "") maid.SetProp(MPN.mizugi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_mizugi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_bra", "0") != "") maid.SetProp(MPN.bra, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_bra", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_panz", "0") != "") maid.SetProp(MPN.panz, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_panz", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_stkg", "0") != "") maid.SetProp(MPN.stkg, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_stkg", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_shoes", "0") != "") maid.SetProp(MPN.shoes, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_shoes", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_megane", "0") != "") maid.SetProp(MPN.megane, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_megane", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchead", "0") != "") maid.SetProp(MPN.acchead, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchead", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_glove", "0") != "") maid.SetProp(MPN.glove, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_glove", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accude", "0") != "") maid.SetProp(MPN.accude, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accude", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchana", "0") != "") maid.SetProp(MPN.acchana, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchana", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accmimi", "0") != "") maid.SetProp(MPN.accmimi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accmimi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accnip", "0") != "") maid.SetProp(MPN.accnip, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accnip", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubi", "0") != "") maid.SetProp(MPN.acckubi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubiwa", "0") != "") maid.SetProp(MPN.acckubiwa, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubiwa", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accheso", "0") != "") maid.SetProp(MPN.accheso, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accheso", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accashi", "0") != "") maid.SetProp(MPN.accashi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accashi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accsenaka", "0") != "") maid.SetProp(MPN.accsenaka, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accsenaka", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accshippo", "0") != "") maid.SetProp(MPN.accshippo, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accshippo", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accxxx", "0") != "") maid.SetProp(MPN.accxxx, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "1_accxxx", "0"), 0, true, false);

                        AllDressVisible(tgID, true);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("衣装１ セット完了");
                    }
                    if (x == 0)
                    {
                        x = 95;
                    }
                    else if (x == 95)
                    {
                        x = 0; y += 25;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat"))
                {
                    if (GUI.Button(new Rect(95, y, 85, 20), "衣装２", gsButton))
                    {
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat", "0") != "") maid.SetProp(MPN.acchat, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_headset", "0") != "") maid.SetProp(MPN.headset, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_headset", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_wear", "0") != "") maid.SetProp(MPN.wear, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_wear", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_skirt", "0") != "") maid.SetProp(MPN.skirt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_skirt", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_onepiece", "0") != "") maid.SetProp(MPN.onepiece, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_onepiece", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_mizugi", "0") != "") maid.SetProp(MPN.mizugi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_mizugi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_bra", "0") != "") maid.SetProp(MPN.bra, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_bra", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_panz", "0") != "") maid.SetProp(MPN.panz, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_panz", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_stkg", "0") != "") maid.SetProp(MPN.stkg, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_stkg", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_shoes", "0") != "") maid.SetProp(MPN.shoes, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_shoes", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_megane", "0") != "") maid.SetProp(MPN.megane, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_megane", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchead", "0") != "") maid.SetProp(MPN.acchead, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchead", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_glove", "0") != "") maid.SetProp(MPN.glove, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_glove", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accude", "0") != "") maid.SetProp(MPN.accude, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accude", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchana", "0") != "") maid.SetProp(MPN.acchana, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchana", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accmimi", "0") != "") maid.SetProp(MPN.accmimi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accmimi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accnip", "0") != "") maid.SetProp(MPN.accnip, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accnip", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubi", "0") != "") maid.SetProp(MPN.acckubi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubiwa", "0") != "") maid.SetProp(MPN.acckubiwa, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubiwa", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accheso", "0") != "") maid.SetProp(MPN.accheso, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accheso", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accashi", "0") != "") maid.SetProp(MPN.accashi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accashi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accsenaka", "0") != "") maid.SetProp(MPN.accsenaka, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accsenaka", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accshippo", "0") != "") maid.SetProp(MPN.accshippo, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accshippo", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accxxx", "0") != "") maid.SetProp(MPN.accxxx, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "2_accxxx", "0"), 0, true, false);

                        AllDressVisible(tgID, true);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("衣装２ セット完了");
                    }
                    if (x == 0)
                    {
                        x = 95;
                    }
                    else if (x == 95)
                    {
                        x = 0; y += 25;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat"))
                {
                    if (GUI.Button(new Rect(0, y, 85, 20), "衣装３", gsButton))
                    {
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat", "0") != "") maid.SetProp(MPN.acchat, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_headset", "0") != "") maid.SetProp(MPN.headset, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_headset", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_wear", "0") != "") maid.SetProp(MPN.wear, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_wear", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_skirt", "0") != "") maid.SetProp(MPN.skirt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_skirt", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_onepiece", "0") != "") maid.SetProp(MPN.onepiece, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_onepiece", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_mizugi", "0") != "") maid.SetProp(MPN.mizugi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_mizugi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_bra", "0") != "") maid.SetProp(MPN.bra, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_bra", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_panz", "0") != "") maid.SetProp(MPN.panz, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_panz", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_stkg", "0") != "") maid.SetProp(MPN.stkg, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_stkg", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_shoes", "0") != "") maid.SetProp(MPN.shoes, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_shoes", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_megane", "0") != "") maid.SetProp(MPN.megane, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_megane", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchead", "0") != "") maid.SetProp(MPN.acchead, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchead", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_glove", "0") != "") maid.SetProp(MPN.glove, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_glove", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accude", "0") != "") maid.SetProp(MPN.accude, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accude", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchana", "0") != "") maid.SetProp(MPN.acchana, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchana", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accmimi", "0") != "") maid.SetProp(MPN.accmimi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accmimi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accnip", "0") != "") maid.SetProp(MPN.accnip, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accnip", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubi", "0") != "") maid.SetProp(MPN.acckubi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubiwa", "0") != "") maid.SetProp(MPN.acckubiwa, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubiwa", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accheso", "0") != "") maid.SetProp(MPN.accheso, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accheso", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accashi", "0") != "") maid.SetProp(MPN.accashi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accashi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accsenaka", "0") != "") maid.SetProp(MPN.accsenaka, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accsenaka", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accshippo", "0") != "") maid.SetProp(MPN.accshippo, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accshippo", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accxxx", "0") != "") maid.SetProp(MPN.accxxx, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "3_accxxx", "0"), 0, true, false);

                        AllDressVisible(tgID, true);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("衣装３ セット完了");
                    }
                    if (x == 0)
                    {
                        x = 95;
                    }
                    else if (x == 95)
                    {
                        x = 0; y += 25;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat"))
                {
                    if (GUI.Button(new Rect(95, y, 85, 20), "衣装４", gsButton))
                    {
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat", "0") != "") maid.SetProp(MPN.acchat, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_headset", "0") != "") maid.SetProp(MPN.headset, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_headset", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_wear", "0") != "") maid.SetProp(MPN.wear, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_wear", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_skirt", "0") != "") maid.SetProp(MPN.skirt, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_skirt", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_onepiece", "0") != "") maid.SetProp(MPN.onepiece, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_onepiece", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_mizugi", "0") != "") maid.SetProp(MPN.mizugi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_mizugi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_bra", "0") != "") maid.SetProp(MPN.bra, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_bra", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_panz", "0") != "") maid.SetProp(MPN.panz, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_panz", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_stkg", "0") != "") maid.SetProp(MPN.stkg, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_stkg", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_shoes", "0") != "") maid.SetProp(MPN.shoes, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_shoes", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_megane", "0") != "") maid.SetProp(MPN.megane, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_megane", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchead", "0") != "") maid.SetProp(MPN.acchead, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchead", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_glove", "0") != "") maid.SetProp(MPN.glove, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_glove", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accude", "0") != "") maid.SetProp(MPN.accude, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accude", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchana", "0") != "") maid.SetProp(MPN.acchana, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchana", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accmimi", "0") != "") maid.SetProp(MPN.accmimi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accmimi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accnip", "0") != "") maid.SetProp(MPN.accnip, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accnip", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubi", "0") != "") maid.SetProp(MPN.acckubi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubiwa", "0") != "") maid.SetProp(MPN.acckubiwa, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubiwa", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accheso", "0") != "") maid.SetProp(MPN.accheso, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accheso", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accashi", "0") != "") maid.SetProp(MPN.accashi, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accashi", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accsenaka", "0") != "") maid.SetProp(MPN.accsenaka, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accsenaka", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accshippo", "0") != "") maid.SetProp(MPN.accshippo, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accshippo", "0"), 0, true, false);
                        if (ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accxxx", "0") != "") maid.SetProp(MPN.accxxx, ExSaveData.Get(maid, "CM3D2.VibeYourMaid.Plugin", "4_accxxx", "0"), 0, true, false);

                        AllDressVisible(tgID, true);
                        maid.AllProcPropSeqStart();
                        Console.WriteLine("衣装４ セット完了");
                    }
                    if (x == 0)
                    {
                        x = 95;
                    }
                    else if (x == 95)
                    {
                        x = 0; y += 25;
                    }
                }
                if (x != 0) y += 25;


                foreach (string f in cdsFiles)
                {
                    string FileName = f.Replace("cds_", "").Replace(".xml", "");
                    if (GUI.Button(new Rect(5, y, 180, 20), FileName, gsButton))
                    {
                        CdsFileLoad(f);
                    }
                    y += 22;
                }
                GUI.EndScrollView();
            }


            if (ConfigFlag == 1)
            {
                //一列目
                GUI.Label(new Rect(5, 35, 190, 20), "【各演出の有無】", gsLabel);

                cfgw.HohoEnabled = GUI.Toggle(new Rect(5, 55, 55, 20), cfgw.HohoEnabled, "頬染め", gsToggle);
                cfgw.NamidaEnabled = GUI.Toggle(new Rect(80, 55, 40, 20), cfgw.NamidaEnabled, "涙", gsToggle);
                cfgw.aseAnimeEnabled = GUI.Toggle(new Rect(140, 55, 40, 20), cfgw.aseAnimeEnabled, "汗", gsToggle);
                cfgw.YodareEnabled = GUI.Toggle(new Rect(5, 75, 55, 20), cfgw.YodareEnabled, "よだれ", gsToggle);
                cfgw.CliAnimeEnabled = GUI.Toggle(new Rect(80, 75, 75, 20), cfgw.CliAnimeEnabled, "クリ勃起", gsToggle);
                cfgw.SioEnabled = GUI.Toggle(new Rect(5, 95, 55, 20), cfgw.SioEnabled, "潮吹き", gsToggle);
                cfgw.NyoEnabled = GUI.Toggle(new Rect(80, 95, 70, 20), cfgw.NyoEnabled, "お漏らし", gsToggle);
                cfgw.OrgsmAnimeEnabled = GUI.Toggle(new Rect(5, 115, 75, 20), cfgw.OrgsmAnimeEnabled, "痙攣動作", gsToggle);
                cfgw.AheEnabled = GUI.Toggle(new Rect(80, 115, 115, 20), cfgw.AheEnabled, "瞳上昇（アヘ）", gsToggle);
                cfgw.zViceWaitEnabled = GUI.Toggle(new Rect(5, 135, 190, 20), cfgw.zViceWaitEnabled, "絶頂時に音声終了を待つ", gsToggle);

                GUI.Label(new Rect(5, 165, 190, 20), "【メイド切替時の設定】", gsLabel);
                cfgw.TaikiEnabled = GUI.Toggle(new Rect(5, 185, 190, 20), cfgw.TaikiEnabled, "余韻状態にする", gsToggle);
                cfgw.CamChangeEnabled = GUI.Toggle(new Rect(5, 205, 190, 20), cfgw.CamChangeEnabled, "カメラを追従する", gsToggle);

                GUI.Label(new Rect(5, 235, 190, 20), "【口元の変更】", gsLabel);
                cfgw.MouthNomalEnabled = GUI.Toggle(new Rect(5, 255, 90, 20), cfgw.MouthNomalEnabled, "通常時", gsToggle);
                cfgw.MouthKissEnabled = GUI.Toggle(new Rect(95, 255, 90, 20), cfgw.MouthKissEnabled, "キス", gsToggle);
                cfgw.MouthZeccyouEnabled = GUI.Toggle(new Rect(5, 275, 90, 20), cfgw.MouthZeccyouEnabled, "連続絶頂", gsToggle);
                cfgw.MouthFeraEnabled = GUI.Toggle(new Rect(95, 275, 90, 20), cfgw.MouthFeraEnabled, "フェラ", gsToggle);

                GUI.Label(new Rect(5, 305, 190, 20), "【カメラの距離判定機能】", gsLabel);
                cfgw.camCheckEnabled = GUI.Toggle(new Rect(5, 325, 190, 20), cfgw.camCheckEnabled, "自動でキスに変更する", gsToggle);
                GUI.Label(new Rect(5, 345, 90, 20), "判定範囲：" + Math.Floor(cfgw.camCheckRange * 100), gsLabel);
                cfgw.camCheckRange = GUI.HorizontalSlider(new Rect(95, 350, 100, 20), cfgw.camCheckRange, 0.0F, 1.0F);

                GUI.Label(new Rect(5, 380, 190, 20), "【ショートカットの同時押し】", gsLabel);
                cfgw.andKeyEnabled[0] = GUI.Toggle(new Rect(5, 400, 55, 20), cfgw.andKeyEnabled[0], " Ctrl", gsToggle);
                if (cfgw.andKeyEnabled[0]) cfgw.andKeyEnabled = new bool[] { true, false, false };
                cfgw.andKeyEnabled[1] = GUI.Toggle(new Rect(65, 400, 55, 20), cfgw.andKeyEnabled[1], " Alt", gsToggle);
                if (cfgw.andKeyEnabled[1]) cfgw.andKeyEnabled = new bool[] { false, true, false };
                cfgw.andKeyEnabled[2] = GUI.Toggle(new Rect(125, 400, 70, 20), cfgw.andKeyEnabled[2], " Shift", gsToggle);
                if (cfgw.andKeyEnabled[2]) cfgw.andKeyEnabled = new bool[] { false, false, true };


                //二列目
                GUI.Label(new Rect(205, 35, 190, 20), "【秘部のシェイプアニメを連動】", gsLabel);
                cfgw.hibuAnime1Enabled = GUI.Toggle(new Rect(205, 55, 190, 20), cfgw.hibuAnime1Enabled, "動作時", gsToggle);
                GUI.Label(new Rect(205, 75, 90, 20), "kupa開度：" + Math.Floor(maidsState[tgID].hibuSlider1Value), gsLabel);
                maidsState[tgID].hibuSlider1Value = GUI.HorizontalSlider(new Rect(295, 80, 100, 20), maidsState[tgID].hibuSlider1Value, 0.0F, 100.0F);
                GUI.Label(new Rect(205, 95, 90, 20), "anal開度：" + Math.Floor(maidsState[tgID].analSlider1Value), gsLabel);
                maidsState[tgID].analSlider1Value = GUI.HorizontalSlider(new Rect(295, 100, 100, 20), maidsState[tgID].analSlider1Value, 0.0F, 100.0F);

                cfgw.hibuAnime2Enabled = GUI.Toggle(new Rect(205, 120, 190, 20), cfgw.hibuAnime2Enabled, "停止時", gsToggle);
                GUI.Label(new Rect(205, 140, 90, 20), "kupa開度：" + Math.Floor(maidsState[tgID].hibuSlider2Value), gsLabel);
                maidsState[tgID].hibuSlider2Value = GUI.HorizontalSlider(new Rect(295, 145, 100, 20), maidsState[tgID].hibuSlider2Value, 0.0F, 100.0F);
                GUI.Label(new Rect(205, 160, 90, 20), "anal開度：" + Math.Floor(maidsState[tgID].analSlider2Value), gsLabel);
                maidsState[tgID].analSlider2Value = GUI.HorizontalSlider(new Rect(295, 165, 100, 20), maidsState[tgID].analSlider2Value, 0.0F, 100.0F);

                GUI.Label(new Rect(205, 190, 190, 20), "【モーションアジャスト】", gsLabel);
                cfgw.majEnabled = GUI.Toggle(new Rect(205, 210, 190, 20), cfgw.majEnabled, "モーションアジャスト有効", gsToggle);
                cfgw.majItemClear = GUI.Toggle(new Rect(215, 230, 190, 20), cfgw.majItemClear, "実行時にアイテムをクリア", gsToggle);
                cfgw.majKupaEnabled = GUI.Toggle(new Rect(215, 250, 190, 20), cfgw.majKupaEnabled, "kupa値変更を有効", gsToggle);


                GUI.Label(new Rect(205, 280, 190, 20), "【マニアック演出】", gsLabel);
                cfgw.uDatsuEnabled = GUI.Toggle(new Rect(205, 300, 190, 20), cfgw.uDatsuEnabled, "子宮脱", gsToggle);

                if (GUI.Button(new Rect(205, 325, 70, 20), "クリ属性", gsButton))
                {
                    ++maidsState[tgID].cliMode;
                    if (maidsState[tgID].cliMode > 2) maidsState[tgID].cliMode = 0;
                    ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "cliMode", maidsState[tgID].cliMode.ToString(), true);

                    try { VertexMorph_FromProcItem(maid.body0, "clitoris", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_large", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "pussy_clitoris_penis", 0f); } catch { /*LogError(ex);*/ }
                }
                GUI.Label(new Rect(290, 325, 70, 20), cliModeText[maidsState[tgID].cliMode], gsLabel);


                GUI.Label(new Rect(205, 355, 190, 20), "【お触り設定】", gsLabel);
                cfgw.osawariEnabled = GUI.Toggle(new Rect(205, 375, 190, 20), cfgw.osawariEnabled, "お触り機能を有効", gsToggle);




                //三列目
                GUI.Label(new Rect(415, 35, 150, 20), "【各EDIT画面を表示】", gsLabel);

                if (GUI.Button(new Rect(420, 60, 190, 20), "基本ボイスセット", gsButton))
                {
                    ConfigFlag = 2;
                }

                if (GUI.Button(new Rect(420, 90, 190, 20), "オリジナルボイスセット", gsButton))
                {
                    ConfigFlag = 3;
                }

                if (GUI.Button(new Rect(420, 120, 190, 20), "ランダムモーションセット", gsButton))
                {
                    ConfigFlag = 4;
                }

                if (GUI.Button(new Rect(420, 150, 190, 20), "髪型・服装の登録", gsButton))
                {
                    ConfigFlag = 5;
                }

                if (GUI.Button(new Rect(420, 180, 190, 20), "モーションアジャスト詳細設定", gsButton))
                {
                    ConfigFlag = 6;
                }


                /*
                if(GUI.Button(new Rect (420, 210, 190, 20), "エンパイアズライフ設定", gsButton)) {
                  LifeSceneLoad();
                  ConfigFlag = 7;
                }*/

                if (GUI.Button(new Rect(420, 240, 190, 20), "エロステータス表示", gsButton))
                {
                    ConfigFlag = 8;
                }

                if (GUI.Button(new Rect(420, 270, 190, 20), "乳首設定の登録", gsButton))
                {
                    ConfigFlag = 9;
                }



                GUI.Label(new Rect(415, 300, 150, 20), "【その他特殊操作】", gsLabel);

                if (vSceneLevel == 3)
                {
                    if (GUI.Button(new Rect(420, 325, 150, 20), "UI表示切り替え", gsButton))
                    {
                        gameObject_ui.SetActive(!gameObject_ui.activeSelf);
                    }
                }

                /*開発用
                if(GUI.Button(new Rect (460, 380, 150, 20), "性格チェック", gsButton)) {
                  Console.WriteLine(stockMaids[tgID].personal);
                }

                if(GUI.Button(new Rect (460, 405, 150, 20), "MAJ 一括初期設定", gsButton)) {
                  for (int i = 0; i < maj.motionName.Count; i++){
                    if(!maj.giveSexual[i][9]){
                      maj.giveSexual[i] = GiveSexualSet(maj.motionName[i]);
                    }
                  }
                }
                */

            }


            if (ConfigFlag == 2)
            {
                x = 0;
                y = 0;
                scKeyOff = GUI.Toggle(new Rect(420, 5, 140, 20), scKeyOff, "ショートカット無効", gsToggle);

                //ボイスセット編集画面
                x = 5;
                y = 40;
                GUI.Label(new Rect(x, y, 400, 20), "基本ボイス編集画面　現在準備中", gsLabel3);


                /*
                //性格選択メニュー
                for (int i = 0; i < personalList[0].Length; i++){
                  if(fVoiceSet2[0] == i){
                    GUI.Label (new Rect (x, y, 60, 20), personalList[0][i] , gsLabel3);
                  }else{
                    if(GUI.Button(new Rect (x, y, 60, 20), personalList[0][i], gsButton)) {
                      fVoiceSet2[0] = i;
                    }
                  }
                  x += 65;
                  if(x + 60 > 620){
                    x = 5;
                    y += 25;
                  }

                }

                //音声種類選択
                x = 10;
                y += 35;
                for (int i = 0; i < bvsText1.Length; i++){
                  if(fVoiceSet2[1] == i){
                    GUI.Label (new Rect (x, y, 60, 20), bvsText1[i] , gsLabel3);
                  }else{
                    if(GUI.Button(new Rect (x, y, 60, 20), bvsText1[i], gsButton)) {
                      fVoiceSet2[1] = i;
                    }
                  }
                }

                x = 220;
                y -= 180;
                int h2 = VSX.saveVoiceSet.Count * 65 + 30;
                if(h2 < 445 - y)h2 = 445 - y;

                Rect scrlRect2    = new Rect(x, y, 400, 445 - y);
                Rect contentRect2 = new Rect(0, 0, 380, h2);
                vsScrollPos2 = GUI.BeginScrollView( scrlRect2, vsScrollPos2, contentRect2, false, true );

                y = 0;
                int iv;
                var _vf = new List<List<string>>();

                if(fVoiceSet2[1] != 6){
                  _vf = new List<List<string>>();
                  if(fVoiceSet2[1] == 0)_vf.AddRange(bvs[i].sLoopVoice20Vibe);
                  if(fVoiceSet2[1] == 1)_vf.AddRange(bvs[i].sLoopVoice20Fera);
                  if(fVoiceSet2[1] == 2)_vf.AddRange(bvs[i].sLoopVoice30Vibe);
                  if(fVoiceSet2[1] == 3)_vf.AddRange(bvs[i].sLoopVoice30Fera);
                  if(fVoiceSet2[1] == 4)_vf.AddRange(bvs[i].sOrgasmVoice30Vibe);
                  if(fVoiceSet2[1] == 5)_vf.AddRange(bvs[i].sOrgasmVoice30Fera);


                  for (int i2 = 0; i2 < 5; i2++){
                    for (int i3 = 0; i3 < _vf.Count; i3++){
                      if(!GameUty.FileSystem.IsExistentFile(_vf[i3]) && !GameUty.FileSystemOld.IsExistentFile(_vf[i3]) && _vf[i3] != "" && _vf[i3] != ".ogg"){
                        Console.WriteLine("音声ファイルが存在しないため除外：" + _vf[i3]);
                        _vf.RemoveAt(i3);
                        i3--;
                      }
                    }
                    bvs[i].sLoopVoice20Vibe[i2] = _vf.ToArray();
                  }
                }

                for (int r = 0; r < 5; r++){
                  for (int i = 0; i < bvs[fVoiceSet2[0]].sLoopVoice20Vibe[i].Length; i++){

                    GUI.Label (new Rect (0, 0 + y, 30, 20), "音声" , gsLabel);
                    VSX.saveVoiceSet[i][0] = GUI.TextField(new Rect(30, 0 + y, 110, 20), VSX.saveVoiceSet[i][0]);

                    if(GUI.Button(new Rect (220, 25 + y, 80, 20), "テスト再生", gsButton)) {
                      if(!Regex.IsMatch(VSX.saveVoiceSet[i][0],@"\.[a-zA-Z][a-zA-Z]"))VSX.saveVoiceSet[i][0] = VSX.saveVoiceSet[i][0] + ".ogg";
                      stockMaids[tgID].mem.AudioMan.LoadPlay(VSX.saveVoiceSet[i][0], 0f, false, false);
                    }

                    if(GUI.Button(new Rect (310, 25 + y, 60, 20), "削除", gsButton)) {
                      VSX.saveVoiceSet.RemoveAt(i);
                    }

                    GUI.Label (new Rect (5, 45 + y, 370, 20), "―――――――――――――――――――――――――――――", gsLabel2);

                    y += 65;
                  }
                }

                if(GUI.Button(new Rect (315, 0 + y, 60, 20), "追加", gsButton)) {
                  string[] set = new string[]{ "" , fVoiceSet[0].ToString() , "0" , "3" , "0" , "3" , fVoiceSet[3].ToString() , fVoiceSet[4].ToString() };
                  VSX.saveVoiceSet.Add(set);
                }

                GUI.EndScrollView();
                */
            }



            if (ConfigFlag == 3)
            {
                x = 0;
                y = 0;
                scKeyOff = GUI.Toggle(new Rect(420, 5, 140, 20), scKeyOff, "ショートカット無効", gsToggle);

                y += 40;
                GUI.Label(new Rect(5, y, 90, 20), "ボイスセット名", gsLabel);
                vs_Overwrite = GUI.Toggle(new Rect(105, y, 70, 20), vs_Overwrite, "上書／ｸﾘｱ", gsToggle);

                y += 20;
                VSX.saveVoiceSetName = GUI.TextField(new Rect(5, y, 170, 20), VSX.saveVoiceSetName);

                y += 25;

                if (GUI.Button(new Rect(5, y, 40, 20), "振分", gsButton))
                {
                    for (int i = 0; i < VSX.saveVoiceSet.Count; i++)
                    {
                        if (VSX.saveVoiceSet[i][0] == "") VSX.saveVoiceSet.RemoveAt(i);
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s0_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S0_")) VSX.saveVoiceSet[i][1] = "0";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s1_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S1_")) VSX.saveVoiceSet[i][1] = "1";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s2_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S2_")) VSX.saveVoiceSet[i][1] = "2";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s3_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S3_")) VSX.saveVoiceSet[i][1] = "3";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s4_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S4_")) VSX.saveVoiceSet[i][1] = "4";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s5_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S5_")) VSX.saveVoiceSet[i][1] = "5";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^s6_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^S6_")) VSX.saveVoiceSet[i][1] = "6";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h0_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H0_")) VSX.saveVoiceSet[i][1] = "7";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h1_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H1_")) VSX.saveVoiceSet[i][1] = "8";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h2_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H2_")) VSX.saveVoiceSet[i][1] = "9";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h3_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H3_")) VSX.saveVoiceSet[i][1] = "10";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h4_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H4_")) VSX.saveVoiceSet[i][1] = "11";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h5_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H5_")) VSX.saveVoiceSet[i][1] = "12";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h6_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H6_")) VSX.saveVoiceSet[i][1] = "13";
                        if (Regex.IsMatch(VSX.saveVoiceSet[i][0], "^h7_") || Regex.IsMatch(VSX.saveVoiceSet[i][0], "^H7_")) VSX.saveVoiceSet[i][1] = "14";
                    }
                }

                if (GUI.Button(new Rect(55, y, 55, 20), "クリア", gsButton))
                {
                    if (vs_Overwrite)
                    {
                        VSX.saveVoiceSet = new List<string[]>{
                    new string[] { "" , "0" , "0" , "3" , "0" , "3" , "0" , "0" }
                  };
                        VSX.saveVoiceSetName = "";
                        maidsState[tgID].editVoiceSetName = "";
                        maidsState[tgID].editVoiceSet = new List<string[]>();
                        vs_Overwrite = false;
                    }
                    else
                    {
                        vsErrer = 3;
                    }
                }
                //XMLファイルに保存する
                if (GUI.Button(new Rect(120, y, 55, 20), "保存", gsButton))
                {
                    voiceSetSave();
                    XmlFilesCheck();
                }

                y += 30;
                if (vsErrer != 0)
                {
                    if (GUI.Button(new Rect(5, y, 20, 20), "x", gsButton))
                    {
                        vsErrer = 0;
                    }
                    GUI.Label(new Rect(30, y, 170, 60), vsErrerText[vsErrer], gsLabel4);
                    y += 45;
                }
                else
                {


                    //フィルタ機能
                    GUI.Label(new Rect(5, y, 145, 20), "【フィルタリング機能】", gsLabel);

                    y += 20;
                    if (GUI.Button(new Rect(5, y, 70, 20), personalList[0][fVoiceSet[0]], gsButton))
                    {
                        ++fVoiceSet[0];
                        if (fVoiceSet[0] >= personalList[0].Length) fVoiceSet[0] = 0;
                    }

                    if (GUI.Button(new Rect(80, y, 55, 20), vsState[fVoiceSet[3]], gsButton))
                    {
                        ++fVoiceSet[3];
                        if (fVoiceSet[3] >= vsState.Length) fVoiceSet[3] = 0;
                    }

                    if (GUI.Button(new Rect(140, y, 55, 20), vsCondition[fVoiceSet[4]], gsButton))
                    {
                        ++fVoiceSet[4];
                        if (fVoiceSet[4] >= vsCondition.Length) fVoiceSet[4] = 0;
                    }


                    y += 25;
                    GUI.Label(new Rect(5, y, 30, 20), "興奮", gsLabel);
                    if (GUI.Button(new Rect(35, y, 20, 20), vsLevel[fVoiceSet[1]], gsButton))
                    {
                        ++fVoiceSet[1];
                        if (fVoiceSet[1] > 4) fVoiceSet[1] = 0;
                    }

                    GUI.Label(new Rect(65, y, 30, 20), "絶頂", gsLabel);
                    if (GUI.Button(new Rect(95, y, 20, 20), vsLevel[fVoiceSet[2]], gsButton))
                    {
                        ++fVoiceSet[2];
                        if (fVoiceSet[2] > 4) fVoiceSet[2] = 0;
                    }

                    if (GUI.Button(new Rect(125, y, 70, 20), "リセット", gsButton))
                    {
                        fVoiceSet = new int[] { 15, 4, 4, 4, 5 };
                    }
                }



                //ボイスセット一覧
                y += 35;
                GUI.Label(new Rect(5, y, 145, 20), "【ボイスセット読み込み】", gsLabel);

                y += 20;
                int h1 = evsFiles.Count * 22;
                if (h1 < 445 - y) h1 = 445 - y;
                Rect scrlRect1 = new Rect(5, y, 200, 445 - y);
                Rect contentRect1 = new Rect(0, 0, 175, h1);
                vsScrollPos1 = GUI.BeginScrollView(scrlRect1, vsScrollPos1, contentRect1, false, true);

                y = 0;
                foreach (string f in evsFiles)
                {
                    string FileName = f.Replace("evs_", "").Replace(".xml", "");
                    if (GUI.Button(new Rect(0, y, 175, 20), FileName, gsButton))
                    {
                        voiceSetLoad(f, tgID);
                    }
                    y += 22;
                }
                GUI.EndScrollView();


                //ボイスセット編集画面
                x = 205;
                y = 40;

                //性格選択メニュー
                for (int i = 0; i < personalList[0].Length; i++)
                {
                    if (GUI.Button(new Rect(x, y, 60, 20), personalList[0][i], gsButton))
                    {
                        fVoiceSet[0] = i;
                    }
                    x += 65;
                    if (x + 60 > 620)
                    {
                        x = 205;
                        y += 25;
                    }
                }

                x = 220;
                y += 35;
                int h2 = VSX.saveVoiceSet.Count * 65 + 30;
                if (h2 < 445 - y) h2 = 445 - y;

                Rect scrlRect2 = new Rect(x, y, 400, 445 - y);
                Rect contentRect2 = new Rect(0, 0, 380, h2);
                vsScrollPos2 = GUI.BeginScrollView(scrlRect2, vsScrollPos2, contentRect2, false, true);

                y = 0;
                int iv;
                for (int i = 0; i < VSX.saveVoiceSet.Count; i++)
                {

                    if ((fVoiceSet[0] == intCnv(VSX.saveVoiceSet[i][1]) || fVoiceSet[0] == personalList[0].Length - 1 || intCnv(VSX.saveVoiceSet[i][1]) == personalList[0].Length - 1)
                       && (intCnv(VSX.saveVoiceSet[i][2]) <= fVoiceSet[1] && fVoiceSet[1] <= intCnv(VSX.saveVoiceSet[i][3]) || fVoiceSet[1] == 4)
                       && (intCnv(VSX.saveVoiceSet[i][4]) <= fVoiceSet[2] && fVoiceSet[2] <= intCnv(VSX.saveVoiceSet[i][5]) || fVoiceSet[2] == 4)
                       && (fVoiceSet[3] == intCnv(VSX.saveVoiceSet[i][6]) || fVoiceSet[3] == 4 || intCnv(VSX.saveVoiceSet[i][6]) == 4)
                       && (fVoiceSet[4] == intCnv(VSX.saveVoiceSet[i][7]) || fVoiceSet[4] == 5 || intCnv(VSX.saveVoiceSet[i][7]) == 5))
                    {

                        GUI.Label(new Rect(0, 0 + y, 30, 20), "音声", gsLabel);
                        VSX.saveVoiceSet[i][0] = GUI.TextField(new Rect(30, 0 + y, 110, 20), VSX.saveVoiceSet[i][0]);


                        //性格選択
                        iv = intCnv(VSX.saveVoiceSet[i][1]);
                        GUI.Label(new Rect(150, y, 70, 20), personalList[0][iv], gsLabel);

                        //強度選択
                        iv = intCnv(VSX.saveVoiceSet[i][6]);
                        if (GUI.Button(new Rect(225, 0 + y, 70, 20), vsState[iv], gsButton))
                        {
                            ++iv;
                            if (iv >= vsState.Length) iv = 0;
                            VSX.saveVoiceSet[i][6] = iv.ToString();
                        }

                        //状態選択
                        iv = intCnv(VSX.saveVoiceSet[i][7]);
                        if (GUI.Button(new Rect(300, 0 + y, 70, 20), vsCondition[iv], gsButton))
                        {
                            ++iv;
                            if (iv >= vsCondition.Length) iv = 0;
                            VSX.saveVoiceSet[i][7] = iv.ToString();
                        }

                        //興奮度指定
                        GUI.Label(new Rect(0, 25 + y, 30, 20), "興奮", gsLabel);
                        iv = intCnv(VSX.saveVoiceSet[i][2]);
                        if (GUI.Button(new Rect(30, 25 + y, 20, 20), VSX.saveVoiceSet[i][2], gsButton))
                        {
                            ++iv;
                            if (iv >= 4) iv = 0;
                            VSX.saveVoiceSet[i][2] = iv.ToString();
                        }

                        GUI.Label(new Rect(55, 25 + y, 15, 20), "～", gsLabel);

                        iv = intCnv(VSX.saveVoiceSet[i][3]);
                        if (GUI.Button(new Rect(70, 25 + y, 20, 20), VSX.saveVoiceSet[i][3], gsButton))
                        {
                            ++iv;
                            if (iv >= 4) iv = 0;
                            VSX.saveVoiceSet[i][3] = iv.ToString();
                        }

                        if (intCnv(VSX.saveVoiceSet[i][2]) > intCnv(VSX.saveVoiceSet[i][3])) VSX.saveVoiceSet[i][3] = VSX.saveVoiceSet[i][2];

                        //絶頂度指定
                        GUI.Label(new Rect(100, 25 + y, 30, 20), "絶頂", gsLabel);
                        iv = intCnv(VSX.saveVoiceSet[i][4]);
                        if (GUI.Button(new Rect(130, 25 + y, 20, 20), VSX.saveVoiceSet[i][4], gsButton))
                        {
                            ++iv;
                            if (iv >= 4) iv = 0;
                            VSX.saveVoiceSet[i][4] = iv.ToString();
                        }

                        GUI.Label(new Rect(155, 25 + y, 15, 20), "～", gsLabel);

                        iv = intCnv(VSX.saveVoiceSet[i][5]);
                        if (GUI.Button(new Rect(170, 25 + y, 20, 20), VSX.saveVoiceSet[i][5], gsButton))
                        {
                            ++iv;
                            if (iv >= 4) iv = 0;
                            VSX.saveVoiceSet[i][5] = iv.ToString();
                        }

                        if (intCnv(VSX.saveVoiceSet[i][4]) > intCnv(VSX.saveVoiceSet[i][5])) VSX.saveVoiceSet[i][5] = VSX.saveVoiceSet[i][4];


                        if (GUI.Button(new Rect(220, 25 + y, 80, 20), "テスト再生", gsButton))
                        {
                            if (!Regex.IsMatch(VSX.saveVoiceSet[i][0], @"\.[a-zA-Z][a-zA-Z]")) VSX.saveVoiceSet[i][0] = VSX.saveVoiceSet[i][0] + ".ogg";
                            stockMaids[tgID].mem.AudioMan.LoadPlay(VSX.saveVoiceSet[i][0], 0f, false, false);
                        }

                        if (GUI.Button(new Rect(310, 25 + y, 60, 20), "削除", gsButton))
                        {
                            VSX.saveVoiceSet.RemoveAt(i);
                        }

                        GUI.Label(new Rect(5, 45 + y, 370, 20), "―――――――――――――――――――――――――――――", gsLabel2);

                        y += 65;
                    }

                }

                if (GUI.Button(new Rect(315, 0 + y, 60, 20), "追加", gsButton))
                {
                    string[] set = new string[] { "", fVoiceSet[0].ToString(), "0", "3", "0", "3", fVoiceSet[3].ToString(), fVoiceSet[4].ToString() };
                    VSX.saveVoiceSet.Add(set);
                }

                GUI.EndScrollView();
            }



            if (ConfigFlag == 4)
            {
                x = 0;
                y = 0;
                scKeyOff = GUI.Toggle(new Rect(420, 5, 140, 20), scKeyOff, "ショートカット無効", gsToggle);

                //モーションセット編集画面
                x = 5;
                y = 40;
                GUI.Label(new Rect(5, y, 120, 20), "モーションセット名", gsLabel);
                ms_Overwrite = GUI.Toggle(new Rect(125, y, 70, 20), ms_Overwrite, "上書／ｸﾘｱ", gsToggle);

                y += 20;
                MSX.saveMotionSetName = GUI.TextField(new Rect(5, y, 170, 20), MSX.saveMotionSetName);

                y += 25;
                if (GUI.Button(new Rect(55, y, 55, 20), "クリア", gsButton))
                {
                    if (ms_Overwrite)
                    {
                        MSX.saveMotionSet = new List<List<string>>();
                        MSX.saveMotionSetName = "";
                        ms_Overwrite = false;
                        msCategory = 0;
                    }
                    else
                    {
                        msErrer = 3;
                    }
                }
                //XMLファイルに保存する
                if (GUI.Button(new Rect(120, y, 55, 20), "保存", gsButton))
                {
                    MotionSetSave();
                    XmlFilesCheck();
                }

                y += 30;
                if (msErrer != 0)
                {
                    if (GUI.Button(new Rect(5, y, 20, 20), "x", gsButton))
                    {
                        msErrer = 0;
                    }
                    GUI.Label(new Rect(30, y, 170, 60), msErrerText[msErrer], gsLabel4);
                }
                y += 45;


                //モーションセット一覧
                y += 35;
                GUI.Label(new Rect(5, y, 200, 20), "【モーションセット読み込み】", gsLabel);

                y += 20;
                int h1 = emsFiles.Count * 22;
                if (h1 < 445 - y) h1 = 445 - y;
                Rect scrlRect1 = new Rect(5, y, 200, 445 - y);
                Rect contentRect1 = new Rect(0, 0, 175, h1);
                vsScrollPos1 = GUI.BeginScrollView(scrlRect1, vsScrollPos1, contentRect1, false, true);

                y = 0;
                foreach (string f in emsFiles)
                {
                    string FileName = f.Replace("ems_", "").Replace(".xml", "");
                    if (GUI.Button(new Rect(0, y, 175, 20), FileName, gsButton))
                    {
                        MotionSetLoad(f);
                    }
                    y += 22;
                }
                GUI.EndScrollView();


                //ボイスセット編集画面
                x = 210;
                y = 50;

                //カテゴリ切り替え
                GUI.Label(new Rect(x, y, 120, 20), "【カテゴリ " + msCategory + " 】", gsLabel);
                if (MSX.saveMotionSet.Count == 0)
                {
                    List<string> nm = new List<string>() { "" };
                    MSX.saveMotionSet.Add(nm);
                }
                if (GUI.Button(new Rect(x + 125, y, 100, 20), "カテゴリ追加", gsButton))
                {
                    List<string> nm = new List<string>() { "" }; ;
                    MSX.saveMotionSet.Add(nm);
                    msCategory = MSX.saveMotionSet.Count - 1;
                }
                if (MSX.saveMotionSet.Count > 1)
                {
                    if (GUI.Button(new Rect(x + 235, y, 100, 20), "カテゴリ削除", gsButton))
                    {
                        MSX.saveMotionSet.RemoveAt(msCategory);
                        if (msCategory >= MSX.saveMotionSet.Count) msCategory = MSX.saveMotionSet.Count - 1;
                    }
                }

                x = 220;
                y += 30;

                for (int i = 0; i < MSX.saveMotionSet.Count; i++)
                {
                    if (GUI.Button(new Rect(x, y, 30, 20), i.ToString(), gsButton))
                    {
                        msCategory = i;
                    }
                    x += 35;
                    if (x + 30 > 620)
                    {
                        x = 220;
                        y += 25;
                    }
                }


                x = 220;
                y += 40;
                int h2 = MSX.saveMotionSet[msCategory].Count * 65 + 30;
                if (h2 < 445 - y) h2 = 445 - y;

                Rect scrlRect2 = new Rect(x, y, 400, 445 - y);
                Rect contentRect2 = new Rect(0, 0, 380, h2);
                vsScrollPos2 = GUI.BeginScrollView(scrlRect2, vsScrollPos2, contentRect2, false, true);

                y = 0;
                for (int i = 0; i < MSX.saveMotionSet[msCategory].Count; i++)
                {

                    GUI.Label(new Rect(0, 0 + y, 70, 20), "モーション", gsLabel);
                    MSX.saveMotionSet[msCategory][i] = GUI.TextField(new Rect(70, 0 + y, 300, 20), MSX.saveMotionSet[msCategory][i]);

                    GUI.Label(new Rect(10, 25 + y, 200, 20), MotionNameChange(MSX.saveMotionSet[msCategory][i]), gsLabel);

                    if (GUI.Button(new Rect(215, 25 + y, 50, 20), "取得", gsButton))
                    {
                        string motion = stockMaids[tgID].mem.body0.LastAnimeFN;
                        motion = regZeccyouBackup.Match(motion).Groups[1].Value;  // 「 - Que…」を除く
                        motion = Regex.Replace(motion, "_[23](?!ana)(?!p_)(?!vibe)", "_1");
                        motion = Regex.Replace(motion, @"[a-zA-Z][0-9][0-9]", "");
                        MSX.saveMotionSet[msCategory][i] = motion;
                    }
                    if (GUI.Button(new Rect(270, 25 + y, 50, 20), "再生", gsButton))
                    {
                        MotionChange(maid, MSX.saveMotionSet[msCategory][i], true, 0.7f, 1f);
                        ManMotionChange(tgID, true, 0.7f, 1f);
                    }
                    if (GUI.Button(new Rect(325, 25 + y, 50, 20), "削除", gsButton))
                    {
                        MSX.saveMotionSet[msCategory].RemoveAt(i);
                    }
                    GUI.Label(new Rect(5, 45 + y, 370, 20), "―――――――――――――――――――――――――――――", gsLabel2);

                    y += 65;
                }

                if (GUI.Button(new Rect(315, 0 + y, 60, 20), "追加", gsButton))
                {
                    MSX.saveMotionSet[msCategory].Add("");
                }

                GUI.EndScrollView();
            }

            if (ConfigFlag == 5)
            {

                scKeyOff = GUI.Toggle(new Rect(420, 5, 140, 20), scKeyOff, "ショートカット無効", gsToggle);

                GUI.Label(new Rect(5, 35, 190, 20), "【髪型】", gsLabel);
                GUI.Label(new Rect(5, 55, 190, 20), "前髪：" + maid.GetProp(MPN.hairf).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);
                GUI.Label(new Rect(5, 75, 190, 20), "後髪：" + maid.GetProp(MPN.hairr).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);
                GUI.Label(new Rect(5, 115, 190, 20), "横髪：" + maid.GetProp(MPN.hairs).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);
                GUI.Label(new Rect(5, 95, 190, 20), "ｴｸｽﾃ髪：" + maid.GetProp(MPN.hairt).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);
                GUI.Label(new Rect(5, 135, 190, 20), "アホ毛：" + maid.GetProp(MPN.hairaho).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);
                GUI.Label(new Rect(5, 155, 190, 20), "リボン：" + maid.GetProp(MPN.acckamisub).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);
                GUI.Label(new Rect(5, 175, 190, 20), "髪ｱｸｾ：" + maid.GetProp(MPN.acckami).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsLabel);

                GUI.Label(new Rect(5, 205, 190, 20), "【服装】", gsLabel);
                setAcchat = GUI.Toggle(new Rect(5, 225, 190, 20), setAcchat, "帽子：" + maid.GetProp(MPN.acchat).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setHeadset = GUI.Toggle(new Rect(5, 245, 190, 20), setHeadset, "ﾍｯﾄﾞﾄﾞﾚｽ：" + maid.GetProp(MPN.headset).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setWear = GUI.Toggle(new Rect(5, 265, 190, 20), setWear, "ﾄｯﾌﾟｽ：" + maid.GetProp(MPN.wear).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setSkirt = GUI.Toggle(new Rect(5, 285, 190, 20), setSkirt, "ﾎﾞﾄﾑｽ：" + maid.GetProp(MPN.skirt).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setOnepiece = GUI.Toggle(new Rect(5, 305, 190, 20), setOnepiece, "ﾜﾝﾋﾟｰｽ：" + maid.GetProp(MPN.onepiece).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setMizugi = GUI.Toggle(new Rect(5, 325, 190, 20), setMizugi, "水着：" + maid.GetProp(MPN.mizugi).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setBra = GUI.Toggle(new Rect(5, 345, 190, 20), setBra, "ﾌﾞﾗｼﾞｬｰ：" + maid.GetProp(MPN.bra).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setPanz = GUI.Toggle(new Rect(5, 365, 190, 20), setPanz, "パンツ：" + maid.GetProp(MPN.panz).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setStkg = GUI.Toggle(new Rect(5, 385, 190, 20), setStkg, "靴下：" + maid.GetProp(MPN.stkg).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setShoes = GUI.Toggle(new Rect(5, 405, 190, 20), setShoes, "靴：" + maid.GetProp(MPN.shoes).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);

                GUI.Label(new Rect(205, 35, 190, 20), "【アクセサリーその他】", gsLabel);
                setMegane = GUI.Toggle(new Rect(205, 55, 190, 20), setMegane, "メガネ：" + maid.GetProp(MPN.megane).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAcchead = GUI.Toggle(new Rect(205, 75, 190, 20), setAcchead, "ｱｲﾏｽｸ：" + maid.GetProp(MPN.acchead).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setGlove = GUI.Toggle(new Rect(205, 95, 190, 20), setGlove, "手袋：" + maid.GetProp(MPN.glove).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccude = GUI.Toggle(new Rect(205, 115, 190, 20), setAccude, "腕：" + maid.GetProp(MPN.accude).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAcchana = GUI.Toggle(new Rect(205, 135, 190, 20), setAcchana, "鼻：" + maid.GetProp(MPN.acchana).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccmimi = GUI.Toggle(new Rect(205, 155, 190, 20), setAccmimi, "耳：" + maid.GetProp(MPN.accmimi).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccnip = GUI.Toggle(new Rect(205, 175, 190, 20), setAccnip, "乳首：" + maid.GetProp(MPN.accnip).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAcckubi = GUI.Toggle(new Rect(205, 195, 190, 20), setAcckubi, "ﾈｯｸﾚｽ：" + maid.GetProp(MPN.acckubi).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAcckubiwa = GUI.Toggle(new Rect(205, 215, 190, 20), setAcckubiwa, "ﾁｮｰｶｰ：" + maid.GetProp(MPN.acckubiwa).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccheso = GUI.Toggle(new Rect(205, 235, 190, 20), setAccheso, "へそ：" + maid.GetProp(MPN.accheso).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccashi = GUI.Toggle(new Rect(205, 255, 190, 20), setAccashi, "足首：" + maid.GetProp(MPN.accashi).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccsenaka = GUI.Toggle(new Rect(205, 275, 190, 20), setAccsenaka, "背中：" + maid.GetProp(MPN.accsenaka).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccshippo = GUI.Toggle(new Rect(205, 295, 190, 20), setAccshippo, "しっぽ：" + maid.GetProp(MPN.accshippo).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);
                setAccxxx = GUI.Toggle(new Rect(205, 315, 190, 20), setAccxxx, "前穴：" + maid.GetProp(MPN.accxxx).strFileName.Replace("_i_", "").Replace("_I_", "").Replace("del.menu", "無し").Replace(".menu", ""), gsToggle);

                GUI.Label(new Rect(205, 350, 190, 20), maid.GetProp(MPN.skirt).strTempFileName, gsLabel);


                GUI.Label(new Rect(405, 35, 190, 20), "【現在の髪型を登録（個別）】", gsLabel);
                if (GUI.Button(new Rect(410, 60, 85, 20), "髪型１", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairF") && !hs_Overwrite[0])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairF", maid.GetProp(MPN.hairf).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairR", maid.GetProp(MPN.hairr).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairS", maid.GetProp(MPN.hairs).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairT", maid.GetProp(MPN.hairt).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairAho", maid.GetProp(MPN.hairaho).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accKami", maid.GetProp(MPN.acckami).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accKamiSub", maid.GetProp(MPN.acckamisub).strFileName, true);
                        Console.WriteLine("髪型１ 登録完了");
                        hs_Overwrite[0] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "1_hairF")) hs_Overwrite[0] = GUI.Toggle(new Rect(505, 60, 70, 20), hs_Overwrite[0], "上書", gsToggle);

                if (GUI.Button(new Rect(410, 85, 85, 20), "髪型２", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairF") && !hs_Overwrite[1])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairF", maid.GetProp(MPN.hairf).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairR", maid.GetProp(MPN.hairr).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairS", maid.GetProp(MPN.hairs).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairT", maid.GetProp(MPN.hairt).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairAho", maid.GetProp(MPN.hairaho).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accKami", maid.GetProp(MPN.acckami).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accKamiSub", maid.GetProp(MPN.acckamisub).strFileName, true);
                        Console.WriteLine("髪型２ 登録完了");
                        hs_Overwrite[1] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "2_hairF")) hs_Overwrite[1] = GUI.Toggle(new Rect(505, 85, 70, 20), hs_Overwrite[1], "上書", gsToggle);

                if (GUI.Button(new Rect(410, 110, 85, 20), "髪型３", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairF") && !hs_Overwrite[2])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairF", maid.GetProp(MPN.hairf).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairR", maid.GetProp(MPN.hairr).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairS", maid.GetProp(MPN.hairs).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairT", maid.GetProp(MPN.hairt).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairAho", maid.GetProp(MPN.hairaho).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accKami", maid.GetProp(MPN.acckami).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accKamiSub", maid.GetProp(MPN.acckamisub).strFileName, true);
                        Console.WriteLine("髪型３ 登録完了");
                        hs_Overwrite[2] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "3_hairF")) hs_Overwrite[2] = GUI.Toggle(new Rect(505, 110, 70, 20), hs_Overwrite[2], "上書", gsToggle);

                if (GUI.Button(new Rect(410, 135, 85, 20), "髪型４", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairF") && !hs_Overwrite[3])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairF", maid.GetProp(MPN.hairf).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairR", maid.GetProp(MPN.hairr).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairS", maid.GetProp(MPN.hairs).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairT", maid.GetProp(MPN.hairt).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairAho", maid.GetProp(MPN.hairaho).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accKami", maid.GetProp(MPN.acckami).strFileName, true);
                        ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accKamiSub", maid.GetProp(MPN.acckamisub).strFileName, true);
                        Console.WriteLine("髪型４ 登録完了");
                        hs_Overwrite[3] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "4_hairF")) hs_Overwrite[3] = GUI.Toggle(new Rect(505, 135, 70, 20), hs_Overwrite[3], "上書", gsToggle);


                GUI.Label(new Rect(405, 165, 190, 20), "【現在の衣装を登録（個別）】", gsLabel);
                if (GUI.Button(new Rect(410, 190, 85, 20), "衣装１", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat") && !ds_Overwrite[0])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        if (setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat", maid.GetProp(MPN.acchat).strFileName, true);
                        if (setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_headset", maid.GetProp(MPN.headset).strFileName, true);
                        if (setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_wear", maid.GetProp(MPN.wear).strFileName, true);
                        if (setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_skirt", maid.GetProp(MPN.skirt).strFileName, true);
                        if (setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_onepiece", maid.GetProp(MPN.onepiece).strFileName, true);
                        if (setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_mizugi", maid.GetProp(MPN.mizugi).strFileName, true);
                        if (setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_bra", maid.GetProp(MPN.bra).strFileName, true);
                        if (setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_panz", maid.GetProp(MPN.panz).strFileName, true);
                        if (setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_stkg", maid.GetProp(MPN.stkg).strFileName, true);
                        if (setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_shoes", maid.GetProp(MPN.shoes).strFileName, true);
                        if (setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_megane", maid.GetProp(MPN.megane).strFileName, true);
                        if (setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchead", maid.GetProp(MPN.acchead).strFileName, true);
                        if (setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_glove", maid.GetProp(MPN.glove).strFileName, true);
                        if (setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accude", maid.GetProp(MPN.accude).strFileName, true);
                        if (setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchana", maid.GetProp(MPN.acchana).strFileName, true);
                        if (setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accmimi", maid.GetProp(MPN.accmimi).strFileName, true);
                        if (setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accnip", maid.GetProp(MPN.accnip).strFileName, true);
                        if (setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubi", maid.GetProp(MPN.acckubi).strFileName, true);
                        if (setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubiwa", maid.GetProp(MPN.acckubiwa).strFileName, true);
                        if (setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accheso", maid.GetProp(MPN.accheso).strFileName, true);
                        if (setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accashi", maid.GetProp(MPN.accashi).strFileName, true);
                        if (setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accsenaka", maid.GetProp(MPN.accsenaka).strFileName, true);
                        if (setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accshippo", maid.GetProp(MPN.accshippo).strFileName, true);
                        if (setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accxxx", maid.GetProp(MPN.accxxx).strFileName, true);

                        if (!setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat", "", true);
                        if (!setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_headset", "", true);
                        if (!setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_wear", "", true);
                        if (!setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_skirt", "", true);
                        if (!setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_onepiece", "", true);
                        if (!setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_mizugi", "", true);
                        if (!setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_bra", "", true);
                        if (!setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_panz", "", true);
                        if (!setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_stkg", "", true);
                        if (!setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_shoes", "", true);
                        if (!setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_megane", "", true);
                        if (!setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchead", "", true);
                        if (!setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_glove", "", true);
                        if (!setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accude", "", true);
                        if (!setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchana", "", true);
                        if (!setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accmimi", "", true);
                        if (!setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accnip", "", true);
                        if (!setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubi", "", true);
                        if (!setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_acckubiwa", "", true);
                        if (!setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accheso", "", true);
                        if (!setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accashi", "", true);
                        if (!setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accsenaka", "", true);
                        if (!setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accshippo", "", true);
                        if (!setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "1_accxxx", "", true);
                        Console.WriteLine("衣装１ 登録完了");
                        ds_Overwrite[0] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "1_acchat")) ds_Overwrite[0] = GUI.Toggle(new Rect(505, 190, 70, 20), ds_Overwrite[0], "上書", gsToggle);

                if (GUI.Button(new Rect(410, 215, 85, 20), "衣装２", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat") && !ds_Overwrite[1])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        if (setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat", maid.GetProp(MPN.acchat).strFileName, true);
                        if (setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_headset", maid.GetProp(MPN.headset).strFileName, true);
                        if (setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_wear", maid.GetProp(MPN.wear).strFileName, true);
                        if (setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_skirt", maid.GetProp(MPN.skirt).strFileName, true);
                        if (setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_onepiece", maid.GetProp(MPN.onepiece).strFileName, true);
                        if (setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_mizugi", maid.GetProp(MPN.mizugi).strFileName, true);
                        if (setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_bra", maid.GetProp(MPN.bra).strFileName, true);
                        if (setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_panz", maid.GetProp(MPN.panz).strFileName, true);
                        if (setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_stkg", maid.GetProp(MPN.stkg).strFileName, true);
                        if (setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_shoes", maid.GetProp(MPN.shoes).strFileName, true);
                        if (setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_megane", maid.GetProp(MPN.megane).strFileName, true);
                        if (setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchead", maid.GetProp(MPN.acchead).strFileName, true);
                        if (setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_glove", maid.GetProp(MPN.glove).strFileName, true);
                        if (setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accude", maid.GetProp(MPN.accude).strFileName, true);
                        if (setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchana", maid.GetProp(MPN.acchana).strFileName, true);
                        if (setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accmimi", maid.GetProp(MPN.accmimi).strFileName, true);
                        if (setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accnip", maid.GetProp(MPN.accnip).strFileName, true);
                        if (setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubi", maid.GetProp(MPN.acckubi).strFileName, true);
                        if (setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubiwa", maid.GetProp(MPN.acckubiwa).strFileName, true);
                        if (setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accheso", maid.GetProp(MPN.accheso).strFileName, true);
                        if (setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accashi", maid.GetProp(MPN.accashi).strFileName, true);
                        if (setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accsenaka", maid.GetProp(MPN.accsenaka).strFileName, true);
                        if (setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accshippo", maid.GetProp(MPN.accshippo).strFileName, true);
                        if (setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accxxx", maid.GetProp(MPN.accxxx).strFileName, true);

                        if (!setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat", "", true);
                        if (!setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_headset", "", true);
                        if (!setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_wear", "", true);
                        if (!setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_skirt", "", true);
                        if (!setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_onepiece", "", true);
                        if (!setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_mizugi", "", true);
                        if (!setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_bra", "", true);
                        if (!setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_panz", "", true);
                        if (!setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_stkg", "", true);
                        if (!setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_shoes", "", true);
                        if (!setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_megane", "", true);
                        if (!setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchead", "", true);
                        if (!setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_glove", "", true);
                        if (!setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accude", "", true);
                        if (!setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchana", "", true);
                        if (!setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accmimi", "", true);
                        if (!setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accnip", "", true);
                        if (!setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubi", "", true);
                        if (!setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_acckubiwa", "", true);
                        if (!setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accheso", "", true);
                        if (!setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accashi", "", true);
                        if (!setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accsenaka", "", true);
                        if (!setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accshippo", "", true);
                        if (!setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "2_accxxx", "", true);
                        Console.WriteLine("衣装２ 登録完了");
                        ds_Overwrite[1] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "2_acchat")) ds_Overwrite[1] = GUI.Toggle(new Rect(505, 215, 70, 20), ds_Overwrite[1], "上書", gsToggle);

                if (GUI.Button(new Rect(410, 240, 85, 20), "衣装３", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat") && !ds_Overwrite[2])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        if (setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat", maid.GetProp(MPN.acchat).strFileName, true);
                        if (setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_headset", maid.GetProp(MPN.headset).strFileName, true);
                        if (setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_wear", maid.GetProp(MPN.wear).strFileName, true);
                        if (setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_skirt", maid.GetProp(MPN.skirt).strFileName, true);
                        if (setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_onepiece", maid.GetProp(MPN.onepiece).strFileName, true);
                        if (setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_mizugi", maid.GetProp(MPN.mizugi).strFileName, true);
                        if (setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_bra", maid.GetProp(MPN.bra).strFileName, true);
                        if (setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_panz", maid.GetProp(MPN.panz).strFileName, true);
                        if (setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_stkg", maid.GetProp(MPN.stkg).strFileName, true);
                        if (setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_shoes", maid.GetProp(MPN.shoes).strFileName, true);
                        if (setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_megane", maid.GetProp(MPN.megane).strFileName, true);
                        if (setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchead", maid.GetProp(MPN.acchead).strFileName, true);
                        if (setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_glove", maid.GetProp(MPN.glove).strFileName, true);
                        if (setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accude", maid.GetProp(MPN.accude).strFileName, true);
                        if (setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchana", maid.GetProp(MPN.acchana).strFileName, true);
                        if (setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accmimi", maid.GetProp(MPN.accmimi).strFileName, true);
                        if (setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accnip", maid.GetProp(MPN.accnip).strFileName, true);
                        if (setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubi", maid.GetProp(MPN.acckubi).strFileName, true);
                        if (setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubiwa", maid.GetProp(MPN.acckubiwa).strFileName, true);
                        if (setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accheso", maid.GetProp(MPN.accheso).strFileName, true);
                        if (setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accashi", maid.GetProp(MPN.accashi).strFileName, true);
                        if (setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accsenaka", maid.GetProp(MPN.accsenaka).strFileName, true);
                        if (setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accshippo", maid.GetProp(MPN.accshippo).strFileName, true);
                        if (setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accxxx", maid.GetProp(MPN.accxxx).strFileName, true);

                        if (!setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat", "", true);
                        if (!setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_headset", "", true);
                        if (!setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_wear", "", true);
                        if (!setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_skirt", "", true);
                        if (!setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_onepiece", "", true);
                        if (!setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_mizugi", "", true);
                        if (!setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_bra", "", true);
                        if (!setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_panz", "", true);
                        if (!setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_stkg", "", true);
                        if (!setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_shoes", "", true);
                        if (!setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_megane", "", true);
                        if (!setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchead", "", true);
                        if (!setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_glove", "", true);
                        if (!setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accude", "", true);
                        if (!setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchana", "", true);
                        if (!setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accmimi", "", true);
                        if (!setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accnip", "", true);
                        if (!setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubi", "", true);
                        if (!setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_acckubiwa", "", true);
                        if (!setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accheso", "", true);
                        if (!setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accashi", "", true);
                        if (!setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accsenaka", "", true);
                        if (!setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accshippo", "", true);
                        if (!setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "3_accxxx", "", true);
                        Console.WriteLine("衣装３ 登録完了");
                        ds_Overwrite[2] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "3_acchat")) ds_Overwrite[2] = GUI.Toggle(new Rect(505, 240, 70, 20), ds_Overwrite[2], "上書", gsToggle);

                if (GUI.Button(new Rect(410, 265, 85, 20), "衣装４", gsButton))
                {
                    if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat") && !ds_Overwrite[3])
                    {
                        dsErrer = 2;
                    }
                    else
                    {
                        if (setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat", maid.GetProp(MPN.acchat).strFileName, true);
                        if (setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_headset", maid.GetProp(MPN.headset).strFileName, true);
                        if (setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_wear", maid.GetProp(MPN.wear).strFileName, true);
                        if (setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_skirt", maid.GetProp(MPN.skirt).strFileName, true);
                        if (setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_onepiece", maid.GetProp(MPN.onepiece).strFileName, true);
                        if (setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_mizugi", maid.GetProp(MPN.mizugi).strFileName, true);
                        if (setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_bra", maid.GetProp(MPN.bra).strFileName, true);
                        if (setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_panz", maid.GetProp(MPN.panz).strFileName, true);
                        if (setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_stkg", maid.GetProp(MPN.stkg).strFileName, true);
                        if (setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_shoes", maid.GetProp(MPN.shoes).strFileName, true);
                        if (setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_megane", maid.GetProp(MPN.megane).strFileName, true);
                        if (setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchead", maid.GetProp(MPN.acchead).strFileName, true);
                        if (setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_glove", maid.GetProp(MPN.glove).strFileName, true);
                        if (setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accude", maid.GetProp(MPN.accude).strFileName, true);
                        if (setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchana", maid.GetProp(MPN.acchana).strFileName, true);
                        if (setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accmimi", maid.GetProp(MPN.accmimi).strFileName, true);
                        if (setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accnip", maid.GetProp(MPN.accnip).strFileName, true);
                        if (setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubi", maid.GetProp(MPN.acckubi).strFileName, true);
                        if (setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubiwa", maid.GetProp(MPN.acckubiwa).strFileName, true);
                        if (setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accheso", maid.GetProp(MPN.accheso).strFileName, true);
                        if (setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accashi", maid.GetProp(MPN.accashi).strFileName, true);
                        if (setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accsenaka", maid.GetProp(MPN.accsenaka).strFileName, true);
                        if (setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accshippo", maid.GetProp(MPN.accshippo).strFileName, true);
                        if (setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accxxx", maid.GetProp(MPN.accxxx).strFileName, true);

                        if (!setAcchat) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat", "", true);
                        if (!setHeadset) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_headset", "", true);
                        if (!setWear) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_wear", "", true);
                        if (!setSkirt) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_skirt", "", true);
                        if (!setOnepiece) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_onepiece", "", true);
                        if (!setMizugi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_mizugi", "", true);
                        if (!setBra) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_bra", "", true);
                        if (!setPanz) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_panz", "", true);
                        if (!setStkg) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_stkg", "", true);
                        if (!setShoes) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_shoes", "", true);
                        if (!setMegane) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_megane", "", true);
                        if (!setAcchead) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchead", "", true);
                        if (!setGlove) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_glove", "", true);
                        if (!setAccude) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accude", "", true);
                        if (!setAcchana) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchana", "", true);
                        if (!setAccmimi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accmimi", "", true);
                        if (!setAccnip) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accnip", "", true);
                        if (!setAcckubi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubi", "", true);
                        if (!setAcckubiwa) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_acckubiwa", "", true);
                        if (!setAccheso) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accheso", "", true);
                        if (!setAccashi) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accashi", "", true);
                        if (!setAccsenaka) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accsenaka", "", true);
                        if (!setAccshippo) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accshippo", "", true);
                        if (!setAccxxx) ExSaveData.Set(maid, "CM3D2.VibeYourMaid.Plugin", "4_accxxx", "", true);
                        Console.WriteLine("衣装４ 登録完了");
                        ds_Overwrite[3] = false;
                        dsErrer = 0;
                    }
                }
                if (ExSaveData.Contains(maid, "CM3D2.VibeYourMaid.Plugin", "4_acchat")) ds_Overwrite[3] = GUI.Toggle(new Rect(505, 265, 70, 20), ds_Overwrite[3], "上書", gsToggle);

                GUI.Label(new Rect(405, 295, 190, 20), "【現在の衣装を登録（共通）】", gsLabel);
                GUI.Label(new Rect(405, 320, 90, 20), "衣装セット名", gsLabel);
                ds_Overwrite[4] = GUI.Toggle(new Rect(530, 320, 70, 20), ds_Overwrite[4], "上書", gsToggle);

                cbsName = GUI.TextField(new Rect(405, 345, 170, 20), cbsName);

                //XMLファイルに保存する
                if (GUI.Button(new Rect(520, 370, 55, 20), "保存", gsButton))
                {
                    CdsFileSave(cbsName);
                    XmlFilesCheck();
                    ds_Overwrite[4] = false;
                }

                if (dsErrer != 0)
                {
                    if (GUI.Button(new Rect(405, 400, 20, 20), "x", gsButton))
                    {
                        dsErrer = 0;
                    }
                    GUI.Label(new Rect(430, 400, 170, 40), dsErrerText[dsErrer], gsLabel4);
                }
            }


            if (ConfigFlag == 6)
            {
                scKeyOff = GUI.Toggle(new Rect(420, 5, 140, 20), scKeyOff, "ショートカット無効", gsToggle);


                Rect scrlRect2 = new Rect(0, 35, 620, 210);
                Rect contentRect2 = new Rect(0, 0, 600, 390);
                vsScrollPos2 = GUI.BeginScrollView(scrlRect2, vsScrollPos2, contentRect2, false, true);


                GUI.Label(new Rect(5, 0, 190, 20), "【モーションアジャスト】", gsLabel);

                if (maidsState[tgID].motionID >= 0)
                {

                    GUI.Label(new Rect(10, 25, 190, 20), "基本の高さ:" + maj.basicHeight[maidsState[tgID].motionID], gsLabel);
                    GUI.Label(new Rect(10, 45, 190, 20), "男の高さ差異:" + maj.mansHeight[maidsState[tgID].motionID], gsLabel);
                    GUI.Label(new Rect(10, 65, 90, 20), "kupa（動）:" + maj.hkupa1[maidsState[tgID].motionID], gsLabel);
                    GUI.Label(new Rect(110, 65, 90, 20), "anal（動）:" + maj.akupa1[maidsState[tgID].motionID], gsLabel);
                    GUI.Label(new Rect(10, 85, 90, 20), "kupa（停）:" + maj.hkupa2[maidsState[tgID].motionID], gsLabel);
                    GUI.Label(new Rect(110, 85, 90, 20), "anal（停）:" + maj.akupa2[maidsState[tgID].motionID], gsLabel);

                    GUI.Label(new Rect(10, 105, 90, 20), "ボイスセット:", gsLabel);
                    maj.mVoiceSet[maidsState[tgID].motionID] = GUI.TextField(new Rect(95, 135, 100, 20), maj.mVoiceSet[maidsState[tgID].motionID]);

                    if (GUI.Button(new Rect(10, 135, 80, 20), "現在値取得", gsButton))
                    {
                        vm = maid.transform.position;
                        em = maid.transform.eulerAngles;
                        int sintyou = maid.GetProp(MPN.sintyou).value;

                        //基本の高さ取得
                        maj.basicHeight[maidsState[tgID].motionID] = vm.y / maid.status.body.height;

                        //男の高さ差異取得
                        if (SubMans[0].Visible)
                        {
                            vm2 = SubMans[0].transform.position;
                            maj.mansHeight[maidsState[tgID].motionID] = (vm.y - vm2.y) / (sintyou - 50);
                        }

                        //kupa値取得
                        maj.hkupa1[maidsState[tgID].motionID] = (float)Math.Floor(maidsState[tgID].hibuSlider1Value);
                        maj.akupa1[maidsState[tgID].motionID] = (float)Math.Floor(maidsState[tgID].analSlider1Value);
                        maj.hkupa2[maidsState[tgID].motionID] = (float)Math.Floor(maidsState[tgID].hibuSlider2Value);
                        maj.akupa2[maidsState[tgID].motionID] = (float)Math.Floor(maidsState[tgID].analSlider2Value);

                        //ボイスセット取得
                        maj.mVoiceSet[maidsState[tgID].motionID] = maidsState[tgID].editVoiceSetName;
                    }


                    if (GUI.Button(new Rect(10, 160, 80, 20), "向き反転", gsButton))
                    {
                        if (maj.basicRoll[maidsState[tgID].motionID] == 0)
                        {
                            maj.basicRoll[maidsState[tgID].motionID] = 180;
                        }
                        else
                        {
                            maj.basicRoll[maidsState[tgID].motionID] = 0;
                        }
                    }
                    if (maj.basicRoll[maidsState[tgID].motionID] != 0) GUI.Label(new Rect(100, 160, 90, 20), "ON", gsLabel);
                    if (maj.basicRoll[maidsState[tgID].motionID] == 0) GUI.Label(new Rect(100, 160, 90, 20), "OFF", gsLabel);


                    if (GUI.Button(new Rect(10, 185, 50, 20), "BaceM", gsButton))
                    {
                        maj.baceMotion[maidsState[tgID].motionID] = maj.motionName[maidsState[tgID].motionID];
                    }
                    maj.baceMotion[maidsState[tgID].motionID] = GUI.TextField(new Rect(65, 185, 130, 20), maj.baceMotion[maidsState[tgID].motionID]);


                    GUI.Label(new Rect(10, 220, 110, 20), "基本の前後：" + Math.Floor(maj.basicForward[maidsState[tgID].motionID] * 100000), gsLabel);
                    maj.basicForward[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(125, 225, 150, 20), maj.basicForward[maidsState[tgID].motionID], -0.005F, 0.005F);

                    GUI.Label(new Rect(10, 240, 110, 20), "相手の高さ：" + Math.Floor(maj.mansHeight[maidsState[tgID].motionID] * 100000), gsLabel);
                    maj.mansHeight[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(125, 245, 150, 20), maj.mansHeight[maidsState[tgID].motionID], -0.002F, 0.002F);

                    GUI.Label(new Rect(10, 260, 110, 20), "相手の前後：" + Math.Floor(maj.mansForward[maidsState[tgID].motionID] * 100000), gsLabel);
                    maj.mansForward[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(125, 265, 150, 20), maj.mansForward[maidsState[tgID].motionID], -0.002F, 0.002F);

                    GUI.Label(new Rect(10, 280, 110, 20), "相手の左右：" + Math.Floor(maj.mansRight[maidsState[tgID].motionID] * 100000), gsLabel);
                    maj.mansRight[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(125, 285, 150, 20), maj.mansRight[maidsState[tgID].motionID], -0.002F, 0.002F);



                    if (maidsState[tgID].analMotion != "Non")
                    {
                        GUI.Label(new Rect(290, 230, 190, 20), "【anal用の設定】", gsLabel);
                        maj.analEnabled[maidsState[tgID].motionID] = GUI.Toggle(new Rect(300, 255, 150, 20), maj.analEnabled[maidsState[tgID].motionID], "analの有効化", gsToggle);

                        GUI.Label(new Rect(300, 275, 110, 20), "anal用の高さ：" + Math.Floor(maj.analHeight[maidsState[tgID].motionID] * 1000), gsLabel);
                        maj.analHeight[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(415, 280, 150, 20), maj.analHeight[maidsState[tgID].motionID], -0.1F, 0.1F);

                        GUI.Label(new Rect(300, 295, 110, 20), "anal用の前後：" + Math.Floor(maj.analForward[maidsState[tgID].motionID] * 1000), gsLabel);
                        maj.analForward[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(415, 300, 150, 20), maj.analForward[maidsState[tgID].motionID], -0.1F, 0.1F);

                        GUI.Label(new Rect(300, 315, 110, 20), "anal用の左右：" + Math.Floor(maj.analRight[maidsState[tgID].motionID] * 1000), gsLabel);
                        maj.analRight[maidsState[tgID].motionID] = GUI.HorizontalSlider(new Rect(415, 320, 150, 20), maj.analRight[maidsState[tgID].motionID], -0.1F, 0.1F);
                    }


                    if (GUI.Button(new Rect(10, 305, 80, 20), "メイド向き", gsButton))
                    {
                        if (maj.maidRoll[maidsState[tgID].motionID] == 0)
                        {
                            maj.maidRoll[maidsState[tgID].motionID] = 1;
                        }
                        else
                        {
                            maj.maidRoll[maidsState[tgID].motionID] = 0;
                        }
                    }
                    GUI.Label(new Rect(100, 305, 140, 20), mukiText2[maj.maidRoll[maidsState[tgID].motionID]], gsLabel);

                    if (GUI.Button(new Rect(10, 330, 80, 20), "男向き", gsButton))
                    {
                        if (maj.manRoll[maidsState[tgID].motionID] == 0)
                        {
                            maj.manRoll[maidsState[tgID].motionID] = 1;
                        }
                        else
                        {
                            maj.manRoll[maidsState[tgID].motionID] = 0;
                        }
                    }
                    GUI.Label(new Rect(100, 330, 140, 20), mukiText2[maj.manRoll[maidsState[tgID].motionID]], gsLabel);

                    if (GUI.Button(new Rect(10, 355, 80, 20), "反転設定", gsButton))
                    {
                        ++maj.rollSettei[maidsState[tgID].motionID];
                        if (maj.rollSettei[maidsState[tgID].motionID] > 2) maj.rollSettei[maidsState[tgID].motionID] = 0;
                    }
                    GUI.Label(new Rect(100, 355, 140, 20), mukiText1[maj.rollSettei[maidsState[tgID].motionID]], gsLabel);



                    GUI.Label(new Rect(205, 0, 190, 20), "【射精タイプ設定】", gsLabel);
                    for (int i = 0; i < SubMans.Length; i++)
                    {
                        int m = i + 1;
                        GUI.Label(new Rect(215, 25 + i * 25, 190, 20), "男" + m + "：" + marksList[maj.syaseiMarks[maidsState[tgID].motionID][i]], gsLabel);
                        if (GUI.Button(new Rect(310, 25 + i * 25, 20, 20), "<", gsButton))
                        {
                            --maj.syaseiMarks[maidsState[tgID].motionID][i];
                            if (maj.syaseiMarks[maidsState[tgID].motionID][i] < 0) maj.syaseiMarks[maidsState[tgID].motionID][i] = marksList.Length - 1;
                        }
                        if (GUI.Button(new Rect(335, 25 + i * 25, 20, 20), ">", gsButton))
                        {
                            ++maj.syaseiMarks[maidsState[tgID].motionID][i];
                            if (maj.syaseiMarks[maidsState[tgID].motionID][i] >= marksList.Length) maj.syaseiMarks[maidsState[tgID].motionID][i] = 0;
                        }
                    }


                    GUI.Label(new Rect(205, 155, 190, 20), "【快感上昇設定】", gsLabel);
                    maj.giveSexual[maidsState[tgID].motionID][0] = GUI.Toggle(new Rect(210, 180, 60, 20), maj.giveSexual[maidsState[tgID].motionID][0], "メイド", gsToggle);
                    maj.giveSexual[maidsState[tgID].motionID][1] = GUI.Toggle(new Rect(270, 180, 60, 20), maj.giveSexual[maidsState[tgID].motionID][1], "男１", gsToggle);
                    maj.giveSexual[maidsState[tgID].motionID][2] = GUI.Toggle(new Rect(330, 180, 60, 20), maj.giveSexual[maidsState[tgID].motionID][2], "男２", gsToggle);
                    maj.giveSexual[maidsState[tgID].motionID][3] = GUI.Toggle(new Rect(210, 200, 60, 20), maj.giveSexual[maidsState[tgID].motionID][3], "男３", gsToggle);
                    maj.giveSexual[maidsState[tgID].motionID][4] = GUI.Toggle(new Rect(270, 200, 60, 20), maj.giveSexual[maidsState[tgID].motionID][4], "男４", gsToggle);
                    maj.giveSexual[maidsState[tgID].motionID][5] = GUI.Toggle(new Rect(330, 200, 60, 20), maj.giveSexual[maidsState[tgID].motionID][5], "男５", gsToggle);



                    GUI.Label(new Rect(375, 0, 190, 20), "【装備アイテム】", gsLabel);
                    maj.itemSet[maidsState[tgID].motionID][0] = GUI.Toggle(new Rect(380, 25, 70, 20), maj.itemSet[maidsState[tgID].motionID][0], "バイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][1] = GUI.Toggle(new Rect(450, 25, 90, 20), maj.itemSet[maidsState[tgID].motionID][1], "バイブ(手)", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][5] = GUI.Toggle(new Rect(540, 25, 80, 20), maj.itemSet[maidsState[tgID].motionID][5], "拘束(手)", gsToggle);

                    maj.itemSet[maidsState[tgID].motionID][2] = GUI.Toggle(new Rect(380, 45, 70, 20), maj.itemSet[maidsState[tgID].motionID][2], "Aバイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][3] = GUI.Toggle(new Rect(450, 45, 90, 20), maj.itemSet[maidsState[tgID].motionID][3], "Aバイブ(手)", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][6] = GUI.Toggle(new Rect(540, 45, 80, 20), maj.itemSet[maidsState[tgID].motionID][6], "拘束(足)", gsToggle);

                    maj.itemSet[maidsState[tgID].motionID][4] = GUI.Toggle(new Rect(380, 65, 100, 20), maj.itemSet[maidsState[tgID].motionID][4], "双頭バイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][7] = GUI.Toggle(new Rect(480, 65, 60, 20), maj.itemSet[maidsState[tgID].motionID][7], "磔", gsToggle);

                    maj.itemSet[maidsState[tgID].motionID][8] = GUI.Toggle(new Rect(380, 85, 100, 20), maj.itemSet[maidsState[tgID].motionID][8], "ディルド台", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][9] = GUI.Toggle(new Rect(480, 85, 100, 20), maj.itemSet[maidsState[tgID].motionID][9], "三角木馬", gsToggle);


                    GUI.Label(new Rect(375, 115, 190, 20), "【男1】", gsLabel);
                    maj.itemSet[maidsState[tgID].motionID][10] = GUI.Toggle(new Rect(420, 115, 70, 20), maj.itemSet[maidsState[tgID].motionID][10], "バイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][11] = GUI.Toggle(new Rect(485, 115, 80, 20), maj.itemSet[maidsState[tgID].motionID][11], "Aバイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][12] = GUI.Toggle(new Rect(560, 115, 80, 20), maj.itemSet[maidsState[tgID].motionID][12], "電マ", gsToggle);

                    GUI.Label(new Rect(375, 145, 190, 20), "【男2】", gsLabel);
                    maj.itemSet[maidsState[tgID].motionID][15] = GUI.Toggle(new Rect(420, 145, 70, 20), maj.itemSet[maidsState[tgID].motionID][15], "バイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][16] = GUI.Toggle(new Rect(485, 145, 80, 20), maj.itemSet[maidsState[tgID].motionID][16], "Aバイブ", gsToggle);
                    maj.itemSet[maidsState[tgID].motionID][17] = GUI.Toggle(new Rect(560, 145, 80, 20), maj.itemSet[maidsState[tgID].motionID][17], "電マ", gsToggle);


                    GUI.Label(new Rect(380, 175, 170, 20), "設置アイテム：" + prefabList[0][maj.prefabSet[maidsState[tgID].motionID]], gsLabel);
                    if (GUI.Button(new Rect(550, 175, 20, 20), "<", gsButton))
                    {
                        --maj.prefabSet[maidsState[tgID].motionID];
                        if (maj.prefabSet[maidsState[tgID].motionID] < 0) maj.prefabSet[maidsState[tgID].motionID] = prefabList[0].Length - 1;
                    }
                    if (GUI.Button(new Rect(575, 175, 20, 20), ">", gsButton))
                    {
                        ++maj.prefabSet[maidsState[tgID].motionID];
                        if (maj.prefabSet[maidsState[tgID].motionID] >= prefabList[0].Length) maj.prefabSet[maidsState[tgID].motionID] = 0;
                    }



                    /*
                    GUI.Label (new Rect (205, 90, 190, 20), "左手アタッチ：" + boneList[maj.iTargetLH[maidsState[tgID].motionID]][1] , gsLabel);
                    if(GUI.Button(new Rect (350, 90, 20, 20), "<", gsButton)) {
                      --maj.iTargetLH[maidsState[tgID].motionID];
                      if(maj.iTargetLH[maidsState[tgID].motionID] < 0)maj.iTargetLH[maidsState[tgID].motionID] = 6;
                    }
                    if(GUI.Button(new Rect (375, 90, 20, 20), ">", gsButton)) {
                      ++maj.iTargetLH[maidsState[tgID].motionID];
                      if(maj.iTargetLH[maidsState[tgID].motionID] > 6)maj.iTargetLH[maidsState[tgID].motionID] = 0;
                    }

                    GUI.Label (new Rect (205, 115, 190, 20), "右手アタッチ：" + boneList[maj.iTargetRH[maidsState[tgID].motionID]][1] , gsLabel);
                    if(GUI.Button(new Rect (350, 115, 20, 20), "<", gsButton)) {
                      --maj.iTargetRH[maidsState[tgID].motionID];
                      if(maj.iTargetRH[maidsState[tgID].motionID] < 0)maj.iTargetRH[maidsState[tgID].motionID] = 6;
                    }
                    if(GUI.Button(new Rect (375, 115, 20, 20), ">", gsButton)) {
                      ++maj.iTargetRH[maidsState[tgID].motionID];
                      if(maj.iTargetRH[maidsState[tgID].motionID] > 6)maj.iTargetRH[maidsState[tgID].motionID] = 0;
                    }
                    */

                    GUI.EndScrollView();

                    GUI.Label(new Rect(10, 260, 400, 20), MotionNameChange(maj.motionName[maidsState[tgID].motionID]) + "　/　" + maj.motionName[maidsState[tgID].motionID], gsLabel);

                    if (GUI.Button(new Rect(420, 260, 180, 25), "調整値保存", gsButton))
                    {
                        MajFileSave();
                    }

                    GUI.Label(new Rect(0, 290, 620, 20), "――――――――――――――――――――――――――――――――――――――――――――――――", gsLabel2);

                    GUI.Label(new Rect(5, 310, 400, 20), "■以下はモーションアジャスト設定のサポート用", gsLabel);

                    GUI.Label(new Rect(5, 330, 145, 20), "ボイスセット：" + maidsState[tgID].editVoiceSetName, gsLabel);
                    y = 350;
                    int h1 = evsFiles.Count * 22;
                    if (maidsState[tgID].editVoiceSetName != "") h1 += 30;
                    if (h1 < 445 - y) h1 = 445 - y;
                    Rect scrlRect1 = new Rect(10, y, 190, 445 - y);
                    Rect contentRect1 = new Rect(0, 0, 170, h1);
                    vsScrollPos1 = GUI.BeginScrollView(scrlRect1, vsScrollPos1, contentRect1, false, true);
                    y = 0;

                    if (maidsState[tgID].editVoiceSetName != "")
                    {
                        if (GUI.Button(new Rect(0, y, 170, 20), "ボイスセット解除", gsButton))
                        {
                            maidsState[tgID].editVoiceSetName = "";
                            maidsState[tgID].editVoiceSet = new List<string[]>();
                        }
                        y += 30;
                    }

                    foreach (string f in evsFiles)
                    {
                        string FileName = f.Replace("evs_", "").Replace(".xml", "");
                        if (GUI.Button(new Rect(0, y, 170, 20), FileName, gsButton))
                        {
                            voiceSetLoad(f, tgID);
                        }
                        y += 22;
                    }
                    GUI.EndScrollView();


                    GUI.Label(new Rect(205, 330, 200, 20), "【メインメイドを移動】", gsLabel);

                    vm = maid.transform.position;
                    vml = maid.transform.localPosition;
                    em = maid.transform.eulerAngles;
                    if (GUI.Button(new Rect(210, 355, 25, 20), "X↑", gsButton))
                    {
                        MaidMove(tgID, "px", moveValue, true);
                    }
                    if (GUI.Button(new Rect(240, 355, 25, 20), "Y↑", gsButton))
                    {
                        MaidMove(tgID, "py", moveValue, true);
                    }
                    if (GUI.Button(new Rect(270, 355, 25, 20), "Z↑", gsButton))
                    {
                        MaidMove(tgID, "pz", moveValue, true);
                    }
                    if (GUI.Button(new Rect(300, 355, 50, 20), "合体", gsButton))
                    {
                        foreach (int maidID in vmId)
                        {
                            if (maidID != tgID && LinkMaidCheck(tgID, maidID))
                            {
                                stockMaids[maidID].mem.transform.position = maid.transform.position;
                                stockMaids[maidID].mem.transform.eulerAngles = maid.transform.eulerAngles;
                                maidsState[maidID].majHiBack = maidsState[tgID].majHiBack;
                                maidsState[maidID].majFwBack = maidsState[tgID].majFwBack;
                            }
                        }
                        for (int i = 0; i < SubMans.Length; i++)
                        {
                            if (!SubMans[i].Visible || MansTg[i] != tgID) continue;
                            SubMans[i].transform.position = maid.transform.position;
                            SubMans[i].transform.eulerAngles = maid.transform.eulerAngles;
                        }
                    }

                    if (GUI.Button(new Rect(210, 380, 25, 20), "X↓", gsButton))
                    {
                        MaidMove(tgID, "px", -moveValue, true);
                    }
                    if (GUI.Button(new Rect(240, 380, 25, 20), "Y↓", gsButton))
                    {
                        MaidMove(tgID, "py", -moveValue, true);
                    }
                    if (GUI.Button(new Rect(270, 380, 25, 20), "Z↓", gsButton))
                    {
                        MaidMove(tgID, "pz", -moveValue, true);
                    }
                    if (GUI.Button(new Rect(300, 380, 50, 20), "ﾘｾｯﾄ", gsButton))
                    {
                        foreach (int maidID in vmId)
                        {
                            if (maidID != tgID && !LinkMaidCheck(tgID, maidID)) continue;
                            stockMaids[maidID].mem.transform.position = new Vector3(0f, 0f, 0f);
                            maidsState[maidID].majHiBack = 0f;
                            maidsState[maidID].majFwBack = 0f;
                        }
                        for (int i = 0; i < SubMans.Length; i++)
                        {
                            if (!SubMans[i].Visible || MansTg[i] != tgID) continue;
                            SubMans[i].transform.position = new Vector3(0f, 0f, 0f);
                        }
                    }

                    GUI.Label(new Rect(210, 405, 95, 20), "移動距離：" + Math.Floor(moveValue * 100), gsLabel);
                    moveValue = GUI.HorizontalSlider(new Rect(215, 425, 170, 20), moveValue, 0.01f, 0.3F);


                    GUI.Label(new Rect(405, 330, 190, 20), "【クパ値設定】", gsLabel);
                    GUI.Label(new Rect(405, 350, 90, 20), "kupa(動)：" + Math.Floor(maidsState[tgID].hibuSlider1Value), gsLabel);
                    maidsState[tgID].hibuSlider1Value = GUI.HorizontalSlider(new Rect(495, 355, 100, 20), maidsState[tgID].hibuSlider1Value, 0.0F, 100.0F);
                    GUI.Label(new Rect(405, 370, 90, 20), "anal(動)：" + Math.Floor(maidsState[tgID].analSlider1Value), gsLabel);
                    maidsState[tgID].analSlider1Value = GUI.HorizontalSlider(new Rect(495, 375, 100, 20), maidsState[tgID].analSlider1Value, 0.0F, 100.0F);

                    GUI.Label(new Rect(405, 395, 90, 20), "kupa(停)：" + Math.Floor(maidsState[tgID].hibuSlider2Value), gsLabel);
                    maidsState[tgID].hibuSlider2Value = GUI.HorizontalSlider(new Rect(495, 400, 100, 20), maidsState[tgID].hibuSlider2Value, 0.0F, 100.0F);
                    GUI.Label(new Rect(405, 415, 90, 20), "anal(停)：" + Math.Floor(maidsState[tgID].analSlider2Value), gsLabel);
                    maidsState[tgID].analSlider2Value = GUI.HorizontalSlider(new Rect(495, 420, 100, 20), maidsState[tgID].analSlider2Value, 0.0F, 100.0F);

                }
            }



            //エンパイアズライフ設定画面
            if (ConfigFlag == 7)
            {
                x = 0;
                y = 0;
                scKeyOff = GUI.Toggle(new Rect(420, 5, 140, 20), scKeyOff, "ショートカット無効", gsToggle);

                x = 5;
                y = 40;

                if (GUI.Button(new Rect(5, y, 110, 20), "背景情報取得", gsButton))
                {
                    if (el_Overwrite || ELS.bgCode == "")
                    {
                        ELS.bgCode = GameMain.Instance.BgMgr.GetBGName();
                        ELS.bgName = ELS.bgCode;
                        ELS.timeZone = GameMain.Instance.CharacterMgr.status.GetFlag("時間帯") - 2;
                        LifeSceneLoad(ELS.bgCode);
                    }
                    else
                    {
                        elErrer = 3;
                    }
                }
                el_Overwrite = GUI.Toggle(new Rect(125, y, 70, 20), el_Overwrite, "上書／ｸﾘｱ", gsToggle);


                y += 25;
                GUI.Label(new Rect(5, y, 180, 20), "背景：" + ELS.bgName, gsLabel);

                y += 25;
                if (GUI.Button(new Rect(5, y, 40, 20), timeText[ELS.timeZone], gsButton))
                {
                    ++ELS.timeZone;
                    if (ELS.timeZone > 2) ELS.timeZone = 0;
                }

                if (GUI.Button(new Rect(55, y, 55, 20), "クリア", gsButton))
                {
                    if (el_Overwrite)
                    {
                        ELS = new EmpiresLifeScene_Xml();
                    }
                    else
                    {
                        elErrer = 3;
                    }
                }
                //XMLファイルに保存する
                if (GUI.Button(new Rect(120, y, 55, 20), "保存", gsButton))
                {
                    LifeSceneSave();
                    LifeSceneLoad();
                }

                y += 30;
                if (elErrer != 0)
                {
                    if (GUI.Button(new Rect(5, y, 20, 20), "x", gsButton))
                    {
                        elErrer = 0;
                    }
                    GUI.Label(new Rect(30, y, 170, 60), elErrerText[elErrer], gsLabel4);
                }
                y += 30;


                GUI.Label(new Rect(5, y, 55, 20), "【ｼｰﾝ名】", gsLabel);
                ELS.bgName = GUI.TextField(new Rect(70, y, 130, 20), ELS.bgName);
                y += 25;

                GUI.Label(new Rect(5, y, 55, 20), "【BGM】", gsLabel);
                ELS.bgm = GUI.TextField(new Rect(70, y, 130, 20), ELS.bgm);
                y += 30;

                //初期カメラ位置
                if (GUI.Button(new Rect(5, y, 180, 20), "初期カメラ位置を設定", gsButton))
                {
                    ELS.cameraPos = mainCamera.transform.position;
                    ELS.cameraEul = mainCamera.transform.eulerAngles;
                }
                y += 25;
                GUI.Label(new Rect(5, y, 200, 20), "【位置】 X:" + Math.Round(ELS.cameraPos.x, 2) + " Y:" + Math.Round(ELS.cameraPos.y, 2) + " Z:" + Math.Round(ELS.cameraPos.z, 2), gsLabel);
                y += 20;
                GUI.Label(new Rect(5, y, 200, 20), "【向き】 X:" + Math.Round(ELS.cameraEul.x, 2) + " Y:" + Math.Round(ELS.cameraEul.y, 2) + " Z:" + Math.Round(ELS.cameraEul.z, 2), gsLabel);


                //ライフセット一覧
                y += 30;
                GUI.Label(new Rect(5, y, 200, 20), "【登録済みシーン一覧】", gsLabel);

                y += 20;
                int h1 = elsFiles.Count * 22;
                if (h1 < 445 - y) h1 = 445 - y;
                Rect scrlRect1 = new Rect(5, y, 200, 445 - y);
                Rect contentRect1 = new Rect(0, 0, 175, h1);
                vsScrollPos1 = GUI.BeginScrollView(scrlRect1, vsScrollPos1, contentRect1, false, true);

                y = 0;
                foreach (EmpiresLifeScene_Xml _els in elsList)
                {
                    if (GUI.Button(new Rect(0, y, 175, 20), _els.bgName, gsButton))
                    {
                        ELS = _els;
                    }
                    y += 22;
                }
                GUI.EndScrollView();



                //ライフセット編集画面
                x = 220;
                y = 50;

                int h2 = ELE.motionSet.Count * 65 + 30;
                if (h2 < 445 - y) h2 = 445 - y;

                Rect scrlRect2 = new Rect(x, y, 400, 445 - y);
                Rect contentRect2 = new Rect(0, 0, 380, h2);
                vsScrollPos2 = GUI.BeginScrollView(scrlRect2, vsScrollPos2, contentRect2, false, true);

                y = 0;
                for (int i = 0; i < ELE.motionSet.Count; i++)
                {

                    GUI.Label(new Rect(0, 0 + y, 110, 20), "モーションセット", gsLabel);
                    ELE.motionSet[i] = GUI.TextField(new Rect(110, 0 + y, 260, 20), ELE.motionSet[i]);

                    GUI.Label(new Rect(10, 25 + y, 200, 20), MotionNameChange(MSX.saveMotionSet[msCategory][i]), gsLabel);

                    if (GUI.Button(new Rect(215, 25 + y, 50, 20), "取得", gsButton))
                    {
                        string motion = stockMaids[tgID].mem.body0.LastAnimeFN;
                        motion = regZeccyouBackup.Match(motion).Groups[1].Value;  // 「 - Que…」を除く
                        motion = Regex.Replace(motion, "_[23](?!ana)(?!p_)(?!vibe)", "_1");
                        motion = Regex.Replace(motion, @"[a-zA-Z][0-9][0-9]", "");
                        MSX.saveMotionSet[msCategory][i] = motion;
                    }
                    if (GUI.Button(new Rect(270, 25 + y, 50, 20), "再生", gsButton))
                    {
                        MotionChange(maid, MSX.saveMotionSet[msCategory][i], true, 0.7f, 1f);
                        ManMotionChange(tgID, true, 0.7f, 1f);
                    }
                    if (GUI.Button(new Rect(325, 25 + y, 50, 20), "削除", gsButton))
                    {
                        MSX.saveMotionSet[msCategory].RemoveAt(i);
                    }
                    GUI.Label(new Rect(5, 45 + y, 370, 20), "―――――――――――――――――――――――――――――", gsLabel2);

                    y += 65;
                }

                if (GUI.Button(new Rect(315, 0 + y, 60, 20), "追加", gsButton))
                {
                    MSX.saveMotionSet[msCategory].Add("");
                }

                GUI.EndScrollView();

            }



            //エロステータス画面
            if (ConfigFlag == 8)
            {

                GUI.Label(new Rect(5, 30, 190, 20), "【エロステータス（β版）】", gsLabel);

                GUI.Label(new Rect(10, 60, 300, 20), "クリトリス肥大度：" + Math.Round(maidsState[tgID].cliHidai, 1, MidpointRounding.AwayFromZero), gsLabel);
                //GUI.Label (new Rect (10, 80, 300, 20), "乳首肥大度　　　：" + Math.Round(maidsState[tgID].chikubiHidai, 1,  MidpointRounding.AwayFromZero) , gsLabel);

                GUI.Label(new Rect(10, 110, 300, 20), "トータル絶頂数：" + maidsState[tgID].orgTotal + " 回", gsLabel);
                GUI.Label(new Rect(10, 130, 300, 20), "最大連続絶頂数：" + maidsState[tgID].orgMax + " 回", gsLabel);

                GUI.Label(new Rect(10, 160, 300, 20), "中出し回数（膣）　：" + maidsState[tgID].syaseiTotal1[0] + " 回（" + Math.Round(maidsState[tgID].syaseiTotal2[0], 2, MidpointRounding.AwayFromZero) + " ml）", gsLabel);
                GUI.Label(new Rect(10, 180, 300, 20), "中出し回数（anal）：" + maidsState[tgID].syaseiTotal1[1] + " 回（" + Math.Round(maidsState[tgID].syaseiTotal2[1], 2, MidpointRounding.AwayFromZero) + " ml）", gsLabel);
                GUI.Label(new Rect(10, 200, 300, 20), "精飲回数　　　　　：" + maidsState[tgID].syaseiTotal1[2] + " 回（" + Math.Round(maidsState[tgID].syaseiTotal2[2], 2, MidpointRounding.AwayFromZero) + " ml）", gsLabel);
                GUI.Label(new Rect(10, 220, 300, 20), "外出し回数　　　　：" + maidsState[tgID].syaseiTotal1[3] + " 回（" + Math.Round(maidsState[tgID].syaseiTotal2[3], 2, MidpointRounding.AwayFromZero) + " ml）", gsLabel);

                GUI.Label(new Rect(10, 250, 300, 20), "潮吹き回数：" + maidsState[tgID].sioTotal1 + " 回（" + Math.Round(maidsState[tgID].sioTotal2, 2, MidpointRounding.AwayFromZero) + " ml）", gsLabel);
                GUI.Label(new Rect(10, 270, 300, 20), "失禁回数　：" + maidsState[tgID].nyoTotal1 + " 回（" + Math.Round(maidsState[tgID].nyoTotal2, 1, MidpointRounding.AwayFromZero) + " ml）", gsLabel);

                GUI.Label(new Rect(10, 300, 300, 20), "失神回数　：" + maidsState[tgID].stanTotal + " 回", gsLabel);
                GUI.Label(new Rect(10, 320, 300, 20), "子宮脱回数：" + maidsState[tgID].uDatsuTotal + " 回", gsLabel);


                GUI.Label(new Rect(10, 350, 300, 20), "潮：" + maidsState[tgID].sioVolume, gsLabel);
                GUI.Label(new Rect(10, 370, 300, 20), "尿：" + maidsState[tgID].nyoVolume, gsLabel);

                /*自分用
                GUI.Label (new Rect (10, 400, 300, 20), "マウス：" + mouse_move , gsLabel);
                GUI.Label (new Rect (10, 420, 300, 20), "お触りポイント：" + hitName , gsLabel);

                GUI.Label (new Rect (310, 60, 300, 20), "快感レベル：" + maidsState[tgID].kaikanLevel , gsLabel);
                GUI.Label (new Rect (310, 80, 300, 20), "スタミナ：" + maidsState[tgID].maidStamina , gsLabel);
                GUI.Label (new Rect (310, 100, 300, 20), "勃起値：" + maidsState[tgID].bokkiValue1 , gsLabel);


                var angleZ = 360 - maidsState[tgID].maidHead.transform.rotation.eulerAngles.z;
                var kz = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                GUI.Label (new Rect (310, 150, 300, 20), "頭Z：" + maidsState[tgID].maidHead.transform.rotation.eulerAngles.z , gsLabel);
                GUI.Label (new Rect (310, 170, 300, 20), "頭加算：" + kz , gsLabel);

                angleZ = 360 - maidsState[tgID].maidXxx.transform.rotation.eulerAngles.z;
                kz = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                GUI.Label (new Rect (310, 200, 300, 20), "股Z：" + maidsState[tgID].maidXxx.transform.rotation.eulerAngles.z , gsLabel);
                GUI.Label (new Rect (310, 220, 300, 20), "股加Z：" + kz , gsLabel);

                angleZ = 360 - maidsState[tgID].maidXxx.transform.rotation.eulerAngles.y;
                kz = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                GUI.Label (new Rect (310, 250, 300, 20), "股Y：" + maidsState[tgID].maidXxx.transform.rotation.eulerAngles.y , gsLabel);
                GUI.Label (new Rect (310, 270, 300, 20), "股加Y：" + kz , gsLabel);

                GUI.Label (new Rect (310, 300, 300, 20), "股X：" + maidsState[tgID].maidXxx.transform.rotation.eulerAngles.x , gsLabel);

                */

            }



            //乳首設定登録画面
            if (ConfigFlag == 9)
            {

                y = 35;
                GUI.Label(new Rect(5, y, 200, 20), "【乳首設定の登録（" + chikubiText[cv] + "）】", gsLabel);
                y += 25;

                maidsState[tgID].chikubiEnabled = GUI.Toggle(new Rect(10, y, 150, 20), maidsState[tgID].chikubiEnabled, "乳首操作の有効化", gsToggle);

                if (maidsState[tgID].chikubiEnabled)
                {
                    maidsState[tgID].chikubiBokkiEnabled = GUI.Toggle(new Rect(160, y, 100, 20), maidsState[tgID].chikubiBokkiEnabled, "勃起の有無", gsToggle);

                    y = 50;
                    if (GUI.Button(new Rect(320, y, 80, 30), "着衣時", gsButton))
                    {
                        cv = 0;
                    }
                    if (GUI.Button(new Rect(410, y, 80, 30), "裸時", gsButton))
                    {
                        cv = 1;
                    }
                    y += 40;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首基本：" + Math.Floor(maidsState[tgID].tits_chikubi_def[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_def[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_def[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首尖：" + Math.Floor(maidsState[tgID].tits_chikubi_perky[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_perky[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_perky[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首牛：" + Math.Floor(maidsState[tgID].tits_chikubi_cow[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_cow[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_cow[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首凹：" + Math.Floor(maidsState[tgID].tits_chikubi_observe[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_observe[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_observe[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首膨１：" + Math.Floor(maidsState[tgID].tits_chikubi_wide[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_wide[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_wide[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首膨２：" + Math.Floor(maidsState[tgID].tits_chikubi_ultrawide[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_ultrawide[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_ultrawide[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首長さ：" + Math.Floor(maidsState[tgID].tits_chikubi_ultralong[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_ultralong[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_ultralong[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首垂れ：" + Math.Floor(maidsState[tgID].tits_chikubi_ultratare[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_ultratare[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_ultratare[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首陥没１：" + Math.Floor(maidsState[tgID].tits_chikubi_kanbotsu_n[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_kanbotsu_n[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_kanbotsu_n[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首陥没２：" + Math.Floor(maidsState[tgID].tits_chikubi_kanbotsu_s[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_kanbotsu_s[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_kanbotsu_s[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(5, y, 100, 20), "乳首陥没３：" + Math.Floor(maidsState[tgID].tits_chikubi_kanbotsu_p[cv] * 100), gsLabel);
                    maidsState[tgID].tits_chikubi_kanbotsu_p[cv] = GUI.HorizontalSlider(new Rect(105, y + 5, 190, 20), maidsState[tgID].tits_chikubi_kanbotsu_p[cv], 0.0F, 2.0F);
                    y = 90;


                    GUI.Label(new Rect(305, y, 100, 20), "乳輪基本：" + Math.Floor(maidsState[tgID].tits_nipple_def[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_def[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_def[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 100, 20), "乳輪尖１：" + Math.Floor(maidsState[tgID].tits_nipple_perky1[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_perky1[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_perky1[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 100, 20), "乳輪尖２：" + Math.Floor(maidsState[tgID].tits_nipple_perky2[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_perky2[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_perky2[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 100, 20), "乳輪伸１：" + Math.Floor(maidsState[tgID].tits_nipple_long1[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_long1[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_long1[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 100, 20), "乳輪伸２：" + Math.Floor(maidsState[tgID].tits_nipple_long2[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_long2[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_long2[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 100, 20), "乳輪膨：" + Math.Floor(maidsState[tgID].tits_nipple_wide[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_wide[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_wide[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 100, 20), "ぷっくり：" + Math.Floor(maidsState[tgID].tits_nipple_puffy[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_puffy[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_puffy[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 90, 20), "乳首クパ：" + Math.Floor(maidsState[tgID].tits_nipple_kupa[cv] * 100), gsLabel);
                    maidsState[tgID].tits_nipple_kupa[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_nipple_kupa[cv], 0.0F, 2.0F);
                    y += 20;

                    GUI.Label(new Rect(305, y, 90, 20), "ちっぱい：" + Math.Floor(maidsState[tgID].tits_munel_chippai[cv] * 100), gsLabel);
                    maidsState[tgID].tits_munel_chippai[cv] = GUI.HorizontalSlider(new Rect(405, y + 5, 190, 20), maidsState[tgID].tits_munel_chippai[cv], 0.0F, 2.0F);
                    y += 40;


                    if (GUI.Button(new Rect(320, y, 130, 20), "コピー（着衣 → 裸）", gsButton))
                    {
                        ChikubiCopy(tgID, 1, 0);
                    }
                    if (GUI.Button(new Rect(460, y, 130, 20), "コピー（着衣 ← 裸）", gsButton))
                    {
                        ChikubiCopy(tgID, 0, 1);
                    }
                    y += 40;


                    GUI.Label(new Rect(10, y, 200, 20), "▼基本設定の読み込み", gsLabel);
                    y += 30;

                    if (GUI.Button(new Rect(10, y, 120, 20), "基本乳首", gsButton))
                    {
                        ChikubiReset(tgID, cv);
                        maidsState[tgID].tits_chikubi_def[cv] = 0.22f;
                        maidsState[tgID].tits_chikubi_perky[cv] = 0.35f;
                        maidsState[tgID].tits_chikubi_wide[cv] = 0.40f;
                        maidsState[tgID].tits_nipple_puffy[cv] = 0.31f;
                    }

                    if (GUI.Button(new Rect(140, y, 120, 20), "大きい乳首", gsButton))
                    {
                        ChikubiReset(tgID, cv);
                        maidsState[tgID].tits_chikubi_perky[cv] = 0.46f;
                        maidsState[tgID].tits_chikubi_wide[cv] = 0.42f;
                        maidsState[tgID].tits_nipple_wide[cv] = 0.75f;
                        maidsState[tgID].tits_nipple_puffy[cv] = 0.42f;
                    }

                    if (GUI.Button(new Rect(270, y, 120, 20), "陥没乳首", gsButton))
                    {
                        ChikubiReset(tgID, cv);
                        maidsState[tgID].tits_chikubi_def[cv] = 0.80f;
                        maidsState[tgID].tits_chikubi_wide[cv] = 0.60f;
                        maidsState[tgID].tits_chikubi_kanbotsu_n[cv] = 0.44f;
                        maidsState[tgID].tits_chikubi_kanbotsu_p[cv] = 1.40f;
                        maidsState[tgID].tits_nipple_wide[cv] = 1.0f;
                        maidsState[tgID].tits_nipple_puffy[cv] = 0.40f;
                    }

                    if (GUI.Button(new Rect(410, y, 120, 20), "デカ乳輪", gsButton))
                    {
                        ChikubiReset(tgID, cv);
                        maidsState[tgID].tits_chikubi_def[cv] = 0.42f;
                        maidsState[tgID].tits_chikubi_perky[cv] = 0.35f;
                        maidsState[tgID].tits_chikubi_wide[cv] = 0.77f;
                        maidsState[tgID].tits_nipple_perky1[cv] = 0.29f;
                        maidsState[tgID].tits_nipple_wide[cv] = 1.6f;
                        maidsState[tgID].tits_nipple_puffy[cv] = 0.80f;
                    }
                    y += 30;

                    if (GUI.Button(new Rect(10, y, 120, 20), "トンガリ乳首", gsButton))
                    {
                        ChikubiReset(tgID, cv);
                        maidsState[tgID].tits_chikubi_def[cv] = 0.21f;
                        maidsState[tgID].tits_chikubi_perky[cv] = 0.34f;
                        maidsState[tgID].tits_chikubi_wide[cv] = 0.40f;
                        maidsState[tgID].tits_nipple_perky1[cv] = 0.75f;
                        maidsState[tgID].tits_nipple_wide[cv] = 0.52f;
                        maidsState[tgID].tits_nipple_puffy[cv] = 0.72f;
                    }
                    y += 10;

                    /*
                    GUI.Label (new Rect (20, 300, 300, 20), "上着（本）：" + maid.GetProp(MPN.wear).strFileName , gsLabel);
                    GUI.Label (new Rect (320, 300, 300, 20), "上着（仮）：" + maid.GetProp(MPN.wear).strTempFileName , gsLabel);

                    GUI.Label (new Rect (20, 320, 300, 20), "ワンピ（本）：" + maid.GetProp(MPN.onepiece).strFileName , gsLabel);
                    GUI.Label (new Rect (320, 320, 300, 20), "ワンピ（仮）：" + maid.GetProp(MPN.onepiece).strTempFileName , gsLabel);

                    GUI.Label (new Rect (20, 340, 300, 20), "水着（本）：" + maid.GetProp(MPN.mizugi).strFileName , gsLabel);
                    GUI.Label (new Rect (320, 340, 300, 20), "水着（仮）：" + maid.GetProp(MPN.mizugi).strTempFileName , gsLabel);

                    GUI.Label (new Rect (20, 360, 300, 20), "ブラ（本）：" + maid.GetProp(MPN.bra).strFileName , gsLabel);
                    GUI.Label (new Rect (320, 360, 300, 20), "ブラ（仮）：" + maid.GetProp(MPN.bra).strTempFileName , gsLabel);
                    */




                    if (GUI.Button(new Rect(470, y, 120, 30), "設定保存", gsButton))
                    {
                        ChikubiSave(tgID, 0);
                        ChikubiSave(tgID, 1);
                    }

                    ChikubiSet(tgID, cv);
                }


            }

            GUI.DragWindow();
        }



        //UNZIP用GUI---------------
        Vector2 YotogiScrollPos = Vector2.zero;
        Vector2 YotogiScrollPos2 = Vector2.zero;
        private bool smHidden = false;
        private bool unzipSelect = false;
        private GUIStyleState styleYellow;
        private GUIStyleState styleWhite;
        void WindowCallback4(int id)
        {

            styleYellow = new GUIStyleState();
            styleYellow.textColor = Color.yellow;

            styleWhite = new GUIStyleState();
            styleWhite.textColor = Color.white;

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;
            gsLabel2.normal = styleYellow;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsToggle = new GUIStyle("toggle");
            gsToggle.fontSize = 12;
            gsToggle.alignment = TextAnchor.MiddleLeft;


            if (GUI.Button(new Rect(600, 0, 20, 20), "x", gsButton))
            {
                cfgw.unzipGuiFlag = false;
            }

            smHidden = GUI.Toggle(new Rect(400, 0, 170, 20), smHidden, "サブモーション非表示", gsToggle);

            int y = 1;
            int x = 5;
            int w = 70;

            for (int i = 0; i < YotogiGroup.Count; i++)
            {
                if (i != YotogiMenu)
                {
                    if (GUI.Button(new Rect(x, y * 25, w, 20), YotogiGroup[i], gsButton))
                    {
                        YotogiMenu = i;
                    }
                }
                else
                {
                    GUI.Label(new Rect(x, y * 25, w, 20), ">> " + YotogiGroup[i], gsLabel2);
                }

                x += w + 5;
                if (x + w > 615)
                {
                    x = 5;
                    y += 1;
                }
            }

            int h = 185 - y * 25;
            if (YotogiGroup.Count - 1 > YotogiMenu)
            {
                h = 22 * (YotogiList[YotogiMenu].Count / 3 + 1);
                if (YotogiMenu == 9 || YotogiMenu == 10) h = 22 * (YotogiList[YotogiMenu].Count / 2 + 1);

                if (h < (185 - y * 25))
                {
                    h = 185 - y * 25;
                }
            }
            else
            {
                if (h < (185 - y * 25)) h = 185 - y * 25;
            }

            Rect scrlRect = new Rect(10, 25 + y * 25, 609, 185 - y * 25);
            Rect contentRect = new Rect(0, 0, 590, h);
            YotogiScrollPos = GUI.BeginScrollView(scrlRect, YotogiScrollPos, contentRect, false, true);

            Maid maid = stockMaids[tgID].mem;

            //夜伽モーションのリスト画面
            if (YotogiGroup.Count - 1 > YotogiMenu)
            {
                y = 0;
                x = 0;
                if (YotogiMenu == 9 || YotogiMenu == 10)
                {
                    w = 290;
                }
                else
                {
                    w = 195;
                }

                for (int i = 0; i < YotogiList[YotogiMenu].Count; i++)
                {
                    string t = YotogiList[YotogiMenu][i];
                    string name = YotogiListName[YotogiMenu][i];
                    if (smHidden && (name.Contains("女B") || name.Contains("女C"))) continue;

                    bool select = false;
                    if (maidsState[tgID].motionID != -1 && maj.motionName[maidsState[tgID].motionID] == t) select = true;
                    if (select)
                    {
                        gsButton.normal.textColor = Color.yellow;
                        gsButton.hover.textColor = Color.yellow;
                    }

                    if (GUI.Button(new Rect(x, y * 22, w, 20), name, gsButton))
                    {

                        //モーションアジャスト実行
                        MotionAdjustDo(tgID, t, true, -1);

                        //メイドのモーション変更
                        if (maidsState[tgID].vStateMajor == 20)
                        { //強度に合わせて変更
                            t = t.Replace("_1_", "_2_");
                        }
                        else if (maidsState[tgID].vStateMajor == 30)
                        {
                            t = t.Replace("_1_", "_3_");
                        }

                        string inMotion = MotionCheckTokusyu(t, sInMaidMotion); //挿入モーションがあるかチェック
                        if (inMotion == "Non" || maidsState[tgID].inMotion == inMotion)
                        {
                            MotionChange(maid, t + ".anm", true, 0.7f, 1f);
                        }
                        else
                        {
                            MotionChange(maid, inMotion + ".anm", false, 0.7f, 1f);
                            MotionChangeAf(maid, t + ".anm", true, 0.7f, 1f); // 終わったら再生する
                        }

                        if (maidsState[tgID].uDatsu == 2 && maj.hkupa1[maidsState[tgID].motionID] > 50f)
                        {
                            maidsState[tgID].uDatsuValue1 = 0f;
                            maidsState[tgID].uDatsu = 0;
                            try { VertexMorph_FromProcItem(maid.body0, "pussy_uterus_prolapse", 0f); } catch { /*LogError(ex);*/ }
                        }

                        if (maidsState[tgID].uDatsu == 3) maidsState[tgID].uDatsu = 0;

                        maid.IKTargetToBone("左手", null, "無し", Vector3.zero, IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);
                        maid.IKTargetToBone("右手", null, "無し", Vector3.zero, IKCtrlData.IKAttachType.Point, false, false, IKCtrlData.IKExecTiming.Normal);

                        //男の自動表示
                        if (cfgw.autoManEnabled && !MansTgCheck(tgID) && MotionOldCheck(Regex.Replace(t, @"_f(|[0-9])", "_m")) != -1)
                        {
                            for (int im = 0; im < SubMans.Length; im++)
                            {
                                if (!SubMans[im]) SubMans[im] = GameMain.Instance.CharacterMgr.GetMan(im);
                                if (SubMans[im].Visible) continue;
                                StartCoroutine("MansVisible", im);
                                maid.EyeToCamera((Maid.EyeMoveType)0, 0.8f);
                                break;
                            }
                        }

                        //男のモーション変更
                        if (inMotion == "Non" || maidsState[tgID].inMotion == inMotion)
                        {
                            ManMotionChange(tgID, true, 0.7f, 1.0f);
                        }
                        else
                        {
                            ManMotionChange(inMotion + ".anm", tgID, false, 0.7f, 1f);
                            ManMotionChangeAf(t + ".anm", tgID, true, 0.7f, 1f); // 終わったら再生する

                        }

                        //百合・ハーレム相手のモーション変更
                        if (YotogiMenu == 8 || YotogiMenu == 9)
                        {
                            if (inMotion == "Non" || maidsState[tgID].inMotion == inMotion)
                            {
                                SubMotionChange(tgID, t + ".anm", true, true, 0.7f, 1f);
                            }
                            else
                            {
                                SubMotionChange(tgID, inMotion + ".anm", false, true, 0.7f, 1f);
                                SubMotionChange(tgID, t + ".anm", true, false, 0.7f, 1f);
                            }
                        }

                        //挿入モーションのバックアップを取得
                        maidsState[tgID].inMotion = inMotion;

                        //モーションセットリセット
                        MotionSetClear(tgID);

                        //いたずら開始フラグ
                        if (lifeStart >= 5) maidsState[tgID].elItazuraFlag = true;

                        //タイマーリセット
                        maidsState[tgID].motionHoldTime = UnityEngine.Random.Range(200f, 600f);
                        maidsState[tgID].voiceHoldTime = 0f;
                        maidsState[tgID].faceHoldTime = 0f;
                        maidsState[tgID].MouthHoldTime = 0f;

                    }

                    if (select)
                    {
                        gsButton.normal.textColor = Color.white;
                        gsButton.hover.textColor = Color.white;
                    }

                    x += w + 2;
                    if (x + w > 590)
                    {
                        x = 0;
                        y += 1;
                    }

                }


            }
            else
            {
                //ランダムモーションセット
                y = 5;
                x = 0;
                w = 195;

                if (maidsState[tgID].editMotionSetName != "")
                {
                    if (GUI.Button(new Rect(x, y, 50, 20), "解除", gsButton))
                    {
                        MotionSetClear(tgID);
                    }
                    GUI.Label(new Rect(x + 60, y, 300, 20), "『" + maidsState[tgID].editMotionSetName + "』を適用中", gsLabel);
                    y += 25;
                }

                foreach (string f in emsFiles)
                {
                    string FileName = f.Replace("ems_", "").Replace(".xml", "");
                    if (GUI.Button(new Rect(x, y, w, 20), FileName, gsButton))
                    {
                        MotionSetClear(tgID);
                        MotionSetLoad(f, tgID);

                        //男の自動表示
                        if (cfgw.autoManEnabled && !MansTgCheck(tgID) && MotionOldCheck(Regex.Replace(maidsState[tgID].editMotionSet[0][0], @"_f(|[0-9])", "_m")) != -1)
                        {
                            for (int im = 0; im < SubMans.Length; im++)
                            {
                                if (!SubMans[im]) SubMans[im] = GameMain.Instance.CharacterMgr.GetMan(im);
                                if (SubMans[im].Visible) continue;
                                StartCoroutine("MansVisible", im);
                                maid.EyeToCamera((Maid.EyeMoveType)0, 0.8f);
                                break;
                            }
                        }

                        //いたずら開始フラグ
                        if (lifeStart >= 5) maidsState[tgID].elItazuraFlag = true;
                    }

                    x += w + 2;
                    if (x + w > 590)
                    {
                        x = 0;
                        y += 22;
                    }
                }
            }

            GUI.EndScrollView();


            GUI.DragWindow();
        }




        void WindowCallback4a(int id)
        {

            styleYellow = new GUIStyleState();
            styleYellow.textColor = Color.yellow;

            styleWhite = new GUIStyleState();
            styleWhite.textColor = Color.white;

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;
            gsLabel2.normal = styleYellow;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsToggle = new GUIStyle("toggle");
            gsToggle.fontSize = 12;
            gsToggle.alignment = TextAnchor.MiddleLeft;


            int y = 0;
            int w = 195;
            int h = 22 * maidsState[tgID].senyouTokusyuMotion.Count;
            if (h < 185) h = 185;

            Maid maid = stockMaids[tgID].mem;

            Rect scrlRect = new Rect(0, 25, 220, 190);
            Rect contentRect = new Rect(0, 0, 200, h);
            YotogiScrollPos2 = GUI.BeginScrollView(scrlRect, YotogiScrollPos2, contentRect, false, true);

            //特殊モーションリスト
            foreach (string tokusyu in maidsState[tgID].senyouTokusyuMotion)
            {
                name = MotionNameChange(tokusyu);
                if (GUI.Button(new Rect(5, y * 22, w, 20), name, gsButton))
                {
                    string t = maid.body0.LastAnimeFN;

                    if (tokusyu.Contains("_once_"))
                    {
                        MotionChange(maid, tokusyu + ".anm", false, 0.7f, 1f);
                        ManMotionChange(tokusyu + ".anm", tgID, false, 0.7f, 1f);

                        MotionChangeAf(maid, t, true, 0.7f, 1f);
                        ManMotionChangeAf(t, tgID, true, 0.7f, 1f); // 終わったら再生する
                    }
                    else
                    {
                        MotionChange(maid, tokusyu + ".anm", true, 0.7f, 1f);
                        ManMotionChange(tgID, true, 0.7f, 1.0f);
                    }
                }
                y += 1;
            }

            GUI.EndScrollView();

            GUI.DragWindow();
        }





        //エンパイアズライフ用GUI
        private int ElGuiFlag = 0;
        private GUIStyleState styleState;
        Vector2 elScrollPos = Vector2.zero;
        private bool flagN = false;
        void WindowCallback5(int id)
        {

            GUIStyle gsLabel = new GUIStyle("label");
            gsLabel.fontSize = 12;
            gsLabel.alignment = TextAnchor.MiddleLeft;

            GUIStyle gsLabel2 = new GUIStyle("label");
            gsLabel2.fontSize = 12;
            gsLabel2.alignment = TextAnchor.MiddleCenter;
            styleState = new GUIStyleState();
            styleState.textColor = Color.yellow;
            gsLabel2.normal = styleState;

            GUIStyle gsButton = new GUIStyle("button");
            gsButton.fontSize = 12;
            gsButton.alignment = TextAnchor.MiddleCenter;

            GUIStyle gsToggle = new GUIStyle("toggle");
            gsToggle.fontSize = 12;
            gsToggle.alignment = TextAnchor.MiddleLeft;


            if (ElGuiFlag == 0)
            {
                if (GUI.Button(new Rect(820, 0, 20, 20), "－", gsButton))
                {
                    ElGuiFlag = 1;
                    node5.width = 220;
                    node5.height = 20;
                }

                Maid maid = null;
                if (tgID != -1) maid = stockMaids[tgID].mem;

                int x = 0;
                int y = 30;


                //GUI.Label (new Rect (5, y, 190, 20), "【移動先選択】" , gsLabel);
                Rect scrlRect = new Rect(0, y, 620, 100);
                Rect contentRect = new Rect(0, 0, 600, 25 * bgC);
                elScrollPos = GUI.BeginScrollView(scrlRect, elScrollPos, contentRect, false, true);

                y = 0;

                for (int i = 0; i < bgArray1.GetLength(0); i++)
                {

                    //bool flagN = GameMain.Instance.CharacterMgr.status.GetFlag("時間帯") == 3;
                    if (bgArray1[i][3] == "0") continue;
                    if (flagN && bgArray1[i][3] == "1") continue;
                    if (!flagN && bgArray1[i][3] == "2") continue;

                    string bgName = bgArray1[i][1].Replace("（夜）", "");
                    if (bgID == i)
                    {
                        GUI.Label(new Rect(10 + x, y, 140, 20), "≫ " + bgName, gsLabel2);
                    }
                    else
                    {
                        if (GUI.Button(new Rect(10 + x, y, 140, 20), bgName, gsButton))
                        {
                            StartCoroutine("ElChange", i);
                        }
                    }

                    if (x >= 435)
                    {
                        y += 25;
                        x = 0;
                    }
                    else
                    {
                        x += 145;
                    }
                }

                foreach (EmpiresLifeScene_Xml _els in elsList)
                {
                    if (_els.timeZone != 2)
                    {
                        if (flagN && _els.timeZone == 0) continue;
                        if (!flagN && _els.timeZone == 1) continue;
                    }

                    if (GUI.Button(new Rect(10 + x, y, 140, 20), _els.bgName, gsButton))
                    {
                        elsChange(_els);
                    }

                    if (x >= 435)
                    {
                        y += 25;
                        x = 0;
                    }
                    else
                    {
                        x += 145;
                    }
                }

                if (!maidOver)
                {
                    for (int i2 = 0; i2 < holidayMaid.Count; i2++)
                    {

                        string hmName = stockMaids[holidayMaid[i2][0]].mem.status.firstName + "の部屋";
                        if (bgID == 38 && hmID == i2)
                        {
                            GUI.Label(new Rect(10 + x, y, 140, 20), "≫ " + hmName, gsLabel2);
                        }
                        else
                        {
                            if (GUI.Button(new Rect(10 + x, y, 140, 20), hmName, gsButton))
                            {
                                mn[38] = holidayMaid[i2];
                                StartCoroutine("ElChange", 38);
                                hmID = i2;
                            }
                        }

                        if (x >= 435)
                        {
                            y += 25;
                            x = 0;
                        }
                        else
                        {
                            x += 145;
                        }
                    }
                }


                GUI.EndScrollView();

                y = 140;


                if (!bOculusVR)
                {
                    GUI.Label(new Rect(10, y, 70, 20), "移動速度", gsLabel);
                    speed = GUI.HorizontalSlider(new Rect(70, y + 5, 100, 20), speed, 0.1f, 2f);
                    if (GUI.Button(new Rect(180, y, 20, 20), "R", gsButton))
                    {
                        speed = 1;
                    }
                }

                if (GUI.Button(new Rect(220, y, 90, 20), "ラナルータ", gsButton))
                {
                    flagN = !flagN;
                    ElStart();
                    if (!flagN) StartCoroutine("ElChange", 0);
                    if (flagN) StartCoroutine("ElChange", 1);
                }

                if (GUI.Button(new Rect(370, y, 120, 20), "アイテム表示切替", gsButton))
                {
                    isItem = !isItem;
                    maid.body0.SetMask(TBody.SlotID.HandItemR, isItem);
                    maid.body0.SetMask(TBody.SlotID.HandItemL, isItem);
                    maid.body0.SetMask(TBody.SlotID.kousoku_upper, isItem);
                    maid.body0.SetMask(TBody.SlotID.kousoku_lower, isItem);
                }

                if (GUI.Button(new Rect(500, y, 75, 20), "NTRﾌﾞﾛｯｸ", gsButton))
                {
                    cfgw.ntrBlock = !cfgw.ntrBlock;
                    ElStart();
                    StartCoroutine("ElChange", bgID);
                }

                if (cfgw.ntrBlock) GUI.Label(new Rect(580, y, 35, 20), "ON", gsLabel);
                if (!cfgw.ntrBlock) GUI.Label(new Rect(580, y, 35, 20), "OFF", gsLabel);


                y = 30;


                if (maid)
                {
                    if (bgID == 36 || bgID == 37)
                    {

                        GUI.Label(new Rect(635, y, 200, 20), "【スポット移動】", gsLabel);

                        if (GUI.Button(new Rect(640, y + 25, 85, 20), "スポット１", gsButton))
                        {
                            maid.transform.position = new Vector3(-2.81f, 0.6f, -3.76f);
                            man.transform.position = new Vector3(-2.81f, 0.6f, -3.76f);
                            maid.transform.eulerAngles = new Vector3(0f, 87.5f, 0f);
                            man.transform.eulerAngles = new Vector3(0f, 87.5f, 0f);
                            maid.body0.SetBoneHitHeightY(0.5f);
                            maid.CrossFadeAbsolute("om_seijyoui_1_f.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                            man.CrossFadeAbsolute("om_seijyoui_1_m.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                        }

                        if (GUI.Button(new Rect(735, y + 25, 85, 20), "スポット２", gsButton))
                        {
                            maid.transform.position = new Vector3(-2.73f, 0.73f, -7.27f);
                            man.transform.position = new Vector3(-2.73f, 0.73f, -7.27f);
                            maid.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                            man.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                            maid.body0.SetBoneHitHeightY(0f);
                            maid.CrossFadeAbsolute("hekimen_tati_sokui_1_f.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                            man.CrossFadeAbsolute("hekimen_tati_sokui_1_m.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                        }

                        if (GUI.Button(new Rect(640, y + 50, 85, 20), "スポット３", gsButton))
                        {
                            maid.transform.position = new Vector3(-2.73f, -0.22f, 2.56f);
                            man.transform.position = new Vector3(-2.73f, -0.22f, 2.56f);
                            maid.transform.eulerAngles = new Vector3(0f, 351f, 0f);
                            man.transform.eulerAngles = new Vector3(0f, 351f, 0f);
                            maid.body0.SetBoneHitHeightY(0f);
                            maid.CrossFadeAbsolute("om_furo_taimenzai_1_f.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                            man.CrossFadeAbsolute("om_furo_taimenzai_1_m.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                        }

                        if (GUI.Button(new Rect(735, y + 50, 85, 20), "スポット４", gsButton))
                        {
                            maid.transform.position = new Vector3(2.6f, -0.1f, 3.9f);
                            man.transform.position = new Vector3(2.6f, -0.1f, 3.9f);
                            maid.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                            man.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                            maid.body0.SetBoneHitHeightY(0f);
                            maid.CrossFadeAbsolute("mp_arai_1_f.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                            man.CrossFadeAbsolute("mp_arai_1_m.anm", GameUty.FileSystem, false, true, false, 0.7f, 1f);
                        }
                    }
                }

            }
            else if (ElGuiFlag == 1)
            {
                node5.x = node2.x;
                node5.y = node2.y - 20;
                if (GUI.Button(new Rect(200, 0, 20, 20), "+", gsButton))
                {
                    ElGuiFlag = 0;
                    node5.width = 840;
                    node5.height = 170;
                    node5.x -= 620;
                    node5.y -= 150;
                }
            }

            GUI.DragWindow();
        }


        //GUI関係終了-------------------------------






        //-------------------------------------------------
        //新 エンパイアズライフ関係------------------------

        private bool el_Overwrite = false;
        private int elErrer = 0;
        private string[] elErrerText = new string[] { "", "背景名が空白のため保存できません", "上書きする場合は『上書／ｸﾘｱ』にチェックを入れて下さい", "クリアする場合は『上書／ｸﾘｱ』にチェックを入れて下さい" };
        private string[] eyeModeText = new string[] { "自動", "顔と目を向ける", "目だけ向ける", "向けない" };
        private string[] timeText = new string[] { "昼", "夜", "共通" };

        EmpiresLifeScene_Xml ELS = new EmpiresLifeScene_Xml();
        List<EmpiresLifeScene_Xml> elsList = new List<EmpiresLifeScene_Xml>();

        public class EmpiresLifeScene_Xml
        {
            public string bgName = "";
            public string bgCode = "";
            public string bgm = "";
            public int timeZone = 0;
            public Color lightColor = new Color(1f, 1f, 1f, 1f);
            public Vector3 cameraPos = new Vector3(0f, 0f, 0f);
            public Vector3 cameraEul = new Vector3(0f, 0f, 0f);

            public List<string> mansMotion = new List<string>();
            public List<int> mansTime = new List<int>();
            public List<Vector3> mansPos = new List<Vector3>();
            public List<Vector3> mansEul = new List<Vector3>();
        }

        EmpiresLifeEvents_Xml ELE = new EmpiresLifeEvents_Xml();
        public class EmpiresLifeEvents_Xml
        {
            public string evName = "";
            public string bgCode = "";
            public int timeZone = 0;

            public List<string> motionSet = new List<string>();
            public List<string> voiceSet = new List<string>();
            public List<bool> ntr = new List<bool>();
            public List<int> mans = new List<int>();
            public List<Vector3> pos = new List<Vector3>();
            public List<Vector3> eul = new List<Vector3>();
            public List<string> faceA = new List<string>();
            public List<string> faceB = new List<string>();
            public List<int> autoP = new List<int>();
            public List<int> eyeMode = new List<int>();
            public List<int> Undress = new List<int>();

            public List<string> handitem = new List<string>();
            public List<string> accvag = new List<string>();
            public List<string> accanl = new List<string>();
        }

        //ライフシーンXMLファイルを読み込む
        private List<string> elsFiles = new List<string>();
        private void LifeSceneLoad()
        {
            List<string> _files = new List<string>();
            string fileName = "";
            string[] files;

            //ライフセットのフォルダ確認
            if (System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\"))
            {
                _files.Clear();
                files = Directory.GetFiles(@"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\", "*.xml");

                foreach (string file in files)
                {
                    fileName = Path.GetFileName(file);
                    if (Regex.IsMatch(fileName, "^els_")) _files.Add(fileName);
                }
                elsFiles = new List<string>(_files);
            }

            elsList.Clear();
            foreach (string file in elsFiles)
            {
                fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\" + file;
                elsList.Add(elsXmlLoad(fileName));
            }
        }

        private void LifeSceneLoad(string bgCode)
        {

            //保存先のファイル名
            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\els_" + bgCode + @".xml";
            Console.WriteLine(fileName);

            if (System.IO.File.Exists(fileName))
            {
                ELS = elsXmlLoad(fileName);

            }
            else
            { //ファイルが存在しない場合に初期ファイルを作成
                LifeSceneSave();
            }
        }

        private EmpiresLifeScene_Xml elsXmlLoad(string fileName)
        {

            EmpiresLifeScene_Xml _els = new EmpiresLifeScene_Xml();

            //XmlSerializerオブジェクトを作成
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EmpiresLifeScene_Xml));
            //読み込むファイルを開く
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));

            //XMLファイルから読み込み、逆シリアル化する
            _els = (EmpiresLifeScene_Xml)serializer.Deserialize(sr);

            //ファイルを閉じる
            sr.Close();
            Console.WriteLine("読み込み完了");

            return _els;
        }

        //ライフイベントXMLファイルを読み込む
        private void LifeEventsLoad(string bgCode, string file)
        {

            //保存先のファイル名
            string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\" + bgCode + @"\ele_" + file + @".xml";
            Console.WriteLine(fileName);

            if (System.IO.File.Exists(fileName))
            {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EmpiresLifeEvents_Xml));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));

                //XMLファイルから読み込み、逆シリアル化する
                ELE = (EmpiresLifeEvents_Xml)serializer.Deserialize(sr);

                //ファイルを閉じる
                sr.Close();
                Console.WriteLine("読み込み完了");
            }
        }

        //ライフシーンをXMLファイルに保存する
        private void LifeSceneSave()
        {

            // フォルダ確認
            if (!System.IO.Directory.Exists(@"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\"))
            {
                //ない場合はフォルダ作成
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(@"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet");
            }


            if (ELS.bgName == "" || ELS.bgCode == "")
            {  //ボイスセット名が空白の場合保存しない
                elErrer = 1;

            }
            else
            {
                //保存先のファイル名
                string fileName = @"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\els_" + ELS.bgCode + @".xml";

                if (System.IO.File.Exists(fileName) && !el_Overwrite)
                {  //上書きのチェック
                    elErrer = 2;

                }
                else
                {

                    //XmlSerializerオブジェクトを作成
                    //オブジェクトの型を指定する
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EmpiresLifeScene_Xml));

                    //書き込むファイルを開く（UTF-8 BOM無し）
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));

                    //シリアル化し、XMLファイルに保存する
                    serializer.Serialize(sw, ELS);
                    //ファイルを閉じる
                    sw.Close();

                    el_Overwrite = false;
                    elErrer = 0;
                }
            }
        }

        //ライフイベントをXMLファイルに保存する
        private void LifeEventsSave()
        {

            // フォルダ確認
            string folder = @"Sybaris\UnityInjector\Config\VibeYourMaid\EmpiresLifeSet\" + ELE.bgCode + @"\";
            if (!System.IO.Directory.Exists(folder))
            {
                //ない場合はフォルダ作成
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(folder);
            }


            if (ELE.evName == "" || ELE.bgCode == "")
            {  //イベント名が空白の場合保存しない
                elErrer = 1;

            }
            else
            {
                //保存先のファイル名
                string fileName = folder + "ele_" + ELE.evName + @".xml";

                if (System.IO.File.Exists(fileName) && !el_Overwrite)
                {  //上書きのチェック
                    elErrer = 2;

                }
                else
                {

                    //XmlSerializerオブジェクトを作成
                    //オブジェクトの型を指定する
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EmpiresLifeEvents_Xml));

                    //書き込むファイルを開く（UTF-8 BOM無し）
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));

                    //シリアル化し、XMLファイルに保存する
                    serializer.Serialize(sw, ELE);
                    //ファイルを閉じる
                    sw.Close();

                    el_Overwrite = false;
                    elErrer = 0;
                }
            }
        }


        private void elsChange(EmpiresLifeScene_Xml els)
        {

            GameMain.Instance.SoundMgr.StopSe();
            GameMain.Instance.SoundMgr.StopBGM(2f);

            GameMain.Instance.MainLight.GetComponent<Light>().color = els.lightColor; //ライト変更

            //全メイドと男を一旦非表示
            GameMain.Instance.CharacterMgr.DeactivateMaidAll();
            GameMain.Instance.CharacterMgr.ResetCharaPosAll();
            foreach (Maid man in SubMans)
            {
                man.Visible = false;
            }

            //背景変更
            Console.WriteLine("背景チェンジ:" + els.bgCode);
            GameMain.Instance.BgMgr.ChangeBg(els.bgCode);

            //カメラ移動
            mainCamera.transform.eulerAngles = els.cameraEul;
            if (!bOculusVR)
            {
                mainCamera.SetPos(els.cameraPos);
                mainCamera.SetTargetPos(els.cameraPos, true);
                mainCamera.SetDistance(0f, true);
            }
            else
            {
                mainCamera.SetPos(els.cameraPos);
            }

            //BGM変更
            GameMain.Instance.SoundMgr.PlayBGMLegacy(els.bgm, 0f, true);

        }


        //新 エンパイアズライフ関係終了------------------------





        //-------------------------------------------------
        //エンパイアズライフ関係---------------------------

        //エンパイアズライフ用変数
        private int bgID = 0;
        private int lifeStart = 0;
        private int danceFlag = 0;
        private bool maidOver = false;
        private bool freeOver = false;
        private bool exclusiveOver = false;
        private int hmID = 0;
        private int[] elMouthMode = new int[] { 0, 0, 0, 0 };
        private bool dCheck = false;
        private int[] eldatui = new int[] { 0, 0, 0, 0 };
        private float[] lifeTime1 = new float[] { 0, 0, 0, 0 };
        private float[] lifeTime2 = new float[] { 0, 0, 0, 0 };
        private float[] lifeTime3 = new float[] { 0, 0, 0, 0 };
        private int[] elvFlag = new int[] { 0, 0, 0, 0 };
        private bool[] elcrFlag = new bool[] { false, false, false, false };
        private bool[] mOnceFlag = new bool[] { false, false, false, false };
        private string[] mOnceBack = new string[] { "", "", "", "" };
        private string[][] mItem = new string[][]{
      new string[]{ "" , "" },
      new string[]{ "" , "" },
      new string[]{ "" , "" },
      new string[]{ "" , "" }
    };

        private int[][] mn = new int[][]{
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1},
      new int[]{-1,-1,-1,-1}
    };
        private List<int[]> holidayMaid = new List<int[]>();

        //モーション , PX , PY , PZ , EX , EY , EZ , 表情 , フェイスブレンド , 床調整 , 着衣 , 視線 , ダンスBGM , ボイスセット , ボイス再生距離 , ボイス再生間隔 , メイドアイテム, NTRブロック
        private string[][] life_f = new string[][]{
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "" , "" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "" , "" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "" , "" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "" , "" , "" , "0" }
        };
        //モーション , PX , PY , PZ , EX , EY , EZ , ターゲットメイド
        private string[][] life_m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
        };

        private string[][] bgArray1 = new string[][]{
          new string[] {"Shitsumu_ChairRot"       , "執務室"                 , "bgm015.ogg"    , "1" , "-0.08" , "1.57" ,  "2.60" , "3.7" , "183.4" , "0" , "1" , "1" }, //00
          new string[] {"Shitsumu_ChairRot_Night" , "執務室（夜）"           , "bgm015.ogg"    , "2" , "-0.08" , "1.57" ,  "2.60" , "3.7" , "183.4" , "0" , "1" , "1" }, //01
          new string[] {"Salon"                   , "サロン"                 , "bgm014.ogg"    , "1" ,  "0.00" , "0.00" , "19.00" , "0.0" , "180" , "0" , "1" , "1" }, //02
          new string[] {"Salon"                   , "サロン（夜）"           , "bgm013.ogg"    , "2" ,  "0.00" , "0.00" , "19.00" , "0.0" , "180" , "0" , "5" , "1" }, //03
          new string[] {"Syosai"                  , "書斎"                   , "bgm007.ogg"    , "1" ,  "4.07" , "1.71" ,  "1.83" , "4.72" , "270.47" , "0" , "1" , "1" }, //04
          new string[] {"Syosai_Night"            , "書斎（夜）"             , "bgm007.ogg"    , "2" ,  "4.07" , "1.71" ,  "1.83" , "4.72" , "270.47" , "0" , "1" , "1" }, //05
          new string[] {"DressRoom_NoMirror"      , "ドレスルーム"           , "bgm014.ogg"    , "1" , "-2.22" , "1.19" ,  "1.96" , "1.92" , "92.93" , "0" , "1" , "1" }, //06
          new string[] {"DressRoom_NoMirror"      , "ドレスルーム（夜）"     , "bgm014.ogg"    , "2" , "-2.22" , "1.19" ,  "1.96" , "1.92" , "92.93" , "0" , "1" , "1" }, //07
          new string[] {"MyBedRoom"               , "自室"                   , "bgm007.ogg"    , "1" , "-3.66" , "1.70" ,  "2.87" , "359.13" , "185.21" , "0" , "1" , "1" }, //08
          new string[] {"MyBedRoom_Night"         , "自室（夜）"             , "bgm011.ogg"    , "2" , "-3.66" , "1.70" ,  "2.87" , "359.13" , "185.21" , "0" , "1" , "1" }, //09
          new string[] {"HoneymoonRoom"           , "ハネムーンルーム（夜）" , "bgm011.ogg"    , "2" , "-2.68" , "1.66" ,  "3.80" , "0" , "157.5" , "0" , "1" , "1" },  //10
          new string[] {"Bathroom"                , "お風呂（夜）"           , "bgm006.ogg"    , "2" ,  "0.07" , "1.46" ,  "0.93" , "4.41" , "180.18" , "0" , "1" , "1" }, //11
          new string[] {"PlayRoom"                , "プレイルーム"           , "bgm014.ogg"    , "1" , "-1.63" , "1.58" , "-5.39" , "1.9" , "358.5" , "0" , "1" , "1" }, //12
          new string[] {"PlayRoom"                , "プレイルーム（夜）"     , "bgm005.ogg"    , "2" , "-1.63" , "1.58" , "-5.39" , "1.9" , "358.5" , "0" , "2" , "1" }, //13
          new string[] {"PlayRoom2"               , "プレイルーム2"          , "bgm014.ogg"    , "1" ,  "0.02" , "1.64" ,  "7.47" , "7.2" , "179.5" , "0" , "1" , "1" }, //14
          new string[] {"PlayRoom2"               , "プレイルーム2（夜）"    , "bgm005.ogg"    , "2" ,  "0.02" , "1.64" ,  "7.47" , "7.2" , "179.5" , "0" , "1" , "1" }, //15
          new string[] {"Pool"                    , "プール"                 , "bgm005.ogg"    , "2" , "17.80" , "2.25" , "15.01" , "359.4" , "269.4" , "0" , "1" , "1" }, //16
          new string[] {"SMRoom"                  , "SMルーム"               , "bgm014.ogg"    , "1" , "-2.08" , "1.43" , "-3.85" , "2.2" , "17.1" , "0" , "1" , "1" }, //17
          new string[] {"SMRoom"                  , "SMルーム（夜）"         , "bgm010.ogg"    , "2" , "-2.08" , "1.43" , "-3.85" , "2.2" , "17.1" , "0" , "1" , "1" }, //18
          new string[] {"SMRoom2"                 , "地下室"                 , "bgm014.ogg"    , "1" ,  "0.12" , "1.53" ,  "4.70" , "5" , "181.1" , "0" , "1" , "1" }, //19
          new string[] {"SMRoom2"                 , "地下室（夜）"           , "bgm026.ogg"    , "2" ,  "0.12" , "1.53" ,  "4.70" , "5" , "181.1" , "0" , "1" , "1" }, //20
          new string[] {"Salon_Garden"            , "中庭"                   , "bgm005.ogg"    , "2" , "-0.09" , "1.50" , "13.20" , "4.1" , "186.7" , "0" , "1" , "1" }, //21
          new string[] {"LargeBathRoom"           , "大浴場"                 , "bgm006.ogg"    , "1" ,  "1.97" , "1.95" ,  "6.08" , "9.69" , "188.74" , "0" , "1" , "1" }, //22
          new string[] {"LargeBathRoom"           , "大浴場（夜）"           , "bgm006.ogg"    , "2" ,  "1.97" , "1.95" ,  "6.08" , "9.69" , "188.74" , "0" , "1" , "1" }, //23
          new string[] {"OiranRoom"               , "花魁部屋"               , "bgm012.ogg"    , "1" , "-0.09" , "1.75" ,  "3.92" , "4.7" , "179.1" , "0" , "1" , "1" }, //24
          new string[] {"OiranRoom"               , "花魁部屋（夜）"         , "bgm012.ogg"    , "2" , "-0.09" , "1.75" ,  "3.92" , "4.7" , "179.1" , "0" , "1" , "1" }, //25
          new string[] {"Penthouse"               , "ペントハウス"           , "bgm005.ogg"    , "2" ,  "1.93" , "1.30" ,  "4.54" , "2.8" , "178.9" , "0" , "1" , "1" }, //26
          new string[] {"Town"                    , "街"                     , "bgm005.ogg"    , "0" , "-7.93" , "2.20" ,  "1.60" , "9" , "92.8" , "0" , "1" , "1" }, //27
          new string[] {"Kitchen"                 , "キッチン"               , "bgm014.ogg"    , "1" , "-2.08" , "1.46" ,  "2.28" , "2.8" , "99.5" , "0" , "1" , "1" }, //28
          new string[] {"Kitchen_Night"           , "キッチン（夜）"         , "bgm014.ogg"    , "2" , "-2.08" , "1.46" ,  "2.28" , "2.8" , "99.5" , "0" , "1" , "1" }, //29
          new string[] {"Salon_Entrance"          , "エントランス"           , "bgm013.ogg"    , "0" , "-0.02" , "1.19" , "-17.4" , "1.6" , "3.5" , "0" , "1" , "1" }, //30
          new string[] {"Salon_Entrance"          , "エントランス（夜）"     , "bgm013.ogg"    , "0" , "-0.02" , "1.19" , "-17.4" , "1.6" , "3.5" , "0" , "1" , "1" }, //31
          new string[] {"poledancestage"          , "ポールダンス"           , "fusionicaddiction_short_pole.ogg"    , "2" , "-0.05" , "1.01" , "-14.5" , "359.7" , "358.5" , "0" , "2" , "1" }, //32
          new string[] {"Bar"                     , "バー（夜）"             , "bgm013.ogg"    , "2" , "-0.13" , "1.57" , "-6.19" , "4.4" , "4.5" , "0" , "1" , "1" },  //33
          new string[] {"Toilet"                  , "トイレ"                 , "bgm014.ogg"    , "1" , "-2.25" , "1.78" ,  "4.43" , "7.51" , "180.77" , "0" , "1" , "1" },  //34
          new string[] {"Toilet"                  , "トイレ（夜）"           , "bgm014.ogg"    , "2" , "-2.25" , "1.78" ,  "4.43" , "7.51" , "180.77" , "0" , "1" , "1" },  //35
          new string[] {"Soap"                    , "ソープ"                 , "bgm011.ogg"    , "1" , "-0.02" , "1.34" , "-7.26" , "0" , "0" , "0" , "1" , "1" },  //36
          new string[] {"Soap"                    , "ソープ（夜）"           , "bgm011.ogg"    , "2" , "-0.02" , "1.34" , "-7.26" , "0" , "0" , "0" , "1" , "1" },  //37
          new string[] {"MaidRoom"                , "メイド部屋"             , "bgm014.ogg"    , "0" ,  "0.10" , "1.53" ,  "2.33" , "5.6" , "183.8" , "0" , "6" , "1" }, //38
          new string[] {"MaidRoom"                , "メイド部屋（夜）"       , "bgm014.ogg"    , "0" ,  "0.10" , "1.53" ,  "2.33" , "5.6" , "183.8" , "0" , "1" , "1" }  //39
	};


        //00：執務室 シーン設定
        private string[][] life00_01f = new string[][]{
      new string[] { "soji_mop.anm|soji_mop_kaiwa.anm" , "-1.3" , "0" , "1" , "0" , "312" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Mop_I_.menu" , "0" },
      new string[] { "soji_zoukin.anm|soji_zoukin_kaiwa_l.anm" , "1" , "0" , "1.5" , "0" , "65" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Zoukin2_I_.menu" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life00_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //01：執務室（夜） シーン設定
        private string[][] life01_01f = new string[][]{
      new string[] { "maid_stand02akubi_ONCE_.anm|maid_dressroom02.anm|maid_stand02ListenB_Unazuki_ONCE_.anm|maid_stand02Listenloop2.anm|maid_stand02tere.anm|maid_stand02sian2_ONCE_.anm|maid_stand02Left_ONCE_.anm|maid_stand02akubi_ONCE_.anm|maid_stand02hair_ONCE_.anm|maid_comehome2_LOOP_.anm" , "1.28" , "0" , "0" , "0" , "272.5" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life01_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //02：サロン シーン設定
        private string[][] life02_01f = new string[][]{
      new string[] { "dance_cm3d_004_kano_f1.anm" , "0" , "0" , "-0.62" , "0" , "0" , "0" , "引きつり笑顔|困った|泣き" , "頬０涙１" , "0" , "0" , "0" , "dummy" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cm3d_004_kano_f1.anm" , "-0.9" , "0" , "0.20" , "0" , "0" , "0" , "引きつり笑顔|困った|泣き" , "頬０涙１" , "0" , "0" , "0" , "dummy" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cm3d_004_kano_f1.anm" , "0.9" , "0" , "0.20" , "0" , "0" , "0" , "通常|笑顔|にっこり|ドヤ顔|ウインク照れ" , "頬０涙０" , "0" , "0" , "0" , "dummy" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "kaiwa_tati_hakusyu_taiki_2_f.anm|kaiwa_tati_hakusyu_taiki_2_f.anm|kaiwa_tati_hakusyu_taiki_2_f.anm|kaiwa_tati_yubisasu_f_ONCE_.anm|kaiwa_tati_kuyasi_f_ONCE_.anm|kaiwa_tati_mo_f_ONCE_.anm|kaiwa_tati_yorokobu_f_ONCE_.anm" , "0" , "0" , "2.04" , "0" , "180" , "0" , "怒り|照れ叫び|ジト目|むー" , "頬０涙０" , "0" , "0" , "1" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life02_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //03：サロン（夜） シーン設定
        private string[][] life03_01f = new string[][]{
      new string[] {"dance_cm3d_001_f1.anm","0","0","0","0","0","0","笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問","頬０涙０","0" , "0" , "1" , "entrancetoyou_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"kaiwa_sofa_kangaeruB_taiki_f.anm|kaiwa_sofa_1_f.anm|kaiwa_sofa_kangaeru_f_ONCE_.anm|kaiwa_sofa_noridasu_2_f_ONCE_.anm|kaiwa_sofa_teawaseA_taiki1_f.anm|kaiwa_sofa_teawase_taiki_f.anm|kaiwa_sofa_tere_taiki_f.anm","-5.67","-1.45","7.91","0","106","0","通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑","頬０涙０","-2" , "0" , "1" , "" , "会話01" , "-1" , "300" , "" , "0" },
      new string[] {"settai_aibu_2_f.anm|settai_aibu_3_f.anm","3.73","-1.46","11.48","0","205","0","エロ羞恥１|エロ羞恥２|興奮射精後１|エロ痛み２|エロ我慢３|まぶたギュ","頬２涙１","-2" , "0" , "2" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] {"om_furo_taimenzai_kiss_2_f.anm|om_furo_taimenzai_kiss_3_f.anm","5.73","-1.47","4.69","0","268","0","エロ羞恥２|エロ羞恥３|エロ好感３|興奮射精後１|発情|エロ興奮３|エロ期待","頬２涙１よだれ","-2" , "3" , "2" , "" , "SEX_A" , "-1" , "0" , "" , "1" }
    };
        private string[][] life03_01m = new string[][]{
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "man_suwarimati1.anm" , "-5.73" , "-1.41" , "8.6" , "0" , "114" , "0" , "1" },
      new string[] { "settai_aibu_2_m.anm|settai_aibu_3_m.anm" , "3.73" , "-1.46" , "11.48" , "0" , "205" , "0" , "2" },
      new string[] { "om_furo_taimenzai_kiss_2_m.anm|om_furo_taimenzai_kiss_3_m.anm" , "5.73" , "-1.47" , "4.69" , "0" , "268" , "0" , "3" }
    };

        private string[][] life03_02f = new string[][]{
      new string[] { "dance_cm3d2_001_f1.anm" , "0" , "0" , "0" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "dokidokifallinlove_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cm3d2_001_f2.anm" , "0" , "0" , "0" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "dokidokifallinlove_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cm3d2_001_f3.anm" , "0" , "0" , "0" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "dokidokifallinlove_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "haimenritui_2_f.anm|haimenritui_2a01_f.anm|haimenritui_2b01_f.anm|haimenritui_2b02_f.anm|haimenritui_3_f.anm|haimenritui_3a01_f.anm|haimenritui_3b01_f.anm|haimenritui_3b02_f.anm" , "-0.77" , "-1.92" , "-4.26" , "0" , "318.3" , "0" , "エロ痛み我慢|エロ羞恥２|興奮射精後１|エロ痛み２|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬２涙１" , "-2" , "3" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" }
    };
        private string[][] life03_02m = new string[][]{
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "haimenritui_2_m.anm|haimenritui_2_m.anm|haimenritui_2_m.anm|haimenritui_2_m.anm|haimenritui_3_m.anm|haimenritui_3_m.anm|haimenritui_3_m.anm|haimenritui_3_m.anm" , "-0.77" , "-1.92" , "-4.26" , "0" , "318.3" , "0" , "3" },
      new string[] { "m_dance000_m.anm" , "0.86" , "-1.94" , "10.25" , "0" , "188.3" , "0" , "0" },
      new string[] { "m_dance000_m.anm" , "-1.11" , "-1.92" , "10.01" , "0" , "172.2" , "0" , "0" }
    };

        private string[][] life03_03f = new string[][]{
      new string[] { "dance_cm3d2_kara_002_cktc_f1.anm" , "0.54" , "0" , "5.58" , "0" , "75.7" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "0" , "can_know_two_close.ogg" , "" , "-1" , "-1" , "handitem,HandItemL_Karaoke_Mike_I_.menu" , "0" },
      new string[] { "dance_cm3d_004_kano_f1.anm" , "-0.75" , "0" , "-0.05" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "can_know_two_close.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cm3d_004_kano_f1.anm" , "0.75" , "0" , "-0.05" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "can_know_two_close.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "jump_s.anm|jump_s.anm|jump_s.anm|[S]turn01_ATOFF_.anm|kaiwa_tati_kuyasi_taiki_1_f.anm|kaiwa_tati_kuyasi_taiki_1_f.anm|kaiwa_tati_yorokobu_f_ONCE_.anm" , "0.50" , "-1.92" , "8.95" , "0" , "186.0" , "0" , "笑顔|にっこり|ドヤ顔|微笑み|ウインク照れ" , "頬１涙０" , "-2" , "0" , "1" , "" , "" , "-1" , "0" , "" , "0" }
    };
        private string[][] life03_03m = new string[][]{
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "m_dance000_m.anm" , "-2.72" , "-1.92" , "8.78" , "0" , "166.2" , "0" , "0" },
          new string[] { "m_dance000_m.anm" , "2.17" , "-1.92" , "10.29" , "0" , "202.6" , "0" , "0" },
          new string[] { "m_dance000_m.anm" , "-1.11" , "-1.92" , "10.01" , "0" , "172.2" , "0" , "0" }
    };

        private string[][] life03_04f = new string[][]{
      new string[] { "dance_cm3d2_kara_001_sl_f1.anm" , "3.42" , "0" , "0.28" , "0" , "177.7" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "0" , "scarlet leap_short.ogg" , "" , "-1" , "-1" , "handitem,HandItemL_Karaoke_Mike_I_.menu" , "0" },
      new string[] { "dance_cm3d_002_end_f1.anm" , "-0.92" , "0" , "-0.48" , "0" , "35" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "scarlet leap_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cm3d_002_end_f1.anm" , "1.02" , "0" , "-0.38" , "0" , "330" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "scarlet leap_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "jump_s.anm|jump_s.anm|jump_s.anm|[S]turn01_ATOFF_.anm|kaiwa_tati_kuyasi_taiki_1_f.anm|kaiwa_tati_kuyasi_taiki_1_f.anm|kaiwa_tati_yorokobu_f_ONCE_.anm" , "0.50" , "-1.92" , "8.95" , "0" , "186.0" , "0" , "笑顔|にっこり|ドヤ顔|微笑み|ウインク照れ" , "頬１涙０" , "-2" , "0" , "1" , "" , "" , "-1" , "0" , "" , "0" }
    };
        private string[][] life03_04m = new string[][]{
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "m_dance000_m.anm" , "-2.72" , "-1.92" , "8.78" , "0" , "166.2" , "0" , "0" },
          new string[] { "m_dance000_m.anm" , "2.17" , "-1.92" , "10.29" , "0" , "202.6" , "0" , "0" },
          new string[] { "m_dance000_m.anm" , "-1.11" , "-1.92" , "10.01" , "0" , "172.2" , "0" , "0" }
    };

        private string[][] life03_05f = new string[][]{
      new string[] { "dance_cmo_001_cg_f1.anm" , "0" , "0" , "0" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "candygirl_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cmo_001_cg_f2.anm" , "0" , "0" , "0" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "candygirl_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "dance_cmo_001_cg_f3.anm" , "0" , "0" , "0" , "0" , "0" , "0" , "笑顔|にっこり|ドヤ顔|ウインク照れ|引きつり笑顔|微笑み|発情|誘惑|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "candygirl_short.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "jump_s.anm|jump_s.anm|jump_s.anm|[S]turn01_ATOFF_.anm|kaiwa_tati_kuyasi_taiki_1_f.anm|kaiwa_tati_kuyasi_taiki_1_f.anm|kaiwa_tati_yorokobu_f_ONCE_.anm" , "0.50" , "-1.92" , "8.95" , "0" , "186.0" , "0" , "笑顔|にっこり|ドヤ顔|微笑み|ウインク照れ" , "頬１涙０" , "-2" , "0" , "1" , "" , "" , "-1" , "0" , "" , "0" }
    };
        private string[][] life03_05m = new string[][]{
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "m_dance000_m.anm" , "-2.72" , "-1.92" , "8.78" , "0" , "166.2" , "0" , "0" },
          new string[] { "m_dance000_m.anm" , "2.17" , "-1.92" , "10.29" , "0" , "202.6" , "0" , "0" },
          new string[] { "m_dance000_m.anm" , "-1.11" , "-1.92" , "10.01" , "0" , "172.2" , "0" , "0" }
    };


        //04：書斎 シーン設定
        private string[][] life04_01f = new string[][]{
          new string[] { "work_saihou.anm" , "-1.139137" , "0.5423361" , "-1.183796" , "0" , "0" , "0" , "ドヤ顔|ジト目|思案伏せ目" , "頬０涙０" , "0" , "0" , "1" , "" , "裁縫" , "-1" , "-1" , "handitem,HandItemD_Shisyuu_Hari_I_.menu" , "0" },
          new string[] { "kaiwa_sofa_kangaeruB_taiki_f.anm|kaiwa_sofa_1_f.anm|kaiwa_sofa_kangaeru_f_ONCE_.anm|kaiwa_sofa_noridasu_2_f_ONCE_.anm|kaiwa_sofa_teawaseA_taiki1_f.anm|kaiwa_sofa_teawase_taiki_f.anm|kaiwa_sofa_tere_taiki_f.anm|kaiwa_sofa_odoroki_taiki_f.anm" , "3.708251" , "0.4274125" , "-0.442423" , "0" , "306.8843" , "0" , "通常|微笑み|にっこり|思案伏せ目|困った|疑問|びっくり" , "頬０涙０" , "0" , "0" , "0" , "" , "会話01" , "-1" , "300" , "" , "0" },
          new string[] { "kaiwa_sofa_kangaeruB_taiki_f.anm|kaiwa_sofa_1_f.anm|kaiwa_sofa_kangaeru_f_ONCE_.anm|kaiwa_sofa_noridasu_2_f_ONCE_.anm|kaiwa_sofa_teawaseA_taiki1_f.anm|kaiwa_sofa_teawase_taiki_f.anm|kaiwa_sofa_tere_taiki_f.anm" , "3.033922" , "0.4356421" , "-1.74213" , "0" , "87.28329" , "0" , "通常|微笑み|にっこり|思案伏せ目|困った|疑問|びっくり" , "頬０涙０" , "0" , "0" , "0" , "" , "会話01" , "-1" , "300" , "" , "0" },
          new string[] { "sleep2.anm" , "-1.119797" , "0.5723807" , "1.035077" , "0" , "173.4105" , "0" , "居眠り安眠|接吻|まぶたギュ" , "頬０涙０" , "0" , "0" , "1" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life04_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //05：書斎（夜） シーン設定
        private string[][] life05_01f = new string[][]{
      new string[] { "midasinami_kesyou_lip_f.anm" , "-2.320528" , "0.5723807" , "1.035077" , "0" , "173.4105" , "0" , "優しさ|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "" , "化粧" , "-1" , "-1" , "handitem,HandItemR_Rip_I_.menu" , "0" },
      new string[] { "midasinami_kesyou_puff_f.anm" , "-1.139137" , "0.5423361" , "-1.072908" , "0" , "0" , "0" , "優しさ|思案伏せ目|疑問|ジト目" , "頬０涙０" , "0" , "0" , "1" , "" , "化粧" , "-1" , "-1" , "handitem,HandItemR_Puff_I_.menu" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" }
    };
        private string[][] life05_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //06：ドレスルーム シーン設定
        private string[][] life06_01f = new string[][]{
          new string[] { "siriname_2_f.anm" , "-2.120155" , "0" , "-1.992422" , "0" , "266.5095" , "0" , "エロ舐め愛情|エロ舌責快楽|エロ舐め快楽" , "頬２涙０" , "0" , "0" , "1" , "" , "フェラ01" , "-1" , "0" , "" , "0" },
          new string[] { "tati_kunni_2_f.anm" , "-2.259117" , "0" , "-1.992422" , "0" , "89.15967" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３|まぶたギュ" , "頬３涙２よだれ" , "0" , "3" , "1" , "" , "SEX01" , "-1" , "0" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life06_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //07：ドレスルーム（夜） シーン設定
        private string[][] life07_01f = new string[][]{
          new string[] { "turn01_ATOFF_.anm" , "-0.9644787" , "0" , "-0.9544698" , "0" , "8.691078" , "0" , "ウインク照れ" , "頬０涙０" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] { "kaiwa_tati_hakusyu_taiki_2_f.anm" , "-0.9416001" , "0" , "0.3957111" , "0" , "186.1866" , "0" , "疑問" , "頬０涙０" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life07_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //08：自室 シーン設定
        private string[][] life08_01f = new string[][]{
      new string[] { "work_bed.anm" , "-0.2246854" , "0.1080843" , "-1.012155" , "0" , "0" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life08_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //09：自室（夜） シーン設定
        private string[][] life09_01f = new string[][]{
      new string[] { "pose_03_f.anm" , "-0.29" , "0.66" , "-1.94" , "0" , "18.7" , "0" , "発情|誘惑|エロ期待|エロ興奮３|優しさ" , "頬１涙０" , "0" , "1" , "0" , "" , "誘惑" , "-1" , "-1" , "" , "0" },
      new string[] { "edit_pose_010_f.anm" , "0.08" , "0.66" , "-0.71" , "0" , "276.3" , "0" , "発情|誘惑|エロ期待|エロ興奮３|優しさ" , "頬１涙０" , "0" , "1" , "0" , "" , "誘惑" , "-1" , "-1" , "" , "0" },
      new string[] { "fera_onani_2_f.anm" , "-0.5006242" , "0" , "2.292451" , "0" , "177.9255" , "0" , "絶頂射精後１" , "頬３涙０" , "0" , "3" , "1" , "" , "SEX01" , "2.5" , "0" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    }; private string[][] life09_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //10：ハネムーンルーム（夜） シーン設定
        private string[][] life10_01f = new string[][]{
      new string[] { "onani_1_f.anm" , "0.24" , "0.47" , "-1.51" , "0" , "320.2" , "0" , "発情|誘惑|エロ期待|エロ興奮３|優しさ" , "頬１涙０" , "0" , "1" , "0" , "" , "誘惑" , "-1" , "-1" , "" , "0" },
      new string[] { "sleep1.anm" , "3.47" , "0.39" , "-2.06" , "0" , "347.3" , "0" , "発情|誘惑|エロ期待|エロ興奮３|優しさ" , "頬２涙０" , "0" , "1" , "0" , "" , "誘惑" , "-1" , "-1" , "" , "0" },
      new string[] { "pose_ero_06_loop_f.anm" , "-6.24" , "0.42" , "-0.46" , "0" , "60.9" , "0" , "発情|誘惑|エロ期待|エロ興奮３|優しさ" , "頬１涙０" , "0" , "1" , "0" , "" , "誘惑" , "-1" , "-1" , "" , "0" },
      new string[] { "yorisoi_sokui_hibuhiraki_1_f.anm" , "-0.63" , "0.42" , "-1.54" , "0" , "318.4" , "0" , "発情|誘惑|エロ期待|エロ興奮３|優しさ" , "頬１涙０" , "0" , "1" , "0" , "" , "誘惑" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life10_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //11：風呂（夜） シーン設定
        private string[][] life11_01f = new string[][]{
          new string[] { "mp_arai_tekoki_2_f.anm|mp_arai_2_f.anm|mp_arai_kiss_f.anm|mp_arai_tikubiname_2_f.anm|mp_arai_asiname_2_f.anm|mp2_siri_f.anm|mp2_sakasaarai_f.anm|mp2_sumata_f.anm" , "-0.9051085" , "0" , "-1.240942" , "0" , "127.0402" , "0" , "エロ羞恥２|エロ羞恥３|エロ好感３|興奮射精後１|発情|エロ興奮３|エロ期待" , "頬２涙１よだれ" , "0" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] { "taimenzai_2_f.anm|taimenzai_kiss2_f.anm|taimenzai_momi_2_f.anm|taimenzai_3_f.anm|taimenzai_kiss3_f.anm|taimenzai_momi_3_f.anm" , "0.70387" , "-0.5754409" , "-3.30988" , "0" , "355.7758" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ痛み２|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬３涙１" , "-1" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life11_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
          new string[] { "mp_arai_tekoki_2_m.anm|mp_arai_2_m.anm|mp_arai_kiss_m.anm|mp_arai_tikubiname_2_m.anm|mp_arai_asiname_2_m.anm|mp2_siri_m.anm|mp2_sakasaarai_m.anm|mp2_sumata_m.anm" , "-0.9051085" , "0" , "-1.240942" , "0" , "127.0402" , "0" , "0" },
          new string[] { "taimenzai_2_m.anm|taimenzai_kiss2_m.anm|taimenzai_momi_2_m.anm|taimenzai_3_m.anm|taimenzai_kiss3_m.anm|taimenzai_momi_3_m.anm" , "0.70387" , "-0.5754409" , "-3.30988" , "0" , "355.7758" , "0" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //12：プレイルーム シーン設定
        private string[][] life12_01f = new string[][]{
      new string[] { "soji_hakisouji.anm" , "-1.35" , "-0.04" , "-1.343" , "0" , "318.4" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Houki_I_.menu" , "0" },
      new string[] { "soji_tukuefuki_salon.anm" , "1.88" , "0.50" , "0.22" , "0" , "88.5" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Zoukin2_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life12_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //13：プレイルーム（夜） シーン設定
        private string[][] life13_01f = new string[][]{
      new string[] { "seijyoui_kiss_2_f.anm|j_seijyoui_kiss_2a01_f.anm|k_seijyoui_kiss_2a01_f.anm|t_seijyoui_kiss_2a01_f.anm|seijyoui_kiss_2a01_f.anm|seijyoui_daki_kiss_2_f.anm|seijyoui_2_f.anm|seijyoui_2e01_f.anm|seijyoui_2e02_f.anm|j_seijyoui_2_f.anm|k_seijyoui_2_f.anm|t_seijyoui_2_f.anm|seijyoui_3_f.anm|seijyoui_3e01_f.anm|seijyoui_3e02_f.anm|j_seijyoui_3_f.anm|k_seijyoui_3_f.anm|t_seijyoui_3_f.anm" , "0.95" , "0.5" , "1.92" , "0" , "272.9" , "0" , "エロ羞恥２|エロ羞恥３|エロ好感３|興奮射精後１|発情|エロ興奮３|エロ期待" , "頬２涙１" , "0" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life13_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "seijyoui_kiss_2_m.anm|j_seijyoui_kiss_2a01_m.anm|k_seijyoui_kiss_2a01_m.anm|t_seijyoui_kiss_2a01_m.anm|seijyoui_kiss_2a01_m.anm|seijyoui_daki_kiss_2_m.anm|seijyoui_2_m.anm|seijyoui_2e01_m.anm|seijyoui_2e02_m.anm|j_seijyoui_2_m.anm|k_seijyoui_2_m.anm|t_seijyoui_2_m.anm|seijyoui_3_m.anm|seijyoui_3e01_m.anm|seijyoui_3e02_m.anm|j_seijyoui_3_m.anm|k_seijyoui_3_m.anm|t_seijyoui_3_m.anm" , "0.95" , "0.5" , "1.92" , "0" , "272.9" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life13_02f = new string[][]{
      new string[] { "kouhaii_3_f.anm|kouhaii_3a01_f.anm|kouhaii_3b01_f.anm|kouhaii_3b02_f.anm|kouhaii_cli_3_f.anm|kouhaii_daki_3_f.anm|kouhaii_siri_3_f.anm" , "0.77" , "0.5" , "1.92" , "0" , "272.9" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３" , "頬３涙２" , "0" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life13_02m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "kouhaii_3_m.anm|kouhaii_3_m.anm|kouhaii_3_m.anm|kouhaii_3_m.anm|kouhaii_cli_3_m.anm|kouhaii_daki_3_m.anm|kouhaii_siri_3_m.anm" , "0.77" , "0.5" , "1.92" , "0" , "272.9" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //14：プレイルーム2 シーン設定
        private string[][] life14_01f = new string[][]{
      new string[] { "midasinami_moyougae_f.anm" , "-4.50" , "0" , "-1.35" , "0" , "242.1" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "" , "0" },
          new string[] { "soji_hataki_kaiwa_r.anm" , "3.20" , "0" , "-1.32" , "0" , "110.3" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Dance_Hataki_I_.menu" , "0" },
          new string[] { "soji_tukuefuki_salon.anm" , "-2.06" , "0.42" , "5.3" , "0" , "297.1" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Zoukin2_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life14_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //15：プレイルーム2（夜） シーン設定
        private string[][] life15_01f = new string[][]{
      new string[] {"harem_sex_2_f.anm" , "0" , "0.58" , "-1.38" , "0" , "180" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３|まぶたギュ" , "頬２涙１" , "0" , "1" , "1" , "" , "SEX02" , "-1" , "0" , "" , "1" },
      new string[] {"harem_sex_2_f2.anm" , "0" , "0.58" , "-1.38" , "0" , "180" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ痛み２|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬２涙１" , "0" , "1" , "1" , "" , "SEX01" , "-1" , "0" , "" , "1" },
      new string[] {"harem_sex_2_f3.anm" , "0" , "0.58" , "-1.38" , "0" , "180" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ痛み２|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬２涙１" , "0" , "1" , "1" , "" , "SEX01" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life15_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"harem_sex_2_m.anm" , "0" , "0.58" , "-1.38" , "0" , "180" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //16：プール シーン設定
        private string[][] life16_01f = new string[][]{
      new string[] { "sixnine_2_f.anm|sixnine_2a01_f.anm|paizuri_69_2_f.anm|paizuri_69_kunni_f.anm|paizuri_fera_69_2_f.anm" , "4.25" , "0.37" , "10" , "0" , "180" , "0" , "エロ羞恥２|エロ羞恥３|エロ好感３|興奮射精後１|発情|エロ興奮３|エロ期待" , "頬２涙１よだれ" , "0" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] { "hekimen_tati_sokui_2_f.anm|hekimen_tati_sokui_3_f.anm|hekimen_tati_sokui_kiss_2_f.anm|hekimen_tati_sokui_kiss_2a01_f.anm|hekimen_tati_sokui_kiss_3_f.anm|hekimen_tati_sokui_kiss_3a01_f.anm" , "10.43" , "-0.47" , "0.5" , "0" , "91.4" , "0" , "エロ羞恥２|エロ羞恥３|エロ好感３|興奮射精後１|発情|エロ興奮３|エロ期待" , "頬２涙１" , "-1" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life16_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "sixnine_2_m.anm|sixnine_2_m.anm|paizuri_69_2_m.anm|paizuri_69_kunni_m.anm|paizuri_fera_69_2_m.anm" , "4.25" , "0.37" , "10" , "0" , "180" , "0" , "0" },
      new string[] { "hekimen_tati_sokui_2_m.anm|hekimen_tati_sokui_3_m.anm|hekimen_tati_sokui_kiss_2_m.anm|hekimen_tati_sokui_kiss_2a01_m.anm|hekimen_tati_sokui_kiss_3_m.anm|hekimen_tati_sokui_kiss_3a01_m.anm" , "10.43" , "-0.47" , "0.5" , "0" , "91.4" , "0" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //17：SMルーム シーン設定
        private string[][] life17_01f = new string[][]{
      new string[] { "soji_hataki_kaiwa_r.anm|soji_hataki_kaiwa_r.anm|maid_stand02ListenB_ONCE_.anm" , "-2.29" , "0" , "2.61" , "0" , "275.2" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Dance_Hataki_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life17_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //18：SMルーム（夜） シーン設定
        private string[][] life18_01f = new string[][]{
      new string[] { "harituke_3_f.anm|harituke_3_f.anm|harituke_zeccyou_f_once_.anm" , "-0.97" , "0" , "1.22" , "0" , "180" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３|まぶたギュ" , "頬３涙３よだれ" , "0" , "1" , "1" , "" , "SEX03" , "-1" , "0" , "kousoku_upper,KousokuU_SMRoom_Haritsuke_I_.menu|kousoku_lower,KousokuL_AshikaseUp_I_.menu|accvag,accVag_VibeBig_I_.menu" , "1" },
      new string[] { "x_manguri_vibe_oku_3_f.anm|x_manguri_vibe_zeccyou_f_once_.anm" , "0.75" , "0.32" , "-0.19" , "0" , "109.7" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３|まぶたギュ" , "頬３涙３" , "0" , "1" , "1" , "" , "SEX02" , "-1" , "0" , "kousoku_upper,KousokuU_TekaseOne_I_.menu|kousoku_lower,KousokuL_AshikaseUp_I_.menu|accvag,accVag_VibeBig_I_.menu" , "1"  },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life18_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "harituke_3_m.anm|harituke_3_m.anm|harituke_zeccyou_m_once_.anm" , "-0.97" , "0" , "1.22" , "0" , "180" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //19：地下室 シーン設定
        private string[][] life19_01f = new string[][]{
      new string[] { "soji_mop.anm" , "0.22" , "0" , "1.07" , "0" , "57.3" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemR_Mop_I_.menu" , "0" },
          new string[] { "fukisouji1.anm" , "-3.66" , "0" , "-1.42" , "0" , "264.5" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "掃除" , "-1" , "-1" , "handitem,HandItemL_Zoukin2_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life19_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //20：地下室（夜） シーン設定
        private string[][] life20_01f = new string[][]{
      new string[] {"muri_6p_aibu_2_f.anm|muri_6p_aibu_3_f.anm|muri_6p_aibu_kunni_2_f.anm|muri_6p_aibu_kunni_3_f.anm|muri_6p_seijyoui_2a01_f.anm|muri_6p_seijyoui_3a01_f.anm|muri_6p_seijyoui_3ana_2_f.anm|muri_6p_seijyoui_3ana_3_f.anm" , "0" , "0.146" , "-1.55" , "0" , "0" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロ痛み１|エロ痛み２|エロ痛み３|エロ羞恥３" , "頬３涙３よだれ" , "0" , "1" , "1" , "" , "SEX03" , "-1" , "0" , "kousoku_upper,KousokuU_TekaseOne_I_.menu|kousoku_lower,KousokuL_AshikaseUp_I_.menu" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life20_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "muri_6p_aibu_2_m.anm|muri_6p_aibu_3_m.anm|muri_6p_aibu_kunni_2_m.anm|muri_6p_aibu_kunni_3_m.anm|muri_6p_seijyoui_2_m.anm|muri_6p_seijyoui_3_m.anm|muri_6p_seijyoui_3ana_2_m.anm|muri_6p_seijyoui_3ana_3_m.anm" , "0" , "0.146" , "-1.55" , "0" , "0" , "0" , "0" },
          new string[] { "muri_6p_aibu_2_m2.anm|muri_6p_aibu_3_m2.anm|muri_6p_aibu_kunni_2_m2.anm|muri_6p_aibu_kunni_3_m2.anm|muri_6p_seijyoui_2_m2.anm|muri_6p_seijyoui_3_m2.anm|muri_6p_seijyoui_3ana_2_m2.anm|muri_6p_seijyoui_3ana_3_m21.anm" , "0" , "0.146" , "-1.55" , "0" , "0" , "0" , "0" },
          new string[] { "muri_6p_aibu_2_m5.anm|muri_6p_aibu_3_m5.anm|muri_6p_aibu_kunni_2_m5.anm|muri_6p_aibu_kunni_3_m5.anm|muri_6p_seijyoui_2_m5.anm|muri_6p_seijyoui_3_m5.anm|muri_6p_seijyoui_3ana_2_m5.anm|muri_6p_seijyoui_3ana_3_m5.anm" , "0" , "0.1468" , "-1.55" , "0" , "0" , "0" , "0" }
    };


        //21：中庭" シーン設定
        private string[][] life21_01f = new string[][]{
      new string[] { "[S]inu_omocya_aruki_f_ONCE_.anm" , "-1.98" , "0" , "0" , "0" , "180" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３|まぶたギュ" , "頬３涙２" , "0" , "1" , "0" , "" , "SEX01" , "-1" , "-1" , "accvag,accVag_Vibe_I_.menu|accanl,accAnl_Photo_VibePink_I_.menu" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life21_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "man_porse01.anm" , "-1.98" , "0" , "0.42" , "0" , "180" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //22：大浴場 シーン設定
        private string[][] life22_01f = new string[][]{
          new string[] { "j_taimenkijyoui_momi_1a01_f.anm" , "-3.584383" , "0" , "0.3971604" , "6.920276" , "83.96275" , "0" , "にっこり" , "頬２涙０" , "0" , "1" , "1" , "" , "風呂" , "-1" , "-1" , "" , "0" },
          new string[] { "senakanagasi_f.anm" , "-3.909705" , "0" , "0.4116318" , "4.166075" , "275.2422" , "0" , "笑顔" , "頬１涙０" , "0" , "1" , "1" , "" , "" , "-1" , "-1" , "handitem,HandItemR_Zoukin2_I_.menu" , "0" },
          new string[] { "sit_tukue.anm" , "1.396726" , "0.09520975" , "-1.849392" , "0" , "89.57285" , "0" , "誘惑" , "頬２涙０" , "0" , "1" , "0" , "" , "風呂" , "-1" , "-1" , "" , "0" },
          new string[] { "syagami_pose_f.anm" , "2.150745" , "-0.4503197" , "-0.7838227" , "0" , "113.13" , "0" , "ためいき" , "頬３涙０" , "-1" , "1" , "1" , "" , "風呂" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life22_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //23：大浴場（夜） シーン設定
        private string[][] life23_01f = new string[][]{
      new string[] { "itya_aibu_2_f.anm|itya_aibu_cli_2_f.anm|itya_aibu_kiss_2_f.anm|aibu_hibu_2_f.anm|aibu_tikubi_2_f.anm|itya_aibu_3_f.anm|itya_aibu_cli_3_f.anm|itya_aibu_kiss_3_f.anm|aibu_hibu_3_f.anm|aibu_tikubi_3_f.anm" , "2.05" , "-0.48" , "-2.84" , "0" , "92.6" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ痛み２|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬３涙１" , "-0.5" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
          new string[] { "arai2_tubo_1_f.anm|arai2_tubo_2_f.anm|arai2_tawasi_1_f.anm|arai2_tawasi_2_f.anm|arai2_mune_2_f.anm" , "-3.67" , "0" , "2.00" , "0" , "5.6" , "0" , "エロメソ泣き|エロ羞恥２|興奮射精後１|発情|エロ羞恥３|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬２涙１" , "0" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
          new string[] { "senboukyou_fera_1_kiss_f.anm|senboukyou_fera_1_sentan_f.anm|senboukyou_fera_1_name_f.anm|senboukyou_fera_1_name_ura_f.anm|senboukyou_fera_2_f.anm|senboukyou_fera_3_f.anm|senboukyou_fera_shasei_kao_f_ONCE_.anm" , "-0.86" , "-0.27" , "-4.09" , "0" , "182.3" , "0" , "エロ舐め愛情|エロ舌責快楽|エロ舐め快楽" , "頬２涙０" , "-0.5" , "1" , "1" , "" , "フェラ01" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life23_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "itya_aibu_2_m.anm|itya_aibu_cli_2_m.anm|itya_aibu_kiss_2_m.anm|aibu_hibu_2_m.anm|aibu_tikubi_2_m.anm|itya_aibu_3_m.anm|itya_aibu_cli_3_m.anm|itya_aibu_kiss_3_m.anm|aibu_hibu_3_m.anm|aibu_tikubi_3_m.anm" , "2.05" , "-0.48" , "-2.84" , "0" , "92.6" , "0" , "0" },
          new string[] { "arai2_tubo_1_m.anm|arai2_tubo_2_m.anm|arai2_tawasi_1_m.anm|arai2_tawasi_2_m.anm|arai2_mune_2_m.anm" , "-3.67" , "-0.05" , "2.00" , "0" , "5.6" , "0" , "1" },
          new string[] { "senboukyou_fera_1_kiss_m.anm|senboukyou_fera_1_sentan_m.anm|senboukyou_fera_1_name_m.anm|senboukyou_fera_1_name_ura_m.anm|senboukyou_fera_2_m.anm|senboukyou_fera_3_m.anm|senboukyou_fera_shasei_kao_m_ONCE_.anm" , "-0.86" , "-0.27" , "-4.09" , "0" , "182.3" , "0" , "2" }
    };


        //24：花魁部屋 シーン設定
        private string[][] life24_01f = new string[][]{
      new string[] {"edit_pose_010_f.anm" , "0.16" , "0.14" , "-4.24" , "0" , "299.2" , "0" , "居眠り安眠|接吻" , "頬０涙０" , "0" , "0" , "1" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life24_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //25：花魁部屋（夜） シーン設定
        private string[][] life25_01f = new string[][]{
      new string[] { "settai_kiss_2_f.anm" , "0" , "0.23" , "-1.11" , "0" , "0" , "0" , "エロ舐め愛情|エロ舌責快楽|エロ舐め快楽" , "頬２涙０" , "0" , "1" , "1" , "" , "キス01" , "-1" , "0" , "" , "1" },
      new string[] { "taimenkijyoui_gr_2_f.anm" , "0" , "0.31" , "-1.17" , "0" , "0" , "0" , "エロメソ泣き|エロ羞恥２|興奮射精後１|発情|エロ羞恥３|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬２涙１" , "0" , "1" , "1" , "" , "SEX01" , "-1" , "0" , "" , "1" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life25_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "settai_kiss_2_m.anm" , "0" , "0.23" , "-1.11" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //26：ペントハウス シーン設定
        private string[][] life26_01f = new string[][]{
      new string[] { "haimenritui_2_f.anm|haimenritui_2a01_f.anm|haimenritui_2b01_f.anm|haimenritui_2b02_f.anm|haimenritui_3_f.anm|haimenritui_3a01_f.anm|haimenritui_3b01_f.anm|haimenritui_3b02_f.anm|haimenritui_cli_2_f.anm|haimenritui_cli_3_f.anm" , "-6.93" , "-0.52" , "-5.51" , "0" , "87" , "0" , "エロメソ泣き|エロ羞恥２|興奮射精後１|発情|エロ痛み２|引きつり笑顔|エロ我慢３|まぶたギュ" , "頬３涙２" , "-0.5" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
          new string[] { "kousokudai_kunni_2_f.anm|kousokudai_kunni_3_f.anm" , "-0.31" , "-0.15" , "2.26" , "0" , "181" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３|まぶたギュ" , "頬２涙２" , "0" , "1" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "1" },
          new string[] { "wfera_2_f.anm" , "3.97" , "0.039" , "-0.62" , "0" , "259.2" , "0" , "エロ舐め愛情|エロ舌責快楽|エロ舐め快楽" , "頬１涙０" , "0" , "1" , "1" , "" , "フェラ01" , "-1" , "0" , "" , "1" },
          new string[] { "wfera_2_f2.anm" , "3.97" , "0.039" , "-0.62" , "0" , "259.2" , "0" , "エロ舐め愛情|エロ舌責快楽|エロ舐め快楽" , "頬１涙０" , "0" , "1" , "1" , "" , "フェラ01" , "-1" , "0" , "" , "1" }
    };
        private string[][] life26_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "haimenritui_2_m.anm|haimenritui_2_m.anm|haimenritui_2_m.anm|haimenritui_2_m.anm|haimenritui_3_m.anm|haimenritui_3_m.anm|haimenritui_3_m.anm|haimenritui_3_m.anm|haimenritui_cli_2_m.anm|haimenritui_cli_3_m.anm" , "-6.93" , "-0.55" , "-5.51" , "0" , "87" , "0" , "0" },
          new string[] { "kousokudai_kunni_2_m.anm|kousokudai_kunni_3_m.anm" , "-0.31" , "-0.31" , "2.26" , "0" , "181" , "0" , "1" },
          new string[] { "wfera_2_m.anm" , "3.970175" , "0.03" , "-0.62" , "0" , "259.2" , "0" , "2" }
    };


        //27：街 シーン設定
        private string[][] life27_01f = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life27_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //28：キッチン シーン設定
        private string[][] life28_01f = new string[][]{
      new string[] { "work_ryouri_houtyou.anm" , "-0.93" , "0" , "-2.22" , "0" , "180" , "0" , "思案伏せ目" , "頬０涙０" , "0" , "0" , "0" , "" , "料理" , "-1" , "-1" , "handitem,HandItemR_Houchou_I_.menu" , "0" },
      new string[] { "soji_syokkiarai.anm" , "1.91" , "-0.05" , "0.25" , "0" , "90.4" , "0" , "微笑み" , "頬０涙０" , "0" , "0" , "0" , "" , "料理" , "-1" , "-1" , "handitem,HandItemD_Sara_Sponge_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life28_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //29：キッチン（夜） シーン設定
        private string[][] life29_01f = new string[][]{
      new string[] { "kyousitu_aibu_kutiosae_1_f.anm" , "2.16" , "0.08" , "-0.87" , "0" , "264.3" , "0" , "エロ痛み我慢３" , "頬２涙１" , "0" , "3" , "0" , "" , "SEX01" , "-1" , "0" , "" , "0" },
          new string[] { "siriname_1_f.anm" , "2.02" , "0.019" , "-0.87" , "0" , "84.3" , "0" , "エロ舐め愛情" , "頬２涙０" , "0" , "0" , "1" , "" , "フェラ01" , "-1" , "0" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life29_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //30：エントランス シーン設定
        private string[][] life30_01f = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life30_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //31：エントランス（夜） シーン設定
        private string[][] life31_01f = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life31_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //モーション , PX , PY , PZ , EX , EY , EZ , 表情 , フェイスブレンド , 床調整 , 着衣 , 視線 , ダンスBGM , ボイスセット , ボイス再生距離 , ボイス再生間隔 , メイドアイテム, NTRブロック
        //32：ポールダンス シーン設定
        private string[][] life32_01f = new string[][]{
      new string[] {"dance_cm3d21_pole_001_fa_f1.anm" , "0.16" , "0" , "0.18" , "0" , "180" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬１涙０" , "0" , "0" , "-1" , "fusionicaddiction_short_pole.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"dance_cm3d21_pole_001_fa_f1.anm" , "-4.44" , "0" , "2.01" , "0" , "137.7" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬１涙０" , "0" , "0" , "-1" , "fusionicaddiction_short_pole.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"dance_cm3d21_pole_001_fa_f1.anm" , "4.76" , "0" , "2.01" , "0" , "214" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬１涙０" , "0" , "0" , "-1" , "fusionicaddiction_short_pole.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life32_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life32_02f = new string[][]{
      new string[] {"dance_cm3d21_pole_002_lc_f1.anm" , "0.16" , "0" , "0.18" , "0" , "180" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬１涙０" , "0" , "0" , "-1" , "lovemorecrymore_short_pole.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"dance_cm3d21_pole_002_lc_f2.anm" , "-4.44" , "0" , "2.01" , "0" , "137.7" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬１涙０" , "0" , "0" , "-1" , "lovemorecrymore_short_pole.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"dance_cm3d21_pole_002_lc_f3.anm" , "4.76" , "0" , "2.01" , "0" , "214" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬１涙０" , "0" , "0" , "-1" , "lovemorecrymore_short_pole.ogg" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life32_02m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //33：バー（夜） シーン設定
        private string[][] life33_01f = new string[][]{
      new string[] { "kaiwa_tati_taiki_f.anm|kaiwa_tati_teawase_f_ONCE_.anm|kaiwa_tati_teawase_taiki_f.anm|kaiwa_tati_hutuu1_taiki_f.anm|kaiwa_tati_ayamaru_f_ONCE_.anm|maid_comehome2_LOOP_.anm|maid_stand02Kaiwa2_ONCE_.anm|kaiwa_tati_hohokaki_taiki_f.anm|kaiwa_tati_tutorial_1_taiki_f.anm" , "-3.17" , "0" , "1.60" , "0" , "89.0" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬０涙０" , "0" , "0" , "-1" , "" , "会話01" , "-1" , "300" , "" , "0" },
      new string[] { "work_mimi_f.anm" , "1.03" , "0.55" , "4.67" , "0" , "88.0" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬０涙０" , "0" , "0" , "-1" , "" , "会話01" , "-1" , "300" , "handitem,HandItemR_Mimikaki_I_.menu" , "0" },
      new string[] { "op_wine_taiki_f.anm|op_wine_taiki_f.anm|op_wine_taiki_f.anm|op_wine_nomu_f_ONCE_.anm|op_wine_nomu_f_ONCE_.anm|op_wine_kanpai_f_ONCE_.anm" , "2.85" , "0.53" , "-1.12" , "0" , "271.3" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬０涙０" , "0" , "0" , "-1" , "" , "会話01" , "-1" , "300" , "handitem,HandItemR_WineGlass_I_.menu" , "0" },
      new string[] { "work_demukae_b.anm|kaiwa_tati_hutuu1_taiki_f.anm|kaiwa_tati_teawase_taiki_f.anm|maid_ojigi02_ONCE_.anm|maid_stand02hair_ONCE_.anm|maid_stand02Left_ONCE_.anm" , "0.47" , "0" , "-2.96" , "0" , "229.8" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life33_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "man_suwarimati1.anm" , "-1.47" , "0.71" , "1.70" , "0" , "267.5" , "0" , "0" },
      new string[] { "work_mimi_itazurago_m.anm" , "1.04" , "0.55" , "4.66" , "0" , "88.0" , "0" , "1" },
      new string[] { "man_suwarimati1.anm" , "3.24" , "0.53" , "-1.70" , "0" , "264.0" , "0" , "2" }
    };


        //34：トイレ シーン設定
        private string[][] life34_01f = new string[][]{
          new string[] { "toilet_onani_2_f.anm|toilet_onani_3_f.anm" , "-3.228128" , "0.1530618" , "0.2837493" , "0" , "87.56886" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ興奮３" , "頬３涙１" , "0" , "3" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life34_01m = new string[][]{
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //35：トイレ（夜） シーン設定
        private string[][] life35_01f = new string[][]{
          new string[] { "toilet_sex_2_f.anm|toilet_sex_3_f.anm" , "-3.228128" , "0.1530618" , "0.2837493" , "0" , "87.56886" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ興奮３" , "頬３涙２" , "0" , "3" , "1" , "" , "SEX_A" , "4" , "0" , "" , "1" },
          new string[] { "fera_onani_2_f.anm|fera_onani_3_f.anm" , "-2.581944" , "0.01027089" , "-4.653751" , "0" , "180" , "0" , "エロ羞恥２|興奮射精後１|発情|エロ興奮３" , "頬２涙１よだれ" , "0" , "3" , "1" , "" , "SEX_A" , "4" , "0" , "" , "1" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
          new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life35_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
          new string[] { "toilet_sex_2_m.anm|toilet_sex_3_m.anm" , "-3.228128" , "0.1530618" , "0.2837493" , "0" , "87.56886" , "0" , "0" },
          new string[] { "fera_onani_2_m.anm|fera_onani_3_m.anm" , "-2.581944" , "-0.0902865" , "-4.653751" , "0" , "180" , "0" , "1" },
          new string[] { "fera_miage_1_sentan_m.anm" , "3.571411" , "-0.08703265" , "-0.7674932" , "0" , "271.1132" , "0" , "0" }
    };


        //36：ロッカールーム シーン設定
        private string[][] life36_01f = new string[][]{
	  //new string[] { "maid_stand02akubi_ONCE_.anm|maid_dressroom02.anm|maid_stand02ListenB_Unazuki_ONCE_.anm|maid_stand02Listenloop2.anm|maid_stand02tere.anm|maid_stand02sian2_ONCE_.anm|maid_stand02Left_ONCE_.anm|maid_stand02akubi_ONCE_.anm|maid_stand02hair_ONCE_.anm|maid_comehome2_LOOP_.anm" , "1.28" , "0" , "0" , "0" , "272.5" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
	  new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life36_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //37：ロッカールーム（夜） シーン設定
        private string[][] life37_01f = new string[][]{
	  //new string[] { "maid_stand02akubi_ONCE_.anm|maid_dressroom02.anm|maid_stand02ListenB_Unazuki_ONCE_.anm|maid_stand02Listenloop2.anm|maid_stand02tere.anm|maid_stand02sian2_ONCE_.anm|maid_stand02Left_ONCE_.anm|maid_stand02akubi_ONCE_.anm|maid_stand02hair_ONCE_.anm|maid_comehome2_LOOP_.anm" , "1.28" , "0" , "0" , "0" , "272.5" , "0" , "通常|微笑み|笑顔|にっこり|優しさ|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
	  new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] { "" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life37_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //38：メイド部屋 シーン設定
        private string[][] life38_01f = new string[][]{
      new string[] {"edit_pose_010_f.anm" , "2.09" , "0.51" , "-1.91" , "0" , "223.5" , "0" , "居眠り安眠|接吻" , "頬０涙０" , "0" , "0" , "1" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life38_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life38_02f = new string[][]{
          new string[] { "work_saihou.anm" , "1.47" , "0.55" , "-1.53" , "0" , "270.9" , "0" , "ドヤ顔|ジト目|思案伏せ目" , "頬０涙０" , "0" , "0" , "0" , "" , "裁縫" , "-1" , "-1" , "handitem,HandItemD_Shisyuu_Hari_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life38_02m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life38_03f = new string[][]{
      new string[] { "midasinami_kesyou_lip_f.anm" , "2.27" , "0.53" , "2.03" , "0" , "348.6" , "0" , "優しさ|思案伏せ目|疑問" , "頬０涙０" , "0" , "0" , "1" , "" , "化粧" , "-1" , "-1" , "handitem,HandItemR_Rip_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life38_03m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life38_04f = new string[][]{
      new string[] { "pose_kakkoii_01_loop_f.anm|pose_kakkoii_06_loop_f.anm|[S]pose_kawaii_01_loop_f.anm|[S]pose_kawaii_03_loop_f.anm|edit_pose_005_f.anm|[S]edit_pose_008_f.anm|[S]edit_pose_009_f.anm|stand_akire.anm|[S]edit_pose_036_f.anm|[S]edit_pose_ke17_002_f.anm|[S]edit_pose_dg17s_003_f.anm|maid_dressroom02.anm|maid_comehome4_Gatsu_ONCE_.anm|maid_stand02hair_ONCE_.anm|maid_stand02sian2_ONCE_.anm|[S]turn01_ATOFF_.anm|kaiwa_tati_appeal_f_ONCE_.anm" , "1.62" , "0.012" , "0.65" , "0" , "87.7" , "0" , "通常|微笑み|にっこり|思案伏せ目|発情|困った|疑問|誘惑" , "頬０涙０" , "0" , "2" , "1" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life38_04m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life38_05f = new string[][]{
          new string[] { "onani_2_f.anm|onani_cli_2_f.anm|onani2_1_f.anm|onani2_cli_1_f.anm|onani_3_f.anm|onani_cli_3_f.anm|onani2_1_f.anm|onani3_cli_1_f.anm" , "1.85" , "0.50" , "-1.30" , "0" , "348.6" , "0" , "エロ羞恥１|エロ羞恥２|興奮射精後１|エロ痛み２|エロ我慢３|まぶたギュ" , "頬２涙１" , "0" , "3" , "1" , "" , "SEX_A" , "-1" , "0" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life38_05m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };

        private string[][] life38_06f = new string[][]{
          new string[] { "vibe_onania_2_f.anm|vibe_onania_3_f.anm" , "1.85" , "0.50" , "-1.30" , "0" , "348.6" , "0" , "エロ痛み我慢|エロ痛み我慢２|エロ痛み我慢３|エロメソ泣き|エロ羞恥３|エロ我慢３" , "頬３涙２" , "0" , "3" , "1" , "" , "SEX_A" , "-1" , "0" , "handitem,HandItemR_AnalVibe_I_.menu" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life38_06m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };


        //39：メイド部屋（夜） シーン設定
        private string[][] life39_01f = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "" , "" , "0" , "0" , "0" , "" , "" , "-1" , "-1" , "" , "0" }
    };
        private string[][] life39_01m = new string[][]{
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" },
      new string[] {"" , "0" , "0" , "0" , "0" , "0" , "0" , "0" }
    };



        //エンパイアズライフ用ボイスセット
        private string[][] elVs = new string[][]{
      new string[] { "" , "" , "" , "" , "" },
      new string[] { "" , "" , "" , "" , "" },
      new string[] { "" , "" , "" , "" , "" },
      new string[] { "" , "" , "" , "" , "" }
    };

        private string[][] elVs_sex01 = new string[][]{
      new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
      new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
      new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
      new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
      new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
      new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04048.ogg" },
      new string[] { "S6_02179.ogg" , "S6_02183.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },

      new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
      new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
      new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
      new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
      new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04048.ogg" },
      new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
      new string[] { "S6_02179.ogg" , "S6_02183.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
      new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
      new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
      new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" }

    };

        private string[][] elVs_sex02 = new string[][]{
      new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
      new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
      new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
      new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
      new string[] { "s4_08140.ogg" , "s4_08134.ogg" , "s4_08149.ogg" , "s4_08150.ogg" },
      new string[] { "s5_04055.ogg" , "s5_04061.ogg" , "s5_04054.ogg" , "s5_04052.ogg" },
      new string[] { "S6_02249.ogg" , "S6_02250.ogg" , "S6_02185.ogg" , "S6_02186.ogg" },

      new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
      new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
      new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
      new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
      new string[] { "s5_04055.ogg" , "s5_04061.ogg" , "s5_04054.ogg" , "s5_04052.ogg" },
      new string[] { "s4_08140.ogg" , "s4_08134.ogg" , "s4_08149.ogg" , "s4_08150.ogg" },
      new string[] { "S6_02249.ogg" , "S6_02250.ogg" , "S6_02185.ogg" , "S6_02186.ogg" },
      new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
      new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
      new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" }
    };

        private string[][] elVs_sex03 = new string[][]{
      new string[] { "s0_09072.ogg" , "s0_09070.ogg" , "s0_09099.ogg" , "s0_09059.ogg" , "s0_09067.ogg" , "s0_09068.ogg" , "s0_09069.ogg" , "s0_09071.ogg" , "s0_09085.ogg" , "s0_09086.ogg" , "s0_09087.ogg" , "s0_09091.ogg" },
      new string[] { "s1_03207.ogg" , "s1_03205.ogg" , "s1_08993.ogg" , "s1_08971.ogg" , "s1_09344.ogg" , "s1_09370.ogg" , "s1_09371.ogg" , "s1_09372.ogg" , "s1_09374.ogg" , "s1_09398.ogg" , "s1_09392.ogg" , "s1_09365.ogg" },
      new string[] { "s2_09039.ogg" , "s2_09067.ogg" , "s2_09052.ogg" , "s2_08502.ogg" , "s2_09047.ogg" , "s2_09048.ogg" , "s2_09049.ogg" , "s2_09050.ogg" , "s2_09051.ogg" , "s2_09066.ogg" , "s2_09069.ogg" , "s2_09073.ogg" },
      new string[] { "s3_02905.ogg" , "s3_02906.ogg" , "s3_02907.ogg" , "s3_05540.ogg" , "s3_05657.ogg" , "s3_05658.ogg" , "s3_05659.ogg" , "s3_05660.ogg" , "s3_05661.ogg" , "s3_05678.ogg" , "s3_05651.ogg" , "s3_05656.ogg" },
      new string[] { "s4_08347.ogg" , "s4_08355.ogg" , "s4_08356.ogg" , "s4_11658.ogg" , "s4_11684.ogg" , "s4_11677.ogg" , "s4_11680.ogg" , "s4_11683.ogg" , "s4_11661.ogg" , "s4_11659.ogg" , "s4_11654.ogg" , "s4_11660.ogg" },
      new string[] { "s5_04266.ogg" , "s5_18375.ogg" , "s5_18380.ogg" , "s5_18393.ogg" , "s5_18379.ogg" , "s5_18380.ogg" , "s5_18382.ogg" , "s5_18384.ogg" , "s5_18385.ogg" , "s5_18400.ogg" , "s5_18402.ogg" , "s5_18119.ogg" },
      new string[] { "S6_28817.ogg" , "S6_02398.ogg" , "S6_02399.ogg" , "s6_02402.ogg" , "S6_09048.ogg" , "S6_01984.ogg" , "S6_01988.ogg" , "S6_01991.ogg" , "S6_02000.ogg" , "S6_01996.ogg" , "S6_01997.ogg" , "S6_01998.ogg" , "S6_01999.ogg" , "S6_02001.ogg" , "s6_05796.ogg" , "s6_05797.ogg" , "s6_05798.ogg" , "s6_05799.ogg" , "s6_05800.ogg" , "s6_05801.ogg" },

      new string[] { "s0_09072.ogg" , "s0_09070.ogg" , "s0_09099.ogg" , "s0_09059.ogg" , "s0_09067.ogg" , "s0_09068.ogg" , "s0_09069.ogg" , "s0_09071.ogg" , "s0_09085.ogg" , "s0_09086.ogg" , "s0_09087.ogg" , "s0_09091.ogg" },
      new string[] { "s1_03207.ogg" , "s1_03205.ogg" , "s1_08993.ogg" , "s1_08971.ogg" , "s1_09344.ogg" , "s1_09370.ogg" , "s1_09371.ogg" , "s1_09372.ogg" , "s1_09374.ogg" , "s1_09398.ogg" , "s1_09392.ogg" , "s1_09365.ogg" },
      new string[] { "s2_09039.ogg" , "s2_09067.ogg" , "s2_09052.ogg" , "s2_08502.ogg" , "s2_09047.ogg" , "s2_09048.ogg" , "s2_09049.ogg" , "s2_09050.ogg" , "s2_09051.ogg" , "s2_09066.ogg" , "s2_09069.ogg" , "s2_09073.ogg" },
      new string[] { "s3_02905.ogg" , "s3_02906.ogg" , "s3_02907.ogg" , "s3_05540.ogg" , "s3_05657.ogg" , "s3_05658.ogg" , "s3_05659.ogg" , "s3_05660.ogg" , "s3_05661.ogg" , "s3_05678.ogg" , "s3_05651.ogg" , "s3_05656.ogg" },
      new string[] { "s5_04266.ogg" , "s5_18375.ogg" , "s5_18380.ogg" , "s5_18393.ogg" , "s5_18379.ogg" , "s5_18380.ogg" , "s5_18382.ogg" , "s5_18384.ogg" , "s5_18385.ogg" , "s5_18400.ogg" , "s5_18402.ogg" , "s5_18119.ogg" },
      new string[] { "s4_08347.ogg" , "s4_08355.ogg" , "s4_08356.ogg" , "s4_11658.ogg" , "s4_11684.ogg" , "s4_11677.ogg" , "s4_11680.ogg" , "s4_11683.ogg" , "s4_11661.ogg" , "s4_11659.ogg" , "s4_11654.ogg" , "s4_11660.ogg" },
      new string[] { "S6_28817.ogg" , "S6_02398.ogg" , "S6_02399.ogg" , "s6_02402.ogg" , "S6_09048.ogg" , "S6_01984.ogg" , "S6_01988.ogg" , "S6_01991.ogg" , "S6_02000.ogg" , "S6_01996.ogg" , "S6_01997.ogg" , "S6_01998.ogg" , "S6_01999.ogg" , "S6_02001.ogg" , "s6_05796.ogg" , "s6_05797.ogg" , "s6_05798.ogg" , "s6_05799.ogg" , "s6_05800.ogg" , "s6_05801.ogg" },
      new string[] { "s2_09039.ogg" , "s2_09067.ogg" , "s2_09052.ogg" , "s2_08502.ogg" , "s2_09047.ogg" , "s2_09048.ogg" , "s2_09049.ogg" , "s2_09050.ogg" , "s2_09051.ogg" , "s2_09066.ogg" , "s2_09069.ogg" , "s2_09073.ogg" },
      new string[] { "s1_03207.ogg" , "s1_03205.ogg" , "s1_08993.ogg" , "s1_08971.ogg" , "s1_09344.ogg" , "s1_09370.ogg" , "s1_09371.ogg" , "s1_09372.ogg" , "s1_09374.ogg" , "s1_09398.ogg" , "s1_09392.ogg" , "s1_09365.ogg" },
      new string[] { "s1_03207.ogg" , "s1_03205.ogg" , "s1_08993.ogg" , "s1_08971.ogg" , "s1_09344.ogg" , "s1_09370.ogg" , "s1_09371.ogg" , "s1_09372.ogg" , "s1_09374.ogg" , "s1_09398.ogg" , "s1_09392.ogg" , "s1_09365.ogg" }
    };

        private string[][] elVs_fera01 = new string[][]{
      new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
      new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
      new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
      new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
      new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
      new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },

      new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
      new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
      new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
      new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
      new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
      new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
      new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" }
    };

        private string[][] elVs_kiss01 = new string[][]{
      new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
      new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
      new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
      new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
      new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
      new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },

      new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
      new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
      new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
      new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
      new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
      new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
      new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
      new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" }
    };

        private string[][] elVs_souji01 = new string[][]{
      new string[] { "S0_03152.ogg" , "S0_03410.ogg" , "S0_03429.ogg" , "S0_03293.ogg" , "S0_03368.ogg" , "S0_03381.ogg" },
      new string[] { "S1_05632.ogg" , "S1_05656.ogg" , "S1_05632.ogg" , "S1_04690.ogg" , "S1_05643.ogg" },
      new string[] { "S2_04678.ogg" , "S2_04277.ogg" , "S2_04282.ogg" , "S2_04714.ogg" , "S2_04702.ogg" },
      new string[] { "S3_12858.ogg" , "S3_12859.ogg" , "S3_12860.ogg" , "S3_07808.ogg" , "S3_07840.ogg" },
      new string[] { "S4_12860.ogg" , "S4_12862.ogg" , "S4_06759.ogg" , "S4_06760.ogg" },
      new string[] { "S5_15282.ogg" , "S5_15283.ogg" , "S5_15284.ogg" , "S5_03418.ogg" , "S5_03436.ogg" },
      new string[] { "S6_24074.ogg" , "S6_24075.ogg" , "S6_24076.ogg" , "S6_14037.ogg" , "S6_14015.ogg" },

      new string[] { "S0_03152.ogg" , "S0_03410.ogg" , "S0_03429.ogg" , "S0_03293.ogg" , "S0_03368.ogg" , "S0_03381.ogg" },
      new string[] { "S1_05632.ogg" , "S1_05656.ogg" , "S1_05632.ogg" , "S1_04690.ogg" , "S1_05643.ogg" },
      new string[] { "S2_04678.ogg" , "S2_04277.ogg" , "S2_04282.ogg" , "S2_04714.ogg" , "S2_04702.ogg" },
      new string[] { "S3_12858.ogg" , "S3_12859.ogg" , "S3_12860.ogg" , "S3_07808.ogg" , "S3_07840.ogg" },
      new string[] { "S5_15282.ogg" , "S5_15283.ogg" , "S5_15284.ogg" , "S5_03418.ogg" , "S5_03436.ogg" },
      new string[] { "S4_12860.ogg" , "S4_12862.ogg" , "S4_06759.ogg" , "S4_06760.ogg" },
      new string[] { "S6_24074.ogg" , "S6_24075.ogg" , "S6_24076.ogg" , "S6_14037.ogg" , "S6_14015.ogg" },
      new string[] { "S2_04678.ogg" , "S2_04277.ogg" , "S2_04282.ogg" , "S2_04714.ogg" , "S2_04702.ogg" },
      new string[] { "S1_05632.ogg" , "S1_05656.ogg" , "S1_05632.ogg" , "S1_04690.ogg" , "S1_05643.ogg" },
      new string[] { "S1_05632.ogg" , "S1_05656.ogg" , "S1_05632.ogg" , "S1_04690.ogg" , "S1_05643.ogg" }
    };

        private string[][] elVs_saiho01 = new string[][]{
      new string[] { "S0_03036.ogg" , "S0_03013.ogg" , "S0_03214.ogg" , "S0_03152.ogg" , "S0_03293.ogg" , "S0_03029.ogg" },
      new string[] { "S1_04524.ogg" , "S1_04598.ogg" , "S1_04697.ogg" , "S1_04690.ogg" , "S1_05656.ogg" , "S1_06549.ogg" },
      new string[] { "S2_02518.ogg" , "S2_02519.ogg" , "S2_02530.ogg" , "S2_02531.ogg" , "S2_02532.ogg" , "S2_02534.ogg" },
      new string[] { "S3_12840.ogg" , "S3_12841.ogg" , "S3_12842.ogg" , "S3_07439.ogg" , "S3_07440.ogg" },
      new string[] { "S4_12842.ogg" , "S4_12843.ogg" , "S4_12844.ogg" , "S4_06325.ogg" , "S4_06367.ogg" , "S4_06395.ogg" },
      new string[] { "S5_15264.ogg" , "S5_15265.ogg" , "S5_15266.ogg" , "S5_01949.ogg" , "S5_01970.ogg" , "S5_01978.ogg" , "S5_02001.ogg" },
      new string[] { "S6_24056.ogg" , "S6_24057.ogg" , "S6_24058.ogg" , "S6_24062.ogg" , "S6_00051.ogg" , "S6_24064.ogg" },

      new string[] { "S0_03036.ogg" , "S0_03013.ogg" , "S0_03214.ogg" , "S0_03152.ogg" , "S0_03293.ogg" , "S0_03029.ogg" },
      new string[] { "S1_04524.ogg" , "S1_04598.ogg" , "S1_04697.ogg" , "S1_04690.ogg" , "S1_05656.ogg" , "S1_06549.ogg" },
      new string[] { "S2_02518.ogg" , "S2_02519.ogg" , "S2_02530.ogg" , "S2_02531.ogg" , "S2_02532.ogg" , "S2_02534.ogg" },
      new string[] { "S3_12840.ogg" , "S3_12841.ogg" , "S3_12842.ogg" , "S3_07439.ogg" , "S3_07440.ogg" },
      new string[] { "S5_15264.ogg" , "S5_15265.ogg" , "S5_15266.ogg" , "S5_01949.ogg" , "S5_01970.ogg" , "S5_01978.ogg" , "S5_02001.ogg" },
      new string[] { "S4_12842.ogg" , "S4_12843.ogg" , "S4_12844.ogg" , "S4_06325.ogg" , "S4_06367.ogg" , "S4_06395.ogg" },
      new string[] { "S6_24056.ogg" , "S6_24057.ogg" , "S6_24058.ogg" , "S6_24062.ogg" , "S6_00051.ogg" , "S6_24064.ogg" },
      new string[] { "S2_02518.ogg" , "S2_02519.ogg" , "S2_02530.ogg" , "S2_02531.ogg" , "S2_02532.ogg" , "S2_02534.ogg" },
      new string[] { "S1_04524.ogg" , "S1_04598.ogg" , "S1_04697.ogg" , "S1_04690.ogg" , "S1_05656.ogg" , "S1_06549.ogg" },
      new string[] { "S1_04524.ogg" , "S1_04598.ogg" , "S1_04697.ogg" , "S1_04690.ogg" , "S1_05656.ogg" , "S1_06549.ogg" }
    };

        private string[][] elVs_ryouri01 = new string[][]{
      new string[] { "S0_03086.ogg" , "S0_03090.ogg" , "S0_03121.ogg" , "S0_03214.ogg" , "S0_03293.ogg" , "S0_03064.ogg" , "S0_03075.ogg" },
      new string[] { "S1_04618.ogg" , "S1_04642.ogg" , "S1_05656.ogg" , "S1_04610.ogg" , "S1_04644.ogg" , "S1_04586.ogg" },
      new string[] { "S2_02625.ogg" , "S2_04097.ogg" , "S2_04714.ogg" , "S2_04678.ogg" , "S2_02621.ogg" },
      new string[] { "S3_12843.ogg" , "S3_12844.ogg" , "S3_12845.ogg" , "S3_07477.ogg" , "S3_07509.ogg" , "S3_07516.ogg" },
      new string[] { "S4_12845.ogg" , "S4_12847.ogg" , "S4_06462.ogg" , "S4_06583.ogg" },
      new string[] { "S5_15268.ogg" , "S5_03377.ogg" , "S5_03396.ogg" , "S5_02071.ogg" , "S5_02072.ogg" },
      new string[] { "S6_24059.ogg" , "S6_24060.ogg" , "S6_24061.ogg" , "S6_00051.ogg" , "S6_00077.ogg" , "S6_00113.ogg" },

      new string[] { "S0_03086.ogg" , "S0_03090.ogg" , "S0_03121.ogg" , "S0_03214.ogg" , "S0_03293.ogg" , "S0_03064.ogg" , "S0_03075.ogg" },
      new string[] { "S1_04618.ogg" , "S1_04642.ogg" , "S1_05656.ogg" , "S1_04610.ogg" , "S1_04644.ogg" , "S1_04586.ogg" },
      new string[] { "S2_02625.ogg" , "S2_04097.ogg" , "S2_04714.ogg" , "S2_04678.ogg" , "S2_02621.ogg" },
      new string[] { "S3_12843.ogg" , "S3_12844.ogg" , "S3_12845.ogg" , "S3_07477.ogg" , "S3_07509.ogg" , "S3_07516.ogg" },
      new string[] { "S5_15268.ogg" , "S5_03377.ogg" , "S5_03396.ogg" , "S5_02071.ogg" , "S5_02072.ogg" },
      new string[] { "S4_12845.ogg" , "S4_12847.ogg" , "S4_06462.ogg" , "S4_06583.ogg" },
      new string[] { "S6_24059.ogg" , "S6_24060.ogg" , "S6_24061.ogg" , "S6_00051.ogg" , "S6_00077.ogg" , "S6_00113.ogg" },
      new string[] { "S2_02625.ogg" , "S2_04097.ogg" , "S2_04714.ogg" , "S2_04678.ogg" , "S2_02621.ogg" },
      new string[] { "S1_04618.ogg" , "S1_04642.ogg" , "S1_05656.ogg" , "S1_04610.ogg" , "S1_04644.ogg" , "S1_04586.ogg" },
      new string[] { "S1_04618.ogg" , "S1_04642.ogg" , "S1_05656.ogg" , "S1_04610.ogg" , "S1_04644.ogg" , "S1_04586.ogg" }
    };

        private string[][] elVs_kesyou01 = new string[][]{
      new string[] { "S0_03252.ogg" , "S0_03288.ogg" , "S0_03293.ogg" , "S0_03273.ogg" , "S0_03302.ogg" },
      new string[] { "S1_05510.ogg" , "S1_05521.ogg" , "S1_05656.ogg" , "S1_05484.ogg" , "S1_05485.ogg" },
      new string[] { "S2_04607.ogg" , "S2_04624.ogg" , "S2_04646.ogg" , "S2_04714.ogg" , "S2_04678.ogg" },
      new string[] { "S3_12853.ogg" , "S3_07674.ogg" , "S3_07702.ogg" , "S3_07730.ogg" },
      new string[] { "S5_15276.ogg" , "S5_15277.ogg" , "S5_15278.ogg" , "S5_02311.ogg" , "S5_02339.ogg" , "S5_02340.ogg" },
      new string[] { "S4_12854.ogg" , "S4_12855.ogg" , "S4_12856.ogg" , "S4_06637.ogg" , "S4_06648.ogg" },
      new string[] { "S6_24068.ogg" , "S6_24069.ogg" , "S6_24070.ogg" , "S6_00051.ogg" , "S6_00273.ogg" , "S6_00331.ogg" },

      new string[] { "S0_03252.ogg" , "S0_03288.ogg" , "S0_03293.ogg" , "S0_03273.ogg" , "S0_03302.ogg" },
      new string[] { "S1_05510.ogg" , "S1_05521.ogg" , "S1_05656.ogg" , "S1_05484.ogg" , "S1_05485.ogg" },
      new string[] { "S2_04607.ogg" , "S2_04624.ogg" , "S2_04646.ogg" , "S2_04714.ogg" , "S2_04678.ogg" },
      new string[] { "S3_12853.ogg" , "S3_07674.ogg" , "S3_07702.ogg" , "S3_07730.ogg" },
      new string[] { "S5_15276.ogg" , "S5_15277.ogg" , "S5_15278.ogg" , "S5_02311.ogg" , "S5_02339.ogg" , "S5_02340.ogg" },
      new string[] { "S4_12854.ogg" , "S4_12855.ogg" , "S4_12856.ogg" , "S4_06637.ogg" , "S4_06648.ogg" },
      new string[] { "S6_24068.ogg" , "S6_24069.ogg" , "S6_24070.ogg" , "S6_00051.ogg" , "S6_00273.ogg" , "S6_00331.ogg" },
      new string[] { "S2_04607.ogg" , "S2_04624.ogg" , "S2_04646.ogg" , "S2_04714.ogg" , "S2_04678.ogg" },
      new string[] { "S1_05510.ogg" , "S1_05521.ogg" , "S1_05656.ogg" , "S1_05484.ogg" , "S1_05485.ogg" },
      new string[] { "S1_05510.ogg" , "S1_05521.ogg" , "S1_05656.ogg" , "S1_05484.ogg" , "S1_05485.ogg" }
    };

        private string[][] elVs_kaiwa01 = new string[][]{
      new string[] { "S0_03621.ogg" , "S0_03625.ogg" , "S0_03631.ogg" , "S0_03638.ogg" , "S0_03655.ogg" , "S0_03656.ogg" , "S0_03657.ogg" , "S0_03666.ogg" , "S0_03668.ogg" , "S0_03728.ogg" , "S0_03729.ogg" , "S0_03738.ogg" , "S0_03767.ogg" , "S0_03769.ogg" , "S0_03770.ogg" , "S0_03776.ogg" , "S0_03780.ogg" , "S0_03781.ogg" },
      new string[] { "S1_03509.ogg" , "S1_03510.ogg" , "S1_03511.ogg" , "S1_03518.ogg" , "S1_03520.ogg" , "S1_03521.ogg" , "S1_03525.ogg" , "S1_03526.ogg" , "S1_03536.ogg" , "S1_03538.ogg" , "S1_03547.ogg" , "S1_03548.ogg" , "S1_03555.ogg" , "S1_03556.ogg" , "S1_03557.ogg" , "S1_03560.ogg" , "S1_03572.ogg" , "S1_03574.ogg" },
      new string[] { "S2_02651.ogg" , "S2_02686.ogg" , "S2_02687.ogg" , "S2_02692.ogg" , "S2_02709.ogg" , "S2_02711.ogg" , "S2_02714.ogg" , "S2_02722.ogg" , "S2_02734.ogg" , "S2_02736.ogg" , "S2_02740.ogg" , "S2_02741.ogg" , "S2_02748.ogg" , "S2_02755.ogg" , "S2_02758.ogg" , "S2_02761.ogg" , "S2_02768.ogg" , "S2_02824.ogg" },
      new string[] { "S3_00052.ogg" , "S3_00053.ogg" , "S3_00054.ogg" , "S3_00060.ogg" , "S3_00071.ogg" , "S3_00072.ogg" , "S3_00073.ogg" , "S3_00074.ogg" , "S3_00077.ogg" , "S3_00079.ogg" , "S3_00080.ogg" , "S3_00087.ogg" , "S3_00089.ogg" , "S3_00090.ogg" , "S3_00092.ogg" , "S3_00093.ogg" , "S3_00098.ogg" , "S3_00099.ogg" },
      new string[] { "S4_04034.ogg" , "S4_04035.ogg" , "S4_04036.ogg" , "S4_04037.ogg" , "S4_04038.ogg" , "S4_04039.ogg" , "S4_04040.ogg" , "S4_04053.ogg" , "S4_04054.ogg" , "S4_04055.ogg" , "S4_04056.ogg" , "S4_04057.ogg" , "S4_04063.ogg" , "S4_04071.ogg" , "S4_04072.ogg" , "S4_04075.ogg" , "S4_04076.ogg" , "S4_04078.ogg" },
      new string[] { "S5_04554.ogg" , "S5_04555.ogg" , "S5_04556.ogg" , "S5_04557.ogg" , "S5_04575.ogg" , "S5_04576.ogg" , "S5_04577.ogg" , "S5_04578.ogg" , "S5_04579.ogg" , "S5_04582.ogg" , "S5_04594.ogg" , "S5_04595.ogg" , "S5_04596.ogg" , "S5_04597.ogg" , "S5_04598.ogg" , "S5_04642.ogg" , "S5_04643.ogg" , "S5_04646.ogg" },
      new string[] { "S6_24126.ogg" , "S6_24127.ogg" , "S6_24128.ogg" , "S6_24129.ogg" , "S6_00474.ogg" , "S6_00476.ogg" , "S6_00477.ogg" , "S6_00479.ogg" , "S6_00480.ogg" , "S6_00491.ogg" , "S6_00492.ogg" , "S6_00493.ogg" , "S6_00494.ogg" , "S6_00495.ogg" , "S6_00531.ogg" , "S6_00532.ogg" , "S6_00533.ogg" , "S6_00534.ogg" },

      new string[] { "S0_03621.ogg" , "S0_03625.ogg" , "S0_03631.ogg" , "S0_03638.ogg" , "S0_03655.ogg" , "S0_03656.ogg" , "S0_03657.ogg" , "S0_03666.ogg" , "S0_03668.ogg" , "S0_03728.ogg" , "S0_03729.ogg" , "S0_03738.ogg" , "S0_03767.ogg" , "S0_03769.ogg" , "S0_03770.ogg" , "S0_03776.ogg" , "S0_03780.ogg" , "S0_03781.ogg" },
      new string[] { "S1_03509.ogg" , "S1_03510.ogg" , "S1_03511.ogg" , "S1_03518.ogg" , "S1_03520.ogg" , "S1_03521.ogg" , "S1_03525.ogg" , "S1_03526.ogg" , "S1_03536.ogg" , "S1_03538.ogg" , "S1_03547.ogg" , "S1_03548.ogg" , "S1_03555.ogg" , "S1_03556.ogg" , "S1_03557.ogg" , "S1_03560.ogg" , "S1_03572.ogg" , "S1_03574.ogg" },
      new string[] { "S2_02651.ogg" , "S2_02686.ogg" , "S2_02687.ogg" , "S2_02692.ogg" , "S2_02709.ogg" , "S2_02711.ogg" , "S2_02714.ogg" , "S2_02722.ogg" , "S2_02734.ogg" , "S2_02736.ogg" , "S2_02740.ogg" , "S2_02741.ogg" , "S2_02748.ogg" , "S2_02755.ogg" , "S2_02758.ogg" , "S2_02761.ogg" , "S2_02768.ogg" , "S2_02824.ogg" },
      new string[] { "S3_00052.ogg" , "S3_00053.ogg" , "S3_00054.ogg" , "S3_00060.ogg" , "S3_00071.ogg" , "S3_00072.ogg" , "S3_00073.ogg" , "S3_00074.ogg" , "S3_00077.ogg" , "S3_00079.ogg" , "S3_00080.ogg" , "S3_00087.ogg" , "S3_00089.ogg" , "S3_00090.ogg" , "S3_00092.ogg" , "S3_00093.ogg" , "S3_00098.ogg" , "S3_00099.ogg" },
      new string[] { "S5_04554.ogg" , "S5_04555.ogg" , "S5_04556.ogg" , "S5_04557.ogg" , "S5_04575.ogg" , "S5_04576.ogg" , "S5_04577.ogg" , "S5_04578.ogg" , "S5_04579.ogg" , "S5_04582.ogg" , "S5_04594.ogg" , "S5_04595.ogg" , "S5_04596.ogg" , "S5_04597.ogg" , "S5_04598.ogg" , "S5_04642.ogg" , "S5_04643.ogg" , "S5_04646.ogg" },
      new string[] { "S4_04034.ogg" , "S4_04035.ogg" , "S4_04036.ogg" , "S4_04037.ogg" , "S4_04038.ogg" , "S4_04039.ogg" , "S4_04040.ogg" , "S4_04053.ogg" , "S4_04054.ogg" , "S4_04055.ogg" , "S4_04056.ogg" , "S4_04057.ogg" , "S4_04063.ogg" , "S4_04071.ogg" , "S4_04072.ogg" , "S4_04075.ogg" , "S4_04076.ogg" , "S4_04078.ogg" },
      new string[] { "S6_24126.ogg" , "S6_24127.ogg" , "S6_24128.ogg" , "S6_24129.ogg" , "S6_00474.ogg" , "S6_00476.ogg" , "S6_00477.ogg" , "S6_00479.ogg" , "S6_00480.ogg" , "S6_00491.ogg" , "S6_00492.ogg" , "S6_00493.ogg" , "S6_00494.ogg" , "S6_00495.ogg" , "S6_00531.ogg" , "S6_00532.ogg" , "S6_00533.ogg" , "S6_00534.ogg" },
      new string[] { "S2_02651.ogg" , "S2_02686.ogg" , "S2_02687.ogg" , "S2_02692.ogg" , "S2_02709.ogg" , "S2_02711.ogg" , "S2_02714.ogg" , "S2_02722.ogg" , "S2_02734.ogg" , "S2_02736.ogg" , "S2_02740.ogg" , "S2_02741.ogg" , "S2_02748.ogg" , "S2_02755.ogg" , "S2_02758.ogg" , "S2_02761.ogg" , "S2_02768.ogg" , "S2_02824.ogg" },
      new string[] { "S1_03509.ogg" , "S1_03510.ogg" , "S1_03511.ogg" , "S1_03518.ogg" , "S1_03520.ogg" , "S1_03521.ogg" , "S1_03525.ogg" , "S1_03526.ogg" , "S1_03536.ogg" , "S1_03538.ogg" , "S1_03547.ogg" , "S1_03548.ogg" , "S1_03555.ogg" , "S1_03556.ogg" , "S1_03557.ogg" , "S1_03560.ogg" , "S1_03572.ogg" , "S1_03574.ogg" },
      new string[] { "S1_03509.ogg" , "S1_03510.ogg" , "S1_03511.ogg" , "S1_03518.ogg" , "S1_03520.ogg" , "S1_03521.ogg" , "S1_03525.ogg" , "S1_03526.ogg" , "S1_03536.ogg" , "S1_03538.ogg" , "S1_03547.ogg" , "S1_03548.ogg" , "S1_03555.ogg" , "S1_03556.ogg" , "S1_03557.ogg" , "S1_03560.ogg" , "S1_03572.ogg" , "S1_03574.ogg" }
    };

        private string[][] elVs_suimin01 = new string[][]{
      new string[] { "S0_03176.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" }
    };

        private string[][] elVs_furo01 = new string[][]{
      new string[] { "S0_03344.ogg" , "S0_03358.ogg" , "S0_03320.ogg" , "S0_03343.ogg" , "S0_03339.ogg" },
      new string[] { "S1_05610.ogg" , "S1_05620.ogg" , "S1_04524.ogg" , "S1_06930.ogg" },
      new string[] { "S2_04103.ogg" , "S2_04714.ogg" , "S2_04678.ogg" },
      new string[] { "S3_12857.ogg" , "S3_12855.ogg" , "S3_07702.ogg" , "S3_07745.ogg" },
      new string[] { "S4_06686.ogg" , "S4_06695.ogg" , "S4_06711.ogg" },
      new string[] { "S5_15279.ogg" , "S5_02392.ogg" , "S5_02382.ogg" , "S5_02433.ogg" , "S5_02442.ogg" },
      new string[] { "S6_24073.ogg" , "S6_00367.ogg" , "S6_00358.ogg" , "S6_00404.ogg" },

      new string[] { "S0_03344.ogg" , "S0_03358.ogg" , "S0_03320.ogg" , "S0_03343.ogg" , "S0_03339.ogg" },
      new string[] { "S1_05610.ogg" , "S1_05620.ogg" , "S1_04524.ogg" , "S1_06930.ogg" },
      new string[] { "S2_04103.ogg" , "S2_04714.ogg" , "S2_04678.ogg" },
      new string[] { "S3_12857.ogg" , "S3_12855.ogg" , "S3_07702.ogg" , "S3_07745.ogg" },
      new string[] { "S5_15279.ogg" , "S5_02392.ogg" , "S5_02382.ogg" , "S5_02433.ogg" , "S5_02442.ogg" },
      new string[] { "S4_06686.ogg" , "S4_06695.ogg" , "S4_06711.ogg" },
      new string[] { "S6_24073.ogg" , "S6_00367.ogg" , "S6_00358.ogg" , "S6_00404.ogg" },
      new string[] { "S2_04103.ogg" , "S2_04714.ogg" , "S2_04678.ogg" },
      new string[] { "S1_05610.ogg" , "S1_05620.ogg" , "S1_04524.ogg" , "S1_06930.ogg" },
      new string[] { "S1_05610.ogg" , "S1_05620.ogg" , "S1_04524.ogg" , "S1_06930.ogg" }
    };

        private string[][] elVs_sake01 = new string[][]{
      new string[] { "S0_03503.ogg" , "S0_03177.ogg" , "S0_03520.ogg" , "S0_08143.ogg" , "S0_08146.ogg" , "S0_18208.ogg" , "S0_18212.ogg" , "S0_03633.ogg" },
      new string[] { "S1_06581.ogg" , "S1_06598.ogg" , "S1_06605.ogg" , "S1_05001.ogg" , "S1_05002.ogg" , "S1_05005.ogg" , "S1_05025.ogg" },
      new string[] { "S2_02663.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { "S3_12865.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { "S5_15289.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" }
    };

        private string[][] elVs_hanyou01 = new string[][]{
      new string[] { "S0_03293.ogg" , "S0_03321.ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { "S1_04524.ogg" , "S1_04690.ogg" , "S1_05656.ogg" , ".ogg" , ".ogg" },
      new string[] { "S2_04714.ogg" , "S2_04678.ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { "S3_07702.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { "S6_00051.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
      new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" }
    };



        //エンパイアズライフ
        private IEnumerator EmpiresLife()
        {

            //スタート時及び場所移動時の処理
            if (lifeStart == 1)
            {

                elMouthMode = new int[] { 0, 0, 0, 0 };
                eldatui = new int[] { 0, 0, 0, 0 };
                GameMain.Instance.SoundMgr.StopSe();
                GameMain.Instance.SoundMgr.StopBGM(2f);

                //シーンファイルの読み込み
                ElLoad(bgID);

                //ライト設定
                if (bgID == 32)
                {
                    GameMain.Instance.MainLight.GetComponent<Light>().color = new Color(0.9f, 0.8f, 0.7f, 1f);
                }
                else
                {
                    GameMain.Instance.MainLight.GetComponent<Light>().color = new Color(1f, 1f, 1f, 1f);
                }

                //全メイドと男を一旦非表示
                GameMain.Instance.CharacterMgr.DeactivateMaidAll();
                GameMain.Instance.CharacterMgr.ResetCharaPosAll();
                foreach (Maid man in SubMans)
                {
                    man.Visible = false;
                }

                //メイドを呼び出す
                for (int i = 0; i < 4; i++)
                {
                    if (mn[bgID][i] == -1 || life_f[i][0] == "") continue;
                    LoadMaid(stockMaids[mn[bgID][i]].mem);

                    stockMaids[mn[bgID][i]].mem.ResetAll();

                }

                //男を呼び出す
                for (int i = 0; i < 4; i++)
                {
                    if (life_m[i][0] == "") continue;

                    SubMans[i].Visible = true;
                }

                if (node5.y < 0)
                {
                    node5.y = 0;
                    cfgw.subGuiFlag = 0;
                    cfgw.configGuiFlag = false;
                }
                lifeStart = 2;

            }


            if (lifeStart == 2)
            {
                int lc = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (life_f[i][0] == "" || mn[bgID][i] == -1)
                    {
                        ++lc;
                    }
                    else if (stockMaids[mn[bgID][i]].mem.body0 != null && stockMaids[mn[bgID][i]].mem.body0.isLoadedBody && !stockMaids[mn[bgID][i]].mem.boAllProcPropBUSY)
                    {
                        ++lc;
                    }

                    if (life_m[i][0] == "")
                    {
                        ++lc;
                    }
                    else if (SubMans[i].body0 != null && SubMans[i].body0.isLoadedBody && !SubMans[i].boAllProcPropBUSY)
                    {
                        ++lc;
                    }
                }
                if (lc == 8) lifeStart = 3;
            }

            if (lifeStart == 3)
            {

                lifeStart = 4;

                yield return new WaitForSeconds(1f);  // 1秒待つ

                //メイドの移動とモーション・表情変更
                for (int i = 0; i < 4; i++)
                {
                    if (life_f[i][0] == "" || mn[bgID][i] == -1) continue;

                    if (stockMaids[mn[bgID][i]].mem.Visible)
                    {

                        //モーション変更
                        if (life_f[i][12] == "")
                        {
                            MaidSetMotion(life_f[i][0], stockMaids[mn[bgID][i]].mem, 0f, i);
                        }

                        //移動
                        stockMaids[mn[bgID][i]].mem.transform.position = new Vector3(floatCnv(life_f[i][1]), floatCnv(life_f[i][2]), floatCnv(life_f[i][3]));
                        stockMaids[mn[bgID][i]].mem.transform.eulerAngles = new Vector3(floatCnv(life_f[i][4]), floatCnv(life_f[i][5]), floatCnv(life_f[i][6]));
                        stockMaids[mn[bgID][i]].mem.body0.SetBoneHitHeightY(floatCnv(life_f[i][9]));

                        //表情変更
                        MaidSetFace(life_f[i][7], stockMaids[mn[bgID][i]].mem);
                        stockMaids[mn[bgID][i]].mem.FaceBlend(life_f[i][8]);

                        //着衣の変更
                        if (life_f[i][10] == "0")
                        { //全着衣
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.wear, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.mizugi, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.onepiece, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.bra, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.skirt, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.panz, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.glove, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accUde, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.stkg, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.shoes, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.headset, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accHat, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubi, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubiwa, true);
                        }
                        if (life_f[i][10] == "1")
                        { //全裸
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.wear, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.mizugi, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.onepiece, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.bra, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.skirt, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.panz, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.glove, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accUde, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.stkg, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.shoes, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.headset, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accHat, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubi, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubiwa, false);
                        }
                        if (life_f[i][10] == "2")
                        { //下着姿
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.wear, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.mizugi, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.onepiece, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.bra, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.skirt, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.panz, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.glove, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accUde, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.stkg, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.shoes, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.headset, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accHat, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubi, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubiwa, false);
                        }
                        if (life_f[i][10] == "3")
                        { //ノーパンノーブラ
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.wear, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.mizugi, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.onepiece, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.bra, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.skirt, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.panz, false);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.glove, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accUde, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.stkg, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.shoes, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.headset, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accHat, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubi, true);
                            stockMaids[mn[bgID][i]].mem.body0.SetMask(TBody.SlotID.accKubiwa, true);
                        }

                        //顔と視線の向き変更
                        if (life_f[i][11] == "0") stockMaids[mn[bgID][i]].mem.EyeToCamera((Maid.EyeMoveType)5, 0.8f); //向ける
                        if (life_f[i][11] == "1") stockMaids[mn[bgID][i]].mem.EyeToCamera((Maid.EyeMoveType)0, 0.8f); //向けない
                        if (life_f[i][11] == "2")
                        { //目だけ向ける
                            stockMaids[mn[bgID][i]].mem.EyeToCamera((Maid.EyeMoveType)0, 0.8f);
                            stockMaids[mn[bgID][i]].mem.body0.boEyeToCam = true;
                        }

                        //ボイスセット読み込み
                        int iPersonal = Array.IndexOf(personalList[1], stockMaids[mn[bgID][i]].personal);
                        elVs[i] = new string[] { "", "", "", "", "" };
                        if (iPersonal < 7)
                        {
                            if (life_f[i][13] == "SEX01")
                            {
                                elVs[i] = new string[elVs_sex01[iPersonal].Length];
                                Array.Copy(elVs_sex01[iPersonal], elVs[i], elVs_sex01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "SEX02")
                            {
                                elVs[i] = new string[elVs_sex02[iPersonal].Length];
                                Array.Copy(elVs_sex02[iPersonal], elVs[i], elVs_sex02[iPersonal].Length);
                            }
                            if (life_f[i][13] == "SEX03")
                            {
                                elVs[i] = new string[elVs_sex03[iPersonal].Length];
                                Array.Copy(elVs_sex03[iPersonal], elVs[i], elVs_sex03[iPersonal].Length);
                            }
                            if (life_f[i][13] == "キス01")
                            {
                                elVs[i] = new string[elVs_kiss01[iPersonal].Length];
                                Array.Copy(elVs_kiss01[iPersonal], elVs[i], elVs_kiss01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "フェラ01")
                            {
                                elVs[i] = new string[elVs_fera01[iPersonal].Length];
                                Array.Copy(elVs_fera01[iPersonal], elVs[i], elVs_fera01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "掃除")
                            {
                                elVs[i] = new string[elVs_souji01[iPersonal].Length];
                                Array.Copy(elVs_souji01[iPersonal], elVs[i], elVs_souji01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "裁縫")
                            {
                                elVs[i] = new string[elVs_saiho01[iPersonal].Length];
                                Array.Copy(elVs_saiho01[iPersonal], elVs[i], elVs_saiho01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "料理")
                            {
                                elVs[i] = new string[elVs_ryouri01[iPersonal].Length];
                                Array.Copy(elVs_ryouri01[iPersonal], elVs[i], elVs_ryouri01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "化粧")
                            {
                                elVs[i] = new string[elVs_kesyou01[iPersonal].Length];
                                Array.Copy(elVs_kesyou01[iPersonal], elVs[i], elVs_kesyou01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "会話01")
                            {
                                elVs[i] = new string[elVs_kaiwa01[iPersonal].Length];
                                Array.Copy(elVs_kaiwa01[iPersonal], elVs[i], elVs_kaiwa01[iPersonal].Length);
                            }
                            if (life_f[i][13] == "風呂")
                            {
                                elVs[i] = new string[elVs_furo01[iPersonal].Length];
                                Array.Copy(elVs_furo01[iPersonal], elVs[i], elVs_furo01[iPersonal].Length);
                            }
                        }

                        //マウスモード設定
                        if (life_f[i][13].Contains("キス"))
                        {
                            elMouthMode[i] = 1;

                        }
                        else if (life_f[i][13].Contains("フェラ"))
                        {
                            elMouthMode[i] = 2;

                        }
                        else if (!life_f[i][13].Contains("SEX_A"))
                        {
                            elMouthMode[i] = 0;

                        }



                        //メイドアイテム装備
                        MaidSetItem(life_f[i][16], stockMaids[mn[bgID][i]].mem);

                        //風呂シーン以外では汗を引かせる（要汗MOD）
                        if (bgID != 11 && bgID != 22 && bgID != 23)
                        {
                            try
                            {
                                VertexMorph_FromProcItem(stockMaids[mn[bgID][i]].mem.body0, "dry", 1f);
                            }
                            catch { /*LogError(ex);*/ }
                        }

                        lifeTime1[i] = 0;
                        lifeTime2[i] = UnityEngine.Random.Range(0f, 300f);
                        lifeTime3[i] = UnityEngine.Random.Range(250f, 500f);
                        elvFlag[i] = 0;
                        elcrFlag[i] = false;


                    }
                }

                //男の移動とモーション変更
                for (int i = 0; i < 4; i++)
                {
                    if (life_m[i][0] == "") continue;

                    if (SubMans[i].Visible)
                    {
                        SubMans[i].transform.position = new Vector3(floatCnv(life_m[i][1]), floatCnv(life_m[i][2]), floatCnv(life_m[i][3]));
                        SubMans[i].transform.eulerAngles = new Vector3(floatCnv(life_m[i][4]), floatCnv(life_m[i][5]), floatCnv(life_m[i][6]));

                        ManSetMotion(life_m[i][0], SubMans[i], 0.7f, 0);

                        //MansTg[i] = vmId[intCnv(life_m[i][7])];
                        MansTg[i] = stockMaids[mn[bgID][intCnv(life_m[i][7])]].id;

                    }
                }

                //背景変更
                Console.WriteLine("背景チェンジ:" + bgID);
                GameMain.Instance.BgMgr.ChangeBg(bgArray1[bgID][0]);

                //カメラ移動
                Vector3 vNewPosition = Vector3.zero;
                vNewPosition = new Vector3(floatCnv(bgArray1[bgID][4]), floatCnv(bgArray1[bgID][5]), floatCnv(bgArray1[bgID][6]));
                mainCamera.transform.eulerAngles = new Vector3(floatCnv(bgArray1[bgID][7]), floatCnv(bgArray1[bgID][8]), floatCnv(bgArray1[bgID][9]));
                if (!bOculusVR)
                {
                    mainCamera.SetPos(vNewPosition);
                    mainCamera.SetTargetPos(vNewPosition, true);
                    mainCamera.SetDistance(0f, true);
                }
                else
                {
                    mainCamera.SetPos(vNewPosition);
                }

                //BGM変更
                if (life_f[0][12] == "")
                {
                    if (bgID == 32)
                    {
                        GameMain.Instance.SoundMgr.PlayBGM(bgArray1[bgID][2], 0f, true);
                    }
                    else
                    {
                        GameMain.Instance.SoundMgr.PlayBGMLegacy(bgArray1[bgID][2], 0f, true);
                    }
                    danceFlag = 0;
                }
                else
                {
                    danceFlag = 2; //ダンス曲が設定されている場合ダンスフラグを2に
                    if (life_f[0][12] == "dummy") GameMain.Instance.SoundMgr.PlayBGMLegacy(bgArray1[bgID][2], 0f, true); //ダンス曲がダミーの場合は普通にBGM再生
                }

            }

            if (lifeStart == 4)
            {
                StartCoroutine("ElChangeEnd");
            }

            if (lifeStart >= 5 && !elFade && tgID != -1)
            {

                //if(maidsState[tgID].vStateMajor == 10){
                for (int i = 0; i < 4; i++)
                {
                    if (mn[bgID][i] == -1 || life_f[i][0] == "" || maidsState[mn[bgID][i]].elItazuraFlag || mn[bgID][i] == osawariID) continue;

                    //モーション変更処理（ダンスではない場合のみ）
                    if (life_f[i][12] == "")
                    {
                        if (mOnceFlag[i])
                        {
                            Animation anim = stockMaids[mn[bgID][i]].mem.body0.GetAnimation();
                            if (!anim.isPlaying)
                            {
                                lifeTime1[i] = 1f;
                                mOnceFlag[i] = false;
                                stockMaids[mn[bgID][i]].mem.CrossFadeAbsolute(mOnceBack[i], GameUty.FileSystemOld, false, true, false, 0f, 1f);
                            }

                        }
                        else if (lifeTime1[i] <= 0)
                        {
                            if (lifeStart > 5) MaidSetMotion(life_f[i][0], stockMaids[mn[bgID][i]].mem, 0.7f, i);
                            if (lifeStart == 5) MaidSetMotion(life_f[i][0], stockMaids[mn[bgID][i]].mem, 0f, i);

                            lifeTime1[i] = UnityEngine.Random.Range(400f, 1200f);  //タイマーリセット

                        }
                        else
                        {
                            lifeTime1[i] -= Time.deltaTime * 60;
                        }

                    }

                    //脱衣状態チェック
                    if (dCheck && life_f[i][10] == "0")
                    {
                        eldatui[i] = 0;
                        if (!stockMaids[mn[bgID][i]].mem.body0.GetMask(TBody.SlotID.wear) || !stockMaids[mn[bgID][i]].mem.body0.GetMask(TBody.SlotID.skirt) || isPropChanged(mn[bgID][i], "skirt").Contains("めくれ") || isPropChanged(mn[bgID][i], "onepiece").Contains("めくれ")) eldatui[i] += 1;
                        if (!stockMaids[mn[bgID][i]].mem.body0.GetMask(TBody.SlotID.panz)) eldatui[i] += 1;
                        if (stockMaids[mn[bgID][i]].mem.GetProp(MPN.accvag).strTempFileName == "accVag_VibePink_I_.menu") eldatui[i] += 1;
                        if (stockMaids[mn[bgID][i]].mem.GetProp(MPN.accanl).strTempFileName == "accAnl_AnalVibe_I_.menu") eldatui[i] += 1;


                        if (eldatui[i] == 0)
                        {
                            stockMaids[mn[bgID][i]].mem.FaceBlend(life_f[i][8]);
                        }
                        else if (eldatui[i] == 1)
                        {
                            stockMaids[mn[bgID][i]].mem.FaceBlend("頬２涙１");
                        }
                        else if (eldatui[i] == 2)
                        {
                            stockMaids[mn[bgID][i]].mem.FaceBlend("頬３涙１");
                        }

                        lifeTime3[i] = 0;
                    }


                    //表情変更処理
                    if (lifeTime3[i] <= 0)
                    {
                        //if((life_f[i][12] == "" && bgID != 32) || eldatui[i] == 0){
                        if (life_f[i][10] != "0" || eldatui[i] == 0)
                        {
                            MaidSetFace(life_f[i][7], stockMaids[mn[bgID][i]].mem);
                        }
                        else
                        {
                            if (eldatui[i] == 1) MaidSetFace("発情|引きつり笑顔|苦笑い|困った|泣き|少し怒り|誘惑|恥ずかしい|エロ羞恥２|エロ興奮３", stockMaids[mn[bgID][i]].mem);
                            if (eldatui[i] >= 2) MaidSetFace("発情|引きつり笑顔|苦笑い|困った|泣き|少し怒り|誘惑|恥ずかしい|エロ羞恥２|エロ興奮３|興奮射精後１|絶頂射精後１|エロ痛み１|エロ痛み２|エロ我慢２|エロ我慢３|まぶたギュ", stockMaids[mn[bgID][i]].mem);
                        }

                        //タイマーリセット
                        if (life_f[i][12] == "") lifeTime3[i] = UnityEngine.Random.Range(300f, 600f);
                        if (life_f[i][12] != "") lifeTime3[i] = UnityEngine.Random.Range(100f, 200f);
                    }
                    else
                    {
                        lifeTime3[i] -= Time.deltaTime * 60;
                    }

                    //ボイス再生処理
                    if (lifeTime2[i] <= 0)
                    {

                        float cr = 0f;
                        if (life_f[i][14] == "-1")
                        {
                            cr = 6f;
                        }
                        else
                        {
                            cr = floatCnv(life_f[i][14]);
                        }

                        //メイドが設定距離より近くにいる場合にボイス再生
                        if (elVs[i][0] != "" && elvFlag[i] == 0)
                        {
                            if (DistanceToMaid(mn[bgID][i], cr))
                            {
                                int r = UnityEngine.Random.Range(0, elVs[i].Length);
                                if (elcrFlag[i]) stockMaids[mn[bgID][i]].mem.AudioMan.LoadPlay(elVs[i][r], 0f, false, false);
                                if (!elcrFlag[i]) stockMaids[mn[bgID][i]].mem.AudioMan.LoadPlay(elVs[i][r], 1.5f, false, false);
                                elvFlag[i] = 1;
                                elcrFlag[i] = true;
                                if (life_f[i][13] == "SEX03")
                                {
                                    elMouthMode[i] = UnityEngine.Random.Range(2, 5);
                                    if (elMouthMode[i] < 3) elMouthMode[i] = 0;
                                }
                            }
                            else
                            {
                                lifeTime2[i] = 30;
                            }
                        }

                        //距離が離れたときもしくは再生が終わったときの処理
                        if (elvFlag[i] == 1)
                        {
                            if (!DistanceToMaid(mn[bgID][i], cr))
                            {
                                stockMaids[mn[bgID][i]].mem.AudioMan.Stop(1.5f);
                                elcrFlag[i] = false;
                            }

                            if (!stockMaids[mn[bgID][i]].mem.AudioMan.audiosource.isPlaying)
                            {
                                float vt = 0f;
                                if (life_f[i][15] == "-1")
                                {
                                    vt = 700f;

                                }
                                else
                                {
                                    vt = floatCnv(life_f[i][15]);
                                }

                                elvFlag[i] = 0; //再生中フラグOFF

                                //タイマーリセット
                                if (elcrFlag[i])
                                {
                                    lifeTime2[i] = UnityEngine.Random.Range(vt, vt * 2.5f);
                                }
                                else
                                {
                                    lifeTime2[i] = 30;
                                }

                            }
                        }

                    }
                    else
                    {
                        lifeTime2[i] -= Time.deltaTime * 60;
                    }

                }
                if (dCheck) dCheck = false;


                if (lifeStart == 5) lifeStart = 6;

                //}

                //ダンス関連チェック
                //メイドのモーションをチェックし、全員のダンスモーションが終了していた場合にフラグを2にする
                if (danceFlag == 1)
                {
                    int dc = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (life_f[i][12] == "" || mn[bgID][i] == -1)
                        {
                            ++dc;
                            continue;
                        }

                        Animation anim = stockMaids[mn[bgID][i]].mem.body0.GetAnimation();
                        if (!anim.IsPlaying(life_f[i][0])) ++dc;

                        //特定のモーションを遅らせて再生
                        if (life_f[i][0] == "dance_cm3d2_kara_002_cktc_f1.anm")
                        {
                            if (lifeTime1[i] <= 0)
                            {
                                stockMaids[mn[bgID][i]].mem.CrossFadeAbsolute(life_f[i][0], GameUty.FileSystemOld, false, false, false, 0.5f, 1f);
                                lifeTime1[i] = 100000;
                            }
                            else
                            {
                                lifeTime1[i] -= Time.deltaTime * 60;
                                if (290 < lifeTime1[i] && lifeTime1[i] < 300) stockMaids[mn[bgID][i]].mem.body0.StopAnime(life_f[i][0]);
                            }
                        }
                        if (life_f[i][0] == "dance_cm3d_004_kano_f1.anm")
                        {
                            if (lifeTime1[i] <= 0)
                            {
                                stockMaids[mn[bgID][i]].mem.CrossFadeAbsolute(life_f[i][0], GameUty.FileSystemOld, false, false, false, 0.5f, 1f);
                                lifeTime1[i] = 100000;
                            }
                            else
                            {
                                lifeTime1[i] -= Time.deltaTime * 60;
                            }
                        }

                    }
                    if (dc == 4) danceFlag = 2;

                }

                //フラグが2の場合、ダンス曲とダンスモーションを再生する
                if (danceFlag == 2)
                {
                    if (life_f[0][12] != "" && life_f[0][12] != "dummy")
                    {
                        GameMain.Instance.SoundMgr.StopBGM(0f);
                        if (life_f[0][12] == "candygirl_short.ogg" || life_f[0][12] == "fusionicaddiction_short_pole.ogg" || life_f[0][12] == "lovemorecrymore_short_pole.ogg")
                        {
                            GameMain.Instance.SoundMgr.PlayBGM(life_f[0][12], 0f, false);
                        }
                        else
                        {
                            GameMain.Instance.SoundMgr.PlayBGMLegacy(life_f[0][12], 0f, false);
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (life_f[i][12] != "" && mn[bgID][i] != -1)
                        {

                            if (allFiles.Contains(life_f[i][0].Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
                            {
                                stockMaids[mn[bgID][i]].mem.CrossFadeAbsolute(life_f[i][0], false, false, false, 0.5f, 1f);
                            }
                            else if (allFilesOld.Contains(life_f[i][0].Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
                            {
                                stockMaids[mn[bgID][i]].mem.CrossFadeAbsolute(life_f[i][0], GameUty.FileSystemOld, false, false, false, 0.5f, 1f);
                            }

                            //特定のモーションは再生を遅らせるために一旦停止
                            if (life_f[i][0] == "dance_cm3d2_kara_002_cktc_f1.anm")
                            {
                                lifeTime1[i] = 350; //遅らせる時間設定
                            }
                            if (life_f[i][0] == "dance_cm3d_004_kano_f1.anm")
                            {
                                lifeTime1[i] = 10; //遅らせる時間設定
                            }
                        }
                    }
                    danceFlag = 1;
                }

                //カメラ移動処理
                if (!bOculusVR) ElMove();

            }

        }


        private void MaidSetMotion(string s, Maid m, float t, int n)
        {
            if (s == "") return;

            string[] motionList = s.Split('|');
            int i = UnityEngine.Random.Range(0, motionList.Length);
            string motion = motionList[i].Replace("[S]", "").Replace("[L]", "").Replace("_ONCE_", "_once_");
            bool old = false;

            if (allFiles.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                old = false;
            }
            else if (allFilesOld.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                old = true;
            }
            else
            {
                Console.WriteLine("モーションが見つかりません：" + motion);
                return;
            }

            if (motionList[i].Contains("[S]"))
            {
                if (old)
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, false, false, t, 1f);
                }
                else
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystem, false, false, false, t, 1f);
                }
                mOnceFlag[n] = true;
                mOnceBack[n] = motion;

            }
            else if (motionList[i].Contains("[L]"))
            {
                if (m.body0.LastAnimeFN == motion && lifeStart == 6) return;
                if (old)
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, true, false, t, 1f);
                }
                else
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystem, false, true, false, t, 1f);
                }
                mOnceFlag[n] = false;
                mOnceBack[n] = "";

            }
            else if (motion.Contains("_once_"))
            {
                if (old)
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, false, false, t, 1f);
                }
                else
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystem, false, false, false, t, 1f);
                }
                mOnceFlag[n] = true;
                if (allFiles.Contains(motion.Replace("f_once_", "taiki_f").Replace(".anm", "")))
                {
                    mOnceBack[n] = motion.Replace("f_once_", "taiki_f");
                }
                else
                {
                    mOnceBack[n] = motion;
                }

            }
            else
            {
                if (m.body0.LastAnimeFN == motion && lifeStart == 6) return;
                if (old)
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, true, false, t, 1f);
                }
                else
                {
                    m.CrossFadeAbsolute(motion, GameUty.FileSystem, false, true, false, t, 1f);
                }
                mOnceFlag[n] = false;
                mOnceBack[n] = "";

            }

            //連動して男モーションも変更
            for (int i2 = 0; i2 < 4; i2++)
            {
                if (intCnv(life_m[i2][7]) == n && life_m[i2][0] != "")
                {
                    ManSetMotion(life_m[i2][0], SubMans[i2], t, i);
                }
            }

            //表情タイマーを0
            lifeTime3[n] = 0;

            //"SEX_A"の場合は音声のオート変更処理
            if (life_f[n][13] == "SEX_A")
            {
                int iPersonal = Array.IndexOf(personalList[1], m.status.personal.uniqueName);
                lifeTime2[n] = 0;
                m.AudioMan.Stop();
                elMouthMode[n] = CheckMouthMode(motion);

                if (elMouthMode[n] == 0)
                {
                    if (motion.Contains("_3_f") || motion.Contains("_3a01_f") || motion.Contains("_3b01_f") || motion.Contains("_3b02_f") || motion.Contains("_3e01_f") || motion.Contains("_3e02_f"))
                    {
                        elVs[n] = new string[elVs_sex02[iPersonal].Length];
                        Array.Copy(elVs_sex02[iPersonal], elVs[n], elVs_sex02[iPersonal].Length);
                    }
                    else
                    {
                        elVs[n] = new string[elVs_sex01[iPersonal].Length];
                        Array.Copy(elVs_sex01[iPersonal], elVs[n], elVs_sex01[iPersonal].Length);
                    }

                }
                else if (elMouthMode[n] == 1)
                {
                    elVs[n] = new string[elVs_kiss01[iPersonal].Length];
                    Array.Copy(elVs_kiss01[iPersonal], elVs[n], elVs_kiss01[iPersonal].Length);

                }
                else if (elMouthMode[n] == 2)
                {
                    elVs[n] = new string[elVs_fera01[iPersonal].Length];
                    Array.Copy(elVs_fera01[iPersonal], elVs[n], elVs_fera01[iPersonal].Length);
                }

            }

        }

        private void ManSetMotion(string s, Maid m, float t, int i)
        {
            if (s == "") return;

            string[] motionList = s.Split('|');
            if (motionList.Length <= i) return;

            string motion = motionList[i];

            if (allFiles.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                m.CrossFadeAbsolute(motion, GameUty.FileSystem, false, true, false, t, 1f);

            }
            else if (allFilesOld.Contains(motion.Replace(".anm", ""), StringComparer.OrdinalIgnoreCase))
            {
                m.CrossFadeAbsolute(motion, GameUty.FileSystemOld, false, true, false, t, 1f);

            }
            else
            {
                Console.WriteLine("男のモーションが見つかりません：" + motion);
                return;
            }


        }


        private void MaidSetFace(string s, Maid m)
        {
            if (s == "") return;

            string[] faceList = s.Split('|');
            int i = UnityEngine.Random.Range(0, faceList.Length);
            m.FaceAnime(faceList[i], cfgw.fAnimeFadeTimeV, 0);
        }

        private void MaidSetItem(string s, Maid m)
        {
            if (s == "") return;

            string[] itemList = s.Split('|');

            foreach (string item in itemList)
            {
                string[] mItem = item.Split(',');
                m.SetProp(mItem[0], mItem[1], 0, true, false);
            }
            m.AllProcPropSeqStart();
        }


        private bool DistanceToMaid(int maidID, float cr)
        {

            //メイドさんの顔情報がない場合、取得する
            if (!maidsState[maidID].maidHead)
            {
                Transform[] objList = stockMaids[maidID].mem.transform.GetComponentsInChildren<Transform>();
                if (objList.Count() != 0)
                {
                    maidsState[maidID].maidHead = null;
                    foreach (var gameobject in objList)
                    {
                        if (gameobject.name == "Bone_Face" && maidsState[maidID].maidHead == null) maidsState[maidID].maidHead = gameobject;
                    }
                }
            }

            //カメラ位置を取得
            Transform cameraPos;
            cameraPos = mainCamera.transform;
            if (bOculusVR)
            {
                try
                {
                    Transform vrCameraPos = Util.GetObject.ByString("GameMain.m_objInstance.m_OvrMgr.m_trEyeAnchor") as Transform;
                    cameraPos = vrCameraPos;
                }
                catch (Exception ex) { }
            }


            //カメラと近接判定対象（ターゲット）の距離取得
            float fDistanceToMaid = Vector3.Distance(maidsState[maidID].maidHead.transform.position, cameraPos.position);
            float camCR = 0f;

            if (!bOculusVR) camCR = cr * (35.0f / Camera.main.fieldOfView);
            if (bOculusVR) camCR = cr * (60.0f / Camera.main.fieldOfView);

            if (fDistanceToMaid <= camCR)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private int bgC = 0;
        private void ElStart()
        {

            GetStockMaids();
            var ary = Enumerable.Range(0, stockMaids.Count).OrderBy(n => Guid.NewGuid()).Take(stockMaids.Count).ToArray(); //メイドの数だけ重複しないランダム変数を作成
            bgC = 0;
            maidOver = false;
            freeOver = false;
            exclusiveOver = false;

            int mi = 0;
            int ei = 0;
            int fi = 0;
            int[] hm = new int[] { -1, -1, -1, -1 };
            //flagN = GameMain.Instance.CharacterMgr.status.GetFlag("時間帯") == 3;


            //NTRブロック用にフリーとそれ以外のメイドを分ける
            List<int> exclusive = new List<int>();
            List<int> free = new List<int>();
            List<int> all = new List<int>();
            foreach (int a in ary)
            {
                if (stockMaids[a].mem.status.heroineType.ToString() == "Sub") continue; //NPCメイドを除外する

                all.Add(a);
                if (stockMaids[a].mem.status.contract.ToString() == "Free")
                {
                    free.Add(a);
                }
                else
                {
                    exclusive.Add(a);
                }
            }


            for (int i = 0; i < bgArray1.GetLength(0); i++)
            {

                //背景が存在するかどうかチェック
                UnityEngine.Object @object = GameMain.Instance.BgMgr.CreateAssetBundle(bgArray1[i][0]);
                if (@object == null)
                {
                    @object = Resources.Load("BG/" + bgArray1[i][0]);
                    if (@object == null)
                    {
                        @object = Resources.Load("BG/2_0/" + bgArray1[i][0]);
                    }
                }
                if (@object == null) bgArray1[i][3] = "0";

                if (bgArray1[i][3] == "0") continue;
                if (flagN && bgArray1[i][3] == "1") continue;
                if (!flagN && bgArray1[i][3] == "2") continue;
                if (bgArray1[i][0] == "MaidRoom") continue;

                //複数シーンファイルがある場合にランダム選択
                int r = UnityEngine.Random.Range(0, intCnv(bgArray1[i][10])) + 1;
                bgArray1[i][11] = r.ToString();

                //メイド配置のためにシーンファイルをロード
                ElLoad(i);

                //各シーンにランダムに並び替えたメイドを順番に配置する
                for (int i2 = 0; i2 < 4; i2++)
                {
                    if (life_f[i2][0] == "") continue;

                    if (cfgw.ntrBlock && flagN)
                    { //NTRブロック有効かつ夜の時
                        if (life_f[i2][17] == "0")
                        {
                            if (exclusive.Count <= i2)
                            {
                                mn[i][i2] = -1;
                                continue;
                            }

                            mn[i][i2] = exclusive[ei];
                            ++ei;
                            if (exclusive.Count <= ei)
                            {
                                ei = 0; //メイド数が限界に達した場合０に戻してループさせる
                                exclusiveOver = true;
                            }

                        }
                        else
                        {
                            if (free.Count <= i2)
                            {
                                mn[i][i2] = -1;
                                continue;
                            }

                            mn[i][i2] = free[fi];
                            ++fi;
                            if (free.Count <= fi)
                            {
                                fi = 0; //メイド数が限界に達した場合０に戻してループさせる
                                freeOver = true;
                            }
                        }
                        if (exclusiveOver && freeOver) maidOver = true;

                    }
                    else
                    { //NTRブロック無効時
                        if (all.Count <= i2)
                        {
                            mn[i][i2] = -1;
                            continue;
                        }

                        mn[i][i2] = all[mi];
                        ++mi;

                        if (all.Count <= mi)
                        {
                            mi = 0; //メイド数が限界に達した場合０に戻してループさせる
                            maidOver = true;
                        }
                    }

                }

                ++bgC;

            }

            if (cfgw.ntrBlock && flagN)
            {
                holidayMaid.Clear();
                if (!exclusiveOver)
                {
                    for (int e = ei; e < exclusive.Count; e++)
                    {
                        hm = new int[] { -1, -1, -1, -1 };
                        hm[0] = exclusive[ei];
                        ++ei;

                        holidayMaid.Add(hm);
                        ++bgC;
                    }
                }
                if (!freeOver)
                {
                    for (int f = fi; f < free.Count; f++)
                    {
                        hm = new int[] { -1, -1, -1, -1 };
                        hm[0] = free[fi];
                        ++fi;

                        holidayMaid.Add(hm);
                        ++bgC;
                    }
                }

            }
            else
            {
                holidayMaid.Clear();
                if (!maidOver)
                {
                    for (int i3 = mi; i3 < all.Count; i3++)
                    {
                        hm = new int[] { -1, -1, -1, -1 };
                        hm[0] = all[mi];
                        ++mi;

                        holidayMaid.Add(hm);
                        ++bgC;
                    }
                }
            }


            if (bgC % 4 == 0)
            {
                bgC = bgC / 4;
            }
            else
            {
                bgC = bgC / 4 + 1;
            }

        }



        private void ElEnd()
        {
            GameMain.Instance.MainCamera.FadeOut(0f, false, null, true, default(Color));
            elFade = true;

            lifeStart = 0;
            if (!bOculusVR) Camera.main.fieldOfView = 35.0f;
            elMouthMode = new int[] { 0, 0, 0, 0 };

            //全キャラ非表示
            GameMain.Instance.CharacterMgr.DeactivateMaidAll();
            GameMain.Instance.CharacterMgr.ResetCharaPosAll();
            foreach (Maid man in SubMans)
            {
                man.Visible = false;
            }

            //背景変更
            //bool flagN = GameMain.Instance.CharacterMgr.status.GetFlag("時間帯") == 3;
            if (!flagN) bgID = 0;
            if (flagN) bgID = 1;
            Console.WriteLine("背景チェンジ:" + bgID);
            GameMain.Instance.BgMgr.ChangeBg(bgArray1[bgID][0]);

            //カメラ移動
            Vector3 vNewPosition = Vector3.zero;
            vNewPosition = new Vector3(floatCnv(bgArray1[bgID][4]), floatCnv(bgArray1[bgID][5]), floatCnv(bgArray1[bgID][6]));
            mainCamera.transform.eulerAngles = new Vector3(floatCnv(bgArray1[bgID][7]), floatCnv(bgArray1[bgID][8]), floatCnv(bgArray1[bgID][9]));
            if (!bOculusVR)
            {
                mainCamera.SetPos(vNewPosition);
                mainCamera.SetTargetPos(vNewPosition, true);
                mainCamera.SetDistance(0f, true);
            }
            else
            {
                mainCamera.SetPos(vNewPosition);
            }

            //BGM変更
            GameMain.Instance.SoundMgr.PlayBGMLegacy("bgm015.ogg", 0f, true);

            GameMain.Instance.MainCamera.FadeIn(1f, false, null, true, true, default(Color));
            elFade = false;

        }


        private float speed = 1;
        private void ElMove()
        {

            Vector3 vNewPosition = Vector3.zero;
            vNewPosition = Camera.main.transform.position;
            float frontValue = 0;
            float rightValue = 0;


            if (Input.GetKey(KeyCode.W)) frontValue = 0.025f * speed;
            if (Input.GetKey(KeyCode.S)) frontValue = -0.025f * speed;
            if (Input.GetKey(KeyCode.D)) rightValue = 0.025f * speed;
            if (Input.GetKey(KeyCode.A)) rightValue = -0.025f * speed;

            if (frontValue != 0 || rightValue != 0)
            {
                frontValue += 0.029f;
                Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;
                Vector3 moveForward = cameraForward * frontValue + Camera.main.transform.right * rightValue;
                vNewPosition += moveForward;

                //カメラ位置の移動
                if (!bOculusVR)
                {
                    mainCamera.SetPos(vNewPosition);
                    mainCamera.SetTargetPos(vNewPosition, true);
                    mainCamera.SetDistance(0f, true);
                }
                else
                {
                    mainCamera.SetPos(vNewPosition);
                }
            }

        }

        private bool elFade = false;
        private IEnumerator ElChange(int i)
        {

            GameMain.Instance.MainCamera.FadeOut(0f, false, null, true, default(Color));
            elFade = true;
            yield return new WaitForSeconds(0.1f);

            bgID = i;
            lifeStart = 1;
        }

        private IEnumerator ElChangeEnd()
        {
            yield return new WaitForSeconds(1f);
            GameMain.Instance.MainCamera.FadeIn(1f, false, null, true, true, default(Color));
            elFade = false;
            lifeStart = 5;
        }


        //エンパイアズライフのシーン設定読み込み
        private void ElLoad(int i)
        {

            string r = bgArray1[i][11];
            switch (i)
            {
                case 0:
                    life00_01f.CopyTo(life_f, 0);
                    life00_01m.CopyTo(life_m, 0);
                    break;

                case 1:
                    life01_01f.CopyTo(life_f, 0);
                    life01_01m.CopyTo(life_m, 0);
                    break;

                case 2:
                    life02_01f.CopyTo(life_f, 0);
                    life02_01m.CopyTo(life_m, 0);
                    break;

                case 3:
                    if (r == "1")
                    {
                        life03_01f.CopyTo(life_f, 0);
                        life03_01m.CopyTo(life_m, 0);
                    }
                    else if (r == "2")
                    {
                        life03_02f.CopyTo(life_f, 0);
                        life03_02m.CopyTo(life_m, 0);
                    }
                    else if (r == "3")
                    {
                        life03_03f.CopyTo(life_f, 0);
                        life03_03m.CopyTo(life_m, 0);
                    }
                    else if (r == "4")
                    {
                        life03_04f.CopyTo(life_f, 0);
                        life03_04m.CopyTo(life_m, 0);
                    }
                    else if (r == "5")
                    {
                        life03_05f.CopyTo(life_f, 0);
                        life03_05m.CopyTo(life_m, 0);
                    }
                    break;

                case 4:
                    life04_01f.CopyTo(life_f, 0);
                    life04_01m.CopyTo(life_m, 0);
                    break;

                case 5:
                    life05_01f.CopyTo(life_f, 0);
                    life05_01m.CopyTo(life_m, 0);
                    break;

                case 6:
                    life06_01f.CopyTo(life_f, 0);
                    life06_01m.CopyTo(life_m, 0);
                    break;

                case 7:
                    life07_01f.CopyTo(life_f, 0);
                    life07_01m.CopyTo(life_m, 0);
                    break;

                case 8:
                    life08_01f.CopyTo(life_f, 0);
                    life08_01m.CopyTo(life_m, 0);
                    break;

                case 9:
                    life09_01f.CopyTo(life_f, 0);
                    life09_01m.CopyTo(life_m, 0);
                    break;

                case 10:
                    life10_01f.CopyTo(life_f, 0);
                    life10_01m.CopyTo(life_m, 0);
                    break;

                case 11:
                    life11_01f.CopyTo(life_f, 0);
                    life11_01m.CopyTo(life_m, 0);
                    break;

                case 12:
                    life12_01f.CopyTo(life_f, 0);
                    life12_01m.CopyTo(life_m, 0);
                    break;

                case 13:
                    if (r == "1")
                    {
                        life13_01f.CopyTo(life_f, 0);
                        life13_01m.CopyTo(life_m, 0);
                    }
                    else if (r == "2")
                    {
                        life13_02f.CopyTo(life_f, 0);
                        life13_02m.CopyTo(life_m, 0);
                    }
                    break;

                case 14:
                    life14_01f.CopyTo(life_f, 0);
                    life14_01m.CopyTo(life_m, 0);
                    break;

                case 15:
                    life15_01f.CopyTo(life_f, 0);
                    life15_01m.CopyTo(life_m, 0);
                    break;

                case 16:
                    life16_01f.CopyTo(life_f, 0);
                    life16_01m.CopyTo(life_m, 0);
                    break;

                case 17:
                    life17_01f.CopyTo(life_f, 0);
                    life17_01m.CopyTo(life_m, 0);
                    break;

                case 18:
                    life18_01f.CopyTo(life_f, 0);
                    life18_01m.CopyTo(life_m, 0);
                    break;

                case 19:
                    life19_01f.CopyTo(life_f, 0);
                    life19_01m.CopyTo(life_m, 0);
                    break;

                case 20:
                    life20_01f.CopyTo(life_f, 0);
                    life20_01m.CopyTo(life_m, 0);
                    break;

                case 21:
                    life21_01f.CopyTo(life_f, 0);
                    life21_01m.CopyTo(life_m, 0);
                    break;

                case 22:
                    life22_01f.CopyTo(life_f, 0);
                    life22_01m.CopyTo(life_m, 0);
                    break;

                case 23:
                    life23_01f.CopyTo(life_f, 0);
                    life23_01m.CopyTo(life_m, 0);
                    break;

                case 24:
                    life24_01f.CopyTo(life_f, 0);
                    life24_01m.CopyTo(life_m, 0);
                    break;

                case 25:
                    life25_01f.CopyTo(life_f, 0);
                    life25_01m.CopyTo(life_m, 0);
                    break;

                case 26:
                    life26_01f.CopyTo(life_f, 0);
                    life26_01m.CopyTo(life_m, 0);
                    break;

                case 27:
                    life27_01f.CopyTo(life_f, 0);
                    life27_01m.CopyTo(life_m, 0);
                    break;

                case 28:
                    life28_01f.CopyTo(life_f, 0);
                    life28_01m.CopyTo(life_m, 0);
                    break;

                case 29:
                    life29_01f.CopyTo(life_f, 0);
                    life29_01m.CopyTo(life_m, 0);
                    break;

                case 30:
                    life30_01f.CopyTo(life_f, 0);
                    life30_01m.CopyTo(life_m, 0);
                    break;

                case 31:
                    life31_01f.CopyTo(life_f, 0);
                    life31_01m.CopyTo(life_m, 0);
                    break;

                case 32:
                    if (r == "1")
                    {
                        life32_01f.CopyTo(life_f, 0);
                        life32_01m.CopyTo(life_m, 0);
                    }
                    else if (r == "2")
                    {
                        life32_02f.CopyTo(life_f, 0);
                        life32_02m.CopyTo(life_m, 0);
                    }
                    break;

                case 33:
                    life33_01f.CopyTo(life_f, 0);
                    life33_01m.CopyTo(life_m, 0);
                    break;

                case 34:
                    life34_01f.CopyTo(life_f, 0);
                    life34_01m.CopyTo(life_m, 0);
                    break;

                case 35:
                    life35_01f.CopyTo(life_f, 0);
                    life35_01m.CopyTo(life_m, 0);
                    break;

                case 36:
                    life36_01f.CopyTo(life_f, 0);
                    life36_01m.CopyTo(life_m, 0);
                    break;

                case 37:
                    life37_01f.CopyTo(life_f, 0);
                    life37_01m.CopyTo(life_m, 0);
                    break;

                case 38:
                    int r2 = UnityEngine.Random.Range(0, 90);
                    if (r2 < 20)
                    {
                        life38_01f.CopyTo(life_f, 0);
                        life38_01m.CopyTo(life_m, 0);
                    }
                    else if (r2 < 40)
                    {
                        life38_02f.CopyTo(life_f, 0);
                        life38_02m.CopyTo(life_m, 0);
                    }
                    else if (r2 < 60)
                    {
                        life38_03f.CopyTo(life_f, 0);
                        life38_03m.CopyTo(life_m, 0);
                    }
                    else if (r2 < 80)
                    {
                        life38_04f.CopyTo(life_f, 0);
                        life38_04m.CopyTo(life_m, 0);
                    }
                    else if (r2 < 85)
                    {
                        life38_05f.CopyTo(life_f, 0);
                        life38_05m.CopyTo(life_m, 0);
                    }
                    else
                    {
                        life38_06f.CopyTo(life_f, 0);
                        life38_06m.CopyTo(life_m, 0);
                    }
                    break;

                case 39:
                    life39_01f.CopyTo(life_f, 0);
                    life39_01m.CopyTo(life_m, 0);
                    break;
            }

        }

        //エンパイアズライフ関係終了-----------------------





        //おさわり処理関係-----------------------

        //おさわり用ターゲット配置
        private void targetSet(int maidID)
        {
            Maid maid = stockMaids[maidID].mem;
            maidsState[maidID].bodyName = maid.GetProp(MPN.body).strFileName;
            Console.WriteLine("お触りボディ:" + maidsState[maidID].bodyName);

            //口
            maidsState[maidID].targetSphere_mouth = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_mouth.name = "MO_" + maidID;
            maidsState[maidID].targetSphere_mouth.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            maidsState[maidID].targetSphere_mouth.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider0 = maidsState[maidID].targetSphere_mouth.gameObject.AddComponent<BoxCollider>();
            boxCollider0.isTrigger = true;
            maidsState[maidID].IK_mouth = CMT.SearchObjName(maid.body0.m_Bones.transform, "Bip01 Head", true);

            //むね
            maidsState[maidID].targetSphere_muneR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_muneR.name = "MR_" + maidID;
            maidsState[maidID].targetSphere_muneR.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            maidsState[maidID].targetSphere_muneR.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider1 = maidsState[maidID].targetSphere_muneR.gameObject.AddComponent<BoxCollider>();
            boxCollider1.isTrigger = true;
            maidsState[maidID].IK_muneR = CMT.SearchObjName(maid.body0.m_Bones.transform, "_IK_muneR", true);

            maidsState[maidID].targetSphere_muneL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_muneL.name = "ML_" + maidID;
            maidsState[maidID].targetSphere_muneL.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            maidsState[maidID].targetSphere_muneL.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider2 = maidsState[maidID].targetSphere_muneL.gameObject.AddComponent<BoxCollider>();
            boxCollider2.isTrigger = true;
            maidsState[maidID].IK_muneL = CMT.SearchObjName(maid.body0.m_Bones.transform, "_IK_muneL", true);

            //おしり
            maidsState[maidID].targetSphere_hipL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_hipL.name = "HL_" + maidID;
            maidsState[maidID].targetSphere_hipL.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
            maidsState[maidID].targetSphere_hipL.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider3 = maidsState[maidID].targetSphere_hipL.gameObject.AddComponent<BoxCollider>();
            boxCollider3.isTrigger = true;
            maidsState[maidID].IK_hipL = CMT.SearchObjName(maid.body0.m_Bones.transform, "_IK_hipL", true);
            maidsState[maidID].Hip_L = CMT.SearchObjName(maid.body0.m_Bones.transform, "Hip_L", true);

            maidsState[maidID].targetSphere_hipR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_hipR.name = "HR_" + maidID;
            maidsState[maidID].targetSphere_hipR.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
            maidsState[maidID].targetSphere_hipR.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider4 = maidsState[maidID].targetSphere_hipR.gameObject.AddComponent<BoxCollider>();
            boxCollider4.isTrigger = true;
            maidsState[maidID].IK_hipR = CMT.SearchObjName(maid.body0.m_Bones.transform, "_IK_hipR", true);
            maidsState[maidID].Hip_R = CMT.SearchObjName(maid.body0.m_Bones.transform, "Hip_R", true);

            //大事なとこ
            maidsState[maidID].targetSphere_vagina = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_vagina.name = "VA_" + maidID;
            maidsState[maidID].targetSphere_vagina.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            maidsState[maidID].targetSphere_vagina.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider5 = maidsState[maidID].targetSphere_vagina.gameObject.AddComponent<BoxCollider>();
            boxCollider5.isTrigger = true;
            maidsState[maidID].IK_vagina = CMT.SearchObjName(maid.body0.m_Bones.transform, "Bip01 Pelvis", true);

            //アナル
            maidsState[maidID].targetSphere_anal = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            maidsState[maidID].targetSphere_anal.name = "AN_" + maidID;
            maidsState[maidID].targetSphere_anal.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            maidsState[maidID].targetSphere_anal.GetComponent<Renderer>().enabled = false;
            BoxCollider boxCollider6 = maidsState[maidID].targetSphere_anal.gameObject.AddComponent<BoxCollider>();
            boxCollider6.isTrigger = true;
            maidsState[maidID].IK_anal = CMT.SearchObjName(maid.body0.m_Bones.transform, "_IK_anal", true);

        }


        //お触りターゲット消去
        private void targetDestroy(int maidID)
        {
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_mouth);
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_muneR);
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_muneL);
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_hipL);
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_hipR);
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_vagina);
            UnityEngine.Object.Destroy(maidsState[maidID].targetSphere_anal);
        }


        //ターゲット位置の更新
        private void targetInstallation(int maidID)
        {

            if (maidsState[maidID].bodyName != stockMaids[maidID].mem.GetProp(MPN.body).strFileName) targetDestroy(maidID);
            if (!maidsState[maidID].targetSphere_mouth) targetSet(maidID);

            maidsState[maidID].targetSphere_mouth.transform.position = maidsState[maidID].IK_mouth.transform.position;

            maidsState[maidID].targetSphere_muneR.transform.position = maidsState[maidID].IK_muneR.transform.position;
            maidsState[maidID].targetSphere_muneL.transform.position = maidsState[maidID].IK_muneL.transform.position;

            float x = (maidsState[maidID].IK_hipL.transform.position.x + maidsState[maidID].Hip_L.transform.position.x) / 2f;
            float y = (maidsState[maidID].IK_hipL.transform.position.y + maidsState[maidID].Hip_L.transform.position.y) / 2f;
            float z = (maidsState[maidID].IK_hipL.transform.position.z + maidsState[maidID].Hip_L.transform.position.z) / 2f;
            maidsState[maidID].targetSphere_hipL.transform.position = new Vector3(x, y, z);

            x = (maidsState[maidID].IK_hipR.transform.position.x + maidsState[maidID].Hip_R.transform.position.x) / 2f;
            y = (maidsState[maidID].IK_hipR.transform.position.y + maidsState[maidID].Hip_R.transform.position.y) / 2f;
            z = (maidsState[maidID].IK_hipR.transform.position.z + maidsState[maidID].Hip_R.transform.position.z) / 2f;
            maidsState[maidID].targetSphere_hipR.transform.position = new Vector3(x, y, z);

            maidsState[maidID].targetSphere_vagina.transform.position = maidsState[maidID].IK_vagina.transform.position;

            maidsState[maidID].targetSphere_anal.transform.position = maidsState[maidID].IK_anal.transform.position;
        }

        private int osawariLock = 0;
        private int osawariID = -1;
        private int osawariLevel = 0;
        private string osawariPoint = "";
        private float sensitivity = 0.1f; // マウス感度
        private float mouse_move = 0f;
        private float move_x = 0f;
        private float move_y = 0f;
        private float moveCheck = 20f;
        private float Move_atp_x = 0f;
        private float Move_atp_y = 0f;
        private Vector3 back_IK_Pos;
        private string hitName = "";

        private float MuneUpDown = 0f;
        private float MuneBlend = 0f;
        private float MuneUpDown_f = 0f;
        private float MuneYori = 0f;
        private float MuneYori_f = 0f;

        private float MuneX = 0f;
        private float MuneY = 0f;
        private float timeX = 0f;
        private float timeY = 0f;


        //お触り時の処理
        private void osawariHand()
        {

            if (osawariID != -1 && vmId.IndexOf(osawariID) == -1) osawariLock = 9;

            if (osawariLock == 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                hitName = "";

                if (Physics.Raycast(ray, out hit))
                {

                    hitName = hit.collider.gameObject.name;
                    if (Regex.IsMatch(hitName, @"^[a-zA-Z][a-zA-Z]_"))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            osawariLock = 1;
                            osawariID = intCnv(Regex.Replace(hitName, @"^[a-zA-Z][a-zA-Z]_", ""));
                            Maid maid = stockMaids[osawariID].mem;

                            if (Regex.IsMatch(hitName, @"^MO_")) osawariPoint = "mouth";
                            if (Regex.IsMatch(hitName, @"^ML_"))
                            {
                                osawariPoint = "muneL";
                                MuneUpDown = maid.body0.jbMuneL.MuneUpDown;
                                MuneBlend = maid.body0.jbMuneL.BlendValue2;
                                MuneUpDown_f = maid.body0.jbMuneL.MuneUpDown_f;
                                MuneYori = maid.body0.jbMuneL.MuneYori;
                                MuneYori_f = maid.body0.jbMuneL.MuneYori_f;
                            }
                            if (Regex.IsMatch(hitName, @"^MR_"))
                            {
                                osawariPoint = "muneR";
                                MuneUpDown = maid.body0.jbMuneR.MuneUpDown;
                                MuneBlend = maid.body0.jbMuneR.BlendValue2;
                                MuneUpDown_f = maid.body0.jbMuneR.MuneUpDown_f;
                                MuneYori = maid.body0.jbMuneR.MuneYori;
                                MuneYori_f = maid.body0.jbMuneR.MuneYori_f;
                            }
                            if (Regex.IsMatch(hitName, @"^HL_")) osawariPoint = "hipL";
                            if (Regex.IsMatch(hitName, @"^HR_")) osawariPoint = "hipR";
                            if (Regex.IsMatch(hitName, @"^VA_")) osawariPoint = "vagina";
                            if (Regex.IsMatch(hitName, @"^AN_")) osawariPoint = "anal";

                            //checkBlowjobing(osawariID);
                            if (!maidsState[osawariID].stunFlag && maidsState[osawariID].bIsBlowjobing != 2) stockMaids[osawariID].mem.EyeToCamera((Maid.EyeMoveType)5, 0.8f);
                            //if(maidsState[osawariID].vStateMajor == 10)ReactionPlay(osawariID);
                        }
                    }
                }

            }
            else if (osawariLock == 1)
            {

                Maid maid = stockMaids[osawariID].mem;

                if (Input.GetMouseButtonUp(0))
                { //マウスリリース時の処理
                    if (osawariPoint == "muneL" || osawariPoint == "muneR")
                    {
                        MuneX = Move_atp_x;
                        MuneY = Move_atp_y;
                        timeX = 0f;
                        timeY = 0f;
                    }
                }

                //マウスドラッグ時の処理
                if (Input.GetMouseButton(0))
                {
                    //マウスの移動値取得
                    if (moveCheck > 0f)
                    {
                        move_x += System.Math.Abs(Input.GetAxis("Mouse X")) * sensitivity;
                        move_y += System.Math.Abs(Input.GetAxis("Mouse Y")) * sensitivity;

                        moveCheck -= timerRate;
                    }
                    else
                    {
                        if (move_x >= move_y) mouse_move = (mouse_move + move_x) * 0.5f;
                        if (move_x < move_y) mouse_move = (mouse_move + move_y) * 0.5f;
                        move_x = 0f;
                        move_y = 0f;
                        moveCheck = 20f;
                    }

                    //お触りレベル判定
                    if (osawariLevel == 0)
                    {
                        if (mouse_move > 2f) osawariLevel = 1;
                    }
                    else if (osawariLevel == 1)
                    {
                        if (mouse_move < 0.5f) osawariLevel = 0;
                        if (mouse_move > 4f) osawariLevel = 2;
                    }
                    else if (osawariLevel == 2)
                    {
                        if (mouse_move < 2f) osawariLevel = 1;
                    }

                    //シェイプキー操作用の値
                    Move_atp_x += Input.GetAxis("Mouse X") * sensitivity * 0.7f;
                    if (Move_atp_x > 1f) Move_atp_x = 1f;
                    if (Move_atp_x < -1f) Move_atp_x = -1f;
                    Move_atp_y += Input.GetAxis("Mouse Y") * sensitivity * 0.7f;
                    if (Move_atp_y > 1f) Move_atp_y = 1f;
                    if (Move_atp_y < -1f) Move_atp_y = -1f;



                }
                else
                {
                    //マウスリリースしたあとの処理
                    if (osawariPoint == "muneL" || osawariPoint == "muneR")
                    {

                        float sinX = -Mathf.Sin(2 * Mathf.PI * 3 * timeX);
                        float sinY = -Mathf.Sin(2 * Mathf.PI * 3 * timeY);

                        if (MuneX > 0)
                        {
                            MuneX -= timerRate / (60f + (float)maid.GetProp(MPN.MuneL).value * 0.5f);
                            if (MuneX < 0) MuneX = 0f;
                        }
                        else if (MuneX < 0)
                        {
                            MuneX += timerRate / (60f + (float)maid.GetProp(MPN.MuneL).value * 0.5f);
                            if (MuneX > 0) MuneX = 0f;
                        }
                        if (MuneY > 0)
                        {
                            MuneY -= timerRate / (60f + (float)maid.GetProp(MPN.MuneL).value * 0.5f);
                            if (MuneY < 0) MuneY = 0f;
                        }
                        else if (MuneY < 0)
                        {
                            MuneY += timerRate / (60f + (float)maid.GetProp(MPN.MuneL).value * 0.5f);
                            if (MuneY > 0) MuneY = 0f;
                        }

                        timeX += timerRate / (60f + (float)maid.GetProp(MPN.MuneL).value * 0.5f);
                        timeY += timerRate / (60f + (float)maid.GetProp(MPN.MuneL).value * 0.5f);

                        Move_atp_x = sinX * MuneX;
                        Move_atp_y = sinY * MuneY;

                        if (MuneX == 0 && MuneY == 0) osawariLock = 2;

                    }
                    else
                    {
                        osawariLock = 2;
                    }
                }



                //お触りポイント別の処理
                float hipX = 0f;
                if (osawariPoint == "vagina")
                {
                    try { VertexMorph_FromProcItem(maid.body0, "atp_vagina", (Move_atp_y - 1f) * -0.5f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "labiakupa_dia", System.Math.Abs(Move_atp_x) * 0.5f); } catch { /*LogError(ex);*/ }
                }

                if (osawariPoint == "muneL")
                {
                    maid.body0.jbMuneL.MuneUpDown = MuneUpDown + Move_atp_y * 60f;
                    maid.body0.jbMuneL.BlendValue2 = MuneBlend + Move_atp_y;
                    maid.body0.jbMuneL.MuneUpDown_f = MuneUpDown_f + Mathf.Abs(Move_atp_y) * 2f;

                    maid.body0.jbMuneL.MuneYori = MuneYori + Move_atp_x * 25f;
                    maid.body0.jbMuneL.MuneYori_f = MuneYori_f + Mathf.Abs(Move_atp_x) * 2f;

                    maid.body0.bonemorph.Blend();
                }

                if (osawariPoint == "muneR")
                {
                    maid.body0.jbMuneR.MuneUpDown = MuneUpDown + Move_atp_y * 60f;
                    maid.body0.jbMuneR.BlendValue2 = MuneBlend - Move_atp_y;
                    maid.body0.jbMuneR.MuneUpDown_f = MuneUpDown_f + Mathf.Abs(Move_atp_y) * 2f;

                    maid.body0.jbMuneR.MuneYori = MuneYori - Move_atp_x * 25f;
                    maid.body0.jbMuneR.MuneYori_f = MuneYori_f + Mathf.Abs(Move_atp_x) * 2f;

                    maid.body0.bonemorph.Blend();
                }

                if (osawariPoint == "hipR")
                {
                    hipX = Move_atp_x;
                }

                if (osawariPoint == "hipL")
                {
                    hipX = Move_atp_x * -1;
                }

                if (osawariPoint == "hipL" || osawariPoint == "hipR")
                {
                    try { VertexMorph_FromProcItem(maid.body0, "hip_type_A", Move_atp_y); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "slim_hip1", Move_atp_y); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "debu_pelvis_x", hipX); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "debu_pelvis_y", Move_atp_y); } catch { /*LogError(ex);*/ }

                    try { VertexMorph_FromProcItem(maid.body0, "hip_type_V", 0.3f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "slim_oshiri", System.Math.Abs(Move_atp_y + Move_atp_x) * 0.2f); } catch { /*LogError(ex);*/ }
                }

                if (osawariPoint == "anal")
                {
                    try { VertexMorph_FromProcItem(maid.body0, "anal_swell2", (Move_atp_y) * -0.5f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "anal_swell3", (Move_atp_y - 1f) * -0.5f); } catch { /*LogError(ex);*/ }
                }



            }
            else if (osawariLock == 2)
            {

                Maid maid = stockMaids[osawariID].mem;

                if (osawariPoint == "vagina")
                {
                    try { VertexMorph_FromProcItem(maid.body0, "atp_vagina", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "labiakupa_dia", 0f); } catch { /*LogError(ex);*/ }

                }
                else if (osawariPoint == "anal")
                {
                    try { VertexMorph_FromProcItem(maid.body0, "anal_swell2", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "anal_swell3", 0f); } catch { /*LogError(ex);*/ }

                }
                else if (osawariPoint == "hipL" || osawariPoint == "hipR")
                {
                    try { VertexMorph_FromProcItem(maid.body0, "hip_type_A", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "slim_hip1", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "debu_pelvis_x", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "debu_pelvis_y", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "hip_type_V", 0f); } catch { /*LogError(ex);*/ }
                    try { VertexMorph_FromProcItem(maid.body0, "slim_oshiri", 0f); } catch { /*LogError(ex);*/ }

                }
                else if (osawariPoint == "muneL")
                {
                    maid.body0.jbMuneL.MuneUpDown = MuneUpDown;
                    maid.body0.jbMuneL.BlendValue2 = MuneBlend;
                    maid.body0.jbMuneL.MuneUpDown_f = MuneUpDown_f;
                    maid.body0.jbMuneL.MuneYori = MuneYori;
                    maid.body0.jbMuneL.MuneYori_f = MuneYori_f;
                    maid.body0.bonemorph.Blend();

                }
                else if (osawariPoint == "muneR")
                {
                    maid.body0.jbMuneR.MuneUpDown = MuneUpDown;
                    maid.body0.jbMuneR.BlendValue2 = MuneBlend;
                    maid.body0.jbMuneR.MuneUpDown_f = MuneUpDown_f;
                    maid.body0.jbMuneR.MuneYori = MuneYori;
                    maid.body0.jbMuneR.MuneYori_f = MuneYori_f;
                    maid.body0.bonemorph.Blend();
                }

                osawariLock = 9;


            }
            else if (osawariLock == 9)
            {
                osawariLock = 0;
                osawariID = -1;
                osawariLevel = 0;
                osawariPoint = "";
                mouse_move = 0f;
                Move_atp_x = 0f;
                Move_atp_y = 0f;
                MuneX = 0f;
                MuneY = 0f;
                timeX = 0f;
                timeY = 0f;
            }


        }





        //おさわり処理関係終了-----------------------




    }
}




//　以下、cm3d2.reflectiontest.plugin.cs より拝借（ありがとうございました）

namespace Util
{
    public static class GetObject
    {
        /// <summary>
        /// static変数を取得する
        /// </summary>
        /// <example>
        /// <code>
        /// var cm = GetObject.ByString("GameMain.m_objInstance.m_CharacterMgr") as CharacterMgr;
        /// Console.WriteLine("cm = {0}", cm);
        /// </code>
        /// </example>
        public static object ByString(string longFieldName)
        {
            string[] ss = longFieldName.Split('.');
            return ByString(TypeByString(ss[0]), string.Join(".", ss, 1, ss.Length - 1));
        }

        /// <summary>
        /// 型情報とフィールド名を元にstatic変数を取得する
        /// </summary>
        /// <example>
        /// 「var cm = GameMain.Instance.CharacterMgr」と同等のコード例
        /// <code>
        /// var cm = GetObject.ByString(typeof(GameMain), "m_objInstance.m_CharacterMgr") as CharacterMgr;
        /// Console.WriteLine("cm = {0}", cm);
        /// </code>
        /// </example>
        public static object ByString(Type type, string longFieldName)
        {
            return ByString(type, null, longFieldName);
        }

        /// <summary>
        /// インスタンス変数を取得する
        /// </summary>
        /// <example>
        /// 「var first_name = maid.status.firstName」と同等のコード例
        /// <code>
        /// Maid maid = GameMain.Instance.CharacterMgr.GetStockMaid(0);
        /// var first_name = GetObject.ByString(maid, "m_Param.status_.first_name") as string;
        /// Console.WriteLine("first_name = {0}", first_name);
        /// </code>
        /// </example>
        public static object ByString(object instance, string longFieldName)
        {
            return ByString(null, instance, longFieldName);
        }

        //
        public static object ByString(Type type, object instance, string longFieldName)
        {
            string[] fieldNames = longFieldName.Split('.');
            foreach (string fieldName in fieldNames)
            {
                if (instance != null)
                {
                    type = instance.GetType();
                }
                if (type == null)
                {
                    return null;
                }

                FieldInfo fi = type.GetField(
                    fieldName,
                    BindingFlags.Instance | BindingFlags.Static |
                    BindingFlags.Public | BindingFlags.NonPublic);
                if (fi == null)
                {
                    return null;
                }
                instance = fi.GetValue(instance);
            }
            return instance;
        }

        public static Type TypeByString(string typeName)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type type = assembly.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }
            return null;
        }
    }
}
