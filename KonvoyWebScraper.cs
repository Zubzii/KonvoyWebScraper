//Tutorial: https://www.youtube.com/watch?v=m9zFq6KS94Y

using HtmlAgilityPack; //HTML parser, a tool designed to read and interpret HTML (HyperText Markup Language) documents. 
using System;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace WebScraper
{
    class KonvoyWebScraper
    {
        public static void Run()
        {
            //Send get request to Konvoy Content Website
            string url = "https://www.konvoy.vc/content";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //Get Konvoy Most Recent Newsletter
            var headerNodes = htmlDocument.DocumentNode.SelectNodes("//a[@data-w-id='50838397-9883-0264-0c90-da02e97749ab']/@href");
            List<string> hrefs = new List<string>();
            if (headerNodes != null)
            {
                foreach (var header in headerNodes)
                {
                    var hrefValue = header.GetAttributeValue("href", string.Empty);
                    hrefs.Add(hrefValue);
                }
            }
            var first_link = hrefs[0];
            Console.WriteLine(first_link);

            //Pulls text from Konvoy's most revent newsletter
            string newUrl = "https://www.konvoy.vc" + first_link;
            Console.WriteLine(newUrl);
            var newHttpClient = new HttpClient();
            var newHtml = newHttpClient.GetStringAsync(newUrl).Result;
            var newHtmlDocument = new HtmlDocument();
            newHtmlDocument.LoadHtml(newHtml);

            var newHeaderNodes = newHtmlDocument.DocumentNode.SelectNodes("//li");
            if (newHeaderNodes != null)
            {
                foreach (var newHeader in newHeaderNodes)
                {
                    var text = newHeader.InnerText;
                    Console.WriteLine(text);
                }
            }
        }
    }
}

