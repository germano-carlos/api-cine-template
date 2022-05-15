
//<#keep(imports)#>
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel;
using EasyCine.Kernel.Model.NSGeneric;

//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Auditoria")]	
	[Produces("application/json")]
	public class AuditoriaFacade : FacadeBase
	{
		public AuditoriaFacade() 
		{
		}
		
		
		[HttpPost, Route("createLOG")] 
		public ActionResult createLOG([FromForm] String Descricao, [FromForm] DateTime CreatedAt, [FromForm] String StackTrace, [FromForm] TypeLog TypeLog) 
		{ 
			try 
			{
				 
				//<#keep(createLOG)#> 
				object ret = new Kernel.Controllers.AuditoriaController().createLOG(Descricao, CreatedAt, StackTrace, TypeLog); 
				return Json(ret); 
				//<#/keep(createLOG)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Auditoria.createLOG", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
