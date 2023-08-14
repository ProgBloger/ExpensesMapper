namespace ExpensesMapper.Models
{
    public class UnmappedExpense
    {
        private InputExpense expense;

        public UnmappedExpense(InputExpense expense)
        {
            this.expense = expense;
        }
    }
}
