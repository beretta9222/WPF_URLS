using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Urls.Model
{
    public static class Log
    {
        /// <summary>
        /// static constructor
        /// </summary>
        static Log() { }
        /// <summary>
        /// write to log file
        /// </summary>
        /// <param name="str">Error to write</param>
        public static void WriteLod(string str)
        {
            try
            {
                string fileName = "log.txt";
                using (StreamWriter sw = new StreamWriter(File.Open(fileName, FileMode.Append)))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss; err:") + str);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
           
        }
    }
}
