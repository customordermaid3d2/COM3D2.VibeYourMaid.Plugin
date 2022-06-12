using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM3D2.VibeYourMaid.Plugin
{
    internal class SeiekiInfoSetup
    {

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

        public static SeiekiInfo Info(string marks)
        {
            int random;
            switch (marks)
            {
                case "顔":
                    random = UnityEngine.Random.Range(0, KaoMarks.Count);
                    return KaoMarks[random];
                    break;

                case "胸":
                    random = UnityEngine.Random.Range(0, MuneMarks.Count);
                    return MuneMarks[random];
                    break;

                case "口元":
                    random = UnityEngine.Random.Range(0, KuchimotoMarks.Count);
                    return KuchimotoMarks[random];
                    break;

                case "背中":
                    random = UnityEngine.Random.Range(0, SenakaMarks.Count);
                    return SenakaMarks[random];
                    break;

                case "尻":
                    random = UnityEngine.Random.Range(0, SiriMarks.Count);
                    return SiriMarks[random];
                    break;

                case "腹":
                    random = UnityEngine.Random.Range(0, HaraMarks.Count);
                    return HaraMarks[random];
                    break;

                case "太股":
                    random = UnityEngine.Random.Range(0, HutomomoMarks.Count);
                    return HutomomoMarks[random];
                    break;

                case "秘部":
                    random = UnityEngine.Random.Range(0, HibuMarks.Count);
                    return HibuMarks[random];
                    break;

                default:
                    return null;
            }

        }

    }
}
