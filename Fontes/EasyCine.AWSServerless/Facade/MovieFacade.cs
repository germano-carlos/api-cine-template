
//<#keep(imports)#>
using System;
using Microsoft.AspNetCore.Mvc;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.Model.NSGeneric;

//<#/keep(imports)#>

namespace EasyCine.AWSServerless.Facade
{
	[ApiController]    
    [Route("api/v1/Movie")]	
	[Produces("application/json")]
	public class MovieFacade : FacadeBase
	{
		public MovieFacade() 
		{
		}
		
		
		[HttpPost, Route("AtualizarFilme")] 
		public ActionResult AtualizarFilme([FromBody] MovieDTO movie) 
		{ 
			try 
			{
				//<#keep(AtualizarFilme)#> 
				object ret = new Kernel.Controllers.MovieController().AtualizarFilme(movie); 
				return Json(ret); 
				//<#/keep(AtualizarFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.AtualizarFilme", e); 
			} 
		}

		[HttpPost, Route("AtualizarSessaoFilme")] 
		public ActionResult AtualizarSessaoFilme([FromBody] MovieSessionDTO movieSession) 
		{ 
			try 
			{
				//<#keep(AtualizarSessaoFilme)#> 
				object ret = new Kernel.Controllers.MovieController().AtualizarSessaoFilme(movieSession); 
				return Json(ret); 
				//<#/keep(AtualizarSessaoFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.AtualizarSessaoFilme", e); 
			} 
		}

		[HttpPost, Route("CriarFilme")] 
		public ActionResult CriarFilme([FromBody] MovieDTO movie) 
		{ 
			try 
			{
				//<#keep(CriarFilme)#> 
				object ret = new Kernel.Controllers.MovieController().CriarFilme(movie); 
				return Json(ret); 
				//<#/keep(CriarFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.CriarFilme", e); 
			} 
		}

		[HttpPost, Route("CriarSessao")] 
		public ActionResult CriarSessao([FromBody] SessionDTO sessao) 
		{ 
			try 
			{
				//<#keep(CriarSessao)#> 
				object ret = new Kernel.Controllers.MovieController().CriarSessao(sessao); 
				return Json(ret); 
				//<#/keep(CriarSessao)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.CriarSessao", e); 
			} 
		}

		[HttpPost, Route("CriarSessaoFilme")] 
		public ActionResult CriarSessaoFilme([FromBody] MovieSessionDTO movieSession) 
		{ 
			try 
			{
				 
				//<#keep(CriarSessaoFilme)#> 
				object ret = new Kernel.Controllers.MovieController().CriarSessaoFilme(movieSession); 
				return Json(ret); 
				//<#/keep(CriarSessaoFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.CriarSessaoFilme", e); 
			} 
		}

		[HttpPost, Route("ListarFilmes")] 
		public ActionResult ListarFilmes([FromForm] String Name, [FromForm] String Description, [FromForm] String Rating, [FromForm] DateTime? CreatedAt, [FromForm] DateTime? StartTime, [FromForm] DateTime? EndTime, [FromForm] ActivityStatus ActivityStatus) 
		{ 
			try 
			{
				//<#keep(ListarFilmes)#> 
				object ret = new Kernel.Controllers.MovieController().ListarFilmes(Name, Description, Rating, CreatedAt, StartTime, EndTime, ActivityStatus); 
				return Json(ret); 
				//<#/keep(ListarFilmes)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.ListarFilmes", e); 
			} 
		}

		[HttpPost, Route("ListarSessoesFilme")] 
		public ActionResult ListarSessoesFilme([FromForm] int movieId) 
		{ 
			try 
			{
				//<#keep(ListarSessoesFilme)#> 
				object ret = new Kernel.Controllers.MovieController().ListarSessoesFilme(movieId); 
				return Json(ret); 
				//<#/keep(ListarSessoesFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.ListarSessoesFilme", e); 
			} 
		}

		[HttpPost, Route("RemoverFilme")] 
		public ActionResult RemoverFilme([FromForm] int movieId) 
		{ 
			try 
			{
				//<#keep(RemoverFilme)#> 
				new Kernel.Controllers.MovieController().RemoverFilme(movieId); 
				return Ok(); 
				//<#/keep(RemoverFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.RemoverFilme", e); 
			} 
		}

		[HttpPost, Route("RemoverSessaoFilme")] 
		public ActionResult RemoverSessaoFilme([FromForm] int movieSessionId) 
		{ 
			try 
			{
				//<#keep(RemoverSessaoFilme)#> 
				new Kernel.Controllers.MovieController().RemoverSessaoFilme(movieSessionId); 
				return Ok(); 
				//<#/keep(RemoverSessaoFilme)#> 
			} 
			catch (Exception e) 
			{ 
				return Erro("EasyCine.Movie.RemoverSessaoFilme", e); 
			} 
		}

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
