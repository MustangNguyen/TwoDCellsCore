using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TwoDCellCore.Models;


public partial class AspNetUser : IdentityUser
{


    [InverseProperty("User")]
    public virtual ICollection<UserGun> UserGuns { get; set; } = new List<UserGun>();

    [InverseProperty("User")]
    public virtual ICollection<UserMutation> UserMutations { get; set; } = new List<UserMutation>();
}
