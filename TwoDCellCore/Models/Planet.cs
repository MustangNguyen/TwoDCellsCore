using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("planet")]
public partial class Planet
{
    [Key]
    [Column("planetId")]
    [StringLength(100)]
    public string PlanetId { get; set; } = null!;

    [Column("planetName")]
    [StringLength(100)]
    public string PlanetName { get; set; } = null!;

    [Column("planetOrder")]
    public int PlanetOrder { get; set; }

    [InverseProperty("Planet")]
    public virtual ICollection<PlanetNode> PlanetNodes { get; set; } = new List<PlanetNode>();
}
