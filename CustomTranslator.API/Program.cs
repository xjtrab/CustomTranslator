using CustomTranslator.API.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Replace with your connection string.
var connectionString = builder.Configuration.GetConnectionString("TranslatorDatabase");

// Replace with your server version and type.
// Use 'MariaDbServerVersion' for MariaDB.
// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// For common usages, see pull request #1233.
var serverVersion = new MySqlServerVersion(new Version(5, 7, 24));
Console.WriteLine(string.Format(connectionString, Environment.GetEnvironmentVariable("DATABASE_HOST")));
builder.Services.AddDbContext<TranslatorContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(string.Format(connectionString, Environment.GetEnvironmentVariable("DATABASE_HOST")), serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        //.LogTo(Console.WriteLine, LogLevel.Debug)
        //.EnableSensitiveDataLogging()
        //.EnableDetailedErrors()
);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.Services.CreateScope().ServiceProvider.GetService<TranslatorContext>().Database.MigrateAsync();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
