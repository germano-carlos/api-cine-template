﻿using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using EasyCine.Kernel.Controllers;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using Newtonsoft.Json;
using Xunit;

namespace EasyCine.Tests;

public class MovieTests
{

    private readonly MovieController _controller; 
    public MovieTests()
    {
        _controller = new MovieController();
    }
    
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
        var movie = new MovieDTO()
        {
            ActivityStatus = ActivityStatus.ACTIVE,
            Description = "Esta é a criação de um filme teste",
            StartTime = new DateTime(2022,06,01),
            EndTime = new DateTime(2022,06,15, 23, 59, 59),
            MovieAttachmentList = new List<MovieAttachmentDTO>(),
            MovieCategoryList = new List<MovieCategoryDTO>()
            {
                new MovieCategoryDTO()
                {
                    Category = Category.ACTION
                }
            },
            MovieSessionList = new List<MovieSessionDTO>(),
            Name = "Charlinhos, o Guerreiro Trovão",
            Rating = "10.0"
        };

        var result = _controller.CriarFilme((movie));

        movie.MovieId = result.MovieId;
        movie.CreatedAt = result.CreatedAt;
        movie.MovieCategoryList.ForEach((m) =>
        {
            var categoria = result.MovieCategoryList.FirstOrDefault(cc => cc.Category == m.Category);
            m.MovieCategoryId = categoria!.MovieCategoryId;
        });

        var resultSerialized = JsonConvert.SerializeObject(result);
        var movieSerialized = JsonConvert.SerializeObject(result);
        
        Assert.Equal(movieSerialized, resultSerialized);
    }
}