using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;


namespace RegexParagraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex1 = new Regex(@"<p[\S\s]*?<\/p>");

            string filePath = @"C:\Users\admin\Documents\RPA\DA15_Templates\FlexFond.htm";
            string text = System.IO.File.ReadAllText(filePath, Encoding.Default);
            string paragraphIdentifier = "Skal kun";

            var matches = Regex.Matches(text, @"<p[\S\s]*?<\/p>").OfType<Match>().Select(m => m.Groups[0].Value).ToArray();

            string paragraphWithNewLine = "";

            //Console.WriteLine(matches[9]);

            for (int i = 0; i < matches.Length; i++)
            {
                if (matches[i].Contains(paragraphIdentifier))
                    paragraphWithNewLine = matches[i] + matches[i + 1];

            }

            Console.WriteLine(paragraphWithNewLine);

        }
    }
}
