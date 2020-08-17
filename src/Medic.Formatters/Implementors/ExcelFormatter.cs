using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Medic.Formatters.Contracts;
using Medic.Resources.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Medic.Formatters.Implementors
{
    public class ExcelFormatter : IExcelFormattable, IDisposable
    {
        private bool _isDisposed = false;

        private SpreadsheetDocument _spreadsheetDocument;
        private readonly WorkbookPart WorkbookPart;
        private readonly WorksheetPart WorksheetPart;
        private readonly SheetData SheetData;
        private readonly Sheets Sheets;

        private readonly Stream Stream;
        private readonly ILocalizationService Localization;

        private uint _sheetId = 1;

        public ExcelFormatter(Stream stream, ILocalizationService localization)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            Localization = localization ?? throw new ArgumentNullException(nameof(localization));

            _spreadsheetDocument = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

            WorkbookPart = _spreadsheetDocument.AddWorkbookPart();
            WorkbookPart.Workbook = new Workbook();

            WorksheetPart = WorkbookPart.AddNewPart<WorksheetPart>();
            SheetData = new SheetData();
            WorksheetPart.Worksheet = new Worksheet(SheetData);

            Sheets = WorkbookPart.Workbook.AppendChild(new Sheets());
        }

        public string MimeType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public async Task AddSheet<T>(IEnumerable<T> model, string sheetName) where T : class
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrWhiteSpace(sheetName))
            {
                throw new ArgumentException(nameof(sheetName));
            }

            await Task.Run(() =>
            {
                Sheet sheet = new Sheet()
                {
                    Id = WorkbookPart.GetIdOfPart(WorksheetPart),
                    SheetId = _sheetId++,
                    Name = sheetName
                };

                Sheets.AppendChild(sheet);

                Type type = typeof(T);

                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                Row headerRow = new Row();

                foreach (PropertyInfo property in properties)
                {
                    headerRow.AppendChild(new Cell()
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(Localization.Get(property.Name))
                    });
                }

                SheetData.AppendChild(headerRow);

                WorkbookPart.Workbook.Save();

                Type stringType = typeof(string);

                foreach (T value in model)
                {
                    Row row = new Row();

                    foreach (PropertyInfo property in properties)
                    {
                        object propertyValue = property.GetValue(value);

                        if (propertyValue is IEnumerable enumerable && propertyValue.GetType() != stringType)
                        {
                            string tempResult = string.Empty;

                            foreach (object childResult in enumerable)
                            {
                                if (childResult != null)
                                {
                                    tempResult += $"{childResult}, ";
                                }
                            }

                            propertyValue = tempResult.Length > 0 ? tempResult.Substring(0, tempResult.Length - 2) : tempResult;
                        }

                        Cell cell = new Cell()
                        {
                            CellValue = new CellValue(propertyValue?.ToString() ?? string.Empty)
                        };

                        if (propertyValue is long || propertyValue is ulong || propertyValue is double || propertyValue is decimal)
                        {
                            cell.DataType = CellValues.Number;
                        }
                        else if (propertyValue is DateTime)
                        {
                            cell.DataType = CellValues.Date;
                        }
                        else if (propertyValue is bool)
                        {
                            cell.DataType = CellValues.Boolean;
                        }
                        else
                        {
                            cell.DataType = CellValues.String;
                        }

                        row.AppendChild(cell);
                    }

                    SheetData.AppendChild(row);

                    WorkbookPart.Workbook.Save();
                }
            });
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _spreadsheetDocument.Dispose();
                _spreadsheetDocument = default;

                GC.SuppressFinalize(this);

                _isDisposed = !_isDisposed;
            }
        }

        public Stream Save()
        {
            _spreadsheetDocument.Close();

            return Stream;
        }
    }
}
