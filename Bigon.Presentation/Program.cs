using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bigon.Application;
using Bigon.Application.Services.File;
using Bigon.Application.Services.Identity;
using Bigon.Infrastructure.Abstracts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Bigon.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DbContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationReferance>());

            builder.Host.UseServiceProviderFactory(new BigonServiceProviderFactory());

            builder.Services.AddScoped<IIdentityService, FakeIdentityService>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            builder.Services.AddValidatorsFromAssemblyContaining<IApplicationReferance>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}
