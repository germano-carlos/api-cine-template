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
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSUser;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSTransaction
{
	[Table("Cards")]
	public sealed class Card
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_card", TypeName = "BIGINT")] public long CardId { get; set; } 
		[Column("holder_name", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string HolderName { get; set; } 
		[Column("card_number", TypeName = "VARCHAR(16)"), MaxLength(16), Required] public string CardNumber { get; set; } 
		[Column("security_code", TypeName = "VARCHAR(3)"), MaxLength(3), Required] public string SecurityCode { get; set; } 
		[Column("expiration_date", TypeName = "DATETIME"), Required] public DateTime ExpirationDate { get; set; } 
		[Column("ACTIVITYSTATUS", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[Column("UserId", TypeName = "BIGINT"), ForeignKey("User")] public long UserId { get; set; } 
		public User User { get; set; } 
		[InverseProperty("Card")] public List<Transaction> TransactionList { get; set; }  // ICollection 

		public Card() { }
		//<#keep(constructor)#>
		public Card(CardDTO cartao)
		{
			HolderName = cartao.HolderName;
			CardNumber = cartao.CardNumber;
			SecurityCode = cartao.SecurityCode;
			ExpirationDate = cartao.ExpirationDate;
			ActivityStatus = ActivityStatus.ACTIVE;
			User = NSUser.User.Get(cartao.User.UserId);
			TransactionList = new List<Transaction>();

			EasyCineContext.Get().CardSet.Add(this);
		}
		
		public Card(CardDTO cartao, User user)
		{
			HolderName = cartao.HolderName;
			CardNumber = cartao.CardNumber;
			SecurityCode = cartao.SecurityCode;
			ExpirationDate = cartao.ExpirationDate;
			ActivityStatus = ActivityStatus.ACTIVE;
			User = user;

			EasyCineContext.Get().CardSet.Add(this);
		}
		
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().CardSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static Card Get(long id)
		{
			return EasyCineContext.Get().CardSet.Find(id);
		}

		public void Inativar()
		{
			if (ActivityStatus == ActivityStatus.INACTIVE)
				throw new Exception("Card Already Inactive");

			ActivityStatus = ActivityStatus.INACTIVE;
		}

		public static List<Card> Listar(long usuarioId)
		{
			return EasyCineContext.Get().CardSet.Where(u => u.User.UserId == usuarioId).Include(u => u.User).ToList();
		}
		//<#/keep(implements)#>
	}
}