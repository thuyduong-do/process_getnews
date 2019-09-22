using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace process_loadXML
{
    class Newspaper
    {
        string title;
        string description;
        string publicdate;
        string link;
       

        public Newspaper(string title, string description, string publicdate, string link)
        {
            this.title = title;
            this.description = description;
            this.publicdate = publicdate;
            this.link = link;     
        }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Publicdate { get => publicdate; set => publicdate = value; }
        public string Link { get => link; set => link = value; }
    
    }
}
