//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using System;
using System.Collections.Generic;
using System.Text;
using EasyCine.Kernel.DTO.NSSession;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSMovie
{
	public class MovieSessionDTO
	{
		public long MovieSessionId;
		public decimal? Amount;
		public ActivityStatus ActivityStatus;
		public SessionType SessionType;
		public MovieDTO Movie;
		public SessionDTO Session;
		public List<TransactionDTO> TransactionList = new List<TransactionDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}