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

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}