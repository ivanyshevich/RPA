using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace RegexParagraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex1 = new Regex(@"<p[\S\s]*?<\/p>");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string filePath = @"C:\Users\admin\Documents\RPA\DA15_Templates\FlexFond_test.htm";
            string writePath = @"C:\Users\admin\Documents\RPA\DA15_Templates\paragraph.htm";
            string htmlInput = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
            string paragraphIdentifier = "Skal kun";

            //var trimedHTML = Regex.Replace(htmlInput, @"(?<=>)\s*", ""Console.WriteLine(paragraph);, RegexOptions.Singleline);
            //System.IO.File.WriteAllText(writePath, trimedHTML, Encoding.Unicode);

            var matches = Regex.Matches(htmlInput, @"<p[\S\s]*?<\/p>").OfType<Match>().Select(m => m.Groups[0].Value).ToArray();
            

            string paragraph = "";
            string emptyNewLine = "";
            var emptyLineIndex = 0;
            for (int i = 0; i < matches.Length; i++)
            {
                if (matches[i].Contains(paragraphIdentifier))
                {
                    string start = "";
                    string end = "";
                    //paragraph = matches[i] + "\n\n        " + matches[i + 1];
                    start = matches[i];
                    end = matches[i + 1];
                    var empty = Regex.Matches(htmlInput, "2017, 2018");
                    Console.WriteLine(empty.Count);
                    //emptyNewLine = matches[i + 1];
                    //emptyLineIndex = i + 1;
                    //Console.WriteLine(matches[i]);
                }
            }
            if (htmlInput.Contains(paragraph))
            {
                Console.WriteLine("fjkf");
            }
            htmlInput = htmlInput.Replace(paragraph, "");

            System.IO.File.WriteAllText(writePath, paragraph, Encoding.UTF8);

            //Console.WriteLine(htmlInput);
            //System.IO.File.WriteAllText(writePath, htmlInput, Encoding.GetEncoding("windows-1251"));
            //Console.WriteLine(paragraph);
        }
    }
}
