//<#keep(imports)#>
using System;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSSession;
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
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarFilme)#> 
		} 

		public MovieSession AtualizarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Movie.AtualizarSessaoFilme"); 
			//<#keep(AtualizarSessaoFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(AtualizarSessaoFilme)#> 
		} 

		public Movie CriarFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarFilme"); 
			//<#keep(CriarFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarFilme)#> 
		} 

		public Session CriarSessao(SessionDTO sessao) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarSessao"); 
			//<#keep(CriarSessao)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarSessao)#> 
		} 

		public MovieSession CriarSessaoFilme(MovieSessionDTO movieSession) 
		{ 
			using var context = EasyCineContext.Get("Movie.CriarSessaoFilme"); 
			//<#keep(CriarSessaoFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarSessaoFilme)#> 
		} 

		public Movie[] ListarFilmes(String Name, String Description, String Rating, DateTime CreatedAt, DateTime StartTime, DateTime EndTime, ActivityStatus ActivityStatus) 
		{ 
			using var context = EasyCineContext.Get("Movie.ListarFilmes"); 
			//<#keep(ListarFilmes)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ListarFilmes)#> 
		} 

		public MovieSession[] ListarSessoesFilme(MovieDTO Movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.ListarSessoesFilme"); 
			//<#keep(ListarSessoesFilme)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(ListarSessoesFilme)#> 
		} 

		public void RemoverFilme(MovieDTO movie) 
		{ 
			using var context = EasyCineContext.Get("Movie.RemoverFilme"); 
			//<#keep(RemoverFilme)#> 
			context.SaveChanges(); 
			//<#/keep(RemoverFilme)#> 
		} 

		public void RemoverSessaoFilme(int movieSessionId) 
		{ 
			using var context = EasyCineContext.Get("Movie.RemoverSessaoFilme"); 
			//<#keep(RemoverSessaoFilme)#> 
			context.SaveChanges(); 
			//<#/keep(RemoverSessaoFilme)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
