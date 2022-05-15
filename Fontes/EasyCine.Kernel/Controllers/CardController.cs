//<#keep(imports)#>
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model;
using EasyCine.Kernel.Model.NSTransaction;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Controllers
{
	public class CardController
	{
		public CardController() 
		{
		}
		
		
		public Card CriarCartao(CardDTO cartao) 
		{ 
			using var context = EasyCineContext.Get("Card.CriarCartao"); 
			//<#keep(CriarCartao)#> 
			context.SaveChanges(); 
			return null; 
			//<#/keep(CriarCartao)#> 
		} 

		public void ExcluirCartao(int idCartao) 
		{ 
			using var context = EasyCineContext.Get("Card.ExcluirCartao"); 
			//<#keep(ExcluirCartao)#> 
			context.SaveChanges(); 
			//<#/keep(ExcluirCartao)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
