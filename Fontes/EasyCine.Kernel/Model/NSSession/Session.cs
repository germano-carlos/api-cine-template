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
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSSession
{
	[Table("Sessions")]
	public class Session
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("session_id", TypeName = "INT")] public int SessionId { get; set; } 
		[Column("session_hour", TypeName = "VARCHAR(8)"),   MaxLength(8),   Required] public String SessionHour { get; set; } 
		[Column("created_at", TypeName = "DATETIME"),   Required] public DateTime CreatedAt { get; set; } 

		public Session() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().SessionSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}