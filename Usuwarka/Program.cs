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
            try
            {
                StreamReader myReader = new StreamReader("Directories.txt");
                string line = "";

                while (line != null)
                {
                    line = myReader.ReadLine();
                    if (line != null)
                    {
                        //Console.WriteLine(line);
                        string[] files = Directory.GetFiles(line);

                        foreach (string file in files)
                        {
                            Console.WriteLine(file);
                            FileInfo fi = new FileInfo(file);
                            if (fi.LastWriteTime < DateTime.Now.AddDays(-30))
                            {
                                try
                                {
                                    FileStream fs = new FileStream(scriptStartTime + "_LogFile.txt", FileMode.Append, FileAccess.Write);
                                    StreamWriter sw = new StreamWriter(fs);
                                    string logline = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + file;
                                    Console.WriteLine(logline);
                                    sw.WriteLine(logline);
                                    sw.Close();
                                } 
                                catch (Exception e1)
                                {
                                    Console.WriteLine("Something didn't quite work correctly: {0}", e1.Message);
                                }
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
            Console.ReadKey();
        }
    }
}
