using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace process_loadXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Process openfile = new Process();
            //    string userinput = Console.ReadLine();
            //    openfile.StartInfo.FileName = userinput;//"notepad.exe"; // exe vi no la chuong trinh
            //    //openfile.StartInfo.Arguments = userinput;
            //    openfile.StartInfo.UseShellExecute = false;
            //    openfile.StartInfo.RedirectStandardOutput = true;
            //    openfile.StartInfo.CreateNoWindow = true;

            //    openfile.Start();
            //    string results = openfile.StandardOutput.ReadToEnd();
            //    openfile.WaitForExit();
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("file doesnt exist");
            //}
            //Process openfile = new Process();


            ////openfile.StartInfo.FileName = "/C code.exe";//"notepad.exe"; // exe vi no la chuong trinh
            ////                                        //openfile.StartInfo.Arguments = userinput;
            ////openfile.StartInfo.UseShellExecute = false;
            //////openfile.StartInfo.RedirectStandardOutput = true;
            //////openfile.StartInfo.CreateNoWindow = true;

            //openfile.StartInfo.FileName = "cmd.exe";
            //openfile.StartInfo.Arguments = $"/C \"code .\""; // mo visual studio code
            //openfile.StartInfo.UseShellExecute = false;
            //openfile.StartInfo.RedirectStandardOutput = true;
            //openfile.StartInfo.CreateNoWindow = true;
            //openfile.Start();
            //-----------------------------------------------------------------------



            // open web pages
            //string[] sources = {
            //"http://feeds.bbci.co.uk/news/world/rss.xml?edition=uk",
            //"http://rss.cnn.com/rss/edition_world.rss"};
            //for (int i = 0; i < sources.Length; i++)
            //{

            //    Process openfile = new Process();
            //    openfile.StartInfo.FileName = sources[i];  
            //    openfile.Start();
            //}

            // ----------------------------------------------------------------------
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("input a key word please");
            string userinput = Console.ReadLine();
            List<Newspaper> newspapers = RSS_Analyzer.Loads(@"https://vnexpress.net/rss/tin-moi-nhat.rss");
            
            var newspaperContainsKeywords = newspapers.Where(newspaper => newspaper.Title.ToLower().Contains(userinput) && newspaper.Description.ToLower().Contains(userinput));

            if (newspaperContainsKeywords.Any())
            {
                foreach (var item in newspaperContainsKeywords)
                {
                    Console.WriteLine(item.Title);
                }
                Console.WriteLine("Do you want to load the pages?");
                string ans = Console.ReadLine();
                if (ans.ToLower().Contains("y"))
                {
                    foreach (var newspaper in newspaperContainsKeywords)
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = newspaper.Link; // mo link tren rss
                        process.Start();
                    }
                }
                else
                {
                    Console.WriteLine("OK");
                }

            }
            else
            {
                Console.WriteLine("The rss not available at the moment");
            }

            
            Console.ReadLine();
        }
    }
}
