using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Dominio.Repositorios;
using CodeTur.Infra.Data.Contexts;
using CodeTur.Infra.Data.Repositorios;
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

namespace CodeTur.Api
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddDbContext<CodeTurContext>(o => o.UseSqlServer("Data Source=DESKTOP-VFV613U ;Initial Catalog=CodeTur;user id=sa; password=sa132"));

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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCodeTurSenai132"))
                    };
                });

            services.AddSwaggerGen(o => {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "Api CodeTur", Version = "v1" });
            });

            #region Injecao de dependencias Usuario
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<LogarHandle, LogarHandle>();
            services.AddTransient<CriarUsuarioHandle, CriarUsuarioHandle>();
            services.AddTransient<BuscarUsuarioPorIdQueryHandler, BuscarUsuarioPorIdQueryHandler>();
            services.AddTransient<AlterarUsuarioHandler, AlterarUsuarioHandler>();
            services.AddTransient<EsqueciSenhaHadler, EsqueciSenhaHadler>();
            services.AddTransient<ListarUsuarioQueryHandler, ListarUsuarioQueryHandler>();
            services.AddTransient<AlterarSenhaHandler, AlterarSenhaHandler>();
            #endregion

            #region Injecao de dependencias Pacote
            services.AddTransient<IPacotesRespositorio, PacoteRepositorio>();
            services.AddTransient<CriarPacoteCommandHandle, CriarPacoteCommandHandle>();
            services.AddTransient<ListarPacoteQueryHandlers, ListarPacoteQueryHandlers>();
            services.AddTransient<BuscarPacotePorIdQuerryHandler, BuscarPacotePorIdQuerryHandler>();
            services.AddTransient<AlterarPacoteHandler, AlterarPacoteHandler>();
            services.AddTransient<AlterarImagemHandler, AlterarImagemHandler>();
            services.AddTransient<AlterarStatusHandler, AlterarStatusHandler>();
            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api CodeTur V1");
                });
                

                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
