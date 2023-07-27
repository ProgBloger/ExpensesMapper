using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IOuputWriter
    {
        void Write(List<CategoryGroup> mergedExpenses);
    }
}
