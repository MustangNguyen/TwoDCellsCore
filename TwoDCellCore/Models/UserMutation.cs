using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_mutation")]
[Index("MutationId", Name = "IX_user_mutation_MutationID")]
[Index("UserId", Name = "IX_user_mutation_userID")]
public partial class UserMutation
{
    [Column("userID")]
    public string UserId { get; set; } = null!;

    [Column("MutationID")]
    [StringLength(10)]
    public string MutationId { get; set; } = null!;

    [Column("mutationLv")]
    public int MutationLv { get; set; }

    [Column("mutationiXp")]
    public int MutationiXp { get; set; }

    [ForeignKey("MutationId")]
    public virtual Mutation Mutation { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual IdentityUser User { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual User UserNavigation { get; set; } = null!;
}
