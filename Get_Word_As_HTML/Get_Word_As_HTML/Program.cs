using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Get_Word_As_HTML
{

    class Program
    {
        
        public static void ConvertDocToHtml(object Sourcepath, object TargetPath)
        {
            Microsoft.Office.Interop.Word._Application newApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Documents d = newApp.Documents;
            object Unknown = Type.Missing;
            Microsoft.Office.Interop.Word.Document od = d.Open(ref Sourcepath, ReadOnly: false, Visible: true);
            object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;

            newApp.ActiveDocument.SaveAs(ref TargetPath, format);

            newApp.Documents.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
        }

        static void Main(string[] args)
        {
            String sourcePath = @"D:\Test";
            String targetPath = @"D:\Test1";
            //String targetPath = @"D:\Test1.htm";

            ConvertDocToHtml(sourcePath, targetPath);

            string html = System.IO.File.ReadAllText(targetPath + ".htm");
            Console.WriteLine(html);

            foreach (var process in Process.GetProcessesByName("WINWORD"))
                process.Kill();
        }
    }
}
