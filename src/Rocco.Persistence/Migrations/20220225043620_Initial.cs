using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocco.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    Country = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(200)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "varchar(200)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(200)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "Country", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Dummy", new DateTime(2022, 2, 24, 23, 36, 20, 379, DateTimeKind.Local).AddTicks(8583), false, null, null, "Admin_Solutions Ltd" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "Country", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "Dummy", new DateTime(2022, 2, 24, 23, 36, 20, 379, DateTimeKind.Local).AddTicks(8570), false, null, null, "IT_Solutions Ltd" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name", "Position" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Dummy", new DateTime(2022, 2, 24, 23, 36, 20, 379, DateTimeKind.Local).AddTicks(9918), false, null, null, "Kane Miller", "Administrator" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name", "Position" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Dummy", new DateTime(2022, 2, 24, 23, 36, 20, 379, DateTimeKind.Local).AddTicks(9910), false, null, null, "Sam Raiden", "Software developer" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name", "Position" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Dummy", new DateTime(2022, 2, 24, 23, 36, 20, 379, DateTimeKind.Local).AddTicks(9916), false, null, null, "Jana McLeaf", "Software developer" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
