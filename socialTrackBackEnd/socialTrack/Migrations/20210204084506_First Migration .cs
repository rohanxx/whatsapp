using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace socialTrack.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsTable",
                columns: table => new
                {
                    User_Id = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsUpdated = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    updatedDateTime = table.Column<DateTime>(nullable: true),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Email_Id = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    User_Password = table.Column<string>(nullable: true),
                    Last_LogIn_Date = table.Column<DateTime>(nullable: false),
                    Password_GenerateDateTime = table.Column<DateTime>(nullable: false),
                    OTP = table.Column<string>(nullable: true),
                    OTP_GenerateTime = table.Column<DateTime>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsTable", x => x.User_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsTable");
        }
    }
}
