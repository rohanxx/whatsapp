using Microsoft.EntityFrameworkCore.Migrations;

namespace socialTrack.Migrations
{
    public partial class addedmessagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageInfoTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SendTo = table.Column<string>(nullable: true),
                    SendFrom = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ConversationSid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageInfoTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageInfoTable");
        }
    }
}
