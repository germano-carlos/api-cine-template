using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCine.AWSServerless.Facade
{
    [ApiController]    
    [Route("api/v1/Session")]	
    [Produces("application/json")]
    public class SessionFacade : FacadeBase
    {
        public SessionFacade() 
        {
        }
		
		
        [HttpPost, Route("FuncaoTeste")] 
        public ActionResult FuncaoTeste([FromForm] int a, [FromForm] string b) 
        { 
            try 
            {
                //<#keep(FuncaoTeste)#> 
                new Kernel.Controllers.SessionController().FuncaoTeste(a, b);
                return null;
                //<#/keep(FuncaoTeste)#> 
            } 
            catch (Exception e) 
            { 
                return Erro("EasyCine.Operacao.FuncaoTeste", e); 
            } 
        }
    }
}