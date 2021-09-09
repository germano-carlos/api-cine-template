using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCine.AWSServerless.Facade
{
    [ApiController]    
    [Route("api/v1/Movie")]	
    [Produces("application/json")]
    public class MovieFacade : FacadeBase
    {
        public MovieFacade() 
        {
        }
		
		
        [HttpPost, Route("FuncaoTeste")] 
        public ActionResult FuncaoTeste([FromForm] int a, [FromForm] string b) 
        { 
            try 
            {
                //<#keep(FuncaoTeste)#> 
                new Kernel.Controllers.MovieController().FuncaoTeste(a, b);
                return null;
                //<#/keep(FuncaoTeste)#> 
            } 
            catch (Exception e) 
            { 
                return Erro("EasyCine.Operacao.FuncaoTeste", e); 
            } 
        }
        
        [HttpPost, Route("ObterTodos")] 
        public ActionResult ObterTodos() 
        { 
            try 
            {
                //<#keep(FuncaoTeste)#> 
                object ret = new Kernel.Controllers.MovieController().ObterTodos(); 
                return Json(ret); 
                //<#/keep(FuncaoTeste)#> 
            } 
            catch (Exception e) 
            { 
                return Erro("EasyCine.Operacao.FuncaoTeste", e); 
            } 
        }
    }
}