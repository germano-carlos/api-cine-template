//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSTransaction;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class TransactionController
	{
		public TransactionController() 
		{
		}
		
		
		public Transaction AtualizarTransacoes(TransactionDTO transacao) 
		{ 
			using var context = EasyCineContext.Get("Transaction.AtualizarTransacoes"); 
			//<#keep(AtualizarTransacoes)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarTransacoes)#> 
		} 

		public Transaction CriarNovaTransacao(TransactionDTO transacao) 
		{ 
			using var context = EasyCineContext.Get("Transaction.CriarNovaTransacao"); 
			//<#keep(CriarNovaTransacao)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarNovaTransacao)#> 
		} 

		public Transaction[] ObterTransacoesUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("Transaction.ObterTransacoesUsuario"); 
			//<#keep(ObterTransacoesUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ObterTransacoesUsuario)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
