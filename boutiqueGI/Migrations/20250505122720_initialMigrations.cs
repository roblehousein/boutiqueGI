using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boutiqueGI.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CommandesId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClientId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ClientName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCommande = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total_Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Qt = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateExp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateCrea = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Remise = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Checked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CommandesId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CommandesId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_Commandes_CommandesId",
                        column: x => x.CommandesId,
                        principalTable: "Commandes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produits_Commandes_CommandesId1",
                        column: x => x.CommandesId1,
                        principalTable: "Commandes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CommandesId",
                table: "Clients",
                column: "CommandesId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientId",
                table: "Commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CommandesId",
                table: "Produits",
                column: "CommandesId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CommandesId1",
                table: "Produits",
                column: "CommandesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Commandes_CommandesId",
                table: "Clients",
                column: "CommandesId",
                principalTable: "Commandes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Commandes_CommandesId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
