using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Data;

namespace VacationManager.Controllers
{
    public class TestController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public TestController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApplicationDbContext;");
            this.dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        public async Task<IActionResult> CreateRole()
        {
            var player = dbContext.Players.Where(p => p.FirstName == "Ivan").First().User;
            var user = userManager.Users.Where(u => u == player).First();
            await userManager.AddToRoleAsync(user, "CEO");

            return Ok();
        }
    }
}
