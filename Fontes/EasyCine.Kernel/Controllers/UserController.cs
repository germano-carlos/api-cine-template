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
		
		
		public UserDTO AtualizarUsuario(UserDTO user) 
		{ 
			using var context = EasyCineContext.Get("User.AtualizarUsuario"); 
			//<#keep(AtualizarUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarUsuario)#> 
		} 

		public UserDTO CriarUsuario(UserDTO usuario) 
		{ 
			using var context = EasyCineContext.Get("User.CriarUsuario"); 
			//<#keep(CriarUsuario)#> 
			var user = new User(usuario);
			context.SaveChanges(); 

			return UserDTO.FromEntity(user); 
			//<#/keep(CriarUsuario)#> 
		} 

		public void ExcluirUsuario(long usuarioId) 
		{ 
			using var context = EasyCineContext.Get("User.ExcluirUsuario"); 
			//<#keep(ExcluirUsuario)#> 
			User.Get(usuarioId).Inativar();
			context.SaveChanges(); 
			//<#/keep(ExcluirUsuario)#> 
		} 

		public UserDTO ObterUsuario(long usuarioId) 
		{ 
			using var context = EasyCineContext.Get("User.ObterUsuario"); 
			//<#keep(ObterUsuario)#>  
			return UserDTO.FromEntity(User.Get(usuarioId)); 
			//<#/keep(ObterUsuario)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
