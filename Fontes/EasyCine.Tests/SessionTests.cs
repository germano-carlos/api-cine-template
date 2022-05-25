using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using EasyCine.Kernel.Controllers;
using EasyCine.Kernel.DTO.NSMovie;
using EasyCine.Kernel.DTO.NSSession;
using EasyCine.Kernel.DTO.NSTransaction;
using EasyCine.Kernel.Model.NSGeneric;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSSession;
using Newtonsoft.Json;
using Xunit;

namespace EasyCine.Tests;

public class SessionTests
{
    private SessionController _sessionController;
    private MovieController _movieController;

    public SessionTests()
    {
        _sessionController = new SessionController();
        _movieController = new MovieController();
    }

    [Fact]
    public void AtualizarSessaoFilmeError()
    {
        var sessaomovie = new MovieSessionDTO()
        {
            Movie = new MovieDTO()
            {
                MovieId = 0
            }
        };

        Assert.Throws<Exception>(() => _movieController.AtualizarSessaoFilme(sessaomovie));
    }
    
    [Theory]
    [InlineData(28)]
    [InlineData(29)]
    [InlineData(30)]
    public void AtualizarSessaoFilmeErroSessao(long movieId)
    {
        var movie = _movieController.ObterFilme(movieId);
        var session = movie.MovieSessionList.FirstOrDefault();
        if (session is null)
            return;

        session.Session.SessionHour = "10:15";
        session.Movie = movie;
        
        Assert.Throws<Exception>(() => _movieController.AtualizarSessaoFilme(session));
    }

    [Fact]
    public void CriarNovaSessao()
    {
        var s = new SessionDTO()
        {
            SessionHour = "11:00",
            ActivityStatus = ActivityStatus.ACTIVE,
        };

        var sessaoCraida = _movieController.CriarSessao(s);
        s.CreatedAt = sessaoCraida.CreatedAt;
        s.SessionId = sessaoCraida.SessionId;

        var s_serializado = JsonConvert.SerializeObject(s);
        var c_serializado = JsonConvert.SerializeObject(sessaoCraida);

        _sessionController.DeletarSessao("11:00");
        
        Assert.Equal(s_serializado, c_serializado);
    }
    
    [Fact]
    public void CriarNovaSessaoErro()
    {
        var s = new SessionDTO()
        {
            SessionHour = "10:00",
            ActivityStatus = ActivityStatus.ACTIVE,
        };

        Assert.Throws<Exception>(() => _movieController.CriarSessao(s));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void CriarSessaoFilmeMovieNotFound(int movieId)
    {
        var movieSession = new MovieSessionDTO()
        {
            Amount = 30,
            ActivityStatus = ActivityStatus.ACTIVE,
            SessionType = SessionType.BIDIMENSIONAL,
            Movie = new MovieDTO()
            {
                MovieId = movieId
            },
            Session = new SessionDTO()
            {
                SessionHour = "10:00"
            },
            TransactionList = new List<TransactionDTO>(),
        };

        Assert.Throws<Exception>(() => _movieController.CriarSessaoFilme(movieSession));
    }
    
    [Theory]
    [InlineData("12:00")]
    [InlineData("12:30")]
    [InlineData("12:45")]
    public void CriarSessaoFilmeSessaoNotFound(string sessionHour)
    {
        var movieSession = new MovieSessionDTO()
        {
            Amount = 30,
            ActivityStatus = ActivityStatus.ACTIVE,
            SessionType = SessionType.BIDIMENSIONAL,
            Movie = new MovieDTO()
            {
                MovieId = 28
            },
            Session = new SessionDTO()
            {
                SessionHour = sessionHour
            },
            TransactionList = new List<TransactionDTO>(),
        };

        Assert.Throws<Exception>(() => _movieController.CriarSessaoFilme(movieSession));
    }
    
    [Fact]
    public void CriarSessaoFilmeSucesso()
    {
        var movieSession = new MovieSessionDTO()
        {
            Amount = 30,
            ActivityStatus = ActivityStatus.ACTIVE,
            SessionType = SessionType.BIDIMENSIONAL,
            Movie = _movieController.ObterFilme(28),
            Session = _sessionController.ObterSessao("10:00"),
            TransactionList = new List<TransactionDTO>(),
        };

        var criar = _movieController.CriarSessaoFilme(movieSession);
        criar.Movie = movieSession.Movie;
        movieSession.MovieSessionId = criar.MovieSessionId;

        var m_serialized = JsonConvert.SerializeObject(movieSession);
        var c_serialized = JsonConvert.SerializeObject(criar);
        
        Assert.Equal(m_serialized, c_serialized);
    }

    [Theory]
    [InlineData(31)]
    [InlineData(35)]
    [InlineData(38)]
    public void ListarSessoes(int movieId)
    {
        var sessoes = _movieController.ListarSessoesFilme(movieId);
        Assert.NotNull(sessoes);
    }

    [Fact]
    public void RemoverSessao()
    {
        var movieSession = new MovieSessionDTO()
        {
            Amount = 30,
            ActivityStatus = ActivityStatus.ACTIVE,
            SessionType = SessionType.BIDIMENSIONAL,
            Movie = _movieController.ObterFilme(28),
            Session = _sessionController.ObterSessao("10:00"),
            TransactionList = new List<TransactionDTO>(),
        };

        var criar = _movieController.CriarSessaoFilme(movieSession);
        criar.Movie = movieSession.Movie;
        _movieController.RemoverSessaoFilme(criar.MovieSessionId);

        var listarSessoes = _movieController.ListarSessoesFilme(criar.Movie.MovieId);
        Assert.True(listarSessoes.FirstOrDefault(s => s.MovieSessionId == criar.MovieSessionId && s.ActivityStatus == ActivityStatus.INACTIVE) is not null);
    }
    
    /*
        
        using var context = EasyCineContext.Get("Movie.CriarSessaoFilme"); 
        //<#keep(CriarSessaoFilme)#> 

        var movie = Movie.Get(movieSession.Movie.MovieId);
        var sessao = Session.Get(movieSession.Session.SessionHour);
        if (movie is null)
            throw new Exception("Movie not found, try again with another values");
        if (sessao is null)
            throw new Exception("Session not found, try again with another values");
			
        var newSession = new MovieSession(movieSession, sessao, movie);
        movie.MovieSessionList.Add(newSession);
			
        context.SaveChanges(); 
        return MovieSessionDTO.FromEntity(newSession); 
        //<#/keep(CriarSessaoFilme)#> */
}