using GladsonEF.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GladsonEF.Infra.Map;

public class DocumentTypeMap : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.ToTable("FINANCE_DOCUMENT_TYPE");


        //builder
        //  .Property(x => x.Id)
        //  .HasColumnType("int")
        //  .HasColumnName("Id")
        //  .ValueGeneratedOnAdd();

        //builder
        //  .OwnsOne(e => e.Name, builder =>
        //  {
        //      builder
        //      .Property(e => e.FullName)
        //      .IsRequired()
        //      .HasColumnType("Varchar(150)")
        //      .HasColumnName("Name")
        //      .HasMaxLength(150);
        //  });

        builder
          .Navigation(e => e.Name)
          .IsRequired();

        builder
          .OwnsOne(e => e.Name)
          .HasIndex(x => x.FullName)
          .HasDatabaseName("idxDocumentType_Name");

        //builder
        //  .Property(x => x.ShowInAppDesktop)
        //  .HasColumnType("bit")
        //  .HasDefaultValue(1)
        //  .HasColumnName("ShowInAppDesktop")
        //  .IsRequired();

        //builder
        //  .Property(x => x.ShowInAppMobile)
        //  .HasColumnType("bit")
        //  .HasDefaultValue(1)
        //  .HasColumnName("ShowInAppMobile")
        //  .IsRequired();

        //builder
        //  .Property(x => x.ShowInAppWeb)
        //  .HasColumnType("bit")
        //  .HasDefaultValue(1)
        //  .HasColumnName("ShowInAppWeb")
        //  .IsRequired();

        //builder
        //  .Property(x => x.CompanyBusinessId)
        //  .HasColumnType("Bigint")
        //  .HasColumnName("CompanyBusinessId")
        //  .IsRequired();

        //builder
        //  .HasIndex(x => x.CompanyBusinessId)
        //  .HasDatabaseName("idxDocumentType_CompanyBusinessId");


    }
}