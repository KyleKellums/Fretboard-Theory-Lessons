using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fretboard_Theory_Course.Data;

namespace Fretboard_Theory_Course.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Advanced", b =>
                {
                    b.Property<int>("AdvancedId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("LessonName");

                    b.HasKey("AdvancedId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Advanced");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.AdvancedImages", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvancedId");

                    b.Property<string>("Path");

                    b.HasKey("ImageId");

                    b.HasIndex("AdvancedId");

                    b.ToTable("AdvancedImages");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

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

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Foundations", b =>
                {
                    b.Property<int>("FoundationsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("LessonName");

                    b.HasKey("FoundationsId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Foundations");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.FoundationsImages", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoundationsId");

                    b.Property<string>("Path");

                    b.HasKey("ImageId");

                    b.HasIndex("FoundationsId");

                    b.ToTable("FoundationsImages");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Intermediate", b =>
                {
                    b.Property<int>("IntermediateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("LessonName");

                    b.HasKey("IntermediateId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Intermediate");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.IntermediateImages", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IntermediateId");

                    b.Property<string>("Path");

                    b.HasKey("ImageId");

                    b.HasIndex("IntermediateId");

                    b.ToTable("IntermediateImages");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Resources", b =>
                {
                    b.Property<int>("ResourcesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ResourceType");

                    b.HasKey("ResourcesId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.ResourcesImages", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.Property<int>("ResourcesId");

                    b.HasKey("ImageId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("ResourcesImages");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.UserAdvanced", b =>
                {
                    b.Property<int>("UserAdvancedId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvancedId");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("UserAdvancedId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAdvanced");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.UserFoundations", b =>
                {
                    b.Property<int>("UserFoundationsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoundationsId");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("UserFoundationsId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFoundations");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.UserIntermediate", b =>
                {
                    b.Property<int>("UserIntermediateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IntermediateId");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("UserIntermediateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIntermediate");
                });

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

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Advanced", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser")
                        .WithMany("Advanced")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.AdvancedImages", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.Advanced", "Advanced")
                        .WithMany("Images")
                        .HasForeignKey("AdvancedId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Foundations", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser")
                        .WithMany("Foundations")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.FoundationsImages", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.Foundations", "Foundations")
                        .WithMany("Images")
                        .HasForeignKey("FoundationsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.Intermediate", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser")
                        .WithMany("Intermediate")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.IntermediateImages", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.Intermediate", "Intermediate")
                        .WithMany("Images")
                        .HasForeignKey("IntermediateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.ResourcesImages", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.Resources", "Resources")
                        .WithMany("Images")
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.UserAdvanced", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.UserFoundations", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fretboard_Theory_Course.Models.UserIntermediate", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser")
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

                    b.HasOne("Fretboard_Theory_Course.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
