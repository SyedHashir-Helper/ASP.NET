using FirstAppNet.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace FirstAppNet.Models
{
	public class TransactionRepository
	{
		public static MarketDBContext MarketDB;
        //private static List<Transaction> _transactions = new List<Transaction>();


		public static IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime dateTime)
		{
			if (string.IsNullOrWhiteSpace(cashierName))
			{
				return MarketDB.Transactions.Where(x => x.TimeStamp.Date == dateTime.Date);
			}
			else
			{
				return MarketDB.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
					x.TimeStamp.Date == dateTime.Date
				);
			}
		}

		public static IEnumerable<Transaction> Search(string cashierName, DateTime startDate,DateTime endDate)
		{
			if (string.IsNullOrWhiteSpace(cashierName))
			{
				return MarketDB.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date);
			}
			else
			{
				return MarketDB.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{x.CashierName}%") &&
				x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date
				);
			}
		}
		public static void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
		{
			var transaction = new Transaction
			{
				ProductId = productId,
				ProductName = productName,
				TimeStamp = DateTime.Now,
				Price = price,
				BeforeQuantity = beforeQty,
				SoldQuantity= soldQty,
				CashierName = cashierName,
			};
			MarketDB.Transactions.Add(transaction);
			MarketDB.SaveChanges();
		}
	}
}
