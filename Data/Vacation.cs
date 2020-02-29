using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationManager.Data
{
    public class Vacation
    {
        public int vacationId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool HalfDay { get; set; }
        public bool Approved { get; set; }
        public virtual Player PlayerOnVacation { get; set; }
        public string fileName { get; set; }
    }
}
