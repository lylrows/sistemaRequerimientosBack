using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Acceso.Datos;
using Encryption.Implementacion;
using Encryption.Interfaz;
using Logica.Negocio.Implementacion.Logic;
using Logica.Negocio.Implementacion.Logic.persona;
using Logica.Negocio.Implementacion.Logic.configuracion;
using Logica.Negocio.Implementacion.Logic.incidencia;
using Logica.Negocio.Implementacion.Logic.login;
using Logica.Negocio.Interfaces.Logic;
using Logica.Negocio.Interfaces.Logic.persona;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Logica.Negocio.Interfaces.Logic.login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Unidad.Trabajo;
using Repositorios.Interfaces.configuracion;
using Logica.Negocio.Interfaces.Logic.correo;
using Logica.Negocio.Implementacion.Logic.correo;
using Logica.Negocio.Implementacion.Logic.empresas;
using Logica.Negocio.Interfaces.Logic.empresas;
using Modelos.Datos.Utils;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Logica.Negocio.Implementacion.Logic.mejora;
using Logica.Negocio.Implementacion.Logic.secuencial;
using Logica.Negocio.Interfaces.Logic.secuencial;
using Logica.Negocio.Implementacion.Logic.emision;
using Logica.Negocio.Interfaces.Logic.emision;

namespace SGRManagement.Efictec
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);

            services.AddSingleton<IUnitOfWork>(option => new UnitOfWork(Configuration.GetConnectionString("local")));
            services.AddTransient<ICredencialesLogic, credencialesLogic>();
            services.AddTransient<IAccesosLogic, accesosLogic>();
            services.AddTransient<IT_personasLogic, personasLogic>();
            services.AddTransient<IMenuLogic, menuLogic>();
            services.AddTransient<IParametrosLogic, parametrosLogic>();
            services.AddTransient<IParametroDetalles, parametroDetallesLogic>();
            services.AddTransient<IConstantesLogic, constantesLogic>();
            services.AddTransient<IEmpresasLogic, empresasLogic>();
            services.AddTransient<IEncryptText, EncriptacionAES>();
            services.AddTransient<IModificarActivoLogic, modificarActivoLogic>();
            services.AddTransient<ISistemasLogic, sistemasLogic>();
            services.AddTransient<IEmpresaSistemasLogic, empresaSistemasLogic>();
            services.AddTransient<IEmpresaSistemaUsuariosLogic, empresaSistemaUsuariosLogic>();
            services.AddTransient<IIncidenciaArchivosLogic, incidenciaArchivosLogic>();
            services.AddTransient<IIncidenciaAsignacionesLogic, incidenciaAsignacionesLogic>();
            services.AddTransient<IIncidenciaComentariosLogic, incidenciaComentariosLogic>();
            services.AddTransient<IIncidenciasLogic, incidenciasLogic>();
            services.AddTransient<IEmpresaHorariosLogic, empresaHorariosLogic>();
            services.AddTransient<IEmpresaANSLogic, empresaANSLogic>();
            services.AddTransient<IIncidenciaSolucionPalabrasClaveLogic, incidenciaSolucionPalabrasClaveLogic>();
            services.AddTransient<IIncidenciaSolucionLogic, incidenciaSolucionLogic>();
            services.AddTransient<IIncidenciaSolucionArchivosLogic, incidenciaSolucionArchivosLogic>();
            services.AddTransient<ICorreoLogic, correoLogic>();
            services.AddTransient<IIncidenciashistorialLogic, incidenciasHistorialLogic>();
            services.AddTransient<ITipificacionesempresaLogic, tipificacionesEmpresaLogic>();
            services.AddTransient<ITipoincidenciasempresaLogic, tipoIncidenciasEmpresaLogic>();
            services.AddTransient<IMejorasLogic,mejorasLogic>();
            services.AddTransient<IMejoraArchivosLogic, mejoraArchivosLogic>();
            services.AddTransient<IMejoraRegistroActividadesLogic, mejoraRegistroActividadesLogic>();
            services.AddTransient<IMejoraAsignacionesLogic, mejoraAsignacionesLogic>();
            services.AddTransient<ISecuencialesidLogic, secuencialesIdLogic>();
            services.AddTransient<ITablasLogic, tablasLogic>();
            services.AddTransient<IPrioridadhistorialLogic, prioridadHistorialLogic>();
            services.AddTransient<IPedidosLogic, pedidosLogic>();
            services.AddTransient<IPedidosarchivosLogic, pedidosArchivosLogic>();
            services.AddTransient<IPedidosrespuestaLogic, pedidosRespuestaLogic>();
            services.AddTransient<IMuralLogic, muralLogic>();
            services.AddTransient<ITagsLogic, tagsLogic>();
            services.AddTransient<ITagsincidenciasLogic, tagsIncidenciasLogic>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins(Configuration["ServerCors"])
                        .AllowAnyHeader()
                        .AllowAnyMethod() 
                        .AllowAnyOrigin());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = " SGRManagement API SERVICES", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsApi",
                        builder => builder.WithOrigins(Configuration["ServerCors"])
                            .AllowAnyHeader()
                            .AllowAnyMethod());
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                        {
                            new OpenApiSecurityScheme
                            {
                            Reference = new OpenApiReference
                                {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                            }
                   });


                #region Agrega la documentación XML de todos los proyectos referenciados que lo generen
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                    .Union(new AssemblyName[] { currentAssembly.GetName() })
                    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                    .Where(File.Exists).ToArray();
                Array.ForEach(xmlDocs, (d) =>
                {
                    c.IncludeXmlComments(d);
                });
                #endregion

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors("CorsApi");
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0"); }); //para correr en local /swagger/v1/swagger.json
            //en el servidor nube v1/swagger.json
        }
    }
}
