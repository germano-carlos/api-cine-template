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

namespace EasyCine.Kernel.Model.NSUser
{
	[Table("Users")]
	public class User
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_user", TypeName = "BIGINT")] public long UserId { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String Name { get; set; } 
		[Column("email", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String Email { get; set; } 
		[Column("password", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String Password { get; set; } 
		[Column("created_at", TypeName = "DATETIME"),   Required] public DateTime CreatedAt { get; set; } 

		public User() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().UserSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}