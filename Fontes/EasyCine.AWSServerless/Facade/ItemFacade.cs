using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCine.AWSServerless.Facade
{
    [ApiController]    
    [Route("api/v1/Item")]	
    [Produces("application/json")]
    public class ItemFacade : FacadeBase
    {
        public ItemFacade() 
        {
        }
		
		
        [HttpPost, Route("FuncaoTeste")] 
        public ActionResult FuncaoTeste([FromForm] int a, [FromForm] string b) 
        { 
            try 
            {
                //<#keep(FuncaoTeste)#> 
                new Kernel.Controllers.ItemController().FuncaoTeste(a, b);
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