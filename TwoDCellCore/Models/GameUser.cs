using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;

public class GameUser : IdentityUser
{
    [JsonIgnore]
    [InverseProperty("User")]
    public virtual ICollection<UserGun> UserGuns { get; set; } = new List<UserGun>();

    [JsonIgnore]
    [InverseProperty("User")]
    public virtual ICollection<UserMutation> UserMutations { get; set; } = new List<UserMutation>();

    [JsonIgnore]
    [InverseProperty("User")]
    public virtual ICollection<UserEquipment> UserEquipment { get; set; } = new List<UserEquipment>();

}
