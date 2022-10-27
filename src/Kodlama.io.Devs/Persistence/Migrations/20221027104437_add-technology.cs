using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addtechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnologyTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramingLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnologyTbl_ProgramingLanguageTbl_ProgramingLanguageId",
                        column: x => x.ProgramingLanguageId,
                        principalTable: "ProgramingLanguageTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TechnologyTbl",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[,]
                {
                    { 1, "WPF", 1 },
                    { 2, ".Net", 1 },
                    { 3, "Spring", 2 },
                    { 4, "JSP", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyTbl_ProgramingLanguageId",
                table: "TechnologyTbl",
                column: "ProgramingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnologyTbl");
        }
    }
}
