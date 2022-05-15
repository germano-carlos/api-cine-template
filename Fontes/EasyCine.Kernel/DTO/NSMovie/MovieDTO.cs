//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSMovie
{
	public class MovieDTO
	{
		public long MovieId;
		public String Name;
		public String Description;
		public String Rating;
		public DateTime CreatedAt;
		public DateTime StartTime;
		public DateTime EndTime;
		public ActivityStatus ActivityStatus;
		public List<MovieAttachmentDTO> MovieAttachmentList = new List<MovieAttachmentDTO>();
		public List<MovieSessionDTO> MovieSessionList = new List<MovieSessionDTO>();
		public List<MovieCategoryDTO> MovieCategoryList = new List<MovieCategoryDTO>();

		//<#keep(implements)#>
		public static MovieDTO FromEntity(Movie movie)
		{
			return new MovieDTO()
			{
				MovieId = movie.MovieId,
				Name = movie.Name,
				Description = movie.Description,
				Rating = movie.Rating,
				CreatedAt = movie.CreatedAt,
				StartTime = movie.StartTime,
				EndTime = movie.EndTime,
				ActivityStatus = movie.ActivityStatus,
				/*MovieAttachmentList = MovieAttachmentDTO.FromEntity(),
				MovieSessionList = MovieSessionDTO.FromEntity(),
				MovieCategoryList = MovieCategoryDTO.FromEntity(),*/
			};
		}
		//<#/keep(implements)#>
	}
}