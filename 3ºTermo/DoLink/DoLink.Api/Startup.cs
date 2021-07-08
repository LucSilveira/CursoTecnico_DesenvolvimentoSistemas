using DoLink.Dominio.Commands.Skill;
using DoLink.Dominio.Handles.Commands;
using DoLink.Dominio.Handles.Commands.Conta;
using DoLink.Dominio.Handles.Commands.Empresas;
using DoLink.Dominio.Handles.Commands.Matchs;
using DoLink.Dominio.Handles.Commands.Profissionais;
using DoLink.Dominio.Handles.Commands.Skills;
using DoLink.Dominio.Handles.Commands.Vagas;
using DoLink.Dominio.Handles.Queries.Conta;
using DoLink.Dominio.Handles.Queries.Empresas;
using DoLink.Dominio.Handles.Queries.Matchs;
using DoLink.Dominio.Handles.Queries.Profissionais;
using DoLink.Dominio.Handles.Queries.Skills;
using DoLink.Dominio.Handles.Queries.Vagas;
using DoLink.Dominio.Repositories;
using DoLink.Infra.Data.Contexts;
using DoLink.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Api
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

            services.AddControllers();

            //Configurando instância com o banco de dados
            services.Configure<DoLinkDatabaseSettings>(Configuration.GetSection(nameof(DoLinkDatabaseSettings)));

            //Definindo o Servico com o banco
            services.AddSingleton<IDoLinkDatabaseSettings>(svc =>
                                    svc.GetRequiredService<IOptions<DoLinkDatabaseSettings>>().Value);

            //Corrigindo erros de retorno no JSON
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

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
                    ValidIssuer = "dolink",
                    ValidAudience = "dolink",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaDoLink"))
                };
            });

            //Adicionamos o swagger a nossa aplicação para podermos documentar nossas API´s
            services.AddSwaggerGen(swg =>
            {
                swg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API DoLink",
                    Description = "Um sistema simples para estudos de ASP.NET Core web API",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });

            //Cors
            services.AddCors(options => {
                options.AddPolicy(PermissaoEntreOrigens,
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //Injeção de dependência do projeto

            #region Services de Empresa
                services.AddTransient<IEmpresaRepository, EmpresaRepository>();
                services.AddTransient<ListarEmpresaHandler, ListarEmpresaHandler>();
                services.AddTransient<BuscarEmpresaHandler, BuscarEmpresaHandler>();
                services.AddTransient<CadastrarEmpresaHandler, CadastrarEmpresaHandler>();
                services.AddTransient<AlterarEmpresaGeneralHandler, AlterarEmpresaGeneralHandler>();
                services.AddTransient<AlterarEmpresaHandler, AlterarEmpresaHandler>();
                services.AddTransient<AlterarDescricaoEmpresaHandler, AlterarDescricaoEmpresaHandler>();
                services.AddTransient<AlterarCnpjHandler, AlterarCnpjHandler>();
                services.AddTransient<ExcluirEmpresaHandler, ExcluirEmpresaHandler>();
            #endregion

            /*************************************************************************/

            #region Services de Skill
                services.AddTransient<ISkillRepository, SkillRepository>();
                services.AddTransient<ListarSkillHandler, ListarSkillHandler>();
                services.AddTransient<BuscarSkillHandler, BuscarSkillHandler>();
                services.AddTransient<BuscarSkillPorIdHandler, BuscarSkillPorIdHandler>();
                services.AddTransient<CadastrarSkillHandler, CadastrarSkillHandler>();
                services.AddTransient<AlterarSkillHandler, AlterarSkillHandler>();
                services.AddTransient<ExcluirSkillHandler, ExcluirSkillHandler>();
            #endregion

            /**************************************************************************/

            #region Services de Profissional
                services.AddTransient<IProfissionalRepository, ProfissionalRepository>();
                services.AddTransient<ListarProfissionaisHandler, ListarProfissionaisHandler>();
                services.AddTransient<BuscarProfissionalHandler, BuscarProfissionalHandler>();
                services.AddTransient<CadastrarProfissionalHandler, CadastrarProfissionalHandler>();
                services.AddTransient<AlterarProfissionalHandler, AlterarProfissionalHandler>();
                services.AddTransient<AlterarCpfProfissionalHandler, AlterarCpfProfissionalHandler>();
                services.AddTransient<AlterarSkillsProfissionalHandler, AlterarSkillsProfissionalHandler>();
                services.AddTransient<AlterarProfissionalMobileHandler, AlterarProfissionalMobileHandler>();
                services.AddTransient<ExcluirProfissionalHandler, ExcluirProfissionalHandler>();
            #endregion

            /**************************************************************************************/

            #region Services de Vaga
                services.AddTransient<IVagaRepository, VagaRepository>();
                services.AddTransient<ListarVagaHandler, ListarVagaHandler>();
                services.AddTransient<ListarVagaEmpresaHandler, ListarVagaEmpresaHandler>();
                services.AddTransient<ListarVagaStatusHandler, ListarVagaStatusHandler>();
                services.AddTransient<BuscarVagaHandler, BuscarVagaHandler>();
                services.AddTransient<BuscarVagaPorIdHandler, BuscarVagaPorIdHandler>();
                services.AddTransient<CadastrarVagaHandler, CadastrarVagaHandler>();
                services.AddTransient<AlterarVagaHandler, AlterarVagaHandler>();
                services.AddTransient<AlterarSkillVagaHandler, AlterarSkillVagaHandler>();
                services.AddTransient<ExcluirVagaHandler, ExcluirVagaHandler>();
                services.AddTransient<AlterarStatusVagaHandler, AlterarStatusVagaHandler>();
                services.AddTransient<ListaPreMatchHandler, ListaPreMatchHandler>();
                services.AddTransient<AlterarDataVencimentoHandler, AlterarDataVencimentoHandler>();
            #endregion

            /**************************************************************************************/

            #region Services de Match
                services.AddTransient<IMatchRepository, MatchRepository>();
                services.AddTransient<CadastrarMatchHandler, CadastrarMatchHandler>();
                services.AddTransient<ExcluirMatchHandler, ExcluirMatchHandler>();
                services.AddTransient<BuscarMatchHandler, BuscarMatchHandler>();
            #endregion

            /**************************************************************************************/

            #region Services de Admin
                services.AddTransient<IAdminRepository, AdminRepository>();

            #endregion

            #region Services gerais
            services.AddTransient<LogarHandler, LogarHandler>();
                services.AddTransient<EsqueciMinhaSenhaHandler, EsqueciMinhaSenhaHandler>();
                services.AddTransient<AlterarSenhaHandler, AlterarSenhaHandler>();
                services.AddTransient<BuscarEmailHandler, BuscarEmailHandler>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            // Habilitamos efetivamente o Swagger em nossa aplicação.    
            app.UseSwagger();

            // Especificamos o endpoint da documentação
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoLink API v1");
            });
        }
    }
}
