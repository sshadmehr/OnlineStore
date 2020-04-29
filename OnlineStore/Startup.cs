using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStore.DataAccess;
using OnlineStore.DataAccess.Repository;
using OnlineStore.Domain.Repositories;
using OnlineStore.Domain.Services;
using OnlineStore.Services;
namespace OnlineStore
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
			services.AddControllers();
			services.AddAutoMapper(typeof(Startup));

			#region Services

			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IProductGroupService, ProductGroupService>();
			services.AddTransient<IDeliveryGroupService, DeliveryGroupService>();
			services.AddTransient<ITariffService, TariffService>();

			#endregion

			#region Repositories

			services.AddScoped<OnlineStoreContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
			services.AddScoped<IDeliveryGroupRepository, DeliveryGroupRepository>();
			services.AddScoped<ITariffRepository, TariffRepository>();
			services.AddScoped<IProductsDeliveryGroupsRepository, ProductsDeliveryGroupsRepository>();

			#endregion
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

			app.UseEndpoints(endpoints =>
			{
				
				endpoints.MapControllers();
			});
		}
	}
}
