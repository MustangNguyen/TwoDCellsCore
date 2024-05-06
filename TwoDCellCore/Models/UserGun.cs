using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Keyless]
[Table("user_gun")]
public partial class UserGun
{
    [Column("userID")]
    [StringLength(30)]
    public string UserId { get; set; } = null!;

    [Column("gunID")]
    [StringLength(10)]
    public string GunId { get; set; } = null!;

    [Column("gunLv")]
    public int GunLv { get; set; }

    [Column("gunXp")]
    public int GunXp { get; set; }

    [JsonIgnore]
    [ForeignKey("GunId")]
    public virtual Gun Gun { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}
