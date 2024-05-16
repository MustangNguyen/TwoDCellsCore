using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoDCellCore.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bullet_types",
                columns: table => new
                {
                    bulletTypeID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    bulletTypeName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bullet_types", x => x.bulletTypeID);
                });

            migrationBuilder.CreateTable(
                name: "cell_faction",
                columns: table => new
                {
                    factionID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    factionName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cell_faction", x => x.factionID);
                });

            migrationBuilder.CreateTable(
                name: "elements",
                columns: table => new
                {
                    element = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elements", x => x.element);
                });

            migrationBuilder.CreateTable(
                name: "gun_upgrade_config",
                columns: table => new
                {
                    mutationLv = table.Column<int>(type: "int", nullable: false),
                    xpRequire = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gun_upgr__3133F2595884267F", x => x.mutationLv);
                });

            migrationBuilder.CreateTable(
                name: "mutation_upgrade_config",
                columns: table => new
                {
                    mutationLv = table.Column<int>(type: "int", nullable: false),
                    xpRequire = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mutation__3133F259C7CDCB68", x => x.mutationLv);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mutations",
                columns: table => new
                {
                    MutationID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    MP = table.Column<int>(type: "int", nullable: false),
                    MutationName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    CellProtection = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    MoveSpeed = table.Column<double>(type: "float", nullable: false),
                    factionID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    ShieldType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Shield = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Table1", x => x.MutationID);
                    table.ForeignKey(
                        name: "FK_mutations_cell_faction",
                        column: x => x.factionID,
                        principalTable: "cell_faction",
                        principalColumn: "factionID");
                });

            migrationBuilder.CreateTable(
                name: "bullets",
                columns: table => new
                {
                    bulletID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    bulletName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    bulletTypeID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    damage = table.Column<int>(type: "int", nullable: false),
                    timeExist = table.Column<double>(type: "float", nullable: false),
                    bulletSpeed = table.Column<double>(type: "float", nullable: false),
                    element = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bullets", x => x.bulletID);
                    table.ForeignKey(
                        name: "FK_bullets_bullet_types",
                        column: x => x.bulletTypeID,
                        principalTable: "bullet_types",
                        principalColumn: "bulletTypeID");
                    table.ForeignKey(
                        name: "FK_bullets_elements",
                        column: x => x.element,
                        principalTable: "elements",
                        principalColumn: "element");
                });

            migrationBuilder.CreateTable(
                name: "mutation_abilities",
                columns: table => new
                {
                    AbilityID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    AbilityName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    MutationID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mutation_abilities", x => x.AbilityID);
                    table.ForeignKey(
                        name: "FK_mutation_abilities_mutations",
                        column: x => x.MutationID,
                        principalTable: "mutations",
                        principalColumn: "MutationID");
                });

            migrationBuilder.CreateTable(
                name: "user_mutation",
                columns: table => new
                {
                    userID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    mutationID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    mutationLv = table.Column<int>(type: "int", nullable: false),
                    mutationXp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_user_mutation_AspNetUsers",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_mutation_mutations",
                        column: x => x.mutationID,
                        principalTable: "mutations",
                        principalColumn: "MutationID");
                });

            migrationBuilder.CreateTable(
                name: "guns",
                columns: table => new
                {
                    gunID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    gunName = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    bulletID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    fireRate = table.Column<double>(type: "float", nullable: false),
                    accuracy = table.Column<double>(type: "float", nullable: false),
                    criticalRate = table.Column<double>(type: "float", nullable: false),
                    criticalMultiple = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guns", x => x.gunID);
                    table.ForeignKey(
                        name: "FK_guns_bullets",
                        column: x => x.bulletID,
                        principalTable: "bullets",
                        principalColumn: "bulletID");
                });

            migrationBuilder.CreateTable(
                name: "enemy_cells",
                columns: table => new
                {
                    EnemyID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    EnemyName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    MP = table.Column<int>(type: "int", nullable: false),
                    CellProtection = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    MoveSpeed = table.Column<double>(type: "float", nullable: false),
                    factionID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    AbilityID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    ShieldType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Shield = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    BodyDamage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enemy_cells", x => x.EnemyID);
                    table.ForeignKey(
                        name: "FK_enemy_cells_cell_faction",
                        column: x => x.factionID,
                        principalTable: "cell_faction",
                        principalColumn: "factionID");
                    table.ForeignKey(
                        name: "FK_enemy_cells_mutation_abilities",
                        column: x => x.AbilityID,
                        principalTable: "mutation_abilities",
                        principalColumn: "AbilityID");
                });

            migrationBuilder.CreateTable(
                name: "user_gun",
                columns: table => new
                {
                    userID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    gunID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    gunLv = table.Column<int>(type: "int", nullable: false),
                    gunXp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_user_gun_AspNetUsers",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_gun_guns",
                        column: x => x.gunID,
                        principalTable: "guns",
                        principalColumn: "gunID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_bullets_bulletTypeID",
                table: "bullets",
                column: "bulletTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_bullets_element",
                table: "bullets",
                column: "element");

            migrationBuilder.CreateIndex(
                name: "IX_enemy_cells_AbilityID",
                table: "enemy_cells",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_enemy_cells_factionID",
                table: "enemy_cells",
                column: "factionID");

            migrationBuilder.CreateIndex(
                name: "IX_guns_bulletID",
                table: "guns",
                column: "bulletID");

            migrationBuilder.CreateIndex(
                name: "IX_mutation_abilities_MutationID",
                table: "mutation_abilities",
                column: "MutationID");

            migrationBuilder.CreateIndex(
                name: "IX_mutations_factionID",
                table: "mutations",
                column: "factionID");

            migrationBuilder.CreateIndex(
                name: "IX_user_gun_gunID",
                table: "user_gun",
                column: "gunID");

            migrationBuilder.CreateIndex(
                name: "IX_user_gun_userID",
                table: "user_gun",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_user_mutation_mutationID",
                table: "user_mutation",
                column: "mutationID");

            migrationBuilder.CreateIndex(
                name: "IX_user_mutation_userID",
                table: "user_mutation",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "enemy_cells");

            migrationBuilder.DropTable(
                name: "gun_upgrade_config");

            migrationBuilder.DropTable(
                name: "mutation_upgrade_config");

            migrationBuilder.DropTable(
                name: "user_gun");

            migrationBuilder.DropTable(
                name: "user_mutation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "mutation_abilities");

            migrationBuilder.DropTable(
                name: "guns");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "mutations");

            migrationBuilder.DropTable(
                name: "bullets");

            migrationBuilder.DropTable(
                name: "cell_faction");

            migrationBuilder.DropTable(
                name: "bullet_types");

            migrationBuilder.DropTable(
                name: "elements");
        }
    }
}
