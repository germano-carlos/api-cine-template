//<#keep(imports)#>
using System;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSUser;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class UserController
	{
		public UserController() 
		{
		}
		
		
		public User AtualizarUsuario(UserDTO user) 
		{ 
			using var context = EasyCineContext.Get("User.AtualizarUsuario"); 
			//<#keep(AtualizarUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarUsuario)#> 
		} 

		public User CriarUsuario(UserDTO usuario) 
		{ 
			using var context = EasyCineContext.Get("User.CriarUsuario"); 
			//<#keep(CriarUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarUsuario)#> 
		} 

		public void ExcluirUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("User.ExcluirUsuario"); 
			//<#keep(ExcluirUsuario)#> 
			context.SaveChanges(); 
			//<#/keep(ExcluirUsuario)#> 
		} 

		public User ObterUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("User.ObterUsuario"); 
			//<#keep(ObterUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ObterUsuario)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
