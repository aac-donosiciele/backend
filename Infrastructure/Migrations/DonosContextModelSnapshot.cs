﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DonosContext))]
    partial class DonosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Core.Entities.Complaint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TargetAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("TargetFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TargetLastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("Core.Entities.ComplaintLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<Guid>("ComplaintId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OfficialId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("OfficialId");

                    b.HasIndex("ComplaintId", "CreatedDate", "OfficialId");

                    b.ToTable("ComplaintsLogs");
                });

            modelBuilder.Entity("Core.Entities.Official", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Officials");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5aad52c-9722-4ef6-a67d-91afb407d891"),
                            Category = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8ce0a49a-4268-47c6-b3fd-122ef222f818"),
                            Category = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5aad52c-9722-4ef6-a67d-91afb407d891"),
                            Category = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsVerified = true,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "a48dbf15d3c2e171b9328005d5727589903c0083b524efba66ea1516231bca85",
                            Pesel = "112345678",
                            Role = 2,
                            Username = "megaAdmin"
                        },
                        new
                        {
                            Id = new Guid("562f5237-43b2-4ea5-9094-e21912a4f03b"),
                            Category = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsVerified = true,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "e8e7b468dcb0446072821a7e5ffb21344ac784c3d6a02192f58df2764cd555e6",
                            Pesel = "012345678",
                            Role = 0,
                            Username = "megaAdmin12"
                        },
                        new
                        {
                            Id = new Guid("8ce0a49a-4268-47c6-b3fd-122ef222f818"),
                            Category = 0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsVerified = true,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "41455bd85390f866c132887d4ec3771240b21700c1b8de233ddab2d832c20c00",
                            Pesel = "012345690",
                            Role = 1,
                            Username = "megaAdmin123"
                        });
                });

            modelBuilder.Entity("Core.Entities.Complaint", b =>
                {
                    b.HasOne("Core.Entities.User", "Sender")
                        .WithMany("Complaints")
                        .HasForeignKey("SenderId")
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Core.Entities.ComplaintLog", b =>
                {
                    b.HasOne("Core.Entities.Complaint", "Complaint")
                        .WithMany("ComplaintLogs")
                        .HasForeignKey("ComplaintId")
                        .IsRequired();

                    b.HasOne("Core.Entities.Official", "Official")
                        .WithMany("ComplaintLogs")
                        .HasForeignKey("OfficialId")
                        .IsRequired();

                    b.Navigation("Complaint");

                    b.Navigation("Official");
                });

            modelBuilder.Entity("Core.Entities.Complaint", b =>
                {
                    b.Navigation("ComplaintLogs");
                });

            modelBuilder.Entity("Core.Entities.Official", b =>
                {
                    b.Navigation("ComplaintLogs");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("Complaints");
                });
#pragma warning restore 612, 618
        }
    }
}
