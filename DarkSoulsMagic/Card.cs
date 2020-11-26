using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private Color (string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        private static Color[] colors  = new Color[]
        {
            new Color("White", "W"),
            new Color("Blue", "U"),
            new Color("Black", "B"),
            new Color("Red", "R"),
            new Color("Green", "G"),
        };
        public static Color[] Colors
        {
            get
            {
                return colors;
            }
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
