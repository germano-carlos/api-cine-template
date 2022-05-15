//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSUser;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public static UserDTO FromEntity(User element)
		{
			if (element is null)
				return new UserDTO();

			return new UserDTO()
			{
				UserId = element.UserId,
				Name = element.Name,
				Email = element.Email,
				Password = element.Password,
				CreatedAt = element.CreatedAt,
				UserType = element.UserType,
				ActivityStatus = element.ActivityStatus,
				CardList = CardDTO.FromEntity(element.CardList),
			};
		}
		
		public static List<UserDTO> FromEntity(List<User> elements)
		{
			return new List<UserDTO>(elements.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}