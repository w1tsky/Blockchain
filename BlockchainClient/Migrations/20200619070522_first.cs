using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace BlockchainClient.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "C##BLOCKCHAIN");

            migrationBuilder.CreateTable(
                name: "Blockchains",
                schema: "C##BLOCKCHAIN",
                columns: table => new
                {
                    BlockchainID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    BlockchainName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockchains", x => x.BlockchainID);
                });

            migrationBuilder.CreateTable(
                name: "BlockchainUser",
                schema: "C##BLOCKCHAIN",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    UserData = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockchainUser", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                schema: "C##BLOCKCHAIN",
                columns: table => new
                {
                    BlockID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    PreviousHash = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    BlockchainID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.BlockID);
                    table.ForeignKey(
                        name: "FK_Blocks_Blockchains_BlockchainID",
                        column: x => x.BlockchainID,
                        principalSchema: "C##BLOCKCHAIN",
                        principalTable: "Blockchains",
                        principalColumn: "BlockchainID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockchainID",
                schema: "C##BLOCKCHAIN",
                table: "Blocks",
                column: "BlockchainID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockchainUser",
                schema: "C##BLOCKCHAIN");

            migrationBuilder.DropTable(
                name: "Blocks",
                schema: "C##BLOCKCHAIN");

            migrationBuilder.DropTable(
                name: "Blockchains",
                schema: "C##BLOCKCHAIN");
        }
    }
}
