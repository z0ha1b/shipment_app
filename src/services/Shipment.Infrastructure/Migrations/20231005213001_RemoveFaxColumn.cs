using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFaxColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
