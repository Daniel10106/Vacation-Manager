using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class Team
    {
        public int teamId { get; set; }
        public string Name { get; set; }
        public virtual List<Player> Developers { get; set; }
        public virtual Player TeamLeader { get; set; }
    }
}
