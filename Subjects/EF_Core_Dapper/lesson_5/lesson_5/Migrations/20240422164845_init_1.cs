﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lesson_5.Migrations
{
    /// <inheritdoc />
    public partial class init_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ClientSequence");

            migrationBuilder.CreateSequence(
                name: "PersonalSequence");

            migrationBuilder.CreateSequence(
                name: "ProductSequence");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ProductSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ProductSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonalSequence]"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonalSequence]"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ProductSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CallTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplies_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ClientId",
                table: "Calls",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ConsultantId",
                table: "Calls",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BuyerId",
                table: "Purchases",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ManagerId",
                table: "Purchases",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductId",
                table: "Purchases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_ManagerId",
                table: "Supplies",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_ProductId",
                table: "Supplies",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_ProviderId",
                table: "Supplies",
                column: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropSequence(
                name: "ClientSequence");

            migrationBuilder.DropSequence(
                name: "PersonalSequence");

            migrationBuilder.DropSequence(
                name: "ProductSequence");
        }
    }
}
