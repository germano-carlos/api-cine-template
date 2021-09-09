//<#keep(import)#>
using EasyCine.Console.Teste;
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
        }
		public delegate void F();
		public static void Run(F f, string mensagem)
		{
			try
			{
				f();
				System.Console.WriteLine("FIM: " + mensagem);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.ToString());
			}
		}
		//<#keep(end)#><#/keep(end)#>
    }
}
