using Microsoft.EntityFrameworkCore;
using Persistence;

namespace TestApp
{
    public static class AutoApplyMigrations
    {
        public static void ApplyMigrations(this IApplicationBuilder builder)
        {
            using IServiceScope scope = builder.ApplicationServices.CreateScope();
            using DataContext dbContext =
                scope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Database.Migrate();
        }
    }
}
