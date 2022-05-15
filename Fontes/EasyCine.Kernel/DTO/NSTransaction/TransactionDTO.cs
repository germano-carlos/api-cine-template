//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model.NSTransaction;

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
		public static TransactionDTO FromEntity(Transaction element)
		{
			return new TransactionDTO()
			{
				TransactionId = element.TransactionId,
				CreatedAt = element.CreatedAt,
				TransactionStatus = element.TransactionStatus,
				MovieSession = MovieSessionDTO.FromEntity(element.MovieSession),
				User = UserDTO.FromEntity(element.User),
				Card = CardDTO.FromEntity(element.Card),
				ItemList = ItemDTO.FromEntity(element.ItemList)
			};
		}
		
		public static List<TransactionDTO> FromEntity(List<Transaction> elements)
		{
			return new List<TransactionDTO>(elements.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}