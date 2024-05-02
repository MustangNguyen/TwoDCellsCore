using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

public partial class TwoDCellsDbContext : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=FUKUI\\SQLEXPRESS;Initial Catalog=TWODCELL;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.UserId).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.UserName).IsFixedLength();
        });

        modelBuilder.Entity<UserGun>(entity =>
        {
            entity.Property(e => e.GunId).IsFixedLength();
            entity.Property(e => e.UserId).IsFixedLength();

            entity.HasOne(d => d.Gun).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_guns");

            entity.HasOne(d => d.User).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_gun_users");
        });

        modelBuilder.Entity<UserMutation>(entity =>
        {
            entity.Property(e => e.MutationId).IsFixedLength();
            entity.Property(e => e.UserId).IsFixedLength();

            entity.HasOne(d => d.Mutation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_mutations");

            entity.HasOne(d => d.User).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_mutation_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
