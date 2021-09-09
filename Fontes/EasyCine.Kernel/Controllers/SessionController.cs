using System.Collections.Generic;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSMovie;

namespace EasyCine.Kernel.Controllers
{
    public class SessionController
    {
        public SessionController() 
        {
        }
		
		
        public void FuncaoTeste(int a, string b) 
        { 
            using (var context = EasyCineContext.Get("Operacao.FuncaoTeste")) 
            { 
                //<#keep(FuncaoTeste)#> 
                context.SaveChanges(); 
                //<#/keep(FuncaoTeste)#> 
            } 
        }
    }
}