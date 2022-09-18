using System.Linq;
using TNBase.External.DataImport;
using TNBase.Repository;
using Xunit;

namespace TNBase.External.Tests.DataImport
{
    public class CsvImportServiceTests
    {
        [Fact]
        public void ImportListeners_ShouldThrowInvalidDataException_WhenNoData()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"";

            Assert.Throws<InvalidImportDataException>(() =>
                service.ImportListeners(importData)
            );
        }

        [Fact]
        public void ImportListeners_ShouldDoNothing_WhenNoRecords()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname";

            service.ImportListeners(importData);

            Assert.Empty(context.Listeners);
        }

        [Fact]
        public void ImportListeners_ShouldCreateListener_WhenContainsSingleRecord()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker";

            service.ImportListeners(importData);

            Assert.Single(context.Listeners);
        }

        [Fact]
        public void ImportListeners_ShouldCreateMultipleListeners_WhenContainsMultipleRecords()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,Tom,Shaw
3,Fred,Gray";

            service.ImportListeners(importData);

            Assert.Equal(3, context.Listeners.Count());
        }

        [Fact]
        public void ImportListeners_ShouldRequireForename()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,,Shaw
3,Fred,Gray";

            var result = service.ImportListeners(importData);

            var faildedRecords = result.Records.Where(x=> x.HasError).ToList();
            Assert.Single(faildedRecords);
            Assert.Equal(3, faildedRecords.First().Row);
            Assert.Equal("Forename", faildedRecords.First().Error.FieldName);
            Assert.Equal("Forename is required", faildedRecords.First().Error.ErrorMessage);
        }
    }
}
