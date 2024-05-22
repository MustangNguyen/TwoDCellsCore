using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("ingame_level_config")]
public partial class IngameLevelConfig
{
    [Key]
    [Column("inGameLv")]
    public int inGameLv { get; set; }

    [Column("xpRequire")]
    public int? xpRequire { get; set; }
}
