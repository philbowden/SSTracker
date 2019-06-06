using System;
using System.Collections.Generic;

namespace SSTracker.Models
{
    public partial class Actfl
    {
        public string YearQuarterID { get; set; }
        public string Language { get; set; }
        public string ItemNumber { get; set; }
        public string SID { get; set; }
        public string PROF_TYPE { get; set; }
        public string PROF_LVL { get; set; }
        public string PROF_SCR { get; set; }

        public virtual Enrollment S { get; set; }
    }
}
