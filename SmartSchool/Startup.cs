using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool
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
            services.AddDbContext<SmartContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            /*services.AddSingleton<IRepository, Repository>(); Cria uma instancia d eum serviço quando é chamado a 1º vez, e reutiliza
            essa msm instancias quando é chamando N vezes.*/

            /*services.AddTransient<IRepository, Repository>(); É o caso contrario do Singleton, toda vez q é chamado cria um nova instancia*/

            services.AddScoped<IRepository, Repository>();

            services.AddControllers()
                    .AddNewtonsoftJson(opt => 
                                       opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Newtonsoft Serve pra desfazer o loop infinito do Json (Ele tem que add no nugetpack ou direto no SmartSchool.csproj
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
