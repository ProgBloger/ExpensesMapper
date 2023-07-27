using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IOutputProcessor
    {
        void Run(List<CategoryGroup> mappedExpenses, List<UnmappedExpense> unmappedExpenses);
    }
}
