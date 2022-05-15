
//<#keep(imports)#>
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model.NSGeneric;

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
