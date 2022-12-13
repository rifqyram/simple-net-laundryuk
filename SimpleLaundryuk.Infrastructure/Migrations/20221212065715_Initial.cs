using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleLaundryuk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    mobilephone = table.Column<string>(name: "mobile_phone", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_bill",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    transdate = table.Column<DateTime>(name: "trans_date", type: "timestamp with time zone", nullable: false),
                    customerid = table.Column<Guid>(name: "customer_id", type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_bill_m_customer_customer_id",
                        column: x => x.customerid,
                        principalTable: "m_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "m_product_price",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false),
                    productid = table.Column<Guid>(name: "product_id", type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_product_price", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_product_price_m_product_product_id",
                        column: x => x.productid,
                        principalTable: "m_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_bill_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    billid = table.Column<Guid>(name: "bill_id", type: "uuid", nullable: false),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    productpriceid = table.Column<Guid>(name: "product_price_id", type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_bill_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_bill_detail_m_product_price_product_price_id",
                        column: x => x.productpriceid,
                        principalTable: "m_product_price",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_bill_detail_t_bill_bill_id",
                        column: x => x.billid,
                        principalTable: "t_bill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_product_price_product_id",
                table: "m_product_price",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_customer_id",
                table: "t_bill",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_detail_bill_id",
                table: "t_bill_detail",
                column: "bill_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_bill_detail_product_price_id",
                table: "t_bill_detail",
                column: "product_price_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_bill_detail");

            migrationBuilder.DropTable(
                name: "m_product_price");

            migrationBuilder.DropTable(
                name: "t_bill");

            migrationBuilder.DropTable(
                name: "m_product");

            migrationBuilder.DropTable(
                name: "m_customer");
        }
    }
}
