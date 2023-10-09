﻿// <auto-generated />
using System;
using EDS_BackendTest.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDS_BackendTest.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231009132640_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EDS_BackendTest.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Organization")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationOrgID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.HasIndex("OrganizationOrgID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Columns", b =>
                {
                    b.Property<int>("ColumnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColumnId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ColName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ColNameExternalDB")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ColumnId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Criteria", b =>
                {
                    b.Property<int>("CriteriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CriteriaID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilterColumnValue")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LookupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TemplateColumnColumnId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateColumnID")
                        .HasColumnType("int");

                    b.Property<int>("TemplateColumnTemplateID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CriteriaID");

                    b.HasIndex("LookupId");

                    b.HasIndex("TemplateColumnTemplateID", "TemplateColumnColumnId");

                    b.ToTable("Criterias");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.DataRecepient", b =>
                {
                    b.Property<int>("DataRecipientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DataRecipientID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DataRecipientInfo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LookUpID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DataRecipientID");

                    b.HasIndex("ClientID");

                    b.HasIndex("LookUpID");

                    b.ToTable("DataRecepients");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Frequency", b =>
                {
                    b.Property<int>("FrequencyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FrequencyID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DateOfMonth")
                        .HasColumnType("int");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FrequencyType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FrequencyID");

                    b.ToTable("Frequencies");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CriteriaID")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyID")
                        .HasColumnType("int");

                    b.Property<int>("LookupID")
                        .HasColumnType("int");

                    b.Property<int?>("LookupsLookUpID")
                        .HasColumnType("int");

                    b.Property<int?>("MaxRecordCountAlarm")
                        .HasColumnType("int");

                    b.Property<int?>("MaxRunDurationAlarm")
                        .HasColumnType("int");

                    b.Property<int?>("MinRecordCountAlarm")
                        .HasColumnType("int");

                    b.Property<int?>("MinRunDurationAlarm")
                        .HasColumnType("int");

                    b.Property<bool>("SendNotification")
                        .HasColumnType("bit");

                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.Property<int?>("TemplateID1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("JobID");

                    b.HasIndex("ClientID");

                    b.HasIndex("CriteriaID");

                    b.HasIndex("FrequencyID");

                    b.HasIndex("LookupID");

                    b.HasIndex("LookupsLookUpID");

                    b.HasIndex("TemplateID");

                    b.HasIndex("TemplateID1");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.JobLog", b =>
                {
                    b.Property<int>("JobLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobLogID"));

                    b.Property<bool>("ExtractSuccess")
                        .HasColumnType("bit");

                    b.Property<int>("ExtractedRecordCount")
                        .HasColumnType("int");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobRunDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobRunDuration")
                        .HasColumnType("int");

                    b.Property<bool>("NotificationRecipientSuccess")
                        .HasColumnType("bit");

                    b.HasKey("JobLogID");

                    b.HasIndex("JobID");

                    b.ToTable("JobLogs");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Lookups", b =>
                {
                    b.Property<int>("LookUpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookUpID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("lookup_hidden_value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("lookup_visible_value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LookUpID");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.NotificationRecepient", b =>
                {
                    b.Property<int>("NotificationRecipientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationRecipientID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LookUpID")
                        .HasColumnType("int");

                    b.Property<string>("NotificationRecipientInfo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("NotificationRecipientID");

                    b.HasIndex("ClientID");

                    b.HasIndex("LookUpID");

                    b.ToTable("notificationRecepients");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Organization", b =>
                {
                    b.Property<int>("OrgID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrgID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("OrgID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.OrganizationLevel", b =>
                {
                    b.Property<int>("LevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LevelID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("LevelID");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationLevels");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Sublevel", b =>
                {
                    b.Property<int>("SublevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SublevelID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("OrganizationLevelId")
                        .HasColumnType("int");

                    b.HasKey("SublevelID");

                    b.HasIndex("OrganizationLevelId");

                    b.ToTable("Sublevels");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Template", b =>
                {
                    b.Property<int>("TemplateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TemplateID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.TemplateColumns", b =>
                {
                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.Property<int>("ColumnId")
                        .HasColumnType("int");

                    b.HasKey("TemplateID", "ColumnId");

                    b.HasIndex("ColumnId");

                    b.ToTable("TemplateColumns");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Client", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Organization", null)
                        .WithMany("Clients")
                        .HasForeignKey("OrganizationOrgID");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Criteria", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Lookups", "Lookup")
                        .WithMany("Criterias")
                        .HasForeignKey("LookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.TemplateColumns", "TemplateColumn")
                        .WithMany("Criterias")
                        .HasForeignKey("TemplateColumnTemplateID", "TemplateColumnColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lookup");

                    b.Navigation("TemplateColumn");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.DataRecepient", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Lookups", "Lookup")
                        .WithMany("DataRecipients")
                        .HasForeignKey("LookUpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Lookup");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Job", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Criteria", "Criteria")
                        .WithMany("Jobs")
                        .HasForeignKey("CriteriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Frequency", "Frequency")
                        .WithMany("Jobs")
                        .HasForeignKey("FrequencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Lookups", "Lookup")
                        .WithMany()
                        .HasForeignKey("LookupID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Lookups", null)
                        .WithMany("Jobs")
                        .HasForeignKey("LookupsLookUpID");

                    b.HasOne("EDS_BackendTest.Model.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Template", null)
                        .WithMany("Jobs")
                        .HasForeignKey("TemplateID1");

                    b.Navigation("Client");

                    b.Navigation("Criteria");

                    b.Navigation("Frequency");

                    b.Navigation("Lookup");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.JobLog", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Job", "Job")
                        .WithMany("JobLogs")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.NotificationRecepient", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Lookups", "Lookup")
                        .WithMany("NotificationRecipients")
                        .HasForeignKey("LookUpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Lookup");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.OrganizationLevel", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Organization", "Organization")
                        .WithMany("Levels")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Sublevel", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.OrganizationLevel", "OrganizationLevel")
                        .WithMany("Sublevels")
                        .HasForeignKey("OrganizationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationLevel");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Template", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Category", "Category")
                        .WithMany("Templates")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.TemplateColumns", b =>
                {
                    b.HasOne("EDS_BackendTest.Model.Columns", "Column")
                        .WithMany("TemplateColumns")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_BackendTest.Model.Template", "Template")
                        .WithMany("TemplateColumns")
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Category", b =>
                {
                    b.Navigation("Templates");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Columns", b =>
                {
                    b.Navigation("TemplateColumns");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Criteria", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Frequency", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Job", b =>
                {
                    b.Navigation("JobLogs");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Lookups", b =>
                {
                    b.Navigation("Criterias");

                    b.Navigation("DataRecipients");

                    b.Navigation("Jobs");

                    b.Navigation("NotificationRecipients");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Organization", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Levels");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.OrganizationLevel", b =>
                {
                    b.Navigation("Sublevels");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.Template", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("TemplateColumns");
                });

            modelBuilder.Entity("EDS_BackendTest.Model.TemplateColumns", b =>
                {
                    b.Navigation("Criterias");
                });
#pragma warning restore 612, 618
        }
    }
}
