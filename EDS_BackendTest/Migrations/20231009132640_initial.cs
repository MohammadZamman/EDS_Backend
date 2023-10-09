using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_BackendTest.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    ColumnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ColNameExternalDB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.ColumnId);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    FrequencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfMonth = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.FrequencyID);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    LookUpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lookup_visible_value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lookup_hidden_value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.LookUpID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrgID);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TemplateID);
                    table.ForeignKey(
                        name: "FK_Templates_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Organization = table.Column<int>(type: "int", nullable: false),
                    OrganizationOrgID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Organizations_OrganizationOrgID",
                        column: x => x.OrganizationOrgID,
                        principalTable: "Organizations",
                        principalColumn: "OrgID");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationLevels",
                columns: table => new
                {
                    LevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationLevels", x => x.LevelID);
                    table.ForeignKey(
                        name: "FK_OrganizationLevels_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrgID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateColumns",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    ColumnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateColumns", x => new { x.TemplateID, x.ColumnId });
                    table.ForeignKey(
                        name: "FK_TemplateColumns_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "ColumnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateColumns_Templates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Templates",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataRecepients",
                columns: table => new
                {
                    DataRecipientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRecipientInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    LookUpID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRecepients", x => x.DataRecipientID);
                    table.ForeignKey(
                        name: "FK_DataRecepients_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataRecepients_Lookup_LookUpID",
                        column: x => x.LookUpID,
                        principalTable: "Lookup",
                        principalColumn: "LookUpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notificationRecepients",
                columns: table => new
                {
                    NotificationRecipientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationRecipientInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    LookUpID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationRecepients", x => x.NotificationRecipientID);
                    table.ForeignKey(
                        name: "FK_notificationRecepients_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationRecepients_Lookup_LookUpID",
                        column: x => x.LookUpID,
                        principalTable: "Lookup",
                        principalColumn: "LookUpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sublevels",
                columns: table => new
                {
                    SublevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrganizationLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sublevels", x => x.SublevelID);
                    table.ForeignKey(
                        name: "FK_Sublevels_OrganizationLevels_OrganizationLevelId",
                        column: x => x.OrganizationLevelId,
                        principalTable: "OrganizationLevels",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Criterias",
                columns: table => new
                {
                    CriteriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilterColumnValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    LookupId = table.Column<int>(type: "int", nullable: false),
                    TemplateColumnID = table.Column<int>(type: "int", nullable: false),
                    TemplateColumnTemplateID = table.Column<int>(type: "int", nullable: false),
                    TemplateColumnColumnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterias", x => x.CriteriaID);
                    table.ForeignKey(
                        name: "FK_Criterias_Lookup_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Lookup",
                        principalColumn: "LookUpID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criterias_TemplateColumns_TemplateColumnTemplateID_TemplateColumnColumnId",
                        columns: x => new { x.TemplateColumnTemplateID, x.TemplateColumnColumnId },
                        principalTable: "TemplateColumns",
                        principalColumns: new[] { "TemplateID", "ColumnId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendNotification = table.Column<bool>(type: "bit", nullable: false),
                    MinRecordCountAlarm = table.Column<int>(type: "int", nullable: true),
                    MaxRecordCountAlarm = table.Column<int>(type: "int", nullable: true),
                    MinRunDurationAlarm = table.Column<int>(type: "int", nullable: true),
                    MaxRunDurationAlarm = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CriteriaID = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    FrequencyID = table.Column<int>(type: "int", nullable: false),
                    LookupID = table.Column<int>(type: "int", nullable: false),
                    LookupsLookUpID = table.Column<int>(type: "int", nullable: true),
                    TemplateID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Jobs_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Criterias_CriteriaID",
                        column: x => x.CriteriaID,
                        principalTable: "Criterias",
                        principalColumn: "CriteriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Frequencies_FrequencyID",
                        column: x => x.FrequencyID,
                        principalTable: "Frequencies",
                        principalColumn: "FrequencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Lookup_LookupID",
                        column: x => x.LookupID,
                        principalTable: "Lookup",
                        principalColumn: "LookUpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Lookup_LookupsLookUpID",
                        column: x => x.LookupsLookUpID,
                        principalTable: "Lookup",
                        principalColumn: "LookUpID");
                    table.ForeignKey(
                        name: "FK_Jobs_Templates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Templates",
                        principalColumn: "TemplateID");
                    table.ForeignKey(
                        name: "FK_Jobs_Templates_TemplateID1",
                        column: x => x.TemplateID1,
                        principalTable: "Templates",
                        principalColumn: "TemplateID");
                });

            migrationBuilder.CreateTable(
                name: "JobLogs",
                columns: table => new
                {
                    JobLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRunDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobRunDuration = table.Column<int>(type: "int", nullable: false),
                    ExtractSuccess = table.Column<bool>(type: "bit", nullable: false),
                    NotificationRecipientSuccess = table.Column<bool>(type: "bit", nullable: false),
                    ExtractedRecordCount = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLogs", x => x.JobLogID);
                    table.ForeignKey(
                        name: "FK_JobLogs_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OrganizationOrgID",
                table: "Clients",
                column: "OrganizationOrgID");

            migrationBuilder.CreateIndex(
                name: "IX_Criterias_LookupId",
                table: "Criterias",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterias_TemplateColumnTemplateID_TemplateColumnColumnId",
                table: "Criterias",
                columns: new[] { "TemplateColumnTemplateID", "TemplateColumnColumnId" });

            migrationBuilder.CreateIndex(
                name: "IX_DataRecepients_ClientID",
                table: "DataRecepients",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_DataRecepients_LookUpID",
                table: "DataRecepients",
                column: "LookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_JobLogs_JobID",
                table: "JobLogs",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ClientID",
                table: "Jobs",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CriteriaID",
                table: "Jobs",
                column: "CriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FrequencyID",
                table: "Jobs",
                column: "FrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_LookupID",
                table: "Jobs",
                column: "LookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_LookupsLookUpID",
                table: "Jobs",
                column: "LookupsLookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TemplateID",
                table: "Jobs",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TemplateID1",
                table: "Jobs",
                column: "TemplateID1");

            migrationBuilder.CreateIndex(
                name: "IX_notificationRecepients_ClientID",
                table: "notificationRecepients",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_notificationRecepients_LookUpID",
                table: "notificationRecepients",
                column: "LookUpID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLevels_OrganizationId",
                table: "OrganizationLevels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sublevels_OrganizationLevelId",
                table: "Sublevels",
                column: "OrganizationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateColumns_ColumnId",
                table: "TemplateColumns",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_CategoryId",
                table: "Templates",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataRecepients");

            migrationBuilder.DropTable(
                name: "JobLogs");

            migrationBuilder.DropTable(
                name: "notificationRecepients");

            migrationBuilder.DropTable(
                name: "Sublevels");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "OrganizationLevels");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Criterias");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "TemplateColumns");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
