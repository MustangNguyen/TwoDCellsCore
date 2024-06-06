using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("user_mutation")]
public partial class UserMutation
{
    [Key]
    [Column("ownershipID")]
    public string OwnershipId { get; set; } = null!;

    [Column("userID")]
    [StringLength(400)]
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
    [InverseProperty("UserMutations")]
    public virtual Mutation Mutation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("UserId")]
    [InverseProperty("UserMutations")]
    public virtual GameUser User { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("MutationOwnership")]
    public virtual UserEquipment UserEquipments { get; set; }
}
