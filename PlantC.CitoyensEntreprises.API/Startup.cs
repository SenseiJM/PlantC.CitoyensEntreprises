using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;
using PlantC.CitoyensEntreprise.DAL.Enums;
using PlantC.CitoyensEntreprise.DAL.Repositories;
using PlantC.CitoyensEntreprises.BLL.Services;
using System.Net.Mail;
using ToolBox.Security.Configuration;
using ToolBox.Security.DependencyInjection.Extensions;

namespace PlantC.CitoyensEntreprises.API {
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlantC.CitoyensEntreprises.API", Version = "v1" });
                OpenApiSecurityScheme securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Fonction>("fonction");
            services.AddScoped<NpgsqlConnection>((s) => new NpgsqlConnection(Configuration.GetConnectionString("Default")));

            #region JWT
            services.AddJwt(Configuration.GetSection("JWT").Get<JwtConfiguration>());
            #endregion

            #region Service Mail
            services.AddSingleton(Configuration.GetSection("SMTP").Get<MailConfig>());
            services.AddScoped<SmtpClient>();
            services.AddScoped<MailService>(); 
            #endregion

            #region Service Data
            services.AddScoped<ParticipantService>();
            services.AddScoped<HashService>();
            services.AddScoped<ProjetService>();
            services.AddScoped<UserService>();
            services.AddScoped<MarqueursService>();
            services.AddScoped<LocalisationService>();
            services.AddScoped<TacheService>();
            #endregion


            #region Repository
            services.AddScoped<LocalisationRepository>();
            services.AddScoped<ParticipantRepository>();
            services.AddScoped<ProjetRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<TagRepository>();
            services.AddScoped<TacheRepository>();
            #endregion

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlantC.CitoyensEntreprises.API v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
