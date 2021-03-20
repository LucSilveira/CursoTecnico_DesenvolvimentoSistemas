using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Dominio.Repositories;
using CodeTur.Infra.Data.Contexts;
using CodeTur.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string PermissaoEntreOrigens = "_PermissaoEntreOrigens";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            //Adicionando a referencia do contexto com o banco de dados
            services.AddDbContext<CodeTurContext>(o => o.UseSqlServer("Data Source=DESKTOP-A8TBAPR; Initial Catalog=CodeTur; User Id=sa; Password=sa132"));

            // JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "codetur",
                    ValidAudience = "codetur",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CodeTurSecurityKey"))
                };
            });

            //Adicionamos o swagger a nossa aplicação para podermos documentar nossas API´s
            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API CodeTur",
                    Description = "Um sistema simples para estudos de ASP.NET Core web API",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });

            //Cors
            services.AddCors(options => {
                options.AddPolicy(PermissaoEntreOrigens,
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            #region Injeção de Dependencia de Usuário

            //Definindo que aonde acessarmos o 'IUsuarioRepository', na verdade instanciaremos o 'UsuarioRepository'
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<CriarUsuarioHandle, CriarUsuarioHandle>();
            services.AddTransient<AdicionarTelefoneHandle, AdicionarTelefoneHandle>();
            services.AddTransient<EsqueciSenhaHandle, EsqueciSenhaHandle>();
            services.AddTransient<AlterarUsuarioHandle, AlterarUsuarioHandle>();
            services.AddTransient<AlterarSenhaHandle, AlterarSenhaHandle>();
            services.AddTransient<ListarUsuariosHandle, ListarUsuariosHandle>();
            services.AddTransient<BuscarUsuarioHandle, BuscarUsuarioHandle>();
            services.AddTransient<ExcluirUsuarioHandle, ExcluirUsuarioHandle>();
            services.AddTransient<LogarHandle, LogarHandle>();
            #endregion

            #region Injeção de Dependencia de Pacote

            //Definindo que aonde acessarmos o 'IPacoteRepository', na verdade instanciaremos o 'PacoteRepository'
            services.AddTransient<IPacoteRepository, PacoteRepository>();
            services.AddTransient<CriarPacoteHandle, CriarPacoteHandle>();
            services.AddTransient<ListarPacotesHandle, ListarPacotesHandle>();
            services.AddTransient<AlterarPacoteHandle, AlterarPacoteHandle>();
            services.AddTransient<AlterarImagemPacoteHandle, AlterarImagemPacoteHandle>();
            services.AddTransient<AlterarStatusPacoteHandle, AlterarStatusPacoteHandle>();
            services.AddTransient<BuscarPacoteHandle, BuscarPacoteHandle>();
            services.AddTransient<ExcluirPacoteHandle, ExcluirPacoteHandle>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Habilitamos efetivamente o Swagger em nossa aplicação.
                app.UseSwagger();

                // Especificamos o endpoint da documentação
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeTur API v1");
                });
            }

            app.UseCors(option => option.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());

            app.UseStaticFiles();

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
