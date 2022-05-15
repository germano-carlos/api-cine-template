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
using EasyCine.Kernel.DTO.NSTransaction;

//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSTransaction
{
	[Table("Itens")]
	public sealed class Item
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_item", TypeName = "BIGINT")] public long ItemId { get; set; } 
		[Column("amount", TypeName = "decimal(10, 2)"), Required] public decimal Amount { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Name { get; set; } 
		[Column("seat", TypeName = "VARCHAR(3)"), MaxLength(3), Required] public string Seat { get; set; } 
		[Column("TransactionId", TypeName = "BIGINT"), ForeignKey("Transaction")] public long TransactionId { get; set; } 
		public Transaction Transaction { get; set; } 

		public Item() { }
		//<#keep(constructor)#>
		public Item(ItemDTO item, Transaction transaction)
		{
			ItemId = item.ItemId; 
			Amount = item.Amount; 
			Name = item.Name; 
			Seat = item.Seat; 
			Transaction = transaction;

			EasyCineContext.Get().ItemSet.Add(this);
		}
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