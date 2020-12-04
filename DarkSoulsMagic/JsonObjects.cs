using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace MagicSite
{
    public class SpoilerInfo
    {
        public string spoilerName { get; set; }
        public string spoilerDescription { get; set; }
        public string spoilerXMLName { get; set; }
        public BoosterPackSlot[] boosterPackSlot { get; set; }
        public BoosterPackRestrictions boosterPackRestrictions { get; set; }
    }
    public class BoosterPackSlot
    {
        public string rarity { get; set; }
        public int count { get; set; } = 1;
        public string selectionLogic { get; set; }
        public BoosterPackRatio[] ratios { get; set; }
    }

    public class BoosterPackRatio
    {
        public int parts { get; set; }
        public string rarity { get; set; }
        public int count { get; set; } = 1;
        public string selectionLogic { get; set; }
    }

    public class BoosterPackRestrictions
    {
        public bool noDuplicates { get; set; }
        public int atLeastXCardOfEachColor { get; set; }

        public int noMoreThanXCardOfEachColor { get; set; }
    }
    public class WorldSectionInfo
    {
        public string name { get; set; }
        public string colorCode { get; set; }
        public string cardImageName { get; set; }
        public string description { get; set; }
        public bool backgroundColorGold { get; set; }
        public bool showColorsAsHybrid { get; set; }
    }
}
