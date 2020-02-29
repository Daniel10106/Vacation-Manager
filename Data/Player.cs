using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual IdentityRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
