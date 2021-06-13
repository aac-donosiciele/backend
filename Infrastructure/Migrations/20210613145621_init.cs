using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Officials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officials", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Pesel = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TargetFirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SenderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SendTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComplaintsLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OfficialId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ComplaintId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintsLogs_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplaintsLogs_Officials_OfficialId",
                        column: x => x.OfficialId,
                        principalTable: "Officials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Officials",
                columns: new[] { "Id", "Category", "CreatedDate", "LastModifiedDate" },
                values: new object[,]
                {
                    { new Guid("b5aad52c-9722-4ef6-a67d-91afb407d891"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ce0a49a-4268-47c6-b3fd-122ef222f818"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Category", "CreatedDate", "IsVerified", "LastModifiedDate", "PasswordHash", "Pesel", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("b5aad52c-9722-4ef6-a67d-91afb407d891"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a48dbf15d3c2e171b9328005d5727589903c0083b524efba66ea1516231bca85", "112345678", 2, "megaAdmin" },
                    { new Guid("562f5237-43b2-4ea5-9094-e21912a4f03b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e8e7b468dcb0446072821a7e5ffb21344ac784c3d6a02192f58df2764cd555e6", "012345678", 0, "megaAdmin12" },
                    { new Guid("8ce0a49a-4268-47c6-b3fd-122ef222f818"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "41455bd85390f866c132887d4ec3771240b21700c1b8de233ddab2d832c20c00", "012345690", 1, "megaAdmin123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_Id",
                table: "Complaints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_SenderId",
                table: "Complaints",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsLogs_ComplaintId_CreatedDate_OfficialId",
                table: "ComplaintsLogs",
                columns: new[] { "ComplaintId", "CreatedDate", "OfficialId" });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsLogs_OfficialId",
                table: "ComplaintsLogs",
                column: "OfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_Officials_Id",
                table: "Officials",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintsLogs");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Officials");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
