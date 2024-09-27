using FirstAppNet.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAppNet.Interfaces
{
	public interface ITransactionRepository
	{
		public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime dateTime);
		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
		public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
	}
}
