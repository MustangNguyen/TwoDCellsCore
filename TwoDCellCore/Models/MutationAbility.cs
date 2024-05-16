using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("mutation_abilities")]
[Index("MutationId", Name = "IX_mutation_abilities_MutationID")]
public partial class MutationAbility
{
    [Key]
    [Column("AbilityID")]
    [StringLength(10)]
    public string AbilityId { get; set; } = null!;

    [StringLength(50)]
    public string AbilityName { get; set; } = null!;

    [Column("MutationID")]
    [StringLength(10)]
    public string? MutationId { get; set; }

    [InverseProperty("Ability")]
    public virtual ICollection<EnemyCell> EnemyCells { get; set; } = new List<EnemyCell>();

    [ForeignKey("MutationId")]
    [InverseProperty("MutationAbilities")]
    public virtual Mutation? Mutation { get; set; }
}
