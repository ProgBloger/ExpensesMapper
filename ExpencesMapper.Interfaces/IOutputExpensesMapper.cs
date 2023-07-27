using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IExpensesMerger
    {
        List<CategoryGroup> MergeAndFilter(List<CategoryGroup> mappedExpenses, List<CategoryGroup> existingExpenses);
    }
}