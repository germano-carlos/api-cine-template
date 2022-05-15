//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using EasyCine.Kernel;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSGeneric;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class AuditoriaController
	{
		public AuditoriaController() 
		{
		}
		
		
		public Log createLOG(String Descricao, DateTime CreatedAt, String StackTrace, TypeLog TypeLog) 
		{ 
			using var context = EasyCineContext.Get("Auditoria.createLOG"); 
			//<#keep(createLOG)#> 
			var log = new Log(Descricao, StackTrace, TypeLog);
			context.SaveChanges(); 
			return log; 
			//<#/keep(createLOG)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
