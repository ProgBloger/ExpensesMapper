namespace ExpensesMapper.Models
{
    public class Configuration
    {
        public string InputPath { get; }
        public string OutputPath { get; }
        public string CategoriesInputPath { get; }

        public Configuration(string inputPath, string outputPath, string categoriesInputPath)
        {
            InputPath = inputPath;
            OutputPath = outputPath;
            CategoriesInputPath = categoriesInputPath;
        }
    }
}
