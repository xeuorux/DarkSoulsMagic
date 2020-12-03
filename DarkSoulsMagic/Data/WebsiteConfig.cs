using MagicSite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.MagicSiteServices
{
    public class WebsiteConfig
    {
        public class WebsiteInfo
        {
            public string websiteTitle { get; set; }
            public string loadingText { get; set; }
            public string tagline { get; set; }
            public bool features { get; set; }
            public string homePageLinkLabel { get; set; }
            public string homePageFeaturesTitle { get; set; }
            public bool worldPage { get; set; }
            public string worldPageLinkLabel { get; set; }
            public bool draftArchetypesPage { get; set; }
            public string draftArchetypesPageLinkLabel { get; set; }
            public string draftArchetypesPageTitle { get; set; }
            public bool spoilerPage { get; set; }
            public string spoilerPageLinkLabel { get; set; }
            public bool mechanicsPage { get; set; }
            public string mechanicsPageLinkLabel { get; set; }
            public string mechanicsPageTitle { get; set; }
            public bool playPage { get; set; }
            public string playPageLinkLabel { get; set; }
            public string playPageTitle { get; set; }
            public bool tokenBasicSpoilerPage { get; set; }
            public string tokenBasicSpoilerPageLinkLabel { get; set; }
            public string tokenBasicSpoilerPageBasicsTitle { get; set; }
            public string tokenBasicSpoilerPageTokensTitle { get; set; }
            public bool tokenBasicSpoilerPageBasicsFirst { get; set; }
            public bool futurePage { get; set; }
            public string futurePageLinkLabel { get; set; }
            public string futurePageTitle { get; set; }
            public bool creditsPage { get; set; }
            public string creditsPageLinkLabel { get; set; }
            public string creditsPageTitle { get; set; }
        }

        public WebsiteInfo info
        {
            get;
            private set;
        }

        public WebsiteConfig()
        {
            string json = File.ReadAllText("wwwroot/website_info/website.json");
            info = JsonSerializer.Deserialize<WebsiteInfo>(json);
        }
    }
}