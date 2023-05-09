using Auction.Application;
using Auction.WebApi.Data;
using MBC.Core.DataAccess.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Auction
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

            services.AddApplication();
            
            SetupInit(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {

           app.UseDeveloperExceptionPage();
            

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitialDebug.FillDevelopmentInfo(serviceProvider).Wait();
        }

        private void SetupInit(IServiceCollection services)
        {
            //Соединение с БД
            SetupDatabaseSql(services);

            //Общие настройки
            SetupCommon(services);

            //Настройки Identity
            InitIdentity(services);

            //Добавление свагера
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Настройка соединения с БД
        /// </summary>
        private void SetupDatabaseSql(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Auction")));       //Строка соединения находится в database-config.json
        }

        /// <summary>
        /// Общие настройки
        /// </summary>
        private void SetupCommon(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        }

        /// <summary>
        /// Инициализация identity
        /// </summary>
        private void InitIdentity(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
