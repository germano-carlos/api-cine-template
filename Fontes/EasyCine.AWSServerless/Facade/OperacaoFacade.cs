
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
		
		
		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
