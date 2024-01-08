using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace googleplayCrawler
{
    internal class Crawler
    {
        private readonly HtmlDocument doc;
        public Crawler(string html)
        {
            doc = new HtmlDocument();
            doc.LoadHtml(html);
        }

        public string GetName()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
            if (h1Element != null)
            {
                return h1Element.InnerText;
            }
            else
            {
                return "-";
            }
        }

        public string GetDeveloperName()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//div[@class='Vbfug auoIOc']/a/span");
            if (h1Element != null)
            {
                return h1Element.InnerText;
            }
            else
            {
                return "-";
            }
        }

        public string GetDeveloperURL()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//div[@class='Vbfug auoIOc']/a");
            if (h1Element != null)
            {
                var mainURL = "https://play.google.com" + h1Element.GetAttributeValue("href", "");
                return mainURL;
            }
            else
            {
                return "-";
            }
        }

        public string GetRate()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//div[@itemprop='starRating']/div");
            if (h1Element != null)
            {
                return h1Element.InnerText.Replace("star", string.Empty);
            }
            else
            {
                return "-";
            }
        }

        public string GetNumberOfReviews()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//div[@class='w7Iutd']/div[@class='wVqUob']/div[@class='g1rdde']");
            if (h1Element != null)
            {
                return h1Element.InnerText.Replace(" reviews", string.Empty);
            }
            else
            {
                return "-";
            }
        }

        public string GetAgeRating()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//span[@itemprop='contentRating']/span");
            if (h1Element != null)
            {
                return h1Element.InnerText;
            }
            else
            {
                return "-";
            }
        }
        public string GetAgeRatingImage()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//div[@class='ClM7O']/img[@class='T75of xGa6dd' and @alt='Content rating']");
            if (h1Element != null)
            {
                return h1Element.GetAttributeValue("srcset", "").Replace(" 2x", string.Empty);
            }
            else
            {
                return "-";
            }
        }

        public string GetDownloadCount()
        {
            var h1Element = doc.DocumentNode.SelectNodes("//div[@class='l8YSdd']/div[@class='w7Iutd']/div[@class='wVqUob']/div[@class='ClM7O']")[1];
            if (h1Element != null)
            {
                return h1Element.InnerText;
            }
            else
            {
                return "-";
            }
        }

        public List<string> GetImages()
        {
            var minsizeImage = "w526-h296";
            var maxSizeImage = "w2560-h1440";

            var imagesElement = doc.DocumentNode.SelectNodes("//img[@alt='Screenshot image' and @class='T75of B5GQxf']");
            if (imagesElement.Any())
            {
                List<string> images = new List<string>();

                foreach (var image in imagesElement)
                {
                    images.Add(image.GetAttributeValue("src", "-").Replace(minsizeImage, maxSizeImage));
                }
                return images;
            }
            else
            {
                return new List<string>();
            }
        }

        public string GetUpdatedOn()
        {
            var h1Element = doc.DocumentNode.SelectSingleNode("//div[@class='TKjAsc']/div/div[@class='xg1aie']");
            if (h1Element != null)
            {
                return h1Element.InnerText;
            }
            else
            {
                return "-";
            }
        }

        //public string GetAboutAppInfo(int Index)
        //{
        //    var h1Element = doc.DocumentNode.SelectNodes("//div[@class='G1zzid']/div[@class='sMUprd']/div[@class='reAt0']")[Index];
        //    if (h1Element != null)
        //    {
        //        return h1Element.InnerText;
        //    }
        //    else
        //    {
        //        return "-";
        //    }
        //}
    }
}
