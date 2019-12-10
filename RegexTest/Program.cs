using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data;
using HtmlAgilityPack;


namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex1 = new Regex(@"\.{0,}#AfkastPercantage[\d]{4}");
            Regex regex2 = new Regex(@"\.{0,}#Afkast[\d]{4}");

            string filePath = @"C:\Users\admin\Documents\RPA\DA15_Templates\Markedsrente.htm";
            string text = System.IO.File.ReadAllText(filePath, Encoding.Default);

            //DataTable table = new DataTable();
            //table.Columns.Add("1", typeof(string));
            //table.Columns.Add("2", typeof(string));

            //for (int i = 0; i<4; i++)
            //{
            //    DataRow row = table.NewRow();
            //    row["1"] = "qw";
            //    row["2"] = "er";
            //    table.Rows.Add(row);
            //}

            //int rowsCount = table.Rows.Count;
            //int columnsCount = table.Columns.Count;
            //Console.WriteLine(rowsCount + " " + columnsCount);

            foreach (Match match in regex1.Matches(text))
            {
                text = text.Replace(match.Value, "rigjorih");
            }

            foreach (Match match in regex2.Matches(text))
            {
                text = text.Replace(match.Value, "adcsdvds");
            }

            //Console.WriteLine(text);

            //System.IO.File.WriteAllText(@"C:\path.txt", text, Encoding.Default);
        }
    }
}
