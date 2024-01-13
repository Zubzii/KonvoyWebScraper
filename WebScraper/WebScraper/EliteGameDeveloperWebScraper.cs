//Tutorial: https://www.youtube.com/watch?v=m9zFq6KS94Y

using HtmlAgilityPack; //HTML parser, a tool designed to read and interpret HTML (HyperText Markup Language) documents. 
using System;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace WebScraper
{
    class EliteGameDeveloperWebScraper
    {
        public static void Run()
        {
            //Send get request to Content Website
            string url = "https://www.elitegamedevelopers.com/newsletter/";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //Get Most Recent Newsletter
            var headerNodes = htmlDocument.DocumentNode.SelectNodes("//a");
            List<string> paragraphs = new List<string>();
            if (headerNodes != null)
            {
                foreach (var header in headerNodes)
                {
                    var hrefValue = header.GetAttributeValue("href", string.Empty);
                    paragraphs.Add(hrefValue);
                }
            }
            var tenth_link = paragraphs[9];

            //Pulls text from most recent newsletter
            string newUrl = tenth_link;
            var newHttpClient = new HttpClient();
            var newHtml = newHttpClient.GetStringAsync(newUrl).Result;
            var newHtmlDocument = new HtmlDocument();
            newHtmlDocument.LoadHtml(newHtml);

            var newHeaderNodes = newHtmlDocument.DocumentNode.SelectNodes("//p");
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

