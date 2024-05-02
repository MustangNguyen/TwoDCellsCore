using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("elements")]
public partial class Element
{
    [Key]
    [Column("element")]
    [StringLength(20)]
    public string Element1 { get; set; } = null!;

    [InverseProperty("ElementNavigation")]
    public virtual ICollection<Bullet> Bullets { get; set; } = new List<Bullet>();
}
