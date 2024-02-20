using TVScheduler.Business;
using TVScheduler.Business.Helpers;
using TVScheduler.Business.Interfaces;
using TVScheduler.DataAccess;
using TVScheduler.DataAccess.Helpers;
using TVScheduler.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);

var app = builder.Build();

app.UseErrorHandlerMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IConnectionProvider, ConnectionProvider>();

    services.AddAutoMapper(typeof(AutoMapperProfile));

    services.AddScoped<IProgramRepository, ProgramRepository>();
    services.AddScoped<IChannelRepository, ChannelRepository>();

    services.AddScoped<IProgramService, ProgramService>();
    services.AddScoped<IChannelService, ChannelService>();
}