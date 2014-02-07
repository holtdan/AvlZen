using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AvlZen.Tests
{
    [TestClass]
    public class Parsing
    {
        const string _path = @"c:\users\daniel holt\documents\visual studio 2013\Projects\AvlZen\AvlZen\App_Data\AvlZen.xlsx";

        [TestMethod]
        public void GrokPlaces()
        {
            var output = AvlZen.Model.ExcelReader.GetPlaces(_path);
        }
        [TestMethod]
        public void GrokExcel()
        {
            AvlZen.Model.ExcelReader.GrokExcel(_path);
        }
        [TestMethod]
        public void GetDayWeeklies()
        {
            AvlZen.Model.ExcelReader.GetDayWeeklies(_path, "Tuesday", "AvlComYog", "WstAvlYog");
        }
    }
}
