using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using Exporter;
using LibraryApp.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("Export/v1")]
    public class ExportController : ControllerBase
    {
        private readonly IDbContext _dbContext;

        public ExportController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ExportToExcel")]
        public IActionResult ExportToExcel()
        {
            List<LibraryApp.DataAccess.Item> items = _dbContext.Items.ToList();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    ExcelExporter exporter = new ExcelExporter(document);

                    exporter.AddItemsToSheet(items);
                    exporter.SaveDocument();
                }

                memoryStream.Position = 0;

                var contentDisposition = new System.Net.Mime.ContentDisposition
                {
                    FileName = "Items.xlsx",
                    Inline = false
                };

                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Items.xlsx");
            }
        }
    }
}