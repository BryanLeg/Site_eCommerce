using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteECommerce_TP_.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    p_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    p_height = table.Column<float>(type: "real", nullable: false),
                    p_lenght = table.Column<float>(type: "real", nullable: false),
                    p_width = table.Column<float>(type: "real", nullable: false),
                    p_weight = table.Column<float>(type: "real", nullable: false),
                    p_capacity = table.Column<int>(type: "int", nullable: false),
                    p_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_primary_color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_price = table.Column<float>(type: "real", nullable: false),
                    p_picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_order_count = table.Column<int>(type: "int", nullable: false),
                    p_is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    u_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    u_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_phone_number = table.Column<int>(type: "int", nullable: false),
                    u_firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_postal_code = table.Column<int>(type: "int", nullable: false),
                    u_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    u_is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.u_id);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    op_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    op_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    op_is_visible = table.Column<bool>(type: "bit", nullable: false),
                    op_rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.op_id);
                    table.ForeignKey(
                        name: "FK_Opinions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "u_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ord_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ord_order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ord_delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ord_receipt_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ord_price = table.Column<int>(type: "int", nullable: false),
                    ord_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ord_id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "u_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderedProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderedProductsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "ord_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_OrderedProductsId",
                        column: x => x.OrderedProductsId,
                        principalTable: "Products",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_ProductId",
                table: "Opinions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_UserId",
                table: "Opinions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrdersId",
                table: "OrderProduct",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
