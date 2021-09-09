//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSMovie
{
	public class MovieSessionDTO
	{
		public long MovieSessionId;
		public decimal? Amount;
		public ActivityStatus ActivityStatus;
		public SessionType SessionType;
		public TransactionDTO Transaction;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}