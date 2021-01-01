using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using ResumeBuilder.connectors;

namespace ResumeBuilder
{
    public class Log
    {
        static string LogFileDirectory = ConfigurationSettings.AppSettings["LogFileDirectory"].ToString().Trim();

        internal static void LogError(string ErrorMessage, string ErrorStackTrace, string ClassMethodName, string ErrorCode, string CurrentID, string PageName)
        {

            string desc = CLOVA.DBErrorLog(ErrorMessage, ErrorStackTrace, ClassMethodName, ErrorCode, CurrentID, PageName);
            if (!desc.ToLower().Contains("success"))
            {
                FileLogError(ErrorMessage, ErrorStackTrace, ClassMethodName, ErrorCode, CurrentID, PageName);
            }
        }

        internal static void FileLogError(string ErrorMessage, string ErrorStackTrace, string ClassMethodName, string ErrorCode, string CurrentID, string PageName)
        {
            StreamWriter sw = null;
            try
            {
                if (!Directory.Exists(LogFileDirectory))
                {
                    Directory.CreateDirectory(LogFileDirectory);
                }
                 sw = new StreamWriter(LogFileDirectory + "ResumeBuilder_ErrorLog.txt", true);
                

                string date = System.DateTime.Now.ToString();

                sw.WriteLine("Date          : " + date);
                sw.WriteLine("ErrorCode     : " + ErrorCode);
                sw.WriteLine("Login ID        : " + CurrentID);
                sw.WriteLine("Method/Module : " + ClassMethodName);
                sw.WriteLine("Page Name   : " + PageName);
                sw.WriteLine("Error         : " + ErrorMessage);
                sw.WriteLine("Error Trace   : " + Regex.Replace(ErrorStackTrace, @"\t|\n|\r", " "));
                sw.WriteLine("======================================================================================");
                sw.Flush();
                //sw.Close();


            }
            catch (Exception ex)
            {
            }
            finally
            {
                System.Threading.Monitor.Exit(sw);
            }
        }

        }
}
