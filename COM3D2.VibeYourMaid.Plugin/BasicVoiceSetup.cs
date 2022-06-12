using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM3D2.VibeYourMaid.Plugin
{
    public static class BasicVoiceSetup
    {

        //性格別声テーブル　ツンデレ---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20PrideVibe = new string[][] {
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20PrideFera = new string[][] {
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30PrideVibe = new string[][] {
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01326.ogg" , "s0_01327.ogg" , "s0_01330.ogg" , "s0_01331.ogg" },
              new string[] { "s0_01236.ogg" , "s0_01237.ogg" , "s0_01238.ogg" , "s0_01239.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30PrideFera = new string[][] {
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01385.ogg" , "S0_01371.ogg" , "S0_01386.ogg" , "S0_01387.ogg" },
              new string[] { "S0_01383.ogg" , "S0_01367.ogg" , "S0_01384.ogg" , "S0_01369.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30PrideVibe = new string[][] {
              new string[] { "s0_01898.ogg" , "s0_01899.ogg" , "s0_01902.ogg" , "s0_01900.ogg" },
              new string[] { "s0_01913.ogg" , "s0_01918.ogg" , "s0_01919.ogg" , "s0_01917.ogg" },
              new string[] { "s0_09072.ogg" , "s0_09070.ogg" , "s0_09099.ogg" , "s0_09059.ogg" },
              new string[] { "s0_09067.ogg" , "s0_09068.ogg" , "s0_09069.ogg" , "s0_09071.ogg" , "s0_09085.ogg" , "s0_09086.ogg" , "s0_09087.ogg" , "s0_09091.ogg" },
              new string[] { "s0_01898.ogg" , "s0_01899.ogg" , "s0_01902.ogg" , "s0_01900.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30PrideFera = new string[][] {
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" },
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" },
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" },
              new string[] { "S0_11361.ogg" , "S0_01931.ogg" , "S0_11350.ogg" , "S0_11349.ogg" },
              new string[] { "S0_01922.ogg" , "S0_01920.ogg" , "S0_01921.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40PrideVibe = new string[] { "S0_01967.ogg", "S0_01967.ogg", "S0_01968.ogg", "S0_01969.ogg", "S0_01969.ogg" };



        //性格別声テーブル　クーデレ---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20CoolVibe = new string[][] {
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20CoolFera = new string[][] {
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30CoolVibe = new string[][] {
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02401.ogg" , "s1_02400.ogg" , "s1_02402.ogg" , "s1_02404.ogg" },
              new string[] { "s1_02396.ogg" , "s1_02390.ogg" , "s1_02391.ogg" , "s1_02392.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30CoolFera = new string[][] {
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02458.ogg" , "S1_02459.ogg" , "S1_02444.ogg" , "S1_02460.ogg" },
              new string[] { "S1_02455.ogg" , "S1_02440.ogg" , "S1_02457.ogg" , "S1_02442.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30CoolVibe = new string[][] {
              new string[] { "s1_03223.ogg" , "s1_03246.ogg" , "s1_03247.ogg" , "s1_03210.ogg" },
              new string[] { "s1_03214.ogg" , "s1_03215.ogg" , "s1_03216.ogg" , "s1_03209.ogg" },
              new string[] { "s1_03207.ogg" , "s1_03205.ogg" , "s1_08993.ogg" , "s1_08971.ogg" },
              new string[] { "s1_09344.ogg" , "s1_09370.ogg" , "s1_09371.ogg" , "s1_09372.ogg" , "s1_09374.ogg" , "s1_09398.ogg" , "s1_09392.ogg" , "s1_09365.ogg" },
              new string[] { "s1_03223.ogg" , "s1_03246.ogg" , "s1_03247.ogg" , "s1_03210.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30CoolFera = new string[][] {
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" },
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" },
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" },
              new string[] { "S1_11440.ogg" , "S1_11429.ogg" , "S1_11952.ogg" , "S1_19221.ogg" },
              new string[] { "S1_03219.ogg" , "S1_03218.ogg" , "S1_03228.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40CoolVibe = new string[] { "S1_03264.ogg", "S1_03264.ogg", "S1_03265.ogg", "S1_03266.ogg", "S1_03266.ogg" };



        //性格別声テーブル　純真---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20PureVibe = new string[][] {
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20PureFera = new string[][] {
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30PureVibe = new string[][] {
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01185.ogg" , "s2_01186.ogg" , "s2_01187.ogg" , "s2_01188.ogg" },
              new string[] { "s2_01235.ogg" , "s2_01236.ogg" , "s2_01237.ogg" , "s2_01238.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30PureFera = new string[][] {
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01299.ogg" , "S2_01300.ogg" , "S2_01285.ogg" , "S2_01301.ogg" },
              new string[] { "S2_01296.ogg" , "S2_01281.ogg" , "S2_01298.ogg" , "S2_01282.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30PureVibe = new string[][] {
              new string[] { "s2_01478.ogg" , "s2_01477.ogg" , "s2_01476.ogg" , "s2_01475.ogg" },
              new string[] { "s2_01432.ogg" , "s2_01433.ogg" , "s2_01434.ogg" , "s2_01436.ogg" },
              new string[] { "s2_09039.ogg" , "s2_09067.ogg" , "s2_09052.ogg" , "s2_08502.ogg" },
              new string[] { "s2_09047.ogg" , "s2_09048.ogg" , "s2_09049.ogg" , "s2_09050.ogg" , "s2_09051.ogg" , "s2_09066.ogg" , "s2_09069.ogg" , "s2_09073.ogg" },
              new string[] { "s2_01478.ogg" , "s2_01477.ogg" , "s2_01476.ogg" , "s2_01475.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30PureFera = new string[][] {
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" },
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" },
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" },
              new string[] { "S2_11371.ogg" , "S2_11370.ogg" , "S2_11358.ogg" , "S2_11347.ogg" },
              new string[] { "S2_01446.ogg" , "S2_01445.ogg" , "S2_01495.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40PureVibe = new string[] { "s2_01491.ogg", "s2_01491.ogg", "s2_01492.ogg", "s2_01493.ogg", "s2_01493.ogg" };



        //性格別声テーブル　ヤンデレ---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20YandereVibe = new string[][] {
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20YandereFera = new string[][] {
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" }
              };

        //強バイブ　通常
        public static string[][] sLoopVoice30YandereVibe = new string[][] {
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02797.ogg" , "s3_02798.ogg" , "s3_02691.ogg" , "s3_02796.ogg" },
              new string[] { "s3_02767.ogg" , "s3_02768.ogg" , "s3_02769.ogg" , "s3_02770.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30YandereFera = new string[][] {
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02836.ogg" , "S3_02837.ogg" , "S3_02822.ogg" , "S3_02838.ogg" },
              new string[] { "S3_02833.ogg" , "S3_02818.ogg" , "S3_02835.ogg" , "S3_02820.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30YandereVibe = new string[][] {
              new string[] { "s3_02908.ogg" , "s3_02950.ogg" , "s3_02923.ogg" , "s3_02932.ogg" },
              new string[] { "s3_02909.ogg" , "s3_02910.ogg" , "s3_02915.ogg" , "s3_02914.ogg" },
              new string[] { "s3_02905.ogg" , "s3_02906.ogg" , "s3_02907.ogg" , "s3_05540.ogg" },
              new string[] { "s3_05657.ogg" , "s3_05658.ogg" , "s3_05659.ogg" , "s3_05660.ogg" , "s3_05661.ogg" , "s3_05678.ogg" , "s3_05651.ogg" , "s3_05656.ogg" },
              new string[] { "s3_02908.ogg" , "s3_02950.ogg" , "s3_02923.ogg" , "s3_02932.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30YandereFera = new string[][] {
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" },
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" },
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" },
              new string[] { "S3_03084.ogg" , "S3_03184.ogg" , "S3_03162.ogg" , "S3_18748.ogg" },
              new string[] { "S3_02919.ogg" , "S3_02918.ogg" , "S3_02928.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40YandereVibe = new string[] { "S3_02964.ogg", "S3_02964.ogg", "S3_02965.ogg", "S3_02966.ogg", "S3_02966.ogg" };



        //性格別声テーブル　お姉ちゃん---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20AnesanVibe = new string[][] {
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20AnesanFera = new string[][] {
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30AnesanVibe = new string[][] {
              new string[] { "s4_08140.ogg" , "s4_08141.ogg" , "s4_08142.ogg" , "s4_08145.ogg" },
              new string[] { "s4_08140.ogg" , "s4_08141.ogg" , "s4_08142.ogg" , "s4_08145.ogg" },
              new string[] { "s4_08140.ogg" , "s4_08141.ogg" , "s4_08149.ogg" , "s4_08150.ogg" },
              new string[] { "s4_08140.ogg" , "s4_08134.ogg" , "s4_08149.ogg" , "s4_08150.ogg" },
              new string[] { "s4_08211.ogg" , "s4_08212.ogg" , "s4_08213.ogg" , "s4_08214.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30AnesanFera = new string[][] {
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08244.ogg" , "S4_08245.ogg" , "S4_08262.ogg" , "S4_08246.ogg" },
              new string[] { "S4_08241.ogg" , "S4_08258.ogg" , "S4_08243.ogg" , "S4_08259.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30AnesanVibe = new string[][] {
              new string[] { "s4_08348.ogg" , "s4_08354.ogg" , "s4_08365.ogg" , "s4_08374.ogg" },
              new string[] { "s4_08345.ogg" , "s4_08346.ogg" , "s4_08349.ogg" , "s4_08350.ogg" },
              new string[] { "s4_08347.ogg" , "s4_08355.ogg" , "s4_08356.ogg" , "s4_11658.ogg" },
              new string[] { "s4_11684.ogg" , "s4_11677.ogg" , "s4_11680.ogg" , "s4_11683.ogg" , "s4_11661.ogg" , "s4_11659.ogg" , "s4_11654.ogg" , "s4_11660.ogg" },
              new string[] { "s4_08348.ogg" , "s4_08354.ogg" , "s4_08365.ogg" , "s4_08374.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30AnesanFera = new string[][] {
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" },
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" },
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" },
              new string[] { "S4_05728.ogg" , "S4_05726.ogg" , "S4_05680.ogg" , "S4_05668.ogg" },
              new string[] { "S4_08359.ogg" , "S4_08358.ogg" , "S4_08368.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40AnesanVibe = new string[] { "s4_08424.ogg", "s4_08426.ogg", "s4_08427.ogg", "s4_08428.ogg", "s4_08428.ogg" };



        //性格別声テーブル　ボクっ娘---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20GenkiVibe = new string[][] {
              new string[] { "s5_04127.ogg" , "s5_04129.ogg" , "s5_04130.ogg" , "s5_04131.ogg" },
              new string[] { "s5_04127.ogg" , "s5_04048.ogg" , "s5_04130.ogg" , "s5_04048.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04048.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04131.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04131.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20GenkiFera = new string[][] {
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "S5_04181.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "S5_04181.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30GenkiVibe = new string[][] {
              new string[] { "s5_04133.ogg" , "s5_04058.ogg" , "s5_04055.ogg" , "s5_04050.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04058.ogg" , "s5_04055.ogg" , "s5_04050.ogg" },
              new string[] { "s5_04051.ogg" , "s5_04055.ogg" , "s5_04054.ogg" , "s5_04052.ogg" },
              new string[] { "s5_04055.ogg" , "s5_04061.ogg" , "s5_04054.ogg" , "s5_04052.ogg" },
              new string[] { "s5_04133.ogg" , "s5_04134.ogg" , "s5_04047.ogg" , "s5_04131.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30GenkiFera = new string[][] {
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04093.ogg" , "S5_04094.ogg" , "S5_04102.ogg" , "S5_04100.ogg" },
              new string[] { "S5_04163.ogg" , "S5_04162.ogg" , "S5_04179.ogg" , "s5_04174.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30GenkiVibe = new string[][] {
              new string[] { "s5_04264.ogg" , "s5_04258.ogg" , "s5_04256.ogg" , "s5_04255.ogg" },
              new string[] { "s5_04265.ogg" , "s5_04270.ogg" , "s5_04267.ogg" , "s5_04268.ogg" },
              new string[] { "s5_04266.ogg" , "s5_18375.ogg" , "s5_18380.ogg" , "s5_18393.ogg" },
              new string[] { "s5_18379.ogg" , "s5_18380.ogg" , "s5_18382.ogg" , "s5_18384.ogg" , "s5_18385.ogg" , "s5_18400.ogg" , "s5_18402.ogg" , "s5_18119.ogg" },
              new string[] { "s5_04264.ogg" , "s5_04258.ogg" , "s5_04256.ogg" , "s5_04255.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30GenkiFera = new string[][] {
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" },
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" },
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" },
              new string[] { "S5_07752.ogg" , "S5_07753.ogg" , "s5_04273.ogg" , "s5_04271.ogg" },
              new string[] { "s5_04271.ogg" , "s5_04272.ogg" , "s5_04273.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40GenkiVibe = new string[] { "s5_04127.ogg", "s5_04129.ogg", "s5_04131.ogg", "s5_04134.ogg", "s5_04134.ogg" };



        //性格別声テーブル　ドＳ---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20SadistVibe = new string[][] {
              new string[] { "S6_02244.ogg" , "S6_02180.ogg" , "S6_02181.ogg" , "S6_02245.ogg" },
              new string[] { "S6_02179.ogg" , "S6_02243.ogg" , "S6_02246.ogg" , "S6_02182.ogg" },
              new string[] { "S6_02179.ogg" , "S6_02183.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02183.ogg" , "S6_02184.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02179.ogg" , "S6_02180.ogg" , "S6_02181.ogg" , "S6_02182.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20SadistFera = new string[][] {
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30SadistVibe = new string[][] {
              new string[] { "S6_02183.ogg" , "S6_02184.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02183.ogg" , "S6_02184.ogg" , "S6_02246.ogg" , "S6_02247.ogg" },
              new string[] { "S6_02248.ogg" , "S6_02184.ogg" , "S6_02185.ogg" , "S6_02249.ogg" },
              new string[] { "S6_02249.ogg" , "S6_02250.ogg" , "S6_02185.ogg" , "S6_02186.ogg" },
              new string[] { "S6_02243.ogg" , "S6_02244.ogg" , "S6_02245.ogg" , "S6_02246.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30SadistFera = new string[][] {
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02223.ogg" , "S6_02224.ogg" , "S6_02225.ogg" , "S6_02226.ogg" },
              new string[] { "S6_02219.ogg" , "S6_02220.ogg" , "S6_02221.ogg" , "S6_02222.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30SadistVibe = new string[][] {
              new string[] { "s6_01744.ogg" , "s6_02700.ogg" , "s6_02450.ogg" , "s6_02357.ogg" },
              new string[] { "S6_28847.ogg" , "S6_28853.ogg" , "S6_28814.ogg" , "S6_02397.ogg" },
              new string[] { "S6_28817.ogg" , "S6_02398.ogg" , "S6_02399.ogg" , "s6_02402.ogg" },
              new string[] { "S6_09048.ogg" , "S6_01984.ogg" , "S6_01988.ogg" , "S6_01991.ogg" , "S6_02000.ogg" , "S6_01996.ogg" , "S6_01997.ogg" , "S6_01998.ogg" , "S6_01999.ogg" , "S6_02001.ogg" , "s6_05796.ogg" , "s6_05797.ogg" , "s6_05798.ogg" , "s6_05799.ogg" , "s6_05800.ogg" , "s6_05801.ogg" },
              new string[] { "s6_01744.ogg" , "s6_02700.ogg" , "s6_02450.ogg" , "s6_02357.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30SadistFera = new string[][] {
              new string[] { "S6_28832.ogg" , "s6_02403.ogg" , "S6_28835.ogg" },
              new string[] { "S6_28835.ogg" , "s6_02403.ogg" , "s6_02404.ogg" },
              new string[] { "S6_28838.ogg" , "s6_02404.ogg" , "s6_02405.ogg" },
              new string[] { "S6_02420.ogg" , "S6_08109.ogg" , "S6_08112.ogg" , "S6_08114.ogg" , "s6_02404.ogg" , "s6_02405.ogg"  },
              new string[] { "S6_28832.ogg" , "s6_02403.ogg" , "S6_28835.ogg" }
              };
        //停止時
        public static string[] sLoopVoice40SadistVibe = new string[] { "s6_02477.ogg", "s6_02478.ogg", "s6_02479.ogg", "s6_02481.ogg", "s6_02480.ogg" };



        //性格別声テーブル　無垢---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20MukuVibe = new string[][] {
              new string[] { "H0_00053.ogg" , "H0_00054.ogg" , "H0_09210.ogg" , "H0_09211.ogg" },
              new string[] { "H0_00069.ogg" , "H0_00070.ogg" , "H0_00229.ogg" , "H0_00230.ogg" },
              new string[] { "H0_00055.ogg" , "H0_00056.ogg" , "H0_09212.ogg" , "H0_09213.ogg" },
              new string[] { "H0_00071.ogg" , "H0_00072.ogg" , "H0_00231.ogg" , "H0_00232.ogg" },
              new string[] { "H0_00085.ogg" , "H0_00086.ogg" , "H0_00087.ogg" , "H0_00088.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20MukuFera = new string[][] {
              new string[] { "H0_00093.ogg" , "H0_00094.ogg" , "H0_00101.ogg" , "H0_00102.ogg" },
              new string[] { "H0_00093.ogg" , "H0_00094.ogg" , "H0_00101.ogg" , "H0_00102.ogg" },
              new string[] { "H0_00095.ogg" , "H0_00096.ogg" , "H0_00103.ogg" , "H0_00104.ogg" },
              new string[] { "H0_00095.ogg" , "H0_00096.ogg" , "H0_00103.ogg" , "H0_00104.ogg" },
              new string[] { "H0_00093.ogg" , "H0_00094.ogg" , "H0_00101.ogg" , "H0_00102.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30MukuVibe = new string[][] {
              new string[] { "H0_00057.ogg" , "H0_00058.ogg" , "H0_09214.ogg" , "H0_09215.ogg" },
              new string[] { "H0_00073.ogg" , "H0_00074.ogg" , "H0_00233.ogg" , "H0_00234.ogg" },
              new string[] { "H0_00059.ogg" , "H0_00060.ogg" , "H0_09216.ogg" , "H0_09217.ogg" },
              new string[] { "H0_00075.ogg" , "H0_00076.ogg" , "H0_00235.ogg" , "H0_00236.ogg" },
              new string[] { "H0_00089.ogg" , "H0_00090.ogg" , "H0_00087.ogg" , "H0_00088.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30MukuFera = new string[][] {
              new string[] { "H0_00105.ogg" , "H0_00106.ogg" , "H0_00097.ogg" , "H0_00098.ogg" },
              new string[] { "H0_00105.ogg" , "H0_00106.ogg" , "H0_00097.ogg" , "H0_00098.ogg" },
              new string[] { "H0_00107.ogg" , "H0_00108.ogg" , "H0_00099.ogg" , "H0_00100.ogg" },
              new string[] { "H0_00107.ogg" , "H0_00108.ogg" , "H0_00099.ogg" , "H0_00100.ogg" },
              new string[] { "H0_00105.ogg" , "H0_00106.ogg" , "H0_00097.ogg" , "H0_00098.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30MukuVibe = new string[][] {
              new string[] { "H0_00289.ogg" , "H0_00290.ogg" , "H0_00291.ogg" , "H0_00292.ogg" },
              new string[] { "H0_07822.ogg" , "H0_07826.ogg" , "H0_10642.ogg" , "H0_10619.ogg" , "H0_07825.ogg" },
              new string[] { "H0_10874.ogg" , "H0_10860.ogg" , "H0_10957.ogg" , "H0_10960.ogg" , "H0_10869.ogg" },
              new string[] { "H0_06353.ogg" , "H0_06358.ogg" , "H0_10859.ogg" , "H0_10870.ogg" , "H0_10860.ogg" , "H0_10961.ogg" , "H0_10962.ogg" , "H0_10963.ogg" , "H0_07695.ogg" , "H0_09708.ogg" , "H0_09713.ogg" , "H0_10470.ogg" , "H0_10471.ogg" , "H0_10476.ogg" , "H0_10479.ogg" , "H0_10480.ogg" , "H0_13669.ogg" , "H0_00567.ogg" , "H0_05H_15068.ogg" , "H0_05H_15079.ogg" , "H0_05H_15080.ogg" , "H0_05H_15081.ogg" , "H0_06062.ogg" , "H0_10473.ogg" , "H0_10474.ogg" , "H0_10475.ogg" , "H0_10477.ogg" , "H0_10478.ogg" , "H0_10926.ogg" , "H0_11359.ogg" , "H0_12625.ogg" , "H0_FEB_20458.ogg" },
              new string[] { "H0_07604.ogg" , "H0_07603.ogg" , "H0_07614.ogg" , "H0_07644.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30MukuFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40MukuVibe = new string[] { "H0_00134.ogg", "H0_00136.ogg", "H0_09239.ogg", "H0_09240.ogg", "H0_00142.ogg" };



        //性格別声テーブル　真面目---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20MajimeVibe = new string[][] {
              new string[] { "H1_00225.ogg" , "H1_00226.ogg" , "H1_08952.ogg" , "H1_08953.ogg" },
              new string[] { "H1_00241.ogg" , "H1_00242.ogg" , "H1_00401.ogg" , "H1_00402.ogg" },
              new string[] { "H1_00227.ogg" , "H1_00228.ogg" , "H1_08954.ogg" , "H1_08955.ogg" },
              new string[] { "H1_00243.ogg" , "H1_00244.ogg" , "H1_00403.ogg" , "H1_00404.ogg" },
              new string[] { "H1_00257.ogg" , "H1_00258.ogg" , "H1_00259.ogg" , "H1_00260.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20MajimeFera = new string[][] {
              new string[] { "H1_00265.ogg" , "H1_00266.ogg" , "H1_00273.ogg" , "H1_00274.ogg" },
              new string[] { "H1_00265.ogg" , "H1_00266.ogg" , "H1_00273.ogg" , "H1_00274.ogg" },
              new string[] { "H1_00267.ogg" , "H1_00268.ogg" , "H1_00275.ogg" , "H1_00276.ogg" },
              new string[] { "H1_00267.ogg" , "H1_00268.ogg" , "H1_00275.ogg" , "H1_00276.ogg" },
              new string[] { "H1_00265.ogg" , "H1_00266.ogg" , "H1_00273.ogg" , "H1_00274.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30MajimeVibe = new string[][] {
              new string[] { "H1_00229.ogg" , "H1_00230.ogg" , "H1_08956.ogg" , "H1_08957.ogg" },
              new string[] { "H1_00245.ogg" , "H1_00246.ogg" , "H1_00405.ogg" , "H1_00406.ogg" },
              new string[] { "H1_00231.ogg" , "H1_00232.ogg" , "H1_08958.ogg" , "H1_08959.ogg" },
              new string[] { "H1_00247.ogg" , "H1_00248.ogg" , "H1_00407.ogg" , "H1_00408.ogg" },
              new string[] { "H1_00262.ogg" , "H1_00263.ogg" , "H1_00264.ogg" , "H1_00261.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30MajimeFera = new string[][] {
              new string[] { "H1_00269.ogg" , "H1_00270.ogg" , "H1_00277.ogg" , "H1_00278.ogg" },
              new string[] { "H1_00269.ogg" , "H1_00270.ogg" , "H1_00277.ogg" , "H1_00278.ogg" },
              new string[] { "H1_00271.ogg" , "H1_00272.ogg" , "H1_00279.ogg" , "H1_00280.ogg" },
              new string[] { "H1_00271.ogg" , "H1_00272.ogg" , "H1_00279.ogg" , "H1_00280.ogg" },
              new string[] { "H1_00269.ogg" , "H1_00270.ogg" , "H1_00277.ogg" , "H1_00278.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30MajimeVibe = new string[][] {
              new string[] { "H1_11482.ogg" , "H1_13858.ogg" , "H1_13879.ogg" , "H1_13918.ogg" },
              new string[] { "H1_11492.ogg" , "H1_11514.ogg" , "H1_10519.ogg" , "H1_10516.ogg" },
              new string[] { "H1_11427.ogg" , "H1_11513.ogg" , "H1_05640.ogg" , "H1_09232.ogg" },
              new string[] { "H1_11425.ogg" , "H1_11424.ogg" , "H1_11427.ogg" , "H1_09232.ogg" , "H1_10397.ogg" , "H1_11645.ogg" , "H1_11654.ogg" , "H1_11747.ogg" , "H1_10313.ogg" , "H1_11254.ogg" , "H1_11402.ogg" , "H1_09829.ogg" , "H1_04547.ogg" , "H1_12675.ogg" , "H1_01477.ogg" , "H1_00739.ogg" , "H1_06987.ogg" , "H1_13138.ogg" , "H1_13372.ogg" , "H1_12929.ogg" , "H1_11404.ogg" , "H1_05638.ogg" , "H1_09837.ogg" , "H1_03615.ogg" , "H1_11513.ogg" , "H1_05640.ogg" },
              new string[] { "H1_10493.ogg" , "H1_10482.ogg" , "H1_10523.ogg" , "H1_10732.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30MajimeFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { "H1_09840.ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { "H1_12857.ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40MajimeVibe = new string[] { "H1_00305.ogg", "H1_08979.ogg", "H1_08980.ogg", "H1_08982.ogg", "H1_00313.ogg" };



        //性格別声テーブル　凛デレ---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20RindereVibe = new string[][] {
              new string[] { "H2_00027.ogg" , "H2_00028.ogg" , "H2_09827.ogg" , "H2_09828.ogg" },
              new string[] { "H2_00043.ogg" , "H2_00044.ogg" , "H2_00203.ogg" , "H2_00204.ogg" },
              new string[] { "H2_00029.ogg" , "H2_00030.ogg" , "H2_09829.ogg" , "H2_09830.ogg" },
              new string[] { "H2_00045.ogg" , "H2_00046.ogg" , "H2_00205.ogg" , "H2_00206.ogg" },
              new string[] { "H2_00059.ogg" , "H2_00060.ogg" , "H2_00061.ogg" , "H2_00062.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20RindereFera = new string[][] {
              new string[] { "H2_00067.ogg" , "H2_00068.ogg" , "H2_00075.ogg" , "H2_00076.ogg" },
              new string[] { "H2_00067.ogg" , "H2_00068.ogg" , "H2_00075.ogg" , "H2_00076.ogg" },
              new string[] { "H2_00069.ogg" , "H2_00070.ogg" , "H2_00077.ogg" , "H2_00078.ogg" },
              new string[] { "H2_00069.ogg" , "H2_00070.ogg" , "H2_00077.ogg" , "H2_00078.ogg" },
              new string[] { "H2_00067.ogg" , "H2_00068.ogg" , "H2_00075.ogg" , "H2_00076.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30RindereVibe = new string[][] {
              new string[] { "H2_00031.ogg" , "H2_00032.ogg" , "H2_09831.ogg" , "H2_09832.ogg" },
              new string[] { "H2_00047.ogg" , "H2_00048.ogg" , "H2_00207.ogg" , "H2_00208.ogg" },
              new string[] { "H2_00033.ogg" , "H2_00034.ogg" , "H2_09833.ogg" , "H2_09834.ogg" },
              new string[] { "H2_00049.ogg" , "H2_00050.ogg" , "H2_00209.ogg" , "H2_00210.ogg" },
              new string[] { "H2_00063.ogg" , "H2_00064.ogg" , "H2_00061.ogg" , "H2_00062.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30RindereFera = new string[][] {
              new string[] { "H2_00071.ogg" , "H2_00072.ogg" , "H2_00079.ogg" , "H2_00080.ogg" },
              new string[] { "H2_00071.ogg" , "H2_00072.ogg" , "H2_00079.ogg" , "H2_00080.ogg" },
              new string[] { "H2_00073.ogg" , "H2_00074.ogg" , "H2_00081.ogg" , "H2_00082.ogg" },
              new string[] { "H2_00073.ogg" , "H2_00074.ogg" , "H2_00081.ogg" , "H2_00082.ogg" },
              new string[] { "H2_00071.ogg" , "H2_00072.ogg" , "H2_00079.ogg" , "H2_00080.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30RindereVibe = new string[][] {
              new string[] { "H2_06092.ogg" , "H2_00252.ogg" , "H2_00285.ogg" , "H2_00277.ogg" },
              new string[] { "H2_10293.ogg" , "H2_10381.ogg" , "H2_10444.ogg" , "H2_11040.ogg" , "H2_07976.ogg" },
              new string[] { "H2_08156.ogg" , "H2_10980.ogg" , "H2_11120.ogg" , "H2_11141.ogg" , "H2_11143.ogg" , "H2_11229.ogg" },
              new string[] { "H2_10580.ogg" , "H2_10581.ogg" , "H2_10584.ogg" , "H2_10585.ogg" , "H2_10586.ogg" , "H2_10587.ogg" , "H2_10064.ogg" , "H2_13912.ogg" , "H2_11118.ogg" , "H2_11119.ogg" , "H2_08338.ogg" , "H2_11371.ogg" , "H2_11464.ogg" , "H2_13449.ogg" , "H2_10971.ogg" , "H2_06130.ogg" , "H2_01902.ogg" , "H2_03017.ogg" , "H2_02782.ogg" , "H2_02861.ogg" , "H2_10573.ogg" , "H2_00865.ogg" , "H2_02550.ogg" , "H2_02603.ogg" , "H2_02606.ogg" , "H2_08156.ogg" , "H2_10980.ogg" , "H2_11120.ogg" , "H2_11141.ogg" , "H2_11143.ogg" , "H2_11229.ogg" },
              new string[] { "H2_08095.ogg" , "H2_08116.ogg" , "H2_08121.ogg" , "H2_08126.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30RindereFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40RindereVibe = new string[] { "H2_00108.ogg", "H2_00110.ogg", "H2_00111.ogg", "H2_00113.ogg", "H2_00118.ogg" };



        //性格別声テーブル　無口---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20SilentVibe = new string[][] {
              new string[] { "H3_00518.ogg" , "H3_00519.ogg" , "H3_00526.ogg" , "H3_00527.ogg" },
              new string[] { "H3_00534.ogg" , "H3_00535.ogg" , "H3_00734.ogg" , "H3_00735.ogg" },
              new string[] { "H3_00520.ogg" , "H3_00521.ogg" , "H3_00528.ogg" , "H3_00529.ogg" },
              new string[] { "H3_00536.ogg" , "H3_00537.ogg" , "H3_00736.ogg" , "H3_00737.ogg" },
              new string[] { "H3_00558.ogg" , "H3_00559.ogg" , "H3_00734.ogg" , "H3_00735.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20SilentFera = new string[][] {
              new string[] { "H3_00566.ogg" , "H3_00567.ogg" , "H3_00702.ogg" , "H3_00703.ogg" },
              new string[] { "H3_00566.ogg" , "H3_00567.ogg" , "H3_00702.ogg" , "H3_00703.ogg" },
              new string[] { "H3_00568.ogg" , "H3_00569.ogg" , "H3_00704.ogg" , "H3_00705.ogg" },
              new string[] { "H3_00568.ogg" , "H3_00569.ogg" , "H3_00704.ogg" , "H3_00705.ogg" },
              new string[] { "H3_00566.ogg" , "H3_00567.ogg" , "H3_00568.ogg" , "H3_00569.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30SilentVibe = new string[][] {
              new string[] { "H3_00522.ogg" , "H3_00523.ogg" , "H3_00530.ogg" , "H3_00531.ogg" },
              new string[] { "H3_00538.ogg" , "H3_00539.ogg" , "H3_00738.ogg" , "H3_00739.ogg" },
              new string[] { "H3_00524.ogg" , "H3_00525.ogg" , "H3_00532.ogg" , "H3_00533.ogg" },
              new string[] { "H3_00540.ogg" , "H3_00541.ogg" , "H3_00740.ogg" , "H3_00741.ogg" },
              new string[] { "H3_00560.ogg" , "H3_00561.ogg" , "H3_00562.ogg" , "H3_00563.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30SilentFera = new string[][] {
              new string[] { "H3_00570.ogg" , "H3_00571.ogg" , "H3_00706.ogg" , "H3_00707.ogg" },
              new string[] { "H3_00570.ogg" , "H3_00571.ogg" , "H3_00706.ogg" , "H3_00707.ogg" },
              new string[] { "H3_00572.ogg" , "H3_00573.ogg" , "H3_00708.ogg" , "H3_00709.ogg" },
              new string[] { "H3_00572.ogg" , "H3_00573.ogg" , "H3_00708.ogg" , "H3_00709.ogg" },
              new string[] { "H3_00570.ogg" , "H3_00571.ogg" , "H3_00706.ogg" , "H3_00707.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30SilentVibe = new string[][] {
              new string[] { "H3_00779.ogg" , "H3_00783.ogg" , "H3_00785.ogg" , "H3_00800.ogg" },
              new string[] { "H3_08926.ogg" , "H3_08112.ogg" , "H3_04262.ogg" , "H3_05125.ogg" , "H3_08926.ogg" },
              new string[] { "H3_02523.ogg" , "H3_04910.ogg" , "H3_07704.ogg" , "H3_04967.ogg" , "H3_04974.ogg" , "H3_05026.ogg" },
              new string[] { "H3_07068.ogg" , "H3_02584.ogg" , "H3_01906.ogg" , "H3_07314.ogg" , "H3_07315.ogg" , "H3_07316.ogg" , "H3_06965.ogg" , "H3_01858.ogg" , "H3_01906.ogg" , "H3_01925.ogg" , "H3_04252.ogg" , "H3_04228.ogg" , "H3_04639.ogg" , "H3_07121.ogg" , "H3_03827.ogg" , "H3_01928.ogg" , "H3_02336.ogg" , "H3_07069.ogg" , "H3_07996.ogg" , "H3_08950.ogg" },
              new string[] { "H3_00779.ogg" , "H3_00783.ogg" , "H3_00785.ogg" , "H3_00800.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30SilentFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40SilentVibe = new string[] { "H3_00622.ogg", "H3_00625.ogg", "H3_00627.ogg", "H3_00628.ogg", "H3_00641.ogg" };



        //性格別声テーブル　小悪魔---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20DevilishVibe = new string[][] {
              new string[] { "H4_00853.ogg" , "H4_00854.ogg" , "H4_00861.ogg" , "H4_00862.ogg" },
              new string[] { "H4_00869.ogg" , "H4_00870.ogg" , "H4_01069.ogg" , "H4_01070.ogg" },
              new string[] { "H4_00855.ogg" , "H4_00856.ogg" , "H4_00863.ogg" , "H4_00864.ogg" },
              new string[] { "H4_00871.ogg" , "H4_00872.ogg" , "H4_01071.ogg" , "H4_01072.ogg" },
              new string[] { "H4_00893.ogg" , "H4_00894.ogg" , "H4_01069.ogg" , "H4_01070.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20DevilishFera = new string[][] {
              new string[] { "H4_00901.ogg" , "H4_00902.ogg" , "H4_01037.ogg" , "H4_01038.ogg" },
              new string[] { "H4_00901.ogg" , "H4_00902.ogg" , "H4_01037.ogg" , "H4_01038.ogg" },
              new string[] { "H4_00903.ogg" , "H4_00904.ogg" , "H4_01039.ogg" , "H4_01040.ogg" },
              new string[] { "H4_00903.ogg" , "H4_00904.ogg" , "H4_01039.ogg" , "H4_01040.ogg" },
              new string[] { "H4_00901.ogg" , "H4_00902.ogg" , "H4_00903.ogg" , "H4_00904.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30DevilishVibe = new string[][] {
              new string[] { "H4_00857.ogg" , "H4_00858.ogg" , "H4_00865.ogg" , "H4_00866.ogg" },
              new string[] { "H4_00873.ogg" , "H4_00874.ogg" , "H4_01073.ogg" , "H4_01074.ogg" },
              new string[] { "H4_00859.ogg" , "H4_00860.ogg" , "H4_00867.ogg" , "H4_00868.ogg" },
              new string[] { "H4_00875.ogg" , "H4_00876.ogg" , "H4_01075.ogg" , "H4_01076.ogg" },
              new string[] { "H4_00895.ogg" , "H4_00896.ogg" , "H4_00897.ogg" , "H4_00898.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30DevilishFera = new string[][] {
              new string[] { "H4_00905.ogg" , "H4_00906.ogg" , "H4_01041.ogg" , "H4_01042.ogg" },
              new string[] { "H4_00905.ogg" , "H4_00906.ogg" , "H4_01041.ogg" , "H4_01042.ogg" },
              new string[] { "H4_00907.ogg" , "H4_00908.ogg" , "H4_01043.ogg" , "H4_01044.ogg" },
              new string[] { "H4_00907.ogg" , "H4_00908.ogg" , "H4_01043.ogg" , "H4_01044.ogg" },
              new string[] { "H4_00905.ogg" , "H4_00906.ogg" , "H4_01041.ogg" , "H4_01042.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30DevilishVibe = new string[][] {
              new string[] { "H4_01200.ogg" , "H4_01204.ogg" , "H4_01209.ogg" , "H4_01208.ogg" },
              new string[] { "H4_03190.ogg" , "H4_02024.ogg" , "H4_02026.ogg" , "H4_02030.ogg" , "H4_02018.ogg" },
              new string[] { "H4_01907.ogg" , "H4_01908.ogg" , "H4_05097.ogg" , "H4_05098.ogg" , "H4_03190.ogg" , "H4_03290.ogg" ,"H4_02020.ogg" , "H4_00583.ogg" , "H4_08568.ogg" },
              new string[] { "H4_03413.ogg" , "H4_08495.ogg" , "H4_08182.ogg" , "H4_02777.ogg" , "H4_03019.ogg" , "H4_06292.ogg" , "H4_06308.ogg" , "H4_06328.ogg" , "H4_08574.ogg" , "H4_08578.ogg" , "H4_08579.ogg" , "H4_08580.ogg" , "H4_08607.ogg" , "H4_08608.ogg" , "H4_08568.ogg" , "H4_08591.ogg" , "H4_04328.ogg" , "H4_03190.ogg" , "H4_06136.ogg" , "H4_00537.ogg" , "H4_00583.ogg" , "H4_08568.ogg" , "H4_02024.ogg" , "H4_02026.ogg" , "H4_02030.ogg" , "H4_02018.ogg" , "H4_04840.ogg" , "H4_05503.ogg" , "H4_08165.ogg" , "H4_08169.ogg" , "H4_PMD_14155.ogg" , "H4_PMD_14156.ogg" , "H4_PMD_14157.ogg" , "H4_Y_13333.ogg" , "H4_Y_13335.ogg" , "H4_Y_13336.ogg" , "H4_Y_13337.ogg" , "H4_Y_13338.ogg" , "H4_Y_13339.ogg" , "H4_Y_13340.ogg" , "H4_Y_13342.ogg" , "H4_Y_13343.ogg" , "H4_Y_13353.ogg" , "H4_Y_13355.ogg" , "H4_Y_13356.ogg" , "H4_Y_13360.ogg" , "H4_Y_13371.ogg", "H4_ADD_10717.ogg", "H4_ADD_10718.ogg", "H4_ADD_10721.ogg", "H4_ADD_10722.ogg", "H4_ADD_10723.ogg", "H4_ADD_11330.ogg", "H4_ADD_11331.ogg", "H4_ADD_11332.ogg", "H4_ADD_11333.ogg", "H4_ADD_11334.ogg", "H4_ADD_11344.ogg", "H4_ADD_11345.ogg", "H4_ADD_11346.ogg", "H4_ADD_11348.ogg", "H4_ADD_11349.ogg", "H4_ADD_11356.ogg", "H4_ADD_11359.ogg", "H4_ADD_11360.ogg", "H4_ADD_11361.ogg", "H4_ADD_11362.ogg" },
              new string[] { "H4_01200.ogg" , "H4_01204.ogg" , "H4_01209.ogg" , "H4_01208.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30DevilishFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40DevilishVibe = new string[] { "H4_00959.ogg", "H4_00962.ogg", "H4_00963.ogg", "H4_00977.ogg", "H4_00980.ogg" };



        //性格別声テーブル　おしとやか---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20LadylikeVibe = new string[][] {
              new string[] { "H5_00592.ogg" , "H5_00593.ogg" , "H5_00600.ogg" , "H5_00601.ogg" },
              new string[] { "H5_00808.ogg" , "H5_00809.ogg" , "H5_00608.ogg" , "H5_00609.ogg" },
              new string[] { "H5_00594.ogg" , "H5_00595.ogg" , "H5_00602.ogg" , "H5_00603.ogg" },
              new string[] { "H5_00810.ogg" , "H5_00811.ogg" , "H5_00610.ogg" , "H5_00611.ogg" },
              new string[] { "H5_00624.ogg" , "H5_00625.ogg" , "H5_00632.ogg" , "H5_00633.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20LadylikeFera = new string[][] {
              new string[] { "H5_00640.ogg" , "H5_00641.ogg" , "H5_00648.ogg" , "H5_00649.ogg" },
              new string[] { "H5_00640.ogg" , "H5_00641.ogg" , "H5_00648.ogg" , "H5_00649.ogg" },
              new string[] { "H5_00642.ogg" , "H5_00643.ogg" , "H5_00650.ogg" , "H5_00651.ogg" },
              new string[] { "H5_00642.ogg" , "H5_00643.ogg" , "H5_00650.ogg" , "H5_00651.ogg" },
              new string[] { "H5_00640.ogg" , "H5_00641.ogg" , "H5_00642.ogg" , "H5_00643.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30LadylikeVibe = new string[][] {
              new string[] { "H5_00596.ogg" , "H5_00597.ogg" , "H5_00604.ogg" , "H5_00605.ogg" },
              new string[] { "H5_00812.ogg" , "H5_00813.ogg" , "H5_00612.ogg" , "H5_00613.ogg" },
              new string[] { "H5_00598.ogg" , "H5_00599.ogg" , "H5_00606.ogg" , "H5_00607.ogg" },
              new string[] { "H5_00814.ogg" , "H5_00815.ogg" , "H5_00614.ogg" , "H5_00615.ogg" },
              new string[] { "H5_00626.ogg" , "H5_00627.ogg" , "H5_00634.ogg" , "H5_00635.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30LadylikeFera = new string[][] {
              new string[] { "H5_00644.ogg" , "H5_00645.ogg" , "H5_00652.ogg" , "H5_00653.ogg" },
              new string[] { "H5_00644.ogg" , "H5_00645.ogg" , "H5_00652.ogg" , "H5_00653.ogg" },
              new string[] { "H5_00646.ogg" , "H5_00647.ogg" , "H5_00654.ogg" , "H5_00655.ogg" },
              new string[] { "H5_00646.ogg" , "H5_00647.ogg" , "H5_00654.ogg" , "H5_00655.ogg" },
              new string[] { "H5_00644.ogg" , "H5_00645.ogg" , "H5_00646.ogg" , "H5_00647.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30LadylikeVibe = new string[][] {
              new string[] { "H5_00943.ogg" , "H5_00944.ogg" , "H5_00948.ogg" , "H5_00874.ogg" },
              new string[] { "H5_00859.ogg" , "H5_00857.ogg" , "H5_00858.ogg" , "H5_00855.ogg" , "H5_02835.ogg" },
              new string[] { "H5_08487.ogg" , "H5_00250.ogg" , "H5_00259.ogg" , "H5_00270.ogg" , "H5_00290.ogg" , "H5_00370.ogg" , "H5_02835.ogg" , "H5_03009.ogg" , "H5_00479.ogg" },
              new string[] { "H5_08158.ogg" , "H5_08153.ogg" , "H5_08155.ogg" , "H5_08482.ogg" , "H5_08484.ogg" , "H5_08485.ogg" , "H5_08486.ogg" , "H5_08487.ogg" , "H5_08488.ogg" , "H5_03789.ogg" , "H5_02561.ogg" , "H5_00370.ogg" , "H5_00379.ogg" , "H5_00398.ogg" , "H5_00399.ogg" , "H5_03009.ogg" , "H5_00479.ogg" , "H5_03462.ogg" , "H5_03464.ogg" , "H5_03465.ogg" , "H5_03468.ogg" , "H5_04142.ogg" , "H5_04144.ogg" , "H5_01588.ogg" , "H5_01596.ogg" , "H5_01597.ogg" , "H5_01598.ogg" },
              new string[] { "H5_00943.ogg" , "H5_00944.ogg" , "H5_00948.ogg" , "H5_00874.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30LadylikeFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40LadylikeVibe = new string[] { "H5_00922.ogg", "H5_00923.ogg", "H5_00916.ogg", "H5_00917.ogg", "H5_00920.ogg" };



        //性格別声テーブル　メイド秘書---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20SecretaryVibe = new string[][] {
              new string[] { "H6_00158.ogg" , "H6_00159.ogg" , "H6_00166.ogg" , "H6_00167.ogg" },
              new string[] { "H6_00374.ogg" , "H6_00375.ogg" , "H6_00174.ogg" , "H6_00175.ogg" },
              new string[] { "H6_00160.ogg" , "H6_00161.ogg" , "H6_00168.ogg" , "H6_00169.ogg" },
              new string[] { "H6_00376.ogg" , "H6_00377.ogg" , "H6_00176.ogg" , "H6_00177.ogg" },
              new string[] { "H6_00190.ogg" , "H6_00191.ogg" , "H6_00192.ogg" , "H6_00193.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20SecretaryFera = new string[][] {
              new string[] { "H6_00206.ogg" , "H6_00207.ogg" , "H6_00214.ogg" , "H6_00215.ogg" },
              new string[] { "H6_00206.ogg" , "H6_00207.ogg" , "H6_00214.ogg" , "H6_00215.ogg" },
              new string[] { "H6_00208.ogg" , "H6_00209.ogg" , "H6_00216.ogg" , "H6_00217.ogg" },
              new string[] { "H6_00208.ogg" , "H6_00209.ogg" , "H6_00216.ogg" , "H6_00217.ogg" },
              new string[] { "H6_00198.ogg" , "H6_00199.ogg" , "H6_00200.ogg" , "H6_00201.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30SecretaryVibe = new string[][] {
              new string[] { "H6_00162.ogg" , "H6_00163.ogg" , "H6_00170.ogg" , "H6_00171.ogg" },
              new string[] { "H6_00378.ogg" , "H6_00379.ogg" , "H6_00178.ogg" , "H6_00179.ogg" },
              new string[] { "H6_00164.ogg" , "H6_00165.ogg" , "H6_00172.ogg" , "H6_00173.ogg" },
              new string[] { "H6_00380.ogg" , "H6_00381.ogg" , "H6_00180.ogg" , "H6_00181.ogg" },
              new string[] { "H6_00194.ogg" , "H6_00195.ogg" , "H6_00196.ogg" , "H6_00197.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30SecretaryFera = new string[][] {
              new string[] { "H6_00210.ogg" , "H6_00211.ogg" , "H6_00218.ogg" , "H6_00219.ogg" },
              new string[] { "H6_00210.ogg" , "H6_00211.ogg" , "H6_00218.ogg" , "H6_00219.ogg" },
              new string[] { "H6_00212.ogg" , "H6_00213.ogg" , "H6_00220.ogg" , "H6_00221.ogg" },
              new string[] { "H6_00212.ogg" , "H6_00213.ogg" , "H6_00220.ogg" , "H6_00221.ogg" },
              new string[] { "H6_00202.ogg" , "H6_00203.ogg" , "H6_00204.ogg" , "H6_00205.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30SecretaryVibe = new string[][] {
              new string[] { "H6_00421.ogg" , "H6_00429.ogg" , "H6_00448.ogg" , "H6_00409.ogg" },
              new string[] { "H6_08956.ogg" , "H6_08721.ogg" , "H6_08731.ogg" , "H6_09052.ogg" , "H6_00413.ogg" },
              new string[] { "H6_04166.ogg" , "H6_04305.ogg" , "H6_05273.ogg" , "H6_06550.ogg" , "H6_06555.ogg" , "H6_05185.ogg" , "H6_08956.ogg" , "H6_08721.ogg" , "H6_08731.ogg" , "H6_02949.ogg" , "H6_03938.ogg" , "H6_00936.ogg" , "H6_05653.ogg" },
              new string[] { "H6_08869.ogg" , "H6_06946.ogg" , "H6_06610.ogg" , "H6_06615.ogg" , "H6_06627.ogg" , "H6_08868.ogg" , "H6_08948.ogg" , "H6_09026.ogg" , "H6_05578.ogg" , "H6_06985.ogg" , "H6_05688.ogg" , "H6_01064.ogg" , "H6_03986.ogg" , "H6_01165.ogg" , "H6_04233.ogg" , "H6_08717.ogg" , "H6_08718.ogg" , "H6_08719.ogg" , "H6_08721.ogg" , "H6_08867.ogg" , "H6_08953.ogg" , "H6_08956.ogg" , "H6_08958.ogg" , "H6_09001.ogg" , "H6_09002.ogg" , "H6_09008.ogg" , "H6_09023.ogg" , "H6_09025.ogg" , "H6_09028.ogg" , "H6_06006.ogg" , "H6_04130.ogg" },
              new string[] { "H6_09028.ogg" , "H6_09023.ogg" , "H6_09002.ogg" , "H6_08956.ogg" , "H6_00421.ogg" , "H6_00429.ogg" , "H6_00448.ogg" , "H6_00409.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30SecretaryFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40SecretaryVibe = new string[] { "H6_00263.ogg", "H6_00264.ogg", "H6_00267.ogg", "H6_00268.ogg", "H6_00284.ogg" };



        //性格別声テーブル　ふわふわ妹---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20SisterVibe = new string[][] {
              new string[] { "H7_02762.ogg" , "H7_02763.ogg" , "H7_02770.ogg" , "H7_02771.ogg" },
              new string[] { "H7_02978.ogg" , "H7_02979.ogg" , "H7_02850.ogg" , "H7_02851.ogg" },
              new string[] { "H7_02764.ogg" , "H7_02765.ogg" , "H7_02772.ogg" , "H7_02773.ogg" },
              new string[] { "H7_02980.ogg" , "H7_02981.ogg" , "H7_02852.ogg" , "H7_02853.ogg" },
              new string[] { "H7_02962.ogg" , "H7_02963.ogg" , "H7_02802.ogg" , "H7_02803.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20SisterFera = new string[][] {
              new string[] { "H7_02810.ogg" , "H7_02811.ogg" , "H7_02818.ogg" , "H7_02819.ogg" },
              new string[] { "H7_02810.ogg" , "H7_02811.ogg" , "H7_02818.ogg" , "H7_02819.ogg" },
              new string[] { "H7_02812.ogg" , "H7_02813.ogg" , "H7_02820.ogg" , "H7_02821.ogg" },
              new string[] { "H7_02812.ogg" , "H7_02813.ogg" , "H7_02820.ogg" , "H7_02821.ogg" },
              new string[] { "H7_02810.ogg" , "H7_02811.ogg" , "H7_02818.ogg" , "H7_02819.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30SisterVibe = new string[][] {
              new string[] { "H7_02766.ogg" , "H7_02767.ogg" , "H7_02774.ogg" , "H7_02775.ogg" },
              new string[] { "H7_02982.ogg" , "H7_02983.ogg" , "H7_02854.ogg" , "H7_02855.ogg" },
              new string[] { "H7_02768.ogg" , "H7_02769.ogg" , "H7_02776.ogg" , "H7_02777.ogg" },
              new string[] { "H7_02984.ogg" , "H7_02985.ogg" , "H7_02856.ogg" , "H7_02857.ogg" },
              new string[] { "H7_02964.ogg" , "H7_02965.ogg" , "H7_02804.ogg" , "H7_02805.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30SisterFera = new string[][] {
              new string[] { "H7_02814.ogg" , "H7_02815.ogg" , "H7_02822.ogg" , "H7_02823.ogg" },
              new string[] { "H7_02814.ogg" , "H7_02815.ogg" , "H7_02822.ogg" , "H7_02823.ogg" },
              new string[] { "H7_02816.ogg" , "H7_02817.ogg" , "H7_02824.ogg" , "H7_02825.ogg" },
              new string[] { "H7_02816.ogg" , "H7_02817.ogg" , "H7_02824.ogg" , "H7_02825.ogg" },
              new string[] { "H7_02812.ogg" , "H7_02813.ogg" , "H7_02820.ogg" , "H7_02821.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30SisterVibe = new string[][] {
              new string[] { "H7_03163.ogg" , "H7_03167.ogg" , "H7_03164.ogg" , "H7_03172.ogg" },
              new string[] { "H7_08797.ogg" , "H7_07791.ogg" , "H7_02309.ogg" , "H7_02353.ogg" , "H7_01991.ogg" , "H7_02498.ogg" },
              new string[] { "H7_05958.ogg" , "H7_02353.ogg" , "H7_02410.ogg" , "H7_04331.ogg" , "H7_01699.ogg" , "H7_02060.ogg" , "H7_05359.ogg" , "H7_02506.ogg" , "H7_01821.ogg" , "H7_02301.ogg" , "H7_01744.ogg" , "H7_02498.ogg" },
              new string[] { "H7_04244.ogg" , "H7_00531.ogg" , "H7_01330.ogg" , "H7_01334.ogg" , "H7_02130.ogg" , "H7_02210.ogg" , "H7_01029.ogg" , "H7_05585.ogg" , "H7_01341.ogg" , "H7_01349.ogg" , "H7_04080.ogg" , "H7_01989.ogg" , "H7_07979.ogg" , "H7_05958.ogg" , "H7_02353.ogg" , "H7_04331.ogg" , "H7_02060.ogg" , "H7_02506.ogg" , "H7_01821.ogg" , "H7_02301.ogg" , "H7_01744.ogg" , "H7_02498.ogg" , "H7_08797.ogg" , "H7_07791.ogg" , "H7_02309.ogg" , "H7_02353.ogg" , "H7_01991.ogg" , "H7_02498.ogg" },
              new string[] { "H7_03163.ogg" , "H7_03167.ogg" , "H7_03164.ogg" , "H7_03172.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30SisterFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40SisterVibe = new string[] { "H7_03086.ogg", "H7_03087.ogg", "H7_03102.ogg", "H7_03103.ogg", "H7_02889.ogg" };




        //性格別声テーブル　無愛想---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20CurtnessVibe = new string[][] {
              new string[] { "H8_01331.ogg" , "H8_01332.ogg" , "H8_01139.ogg" , "H8_01140.ogg" },
              new string[] { "H8_01347.ogg" , "H8_01348.ogg" , "H8_01131.ogg" , "H8_01132.ogg" },
              new string[] { "H8_01333.ogg" , "H8_01334.ogg" , "H8_01141.ogg" , "H8_01142.ogg" },
              new string[] { "H8_01349.ogg" , "H8_01350.ogg" , "H8_01133.ogg" , "H8_01134.ogg" },
              new string[] { "H8_01163.ogg" , "H8_01164.ogg" , "H8_01171.ogg" , "H8_01172.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20CurtnessFera = new string[][] {
              new string[] { "H8_01179.ogg" , "H8_01180.ogg" , "H8_01187.ogg" , "H8_01188.ogg" },
              new string[] { "H8_01179.ogg" , "H8_01180.ogg" , "H8_01187.ogg" , "H8_01188.ogg" },
              new string[] { "H8_01181.ogg" , "H8_01182.ogg" , "H8_01189.ogg" , "H8_01190.ogg" },
              new string[] { "H8_01181.ogg" , "H8_01182.ogg" , "H8_01189.ogg" , "H8_01190.ogg" },
              new string[] { "H8_01179.ogg" , "H8_01180.ogg" , "H8_01187.ogg" , "H8_01188.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30CurtnessVibe = new string[][] {
              new string[] { "H8_01335.ogg" , "H8_01336.ogg" , "H8_01143.ogg" , "H8_01144.ogg" },
              new string[] { "H8_01351.ogg" , "H8_01352.ogg" , "H8_01135.ogg" , "H8_01136.ogg" },
              new string[] { "H8_01337.ogg" , "H8_01338.ogg" , "H8_01145.ogg" , "H8_01146.ogg" },
              new string[] { "H8_01353.ogg" , "H8_01354.ogg" , "H8_01137.ogg" , "H8_01138.ogg" },
              new string[] { "H8_01165.ogg" , "H8_01166.ogg" , "H8_01173.ogg" , "H8_01174.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30CurtnessFera = new string[][] {
              new string[] { "H8_01183.ogg" , "H8_01184.ogg" , "H8_01191.ogg" , "H8_01192.ogg" },
              new string[] { "H8_01183.ogg" , "H8_01184.ogg" , "H8_01191.ogg" , "H8_01192.ogg" },
              new string[] { "H8_01185.ogg" , "H8_01186.ogg" , "H8_01193.ogg" , "H8_01194.ogg" },
              new string[] { "H8_01185.ogg" , "H8_01186.ogg" , "H8_01193.ogg" , "H8_01194.ogg" },
              new string[] { "H8_01181.ogg" , "H8_01182.ogg" , "H8_01189.ogg" , "H8_01190.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30CurtnessVibe = new string[][] {
              new string[] { "H8_08466.ogg" , "H8_01430.ogg" , "H8_01421.ogg" , "H8_01382.ogg" , "H8_01396.ogg" , "H8_01398.ogg" },
              new string[] { "H8_08440.ogg" , "H8_08455.ogg" , "H8_08456.ogg" , "H8_08485.ogg" , "H8_08497.ogg" , "H8_08499.ogg" , "H8_02017.ogg" },
              new string[] { "H8_08471.ogg" , "H8_08473.ogg" , "H8_08500.ogg" , "H8_05361.ogg" , "H8_01936.ogg" , "H8_00646.ogg" , "H8_00648.ogg" , "H8_00657.ogg" , "H8_02023.ogg" , "H8_02025.ogg" , "H8_00717.ogg" , "H8_05547.ogg" },
              new string[] { "H8_08463.ogg" , "H8_08464.ogg" , "H8_08465.ogg" , "H8_08486.ogg" , "H8_08492.ogg" , "H8_08505.ogg" , "H8_07064.ogg" , "H8_09399.ogg" , "H8_09402.ogg" , "H8_09474.ogg" , "H8_02953.ogg" , "H8_05361.ogg" , "H8_02971.ogg" , "H8_01936.ogg" , "H8_03201.ogg" , "H8_03206.ogg" , "H8_00617.ogg" , "H8_00646.ogg" , "H8_00657.ogg" , "H8_02025.ogg" , "H8_00747.ogg" , "H8_00768.ogg" , "H8_01626.ogg" , "H8_00830.ogg" , "H8_07061.ogg" , "H8_07062.ogg" , "H8_00918.ogg" , "H8_05277.ogg" , "H8_04988.ogg" , "H8_05006.ogg" , "H8_05322.ogg" , "H8_05214.ogg" , "H8_05249.ogg" , "H8_05252.ogg" , "H8_09710.ogg" , "H8_09711.ogg" , "H8_09712.ogg" , "H8_01396.ogg" },
              new string[] { "H8_01427.ogg" , "H8_01382.ogg" , "H8_01421.ogg" , "H8_01401.ogg" , "H8_01396.ogg" , "H8_01398.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30CurtnessFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40CurtnessVibe = new string[] { "H8_01455.ogg", "H8_01456.ogg", "H8_01457.ogg", "H8_01472.ogg", "H8_01459.ogg" };





        //性格別声テーブル　お嬢様---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20MissyVibe = new string[][] {
              new string[] { "H9_00586.ogg" , "H9_00587.ogg" , "H9_00578.ogg" , "H9_00579.ogg" },
              new string[] { "H9_00786.ogg" , "H9_00787.ogg" , "H9_00570.ogg" , "H9_00571.ogg" },
              new string[] { "H9_00588.ogg" , "H9_00589.ogg" , "H9_00580.ogg" , "H9_00581.ogg" },
              new string[] { "H9_00788.ogg" , "H9_00789.ogg" , "H9_00572.ogg" , "H9_00573.ogg" },
              new string[] { "H9_00612.ogg" , "H9_00613.ogg" , "H9_00610.ogg" , "H9_00611.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20MissyFera = new string[][] {
              new string[] { "H9_00618.ogg" , "H9_00619.ogg" , "H9_00626.ogg" , "H9_00627.ogg" },
              new string[] { "H9_00618.ogg" , "H9_00619.ogg" , "H9_00626.ogg" , "H9_00627.ogg" },
              new string[] { "H9_00620.ogg" , "H9_00621.ogg" , "H9_00628.ogg" , "H9_00629.ogg" },
              new string[] { "H9_00620.ogg" , "H9_00621.ogg" , "H9_00628.ogg" , "H9_00629.ogg" },
              new string[] { "H9_00618.ogg" , "H9_00619.ogg" , "H9_00626.ogg" , "H9_00627.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30MissyVibe = new string[][] {
              new string[] { "H9_00590.ogg" , "H9_00591.ogg" , "H9_00582.ogg" , "H9_00583.ogg" },
              new string[] { "H9_00790.ogg" , "H9_00791.ogg" , "H9_00574.ogg" , "H9_00575.ogg" },
              new string[] { "H9_00592.ogg" , "H9_00593.ogg" , "H9_00584.ogg" , "H9_00585.ogg" },
              new string[] { "H9_00792.ogg" , "H9_00793.ogg" , "H9_00576.ogg" , "H9_00577.ogg" },
              new string[] { "H9_00614.ogg" , "H9_00615.ogg" , "H9_00617.ogg" , "H9_00616.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30MissyFera = new string[][] {
              new string[] { "H9_00622.ogg" , "H9_00623.ogg" , "H9_00630.ogg" , "H9_00631.ogg" },
              new string[] { "H9_00622.ogg" , "H9_00623.ogg" , "H9_00630.ogg" , "H9_00631.ogg" },
              new string[] { "H9_00624.ogg" , "H9_00625.ogg" , "H9_00632.ogg" , "H9_00633.ogg" },
              new string[] { "H9_00624.ogg" , "H9_00625.ogg" , "H9_00632.ogg" , "H9_00633.ogg" },
              new string[] { "H9_00622.ogg" , "H9_00623.ogg" , "H9_00630.ogg" , "H9_00631.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30MissyVibe = new string[][] {
              new string[] { "H9_00825.ogg" , "H9_00833.ogg" , "H9_00841.ogg" , "H9_00824.ogg" , "H9_00966.ogg" , "H9_00860.ogg" , "H9_00987.ogg" },
              new string[] { "H9_09425.ogg" , "H9_04328.ogg" , "H9_09398.ogg" , "H9_00837.ogg" , "H9_04410.ogg" , "H9_07850.ogg" , "H9_04310.ogg" , "H9_04320.ogg" , "H9_04391.ogg" , "H9_09446.ogg" , "H9_04408.ogg" },
              new string[] { "H9_07848.ogg" , "H9_06457.ogg" , "H9_06388.ogg" , "H9_06428.ogg" , "H9_06468.ogg" , "H9_09446.ogg" , "H9_07851.ogg" , "H9_04310.ogg" , "H9_04287.ogg" , "H9_09438.ogg" , "H9_04187.ogg" , "H9_09303.ogg" , "H9_04114.ogg" , "H9_06929.ogg" , "H9_03989.ogg" , ".ogg" , ".ogg" },
              new string[] { "H9_09304.ogg" , "H9_03822.ogg" , "H9_02024.ogg" , "H9_06487.ogg" , "H9_05299.ogg" , "H9_09423.ogg" , "H9_08378.ogg" , "H9_09362.ogg" , "H9_07836.ogg" , "H9_04325.ogg" , "H9_08215.ogg" , "H9_06562.ogg" , "H9_06426.ogg" , "H9_07096.ogg" , "H9_07848.ogg" , "H9_03812.ogg" , "H9_03439.ogg" , "H9_06428.ogg" , "H9_05297.ogg" , "H9_09440.ogg" , "H9_09433.ogg" , "H9_06589.ogg" , "H9_04054.ogg" , "H9_04328.ogg" , "H9_00333.ogg" , "H9_03821.ogg" , "H9_06407.ogg" , "H9_03574.ogg" , "H9_09439.ogg" , "H9_07837.ogg" , "H9_07851.ogg" , "H9_06586.ogg" , "H9_04049.ogg" , "H9_05794.ogg" , "H9_04310.ogg" , "H9_05711.ogg" , "H9_04324.ogg" , "H9_03491.ogg" , "H9_06573.ogg" , "H9_07826.ogg" , "H9_09430.ogg" , "H9_09353.ogg" , "H9_04287.ogg" , "H9_04326.ogg" , "H9_09303.ogg" , "H9_04187.ogg" , "H9_03571.ogg" , "H9_03842.ogg" , "H9_03834.ogg" , "H9_07847.ogg" , "H9_06553.ogg" , "H9_04327.ogg" , "H9_03506.ogg" },
              new string[] { "H9_00825.ogg" , "H9_00833.ogg" , "H9_00841.ogg" , "H9_00824.ogg" , "H9_00966.ogg" , "H9_00860.ogg" , "H9_00987.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30MissyFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40MissyVibe = new string[] { "H9_00894.ogg", "H9_00909.ogg", "H9_00895.ogg", "H9_00910.ogg", "H9_04413.ogg" };





        //性格別声テーブル　幼馴染---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20ChildhoodVibe = new string[][] {
              new string[] { "H10_03849.ogg" , "H10_03850.ogg" , "H10_03857.ogg" , "H10_03858.ogg" },
              new string[] { "H10_03841.ogg" , "H10_03842.ogg" , "H10_04057.ogg" , "H10_04058.ogg" },
              new string[] { "H10_03851.ogg" , "H10_03852.ogg" , "H10_03859.ogg" , "H10_03860.ogg" },
              new string[] { "H10_03843.ogg" , "H10_03844.ogg" , "H10_04059.ogg" , "H10_04060.ogg" },
              new string[] { "H10_03881.ogg" , "H10_03882.ogg" , "H10_03883.ogg" , "H10_03884.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20ChildhoodFera = new string[][] {
              new string[] { "H10_03889.ogg" , "H10_03890.ogg" , "H10_03897.ogg" , "H10_03898.ogg" },
              new string[] { "H10_03889.ogg" , "H10_03890.ogg" , "H10_03897.ogg" , "H10_03898.ogg" },
              new string[] { "H10_03891.ogg" , "H10_03892.ogg" , "H10_03899.ogg" , "H10_03900.ogg" },
              new string[] { "H10_03891.ogg" , "H10_03892.ogg" , "H10_03899.ogg" , "H10_03900.ogg" },
              new string[] { "H10_03889.ogg" , "H10_03890.ogg" , "H10_03897.ogg" , "H10_03898.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30ChildhoodVibe = new string[][] {
              new string[] { "H10_03853.ogg" , "H10_03854.ogg" , "H10_03861.ogg" , "H10_03862.ogg" },
              new string[] { "H10_03845.ogg" , "H10_03846.ogg" , "H10_04061.ogg" , "H10_04062.ogg" },
              new string[] { "H10_03855.ogg" , "H10_03856.ogg" , "H10_03863.ogg" , "H10_03864.ogg" },
              new string[] { "H10_03847.ogg" , "H10_03848.ogg" , "H10_04063.ogg" , "H10_04064.ogg" },
              new string[] { "H10_03885.ogg" , "H10_03886.ogg" , "H10_03887.ogg" , "H10_03888.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30ChildhoodFera = new string[][] {
              new string[] { "H10_03893.ogg" , "H10_03894.ogg" , "H10_03901.ogg" , "H10_03902.ogg" },
              new string[] { "H10_03893.ogg" , "H10_03894.ogg" , "H10_03901.ogg" , "H10_03902.ogg" },
              new string[] { "H10_03895.ogg" , "H10_03896.ogg" , "H10_03903.ogg" , "H10_03904.ogg" },
              new string[] { "H10_03895.ogg" , "H10_03896.ogg" , "H10_03903.ogg" , "H10_03904.ogg" },
              new string[] { "H10_03893.ogg" , "H10_03894.ogg" , "H10_03901.ogg" , "H10_03902.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30ChildhoodVibe = new string[][] {
              new string[] { "H10_04104.ogg" , "H10_04120.ogg" , "H10_04108.ogg" , "H10_04092.ogg" , "H10_04112.ogg" , "H10_04242.ogg" , "H10_04253.ogg" },
              new string[] { "H10_08819.ogg" , "H10_09457.ogg" , "H10_09058.ogg" , "H10_07196.ogg" , "H10_07216.ogg" , "H10_08271.ogg" , "H10_09813.ogg" },
              new string[] { "H10_09415.ogg" , "H10_09993.ogg" , "H10_08334.ogg" , "H10_01736.ogg" , "H10_01739.ogg" , "H10_03656.ogg" , "H10_03475.ogg" , "H10_03050.ogg" , "H10_03714.ogg" , "H10_03717.ogg" , "H10_03504.ogg" , "H10_03752.ogg" , "H10_04738.ogg" , "H10_08819.ogg" , "H10_09457.ogg" , "H10_09058.ogg" , "H10_07196.ogg" , "H10_07216.ogg" , "H10_08271.ogg" , "H10_09813.ogg" },
              new string[] { "H10_09415.ogg" , "H10_09993.ogg" , "H10_08334.ogg" , "H10_01736.ogg" , "H10_01739.ogg" , "H10_03656.ogg" , "H10_03475.ogg" , "H10_03050.ogg" , "H10_03714.ogg" , "H10_03717.ogg" , "H10_03504.ogg" , "H10_03752.ogg" , "H10_04738.ogg" , "H10_08819.ogg" , "H10_09457.ogg" , "H10_09058.ogg" , "H10_07196.ogg" , "H10_07216.ogg" , "H10_08271.ogg" , "H10_09813.ogg" , "H10_07212.ogg" , "H10_09173.ogg" , "H10_01079.ogg" , "H10_01553.ogg" , "H10_00671.ogg" , "H10_03456.ogg" , "H10_09207.ogg" , "H10_05225.ogg" , "H10_05228.ogg" , "H10_05231.ogg" , "H10_05617.ogg" , "H10_05393.ogg" , "H10_06041.ogg" , "H10_06229.ogg" , "H10_06066.ogg" , "H10_07020.ogg" , "H10_07021.ogg" },
              new string[] { "H10_04104.ogg" , "H10_04120.ogg" , "H10_04108.ogg" , "H10_04092.ogg" , "H10_04112.ogg" , "H10_04242.ogg" , "H10_04253.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30ChildhoodFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40ChildhoodVibe = new string[] { "H10_04171.ogg", "H10_04165.ogg", "H10_04166.ogg", "H10_04168.ogg", "H10_04170.ogg" };





        //性格別声テーブル　ドＭ---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20MasochistVibe = new string[][] {
              new string[] { "H11_00673.ogg" , "H11_00674.ogg" , "H11_00681.ogg" , "H11_00682.ogg" },
              new string[] { "H11_00865.ogg" , "H11_00866.ogg" , "H11_00689.ogg" , "H11_00690.ogg" },
              new string[] { "H11_00675.ogg" , "H11_00676.ogg" , "H11_00683.ogg" , "H11_00684.ogg" },
              new string[] { "H11_00867.ogg" , "H11_00868.ogg" , "H11_00691.ogg" , "H11_00692.ogg" },
              new string[] { "H11_00705.ogg" , "H11_00706.ogg" , "H11_00729.ogg" , "H11_00730.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20MasochistFera = new string[][] {
              new string[] { "H11_00713.ogg" , "H11_00714.ogg" , "H11_00721.ogg" , "H11_00722.ogg" },
              new string[] { "H11_00713.ogg" , "H11_00714.ogg" , "H11_00721.ogg" , "H11_00722.ogg" },
              new string[] { "H11_00715.ogg" , "H11_00716.ogg" , "H11_00723.ogg" , "H11_00724.ogg" },
              new string[] { "H11_00715.ogg" , "H11_00716.ogg" , "H11_00723.ogg" , "H11_00724.ogg" },
              new string[] { "H11_00713.ogg" , "H11_00714.ogg" , "H11_00721.ogg" , "H11_00722.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30MasochistVibe = new string[][] {
              new string[] { "H11_00677.ogg" , "H11_00678.ogg" , "H11_00685.ogg" , "H11_00686.ogg" },
              new string[] { "H11_00869.ogg" , "H11_00870.ogg" , "H11_00693.ogg" , "H11_00694.ogg" },
              new string[] { "H11_00679.ogg" , "H11_00680.ogg" , "H11_00687.ogg" , "H11_00688.ogg" },
              new string[] { "H11_00871.ogg" , "H11_00872.ogg" , "H11_00695.ogg" , "H11_00696.ogg" },
              new string[] { "H11_00708.ogg" , "H11_00707.ogg" , "H11_00731.ogg" , "H11_00732.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30MasochistFera = new string[][] {
              new string[] { "H11_00717.ogg" , "H11_00718.ogg" , "H11_00725.ogg" , "H11_00726.ogg" },
              new string[] { "H11_00717.ogg" , "H11_00718.ogg" , "H11_00725.ogg" , "H11_00726.ogg" },
              new string[] { "H11_00719.ogg" , "H11_00720.ogg" , "H11_00727.ogg" , "H11_00728.ogg" },
              new string[] { "H11_00719.ogg" , "H11_00720.ogg" , "H11_00727.ogg" , "H11_00728.ogg" },
              new string[] { "H11_00717.ogg" , "H11_00718.ogg" , "H11_00725.ogg" , "H11_00726.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30MasochistVibe = new string[][] {
              new string[] { "H11_00902.ogg" , "H11_00905.ogg" , "H11_00923.ogg" , "H11_00924.ogg" },
              new string[] { "H11_04914.ogg" , "H11_04738.ogg" , "H11_04915.ogg" , "H11_04983.ogg" ,"H11_05086.ogg" },
              new string[] { "H11_01458.ogg" , "H11_02000.ogg" , "H11_01850.ogg" , "H11_01963.ogg" , "H11_04177.ogg" , "H11_04265.ogg" , "H11_01980.ogg" , "H11_01988.ogg" , "H11_02029.ogg" , "H11_04914.ogg" , "H11_04738.ogg" , "H11_04915.ogg" , "H11_04983.ogg" ,"H11_05086.ogg" },
              new string[] { "H11_04902.ogg" , "H11_05069.ogg" , "H11_05104.ogg" , "H11_05150.ogg" , "H11_04450.ogg" , "H11_01875.ogg" , "H11_01880.ogg" , "H11_01883.ogg" , "H11_01885.ogg" , "H11_02204.ogg" , "H11_01945.ogg" , "H11_04253.ogg" , "H11_03646.ogg" , "H11_03545.ogg" , "H11_03414.ogg" , "H11_03548.ogg" , "H11_03596.ogg" , "H11_05093.ogg" , "H11_01988.ogg" , "H11_04914.ogg" , "H11_04738.ogg" , "H11_04915.ogg" , "H11_04983.ogg" ,"H11_05086.ogg" },
              new string[] { "H11_00902.ogg" , "H11_00905.ogg" , "H11_00923.ogg" , "H11_00924.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30MasochistFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40MasochistVibe = new string[] { "H11_00957.ogg", "H11_00969.ogg", "H11_00958.ogg", "H11_00970.ogg", "H11_02817.ogg" };





        //性格別声テーブル　腹黒---------------------------------------------------------------
        //弱バイブ　通常
        public static string[][] sLoopVoice20CraftyVibe = new string[][] {
              new string[] { "H12_01213.ogg" , "H12_01214.ogg" , "H12_01221.ogg" , "H12_01222.ogg" },
              new string[] { "H12_01205.ogg" , "H12_01206.ogg" , "H12_01421.ogg" , "H12_01422.ogg" },
              new string[] { "H12_01215.ogg" , "H12_01216.ogg" , "H12_01223.ogg" , "H12_01227.ogg" },
              new string[] { "H12_01207.ogg" , "H12_01208.ogg" , "H12_01423.ogg" , "H12_01424.ogg" },
              new string[] { "H12_01245.ogg" , "H12_01247.ogg" , "H12_01248.ogg" , "H12_01249.ogg" }
              };
        //弱バイブ　フェラ
        public static string[][] sLoopVoice20CraftyFera = new string[][] {
              new string[] { "H12_01253.ogg" , "H12_01254.ogg" , "H12_01261.ogg" , "H12_01262.ogg" },
              new string[] { "H12_01253.ogg" , "H12_01254.ogg" , "H12_01261.ogg" , "H12_01262.ogg" },
              new string[] { "H12_01255.ogg" , "H12_01256.ogg" , "H12_01263.ogg" , "H12_01264.ogg" },
              new string[] { "H12_01255.ogg" , "H12_01256.ogg" , "H12_01263.ogg" , "H12_01264.ogg" },
              new string[] { "H12_01253.ogg" , "H12_01254.ogg" , "H12_01261.ogg" , "H12_01262.ogg" }
              };
        //強バイブ　通常
        public static string[][] sLoopVoice30CraftyVibe = new string[][] {
              new string[] { "H12_01217.ogg" , "H12_01218.ogg" , "H12_01225.ogg" , "H12_01226.ogg" },
              new string[] { "H12_01209.ogg" , "H12_01210.ogg" , "H12_01425.ogg" , "H12_01426.ogg" },
              new string[] { "H12_01219.ogg" , "H12_01220.ogg" , "H12_01227.ogg" , "H12_01228.ogg" },
              new string[] { "H12_01211.ogg" , "H12_01212.ogg" , "H12_01427.ogg" , "H12_01428.ogg" },
              new string[] { "H12_01249.ogg" , "H12_01250.ogg" , "H12_01251.ogg" , "H12_01252.ogg" }
              };
        //強バイブ　フェラ
        public static string[][] sLoopVoice30CraftyFera = new string[][] {
              new string[] { "H12_01257.ogg" , "H12_01258.ogg" , "H12_01265.ogg" , "H12_01266.ogg" },
              new string[] { "H12_01257.ogg" , "H12_01258.ogg" , "H12_01265.ogg" , "H12_01266.ogg" },
              new string[] { "H12_01259.ogg" , "H12_01260.ogg" , "H12_01267.ogg" , "H12_01268.ogg" },
              new string[] { "H12_01259.ogg" , "H12_01260.ogg" , "H12_01267.ogg" , "H12_01268.ogg" },
              new string[] { "H12_01257.ogg" , "H12_01258.ogg" , "H12_01265.ogg" , "H12_01266.ogg" }
              };
        //絶頂　通常
        public static string[][] sOrgasmVoice30CraftyVibe = new string[][] {
              new string[] { "H12_01487.ogg" , "H12_01488.ogg" , "H12_01487.ogg" , "H12_01488.ogg" },
              new string[] { "H12_01488.ogg" , "H12_01663.ogg" , "H12_03082.ogg" , "H12_03084.ogg" ,"H12_03115.ogg" },
              new string[] { "H12_03082.ogg" , "H12_01725.ogg" , "H12_03082.ogg" , "H12_01870.ogg" , "H12_01799.ogg" , "H12_01787.ogg", "H12_01488.ogg" , "H12_01663.ogg" , "H12_03084.ogg" ,"H12_03115.ogg" },
              new string[] { "H12_01487.ogg" , "H12_01665.ogg" , "H12_01870.ogg" , "H12_01799.ogg" , "H12_01725.ogg" , "H12_03084.ogg" , "H12_03096.ogg" , "H12_03115.ogg" , "H12_01663.ogg" , "H12_01787.ogg" , "H12_01666.ogg"  },
              new string[] { "H12_01487.ogg" , "H12_01488.ogg" , "H12_01487.ogg" , "H12_01488.ogg" }
              };
        //絶頂　フェラ
        public static string[][] sOrgasmVoice30CraftyFera = new string[][] {
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" , ".ogg" },
              new string[] { ".ogg" , ".ogg" , ".ogg" , ".ogg" }
              };
        //停止時
        public static string[] sLoopVoice40CraftyVibe = new string[] { "H12_01529.ogg", "H12_01544.ogg", "H12_01530.ogg", "H12_01545.ogg", "H12_01534.ogg" };










        //　性格別声テーブル　こっち来て
        public static string[] sCallVoice = new string[] { "S0_13972.ogg", "S1_03893.ogg", "s2_08163.ogg", "S3_11386.ogg", "s4_15255.ogg", "s5_16924.ogg", "s6_18089.ogg", "", "" };



        //カスタム音声テーブル　弱バイブ版---------------------------------------------------------------
        //カスタムボイス１
        public static string[][] sLoopVoice20Custom1 = new string[][] {
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" }
              };
        //カスタムボイス２
        public static string[][] sLoopVoice20Custom2 = new string[][] {
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" }
              };
        //カスタムボイス３
        public static string[][] sLoopVoice20Custom3 = new string[][] {
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" }
              };
        //カスタムボイス４
        public static string[][] sLoopVoice20Custom4 = new string[][] {
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" }
              };

        //カスタム音声テーブル　強バイブ版---------------------------------------------------------------
        public static string[][] sLoopVoice30Custom1 = new string[][] {
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00421.ogg" , "N0_00422.ogg" , "N0_00423.ogg" },
              new string[] { "N0_00435.ogg" , "N0_00449.ogg" }
              };
        public static string[][] sLoopVoice30Custom2 = new string[][] {
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00252.ogg" , "N7_00255.ogg" , "N7_00267.ogg" , "N7_00261.ogg" },
              new string[] { "N7_00262.ogg" , "N7_00267.ogg" , "N7_00269.ogg" , "N7_00272.ogg" }
              };
        public static string[][] sLoopVoice30Custom3 = new string[][] {
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00183.ogg" , "N1_00195.ogg" , "N1_00323.ogg" , "N1_00330.ogg" },
              new string[] { "N1_00170.ogg" , "N1_00191.ogg" , "N1_00192.ogg" , "N1_00194.ogg" }
              };
        public static string[][] sLoopVoice30Custom4 = new string[][] {
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00310.ogg" , "N3_00318.ogg" , "N3_00377.ogg" },
              new string[] { "N3_00157.ogg" , "N3_00370.ogg" }
              };

        //カスタム音声テーブル　絶頂時---------------------------------------------------------------
        public static string[][] sOrgasmVoice30Custom1 = new string[][] {
              new string[] { "N0_00424.ogg" , "N0_00459.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" },
              new string[] { "N0_00424.ogg" , "N0_00459.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" },
              new string[] { "N0_00424.ogg" , "N0_00457.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" },
              new string[] { "N0_00456.ogg" , "N0_00457.ogg" , "N0_00458.ogg" , "N0_00534.ogg" , "N0_00288.ogg" , "N0_00292.ogg" , "N0_00293.ogg" },
              new string[] { "N0_00424.ogg" , "N0_00459.ogg" , "N0_00503.ogg" , "N0_00508.ogg" , "N0_00534.ogg" }
              };
        public static string[][] sOrgasmVoice30Custom2 = new string[][] {
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" },
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" },
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" },
              new string[] { "N7_00284.ogg" , "N7_00291.ogg" , "N7_00293.ogg" , "N7_00294.ogg" , "N7_00295.ogg" , "N7_00275.ogg" , "n7_00295.ogg" },
              new string[] { "N7_00251.ogg" , "N7_00267.ogg" , "N7_00275.ogg" , "N7_00276.ogg" , "N7_00280.ogg" }
              };
        public static string[][] sOrgasmVoice30Custom3 = new string[][] {
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00198.ogg" , "N1_00199.ogg" , "N1_00205.ogg" , "N1_00217.ogg" , "N1_00333.ogg" },
              new string[] { "N1_00179.ogg" , "N1_00180.ogg" , "N1_00200.ogg" , "N1_00204.ogg" , "N1_00209.ogg" }
              };
        public static string[][] sOrgasmVoice30Custom4 = new string[][] {
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" },
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" },
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" },
              new string[] { "N3_00376.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00197.ogg" , "N3_00203.ogg" , "N3_00328.ogg" , "N3_00330.ogg" , "N3_00379.ogg" },
              new string[] { "N3_00193.ogg" , "N3_00194.ogg" , "N3_00195.ogg" , "N3_00330.ogg" , "N3_00378.ogg" }
              };

        //カスタム音声テーブル　停止時---------------------------------------------------------------
        public static string[] sLoopVoice40Custom1 = new string[] { "N0_00460.ogg", "N0_00460.ogg", "N0_00460.ogg", "N0_00460.ogg", "N0_00460.ogg" };
        public static string[] sLoopVoice40Custom2 = new string[] { "N7_00277.ogg", "N7_00277.ogg", "N7_00277.ogg", "N7_00277.ogg", "N7_00277.ogg" };
        public static string[] sLoopVoice40Custom3 = new string[] { "N1_00382.ogg", "N1_00382.ogg", "N1_00382.ogg", "N1_00382.ogg", "N1_00382.ogg" };
        public static string[] sLoopVoice40Custom4 = new string[] { "N3_00205.ogg", "N3_00205.ogg", "N3_00205.ogg", "N3_00205.ogg", "N3_00205.ogg" };

        //改変終了---------------------------------------

        public static string[][] reactionVoice = new string[][] { //性格追加時に更新
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





        public static void setup(BasicVoiceSet[] bvs)
        {
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
        }

    }
}
