//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCine.Kernel.Model.NSTransaction;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSTransaction
{
	public class ItemDTO
	{
		public long ItemId;
		public decimal Amount;
		public String Name;
		public String Seat;
		public TransactionDTO Transaction;

		//<#keep(implements)#>
		public static ItemDTO FromEntity(Item element)
		{
			return new ItemDTO()
			{
				ItemId = element.ItemId,
				Amount = element.Amount,
				Name = element.Name,
				Seat = element.Seat
			};
		}
		
		public static List<ItemDTO> FromEntity(List<Item> elements)
		{
			return new List<ItemDTO>(elements.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}