using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomClothingApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewRemoveTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_status_orders",
                table: "orders");

            migrationBuilder.DropTable(
                name: "orderstagehistory");

            migrationBuilder.DropTable(
                name: "orderstatuses");

            migrationBuilder.DropIndex(
                name: "IX_orders_statusid",
                table: "orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderstagehistory",
                columns: table => new
                {
                    stagehistoryid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderid = table.Column<int>(type: "integer", nullable: true),
                    stagedate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    stagedescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    stagename = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orderstagehistory_pkey", x => x.stagehistoryid);
                    table.ForeignKey(
                        name: "orderstagehistory_orderid_fkey",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "orderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderstatuses",
                columns: table => new
                {
                    statusid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    statusname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orderstatuses_pkey", x => x.statusid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_statusid",
                table: "orders",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_orderstagehistory_orderid",
                table: "orderstagehistory",
                column: "orderid");

            migrationBuilder.AddForeignKey(
                name: "fk_status_orders",
                table: "orders",
                column: "statusid",
                principalTable: "orderstatuses",
                principalColumn: "statusid");
        }
    }
}
