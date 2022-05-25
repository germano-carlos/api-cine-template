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
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSTransaction;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSUser
{
	[Table("Users")]
	public sealed class User
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_user", TypeName = "BIGINT")] public long UserId { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Name { get; set; } 
		[Column("email", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Email { get; set; } 
		[Column("password", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Password { get; set; } 
		[Column("created_at", TypeName = "DATETIME"), Required] public DateTime CreatedAt { get; set; } 
		[Column("id_user_type", TypeName = "INT"), Required] public UserType UserType { get; set; }
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[InverseProperty("User")] public List<Card> CardList { get; set; }  // ICollection 
		[InverseProperty("User")] public List<Transaction> TransactionList { get; set; }  // ICollection 

		public User() { }
		//<#keep(constructor)#>
		public User(UserDTO usuario)
		{
			Atualizar(usuario);
			CreatedAt = DateTime.Now;
			ActivityStatus = ActivityStatus.ACTIVE;
			CardList = new List<Card>();
			TransactionList = new List<Transaction>();

			foreach (var card in usuario.CardList)
				new Card(card, this);
			foreach (var transaction in usuario.TransactionList)
				new NSTransaction.Transaction(transaction, this);

			EasyCineContext.Get().UserSet.Add(this);
		}
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().UserSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public static User Get(long id)
		{
			return EasyCineContext.Get().UserSet.Find(id);
		}

		public void Atualizar(UserDTO user)
		{
			UserId = user.UserId;  
			Name = user.Name;  
			Email = user.Email;  
			Password = user.Password;  
			CreatedAt = user.CreatedAt;  
			UserType = user.UserType; 
			ActivityStatus = user.ActivityStatus; 
		}

		public void Inativar()
		{
			if (ActivityStatus == ActivityStatus.INACTIVE)
				throw new Exception("User already inactive");

			ActivityStatus = ActivityStatus.INACTIVE;
		}
		//<#/keep(implements)#>
	}
}