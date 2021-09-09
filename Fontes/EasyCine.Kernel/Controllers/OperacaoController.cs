//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using EasyCine.Kernel;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSMovie;

//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class OperacaoController
	{
		public OperacaoController() 
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

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
