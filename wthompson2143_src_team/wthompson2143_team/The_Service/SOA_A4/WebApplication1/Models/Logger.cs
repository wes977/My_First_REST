/*
 * Project Name :       SOA A4
 * Project Author :     Wes Thompson, Jen Klimova, Niels Lindeboom and Alex Martin
 * Date :               November 10, 2016.
 * Description :        The purpose of this assignment is to give practice at creating and calling a RESTful web-service.
 *                      The service mimics an online shopping website.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication1.Models
{
    /*
     * Class Name :     Logger
     * Description :    The logger class is responsible to take an action that was performed
     *                  by the service and record it along with the time of the action in the
     *                  log file.
     */

    public class Logger
    {
        public void Log(string action)
        {
            string path = @"C:\Users\wthompson2143\Desktop\logger.txt";
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now + " : " + action);
            }
        }
    }
}