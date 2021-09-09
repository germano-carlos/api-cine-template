//<#keep(imports)#>
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
		public TransactionDTO Transaction;
		public List<CardDTO> CardList = new List<CardDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}