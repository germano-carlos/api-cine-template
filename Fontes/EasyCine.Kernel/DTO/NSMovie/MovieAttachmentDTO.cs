//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.Model.NSMovie;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSMovie
{
	public class MovieAttachmentDTO
	{
		public long MovieAttachmentId;
		public String Url;
		public AttachmentType AttachmentType;
		public MovieDTO Movie;

		//<#keep(implements)#>
		public static MovieAttachmentDTO FromEntity(MovieAttachment element)
		{
			if (element is null)
				return new MovieAttachmentDTO();

			return new MovieAttachmentDTO()
			{
				MovieAttachmentId = element.MovieAttachmentId, 
				Url = element.Url, 
				AttachmentType = element.AttachmentType,
			};
		}

		public static List<MovieAttachmentDTO> FromEntity(List<MovieAttachment> element)
		{
			return new List<MovieAttachmentDTO>(element.Select(FromEntity));
		}
		//<#/keep(implements)#>
	}
}