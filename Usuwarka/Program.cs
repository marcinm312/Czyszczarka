using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Usuwarka
{
    class Program
    {
        static void Main(string[] args)
        {
            string scriptStartTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            int days = 1000000;
            try
            {
                //Pobranie liczby dni z pliku
                StreamReader myReader2 = new StreamReader("Days.txt");
                string line2 = "";
                while (line2 != null)
                {
                    line2 = myReader2.ReadLine();
                    if (line2 != null)
                    {
                        days = Int32.Parse(line2);
                    }
                }

                //Odczytywanie z pliku tekstowego ścieżek i usuwanie plików
                StreamReader myReader = new StreamReader("Directories.txt");
                string line = "";

                while (line != null)
                {
                    line = myReader.ReadLine();
                    if (line != null)
                    {
                        string[] files = Directory.GetFiles(line);
                        foreach (string file in files)
                        {
                            FileInfo fi = new FileInfo(file);
                            //Sprawdzam czy plik jest starszy niż ilość dni zdefiniowana w pliku
                            if (fi.LastWriteTime < DateTime.Now.AddDays(-days))
                            {
                                try
                                {
                                    //Zapisuję do logów ścieżkę usuniętego pliku
                                    FileStream fs = new FileStream(scriptStartTime + "_LogFile.txt", FileMode.Append, FileAccess.Write);
                                    StreamWriter sw = new StreamWriter(fs);
                                    string logline = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Data pliku: " + fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss") + " " + file;
                                    Console.WriteLine(logline);
                                    sw.WriteLine(logline);
                                    sw.Close();
                                }
                                catch (Exception e1)
                                {
                                    Console.WriteLine("Something didn't quite work correctly: {0}", e1.Message);
                                }
                                //Usunięcie pliku
                                fi.Delete();
                            }
                        }
                    }
                }
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something didn't quite work correctly: {0}", e.Message);
            }
            //Console.ReadKey();
        }
    }
}
