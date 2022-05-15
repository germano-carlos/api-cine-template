//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using EasyCine.Kernel;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSSession;
using EasyCine.Kernel.Model.NSTransaction;
using EasyCine.Kernel.Model.NSUser;

//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class OperacaoController
	{
		public OperacaoController() 
		{
		}
		
		
		public List<Movie> FuncaoTeste(int a, string b) 
		{ 
			using var context = EasyCineContext.Get("Operacao.FuncaoTeste"); 
			//<#keep(FuncaoTeste)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(FuncaoTeste)#> 
		} 

		public Movie[] ListarFilmes(String Name, String Description, String Rating, DateTime CreatedAt, DateTime StartTime, DateTime EndTime, ActivityStatus ActivityStatus) 
		{ 
			using var context = EasyCineContext.Get("Operacao.ListarFilmes"); 
			//<#keep(ListarFilmes)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ListarFilmes)#> 
		} 

		public void RemoverFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Operacao.RemoverFilme"); 
			//<#keep(RemoverFilme)#> 
			context.SaveChanges(); 
			//<#/keep(RemoverFilme)#> 
		} 

		public Movie AtualizarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Operacao.AtualizarFilme"); 
			//<#keep(AtualizarFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarFilme)#> 
		} 

		public Movie CriarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Operacao.CriarFilme"); 
			//<#keep(CriarFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarFilme)#> 
		} 

		public MovieSession[] ListarSessoesFilme(MovieDTO Movie) 
		{ 
			using var context = EasyCineContext.Get("Operacao.ListarSessoesFilme"); 
			//<#keep(ListarSessoesFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ListarSessoesFilme)#> 
		} 

		public void RemoverSessaoFilme(int movieSessionId) 
		{ 
			using var context = EasyCineContext.Get("Operacao.RemoverSessaoFilme"); 
			//<#keep(RemoverSessaoFilme)#> 
			context.SaveChanges(); 
			//<#/keep(RemoverSessaoFilme)#> 
		} 

		public MovieSession AtualizarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Operacao.AtualizarSessaoFilme"); 
			//<#keep(AtualizarSessaoFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarSessaoFilme)#> 
		} 

		public MovieSession CriarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Operacao.CriarSessaoFilme"); 
			//<#keep(CriarSessaoFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarSessaoFilme)#> 
		} 

		public User ObterUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("Operacao.ObterUsuario"); 
			//<#keep(ObterUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ObterUsuario)#> 
		} 

		public void ExcluirUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("Operacao.ExcluirUsuario"); 
			//<#keep(ExcluirUsuario)#> 
			context.SaveChanges(); 
			//<#/keep(ExcluirUsuario)#> 
		} 

		public User AtualizarUsuario(UserDTO user) 
		{ 
			using var context = EasyCineContext.Get("Operacao.AtualizarUsuario"); 
			//<#keep(AtualizarUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarUsuario)#> 
		} 

		public Transaction[] ObterTransacoesUsuario(int usuarioId) 
		{ 
			using var context = EasyCineContext.Get("Operacao.ObterTransacoesUsuario"); 
			//<#keep(ObterTransacoesUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ObterTransacoesUsuario)#> 
		} 

		public Transaction AtualizarTransacoes(TransactionDTO transacao) 
		{ 
			using var context = EasyCineContext.Get("Operacao.AtualizarTransacoes"); 
			//<#keep(AtualizarTransacoes)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarTransacoes)#> 
		} 

		public Transaction CriarNovaTransacao(TransactionDTO transacao) 
		{ 
			using var context = EasyCineContext.Get("Operacao.CriarNovaTransacao"); 
			//<#keep(CriarNovaTransacao)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarNovaTransacao)#> 
		} 

		public Card CriarCartao(CardDTO cartao) 
		{ 
			using var context = EasyCineContext.Get("Operacao.CriarCartao"); 
			//<#keep(CriarCartao)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarCartao)#> 
		} 

		public Session CriarSessao(SessionDTO sessao) 
		{ 
			using var context = EasyCineContext.Get("Operacao.CriarSessao"); 
			//<#keep(CriarSessao)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarSessao)#> 
		} 

		public User CriarUsuario(UserDTO usuario) 
		{ 
			using var context = EasyCineContext.Get("Operacao.CriarUsuario"); 
			//<#keep(CriarUsuario)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarUsuario)#> 
		} 

		public void ExcluirCartao(int idCartao) 
		{ 
			using var context = EasyCineContext.Get("Operacao.ExcluirCartao"); 
			//<#keep(ExcluirCartao)#> 
			context.SaveChanges(); 
			//<#/keep(ExcluirCartao)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
