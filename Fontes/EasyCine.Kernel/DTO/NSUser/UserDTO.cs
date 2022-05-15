//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSUser;
using System;
using System.Collections.Generic;
using System.Text;
//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSUser
{
	public class UserDTO
	{
		public long UserId;
		public String Name;
		public String Email;
		public String Password;
		public DateTime CreatedAt;
		public UserType UserType;
		public ActivityStatus ActivityStatus;
		public List<CardDTO> CardList = new List<CardDTO>();
		public List<TransactionDTO> TransactionList = new List<TransactionDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}