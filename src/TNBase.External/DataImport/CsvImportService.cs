using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase.External.DataImport
{
    public class CsvImportService
    {
        private readonly ITNBaseContext context;

        public CsvImportService(ITNBaseContext context)
        {
            this.context = context;
        }

        public ImportResult ImportListeners(string importData)
        {
            if (string.IsNullOrWhiteSpace(importData))
            {
                throw new InvalidImportDataException("Header is missing");
            }

            var resultItems = new Dictionary<int, ImportResultItem>();

            var dataReader = new StringReader(importData);

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ReadingExceptionOccurred = c =>
                {
                    var resultItem = resultItems[c.Exception.Context.Parser.Row];
                    if (c.Exception.InnerException is FieldValidationException validationException)
                    {
                        resultItem.SetError(validationException.FieldName, validationException.Message, c.Exception.Context.Parser.RawRecord);
                    }
                    return false;
                }
            };

            var isDirty = false;
            using var csv = new CsvReader(dataReader, configuration);
            csv.Context.RegisterClassMap<ListenerCsvMap>();

            csv.Read();
            csv.ReadHeader();
            csv.ValidateHeader<Listener>();

            //progress?.Report(new ImportExportProgressReport("header is valid"));

            while (csv.Read())
            {
                resultItems.Add(csv.Parser.Row, new ImportResultItem(csv.Parser.Row));
                //progress?.Report(new ImportExportProgressReport($"line {csv.Context.Row}: {csv.Context.RawRecord.Replace(Environment.NewLine, "")}"));
                var listener = csv.GetRecord<Listener>();
                if (listener != null)
                {
                    context.Listeners.Add(listener);
                    isDirty = true;
                }
                //progress?.Report(new ImportExportProgressReport($"entry found: Name '{record.Name}' ComponentIdentifier '{record.ComponentIdentifier}' PosX '{record.PosX}' PosY '{record.Posy}' Rotation '{record.Rotation}'"));
            }

            if (isDirty)
            {
                context.SaveChanges();
            }

            return new ImportResult { Records = resultItems.Values };
        }
    }
}
