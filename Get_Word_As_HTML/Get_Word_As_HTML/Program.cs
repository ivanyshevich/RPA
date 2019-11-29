using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Word = Microsoft.Office.Interop.Word;

namespace Get_Word_As_HTML
{

    class Program
    {
        
        public static void ConvertDocToHtml(object Sourcepath, object TargetPath)
        {
            Word._Application newApp = new Word.Application();
            Word.Documents d = newApp.Documents;
            object Unknown = Type.Missing;
            Word.Document od = d.Open(ref Sourcepath, ReadOnly: false, Visible: true);
            object format = Word.WdSaveFormat.wdFormatHTML;

            newApp.ActiveDocument.SaveAs(ref TargetPath, format);

            newApp.Documents.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
        }

        static void Main(string[] args)
        {
            String sourcePath = @"D:\Test";
            String targetPath = @"D:\Test1";
            //String targetPath = @"D:\Test1.htm";

            ConvertDocToHtml(sourcePath, targetPath);

            //string html = System.IO.File.ReadAllText(targetPath);
            //Console.WriteLine(html);

            foreach (var process in Process.GetProcessesByName("WINWORD"))
                process.Kill();
        }
    }
}
