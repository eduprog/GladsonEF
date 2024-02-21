
using GladsonEF;
using GladsonEF.Extensions;
using GladsonEF.Infra;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;


//Iniciando o log
SerilogExtensions.EnsureInitialized();

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    // Add services to the container.

    builder.AddCustomSerilog(); //Adcionando configuracoes detalhadas de log.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    //adicionando o contexto. 
    //Uso a extensão do WebApplicationBuilder pq ele tem tudo, inclusive as configurações. 
    builder.AddContextDeTeste();

    //Adcionando os serviços de log que serão utilizados pelos middlewares se estiver configurado no appsettings.json
    builder.AddRequestLogging();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    //Adcionando logs de Request e Response apenas para melhorar a depuraçõa
    app.UseRequestLogging();


    app.MapControllers();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("HostAbortedException", StringComparison.Ordinal))
{ 
    SerilogExtensions.EnsureInitialized();
    Log.Fatal(ex, "Excessão não tratada.");
}
finally
{
    SerilogExtensions.EnsureInitialized();
    Log.Information("Desligando Servidor...");
    Log.CloseAndFlush();
}