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

namespace EasyCine.Kernel.Model.NSGeneric
{
	[Table("logs")]
	public sealed class Log
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Id", TypeName = "BIGINT")] public long id_log { get; set; } 
		[Column("descricao", TypeName = "VARCHAR(1000)"), MaxLength(1000), Required] public string Descricao { get; set; } 
		[Column("created_at", TypeName = "DATETIME"), Required] public DateTime CreatedAt { get; set; } 
		[Column("stack_trace", TypeName = "VARCHAR(0)"), MaxLength(0)] public string StackTrace { get; set; } 
		[Column("TYPELOG", TypeName = "INT"), Required] public TypeLog TypeLog { get; set; }

		public Log() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().LogSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}