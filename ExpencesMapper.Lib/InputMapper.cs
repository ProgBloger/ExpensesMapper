using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;

namespace ExpensesMapper.Lib
{
    public class InputMapper : IInputMapper
    {
        public (List<CategoryGroup> mappedExpenses, List<UnmappedExpense> unmappedExpenses) MapExpensesToCategories(List<InputExpense> inputExpenses, List<CategoryMap> categoryMaps)
        {
            throw new NotImplementedException();
        }
    }
}
