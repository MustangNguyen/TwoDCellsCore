using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("cell_faction")]
public partial class CellFaction
{
    [Key]
    [Column("factionID")]
    [StringLength(10)]
    public string FactionId { get; set; } = null!;

    [Column("factionName")]
    [StringLength(30)]
    public string FactionName { get; set; } = null!;

    [InverseProperty("Faction")]
    public virtual ICollection<EnemyCell> EnemyCells { get; set; } = new List<EnemyCell>();

    [InverseProperty("Faction")]
    public virtual ICollection<Mutation> Mutations { get; set; } = new List<Mutation>();
}
