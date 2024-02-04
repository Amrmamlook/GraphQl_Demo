using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQl_Demo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "Main" },
                    { 3, "Drinks" },
                    { 4, "Burger" },
                    { 5, "Pizza" },
                    { 6, "Pasta" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 4, "A juicy chicken burger with lettuce and cheese", "Classic Burger", 8.9900000000000002 },
                    { 2, 5, "Tomato, mozzarella, and basil pizza", "Margherita Pizza", 10.5 },
                    { 3, 2, "Fresh garden salad with grilled chicken", "Grilled Chicken Salad", 7.9500000000000002 },
                    { 4, 6, "Creamy Alfredo sauce with fettuccine pasta", "Pasta Alfredo", 12.75 },
                    { 5, 3, "Warm chocolate brownie with ice cream and fudge", "Chocolate Brownie Sundae", 6.9900000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
