using System.Collections.Generic;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSMovie;

namespace EasyCine.Kernel.Controllers
{
    public class MovieController
    {
        public MovieController() 
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
        
        public List<Movie> ObterTodos() 
        { 
            using (var context = EasyCineContext.Get("Operacao.FuncaoTeste")) 
            { 
                //<#keep(FuncaoTeste)#> 
                return Movie.ObterTodos();
                //<#/keep(FuncaoTeste)#> 
            } 
        }
        
    }
}