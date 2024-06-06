using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("user_gun")]
public partial class UserGun
{
    [Key]
    [Column("ownershipID")]
    public string OwnershipId { get; set; } = null!;

    [Column("userID")]
    [StringLength(400)]
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
    [InverseProperty("UserGuns")]
    public virtual Gun Gun { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("UserId")]
    [InverseProperty("UserGuns")]
    public virtual GameUser User { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("GunOwnershipId1Navigation")]
    public virtual UserEquipment UserEquipmentGunOwnershipId1Navigations { get; set; } 

    [JsonIgnore]
    [InverseProperty("GunOwnershipId2Navigation")]
    public virtual UserEquipment UserEquipmentGunOwnershipId2Navigations { get; set; }
}
