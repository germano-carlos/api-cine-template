using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EasyCine.Kernel.Controllers;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSTransaction;
using Newtonsoft.Json;
using Xunit;

namespace EasyCine.Tests;

public class TransactionTests
{
	private TransactionController _transactionController;
	private MovieController _movieController;
	private CardController _cardController;
	private UserController _userController;

	public TransactionTests()
	{
		_transactionController = new TransactionController();
		_cardController = new CardController();
		_movieController = new MovieController();
		_userController = new UserController();
	}
	
	[Fact]
	public void CriarNovaTransacao()
	{
		var usuario = _userController.ObterUsuario(5);
		var card = _cardController.ListarCartoes(usuario.UserId);
		var sessoes = _movieController.ListarSessoesFilme(28);

		var dto = new TransactionDTO()
		{
			TransactionStatus = TransactionStatus.WAITING,
			MovieSession = sessoes.First(),
			User = usuario,
			Card = card.First(),
			ItemList = new List<ItemDTO>()
			{
				new ItemDTO()
				{
					Amount = 10,
					Name = "Ingresso Hotwheels Pista Tubarão (MEIA)",
					Seat = "H7"
				},
				new ItemDTO()
				{
					Amount = 10,
					Name = "Ingresso Hotwheels Pista Tubarão (MEIA)",
					Seat = "H8"
				}
			}
		};

		var criarTransacao = _transactionController.CriarNovaTransacao(dto);
		dto.CreatedAt = criarTransacao.CreatedAt;
		dto.TransactionId = criarTransacao.TransactionId;
		criarTransacao.MovieSession.Session = dto.MovieSession.Session;
		dto.ItemList.ForEach((item) =>
		{
			item.ItemId = criarTransacao.ItemList.FirstOrDefault(s => s.Seat == item.Seat)!.ItemId;
		});
		
		var t_serialized = JsonConvert.SerializeObject(dto);
		var c_serialized = JsonConvert.SerializeObject(criarTransacao);
        
		Assert.Equal(t_serialized, c_serialized);
	}

	[Theory]
	[InlineData(5)]
	[InlineData(6)]
	[InlineData(7)]
	public void ObterTransacao(long idUsuario)
	{
		var t = _transactionController.ObterTransacoesUsuario(idUsuario).ToList();
		Assert.True(t.Count(s => s.User.UserId == idUsuario) == t.Count);
	}

}