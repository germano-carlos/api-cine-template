//<#keep(imports)#>
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using EasyCine.Kernel.Model.NSMovie;
using EasyCine.Kernel.Model.NSUser;
using EasyCine.Kernel.Model.NSTransaction;
using EasyCine.Kernel.Model.NSSession;
using EasyCine.Kernel.Util;
//<#/keep(imports)#>

namespace EasyCine.Kernel.Model
{
    internal class EasyCineContext : DbContext
	{
		private static ThreadLocal<EasyCineContext> _instance = new ThreadLocal<EasyCineContext>();
		internal static EasyCineContext Get()
		{
			if (!_instance.IsValueCreated || _instance.Value == null)
				throw new Exception("Uma transação não pode ser iniciada sem título.");
			return _instance.Value;
		}
		internal static EasyCineContext Get(string titulo)
		{
			if (_instance.IsValueCreated && _instance.Value != null)
				throw new Exception($"Uma transação só pode ter um título {titulo}.");
			return _instance.Value = new EasyCineContext(titulo);
		}
		internal static EasyCineContext Get(string titulo, string detalhes)
		{
			if (_instance.IsValueCreated && _instance.Value != null)
				throw new Exception($"Uma transação só pode ter um título {titulo}.");
			return _instance.Value = new EasyCineContext(titulo, detalhes);
		}
		
		public DbSet<Movie> MovieSet { get; set; }
		public DbSet<MovieAttachment> MovieAttachmentSet { get; set; }
		public DbSet<MovieSession> MovieSessionSet { get; set; }
		public DbSet<User> UserSet { get; set; }
		public DbSet<Transaction> TransactionSet { get; set; }
		public DbSet<Card> CardSet { get; set; }
		public DbSet<Item> ItemSet { get; set; }
		public DbSet<Session> SessionSet { get; set; }
		
		private EasyCineContext(string titulo) 
		{ 
			//<#keep(criacao)#><#/keep(criacao)#>
		}
		private EasyCineContext(string titulo, string detalhes)
		{
			//<#keep(criacao2)#><#/keep(criacao2)#>
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) 
				return;
			
			optionsBuilder.UseMySql(Constantes.ConnectionString);
				
			if (Debugger.IsAttached)
			{
				optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b => b
						.AddConsole()
						.AddFilter(level => level >= LogLevel.Information)))
					.EnableSensitiveDataLogging()
					.EnableDetailedErrors();
			}
		}
		//<#keep(generico)#><#/keep(generico)#>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// para fazer uma propriedade transiente
			// modelBuilder.Entity<Usuario>().Ignore(b => b.nome);
			// ou colocar [NotMapped] na propriedade

			//<#keep(index)#>
			
			// para chave composta
			//modelBuilder.Entity<Order>().HasKey(o => new { o.CustomerAbbreviation, o.OrderNumber });
			
			//modelBuilder.Entity<Solicitacao>()
			//	.HasOne(c => c.IFDestino)
			//	.WithOne

			/*
			modelBuilder.Entity<Solicitacao>().HasIndex(s => new {
				s.CPFCliente,
				s.CNPJEmpregador,
				s.IdIFFolha
			});
			modelBuilder.Entity<InstituicaoFinanceira>().HasIndex(s => s.CNPJ).IsUnique();
			*/
			
			//<#/keep(index)#>
		}
		public override int SaveChanges()
		{
			return base.SaveChanges();
		}
		public override void Dispose()
		{
			base.Dispose();
			_instance.Value = null;
			//<#keep(dispose)#><#/keep(dispose)#>
		}
		//<#keep(end)#><#/keep(end)#>
	}
}
