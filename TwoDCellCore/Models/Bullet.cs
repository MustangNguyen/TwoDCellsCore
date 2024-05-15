using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("bullets")]
[Index("BulletTypeId", Name = "IX_bullets_bulletTypeID")]
[Index("Element", Name = "IX_bullets_element")]
public partial class Bullet
{
    [Key]
    [Column("bulletID")]
    [StringLength(10)]
    public string BulletId { get; set; } = null!;

    [Column("bulletName")]
    [StringLength(30)]
    public string BulletName { get; set; } = null!;

    [Column("bulletTypeID")]
    [StringLength(10)]
    public string BulletTypeId { get; set; } = null!;

    [Column("damage")]
    public int Damage { get; set; }

    [Column("timeExist")]
    public double TimeExist { get; set; }

    [Column("bulletSpeed")]
    public double BulletSpeed { get; set; }

    [Column("element")]
    [StringLength(20)]
    public string Element { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("BulletTypeId")]
    [InverseProperty("Bullets")]
    public virtual BulletType BulletType { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("Element")]
    [InverseProperty("Bullets")]
    public virtual Element ElementNavigation { get; set; } = null!;

    [InverseProperty("Bullet")]
    public virtual ICollection<Gun> Guns { get; set; } = new List<Gun>();
}
