using ExpensesMapper.Enums;
using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace ExpensesMapper.Lib
{
    public class CategoriesParser : ICategoriesParser
    {
        public string _categoriesPath;

        private static string GetCellValue(IRow row, MapProperties property) =>
            row.GetCell((int)property)?.ToString();

        public CategoriesParser(Configuration conf)
        {
            _categoriesPath = conf.CategoriesInputPath;
        }

        public List<CategoryMap> ReadAllCategoryMaps()
        {
            var categoryMaps = new List<CategoryMap>();

            string filePath = Path.Combine(Environment.CurrentDirectory, _categoriesPath);

            // TODO: Add file creation
            if (!File.Exists(filePath))
            {
                CreateDefaultEmptyFile(filePath);

                // Return empty list as the file is newly created
                return categoryMaps;
            }

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0); // Get the first sheet

                // Iterate through the rows in the sheet
                for (int rowIdx = 1; rowIdx <= sheet.LastRowNum; rowIdx++) // Start from 1 to skip header
                {
                    IRow row = sheet.GetRow(rowIdx);
                    if (row == null) continue;

                    // Read the values from the cells using the GetCellValue function
                    string categoryGroup = GetCellValue(row, MapProperties.CategoryGroup);
                    string category = GetCellValue(row, MapProperties.Category);
                    string regex = GetCellValue(row, MapProperties.Regex);

                    // Construct the CategoryMap object and add it to the list
                    var categoryMap = new CategoryMap(categoryGroup, category, regex);
                    categoryMaps.Add(categoryMap);
                }
            }

            return categoryMaps;
        }

        private static void CreateDefaultEmptyFile(string filePath)
        {
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Category Maps");
                IRow headerRow = sheet.CreateRow(0);

                // Adding headers
                headerRow.CreateCell((int)MapProperties.CategoryGroup).SetCellValue("Category Group");
                headerRow.CreateCell((int)MapProperties.Category).SetCellValue("Category");
                headerRow.CreateCell((int)MapProperties.Regex).SetCellValue("Regex");

                workbook.Write(file);
            }
        }
    }
}