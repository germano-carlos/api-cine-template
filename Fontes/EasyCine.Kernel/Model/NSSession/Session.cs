//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSSession
{
	[Table("Sessions")]
	public sealed class Session
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_session", TypeName = "INT")] public int SessionId { get; set; } 
		[Column("session_hour", TypeName = "VARCHAR(8)"), MaxLength(8), Required] public string SessionHour { get; set; } 
		[Column("created_at", TypeName = "DATETIME"), Required] public DateTime CreatedAt { get; set; } 
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }

		public Session() { }
		//<#keep(constructor)#>
		public Session(SessionDTO sessao)
		{
			SessionHour = sessao.SessionHour;
			CreatedAt = DateTime.Now;
			ActivityStatus = ActivityStatus.ACTIVE;

			EasyCineContext.Get().SessionSet.Add(this);
		}
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().SessionSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static Session Get(string sessionHour)
		{
			return EasyCineContext.Get().SessionSet.FirstOrDefault(s =>
				s.SessionHour == sessionHour && s.ActivityStatus == ActivityStatus.ACTIVE);
		}
		//<#/keep(implements)#>
	}
}