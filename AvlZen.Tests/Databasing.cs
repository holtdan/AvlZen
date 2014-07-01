using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvlZen.Tests
{
    [TestClass]
    public class Databasing
    {
        [TestMethod]
        public void GetPlaces()
        {
            var output = AvlZen.Model.DbReader.GetPlaces();
        }
    }
}
