using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("mutations")]
[Index("FactionId", Name = "IX_mutations_factionID")]
public partial class Mutation
{
    [Key]
    [Column("MutationID")]
    [StringLength(10)]
    public string MutationId { get; set; } = null!;

    [Column("HP")]
    public int Hp { get; set; }

    [Column("MP")]
    public int Mp { get; set; }

    [StringLength(50)]
    public string MutationName { get; set; } = null!;

    [StringLength(10)]
    public string CellProtection { get; set; } = null!;

    public int Armor { get; set; }

    public double MoveSpeed { get; set; }

    [Column("factionID")]
    [StringLength(10)]
    public string FactionId { get; set; } = null!;

    [StringLength(10)]
    public string ShieldType { get; set; } = null!;

    public int Shield { get; set; }

    [JsonIgnore]
    [ForeignKey("FactionId")]
    [InverseProperty("Mutations")]
    public virtual CellFaction Faction { get; set; } = null!;

    [InverseProperty("Mutation")]
    public virtual ICollection<MutationAbility> MutationAbilities { get; set; } = new List<MutationAbility>();

    [JsonIgnore]
    [InverseProperty("Mutation")]
    public virtual ICollection<UserMutation> UserMutations { get; set; } = new List<UserMutation>();
}
