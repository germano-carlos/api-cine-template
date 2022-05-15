//<#keep(imports)#>
using System;
using System.Collections.Generic;
using System.Text;
using EasyCine.Kernel.Model.NSGeneric;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSGeneric
{
	public class LogDTO
	{
		public long id_log;
		public String Descricao;
		public DateTime CreatedAt;
		public String StackTrace;
		public TypeLog TypeLog;

		//<#keep(implements)#>
		//<#/keep(implements)#>
	}
}