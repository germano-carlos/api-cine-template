//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSUser;
using System;
using System.Collections.Generic;
using System.Text;
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
		public UserDTO User;
		public List<TransactionDTO> TransactionList = new List<TransactionDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}