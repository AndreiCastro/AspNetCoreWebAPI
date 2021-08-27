using AutoMapper;
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
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

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


            services.AddControllers()
                    .AddNewtonsoftJson(opt => 
                                       opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Newtonsoft Serve pra desfazer o loop infinito do Json (Ele tem que add no nugetpack ou direto no SmartSchool.csproj



            /*services.AddSingleton<IRepository, Repository>(); Cria uma instancia d eum serviço quando é chamado a 1º vez, e reutiliza
            essa msm instancias quando é chamando N vezes.*/
            /*services.AddTransient<IRepository, Repository>(); É o caso contrario do Singleton, toda vez q é chamado cria um nova instancia*/
            services.AddScoped<IRepository, Repository>();


            //Esse baico tambem é uma forma de injeção de dependencia com AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "smartschoolapi",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "SmartSchool API",
                        Version = "1.0"
                    });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                options.IncludeXmlComments(xmlCommentsFullPath);
                //As 3 linhas acima servem para add comentarios em XML no projeto, utilizando o /// nas Controles e Dto

            });
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

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/smartschoolapi/swagger.json", "smartschoolapi");
                    options.RoutePrefix = "";
                });
            //Configurou o swagger para abri com essa url
        }
    }
}
