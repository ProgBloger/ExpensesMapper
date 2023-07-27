using ExpensesMapper.Models;

namespace ExpensesMapper.Interfaces
{
    public interface ICategoriesParser
    {
        List<CategoryMap> ReadAllCategoryMaps();
    }
}
