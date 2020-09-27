using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace APIJogo
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
            services.AddControllers().AddNewtonsoftJson(_options => {

                _options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                _options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Jogame",
                    Description = "Um sistema simples de ecommerce para estudos de ASP.NET Core web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Silveira",
                        Email = "lucassilveira586@gmail.com",
                        Url = new Uri("https://github.com/LucSilveira"),
                    },

                    License = new OpenApiLicense
                    {
                        Name = "Open License",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // geramos o arquivo xml para leitura das documentações dos métodos da nossa API
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                swg.IncludeXmlComments(xmlPath);
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

            // Usando a configurando do Swagger
            app.UseSwagger();

            // configurando a descrição da api
            app.UseSwaggerUI(swg =>
            {
                swg.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
