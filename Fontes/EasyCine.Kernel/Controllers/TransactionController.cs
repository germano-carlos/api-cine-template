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
		
		
		public TransactionDTO AtualizarTransacoes(TransactionDTO transacao) 
		{ 
			using var context = EasyCineContext.Get("Transaction.AtualizarTransacoes"); 
			//<#keep(AtualizarTransacoes)#> 
			
			var t = Transaction.Get(transacao.TransactionId);
			t.Atualizar(transacao);
			context.SaveChanges(); 

			return TransactionDTO.FromEntity(t); 
			//<#/keep(AtualizarTransacoes)#> 
		} 

		public TransactionDTO CriarNovaTransacao(TransactionDTO transacao) 
		{ 
			using var context = EasyCineContext.Get("Transaction.CriarNovaTransacao"); 
			//<#keep(CriarNovaTransacao)#> 
			var t = new Transaction(transacao);
			context.SaveChanges(); 

			return TransactionDTO.FromEntity(t); 
			//<#/keep(CriarNovaTransacao)#> 
		} 

		public TransactionDTO[] ObterTransacoesUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("Transaction.ObterTransacoesUsuario"); 
			//<#keep(ObterTransacoesUsuario)#> 
			var t = Transaction.ObterTransacoesUsuario(usuarioId);
			context.SaveChanges(); 

			return TransactionDTO.FromEntity(t); 
			//<#/keep(ObterTransacoesUsuario)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
