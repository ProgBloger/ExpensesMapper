namespace ExpensesMapper.Models
{
    public class CategoryGroup
    {
        public string Name { get; }
        public List<Category> Categories { get; set; }

        public CategoryGroup(string categoryGroupName)
        {
            Name = categoryGroupName;
            Categories = new List<Category>(); // Initializing the Categories list
        }

        public void AddExpense(string categoryName, decimal amount)
        {
            // Find the Category by its name
            var category = Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category != null)
            {
                // If there is such - add the value to the Category
                category.AddAmount(amount);
            }
            else
            {
                // Else add current Category to the Category group
                category = new Category(categoryName, amount);
                Categories.Add(category);
            }
        }
    }
}
