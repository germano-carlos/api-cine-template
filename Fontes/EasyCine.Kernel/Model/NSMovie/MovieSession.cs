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
using EasyCine.Kernel.Model.NSSession;
using EasyCine.Kernel.Model.NSTransaction;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("MovieSessions")]
	public sealed class MovieSession
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie_session", TypeName = "BIGINT")] public long MovieSessionId { get; set; } 
		[Column("amount", TypeName = "decimal(10, 2)")] public decimal? Amount { get; set; } 
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[Column("id_session_type", TypeName = "INT"), Required] public SessionType SessionType { get; set; }
		[Column("MovieId", TypeName = "BIGINT"), ForeignKey("Movie")] public long MovieId { get; set; } 
		public Movie Movie { get; set; } 
		[Column("id_session", TypeName = "INT"), ForeignKey("Session")] public int id_session { get; set; } 
		public Session Session { get; set; } 
		[InverseProperty("MovieSession")] public List<Transaction> TransactionList { get; set; }  // ICollection 

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