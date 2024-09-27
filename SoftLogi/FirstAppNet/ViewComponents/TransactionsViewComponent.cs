using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppNet.ViewComponents
{
	[ViewComponent]
	public class TransactionsViewComponent:ViewComponent
	{
        public TransactionsViewComponent(ITransactionRepository transactionRepository)
        {
			TransactionRepository = transactionRepository;
		}

		public ITransactionRepository TransactionRepository { get; }

		public IViewComponentResult Invoke(string username)
		{
			var transactions = TransactionRepository.GetByDayAndCashier(username, DateTime.Now);
			return View(transactions);
		}
	}
}
