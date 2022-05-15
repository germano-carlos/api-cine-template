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
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("Movies")]
	public sealed class Movie
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie", TypeName = "BIGINT")] public long MovieId { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Name { get; set; } 
		[Column("ds_movie", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Description { get; set; } 
		[Column("rating", TypeName = "VARCHAR(3)"), MaxLength(3), Required] public string Rating { get; set; } 
		[Column("created_at", TypeName = "DATETIME"), Required] public DateTime CreatedAt { get; set; } 
		[Column("start_time", TypeName = "DATETIME"), Required] public DateTime StartTime { get; set; } 
		[Column("end_time", TypeName = "DATETIME"), Required] public DateTime EndTime { get; set; } 
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[InverseProperty("Movie")] public List<MovieAttachment> MovieAttachmentList { get; set; }  // ICollection 
		[InverseProperty("Movie")] public List<MovieSession> MovieSessionList { get; set; }  // ICollection 
		[InverseProperty("Movie")] public List<MovieCategory> MovieCategoryList { get; set; }  // ICollection 

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
		internal static List<Movie> ObterTodos()
		{
			return EasyCineContext.Get().MovieSet.ToList();
		}
		//<#/keep(implements)#>
	}
}