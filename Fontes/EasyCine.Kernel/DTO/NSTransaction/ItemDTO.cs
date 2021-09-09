//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSTransaction
{
	public class ItemDTO
	{
		public long ItemId;
		public decimal Amount;
		public String Name;
		public TransactionDTO Transaction;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}