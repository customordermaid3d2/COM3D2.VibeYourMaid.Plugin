using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM3D2.VibeYourMaid.Plugin
{
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

}
