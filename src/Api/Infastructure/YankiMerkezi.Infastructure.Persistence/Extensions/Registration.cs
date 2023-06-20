using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YankiMerkezi.Infastructure.Persistence.Context;

namespace YankiMerkezi.Infastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<YankiMerkeziContext>(conf =>
            {
                conf.UseNpgsql(Configuration.ConnectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });


            /*
            Activate this line to create fake data. However, remember that it creates fake data every time you run your project. 
            Therefore, make it inactive after the DB connection is made and the data is processed.

            var seedData = new SeedData();
            seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            */
           
            return services;
        }
    }
}
