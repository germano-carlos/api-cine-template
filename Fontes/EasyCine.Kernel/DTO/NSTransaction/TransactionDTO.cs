//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSUser;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSTransaction
{
	public class TransactionDTO
	{
		public long TransactionId;
		public DateTime CreatedAt;
		public TransactionStatus TransactionStatus;
		public MovieSessionDTO MovieSession;
		public UserDTO User;
		public CardDTO Card;
		public List<ItemDTO> ItemList = new List<ItemDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}