using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace DarkSoulsMagic
{    public class SpoilerInfo
    {
        public string spoilerName { get; set; }
        public string spoilerDescription { get; set; }
        public string spoilerXMLName { get; set; }
        public BoosterPackArrangement[] boosterPackArrangement { get; set; }
        public int ratioedSlots { get; set; }
    }
    public class BoosterPackArrangement
    {
        public string rarity { get; set; }
        public int count { get; set; }
        public int ratioedSlot { get; set; }
        public int parts { get; set; }
    }
    public class WorldSectionInfo
    {
        public string name { get; set; }
        public string colorCode { get; set; }
        public string cardImageName { get; set; }
        public bool cardImageOnLeft { get; set; }
        public string description { get; set; }
        public bool backgroundColorGold { get; set; }
        public bool showColorsAsHybrid { get; set; }
    }
}
