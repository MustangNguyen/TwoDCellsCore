using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("guns")]
[Index("BulletId", Name = "IX_guns_bulletID")]
public partial class Gun
{
    [Key]
    [Column("gunID")]
    [StringLength(10)]
    public string GunId { get; set; } = null!;

    [Column("gunName")]
    [StringLength(30)]
    public string GunName { get; set; } = null!;

    [Column("bulletID")]
    [StringLength(10)]
    public string BulletId { get; set; } = null!;

    [Column("fireRate")]
    public double FireRate { get; set; }

    [Column("accuracy")]
    public double Accuracy { get; set; }

    [Column("criticalRate")]
    public double CriticalRate { get; set; }

    [Column("criticalMultiple")]
    public double CriticalMultiple { get; set; }

    [JsonIgnore]
    [ForeignKey("BulletId")]
    [InverseProperty("Guns")]
    public virtual Bullet Bullet { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("Gun")]
    public virtual ICollection<UserGun> UserGuns { get; set; } = new List<UserGun>();
}
