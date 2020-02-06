using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Virtual_Keyboard.Scripts.Misc
{
    public class Print : MonoBehaviour
    {
        private const string ImagePath = "C:/Users/Sokratis/Desktop/b.jpg";
        private const string Path = "C:/Users/Sokratis/Desktop/test.txt";

        public void GenerateFile()
        {
            if (File.Exists(Path))
                File.Delete(Path);

            using (var fileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                var writer = PdfWriter.GetInstance(document, fileStream);

                try
                {
                    document.Open();
                    document.Add(new Paragraph("This is the header"));
                    var png = Image.GetInstance(ImagePath);
                    png.ScalePercent(24f); //convert to 300 dpi
                    document.Add(png);
                    document.Add(new Paragraph("This is the body"));
                }
                catch (DocumentException)
                {
                }
                catch (IOException)
                {
                }
                finally
                {
                    document.Close();
                    writer.Close();
                }
            }

            PrintFiles();
        }

        public void PrintFiles()
        {
            Debug.Log(Path);

            if (File.Exists(Path))
            {
                Debug.Log("file found");
            }
            else
            {
                Debug.Log("file not found");
                return;
            }
            
            var startInfo = new ProcessStartInfo(Path);
            foreach (var verb in startInfo.Verbs)
            {
                print(verb);
            }
            var process = new Process
            {
                StartInfo =
                {
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Normal,
                    UseShellExecute = true,
                    FileName = Path,
                    Verb = "Print"
                }
            };

            process.Start();
            //process.WaitForExit();
        }
    }
}