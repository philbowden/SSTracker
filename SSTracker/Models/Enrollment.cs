using System;
using System.Collections.Generic;

namespace SSTracker.Models
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            Actfl = new HashSet<Actfl>();
        }

        public string SID { get; set; }
        public string ClassID { get; set; }
        public string YearQuarterID { get; set; }

        public virtual ICollection<Actfl> Actfl { get; set; }
    }
}
