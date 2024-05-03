using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("userID")]
    [StringLength(30)]
    public string UserId { get; set; } = null!;

    [Column("userName")]
    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [Column("password")]
    [StringLength(18)]
    public string Password { get; set; } = null!;

    [Column("credit")]
    public long Credit { get; set; }
}
