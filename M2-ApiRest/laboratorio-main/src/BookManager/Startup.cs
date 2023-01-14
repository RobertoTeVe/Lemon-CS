using BookManager.Extensions;
using BookManager.Domain;
using BookManager.Application;
using Microsoft.EntityFrameworkCore;


namespace BookManager
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Contenedor de dependencias (Dependency Injection Container)
        public void ConfigureServices(IServiceCollection services)
        {
            var booksConnectionString =
                _configuration.GetValue<string>("ConnectionStrings:BooksDataBase");

            services
                .AddTransient<BookCommandServices>()
                .AddDbContext<BookDbContext>(options =>
                {
                    options.UseSqlServer(booksConnectionString);
                })
                .AddScoped<IBookDbContext, BookDbContext>()
                .AddOpenApi()
                .AddControllers();
        }

        // Middleware pipeline
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseOpenApi();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
