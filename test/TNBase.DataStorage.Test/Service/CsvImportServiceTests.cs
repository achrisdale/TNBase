using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNBase.DataStorage.Service;

namespace TNBase.DataStorage.Test.Service
{
    [TestClass]
    public class CsvImportServiceTests
    {
        [TestMethod]
        public async Task ImportListeners_ShouldCreateListener_WhenContainsSingleRecord()
        {
            var service = new CsvImportService();

            var result = service.ImportListeners();

            Assert.IsNotNull(result);
        }
    }
}
