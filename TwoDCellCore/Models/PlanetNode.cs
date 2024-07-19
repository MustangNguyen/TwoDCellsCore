using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("planet_node")]
public partial class PlanetNode
{
    [Key]
    [Column("nodeId")]
    [StringLength(50)]
    public string NodeId { get; set; } = null!;

    [Column("planetId")]
    [StringLength(100)]
    public string PlanetId { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("Node")]
    public virtual ICollection<NodeProcess> NodeProcesses { get; set; } = new List<NodeProcess>();

    [JsonIgnore]
    [ForeignKey("PlanetId")]
    [InverseProperty("PlanetNodes")]
    public virtual Planet Planet { get; set; } = null!;
}
