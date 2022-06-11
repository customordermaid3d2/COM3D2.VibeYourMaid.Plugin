using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM3D2.VibeYourMaid.Plugin
{
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
}
