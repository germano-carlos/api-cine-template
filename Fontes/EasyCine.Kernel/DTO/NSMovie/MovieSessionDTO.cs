//<#keep(imports)#>
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
		public SessionType SessionType;
		public ActivityStatus ActivityStatus;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}