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
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

//<#/keep(imports)#>

namespace EasyCine.Kernel.Model.NSMovie
{
	[Table("Movies")]
	public sealed class Movie
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id_movie", TypeName = "BIGINT")] public long MovieId { get; set; } 
		[Column("name", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Name { get; set; } 
		[Column("ds_movie", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string Description { get; set; } 
		[Column("rating", TypeName = "VARCHAR(4)"), MaxLength(4), Required] public string Rating { get; set; } 
		[Column("created_at", TypeName = "DATETIME"), Required] public DateTime CreatedAt { get; set; } 
		[Column("start_time", TypeName = "DATETIME"), Required] public DateTime StartTime { get; set; } 
		[Column("end_time", TypeName = "DATETIME"), Required] public DateTime EndTime { get; set; } 
		[Column("id_status", TypeName = "INT"), Required] public ActivityStatus ActivityStatus { get; set; }
		[InverseProperty("Movie")] public List<MovieAttachment> MovieAttachmentList { get; set; }  // ICollection 
		[InverseProperty("Movie")] public List<MovieSession> MovieSessionList { get; set; }  // ICollection 
		[InverseProperty("Movie")] public List<MovieCategory> MovieCategoryList { get; set; }  // ICollection 

		//<#keep(constructor)#>
		public Movie() { }
		public Movie(MovieDTO movieP)
		{
			Atualizar(movieP);
			
			CreatedAt = DateTime.Now; 
		 	ActivityStatus = ActivityStatus.ACTIVE;
		    MovieAttachmentList = new List<MovieAttachment>();
		    MovieSessionList = new List<MovieSession>();
		    MovieCategoryList = new List<MovieCategory>();
		    
		    foreach (var movieAttachmentElement in movieP.MovieAttachmentList)
			    new MovieAttachment(movieAttachmentElement, this);
		    foreach (var movieCategoryElement in movieP.MovieCategoryList)
			    new MovieCategory(movieCategoryElement.Category, this);
		    foreach (var movieSessionElement in movieP.MovieSessionList)
		    {
			    var session = Session.Get(movieSessionElement.Session.SessionHour);
			    if (session is null)
				    throw new Exception("It was not possibile create the filme, because the sessionHour is invalid !");
			    
			    new MovieSession(movieSessionElement, session, this);
		    }
		}
		//<#/keep(constructor)#>

		//<#keep(implements)#>
		public static Movie Get(long movieId)
		{
			return (from m in EasyCineContext.Get().MovieSet
					.Include(m => m.MovieSessionList).ThenInclude(mm => mm.Session)
					.Include(mmm => mmm.MovieAttachmentList)
					.Include(mmmm => mmmm.MovieCategoryList)
				where m.MovieId == movieId
				select m).FirstOrDefault();
		}
		
		public void Atualizar(MovieDTO movieP)
		{
			Name = movieP.Name; 
			Description = movieP.Description; 
			Rating = movieP.Rating; 
			StartTime = movieP.StartTime; 
			EndTime = movieP.EndTime; 
			ActivityStatus = movieP.ActivityStatus;
		}

		public static Movie[] Listar(String name, String description, String rating, DateTime? createdAt, DateTime? startTime, DateTime? endTime, ActivityStatus activityStatus)
		{
			return (from m in EasyCineContext.Get().MovieSet
						.Include(m => m.MovieSessionList).ThenInclude(m => m.Session)
						.Include(m => m.MovieAttachmentList)
						.Include(m => m.MovieCategoryList)
					where (string.IsNullOrWhiteSpace(name) || m.Name.Contains(name)) &&
					      (string.IsNullOrWhiteSpace(description) || m.Description.Contains(description)) &&
					      (string.IsNullOrWhiteSpace(rating) || m.Rating.Contains(rating)) &&
					      (!createdAt.HasValue || m.CreatedAt.Date == createdAt.Value.Date) &&
					      (!startTime.HasValue || m.StartTime.Date == startTime.Value.Date) &&
					      (!endTime.HasValue || m.EndTime.Date == endTime.Value.Date) &&
					      (m.ActivityStatus == activityStatus)
					select m).ToArray();
		}

		public void Inativar()
		{
			if (ActivityStatus == ActivityStatus.INACTIVE)
				throw new Exception("Movie Already Inactive");
			
			MovieSessionList.ForEach(m => m.Inativar());
			ActivityStatus = ActivityStatus.INACTIVE;
		}
		//<#/keep(implements)#>
	}
}