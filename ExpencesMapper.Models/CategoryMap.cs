using System.Text.RegularExpressions;

namespace ExpensesMapper.Models
{
    public class CategoryMap
    {
        public string CategoryGroupName { get; set; }
        public string CategoryName { get; }
        public Regex Regex { get; }

        public CategoryMap(string categoryGroup, string category, string regex)
        {
            CategoryGroupName = categoryGroup;
            CategoryName = category;
            Regex = new Regex(regex);
        }

        public MatchCollection Matches(InputExpense expense)
        {
            return Regex.Matches(expense.Description);
        }
    }
}
