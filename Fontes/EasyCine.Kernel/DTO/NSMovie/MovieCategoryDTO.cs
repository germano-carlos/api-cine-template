//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.Model.NSMovie;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSMovie
{
	public class MovieCategoryDTO
	{
		public long MovieCategoryId;
		public Category Category;
		public MovieDTO Movie;

		//<#keep(implements)#>
		public static MovieCategoryDTO FromEntity(MovieCategory element)
		{
			if (element is null)
				return new MovieCategoryDTO();

			return new MovieCategoryDTO()
			{
				Category = element.Category,
				MovieCategoryId = element.MovieCategoryId
			};
		}

		public static List<MovieCategoryDTO> FromEntity(List<MovieCategory> element)
		{
			return new List<MovieCategoryDTO>(element.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}