using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewspaperServer.Migrations
{
    /// <inheritdoc />
    public partial class AddNorthwindTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address1",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    street = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    house_number = table.Column<int>(type: "int", nullable: false),
                    zip_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__address1__CAA247C8BC71EC90", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "category_id",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false),
                    name_cate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__D54EE9B41743FF23", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "newspaper",
                columns: table => new
                {
                    news_id = table.Column<int>(type: "int", nullable: false),
                    type_news = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__newspape__4C27CCD82E9E50E6", x => x.news_id);
                });

            migrationBuilder.CreateTable(
                name: "packages1",
                columns: table => new
                {
                    package_id = table.Column<int>(type: "int", nullable: false),
                    package_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    payment = table.Column<int>(type: "int", nullable: true),
                    num_newspaper = table.Column<int>(type: "int", nullable: true),
                    num_subscrition = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__packages__63846AE8F6247BC8", x => x.package_id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "type_worker",
                columns: table => new
                {
                    type_worker_id = table.Column<int>(type: "int", nullable: false),
                    name_type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__type_wor__A6E0C52144704B1B", x => x.type_worker_id);
                });

            migrationBuilder.CreateTable(
                name: "news_for_pack",
                columns: table => new
                {
                    news_for_pack_id = table.Column<int>(type: "int", nullable: false),
                    package_id = table.Column<int>(type: "int", nullable: false),
                    news_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__news_for__B8CB6B6E5B5582EF", x => x.news_for_pack_id);
                    table.ForeignKey(
                        name: "FK_news_id",
                        column: x => x.news_id,
                        principalTable: "newspaper",
                        principalColumn: "news_id");
                    table.ForeignKey(
                        name: "FK_package_id",
                        column: x => x.package_id,
                        principalTable: "packages1",
                        principalColumn: "package_id");
                });

            migrationBuilder.CreateTable(
                name: "subscrition",
                columns: table => new
                {
                    sub_id = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    date_add = table.Column<DateOnly>(type: "date", nullable: true),
                    package_id = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subscrit__694106B0F43D03FE", x => x.sub_id);
                    table.ForeignKey(
                        name: "FK_address_id2",
                        column: x => x.address_id,
                        principalTable: "address1",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK_package_id2",
                        column: x => x.package_id,
                        principalTable: "packages1",
                        principalColumn: "package_id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CategoryIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_category_id_CategoryIdId",
                        column: x => x.CategoryIdId,
                        principalTable: "category_id",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "worker",
                columns: table => new
                {
                    worker_id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    type_worker_id = table.Column<int>(type: "int", nullable: false),
                    salary_for_hour = table.Column<int>(type: "int", nullable: true),
                    num_for_week = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__worker__569F8007D7AF20AA", x => x.worker_id);
                    table.ForeignKey(
                        name: "FK_address_id",
                        column: x => x.address_id,
                        principalTable: "address1",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK_type_worker_id",
                        column: x => x.type_worker_id,
                        principalTable: "type_worker",
                        principalColumn: "type_worker_id");
                });

            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    sections_id = table.Column<int>(type: "int", nullable: false),
                    name_sec = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    news_id = table.Column<int>(type: "int", nullable: false),
                    worker_id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sections__CE9F3A87E530728B", x => x.sections_id);
                    table.ForeignKey(
                        name: "FK_category_id1",
                        column: x => x.category_id,
                        principalTable: "category_id",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_news_id2",
                        column: x => x.news_id,
                        principalTable: "newspaper",
                        principalColumn: "news_id");
                    table.ForeignKey(
                        name: "FK_worker_id5",
                        column: x => x.worker_id,
                        principalTable: "worker",
                        principalColumn: "worker_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_for_pack_news_id",
                table: "news_for_pack",
                column: "news_id");

            migrationBuilder.CreateIndex(
                name: "IX_news_for_pack_package_id",
                table: "news_for_pack",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryIdId",
                table: "Products",
                column: "CategoryIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_sections_category_id",
                table: "sections",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_sections_news_id",
                table: "sections",
                column: "news_id");

            migrationBuilder.CreateIndex(
                name: "IX_sections_worker_id",
                table: "sections",
                column: "worker_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscrition_address_id",
                table: "subscrition",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscrition_package_id",
                table: "subscrition",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_worker_address_id",
                table: "worker",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_worker_type_worker_id",
                table: "worker",
                column: "type_worker_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_for_pack");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "sections");

            migrationBuilder.DropTable(
                name: "subscrition");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "category_id");

            migrationBuilder.DropTable(
                name: "newspaper");

            migrationBuilder.DropTable(
                name: "worker");

            migrationBuilder.DropTable(
                name: "packages1");

            migrationBuilder.DropTable(
                name: "address1");

            migrationBuilder.DropTable(
                name: "type_worker");
        }
    }
}
