//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using EasyCine.Kernel.DTO.NSMovie; 

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
		//<#/keep(implements)#>
	}
}