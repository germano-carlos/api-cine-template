//<#keep(imports)#>

using System.Collections.Generic;
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
		
		
		public CardDTO CriarCartao(CardDTO cartao) 
		{ 
			using var context = EasyCineContext.Get("Card.CriarCartao"); 
			//<#keep(CriarCartao)#> 
			var cartaoGerado = new Card(cartao);
			context.SaveChanges(); 
			return CardDTO.FromEntity(cartaoGerado); 
			//<#/keep(CriarCartao)#> 
		} 

		public void ExcluirCartao(long idCartao) 
		{ 
			using var context = EasyCineContext.Get("Card.ExcluirCartao"); 
			//<#keep(ExcluirCartao)#> 
			Card.Get(idCartao).Inativar();
			context.SaveChanges(); 
			//<#/keep(ExcluirCartao)#> 
		} 
		
		public List<CardDTO> ListarCartoes(long idUsuario) 
		{ 
			using var context = EasyCineContext.Get("Card.ExcluirCartao"); 
			//<#keep(ExcluirCartao)#> 
			return CardDTO.FromEntity(Card.Listar(idUsuario));
			//<#/keep(ExcluirCartao)#> 
		} 

		//<#keep(implementation)#><#/keep(implementation)#>
	}
}
