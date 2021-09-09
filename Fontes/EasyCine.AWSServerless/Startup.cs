using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EasyCine.AWSServerless
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson(options =>
				options.SerializerSettings.ContractResolver =
				new Newtonsoft.Json.Serialization.DefaultContractResolver());
				
			services.AddMvc().AddNewtonsoftJson(options =>
				options.SerializerSettings.ContractResolver =
				new Newtonsoft.Json.Serialization.DefaultContractResolver());
				
			services.AddCors();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "CM EasyCine",
					Description = "API para EasyCine",
					Contact = new OpenApiContact() { Name = "Carlos Germano", Email = "germano.carlos2712@gmail.com" }
				});
				
				c.AddSecurityDefinition("AuthToken", new OpenApiSecurityScheme
				{
					Name = "AuthToken",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});
				
				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Id = "AuthToken",
								Type = ReferenceType.SecurityScheme
							}
						},
						new List<string>()
					}
				});

				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
				c.IncludeXmlComments(GetXmlCommentsPath());
				c.OperationFilter<AwsApiGatewayIntegrationFilter>();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Welcome to running ASP.NET Core 3.1 in Lambda!");
				});
			});
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.DocumentTitle = "EasyCine API UI";
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyCine API V1");
			});
		}

		private string GetXmlCommentsPath()
		{
			var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
			return xmlPath;
		}
	}
	public class AwsApiGatewayIntegrationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			operation.Extensions.Add("x-amazon-apigateway-integration", new OpenApiObject
			{
				["type"] = new OpenApiString("aws"),
				["uri"] = new OpenApiString("arn_to_your_aws_resource"),
			});
		}
	}

}
