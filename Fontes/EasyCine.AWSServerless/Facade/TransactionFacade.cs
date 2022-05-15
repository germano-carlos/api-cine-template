
//<#keep(imports)#>
using System;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel.DTO.NSTransaction;

//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Transaction")]	
	[Produces("application/json")]
	public class TransactionFacade : FacadeBase
	{
		public TransactionFacade() 
		{
		}
		
		
		[HttpPost, Route("AtualizarTransacoes")] 
		public ActionResult AtualizarTransacoes([FromBody] TransactionDTO transacao) 
		{ 
			try 
			{
				 
				//<#keep(AtualizarTransacoes)#> 
				object ret = new Kernel.Controllers.TransactionController().AtualizarTransacoes(transacao); 
				return Json(ret); 
				//<#/keep(AtualizarTransacoes)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Transaction.AtualizarTransacoes", e); 
			} 
		}

		[HttpPost, Route("CriarNovaTransacao")] 
		public ActionResult CriarNovaTransacao([FromBody] TransactionDTO transacao) 
		{ 
			try 
			{
				 
				//<#keep(CriarNovaTransacao)#> 
				object ret = new Kernel.Controllers.TransactionController().CriarNovaTransacao(transacao); 
				return Json(ret); 
				//<#/keep(CriarNovaTransacao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Transaction.CriarNovaTransacao", e); 
			} 
		}

		[HttpPost, Route("ObterTransacoesUsuario")] 
		public ActionResult ObterTransacoesUsuario([FromForm] int usuarioId) 
		{ 
			try 
			{
				 
				//<#keep(ObterTransacoesUsuario)#> 
				object ret = new Kernel.Controllers.TransactionController().ObterTransacoesUsuario(usuarioId); 
				return Json(ret); 
				//<#/keep(ObterTransacoesUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Transaction.ObterTransacoesUsuario", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
