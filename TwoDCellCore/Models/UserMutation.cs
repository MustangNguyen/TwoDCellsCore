using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_mutation")]
public partial class UserMutation
{
    [Column("userID")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [Column("mutationID")]
    [StringLength(10)]
    public string MutationId { get; set; } = null!;

    [Column("mutationLv")]
    public int MutationLv { get; set; }

    [Column("mutationXp")]
    public int MutationXp { get; set; }

    [JsonIgnore]
    [ForeignKey("MutationId")]
    public virtual Mutation Mutation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual IdentityUser User { get; set; } = null!;
}
