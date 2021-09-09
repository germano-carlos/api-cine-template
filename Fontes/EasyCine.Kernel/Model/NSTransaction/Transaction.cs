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
	[Table("Transactions")]
	public class Transaction
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("transaction_id", TypeName = "BIGINT")] public long TransactionId { get; set; } 
		[Column("created_at", TypeName = "DATETIME"),   Required] public DateTime CreatedAt { get; set; } 
		[Column("TRANSACTIONSTATUS", TypeName = "INT"), Required] public TransactionStatus TransactionStatus { get; set; }
		[InverseProperty("Transaction")] public virtual List<Item> ItemList { get; set; }  // ICollection 

		public Transaction() { }
		//<#keep(constructor)#>
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().TransactionSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}