using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Virtual_Keyboard.Scripts.Misc
{
    public class Print : MonoBehaviour
    {
        private const string ImagePath = "C:/Users/Sokratis/Desktop/b.jpg";
        private const string Path = "C:/Users/Sokratis/Desktop/test.txt";

        public void GenerateFile()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
            File.WriteAllText(Path, "hello");
        }

        public void PrintFiles()
        {
            if (!File.Exists(Path)) return;
              
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
        }
    }
}