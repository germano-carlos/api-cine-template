//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;using EasyCine.Kernel.DTO.NSMovie; 

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
		public MovieCategory MovieCategory;
		public MovieSessionDTO MovieSession;
		public List<MovieAttachmentDTO> MovieAttachmentList = new List<MovieAttachmentDTO>();

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}