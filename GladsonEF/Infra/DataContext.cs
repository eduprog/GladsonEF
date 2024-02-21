using GladsonEF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GladsonEF.Infra;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }


    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // QueryFilters need to be applied before base.OnModelCreating
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly); // Aplica todos mapeamentos que estão no mesmo assembly que DataContext
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging(); // Define para ser apresentado logs detalhados
        optionsBuilder.LogTo(Console.WriteLine,
            new[] { RelationalEventId.CommandExecuted });
        //optionsBuilder.LogTo(_logStream.WriteLine);
#endif
    }

}