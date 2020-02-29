using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class Project
    {
        public int projectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Team> ProjectTeams { get; set; }
    }
}
