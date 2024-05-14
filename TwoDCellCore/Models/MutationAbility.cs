using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("mutation_abilities")]
public partial class MutationAbility
{
    [Key]
    [Column("AbilityID")]
    [StringLength(10)]
    public string AbilityId { get; set; } = null!;

    [StringLength(50)]
    public string AbilityName { get; set; } = null!;

    [JsonIgnore]
    [Column("MutationID")]
    [StringLength(10)]
    public string? MutationId { get; set; }

    [InverseProperty("Ability")]
    public virtual ICollection<EnemyCell> EnemyCells { get; set; } = new List<EnemyCell>();

    [JsonIgnore]
    [ForeignKey("MutationId")]
    [InverseProperty("MutationAbilities")]
    public virtual Mutation? Mutation { get; set; }
}
