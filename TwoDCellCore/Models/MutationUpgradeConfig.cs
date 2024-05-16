using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("mutation_upgrade_config")]
public partial class MutationUpgradeConfig
{
    [Key]
    [Column("mutationLv")]
    public int MutationLv { get; set; }

    [Column("xpRequire")]
    public int? XpRequire { get; set; }
}
