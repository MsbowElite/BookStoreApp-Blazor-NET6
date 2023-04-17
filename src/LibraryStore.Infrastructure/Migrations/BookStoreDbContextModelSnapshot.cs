﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LibraryStore.Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("BookStoreApp.API.Data.ApiUser", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("TEXT");

                b.Property<int>("AccessFailedCount")
                    .HasColumnType("INTEGER");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("TEXT");

                b.Property<string>("Email")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");

                b.Property<bool>("EmailConfirmed")
                    .HasColumnType("INTEGER");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<bool>("LockoutEnabled")
                    .HasColumnType("INTEGER");

                b.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("TEXT");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");

                b.Property<string>("PasswordHash")
                    .HasColumnType("TEXT");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("TEXT");

                b.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("INTEGER");

                b.Property<string>("SecurityStamp")
                    .HasColumnType("TEXT");

                b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("INTEGER");

                b.Property<string>("UserName")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasDatabaseName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasDatabaseName("UserNameIndex");

                b.ToTable("AspNetUsers", (string)null);

                b.HasData(
                    new
                    {
                        Id = "8e448afa-f008-446e-a52f-13c449803c2e",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "a0ab72ab-2cfb-444f-a36c-e6d88a9c4283",
                        Email = "admin@bookstore.com",
                        EmailConfirmed = false,
                        FirstName = "System",
                        LastName = "Admin",
                        LockoutEnabled = false,
                        NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                        NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                        PasswordHash = "AQAAAAIAAYagAAAAEN5GwhVq2K27MS7XP+zZoE1ExYO4fiweKURKT6Pejmof7AWWE2KGOt34jZ9rWytIEg==",
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "9a81f0ef-7c4c-431d-8fdd-53e6eee65c9f",
                        TwoFactorEnabled = false,
                        UserName = "admin@bookstore.com"
                    },
                    new
                    {
                        Id = "30a24107-d279-4e37-96fd-01af5b38cb27",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "d07c25d2-eba7-4414-82e5-9f8759234567",
                        Email = "user@bookstore.com",
                        EmailConfirmed = false,
                        FirstName = "System",
                        LastName = "User",
                        LockoutEnabled = false,
                        NormalizedEmail = "USER@BOOKSTORE.COM",
                        NormalizedUserName = "USER@BOOKSTORE.COM",
                        PasswordHash = "AQAAAAIAAYagAAAAEDOqHRVWWXY5WgebImIOd269PtlSKacWjCMuPP140QdFQze2utJk+LdJh59JOfl+1Q==",
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "866149f3-96aa-461d-a147-07283eb89973",
                        TwoFactorEnabled = false,
                        UserName = "user@bookstore.com"
                    });
            });

            modelBuilder.Entity("BookStoreApp.API.Data.Author", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Bio")
                    .HasMaxLength(250)
                    .HasColumnType("TEXT");

                b.Property<string>("FirstName")
                    .HasMaxLength(50)
                    .HasColumnType("TEXT");

                b.Property<string>("LastName")
                    .HasMaxLength(50)
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Authors");
            });

            modelBuilder.Entity("BookStoreApp.API.Data.Book", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int?>("AuthorId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Image")
                    .HasMaxLength(250)
                    .HasColumnType("TEXT");

                b.Property<string>("Isbn")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("TEXT")
                    .HasColumnName("ISBN");

                b.Property<decimal?>("Price")
                    .HasColumnType("decimal(18, 2)");

                b.Property<string>("Summary")
                    .HasMaxLength(250)
                    .HasColumnType("TEXT");

                b.Property<string>("Title")
                    .HasMaxLength(50)
                    .HasColumnType("TEXT");

                b.Property<int?>("Year")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("AuthorId");

                b.HasIndex(new[] { "Isbn" }, "UQ__Books__447D36EA09FAB742")
                    .IsUnique();

                b.ToTable("Books");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("TEXT");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("TEXT");

                b.Property<string>("Name")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");

                b.Property<string>("NormalizedName")
                    .HasMaxLength(256)
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasDatabaseName("RoleNameIndex");

                b.ToTable("AspNetRoles", (string)null);

                b.HasData(
                    new
                    {
                        Id = "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                        Name = "User",
                        NormalizedName = "USER"
                    },
                    new
                    {
                        Id = "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    });
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("ClaimType")
                    .HasColumnType("TEXT");

                b.Property<string>("ClaimValue")
                    .HasColumnType("TEXT");

                b.Property<string>("RoleId")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims", (string)null);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("ClaimType")
                    .HasColumnType("TEXT");

                b.Property<string>("ClaimValue")
                    .HasColumnType("TEXT");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims", (string)null);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider")
                    .HasColumnType("TEXT");

                b.Property<string>("ProviderKey")
                    .HasColumnType("TEXT");

                b.Property<string>("ProviderDisplayName")
                    .HasColumnType("TEXT");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins", (string)null);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("TEXT");

                b.Property<string>("RoleId")
                    .HasColumnType("TEXT");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles", (string)null);

                b.HasData(
                    new
                    {
                        UserId = "30a24107-d279-4e37-96fd-01af5b38cb27",
                        RoleId = "8343074e-8623-4e1a-b0c1-84fb8678c8f3"
                    },
                    new
                    {
                        UserId = "8e448afa-f008-446e-a52f-13c449803c2e",
                        RoleId = "c7ac6cfe-1f10-4baf-b604-cde350db9554"
                    });
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("TEXT");

                b.Property<string>("LoginProvider")
                    .HasColumnType("TEXT");

                b.Property<string>("Name")
                    .HasColumnType("TEXT");

                b.Property<string>("Value")
                    .HasColumnType("TEXT");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens", (string)null);
            });

            modelBuilder.Entity("BookStoreApp.API.Data.Book", b =>
            {
                b.HasOne("BookStoreApp.API.Data.Author", "Author")
                    .WithMany("Books")
                    .HasForeignKey("AuthorId")
                    .HasConstraintName("FK_Books_ToTable");

                b.Navigation("Author");
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
                b.HasOne("BookStoreApp.API.Data.ApiUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.HasOne("BookStoreApp.API.Data.ApiUser", null)
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

                b.HasOne("BookStoreApp.API.Data.ApiUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.HasOne("BookStoreApp.API.Data.ApiUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("BookStoreApp.API.Data.Author", b =>
            {
                b.Navigation("Books");
            });
#pragma warning restore 612, 618
        }
    }
}
