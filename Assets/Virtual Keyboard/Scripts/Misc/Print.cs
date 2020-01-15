using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using UnityEngine;

public class Print : MonoBehaviour
{
    const string filePath = "C:/Users/Sokratis/Desktop";
    const string imagePath = "C:/Users/Sokratis/Desktop";
    string path = filePath + "/pdf.pdf";

    private void Start()
    {
        // GenerateFile();
    }

    public void GenerateFile()
    {
        if (File.Exists(path))
            File.Delete(path);

        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            var writer = PdfWriter.GetInstance(document, fileStream);

            try
            {
                document.Open();
                document.Add(new Paragraph("This is the header"));
                iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(imagePath + "/Virtual Keyboard.png");
                png.ScalePercent(24f); //convert to 300 dpi
                document.Add(png);
                document.Add(new Paragraph("This is the body"));
            }
            catch (DocumentException dex) { throw (dex); }
            catch (IOException ioex) { throw (ioex); }
            finally { document.Close(); writer.Close(); }

        }
        // PrintFiles();
    }

    void PrintFiles()
    {
        Debug.Log(path);
        if (path == null)
            return;

        if (File.Exists(path))
        {
            Debug.Log("file found");
        }
        else
        {
            Debug.Log("file not found");
            return;
        }
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = path;
        //process.StartInfo.Verb = "print";

        process.Start();
        print("show'em");
        //process.WaitForExit();
    }
}
