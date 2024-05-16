using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_gun")]
public partial class UserGun
{
    [Column("userID")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [Column("gunID")]
    [StringLength(10)]
    public string GunId { get; set; } = null!;

    [Column("gunLv")]
    public int GunLv { get; set; }

    [Column("gunXp")]
    public int GunXp { get; set; }

    [ForeignKey("GunId")]
    public virtual Gun Gun { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual IdentityUser User { get; set; } = null!;
}
