using Microsoft.EntityFrameworkCore;
using Odata.Application.Service;
using Persistence.EF;
using Persistence.EF.Repository;
using Utility.marker;

namespace ODataProject.ProviderExtensions
{
    public static class ServiceProviderServiceExtensions
    {


        public static void InjectScope(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssembliesOf(typeof(AreaRepository))
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan.FromAssembliesOf(typeof(AreaService))
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        public static void DatabaseContext(this IServiceCollection services, string connection)
        {
            services.AddDbContextFactory<OdataDbContext>(x =>
                x.UseSqlServer(connection));
        }

        public static void UpgradeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<OdataDbContext>();
            db.Database.Migrate();
        }
    }
}
