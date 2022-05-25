using System;
using System.Collections.Generic;
using System.Linq;
using EasyCine.Kernel.Controllers;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSUser;
using Newtonsoft.Json;
using Xunit;

namespace EasyCine.Tests;

public class CardTests
{
    private readonly CardController _controller; 
    public CardTests()
    {
        _controller = new CardController();
    }

    [Fact]
    public void CriarNovoCartao()
    {
        var usuario_d = new UserDTO()
        {
            Name = "Carlos Germano Avelar Carvalho",
            Email = "carlos@enterprise.com.br",
            Password = "batatinha1234",
            CreatedAt = DateTime.Now,
            UserType = UserType.USER,
            ActivityStatus = ActivityStatus.ACTIVE,
            CardList = new List<CardDTO>(),
            TransactionList = new List<TransactionDTO>()
        };

        var usuario_c = new UserController().CriarUsuario(usuario_d);

        var cartao_d = new CardDTO()
        {
            HolderName = "CARLOS G A CARVALHO",
            CardNumber = "5117659862365698",
            SecurityCode = "029",
            ExpirationDate = new DateTime(2029,06,30),
            ActivityStatus = ActivityStatus.ACTIVE,
            User = usuario_c,
            TransactionList = new List<TransactionDTO>()
        };

        var card_criar = _controller.CriarCartao(cartao_d);
        cartao_d.CardId = card_criar.CardId;
        card_criar.User.CreatedAt = usuario_c.CreatedAt;

        var cartao_ex_serialized = JsonConvert.SerializeObject(cartao_d);
        var cartao_cri_serialized = JsonConvert.SerializeObject(card_criar);
        
        Assert.Equal(cartao_ex_serialized, cartao_cri_serialized);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(6)]
    public void ListarCartoes(int usuarioId)
    {
        var cartoes = _controller.ListarCartoes(usuarioId).ToList();
        Assert.True(cartoes.Count(s => s.User.UserId == usuarioId) == cartoes.Count);
    }

    [Fact]
    public void InativarCartao()
    {
        var usuario_d = new UserDTO()
        {
            Name = "Carlos Germano Avelar Carvalho",
            Email = "carlos@enterprise.com.br",
            Password = "batatinha1234",
            CreatedAt = DateTime.Now,
            UserType = UserType.USER,
            ActivityStatus = ActivityStatus.ACTIVE,
            CardList = new List<CardDTO>(),
            TransactionList = new List<TransactionDTO>()
        };

        var usuario_c = new UserController().CriarUsuario(usuario_d);

        var cartao_d = new CardDTO()
        {
            HolderName = "CARLOS G A CARVALHO",
            CardNumber = "5117659862365698",
            SecurityCode = "029",
            ExpirationDate = new DateTime(2029,06,30),
            ActivityStatus = ActivityStatus.ACTIVE,
            User = usuario_c,
            TransactionList = new List<TransactionDTO>()
        };

        var card_criar = _controller.CriarCartao(cartao_d);
        _controller.ExcluirCartao(card_criar.CardId);

        var cardInativado = _controller.ListarCartoes(card_criar.User.UserId);
        
        Assert.True(cardInativado.FirstOrDefault(c => c.CardId == card_criar.CardId && c.ActivityStatus == ActivityStatus.INACTIVE) != null);
    }
}