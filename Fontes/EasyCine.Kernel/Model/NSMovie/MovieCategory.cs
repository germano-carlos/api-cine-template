//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;using EasyCine.Kernel.Model.NSMovie; 

//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("MovieCategories")]
	public sealed class MovieCategory
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie_category", TypeName = "BIGINT")] public long MovieCategoryId { get; set; } 
		[Column("CATEGORY", TypeName = "INT"), Required] public Category Category { get; set; }
		[Column("id_movie", TypeName = "BIGINT"), ForeignKey("Movie")] public long id_movie { get; set; } 
		public Movie Movie { get; set; } 

		public MovieCategory() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().MovieCategorySet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}