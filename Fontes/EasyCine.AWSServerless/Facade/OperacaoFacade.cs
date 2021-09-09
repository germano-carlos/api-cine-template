
//<#keep(imports)#>
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel;
//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Operacao")]	
	[Produces("application/json")]
	public class OperacaoFacade : FacadeBase
	{
		public OperacaoFacade() 
		{
		}
		
		
		[HttpPost, Route("FuncaoTeste")] 
		public ActionResult FuncaoTeste([FromForm] int a, [FromForm] string b) 
		{ 
			try 
			{
				//<#keep(FuncaoTeste)#> 
				new Kernel.Controllers.OperacaoController().FuncaoTeste(a, b);
				return null;
				//<#/keep(FuncaoTeste)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.FuncaoTeste", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
