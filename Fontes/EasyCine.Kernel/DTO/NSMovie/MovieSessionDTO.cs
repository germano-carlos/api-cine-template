//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCine.Kernel.DTO.NSSession;

//<#/keep(imports)#>

namespace EasyCine.Kernel.DTO.NSMovie
{
	public class MovieSessionDTO
	{
		public long MovieSessionId;
		public decimal? Amount;
		public ActivityStatus ActivityStatus;
		public SessionType SessionType;
		public MovieDTO Movie;
		public SessionDTO Session;
		public List<TransactionDTO> TransactionList = new List<TransactionDTO>();

		//<#keep(implements)#>
		public static MovieSessionDTO FromEntity(MovieSession element)
		{
			if (element is null)
				return new MovieSessionDTO();

			return new MovieSessionDTO()
			{
				MovieSessionId = element.MovieSessionId, 
				Amount = element.Amount, 
				ActivityStatus = element.ActivityStatus, 
				SessionType = element.SessionType,
				Session = SessionDTO.FromEntity(element.Session)
			};
		}
		
		public static List<MovieSessionDTO> FromEntity(List<MovieSession> elements)
		{
			return new List<MovieSessionDTO>(elements.Select(FromEntity));
		}
		
		public static MovieSessionDTO[] FromEntity(MovieSession[] elements)
		{
			return new List<MovieSessionDTO>(elements.Select(FromEntity)).ToArray();
		}
		//<#/keep(implements)#>
	}
}