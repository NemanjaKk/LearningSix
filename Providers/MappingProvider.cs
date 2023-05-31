using LearningSix.Dto;
using LearningSix.Models;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace LearningSix.Providers
{
    public static class MappingProvider
    {
        public static void Register(WebApplicationBuilder builder)
        {
            var config = new TypeAdapterConfig();
            // Or
            // var config = TypeAdapterConfig.GlobalSettings;

            builder.Services.AddSingleton(config);
            builder.Services.AddScoped<IMapper, ServiceMapper>();
            TypeAdapterConfig<WeaponDto, Weapon>.NewConfig().Map(dest => dest.Name, src => src.WeaponName);
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
