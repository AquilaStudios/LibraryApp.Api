using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;

namespace Exporter
{
    public class ExcelExporter
    {
        private readonly SpreadsheetDocument _document;
        private readonly WorkbookPart _workbookPart;
        private readonly WorksheetPart _worksheetPart;
        private readonly SheetData _sheetData;

        public ExcelExporter(SpreadsheetDocument document)
        {
            _document = document;
            _workbookPart = _document.AddWorkbookPart();
            _workbookPart.Workbook = new Workbook();

            var sheetId = 1U;
            var sheetName = "Sheet" + sheetId;

            var worksheetPart = _workbookPart.AddNewPart<WorksheetPart>();
            _worksheetPart = worksheetPart;
            _worksheetPart.Worksheet = new Worksheet();
            _sheetData = new SheetData();

            _worksheetPart.Worksheet.AppendChild(_sheetData);

            var sheets = _workbookPart.Workbook.AppendChild(new Sheets());
            sheets.AppendChild(new Sheet { Id = _workbookPart.GetIdOfPart(_worksheetPart), SheetId = sheetId, Name = sheetName });
        }

        public void AddItemsToSheet(List<LibraryApp.DataAccess.Item> items)
        {
            Row headerRow = new Row();
            headerRow.Append(new Cell(new InlineString(new Text("Title"))));
            headerRow.Append(new Cell(new InlineString(new Text("Publication Date"))));


            _sheetData.AppendChild(headerRow);


            foreach (var item in items)
            {
                Row row = new Row();
                row.Append(new Cell(new InlineString(new Text(item.Title))));
                row.Append(new Cell(new InlineString(new Text(item.PublicationDate.ToString()))));

                _sheetData.AppendChild(row);
            }
        }

        public void SaveDocument()
        {
            _worksheetPart.Worksheet.Save();

            _workbookPart.Workbook.Save();

            _document.Close();
        }
    }
}