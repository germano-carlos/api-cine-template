//<#keep(import)#>
using EasyCine.Console.Teste;
using CMUtil.CMException;
using CMUtil.Configuracao;
using CMUtil.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
//<#/keep(import)#>


namespace EasyCine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
			Config.Registry(new AppConfig());
			
			//<#keep(main)#>
			
			//Run(CaminhoFeliz.Run, "CaminhoFeliz");

			//<#/keep(main)#>

			Log.Logar("Fim dos testes com sucesso.", CodigoLog.Teste);
			System.Console.Read();
        }
		public delegate void F();
		public static void Run(F f, string mensagem)
		{
			Log.Logar("INICIO: "+mensagem, CodigoLog.Teste);
			try
			{
				f();
				System.Console.WriteLine("FIM: " + mensagem);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.ToString());
				Log.Logar("FIM COM ERRO: " + mensagem, e, CodigoLog.Teste);
			}
		}
		//<#keep(end)#><#/keep(end)#>
    }
}
