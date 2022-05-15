
//<#keep(imports)#>
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model.NSGeneric;

//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Operacao")]	
	[Produces("application/json")]
	public class OperacaoFacade : FacadeBase
	{
		public OperacaoFacade() 
		{
		}
		
		
		[HttpPost, Route("FuncaoTeste")] 
		public ActionResult FuncaoTeste([FromForm] int a, [FromForm] string b) 
		{ 
			try 
			{
				 
				//<#keep(FuncaoTeste)#> 
				object ret = new Kernel.Controllers.OperacaoController().FuncaoTeste(a, b); 
				return Json(ret); 
				//<#/keep(FuncaoTeste)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.FuncaoTeste", e); 
			} 
		}

		[HttpPost, Route("ListarFilmes")] 
		public ActionResult ListarFilmes([FromForm] String Name, [FromForm] String Description, [FromForm] String Rating, [FromForm] DateTime CreatedAt, [FromForm] DateTime StartTime, [FromForm] DateTime EndTime, [FromForm] ActivityStatus ActivityStatus) 
		{ 
			try 
			{
				 
				//<#keep(ListarFilmes)#> 
				object ret = new Kernel.Controllers.OperacaoController().ListarFilmes(Name, Description, Rating, CreatedAt, StartTime, EndTime, ActivityStatus); 
				return Json(ret); 
				//<#/keep(ListarFilmes)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.ListarFilmes", e); 
			} 
		}

		[HttpPost, Route("RemoverFilme")] 
		public ActionResult RemoverFilme([FromBody] MovieDTO movie) 
		{ 
			try 
			{
				 
				//<#keep(RemoverFilme)#> 
				new Kernel.Controllers.OperacaoController().RemoverFilme(movie); 
				return Ok(); 
				//<#/keep(RemoverFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.RemoverFilme", e); 
			} 
		}

		[HttpPost, Route("AtualizarFilme")] 
		public ActionResult AtualizarFilme([FromBody] MovieDTO movie) 
		{ 
			try 
			{
				 
				//<#keep(AtualizarFilme)#> 
				object ret = new Kernel.Controllers.OperacaoController().AtualizarFilme(movie); 
				return Json(ret); 
				//<#/keep(AtualizarFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.AtualizarFilme", e); 
			} 
		}

		[HttpPost, Route("CriarFilme")] 
		public ActionResult CriarFilme([FromBody] MovieDTO movie) 
		{ 
			try 
			{
				 
				//<#keep(CriarFilme)#> 
				object ret = new Kernel.Controllers.OperacaoController().CriarFilme(movie); 
				return Json(ret); 
				//<#/keep(CriarFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.CriarFilme", e); 
			} 
		}

		[HttpPost, Route("ListarSessoesFilme")] 
		public ActionResult ListarSessoesFilme([FromBody] MovieDTO Movie) 
		{ 
			try 
			{
				 
				//<#keep(ListarSessoesFilme)#> 
				object ret = new Kernel.Controllers.OperacaoController().ListarSessoesFilme(Movie); 
				return Json(ret); 
				//<#/keep(ListarSessoesFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.ListarSessoesFilme", e); 
			} 
		}

		[HttpPost, Route("RemoverSessaoFilme")] 
		public ActionResult RemoverSessaoFilme([FromForm] int movieSessionId) 
		{ 
			try 
			{
				 
				//<#keep(RemoverSessaoFilme)#> 
				new Kernel.Controllers.OperacaoController().RemoverSessaoFilme(movieSessionId); 
				return Ok(); 
				//<#/keep(RemoverSessaoFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.RemoverSessaoFilme", e); 
			} 
		}

		[HttpPost, Route("AtualizarSessaoFilme")] 
		public ActionResult AtualizarSessaoFilme([FromBody] MovieSessionDTO movieSession) 
		{ 
			try 
			{
				 
				//<#keep(AtualizarSessaoFilme)#> 
				object ret = new Kernel.Controllers.OperacaoController().AtualizarSessaoFilme(movieSession); 
				return Json(ret); 
				//<#/keep(AtualizarSessaoFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.AtualizarSessaoFilme", e); 
			} 
		}

		[HttpPost, Route("CriarSessaoFilme")] 
		public ActionResult CriarSessaoFilme([FromBody] MovieSessionDTO movieSession) 
		{ 
			try 
			{
				 
				//<#keep(CriarSessaoFilme)#> 
				object ret = new Kernel.Controllers.OperacaoController().CriarSessaoFilme(movieSession); 
				return Json(ret); 
				//<#/keep(CriarSessaoFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.CriarSessaoFilme", e); 
			} 
		}

		[HttpPost, Route("ObterUsuario")] 
		public ActionResult ObterUsuario([FromForm] int usuarioId) 
		{ 
			try 
			{
				 
				//<#keep(ObterUsuario)#> 
				object ret = new Kernel.Controllers.OperacaoController().ObterUsuario(usuarioId); 
				return Json(ret); 
				//<#/keep(ObterUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.ObterUsuario", e); 
			} 
		}

		[HttpPost, Route("ExcluirUsuario")] 
		public ActionResult ExcluirUsuario([FromForm] int usuarioId) 
		{ 
			try 
			{
				 
				//<#keep(ExcluirUsuario)#> 
				new Kernel.Controllers.OperacaoController().ExcluirUsuario(usuarioId); 
				return Ok(); 
				//<#/keep(ExcluirUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.ExcluirUsuario", e); 
			} 
		}

		[HttpPost, Route("AtualizarUsuario")] 
		public ActionResult AtualizarUsuario([FromBody] UserDTO user) 
		{ 
			try 
			{
				 
				//<#keep(AtualizarUsuario)#> 
				object ret = new Kernel.Controllers.OperacaoController().AtualizarUsuario(user); 
				return Json(ret); 
				//<#/keep(AtualizarUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.AtualizarUsuario", e); 
			} 
		}

		[HttpPost, Route("ObterTransacoesUsuario")] 
		public ActionResult ObterTransacoesUsuario([FromForm] int usuarioId) 
		{ 
			try 
			{
				 
				//<#keep(ObterTransacoesUsuario)#> 
				object ret = new Kernel.Controllers.OperacaoController().ObterTransacoesUsuario(usuarioId); 
				return Json(ret); 
				//<#/keep(ObterTransacoesUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.ObterTransacoesUsuario", e); 
			} 
		}

		[HttpPost, Route("AtualizarTransacoes")] 
		public ActionResult AtualizarTransacoes([FromBody] TransactionDTO transacao) 
		{ 
			try 
			{
				 
				//<#keep(AtualizarTransacoes)#> 
				object ret = new Kernel.Controllers.OperacaoController().AtualizarTransacoes(transacao); 
				return Json(ret); 
				//<#/keep(AtualizarTransacoes)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.AtualizarTransacoes", e); 
			} 
		}

		[HttpPost, Route("CriarNovaTransacao")] 
		public ActionResult CriarNovaTransacao([FromBody] TransactionDTO transacao) 
		{ 
			try 
			{
				 
				//<#keep(CriarNovaTransacao)#> 
				object ret = new Kernel.Controllers.OperacaoController().CriarNovaTransacao(transacao); 
				return Json(ret); 
				//<#/keep(CriarNovaTransacao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.CriarNovaTransacao", e); 
			} 
		}

		[HttpPost, Route("CriarCartao")] 
		public ActionResult CriarCartao([FromBody] CardDTO cartao) 
		{ 
			try 
			{
				 
				//<#keep(CriarCartao)#> 
				object ret = new Kernel.Controllers.OperacaoController().CriarCartao(cartao); 
				return Json(ret); 
				//<#/keep(CriarCartao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.CriarCartao", e); 
			} 
		}

		[HttpPost, Route("CriarSessao")] 
		public ActionResult CriarSessao([FromBody] SessionDTO sessao) 
		{ 
			try 
			{
				 
				//<#keep(CriarSessao)#> 
				object ret = new Kernel.Controllers.OperacaoController().CriarSessao(sessao); 
				return Json(ret); 
				//<#/keep(CriarSessao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.CriarSessao", e); 
			} 
		}

		[HttpPost, Route("CriarUsuario")] 
		public ActionResult CriarUsuario([FromBody] UserDTO usuario) 
		{ 
			try 
			{
				 
				//<#keep(CriarUsuario)#> 
				object ret = new Kernel.Controllers.OperacaoController().CriarUsuario(usuario); 
				return Json(ret); 
				//<#/keep(CriarUsuario)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.CriarUsuario", e); 
			} 
		}

		[HttpPost, Route("ExcluirCartao")] 
		public ActionResult ExcluirCartao([FromForm] int idCartao) 
		{ 
			try 
			{
				 
				//<#keep(ExcluirCartao)#> 
				new Kernel.Controllers.OperacaoController().ExcluirCartao(idCartao); 
				return Ok(); 
				//<#/keep(ExcluirCartao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Operacao.ExcluirCartao", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
