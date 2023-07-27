using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IInputMapper
    {
        (List<CategoryGroup> mappedExpenses, List<UnmappedExpense> unmappedExpenses) MapExpensesToCategories(List<InputExpense> inputExpenses, List<CategoryMap> categoryMaps);
    }
}
