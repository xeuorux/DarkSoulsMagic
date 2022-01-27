using MagicSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.MagicSiteServices
{
    public class CardDatabase
    {
        private bool initialized = false;

        private Dictionary<string, List<Card>> cards;
        public Dictionary<string, List<Card>> Cards
        {
            get
            {
                if (cards != null)
                {
                    return cards;
                }
                else
                {
                    Initialize();
                    return cards;
                }
            }
        }

        private List<Card> tokens;
        public List<Card> Tokens
        {
            get
            {
                if (tokens != null)
                {
                    return tokens;
                }
                else
                {
                    Initialize();
                    return tokens;
                }
            }
        }

        private List<Card> basics;
        public List<Card> Basics
        {
            get
            {
                if (basics != null)
                {
                    return basics;
                }
                else
                {
                    Initialize();
                    return basics;
                }
            }
        }
        public void Initialize()
        {
            if (!initialized)
            {
                LoadXMLs();

                initialized = true;
            }
        }

        private string[] namesOfXMLs = new string[]
        {
            "HLW",
            "MHLW"
        };

        private void LoadXMLs()
        {
            Console.WriteLine("LOADING XML");

            cards = new Dictionary<string, List<Card>>();

            foreach(string xmlName in namesOfXMLs)
            {
                List<Card> newCards = new List<Card>();
                cards.Add(xmlName, newCards);

                XElement cardsHead = XElement.Load($"wwwroot/{xmlName}.xml");

                IEnumerable<XElement> cardElements = cardsHead.Descendants("card");

                foreach (XElement element in cardElements)
                {
                    string cardName = element.Descendants("name").First().Value;

                    Rarity rarity = Rarity.noRarity;
                    try
                    {
                        XAttribute rarityAttribute = element.Descendants("set").First().Attribute("rarity");
                        if (rarityAttribute != null)
                        {
                            rarity = Rarity.Rarities.Where(e => e.name.ToLower().Equals(rarityAttribute.Value)).First();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.Write(e);
                    }
                    Color[] colors = ParseColors(element.Descendants("color").First().Value);
                    String manaCost = "";
                    try
                    {
                        manaCost = element.Descendants("manacost").First().Value;
                    }
                    catch (Exception e)
                    {
                        //Console.Error.Write(e);
                    }
                    int cmc = 0;
                    try
                    {
                        cmc = int.Parse(element.Descendants("cmc").First().Value);
                    }
                    catch (Exception e)
                    {
                        //Console.Error.Write(e);
                    }

                    string typeLine = "";
                    try
                    {
                        typeLine = element.Descendants("type").First().Value;
                    }
                    catch (Exception e)
                    {
                        //Console.Error.Write(e);
                    }

                    string text = "";
                    try
                    {
                        text = element.Descendants("text").First().Value;
                    }
                    catch (Exception e)
                    {
                        //Console.Error.Write(e);
                    }

                    string flavorText = "";
                    try
                    {
                        flavorText = element.Descendants("flavor-text").First().Value;
                    }
                    catch (Exception e)
                    {
                        //Console.Error.Write(e);
                    }

                    int power = 0;
                    int toughness = 0;
                    try
                    {
                        string PT = element.Descendants("pt").First().Value;
                        power = int.Parse(PT.Split("/").First());
                        toughness = int.Parse(PT.Split("/")[1]);
                    }
                    catch (Exception e)
                    {
                        //Console.Error.Write(e);
                    }

                    Card newCard = new Card
                    {
                        name = cardName,
                        rarity = rarity,
                        colors = colors,
                        manacost = manaCost,
                        convertedManaCost = cmc,
                        typeLine = typeLine,
                        text = text,
                        flavorText = flavorText,
                        power = power,
                        toughness = toughness,
                        cardNumber = Card.cardCount++
                    };

                    newCards.Add(newCard);
                }
            }
        }

        private Color[] ParseColors(String colorsString)
        {
            if (colorsString.Length == 0)
            {
                return new Color[] { };
            }
            else
            {
                List<Color> colorsOfCard = new List<Color>();

                foreach (Color color in Color.Colors)
                {
                    if (colorsString.Contains(color.code))
                    {
                        colorsOfCard.Add(color);
                    }
                }

                return colorsOfCard.ToArray();
            }
        }
    }
}