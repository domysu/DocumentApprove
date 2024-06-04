using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DokumentuTvirtinimoSistema.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditDocumentId = table.Column<int>(type: "int", nullable: false),
                    AuditStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRequests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTemplates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldsStructure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTemplates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCorrections",
                columns: table => new
                {
                    DataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentRequestRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCorrections", x => x.DataId);
                    table.ForeignKey(
                        name: "FK_DocumentCorrections_DocumentRequests_DocumentRequestRequestId",
                        column: x => x.DocumentRequestRequestId,
                        principalTable: "DocumentRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentData",
                columns: table => new
                {
                    DataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentData", x => x.DataId);
                    table.ForeignKey(
                        name: "FK_DocumentData_DocumentRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "DocumentRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentReviews_DocumentRequests_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "DocumentRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentReviewId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationLogs_DocumentReviews_DocumentReviewId",
                        column: x => x.DocumentReviewId,
                        principalTable: "DocumentReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCorrections_DocumentRequestRequestId",
                table: "DocumentCorrections",
                column: "DocumentRequestRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_RequestId",
                table: "DocumentData",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentReviews_DocumentId",
                table: "DocumentReviews",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationLogs_DocumentReviewId",
                table: "ValidationLogs",
                column: "DocumentReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "DocumentCorrections");

            migrationBuilder.DropTable(
                name: "DocumentData");

            migrationBuilder.DropTable(
                name: "DocumentTemplates");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ValidationLogs");

            migrationBuilder.DropTable(
                name: "WorkflowStatus");

            migrationBuilder.DropTable(
                name: "DocumentReviews");

            migrationBuilder.DropTable(
                name: "DocumentRequests");
        }
    }
}
