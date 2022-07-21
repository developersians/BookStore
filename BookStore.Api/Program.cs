using BookStore.Application;
using BookStore.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
{
    ////Simpler way is to use builder.Configuration
    //IConfiguration configuration = new ConfigurationBuilder()
    //    .SetBasePath(Directory.GetCurrentDirectory())
    //    .AddJsonFile("appSettings.json", false)
    //    .Build();

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddMediatR(typeof(EntryPoint));
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

// Expose the Program class to use in integration tests through WebApplicationFactory
public partial class Program
{
}
