namespace LearningSix.Providers
{
    public class WebApplicationProvider
    {
        public static WebApplication Build(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            DbProvider.Register(builder);
            SwaggerProvider.Register(builder);
            MappingProvider.Register(builder);

            return builder.Build();
        }
    }
}
