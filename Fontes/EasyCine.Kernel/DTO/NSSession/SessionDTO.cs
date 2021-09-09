//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSSession
{
	public class SessionDTO
	{
		public int SessionId;
		public DateTime SessionHour;
		public DateTime CreatedAt;
		public ActivityStatus ActivityStatus;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}