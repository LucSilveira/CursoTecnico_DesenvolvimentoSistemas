using Carometro.Dominio.Handlers.Commands.Admins;
using Carometro.Dominio.Handlers.Commands.Alunos;
using Carometro.Dominio.Handlers.Commands.AlunosTurmas;
using Carometro.Dominio.Handlers.Commands.Professores;
using Carometro.Dominio.Handlers.Commands.ProssoresTurmas;
using Carometro.Dominio.Handlers.Commands.Turmas;
using Carometro.Dominio.Handlers.Commands.Usuarios;
using Carometro.Dominio.Handlers.Queries;
using Carometro.Dominio.Handlers.Queries.Admins;
using Carometro.Dominio.Handlers.Queries.Alunos;
using Carometro.Dominio.Handlers.Queries.AlunosTurmas;
using Carometro.Dominio.Handlers.Queries.Professores;
using Carometro.Dominio.Handlers.Queries.ProfessoresTurmas;
using Carometro.Dominio.Handlers.Queries.Turmas;
using Carometro.Dominio.Queries.Professor;
using Carometro.Dominio.Repositorios;
using Carometro.Infra.Data.Contexts;
using Carometro.Infra.Data.Repositorios;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Api
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

            services.AddDbContext<CarometroContext>(o => o.UseSqlServer("Data Source=DESKTOP-E34QQ0G\\SQLEXPRESS;Initial Catalog=Carometro-DataBase;User ID=sa;Password=sa132"));
            //Connection String - Toshi: DESKTOP-72RKQ3P\\SQLEXPRESS

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
                    ValidIssuer = "carometro",
                    ValidAudience = "carometro",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCarometro"))
                };
            });

            //Adicionamos o swagger a nossa aplicação para podermos documentar nossas API´s
            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Carometro",
                    Description = "Um sistema simples para estudos de ASP.NET Core web API",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });

            //Cors
            services.AddCors(options => {
                options.AddPolicy(PermissaoEntreOrigens,
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            #region Injeção de Dependência - Admin

            services.AddTransient<IAdminRepositorio, AdminRepositorio>();
            services.AddTransient<CadastrarContaHandler, CadastrarContaHandler>();
            services.AddTransient<AlterarContaHandler, AlterarContaHandler>();
            services.AddTransient<ExcluirContaHandler, ExcluirContaHandler>();
            services.AddTransient<ListarAdminHandler, ListarAdminHandler>();
            services.AddTransient<BuscarAdminHandler, BuscarAdminHandler>();
            services.AddTransient<LogarHandler, LogarHandler>();
            services.AddTransient<EsqueciSenhaHandler, EsqueciSenhaHandler>();
            services.AddTransient<AlterarSenhaHandler, AlterarSenhaHandler>();
            #endregion

            #region Injeção de Dependência - Aluno

            services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
            services.AddTransient<CadastrarAlunoHandler, CadastrarAlunoHandler>();
            services.AddTransient<ListarAlunoQueryHandle, ListarAlunoQueryHandle>();
            services.AddTransient<BuscarAlunoHandler, BuscarAlunoHandler>();
            services.AddTransient<AlterarAlunoHandler, AlterarAlunoHandler>();
            services.AddTransient<ExcluirAlunoHandler, ExcluirAlunoHandler>();
            #endregion

            #region Injeção de Dependência - Professor

            services.AddTransient<IProfessorRepositorio, ProfessorRepositorio>();
            services.AddTransient<CadastrarProfessorHandler, CadastrarProfessorHandler>();
            services.AddTransient<AlterarProfessorHandle, AlterarProfessorHandle>();
            services.AddTransient<ExcluirProfessorHandler, ExcluirProfessorHandler>();
            services.AddTransient<ListarProfessorHandler, ListarProfessorHandler>();
            services.AddTransient<BuscarProfessorHandler, BuscarProfessorHandler>();
            #endregion

            #region Injeção de Dependência - Turma

            services.AddTransient<ITurmaRepositorio, TurmaRepositorio>();
            services.AddTransient<CadastrarTurmaHandler, CadastrarTurmaHandler>();
            services.AddTransient<AlterarTurmaHandler, AlterarTurmaHandler>();
            services.AddTransient<ListarTurmasHandler, ListarTurmasHandler>();
            services.AddTransient<BuscarTurmaHandler, BuscarTurmaHandler>();
            #endregion

            #region Injeção de Dependência - Horário

            services.AddTransient<IHorarioRepositorio, HorarioRepositorio>();
            #endregion

            #region Injeção de Dependência - AlunoTurma

            services.AddTransient<IAlunoTurmaRepositorio, AlunoTurmaRepositorio>();
            services.AddTransient<BuscarAlunoTurmaHandler, BuscarAlunoTurmaHandler>();
            services.AddTransient<CadastrarAlunoTurmaHandler, CadastrarAlunoTurmaHandler>();
            services.AddTransient<ListarAlunosTurmasHandler, ListarAlunosTurmasHandler>();
            services.AddTransient<ListarAlunosDaTurmaHandler, ListarAlunosDaTurmaHandler>();
            services.AddTransient<ListarTurmasDoAlunoHandler, ListarTurmasDoAlunoHandler>();
            services.AddTransient<AlterarAlunoTurmaHandler, AlterarAlunoTurmaHandler>();
            services.AddTransient<ExcluirAlunoTurmaHandler, ExcluirAlunoTurmaHandler>();
            #endregion

            #region Injeção de Dependência - ProfessorTurma

            services.AddTransient<IProfessorTurmaRepositorio, ProfessorTurmaRepositorio>();
            services.AddTransient<BuscarProfessorHandler, BuscarProfessorHandler>();
            services.AddTransient<CadastrarProfessorTurmaHandler, CadastrarProfessorTurmaHandler>();
            services.AddTransient<ListarProfessoresDaTurmaHandler, ListarProfessoresDaTurmaHandler>();
            services.AddTransient<ListarProfessoresTurmasHandler, ListarProfessoresTurmasHandler>();
            services.AddTransient<ListarTurmasDoProfessorHandler, ListarTurmasDoProfessorHandler>();
            services.AddTransient<AlterarProfessorTurmaHandler, AlterarProfessorTurmaHandler>();
            services.AddTransient<ExcluirProfessorTurmaHandler, ExcluirProfessorTurmaHandler>();
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carometro API v1");
                });
            }

            app.UseCors(option => option.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());

            //app.UseHttpsRedirection();

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
