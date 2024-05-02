using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("bullet_types")]
public partial class BulletType
{
    [Key]
    [Column("bulletTypeID")]
    [StringLength(10)]
    public string BulletTypeId { get; set; } = null!;

    [Column("bulletTypeName")]
    [StringLength(30)]
    public string BulletTypeName { get; set; } = null!;

    [InverseProperty("BulletType")]
    public virtual ICollection<Bullet> Bullets { get; set; } = new List<Bullet>();
}
