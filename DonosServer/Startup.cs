using Core.Interfaces;
using DonosServer.API.Authorization;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DonosServer.API
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
            services.AddControllers();

            services.AddCors();
            services.AddSwaggerGen();

            services.AddDbContext<DonosContext>(options => options.UseMySql(this.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("8.0.20")));

            services.AddTransient<IComplaintLogService, ComplaintLogService>();
            services.AddTransient<IComplaintService, ComplaintService>();
            services.AddTransient<IOfficialService, OfficialService>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<UserContext>();
            services.AddScoped<AuthorizationFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "DonosServer API");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
