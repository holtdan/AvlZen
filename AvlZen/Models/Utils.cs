using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvlZen.Models
{
    public class Utils
    {
        public static string ExcelFileName
        {
            get
            {
                var dd = AppDomain.CurrentDomain.GetData("DataDirectory");
                var efn = System.Configuration.ConfigurationManager.AppSettings["ExcelFileName"];
                return dd + "\\" + efn;
            }
        }
    }
}