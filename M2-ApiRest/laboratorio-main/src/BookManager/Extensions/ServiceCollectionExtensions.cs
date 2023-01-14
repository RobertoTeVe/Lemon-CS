using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace BookManager.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            var mainAssemblyName = typeof(Startup).Assembly.GetName().Name;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = mainAssemblyName,
                    Version = "v1",
                    Description = "Book Manager DB",
                    Contact = new OpenApiContact
                    {
                        Name = "Roberto Alonso"
                    }
                });

                c.DocumentFilter<LowerCaseDocumentFilter>();
            });

            return services;
        }

    }

    public class LowerCaseDocumentFilter
    : IDocumentFilter
    {
        private static string LowercaseEverythingButParameters(string key) => string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths.ToDictionary(entry => LowercaseEverythingButParameters(entry.Key),
                entry => entry.Value);
            swaggerDoc.Paths = new OpenApiPaths();
            foreach (var (key, value) in paths)
            {
                swaggerDoc.Paths.Add(key, value);
            }
        }
    }

}
