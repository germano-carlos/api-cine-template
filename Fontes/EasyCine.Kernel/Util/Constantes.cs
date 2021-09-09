//<#keep(import)#>
using CMUtil.CMException;
using CMUtil.Configuracao;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
//<#/keep(import)#>

namespace EasyCine.Kernel.Util
{
	public class Constantes
	{
		//<#keep(conteudo)#>
		internal static CodigoLog ErroUrl = new CodigoLog(101);
		internal static CodigoLog ErroEmail = new CodigoLog(102);
		internal static CodigoLog ErroSMS = new CodigoLog(103);
		internal static CodigoLog ErroWhatsapp = new CodigoLog(104);
		public static string urlSend = Config.Read("AppSettings:CMSend:Url");
		//<#/keep(conteudo)#>
	}
}
