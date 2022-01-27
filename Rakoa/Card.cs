using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace MagicSite
{
    public class Card
    {
        public string name;
        public Rarity rarity;
        public Color[] colors;
        public String manacost;
        public int convertedManaCost;
        public string typeLine;
        public string text;
        public string flavorText;
        public int power;
        public int toughness;
        public int cardNumber;

        public static int cardCount = 0;
    }

    public class Color
    {
        public string name { get; set; }
        public string code { get; set; }

        public string backgroundHexcode { get; set; }
        public static Color[] Colors
        {
            private set;
            get;
        }

        static Color()
        {
            string json = File.ReadAllText("wwwroot/website_info/colors.json");
            Colors = JsonSerializer.Deserialize<Color[]>(json);
        }

        public static Color GetColorOfCode (string code)
        {
            return Colors.Where(e => e.code.Equals(code)).FirstOrDefault();
        }
    }

    public class Rarity
    {
        public string name { get; set; }
        public string code { get; set; }
        public string backgroundHexCode { get; set; }
        public int index { get; set; }

        static Rarity()
        {
            string json = File.ReadAllText("wwwroot/website_info/rarities.json");
            Rarities = JsonSerializer.Deserialize<Rarity[]>(json);
            noRarity = new Rarity
             {
                 name = "None",
                 code = "",
                 backgroundHexCode = "#000000",
                 index = 0
             };
        }
        public static Rarity[] Rarities
        {
            private set;
            get;
        }

        public static Rarity noRarity;
    }
}
