//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.Model.NSGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSSession;

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
		public static SessionDTO FromEntity(Session element)
		{
			if (element is null)
				return new SessionDTO();

			return new SessionDTO()
			{
				SessionId = element.SessionId,
				SessionHour = element.SessionHour,
				CreatedAt = element.CreatedAt,
				ActivityStatus = element.ActivityStatus,
			};
		}
		
		public static List<SessionDTO> FromEntity(List<Session> elements)
		{
			return new List<SessionDTO>(elements.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}