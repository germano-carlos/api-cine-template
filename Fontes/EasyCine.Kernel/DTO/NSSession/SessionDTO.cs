//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.Model.NSGeneric;
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSSession
{
	public class SessionDTO
	{
		public int SessionId;
		public String SessionHour;
		public DateTime CreatedAt;
		public ActivityStatus ActivityStatus;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}