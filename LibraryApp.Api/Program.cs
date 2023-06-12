using LibraryApp.Api.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

var configuration = new ConfigurationBuilder()
                    .SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

StartupHelper.ConfigureDatabase(builder.Services, configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
