﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwoDCellCore.Models;

#nullable disable

namespace TwoDCellCore.Migrations
{
    [DbContext(typeof(TwoDCellsDbContext))]
    partial class TwoDCellsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TwoDCellCore.Models.Bullet", b =>
                {
                    b.Property<string>("BulletId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("bulletID")
                        .IsFixedLength();

                    b.Property<string>("BulletName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("bulletName")
                        .IsFixedLength();

                    b.Property<double>("BulletSpeed")
                        .HasColumnType("float")
                        .HasColumnName("bulletSpeed");

                    b.Property<string>("BulletTypeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("bulletTypeID")
                        .IsFixedLength();

                    b.Property<int>("Damage")
                        .HasColumnType("int")
                        .HasColumnName("damage");

                    b.Property<string>("Element")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("element")
                        .IsFixedLength();

                    b.Property<double>("TimeExist")
                        .HasColumnType("float")
                        .HasColumnName("timeExist");

                    b.HasKey("BulletId");

                    b.HasIndex(new[] { "BulletTypeId" }, "IX_bullets_bulletTypeID");

                    b.HasIndex(new[] { "Element" }, "IX_bullets_element");

                    b.ToTable("bullets");
                });

            modelBuilder.Entity("TwoDCellCore.Models.BulletType", b =>
                {
                    b.Property<string>("BulletTypeId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("bulletTypeID")
                        .IsFixedLength();

                    b.Property<string>("BulletTypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("bulletTypeName")
                        .IsFixedLength();

                    b.HasKey("BulletTypeId");

                    b.ToTable("bullet_types");
                });

            modelBuilder.Entity("TwoDCellCore.Models.CellFaction", b =>
                {
                    b.Property<string>("FactionId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("factionID")
                        .IsFixedLength();

                    b.Property<string>("FactionName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("factionName")
                        .IsFixedLength();

                    b.HasKey("FactionId");

                    b.ToTable("cell_faction");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Element", b =>
                {
                    b.Property<string>("Element1")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("element")
                        .IsFixedLength();

                    b.HasKey("Element1");

                    b.ToTable("elements");
                });

            modelBuilder.Entity("TwoDCellCore.Models.EnemyCell", b =>
                {
                    b.Property<string>("EnemyId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("EnemyID")
                        .IsFixedLength();

                    b.Property<string>("AbilityId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("AbilityID")
                        .IsFixedLength();

                    b.Property<int>("Armor")
                        .HasColumnType("int");

                    b.Property<int?>("BodyDamage")
                        .HasColumnType("int");

                    b.Property<string>("CellProtection")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("FactionId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("factionID")
                        .IsFixedLength();

                    b.Property<int>("Hp")
                        .HasColumnType("int")
                        .HasColumnName("HP");

                    b.Property<double>("MoveSpeed")
                        .HasColumnType("float");

                    b.Property<int>("Mp")
                        .HasColumnType("int")
                        .HasColumnName("MP");

                    b.Property<int>("Shield")
                        .HasColumnType("int");

                    b.Property<string>("ShieldType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("EnemyId");

                    b.HasIndex(new[] { "AbilityId" }, "IX_enemy_cells_AbilityID");

                    b.HasIndex(new[] { "FactionId" }, "IX_enemy_cells_factionID");

                    b.ToTable("enemy_cells");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Gun", b =>
                {
                    b.Property<string>("GunId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("gunID")
                        .IsFixedLength();

                    b.Property<double>("Accuracy")
                        .HasColumnType("float")
                        .HasColumnName("accuracy");

                    b.Property<string>("BulletId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("bulletID")
                        .IsFixedLength();

                    b.Property<double>("CriticalMultiple")
                        .HasColumnType("float")
                        .HasColumnName("criticalMultiple");

                    b.Property<double>("CriticalRate")
                        .HasColumnType("float")
                        .HasColumnName("criticalRate");

                    b.Property<double>("FireRate")
                        .HasColumnType("float")
                        .HasColumnName("fireRate");

                    b.Property<string>("GunName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("gunName")
                        .IsFixedLength();

                    b.HasKey("GunId");

                    b.HasIndex(new[] { "BulletId" }, "IX_guns_bulletID");

                    b.ToTable("guns");
                });

            modelBuilder.Entity("TwoDCellCore.Models.GunUpgradeConfig", b =>
                {
                    b.Property<int>("MutationLv")
                        .HasColumnType("int")
                        .HasColumnName("mutationLv");

                    b.Property<int?>("XpRequire")
                        .HasColumnType("int")
                        .HasColumnName("xpRequire");

                    b.HasKey("MutationLv")
                        .HasName("PK__gun_upgr__3133F2595884267F");

                    b.ToTable("gun_upgrade_config");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Mutation", b =>
                {
                    b.Property<string>("MutationId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("MutationID")
                        .IsFixedLength();

                    b.Property<int>("Armor")
                        .HasColumnType("int");

                    b.Property<string>("CellProtection")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("FactionId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("factionID")
                        .IsFixedLength();

                    b.Property<int>("Hp")
                        .HasColumnType("int")
                        .HasColumnName("HP");

                    b.Property<double>("MoveSpeed")
                        .HasColumnType("float");

                    b.Property<int>("Mp")
                        .HasColumnType("int")
                        .HasColumnName("MP");

                    b.Property<string>("MutationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<int>("Shield")
                        .HasColumnType("int");

                    b.Property<string>("ShieldType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("MutationId")
                        .HasName("PK_Test_Table1");

                    b.HasIndex(new[] { "FactionId" }, "IX_mutations_factionID");

                    b.ToTable("mutations");
                });

            modelBuilder.Entity("TwoDCellCore.Models.MutationAbility", b =>
                {
                    b.Property<string>("AbilityId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("AbilityID")
                        .IsFixedLength();

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<string>("MutationId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("MutationID")
                        .IsFixedLength();

                    b.HasKey("AbilityId");

                    b.HasIndex(new[] { "MutationId" }, "IX_mutation_abilities_MutationID");

                    b.ToTable("mutation_abilities");
                });

            modelBuilder.Entity("TwoDCellCore.Models.MutationUpgradeConfig", b =>
                {
                    b.Property<int>("MutationLv")
                        .HasColumnType("int")
                        .HasColumnName("mutationLv");

                    b.Property<int?>("XpRequire")
                        .HasColumnType("int")
                        .HasColumnName("xpRequire");

                    b.HasKey("MutationLv")
                        .HasName("PK__mutation__3133F259C7CDCB68");

                    b.ToTable("mutation_upgrade_config");
                });

            modelBuilder.Entity("TwoDCellCore.Models.UserGun", b =>
                {
                    b.Property<string>("GunId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("gunID")
                        .IsFixedLength();

                    b.Property<int>("GunLv")
                        .HasColumnType("int")
                        .HasColumnName("gunLv");

                    b.Property<int>("GunXp")
                        .HasColumnType("int")
                        .HasColumnName("gunXp");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("userID");

                    b.HasIndex("GunId");

                    b.HasIndex("UserId");

                    b.ToTable("user_gun");
                });

            modelBuilder.Entity("TwoDCellCore.Models.UserMutation", b =>
                {
                    b.Property<string>("MutationId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("mutationID")
                        .IsFixedLength();

                    b.Property<int>("MutationLv")
                        .HasColumnType("int")
                        .HasColumnName("mutationLv");

                    b.Property<int>("MutationXp")
                        .HasColumnType("int")
                        .HasColumnName("mutationXp");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("userID");

                    b.HasIndex("MutationId");

                    b.HasIndex("UserId");

                    b.ToTable("user_mutation");
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

            modelBuilder.Entity("TwoDCellCore.Models.Bullet", b =>
                {
                    b.HasOne("TwoDCellCore.Models.BulletType", "BulletType")
                        .WithMany("Bullets")
                        .HasForeignKey("BulletTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_bullets_bullet_types");

                    b.HasOne("TwoDCellCore.Models.Element", "ElementNavigation")
                        .WithMany("Bullets")
                        .HasForeignKey("Element")
                        .IsRequired()
                        .HasConstraintName("FK_bullets_elements");

                    b.Navigation("BulletType");

                    b.Navigation("ElementNavigation");
                });

            modelBuilder.Entity("TwoDCellCore.Models.EnemyCell", b =>
                {
                    b.HasOne("TwoDCellCore.Models.MutationAbility", "Ability")
                        .WithMany("EnemyCells")
                        .HasForeignKey("AbilityId")
                        .HasConstraintName("FK_enemy_cells_mutation_abilities");

                    b.HasOne("TwoDCellCore.Models.CellFaction", "Faction")
                        .WithMany("EnemyCells")
                        .HasForeignKey("FactionId")
                        .IsRequired()
                        .HasConstraintName("FK_enemy_cells_cell_faction");

                    b.Navigation("Ability");

                    b.Navigation("Faction");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Gun", b =>
                {
                    b.HasOne("TwoDCellCore.Models.Bullet", "Bullet")
                        .WithMany("Guns")
                        .HasForeignKey("BulletId")
                        .IsRequired()
                        .HasConstraintName("FK_guns_bullets");

                    b.Navigation("Bullet");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Mutation", b =>
                {
                    b.HasOne("TwoDCellCore.Models.CellFaction", "Faction")
                        .WithMany("Mutations")
                        .HasForeignKey("FactionId")
                        .IsRequired()
                        .HasConstraintName("FK_mutations_cell_faction");

                    b.Navigation("Faction");
                });

            modelBuilder.Entity("TwoDCellCore.Models.MutationAbility", b =>
                {
                    b.HasOne("TwoDCellCore.Models.Mutation", "Mutation")
                        .WithMany("MutationAbilities")
                        .HasForeignKey("MutationId")
                        .HasConstraintName("FK_mutation_abilities_mutations");

                    b.Navigation("Mutation");
                });

            modelBuilder.Entity("TwoDCellCore.Models.UserGun", b =>
                {
                    b.HasOne("TwoDCellCore.Models.Gun", "Gun")
                        .WithMany()
                        .HasForeignKey("GunId")
                        .IsRequired()
                        .HasConstraintName("FK_user_gun_guns");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_user_gun_AspNetUsers");

                    b.Navigation("Gun");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwoDCellCore.Models.UserMutation", b =>
                {
                    b.HasOne("TwoDCellCore.Models.Mutation", "Mutation")
                        .WithMany()
                        .HasForeignKey("MutationId")
                        .IsRequired()
                        .HasConstraintName("FK_user_mutation_mutations");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_user_mutation_AspNetUsers");

                    b.Navigation("Mutation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Bullet", b =>
                {
                    b.Navigation("Guns");
                });

            modelBuilder.Entity("TwoDCellCore.Models.BulletType", b =>
                {
                    b.Navigation("Bullets");
                });

            modelBuilder.Entity("TwoDCellCore.Models.CellFaction", b =>
                {
                    b.Navigation("EnemyCells");

                    b.Navigation("Mutations");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Element", b =>
                {
                    b.Navigation("Bullets");
                });

            modelBuilder.Entity("TwoDCellCore.Models.Mutation", b =>
                {
                    b.Navigation("MutationAbilities");
                });

            modelBuilder.Entity("TwoDCellCore.Models.MutationAbility", b =>
                {
                    b.Navigation("EnemyCells");
                });
#pragma warning restore 612, 618
        }
    }
}
