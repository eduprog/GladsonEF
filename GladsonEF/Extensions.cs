using GladsonEF.Domain.Configuration;
using GladsonEF.Infra;
using GladsonEF.Middleware;
using Microsoft.EntityFrameworkCore;

namespace GladsonEF;

internal static class ProgramExtensions
{
    internal static WebApplicationBuilder AddContextDeTeste(this WebApplicationBuilder builder)
    {

        //Posso pegar as configurações de varias maneiras 
        var connStringSqlServer = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value; 
        var connStringSqlite = builder.Configuration.GetConnectionString("Sqlite");
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(connStringSqlite);
        });
        return builder;
    }


    internal static WebApplicationBuilder AddRequestLogging(this WebApplicationBuilder builder)
    {
        //Adicionando o ICurrentUser apenas para exemplificar que posso adicionar qualquer serviço que eu quiser.
        builder.Services.AddScoped<ICurrentUser, CurrentUser>();
        var config = builder.Configuration.GetSection(nameof(MiddlewareSettings)).Get<MiddlewareSettings>()!;
        if (config.EnableHttpsLogging)
        {
            builder.Services.AddSingleton<RequestLoggingMiddleware>();
            builder.Services.AddScoped<ResponseLoggingMiddleware>();
        }

        return builder;
    }


    internal static WebApplication UseRequestLogging(this WebApplication app)
    {
        var config = app.Configuration.GetSection(nameof(MiddlewareSettings)).Get<MiddlewareSettings>()!;

        if (config.EnableHttpsLogging)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ResponseLoggingMiddleware>();
        }

        return app;
    }
}