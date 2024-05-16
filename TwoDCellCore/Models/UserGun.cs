using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_gun")]
[Index("GunId", Name = "IX_user_gun_gunID")]
[Index("UserId", Name = "IX_user_gun_userID")]
public partial class UserGun
{
    [Column("userID")]
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

    [ForeignKey("UserId")]
    public virtual User UserNavigation { get; set; } = null!;
}
