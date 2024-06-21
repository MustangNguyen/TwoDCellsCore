using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwoDCellCore.Models;


namespace TwoDCellCore.Models;

public partial class TwoDCellsDbContext : IdentityDbContext<GameUser>
{
    public TwoDCellsDbContext()
    {
    }

    public TwoDCellsDbContext(DbContextOptions<TwoDCellsDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<GameUser> AspNetUsers { get; set; }

    public virtual DbSet<Bullet> Bullets { get; set; }

    public virtual DbSet<BulletType> BulletTypes { get; set; }

    public virtual DbSet<CellFaction> CellFactions { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<EnemyCell> EnemyCells { get; set; }

    public virtual DbSet<Gun> Guns { get; set; }

    public virtual DbSet<GunUpgradeConfig> GunUpgradeConfigs { get; set; }

    public virtual DbSet<Mutation> Mutations { get; set; }

    public virtual DbSet<MutationAbility> MutationAbilities { get; set; }

    public virtual DbSet<MutationUpgradeConfig> MutationUpgradeConfigs { get; set; }

    public virtual DbSet<UserGun> UserGuns { get; set; }

    public virtual DbSet<UserMutation> UserMutations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GameUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");
        });

        modelBuilder.Entity<UserEquipment>(entity =>
        {
            entity.Property(e => e.UserEquipmentId).ValueGeneratedNever();

            entity.HasOne(d => d.GunOwnershipId1Navigation).WithOne(p => p.UserEquipmentGunOwnershipId1Navigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_equipment_user_gun");

            entity.HasOne(d => d.GunOwnershipId2Navigation).WithOne(p => p.UserEquipmentGunOwnershipId2Navigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_equipment_user_gun1");

            entity.HasOne(d => d.MutationOwnership).WithOne(p => p.UserEquipments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_equipment_user_mutation");

            entity.HasOne(d => d.User).WithMany(p => p.UserEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_equipment_AspNetUsers");
        });

        modelBuilder.Entity<Bullet>(entity =>
        {
            entity.Property(e => e.BulletId).IsFixedLength();
            entity.Property(e => e.BulletName).IsFixedLength();
            entity.Property(e => e.BulletTypeId).IsFixedLength();
            entity.Property(e => e.Element).IsFixedLength();

            entity.HasOne(d => d.BulletType).WithMany(p => p.Bullets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bullets_bullet_types");

            entity.HasOne(d => d.ElementNavigation).WithMany(p => p.Bullets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bullets_elements");
        });

        modelBuilder.Entity<BulletType>(entity =>
        {
            entity.Property(e => e.BulletTypeId).IsFixedLength();
            entity.Property(e => e.BulletTypeName).IsFixedLength();
        });

        modelBuilder.Entity<CellFaction>(entity =>
        {
            entity.Property(e => e.FactionId).IsFixedLength();
            entity.Property(e => e.FactionName).IsFixedLength();
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.Property(e => e.Element1).IsFixedLength();
        });

        modelBuilder.Entity<EnemyCell>(entity =>
        {
            entity.Property(e => e.EnemyId).IsFixedLength();
            entity.Property(e => e.AbilityId).IsFixedLength();
            entity.Property(e => e.CellProtection).IsFixedLength();
            entity.Property(e => e.EnemyName).IsFixedLength();
            entity.Property(e => e.Equipment).IsFixedLength();
            entity.Property(e => e.FactionId).IsFixedLength();
            entity.Property(e => e.ShieldType).IsFixedLength();

            entity.HasOne(d => d.Ability).WithMany(p => p.EnemyCells).HasConstraintName("FK_enemy_cells_mutation_abilities");

            entity.HasOne(d => d.Faction).WithMany(p => p.EnemyCells)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_enemy_cells_cell_faction");
        });

        modelBuilder.Entity<Gun>(entity =>
        {
            entity.Property(e => e.GunId).IsFixedLength();
            entity.Property(e => e.BulletId).IsFixedLength();
            entity.Property(e => e.GunName).IsFixedLength();

            entity.HasOne(d => d.Bullet).WithMany(p => p.Guns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guns_bullets");
        });

        modelBuilder.Entity<GunUpgradeConfig>(entity =>
        {
            entity.HasKey(e => e.GunLv).HasName("PK__gun_upgr__7EA6F9A419B4DD29");

            entity.Property(e => e.GunLv).ValueGeneratedNever();
        });

        modelBuilder.Entity<Mutation>(entity =>
        {
            entity.HasKey(e => e.MutationId).HasName("PK_Test_Table1");

            entity.Property(e => e.MutationId).IsFixedLength();
            entity.Property(e => e.CellProtection).IsFixedLength();
            entity.Property(e => e.FactionId).IsFixedLength();
            entity.Property(e => e.MutationName).IsFixedLength();
            entity.Property(e => e.ShieldType).IsFixedLength();

            entity.HasOne(d => d.Faction).WithMany(p => p.Mutations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mutations_cell_faction");
        });

        modelBuilder.Entity<MutationAbility>(entity =>
        {
            entity.Property(e => e.AbilityId).IsFixedLength();
            entity.Property(e => e.AbilityName).IsFixedLength();
            entity.Property(e => e.MutationId).IsFixedLength();

            entity.HasOne(d => d.Mutation).WithMany(p => p.MutationAbilities).HasConstraintName("FK_mutation_abilities_mutations");
        });

        modelBuilder.Entity<MutationUpgradeConfig>(entity =>
        {
            entity.HasKey(e => e.MutationLv).HasName("PK__mutation__3133F259C7CDCB68");

            entity.Property(e => e.MutationLv).ValueGeneratedNever();
        });
        modelBuilder.Entity<IngameLevelConfig>(entity =>
        {
            entity.HasKey(e => e.inGameLv).HasName("PK__ingame_l__4400D4D8552BD21F");

            entity.Property(e => e.xpRequire).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserGun>(entity =>
        {
            entity.Property(e => e.GunId).IsFixedLength();

            entity.HasOne(d => d.Gun).WithMany(p => p.UserGuns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_guns");

            entity.HasOne(d => d.User).WithMany(p => p.UserGuns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_AspNetUsers");
        });

        modelBuilder.Entity<UserMutation>(entity =>
        {
            entity.Property(e => e.MutationId).IsFixedLength();

            entity.HasOne(d => d.Mutation).WithMany(p => p.UserMutations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_mutations");

            entity.HasOne(d => d.User).WithMany(p => p.UserMutations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_AspNetUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<TwoDCellCore.Models.IngameLevelConfig> IngameLevelConfig { get; set; } = default!;

public DbSet<TwoDCellCore.Models.UserEquipment> UserEquipment { get; set; } = default!;
}
