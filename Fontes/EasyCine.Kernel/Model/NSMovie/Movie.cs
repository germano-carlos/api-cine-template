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
	[Table("Movies")]
	public class Movie
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("movie_id", TypeName = "BIGINT")] public long MovieId { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String Name { get; set; } 
		[Column("ds_movie", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String Description { get; set; } 
		[Column("rating", TypeName = "VARCHAR(3)"),   MaxLength(3),   Required] public String Rating { get; set; } 
		[Column("created_at", TypeName = "DATETIME"),   Required] public DateTime CreatedAt { get; set; } 
		[Column("start_time", TypeName = "DATETIME"),   Required] public DateTime StartTime { get; set; } 
		[Column("end_time", TypeName = "DATETIME"),   Required] public DateTime EndTime { get; set; } 

		public Movie() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().MovieSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}