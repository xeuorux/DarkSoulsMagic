using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace DarkSoulsMagic
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
        public string name
        {
            private set;
            get;
        }
        public string code
        {
            private set;
            get;
        }
        public string hexCode
        {
            private set;
            get;
        }
        public int index
        {
            private set;
            get;
        }
        private static int rarityCount = 0;

        private Rarity(string name, string code, string hexCode)
        {
            this.name = name;
            this.code = code;
            this.hexCode = hexCode;
            this.index = rarityCount++;
        }

        private static Rarity[] rarities = new Rarity[]
        {
            new Rarity("Common", "C", "#000000"),
            new Rarity("Uncommon", "U", "#000000"),
            new Rarity("Rare", "R", "#000000"),
            new Rarity("Mythic", "M", "#000000"),
        };
        public static Rarity[] Rarities
        {
            get
            {
                return rarities;
            }
        }

        public static Rarity noRarity = new Rarity("None", "", "#000000");
    }
}
