using ExpensesMapper.Models;

namespace ExpensesMapper.Lib
{
    public class UnmachedExpensesWriter : IUnmachedExpensesWriter
    {
        public void Write(List<UnmappedExpense> unmappedExpenses)
        {
            throw new NotImplementedException();
        }
    }
}
