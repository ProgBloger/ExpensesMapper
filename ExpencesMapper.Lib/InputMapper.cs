using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;
using System.Text.RegularExpressions;

namespace ExpensesMapper.Lib
{
    public class InputMapper : IInputMapper
    {
        public (List<CategoryGroup> MappedExpenses, List<UnmappedExpense> UnmappedExpenses) MapExpensesToCategories(List<InputExpense> inputExpenses, List<CategoryMap> categoryMaps)
        {
            var MappedExpenses = new List<CategoryGroup>();
            var UnmappedExpenses = new List<UnmappedExpense>();

            // For each input find a mapper that fits
            foreach (var expense in inputExpenses)
            {
                bool mapperFound = false;
                foreach (var categoryMap in categoryMaps)
                {
                    MatchCollection matches = categoryMap.Matches(expense);
                    if (matches.Count > 0)
                    {
                        mapperFound = true;

                        AddMappedExpense(MappedExpenses, expense, categoryMap);

                        break;
                    }
                }

                if (!mapperFound)
                {
                    UnmappedExpenses.Add(new UnmappedExpense(expense));
                }
            }

            return (MappedExpenses, UnmappedExpenses);
        }

        private void AddMappedExpense(List<CategoryGroup> MappedExpenses, InputExpense expense, CategoryMap categoryMap)
        {
            var categoryGroupName = categoryMap.CategoryGroupName;
            var categoryGroup = MappedExpenses.FirstOrDefault(cg => cg.Name == categoryGroupName);

            // If there is a CategoryGroup of that type already in the list
            if (categoryGroup != null)
            {
                AddExpenseToCategoryGroup(expense, categoryMap, categoryGroup);
            }
            // Else create a new CategoryGroup for the mapped Expense
            else
            {
                CreateCategoryGroupAndAddExpense(MappedExpenses, expense, categoryMap, categoryGroupName);
            }
        }

        private void AddExpenseToCategoryGroup(InputExpense expense, CategoryMap categoryMap, CategoryGroup? categoryGroup)
        {
            var categoryName = categoryMap.CategoryName;
            categoryGroup.AddExpense(categoryName, expense.Amount);
        }

        private void CreateCategoryGroupAndAddExpense(List<CategoryGroup> MappedExpenses, InputExpense expense, CategoryMap categoryMap, string categoryGroupName)
        {
            var newCategoryGroup = new CategoryGroup(categoryGroupName);
            MappedExpenses.Add(newCategoryGroup);

            var categoryName = categoryMap.CategoryName;
            newCategoryGroup.AddExpense(categoryName, expense.Amount);
        }
    }
}
