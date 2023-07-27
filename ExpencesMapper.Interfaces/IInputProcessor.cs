using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IInputProcessor
    {
        public (List<CategoryGroup> MappedExpenses, List<UnmappedExpense> UnmappedExpenses) Run();
    }
}
