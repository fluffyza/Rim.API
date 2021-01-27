
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using Rim.API.Entities;
using Rim.API.Services;
using Rim.API.Services.Interface;

namespace Rim.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

			services.AddCors();
			services.AddControllers();

			services.AddAutoMapper(typeof(Startup));

			services.AddDbContext<Context>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Context"));
			});

			services.AddSwaggerDocument(config =>
			{
				config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
				config.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT",
					new OpenApiSecurityScheme
					{
						Type = OpenApiSecuritySchemeType.ApiKey,
						Name = "Authorization",
						Description = "Copy 'Bearer ' + valid JWT token into field",
						In = OpenApiSecurityApiKeyLocation.Header
					}));

				config.PostProcess = (document) =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "Rim.Api";
					document.Info.Description = "Rim.Api ASP.NET Core 3.1 Rest API";
				};
			});

			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IOrderService, OrderService>();

			services.AddOptions();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseOpenApi();
			app.UseSwaggerUi3();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
