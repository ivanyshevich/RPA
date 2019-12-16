using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace Get_Regex_Matches
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpurRegex = "<p[\\S\\s]*?<\\/p>";
            //Regex regex = new Regex(@"<p[\S\s]*?<\/p>");
            string filePath = @"C:\Users\admin\Documents\RPA\DA15_Templates\FlexFond_test.htm";

            string htmlInput = System.IO.File.ReadAllText(filePath, Encoding.UTF8);

            var matches = Regex.Matches(htmlInput, inpurRegex).OfType<Match>().Select(m => m.Groups[0].Value).ToArray();

            DataTable table = new DataTable();
            table.Columns.Add("Matches", typeof(string));

            for (int i = 0; i < matches.Length; i++)
            {
                DataRow row = table.NewRow();
                row[0] = matches[i];
                table.Rows.Add(row);
            }

            //I've put breakpoint on Console.Writeline
            Console.WriteLine(table);
        }
    }
}
