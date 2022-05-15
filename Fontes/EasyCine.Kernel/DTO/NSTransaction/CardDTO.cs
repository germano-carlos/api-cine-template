//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSTransaction;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSTransaction
{
	public class CardDTO
	{
		public long CardId;
		public String HolderName;
		public String CardNumber;
		public String SecurityCode;
		public DateTime ExpirationDate;
		public ActivityStatus ActivityStatus;
		public UserDTO User;
		public List<TransactionDTO> TransactionList = new List<TransactionDTO>();

		//<#keep(implements)#>
		public static CardDTO FromEntity(Card element)
		{
			return new CardDTO()
			{
				CardId = element.CardId,
				HolderName = element.HolderName,
				CardNumber = element.CardNumber,
				SecurityCode = element.SecurityCode,
				ExpirationDate = element.ExpirationDate,
				ActivityStatus = element.ActivityStatus
			};
		}
		
		public static List<CardDTO> FromEntity(List<Card> elements)
		{
			return new List<CardDTO>(elements.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}