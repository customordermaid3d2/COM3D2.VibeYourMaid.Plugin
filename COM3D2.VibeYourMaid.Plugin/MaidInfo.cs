using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM3D2.VibeYourMaid.Plugin
{

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

}
