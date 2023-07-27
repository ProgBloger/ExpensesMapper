using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;

namespace ExpensesMapper.Lib
{
    public class OutputProcessor : IOutputProcessor
    {
        private IExpensesMerger _ExpensesMerger { get; }
        private IUnmachedExpensesWriter _unmachedExpensesWriter { get; }
        private IOuputReader _outputReader { get; }
        private IOuputWriter _outputWriter { get; }

        public OutputProcessor(
            IExpensesMerger expensesMerger,
            IUnmachedExpensesWriter unmachedExpensesWriter,
            IOuputReader outputReader,
            IOuputWriter outputWriter)
        {
            _ExpensesMerger = expensesMerger;
            _unmachedExpensesWriter = unmachedExpensesWriter;
            _outputReader = outputReader;
            _outputWriter = outputWriter;
        }

        public void Run(List<CategoryGroup> mappedExpenses, List<UnmappedExpense> unmappedExpenses)
        {
            MergeMappedExpenses(mappedExpenses);
            StoreUnmappedExpenses(unmappedExpenses);
        }

        private void MergeMappedExpenses(List<CategoryGroup> mappedExpenses)
        {
            // Get existing Expenses from output
            var existingExpenses = _outputReader.Read();

            // Merge
            // Look what changed and return changes only
            var mergedExpenses = _ExpensesMerger.MergeAndFilter(mappedExpenses, existingExpenses);

            // Write down new values
            _outputWriter.Write(mergedExpenses);
        }

        private void StoreUnmappedExpenses(List<UnmappedExpense> unmappedExpenses)
        {
            // Concatenate Unmapped Expenses
            _unmachedExpensesWriter.Write(unmappedExpenses);
        }
    }
}
