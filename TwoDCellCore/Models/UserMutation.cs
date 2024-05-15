using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_mutation")]
[Index("MutationId", Name = "IX_user_mutation_MutationID")]
[Index("Id", Name = "IX_user_mutation_userID")]
public partial class UserMutation
{
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("MutationID")]
    [StringLength(10)]
    public string MutationId { get; set; } = null!;

    [Column("mutationLv")]
    public int MutationLv { get; set; }

    [Column("mutationiXp")]
    public int MutationiXp { get; set; }

    [JsonIgnore]
    [ForeignKey("Id")]
    public virtual AspNetUser IdNavigation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("MutationId")]
    public virtual Mutation Mutation { get; set; } = null!;
}
