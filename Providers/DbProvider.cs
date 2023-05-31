using LearningSix.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningSix.Providers
{
    public static class DbProvider
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
