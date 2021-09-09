﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CMUtil.CMException;
using CMUtil.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EasyCine.AWSServerless.Facade
{
	public class FacadeBase : Controller
	{
		[HttpGet]
		public ObjectResult Erro(string mensagem, Exception e)
		{
			if (e is BException)
				Log.Logar(mensagem, e, ((BException)e).codigo, ((BException)e).codigoClienteCM);
			else
				Log.Logar(mensagem, e, CodigoLog.Erro);
			return base.StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
		}		
		public override JsonResult Json(object data)
		{
			return base.Json(data, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
		}
	}
}
