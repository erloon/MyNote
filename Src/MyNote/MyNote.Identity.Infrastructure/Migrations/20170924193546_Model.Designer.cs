using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyNote.Identity.Infrastructure;

namespace MyNote.Identity.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170924193546_Model")]
    partial class Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
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
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
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

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Country")
                        .HasMaxLength(150);

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modyfication");

                    b.Property<string>("Number")
                        .HasMaxLength(20);

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("Street")
                        .HasMaxLength(150);

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("OrganizationId")
                        .IsUnique();

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

                    b.Property<bool>("IsAdministrator");

                    b.Property<bool>("IsConfirmByAdmin");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<Guid>("OrganizationId");

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
                        .HasName("UserNameIndex");

                    b.HasIndex("OrganizationId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modyfication");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(15);

                    b.Property<Guid>("UpdateBy");

                    b.Property<string>("VatNumber")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modyfication");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<TimeSpan>("TimeSpan");

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

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

                    b.Property<DateTime>("Modyfication");

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

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<string>("CreateDate");

                    b.Property<DateTime>("Modyfication");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("OwnerId");

                    b.Property<Guid>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserProject", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<string>("UserId");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjrcts");
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserTeam", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("TeamId");

                    b.HasKey("UserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("UserTeams");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Address", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Company", "Company")
                        .WithOne("Address")
                        .HasForeignKey("MyNote.Identity.Domain.Model.Address", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithOne("Address")
                        .HasForeignKey("MyNote.Identity.Domain.Model.Address", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.ApplicationUser", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Company", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithOne("Company")
                        .HasForeignKey("MyNote.Identity.Domain.Model.Company", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.Project", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Organization", "Organization")
                        .WithMany("Projects")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyNote.Identity.Domain.Model.UserProject", b =>
                {
                    b.HasOne("MyNote.Identity.Domain.Model.Project", "Project")
                        .WithMany("UserProjrcts")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser", "User")
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

                    b.HasOne("MyNote.Identity.Domain.Model.ApplicationUser", "User")
                        .WithMany("UserTeams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
