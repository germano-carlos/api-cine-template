//<#keep(imports)#>
using System;
using System.Collections.Generic;
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
		//<#/keep(implements)#>
	}
}