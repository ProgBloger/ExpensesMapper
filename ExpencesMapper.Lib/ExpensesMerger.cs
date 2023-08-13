using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;

namespace ExpensesMapper.Lib
{
    public class ExpensesMerger : IExpensesMerger
    {
        public List<CategoryGroup> MergeAndFilter(List<CategoryGroup> mappedExpenses, List<CategoryGroup> existingExpenses)
        {
            throw new NotImplementedException();
        }
    }
}
