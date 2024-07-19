using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[PrimaryKey("UserId", "NodeId")]
[Table("node_process")]
public partial class NodeProcess
{
    [Key]
    [Column("userId")]
    public string UserId { get; set; } = null!;

    [Key]
    [Column("nodeId")]
    [StringLength(50)]
    public string NodeId { get; set; } = null!;

    [Column("isNodeFinish")]
    public bool? IsNodeFinish { get; set; }

    [Column("nodeScore")]
    public int? NodeScore { get; set; }

    [JsonIgnore]
    [ForeignKey("NodeId")]
    [InverseProperty("NodeProcesses")]
    public virtual PlanetNode Node { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("UserId")]
    [InverseProperty("NodeProcesses")]
    public virtual GameUser User { get; set; } = null!;
}
