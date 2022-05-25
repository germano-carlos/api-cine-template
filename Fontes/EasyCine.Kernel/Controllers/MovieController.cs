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
		
		
		public MovieDTO AtualizarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.AtualizarFilme"); 
			//<#keep(AtualizarFilme)#> 
			var movieGet = Movie.Get(movie.MovieId);
			movieGet.Atualizar(movie);
			context.SaveChanges(); 

			return MovieDTO.FromEntity(movieGet); 
			//<#/keep(AtualizarFilme)#> 
		} 

		public MovieSessionDTO AtualizarSessaoFilme(MovieSessionDTO movieSession) 
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

			return MovieSessionDTO.FromEntity(session); 
			//<#/keep(AtualizarSessaoFilme)#> 
		} 

		public MovieDTO CriarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarFilme"); 
			//<#keep(CriarFilme)#> 
			var movieCriado = new Movie(movie);
			context.SaveChanges(); 

			return MovieDTO.FromEntity(movieCriado); 
			//<#/keep(CriarFilme)#> 
		} 
		
		public MovieDTO ObterFilme(long movieId) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarFilme"); 
			//<#keep(CriarFilme)#> 
			return MovieDTO.FromEntity(Movie.Get(movieId)); 
			//<#/keep(CriarFilme)#> 
		} 

		public SessionDTO CriarSessao(SessionDTO sessao) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarSessao"); 
			//<#keep(CriarSessao)#> 

			if (Session.Get(sessao.SessionHour) != null)
				throw new Exception("The session you wanted to create already Exists");
			
			var session = new Session(sessao);
			context.SaveChanges(); 

			return SessionDTO.FromEntity(session); 
			//<#/keep(CriarSessao)#> 
		} 

		public MovieSessionDTO CriarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarSessaoFilme"); 
			//<#keep(CriarSessaoFilme)#> 

			var movie = Movie.Get(movieSession.Movie.MovieId);
			var sessao = Session.Get(movieSession.Session.SessionHour);
			if (movie is null)
				throw new Exception("Movie not found, try again with another values");
			if (sessao is null)
				throw new Exception("Session not found, try again with another values");
			
			var newSession = new MovieSession(movieSession, sessao, movie);
			movie.MovieSessionList.Add(newSession);
			
			context.SaveChanges(); 
			return MovieSessionDTO.FromEntity(newSession); 
			//<#/keep(CriarSessaoFilme)#> 
		} 

		public MovieDTO[] ListarFilmes(String Name, String Description, String Rating, DateTime? CreatedAt, DateTime? StartTime, DateTime? EndTime, ActivityStatus ActivityStatus) 
		{ 
			using var context = EasyCineContext.Get("Movie.ListarFilmes"); 
			//<#keep(ListarFilmes)#> 
			return MovieDTO.FromEntity(Movie.Listar(Name, Description, Rating, CreatedAt, StartTime, EndTime, ActivityStatus)); 
			//<#/keep(ListarFilmes)#> 
		} 

		public MovieSessionDTO[] ListarSessoesFilme(long movieId) 
		{ 
			using var context = EasyCineContext.Get("Movie.ListarSessoesFilme"); 
			//<#keep(ListarSessoesFilme)#> 
			
			var movieGet = Movie.Get(movieId);
			if (movieGet is null)
				throw new Exception("Movie not found, try again with another values");

			return MovieSessionDTO.FromEntity(movieGet.MovieSessionList.ToArray()); 
			//<#/keep(ListarSessoesFilme)#> 
		} 

		public void RemoverFilme(long movieId) 
		{ 
			using var context = EasyCineContext.Get("Movie.RemoverFilme"); 
			//<#keep(RemoverFilme)#> 

			Movie.Get(movieId).Inativar();
			
			context.SaveChanges(); 
			//<#/keep(RemoverFilme)#> 
		} 

		public void RemoverSessaoFilme(long movieSessionId) 
		{ 
			using var context = EasyCineContext.Get("Movie.RemoverSessaoFilme"); 
			//<#keep(RemoverSessaoFilme)#> 
			
			var movieGet = MovieSession.Get(movieSessionId);
			if (movieGet is null)
				throw new Exception("Movie not found, try again with another values");
			
			movieGet.Inativar();
			context.SaveChanges(); 
			//<#/keep(RemoverSessaoFilme)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
