using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface IOuputReader
    {
        List<CategoryGroup> Read();
    }
}
