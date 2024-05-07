using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;


[Table("gun_upgrade_config")]
public partial class GunUpgradeConfig
{
    [Key]
    [Column("mutationLv")]
    public int MutationLv { get; set; }

    [Column("xpRequire")]
    public int XpRequire { get; set; }
}
