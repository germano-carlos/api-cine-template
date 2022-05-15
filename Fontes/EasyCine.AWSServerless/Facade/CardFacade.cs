
//<#keep(imports)#>
using System;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel.DTO.NSTransaction;

//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Card")]	
	[Produces("application/json")]
	public class CardFacade : FacadeBase
	{
		public CardFacade() 
		{
		}
		
		
		[HttpPost, Route("CriarCartao")] 
		public ActionResult CriarCartao([FromBody] CardDTO cartao) 
		{ 
			try 
			{
				 
				//<#keep(CriarCartao)#> 
				object ret = new Kernel.Controllers.CardController().CriarCartao(cartao); 
				return Json(ret); 
				//<#/keep(CriarCartao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Card.CriarCartao", e); 
			} 
		}

		[HttpPost, Route("ExcluirCartao")] 
		public ActionResult ExcluirCartao([FromForm] int idCartao) 
		{ 
			try 
			{
				 
				//<#keep(ExcluirCartao)#> 
				new Kernel.Controllers.CardController().ExcluirCartao(idCartao); 
				return Ok(); 
				//<#/keep(ExcluirCartao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Card.ExcluirCartao", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
