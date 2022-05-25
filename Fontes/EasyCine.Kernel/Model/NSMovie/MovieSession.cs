//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSSession;
using EasyCine.Kernel.Model.NSTransaction;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("MovieSessions")]
	public sealed class MovieSession
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie_session", TypeName = "BIGINT")] public long MovieSessionId { get; set; } 
		[Column("amount", TypeName = "decimal(10, 2)")] public decimal? Amount { get; set; } 
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[Column("id_session_type", TypeName = "INT"), Required] public SessionType SessionType { get; set; }
		[Column("MovieId", TypeName = "BIGINT"), ForeignKey("Movie")] public long MovieId { get; set; } 
		public Movie Movie { get; set; } 
		[Column("id_session", TypeName = "INT"), ForeignKey("Session")] public int id_session { get; set; } 
		public Session Session { get; set; } 
		[InverseProperty("MovieSession")] public List<Transaction> TransactionList { get; set; }  // ICollection 

		public MovieSession() { }
		//<#keep(constructor)#>
		public MovieSession(MovieSessionDTO parameters, Session session, Movie movie)
		{
			Atualizar(parameters);
			Movie = movie;
			Session = session;

			EasyCineContext.Get().MovieSessionSet.Add(this);
		}
		//<#/keep(constructor)#>
		internal void Delete()
		{
			//<#keep(delete)#>
			EasyCineContext.Get().MovieSessionSet.Remove(this);
			//<#/keep(delete)#>
		}
		//<#keep(implements)#>
		public void Atualizar(MovieSessionDTO movieSession)
		{
			Amount = movieSession.Amount ?? Amount;
			ActivityStatus = movieSession.ActivityStatus;
			SessionType = movieSession.SessionType;

			if (this.Session != null || this.Movie != null)
				throw new Exception("It is not possibile to do this operation, please create another movie to do this !");
		}

		public static MovieSession Get(long id)
		{
			return EasyCineContext.Get().MovieSessionSet.Include(s => s.TransactionList).FirstOrDefault(s => s.MovieSessionId == id);
		}

		public void Inativar()
		{
			if(ActivityStatus == ActivityStatus.INACTIVE)
				throw new Exception("MovieSession Already Inactive");

			ActivityStatus = ActivityStatus.INACTIVE;
		}
		//<#/keep(implements)#>
	}
}