var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//string connString = ConfigurationManager("ConnectionStringSql").ToString();

app.MapGet("/", () => "Hello World!");

app.Run();
