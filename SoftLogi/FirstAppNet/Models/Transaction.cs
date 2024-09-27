using System.Globalization;

namespace FirstAppNet.Models
{
	public class Transaction
	{
		public int TransactionId { get; set; }
		public DateTime TimeStamp { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; } = "";
		public double Price { get; set; }
		public int BeforeQuantity { get; set; }
		public int SoldQuantity { get; set; }
		public string CashierName { get; set; } = "";
	}
}
