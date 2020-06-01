using Microsoft.EntityFrameworkCore.Migrations;

namespace PPT_Grpc.Migrations
{
    public partial class BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Nome = table.Column<string>(nullable: false),
                    vitorias = table.Column<int>(nullable: false),
                    empates = table.Column<int>(nullable: false),
                    derrotas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Nome);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
