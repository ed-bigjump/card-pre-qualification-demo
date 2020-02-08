using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCard.PreQualification.Demo.Web.Migrations
{
    public partial class CustomerApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AnnualIncome = table.Column<int>(nullable: false),
                    RecommendedCards = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerApplications");
        }
    }
}
