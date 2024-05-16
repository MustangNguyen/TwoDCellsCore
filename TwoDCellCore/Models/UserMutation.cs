using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [ForeignKey("MutationId")]
    [InverseProperty("UserMutations")]
    public virtual Mutation Mutation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserMutations")]
    public virtual AspNetUser User { get; set; } = null!;
}
