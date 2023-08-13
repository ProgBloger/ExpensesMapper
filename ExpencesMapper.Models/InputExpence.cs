using ExpensesMapper.Enums;

namespace ExpensesMapper.Models
{
    public class InputExpense
    {
        public string OperationDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public CurrencyCode Currency { get; set; }
        public string RecipientName { get; set; }
        public string Description { get; set; }
    }
}
