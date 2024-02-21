using GladsonEF.Domain;
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



    internal static void VerificaExistenciaBanco(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();

        // usando o context de acordo com suas configurações. 
        using var _context = scope.ServiceProvider.GetRequiredService<DataContext>();

        if (_context.Database.EnsureCreated())
        {
            // Aqui a gente pode criar um seed para o banco de dados pq os dados foram criados de documentype
            _context.DocumentTypes.Add(new DocumentType("CPF", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("RG", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("CNPJ", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("IE", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Passaporte", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("CNH", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Titulo de Eleitor", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Nascimento", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Casamento", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Óbito", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Divórcio", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de União Estável", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Interdição", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Tutela", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Curatela", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Guarda", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Adoção", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Nada Consta", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Protesto", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Quitação Eleitoral", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do FGTS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do INSS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ICMS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ISS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ITR", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do IPTU", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do IPVA", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ITBI", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ITCD", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDT", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CND", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDI", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDL", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDM", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDP", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDH", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDG", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDJ", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDK", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDQ", true, true, true, 0));
            _context.SaveChanges();

        };

    }   
}