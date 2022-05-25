using System;
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

    [Theory]
    [InlineData(28)]
    public void ObterFilme(int id)
    {
        var movie = new MovieDTO()
        {
            MovieId = id,
            ActivityStatus = ActivityStatus.ACTIVE,
            Description = "Esta é a criação de um filme teste",
            StartTime = new DateTime(2022,06,01),
            EndTime = new DateTime(2022,06,15, 23, 59, 59),
            MovieAttachmentList = new List<MovieAttachmentDTO>(),
            MovieCategoryList = new List<MovieCategoryDTO>()
            {
                new MovieCategoryDTO()
                {
                    MovieCategoryId = id,
                    Category = Category.ACTION
                }
            },
            MovieSessionList = new List<MovieSessionDTO>(),
            Name = "Charlinhos, o Guerreiro Trovão",
            Rating = "10.0"
        };
        
        var movieGet = _controller.ObterFilme(id);
        movie.CreatedAt = movieGet.CreatedAt;

        var s_movie = JsonConvert.SerializeObject(movie);
        var s_movie_get = JsonConvert.SerializeObject(movieGet);
        
        Assert.Equal(s_movie, s_movie_get);
    }

    [Fact]
    public void InativarFilme()
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
        _controller.RemoverFilme(result.MovieId);

        var movieInativado = _controller.ObterFilme(result.MovieId);
        
        Assert.True(movieInativado.ActivityStatus == ActivityStatus.INACTIVE);
    }

    [Theory]
    [InlineData("Charlinhos", null, null, null, null, null, ActivityStatus.ACTIVE)]
    [InlineData(null, "teste", null, null, null, null, ActivityStatus.ACTIVE)]
    [InlineData(null, null, "10", null, null, null, ActivityStatus.ACTIVE)]
    [InlineData(null, null, null, null, null, null, ActivityStatus.INACTIVE)]
    public void ListarFilmes(string nome, string desc, string rating, DateTime? created, DateTime? start, DateTime? endTime, ActivityStatus status)
    {
        var movies = _controller.ListarFilmes(nome, desc, rating, created, start, endTime, status).ToList();
        var passed = movies.Count(m => m.ActivityStatus == status) == movies.Count;

        if (!string.IsNullOrEmpty(nome))
            passed = movies.Count(m => m.Name.Contains(nome)) == movies.Count;
        if (!string.IsNullOrEmpty(desc))
            passed = movies.Count(m => m.Description.Contains(desc)) == movies.Count;
        if (!string.IsNullOrEmpty(rating))
            passed = movies.Count(m => m.Rating.Contains(rating)) == movies.Count;
        if (created.HasValue)
            passed = movies.Count(m => m.CreatedAt.Date == created.Value.Date) == movies.Count;
        if (start.HasValue)
            passed = movies.Count(m => m.StartTime.Date == start.Value.Date) == movies.Count;
        if (endTime.HasValue)
            passed = movies.Count(m => m.EndTime.Date == endTime.Value.Date) == movies.Count;
        
        Assert.True(passed);
    }
}