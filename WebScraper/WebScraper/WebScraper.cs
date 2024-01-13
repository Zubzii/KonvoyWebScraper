using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack; //HTML parser, a tool designed to read and interpret HTML (HyperText Markup Language) documents. 
using System;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace WebScraper
{
    class WebScraper
    {
        static void Main()
    {
            KonvoyWebScraper.Run();
            NaavikDigestWebScraper.Run();
            EliteGameDeveloperWebScraper.Run();
    }
    }
}
