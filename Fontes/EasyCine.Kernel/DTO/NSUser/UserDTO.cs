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

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}