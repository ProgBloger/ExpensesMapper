namespace ExpensesMapper.Models
{
    public class Configuration
    {
        public string InputPath { get; }
        public string OutputPath { get; }

        public Configuration(string inputPath, string outputPath)
        {
            InputPath = inputPath;
            OutputPath = outputPath;
        }
    }
}
