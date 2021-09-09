using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCine.AWSServerless.Facade
{
    [ApiController]    
    [Route("api/v1/MovieAttachment")]	
    [Produces("application/json")]
    public class MovieAttachmentFacade : FacadeBase
    {
        public MovieAttachmentFacade() 
        {
        }
		
        [HttpPost, Route("FuncaoTeste")] 
        public ActionResult FuncaoTeste([FromForm] int a, [FromForm] string b) 
        { 
            try 
            {
                //<#keep(FuncaoTeste)#> 
                new Kernel.Controllers.MovieAttachmentController().FuncaoTeste(a, b);
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