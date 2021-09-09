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
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSTransaction;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("MovieSessions")]
	public class MovieSession
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie_session", TypeName = "BIGINT")] public long MovieSessionId { get; set; } 
		[Column("amount", TypeName = "decimal(10, 2)")] public decimal? Amount { get; set; } 
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[Column("id_session_type", TypeName = "INT"), Required] public SessionType SessionType { get; set; }
		[Column("id_transaction", TypeName = "BIGINT"), ForeignKey("Transaction")] public long id_transaction { get; set; } 
		public virtual Transaction Transaction { get; set; } 

		public MovieSession() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().MovieSessionSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}