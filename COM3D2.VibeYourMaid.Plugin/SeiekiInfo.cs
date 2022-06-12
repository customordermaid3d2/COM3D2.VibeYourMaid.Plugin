using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM3D2.VibeYourMaid.Plugin
{
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

}
