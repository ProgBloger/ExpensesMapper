using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;

namespace ExpensesMapper.Lib
{
    public class InputProcessor : IInputProcessor
    {
        private IInputParser _inputParser { get; }
        private ICategoriesParser _categoriesParser { get; }
        private IInputMapper _inputMapper { get; }

        public InputProcessor(
            IInputParser inputParser, 
            ICategoriesParser categoriesParser,
            IInputMapper inputMapper)
        {
            _inputParser = inputParser;
            _categoriesParser = categoriesParser;
            _inputMapper = inputMapper;
        }

        public (List<CategoryGroup> MappedExpenses, List<UnmappedExpense> UnmappedExpenses) Run()
        {
            var inputExpenses = _inputParser.ReadAllInputExpenses();
            var categoryMaps = _categoriesParser.ReadAllCategoryMaps();

            var result = _inputMapper.MapExpensesToCategories(inputExpenses, categoryMaps);

            return result;
        }
    }
}
