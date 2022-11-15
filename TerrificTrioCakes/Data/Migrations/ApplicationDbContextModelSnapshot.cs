﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerrificTrioCakes.Data;

#nullable disable

namespace TerrificTrioCakes.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "62f7109f-b929-42cd-92c2-4ccb08803f7d",
                            ConcurrencyStamp = "80e1f706-68bc-4526-937d-e6e624ed339d",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "cbdc7b8f-a42e-4adb-bd0f-329b2dbcab28",
                            ConcurrencyStamp = "82dfb0a4-9273-4554-9f98-3cb271f792d0",
                            Name = "Staff",
                            NormalizedName = "STAFF"
                        },
                        new
                        {
                            Id = "c36ecd80-aec9-4677-b33f-e1e6b7ddc9f4",
                            ConcurrencyStamp = "d475c953-0014-4e34-aaee-ef442b4385c5",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9659aeae-5e19-4fe8-93b0-5d4750c0c3de",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff1993c8-9a93-4fd5-bb04-5841a580ece5",
                            Email = "admin@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOkKCgorp7Ep7yD2gIaogrH1m1KSqmAcIOwQSfYJKiqrjUn5ebYppUfYM/+5oSzqpw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c1d27da2-a0db-414d-a36d-51f788464019",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "6419f98d-a17b-40ca-9287-e7ff5f544922",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0efa3bff-e7f4-4af0-b616-106bd3b245cf",
                            Email = "staff@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "STAFF@MAIL.COM",
                            NormalizedUserName = "STAFF@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGY9iLXIQdMYLSSJQhAB//vr3tI/qZ1BbljSjrI+/sTlKzJy3icD38dVDWhTNhUXWQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "522855e5-e65c-49db-b4e4-ea892cbe0f5d",
                            TwoFactorEnabled = false,
                            UserName = "staff@mail.com"
                        },
                        new
                        {
                            Id = "5131373d-87da-47b0-ba8a-ac5a0f205116",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a8533129-783f-401b-9df9-21ed21228d60",
                            Email = "user@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@MAIL.COM",
                            NormalizedUserName = "USER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECd8oBBxnYgfj/gv6ViIA7kC7gHMdIU23uC9yAXvyBmVPtbEdz8uySAtyS2HEdhC6A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "76cc9451-4286-414f-a5cb-e84f111ab8db",
                            TwoFactorEnabled = false,
                            UserName = "user@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "9659aeae-5e19-4fe8-93b0-5d4750c0c3de",
                            RoleId = "62f7109f-b929-42cd-92c2-4ccb08803f7d"
                        },
                        new
                        {
                            UserId = "6419f98d-a17b-40ca-9287-e7ff5f544922",
                            RoleId = "cbdc7b8f-a42e-4adb-bd0f-329b2dbcab28"
                        },
                        new
                        {
                            UserId = "5131373d-87da-47b0-ba8a-ac5a0f205116",
                            RoleId = "c36ecd80-aec9-4677-b33f-e1e6b7ddc9f4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
