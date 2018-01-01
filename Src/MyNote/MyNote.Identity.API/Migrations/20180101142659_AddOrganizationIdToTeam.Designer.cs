﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyNote.Identity.Infrastructure;
using System;

namespace MyNote.Identity.API.Migrations
{
    [DbContext(typeof(MyIdentityDbContext))]
    [Migration("20180101142659_AddOrganizationIdToTeam")]
    partial class AddOrganizationIdToTeam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(150);

                    b.Property<string>("Country")
                        .HasMaxLength(150);

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modification");

                    b.Property<string>("Number")
                        .HasMaxLength(20);

                    b.Property<string>("Street")
                        .HasMaxLength(150);

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modification");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(15);

                    b.Property<Guid>("UpdateBy");

                    b.Property<string>("VatNumber")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("CompanyId");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modification");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasFilter("[CompanyId] IS NOT NULL");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("Modification");

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.Property<Guid>("OrganizationId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Subject")
                        .HasMaxLength(150);

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ContentId");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modification");

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("OwnerId");

                    b.Property<Guid?>("OwnerId1");

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("OwnerId1");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ResourceProject", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("ResourceId");

                    b.HasKey("ProjectId", "ResourceId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceProjects");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ResourceTeam", b =>
                {
                    b.Property<Guid>("ResourceId");

                    b.Property<Guid>("TeamId");

                    b.HasKey("ResourceId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("ResourceTeams");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ResourceUser", b =>
                {
                    b.Property<Guid>("ResourceId");

                    b.Property<Guid>("UserId");

                    b.HasKey("ResourceId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ResourceUsers");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("Modification");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<Guid>("OrganizationId");

                    b.Property<Guid>("OwnerId");

                    b.Property<Guid>("UpdateBy");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<bool>("IsAdministrator");

                    b.Property<bool>("IsConfirmByAdmin");

                    b.Property<DateTime>("Modification");

                    b.Property<Guid>("OrganizationId");

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserProject", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("UserId");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserTeam", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("TeamId");

                    b.HasKey("UserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("UserTeams");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Company", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Organization", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("MyNote.Identity.Domain.Model.Company", "Company")
                        .WithOne("Organization")
                        .HasForeignKey("MyNote.Identity.Domain.Model.Organization", "CompanyId");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Project", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithMany("Projects")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Resource", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithMany("Resources")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId1");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ResourceProject", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Project", "Project")
                        .WithMany("ResourceProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.Resource", "Resource")
                        .WithMany("ResourceProjects")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ResourceTeam", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Resource", "Resource")
                        .WithMany("ResourceTeams")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.Team", "Team")
                        .WithMany("ResourceTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ResourceUser", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Resource", "Resource")
                        .WithMany("ResourceUsers")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.User", "User")
                        .WithMany("ResourceUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Team", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.User", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserProject", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserTeam", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Team", "Team")
                        .WithMany("UserTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.User", "User")
                        .WithMany("UserTeams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
