using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VacationManager.Data;
using VacationManager.Models;

namespace VacationManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApplicationDbContext;");
            this.dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        public IActionResult Index()
        {            
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ShowAllAsync()
        {
            var viewModel = new List<PlayerViewModel>();
            var players = await dbContext.Players.ToListAsync();
            foreach(var player in players)
            {
                var user = _userManager.Users.Where(u => u == player.User).First();
                var role = await _userManager.GetRolesAsync(user);
                viewModel.Add(new PlayerViewModel { FirstName = player.FirstName, LastName = player.LastName, PlayerId = player.PlayerId, Role= role.First()});            
            }
            return View(viewModel);
        }

        public async Task<IActionResult> InfoAsync(int id)
        {
            var employeeViewModel = new EmployeeInfoViewModel();
            var player = dbContext.Players.Where(p => p.PlayerId == id).FirstOrDefault();
            var user = _userManager.Users.Where(u => u == player.User).First();
            var role = await _userManager.GetRolesAsync(user);
            employeeViewModel.FirstName = player.FirstName;
            employeeViewModel.LastName = player.LastName;
            employeeViewModel.PlayerId = id;
            if(dbContext.Teams.Where(x => x.Developers.Contains(player)).FirstOrDefault() != null)
            {
                employeeViewModel.Team = dbContext.Teams.Where(x => x.Developers.Contains(player)).FirstOrDefault().Name;
            }
            employeeViewModel.Role = role.FirstOrDefault();
            return View(employeeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
