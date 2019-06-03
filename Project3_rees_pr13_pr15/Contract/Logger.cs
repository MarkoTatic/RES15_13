using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logger
    {
        public static string WriteToLogFile(string text, string path)
        {
            string line = text + Environment.NewLine;
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Log path not found on local disk: {0}", e.Message);
                Console.ReadKey();
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(line);
                writer.Flush();
            }

            return line;
        }
    }
}
