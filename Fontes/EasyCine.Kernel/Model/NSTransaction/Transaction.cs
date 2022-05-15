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
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSUser;

//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSTransaction
{
	[Table("Transactions")]
	public sealed class Transaction
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_transaction", TypeName = "BIGINT")] public long TransactionId { get; set; } 
		[Column("created_at", TypeName = "DATETIME"), Required] public DateTime CreatedAt { get; set; } 
		[Column("id_transaction_status", TypeName = "INT"), Required] public TransactionStatus TransactionStatus { get; set; }
		[Column("MovieSessionId", TypeName = "BIGINT"), ForeignKey("MovieSession")] public long MovieSessionId { get; set; } 
		public MovieSession MovieSession { get; set; } 
		[Column("UserId", TypeName = "BIGINT"), ForeignKey("User")] public long UserId { get; set; } 
		public User User { get; set; } 
		[Column("CardId", TypeName = "BIGINT"), ForeignKey("Card")] public long CardId { get; set; } 
		public Card Card { get; set; } 
		[InverseProperty("Transaction")] public List<Item> ItemList { get; set; }  // ICollection 

		public Transaction() { }
		//<#keep(constructor)#>
		public Transaction(TransactionDTO transaction)
		{
			CreatedAt = DateTime.Now;
			TransactionStatus = transaction.TransactionStatus;
			User = User.Get(transaction.User.UserId);
			Card = Card.Get(transaction.Card.CardId);
			MovieSession = MovieSession.Get(transaction.MovieSession.MovieSessionId);
			ItemList = new List<Item>();
		}
		
		public Transaction(TransactionDTO transaction, User usuario)
		{
			CreatedAt = DateTime.Now;
			TransactionStatus = transaction.TransactionStatus;
			User = usuario;
			Card = Card.Get(transaction.Card.CardId);
			MovieSession = MovieSession.Get(transaction.MovieSession.MovieSessionId);
			ItemList = new List<Item>();
		}

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