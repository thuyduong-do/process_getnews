using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace process_loadXML
{ 
    class RSS_Analyzer
    {
        public static List<Newspaper> Loads(string url)
        {
            XDocument doc = XDocument.Load(url);
            return doc.Element("rss").Element("channel").Descendants("item").Select(item =>
            new Newspaper(
                item.Element("title")?.Value,
                item.Element("description")?.Value,
                item.Element("pubDate")?.Value,
                item.Element("link")?.Value 
                )
            ).ToList();
        }
      
    }
}
