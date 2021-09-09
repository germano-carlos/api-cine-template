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
		public String SessionHour;
		public DateTime CreatedAt;
		public ActivityStatus ActivityStatus;
		public MovieSessionDTO MovieSession;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}