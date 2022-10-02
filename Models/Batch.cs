using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class Batch
    {
        public Batch()
        {
            Advisors = new HashSet<Advisor>();
            Students = new HashSet<Student>();
        }

        public string BatchId { get; set; } = null!;
        public int BatchSize { get; set; }
        public int CurrentYear { get; set; }
        public string CurrentTerm { get; set; } = null!;
        public int? TotalCourses { get; set; }

        public virtual Term CurrentTermNavigation { get; set; } = null!;
        public virtual ICollection<Advisor> Advisors { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
