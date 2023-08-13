using ExpensesMapper.Enums;
using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ExpensesMapper.Lib
{
    public class InputParser : IInputParser
    {
        private string _inputPath;

        public InputParser(Configuration conf)
        {
            _inputPath = conf.InputPath;
        }

        public List<InputExpense> ReadAllInputExpenses()
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, _inputPath);

            string[] files = Directory.GetFiles(directoryPath);
            List<InputExpense> inputExpenses = new List<InputExpense>();

            if (files.Length > 0)
            {
                string firstFile = files[0];

                using(var fileStream = new FileStream(firstFile, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook wb = new HSSFWorkbook(fileStream);
                    ISheet sheet = wb.GetSheetAt(0);

                    for(int rowNumber = 1; rowNumber <= sheet.LastRowNum; rowNumber++)
                    {
                        IRow row = sheet.GetRow(rowNumber);
                        var currencyValue = GetCellValue(row, PKOColumns.Currency);
                        var currency = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), currencyValue);
                        var amountValue = GetCellValue(row, PKOColumns.Amount);

                        decimal amount;
                        if (decimal.TryParse(amountValue, out amount))
                        {
                            InputExpense inputExpense = new InputExpense
                            {
                                OperationDate = GetCellValue(row, PKOColumns.OperationDate),
                                TransactionType = GetCellValue(row, PKOColumns.TransactionType),
                                Amount = amount,
                                Currency = currency,
                                RecipientName = GetCellValue(row, PKOColumns.RecipientName),
                                Description = GetCellValue(row, PKOColumns.Description),
                            };

                            inputExpenses.Add(inputExpense);
                        }
                    }
                }
            }
            // Move processed files to the processed folder
            // Get Unmatched Expenses

            return inputExpenses;
        }

        private static string GetCellValue(IRow row, PKOColumns column)
        {
            return row.GetCell((int)column).StringCellValue;
        }
    }
}
