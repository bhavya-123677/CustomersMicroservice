using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomersMicroservice.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Propertyid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget = table.Column<int>(nullable: false),
                    PropertyType = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Propertyid);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    Locality = table.Column<string>(nullable: true),
                    Customerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.id);
                    table.ForeignKey(
                        name: "FK_Requirement_Customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_Customerid",
                table: "Requirement",
                column: "Customerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
