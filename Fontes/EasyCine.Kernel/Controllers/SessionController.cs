using System.Collections.Generic;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSSession;

namespace EasyCine.Kernel.Controllers
{
    public class SessionController
    {
        public SessionController() 
        {
        }

        public void DeletarSessao(string sessionHour)
        {
            using (var context = EasyCineContext.Get("SessionController.DeletarSessao"))
            {
                Session.Get(sessionHour).Delete();
                context.SaveChanges();
            }
        }
        
        public SessionDTO ObterSessao(string sessionHour)
        {
            using (var context = EasyCineContext.Get("SessionController.DeletarSessao"))
            {
                var x = Session.Get(sessionHour);
                return SessionDTO.FromEntity(x);
            }
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