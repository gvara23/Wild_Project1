using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Project1
{
    public static class Logger
    {
        public static void Log(string message, string logFileName)
        {
            string logFilePath = $"{logFileName}.log";
            string logMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}";

            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(logMessage);
            }
        }
    }
}
