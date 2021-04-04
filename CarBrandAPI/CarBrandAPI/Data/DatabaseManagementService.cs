using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarBrandAPI.Data
{
    public static class DatabaseManagementService
    {
        /// <summary>
        /// Gets the scope of the database context
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void MigrationInitialization(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Takes all of the migration files and applies them to the database in case they are not implemented
                serviceScope.ServiceProvider.GetService<CarBrandContext>().Database.Migrate();
            }
        }
    }
}
