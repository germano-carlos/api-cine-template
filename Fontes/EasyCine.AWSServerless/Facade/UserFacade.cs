
//<#keep(imports)#>
using System;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel.DTO.NSUser;

//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/User")]	
	[Produces("application/json")]
	public class UserFacade : FacadeBase
	{
		public UserFacade() 
		{
		}
		
		
		[HttpPost, Route("AtualizarUsuario")] 
		public ActionResult AtualizarUsuario([FromBody] UserDTO user) 
		{ 
			try 
			{
				 
				//<#keep(AtualizarUsuario)#> 
				object ret = new Kernel.Controllers.UserController().AtualizarUsuario(user); 
				return Json(ret); 
				//<#/keep(AtualizarUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.User.AtualizarUsuario", e); 
			} 
		}

		[HttpPost, Route("CriarUsuario")] 
		public ActionResult CriarUsuario([FromBody] UserDTO usuario) 
		{ 
			try 
			{
				 
				//<#keep(CriarUsuario)#> 
				object ret = new Kernel.Controllers.UserController().CriarUsuario(usuario); 
				return Json(ret); 
				//<#/keep(CriarUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.User.CriarUsuario", e); 
			} 
		}

		[HttpPost, Route("ExcluirUsuario")] 
		public ActionResult ExcluirUsuario([FromForm] int usuarioId) 
		{ 
			try 
			{
				 
				//<#keep(ExcluirUsuario)#> 
				new Kernel.Controllers.UserController().ExcluirUsuario(usuarioId); 
				return Ok(); 
				//<#/keep(ExcluirUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.User.ExcluirUsuario", e); 
			} 
		}

		[HttpPost, Route("ObterUsuario")] 
		public ActionResult ObterUsuario([FromForm] int usuarioId) 
		{ 
			try 
			{
				 
				//<#keep(ObterUsuario)#> 
				object ret = new Kernel.Controllers.UserController().ObterUsuario(usuarioId); 
				return Json(ret); 
				//<#/keep(ObterUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.User.ObterUsuario", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
