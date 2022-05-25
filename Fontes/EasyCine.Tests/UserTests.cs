using System;
using System.Collections.Generic;
using EasyCine.Kernel.Controllers;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.DTO.NSUser;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSUser;
using Newtonsoft.Json;
using Xunit;

namespace EasyCine.Tests;

public class UserTests
{
    private UserController _controller;
    public UserTests()
    {
        _controller = new UserController();
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void AtualizarUsuario(long usuarioId)
    {
        var usuario = _controller.ObterUsuario(usuarioId);
        usuario.Password = "Senha Segura";
        _controller.AtualizarUsuario(usuario);
        
        var usuarioAtt = _controller.ObterUsuario(usuarioId);
        Assert.True(usuarioAtt.Password == "Senha Segura");
    }

    [Fact]
    public void CriarUsuario()
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

        var usuario_c = _controller.CriarUsuario(usuario_d);
        usuario_d.UserId = usuario_c.UserId;
        usuario_d.CreatedAt = usuario_c.CreatedAt;

        var usuario_ex_serialized = JsonConvert.SerializeObject(usuario_d);
        var usuario_cri_serialized = JsonConvert.SerializeObject(usuario_c);
        
        Assert.Equal(usuario_ex_serialized, usuario_cri_serialized);
    }
    
    [Fact]
    public void ExcluirUsuario() 
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

        var usuario_c = _controller.CriarUsuario(usuario_d);
        _controller.ExcluirUsuario(usuario_c.UserId);
        
        Assert.True(_controller.ObterUsuario(usuario_c.UserId).ActivityStatus == ActivityStatus.INACTIVE);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ObterUsuario(long id)
    {
        var usuario = _controller.ObterUsuario(id);
        Assert.NotNull(usuario);
    }
}