using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_mutation")]
public partial class UserMutation
{
    [Column("userID")]
    [StringLength(30)]
    public string UserId { get; set; } = null!;

    [Column("MutationID")]
    [StringLength(10)]
    public string MutationId { get; set; } = null!;

    [Column("mutationLv")]
    public int MutationLv { get; set; }

    [Column("mutationiXp")]
    public int MutationiXp { get; set; }

    [JsonIgnore]
    [ForeignKey("MutationId")]
    public virtual Mutation Mutation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}
