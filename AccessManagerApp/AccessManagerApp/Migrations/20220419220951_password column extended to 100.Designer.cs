﻿// <auto-generated />
using System;
using AccessManagerApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccessManagerApp.Migrations
{
    [DbContext(typeof(DbContextAccessManager))]
    [Migration("20220419220951_password column extended to 100")]
    partial class passwordcolumnextendedto100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccessManagerApp.Models.Account", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nchar(100)");

                    b.Property<Guid>("GuidAccount")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<int>("IdAccountType")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("IdAccount");

                    b.HasIndex("IdAccountType");

                    b.HasIndex("IdUser");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccountDetails", b =>
                {
                    b.Property<int>("IdAccountDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<bool>("IsSensitive")
                        .HasColumnType("bit");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueTag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAccountDetail");

                    b.HasIndex("IdAccount");

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccountType", b =>
                {
                    b.Property<int>("IdAccountType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nchar(4)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nchar(20)");

                    b.HasKey("IdAccountType");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("AccessManagerApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nchar(100)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccCard", b =>
                {
                    b.HasBaseType("AccessManagerApp.Models.Account");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasColumnType("nchar(20)");

                    b.Property<string>("CCV")
                        .HasColumnType("nchar(50)");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.Property<string>("Franchise")
                        .IsRequired()
                        .HasColumnType("nchar(20)");

                    b.ToTable("AccCard");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccEmailAssociated", b =>
                {
                    b.HasBaseType("AccessManagerApp.Models.Account");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.ToTable("AccWebAssociated");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccNormal", b =>
                {
                    b.HasBaseType("AccessManagerApp.Models.Account");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.ToTable("AccNormal");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccWebSite", b =>
                {
                    b.HasBaseType("AccessManagerApp.Models.Account");

                    b.Property<string>("WebSiteName")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.ToTable("AccWebSite");
                });

            modelBuilder.Entity("AccessManagerApp.Models.Account", b =>
                {
                    b.HasOne("AccessManagerApp.Models.AccountType", "AccountType")
                        .WithMany("Account")
                        .HasForeignKey("IdAccountType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AccessManagerApp.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AccountType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccountDetails", b =>
                {
                    b.HasOne("AccessManagerApp.Models.Account", "Account")
                        .WithMany("AccountDetails")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccCard", b =>
                {
                    b.HasOne("AccessManagerApp.Models.Account", null)
                        .WithOne()
                        .HasForeignKey("AccessManagerApp.Models.AccCard", "IdAccount")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccEmailAssociated", b =>
                {
                    b.HasOne("AccessManagerApp.Models.Account", null)
                        .WithOne()
                        .HasForeignKey("AccessManagerApp.Models.AccEmailAssociated", "IdAccount")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccNormal", b =>
                {
                    b.HasOne("AccessManagerApp.Models.Account", null)
                        .WithOne()
                        .HasForeignKey("AccessManagerApp.Models.AccNormal", "IdAccount")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccWebSite", b =>
                {
                    b.HasOne("AccessManagerApp.Models.Account", null)
                        .WithOne()
                        .HasForeignKey("AccessManagerApp.Models.AccWebSite", "IdAccount")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccessManagerApp.Models.Account", b =>
                {
                    b.Navigation("AccountDetails");
                });

            modelBuilder.Entity("AccessManagerApp.Models.AccountType", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("AccessManagerApp.Models.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
