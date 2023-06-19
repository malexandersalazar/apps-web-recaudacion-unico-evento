using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniqueFundraisingEvent.Web.Application.Contracts.Persistence;
using UniqueFundraisingEvent.Web.Common.Application;
using UniqueFundraisingEvent.Web.Common.Persistence;

namespace UniqueFundraisingEvent.Web.Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<DbContext, CompanyDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("Company"),
            //            builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
            //);

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<DbContext>(x => x.GetRequiredService<ApplicationDbContext>());
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<UnitOfWork, ApplicationUnitOfWork>();

            return services;
        }
    }
}