using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("user_gun")]
public partial class UserGun
{
    [Key]
    [Column("ownershipID")]
    public string OwnershipId { get; set; } = null!;

    [Column("userID")]
    [StringLength(400)]
    public string UserId { get; set; } = null!;

    [Column("gunID")]
    [StringLength(10)]
    public string GunId { get; set; } = null!;

    [Column("gunLv")]
    public int GunLv { get; set; }

    [Column("gunXp")]
    public int GunXp { get; set; }

    [ForeignKey("GunId")]
    [InverseProperty("UserGuns")]
    public virtual Gun Gun { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserGuns")]
    public virtual AspNetUser User { get; set; } = null!;
}
