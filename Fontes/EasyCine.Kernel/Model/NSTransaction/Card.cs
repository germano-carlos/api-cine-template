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
using EasyCine.Kernel.Model.NSUser;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSTransaction
{
	[Table("Cards")]
	public class Card
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("card_id", TypeName = "BIGINT")] public long CardId { get; set; } 
		[Column("holder_name", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String HolderName { get; set; } 
		[Column("card_number", TypeName = "VARCHAR(16)"),   MaxLength(16),   Required] public String CardNumber { get; set; } 
		[Column("security_code", TypeName = "VARCHAR(3)"),   MaxLength(3),   Required] public String SecurityCode { get; set; } 
		[Column("expiration_date", TypeName = "DATETIME"),   Required] public DateTime ExpirationDate { get; set; } 
		[Column("id_user", TypeName = "BIGINT"), ForeignKey("User")] public long? id_user { get; set; } 
		public virtual User User { get; set; } 

		public Card() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().CardSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}