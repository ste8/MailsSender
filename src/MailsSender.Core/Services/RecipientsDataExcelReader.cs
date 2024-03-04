using MailsSender.Core.Entities;
using MailsSender.Core.Helpers;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MailsSender.Core.Services
{
    public class RecipientsDataExcelReader
    {
        public RecipientsData Read(string excelFilePath)
        {
            var workbook = new XSSFWorkbook(new FileInfo(excelFilePath));
            var sheet = workbook.GetSheetAt(0);
            var headers = ReadHeaders(sheet);
            var recipientsData = ReadRows(sheet, headers);
            workbook.Close();
            return recipientsData;
        }

        private string[] ReadHeaders(ISheet sheet)
        {
            var headers = new List<string>();
            var row = sheet.GetRow(0);
            int colIndex = 0;
            while (true) {
                var value = GetCellAsString(row, colIndex);
                if (value == null) break;
                headers.Add(value);
                colIndex++;
            }
            return headers.ToArray();
        }

        private RecipientsData ReadRows(ISheet sheet, string[] headers)
        {
            var recipientsData = new RecipientsData();
            int rowCount = sheet.LastRowNum;
            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++) {
                var currentRow = sheet.GetRow(rowIndex);
                if (currentRow == null) break;
                var recipientData = ReadRecipient(sheet, currentRow, headers);
                recipientsData.Add(recipientData);  
            }
            return recipientsData;
        }

        private dynamic ReadRecipient(ISheet sheet, IRow row, string[] headers)
        {
            var values = new Dictionary<string, string?>();

            for (int colIndex = 0; colIndex < headers.Length; colIndex++) {
                var value = GetCellAsString(row, colIndex);
                values.Add(headers[colIndex], value);
            }

            var recipientData = DynamicHelper.ToDynamic(values);
            return recipientData;
        }

        

        private string? GetCellAsString(IRow row, int colIndex)
        {
            var cell = row.GetCell(colIndex);
            if (cell == null) return null;
            var value = cell.StringCellValue.Trim();
            return value;
        }
    }
}
