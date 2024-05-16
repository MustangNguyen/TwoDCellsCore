using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

public partial class TwoDCellsDbContext : IdentityDbContext
{
    public TwoDCellsDbContext()
    {
    }

    public TwoDCellsDbContext(DbContextOptions<TwoDCellsDbContext> options)
        : base(options)
    {
    }

   

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

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGun> UserGuns { get; set; }

    public virtual DbSet<UserMutation> UserMutations { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<AspNetRole>(entity =>
        //{
        //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
        //        .IsUnique()
        //        .HasFilter("([NormalizedName] IS NOT NULL)");
        //});

        //modelBuilder.Entity<AspNetUser>(entity =>
        //{
        //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
        //        .IsUnique()
        //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

        //    entity.HasMany(d => d.Roles).WithMany(p => p.Users)
        //        .UsingEntity<Dictionary<string, object>>(
        //            "AspNetUserRole",
        //            r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
        //            l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
        //            j =>
        //            {
        //                j.HasKey("UserId", "RoleId");
        //                j.ToTable("AspNetUserRoles");
        //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
        //            });
        //});

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

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.UserName).IsFixedLength();
        });

        modelBuilder.Entity<UserGun>(entity =>
        {
            entity.Property(e => e.GunId).IsFixedLength();

            entity.HasOne(d => d.Gun).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_guns");

            entity.HasOne(d => d.User).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_AspNetUsers");

            entity.HasOne(d => d.UserNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_users");
        });

        modelBuilder.Entity<UserMutation>(entity =>
        {
            entity.Property(e => e.MutationId).IsFixedLength();

            entity.HasOne(d => d.Mutation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_mutations");

            entity.HasOne(d => d.User).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_AspNetUsers");

            entity.HasOne(d => d.UserNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
