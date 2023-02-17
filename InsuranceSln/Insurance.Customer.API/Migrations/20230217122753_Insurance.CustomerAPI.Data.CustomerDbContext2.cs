using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.CustomerAPI.Migrations
{
    public partial class InsuranceCustomerAPIDataCustomerDbContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");
        }
    }
}
