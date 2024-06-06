using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

[Table("user_equipment")]
public partial class UserEquipment
{
    [Key]
    [StringLength(450)]
    [Column("userEquipmentID")]
    public string UserEquipmentId { get; set; } = null!;

    [Column("userID")]
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [Column("mutationOwnershipID")]
    [StringLength(450)]
    public string? MutationOwnershipId { get; set; }

    [Column("gunOwnershipID1")]
    [StringLength(450)]
    public string? GunOwnershipId1 { get; set; }

    [Column("gunOwnershipID2")]
    [StringLength(450)]
    public string? GunOwnershipId2 { get; set; }

    [JsonIgnore]
    [ForeignKey("GunOwnershipId1")]
    [InverseProperty("UserEquipmentGunOwnershipId1Navigations")]
    public virtual UserGun? GunOwnershipId1Navigation { get; set; } 

    [JsonIgnore]
    [ForeignKey("GunOwnershipId2")]
    [InverseProperty("UserEquipmentGunOwnershipId2Navigations")]
    public virtual UserGun? GunOwnershipId2Navigation { get; set; }

    [JsonIgnore]
    [ForeignKey("MutationOwnershipId")]
    [InverseProperty("UserEquipments")]
    public virtual UserMutation? MutationOwnership { get; set; }

    [JsonIgnore]
    [ForeignKey("UserId")]
    [InverseProperty("UserEquipment")]
    public virtual GameUser User { get; set; } = null!;
}
