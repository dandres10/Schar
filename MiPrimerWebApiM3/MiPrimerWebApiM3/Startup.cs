namespace MiPrimerWebApiM3
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MiPrimerWebApiM3.Contexts;
    using MiPrimerWebApiM3.Entities;
    using MiPrimerWebApiM3.Helpers;
    using MiPrimerWebApiM3.Models;
    using MiPrimerWebApiM3.Services;

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
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Autor, AutorDTO>().ReverseMap();
            }, typeof(Startup));
            services.AddScoped<MiFiltroDeAccion>();
            services.AddResponseCaching();
            services.AddTransient<ClaseB>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            //services.AddTransient<IHostedService, ConsumeScopedService>(); // como un servicio windows
            services.AddControllers(options =>
            {
                options.Filters.Add(new MiFiltroDeException());
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            //services.AddTransient<IClaseB, ClaseB2>();

            //services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options =>
            //            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //        );
            services.AddControllersWithViews()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}