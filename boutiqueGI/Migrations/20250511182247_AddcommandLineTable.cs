using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boutiqueGI.Migrations
{
    /// <inheritdoc />
    public partial class AddcommandLineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Commandes_CommandesId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Commandes_CommandesId",
                table: "Produits");

            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Commandes_CommandesId1",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_CommandesId",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_CommandesId1",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CommandesId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Checked",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "CommandesId",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "CommandesId1",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "CommandesId",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Commandes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "CommandeLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CommandesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProduitsId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommandeLines_Commandes_CommandesId",
                        column: x => x.CommandesId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandeLines_Produits_ProduitsId",
                        column: x => x.ProduitsId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeLines_CommandesId",
                table: "CommandeLines",
                column: "CommandesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeLines_ProduitsId",
                table: "CommandeLines",
                column: "ProduitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes");

            migrationBuilder.DropTable(
                name: "CommandeLines");

            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "Produits",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CommandesId",
                table: "Produits",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CommandesId1",
                table: "Produits",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Commandes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CommandesId",
                table: "Clients",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CommandesId",
                table: "Produits",
                column: "CommandesId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CommandesId1",
                table: "Produits",
                column: "CommandesId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CommandesId",
                table: "Clients",
                column: "CommandesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Commandes_CommandesId",
                table: "Clients",
                column: "CommandesId",
                principalTable: "Commandes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Commandes_CommandesId",
                table: "Produits",
                column: "CommandesId",
                principalTable: "Commandes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Commandes_CommandesId1",
                table: "Produits",
                column: "CommandesId1",
                principalTable: "Commandes",
                principalColumn: "Id");
        }
    }
}
