using System;
using System.Collections.Generic;
using EasyCine.Kernel.Controllers;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using Xunit;

namespace EasyCine.Tests;

public class MovieTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(1)] // Gera erro !
    [InlineData(3)]
    public void IsNotEven(int value)
    {
        var result = value % 2 == 0;
        Assert.False(result, $"{value} should not be prime");
    }
    
    [Fact]
    public void CriarNovoFilme()
    {
        var movie = new Movie()
        {
            ActivityStatus = ActivityStatus.ACTIVE,
            CreatedAt = DateTime.Now,
            Description = "Esta é a criação de um filme teste",
            StartTime = DateTime.Now.AddDays(15),
            EndTime = DateTime.Now.AddDays(30),
            MovieAttachmentList = new List<MovieAttachment>(),
            MovieCategoryList = new List<MovieCategory>()
            {
                new MovieCategory()
                {
                    Category = Category.ACTION
                }
            },
            MovieSessionList = new List<MovieSession>(),
            Name = "Charlinhos, o Guerreiro Trovão",
            Rating = "10.0"
        };

        //var result = new MovieController().CriarFilme(MovieDTO.FromEntity(movie));
        
        Assert.Equal(new {ob = "teste"}, new {ob = "teste"});
    }
}