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

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("MovieSessions")]
	public class MovieSession
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie_session", TypeName = "BIGINT")] public long MovieSessionId { get; set; } 
		[Column("amount", TypeName = "decimal(10, 2)")] public decimal? Amount { get; set; } 

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