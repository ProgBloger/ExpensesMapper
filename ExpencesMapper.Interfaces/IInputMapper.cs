using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IInputMapper
    {
        (List<CategoryGroup> MappedExpenses, List<UnmappedExpense> UnmappedExpenses) MapExpensesToCategories(List<InputExpense> inputExpenses, List<CategoryMap> categoryMaps);
    }
}
