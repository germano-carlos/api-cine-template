//<#keep(imports)#>
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

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}