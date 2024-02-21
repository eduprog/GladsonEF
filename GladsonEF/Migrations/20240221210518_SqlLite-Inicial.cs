using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GladsonEF.Migrations
{
    /// <inheritdoc />
    public partial class SqlLiteInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FINANCE_DOCUMENT_TYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name_FullName = table.Column<string>(type: "TEXT", nullable: false),
                    ShowInAppDesktop = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowInAppMobile = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowInAppWeb = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompanyBusinessId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FINANCE_DOCUMENT_TYPE", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idxDocumentType_Name",
                table: "FINANCE_DOCUMENT_TYPE",
                column: "Name_FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FINANCE_DOCUMENT_TYPE");
        }
    }
}
