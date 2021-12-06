namespace EasyTranslatorAPI
{
    using System;
    using EasyTranslatorAPI.Clients;
    using EasyTranslatorAPI.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.Configure<EasyTranslatorConfig>(Configuration.GetSection("EasyTranslatorConfig"));
            services.AddSingleton(typeof(ITranslateClient), typeof(GoogleTranslateClient));
            services.AddTransient(typeof(ITranslatorService), typeof(TranslatorService));
            AddSwagger(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyTranslator API V1");
            });

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"EasyTranslator {groupName}",
                    Version = groupName,
                    Description = "EasyTranslator API",
                    Contact = new OpenApiContact
                    {
                        Name = "Vic Saez",
                        Email = string.Empty,
                        Url = new Uri("https://re-active.org"),
                    },
                });
            });
        }
    }
}
