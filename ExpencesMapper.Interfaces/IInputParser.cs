using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IInputParser
    {
        List<InputExpense> ReadAllInputExpenses();
    }
}
