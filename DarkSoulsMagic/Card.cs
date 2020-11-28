using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace DarkSoulsMagic
{
    public class WorldSectionInfo
    {
        public string name { get; set; }
        public string colorCode { get; set; }
        public string cardImageName { get; set; }
        public bool cardImageOnLeft { get; set; }
        public string description { get; set; }
        public bool backgroundColorGold { get; set; }
    }
}
