//<#keep(imports)#>
using System;
using System.Linq;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSSession;
using Microsoft.AspNetCore.Identity;

//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class MovieController
	{
		public MovieController() 
		{
		}
		
		
		public Movie AtualizarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.AtualizarFilme"); 
			//<#keep(AtualizarFilme)#> 
			var movieGet = Movie.Get(movie.MovieId);
			movieGet.Atualizar(movie);
			context.SaveChanges(); 

			return movieGet; 
			//<#/keep(AtualizarFilme)#> 
		} 

		public MovieSession AtualizarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Movie.AtualizarSessaoFilme"); 
			//<#keep(AtualizarSessaoFilme)#> 

			if (movieSession.Movie.MovieId <= 0)
				throw new Exception("Movie Id must be greater than zero !");

			var movie = Movie.Get(movieSession.Movie.MovieId);
			var session = movie.MovieSessionList.FirstOrDefault(s => s.MovieSessionId == movieSession.MovieSessionId);

			if (session is null)
				throw new Exception("The expected session was not founded !");

			session.Atualizar(movieSession);
			context.SaveChanges(); 

			return session; 
			//<#/keep(AtualizarSessaoFilme)#> 
		} 

		public Movie CriarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarFilme"); 
			//<#keep(CriarFilme)#> 
			var movieCriado = new Movie(movie);
			context.SaveChanges(); 

			return movieCriado; 
			//<#/keep(CriarFilme)#> 
		} 

		public Session CriarSessao(SessionDTO sessao) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarSessao"); 
			//<#keep(CriarSessao)#> 

			if (Session.Get(sessao.SessionHour) != null)
				throw new Exception("The session you wanted to create already Exists");
			
			var session = new Session(sessao);
			context.SaveChanges(); 

			return session; 
			//<#/keep(CriarSessao)#> 
		} 

		public MovieSession CriarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarSessaoFilme"); 
			//<#keep(CriarSessaoFilme)#> 

			var movie = Movie.Get(movieSession.Movie.MovieId);
			if (movie is null)
				throw new Exception("Movie not found, try again with another values");

			//TODO: Incluir os parametros para criaacao
			var newSession = new MovieSession();
			movie.MovieSessionList.Add(newSession);
			
			context.SaveChanges(); 
			return newSession; 
			//<#/keep(CriarSessaoFilme)#> 
		} 

		public Movie[] ListarFilmes(String Name, String Description, String Rating, DateTime? CreatedAt, DateTime? StartTime, DateTime? EndTime, ActivityStatus ActivityStatus) 
		{ 
			using var context = EasyCineContext.Get("Movie.ListarFilmes"); 
			//<#keep(ListarFilmes)#> 
			return Movie.Listar(Name, Description, Rating, CreatedAt, StartTime, EndTime, ActivityStatus); 
			//<#/keep(ListarFilmes)#> 
		} 

		public MovieSession[] ListarSessoesFilme(int movieId) 
		{ 
			using var context = EasyCineContext.Get("Movie.ListarSessoesFilme"); 
			//<#keep(ListarSessoesFilme)#> 
			
			var movieGet = Movie.Get(movieId);
			if (movieGet is null)
				throw new Exception("Movie not found, try again with another values");

			return movieGet.MovieSessionList.ToArray(); 
			//<#/keep(ListarSessoesFilme)#> 
		} 

		public void RemoverFilme(int movieId) 
		{ 
			using var context = EasyCineContext.Get("Movie.RemoverFilme"); 
			//<#keep(RemoverFilme)#> 

			Movie.Get(movieId).Inativar();
			
			context.SaveChanges(); 
			//<#/keep(RemoverFilme)#> 
		} 

		public void RemoverSessaoFilme(int movieSessionId) 
		{ 
			using var context = EasyCineContext.Get("Movie.RemoverSessaoFilme"); 
			//<#keep(RemoverSessaoFilme)#> 
			var movieGet = Movie.Get(movieSessionId);
			if (movieGet is null)
				throw new Exception("Movie not found, try again with another values");
			
			movieGet.MovieSessionList.FirstOrDefault(m => m.MovieSessionId == movieSessionId)?.Inativar();
			context.SaveChanges(); 
			//<#/keep(RemoverSessaoFilme)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
