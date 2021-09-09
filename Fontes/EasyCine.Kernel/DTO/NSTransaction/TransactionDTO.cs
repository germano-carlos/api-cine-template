//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSTransaction
{
	public class TransactionDTO
	{
		public long TransactionId;
		public DateTime CreatedAt;
		public TransactionStatus TransactionStatus;
		public List<ItemDTO> ItemList = new List<ItemDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}