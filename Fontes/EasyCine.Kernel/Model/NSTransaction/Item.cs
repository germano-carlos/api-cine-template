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

namespace EasyCine.Kernel.Model.NSTransaction
{
	[Table("Itens")]
	public class Item
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_item", TypeName = "BIGINT")] public long ItemId { get; set; } 
		[Column("amount", TypeName = "decimal(10, 2)"),   Required] public decimal Amount { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"),   MaxLength(255),   Required] public String Name { get; set; } 
		[Column("transaction_id", TypeName = "BIGINT"), ForeignKey("Transaction")] public long transaction_id { get; set; } 
		public virtual Transaction Transaction { get; set; } 

		public Item() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().ItemSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}