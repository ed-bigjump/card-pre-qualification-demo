using CreditCard.PreQualification.Demo.Web.Data;
using CreditCard.PreQualification.Demo.Web.Infrastructure.Cqs;
using CreditCard.PreQualification.Demo.Web.Infrastructure.DateTime;
using CreditCard.PreQualification.Demo.Web.Infrastructure.IpAddress;
using CreditCard.PreQualification.Demo.Web.Recommendation.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CreditCard.PreQualification.Demo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => { o.EnableEndpointRouting = false; });

            services.AddHttpContextAccessor();

            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IClientIpAddressService, ClientIpAddressService>();

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDbContext, AppDbContext>();

            services.AddScoped<ICommandHandler<LogCustomerApplication>, LogCustomerApplicationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHsts(hsts => hsts.MaxAge(365));
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseCsp(opts => opts.DefaultSources(s => s.Self()).StyleSources(s => s.Self().UnsafeInline()));

            app.UseStaticFiles();

            app.UseXfo(xfo => xfo.Deny());
            app.UseXXssProtection(opts => opts.EnabledWithBlockMode());
            app.UseRedirectValidation();
            app.UseNoCacheHttpHeaders();

            app.UseMvcWithDefaultRoute();
        }
    }
}
