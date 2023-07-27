using ExpensesMapper.Models;

namespace ExpensesMapper.Lib
{
    public interface IUnmachedExpensesWriter
    {
        void Write(List<UnmappedExpense> unmappedExpenses);
    }
}