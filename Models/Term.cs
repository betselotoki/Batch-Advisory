using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class Term
    {
        public Term()
        {
            Batches = new HashSet<Batch>();
            Courses = new HashSet<Course>();
        }

        public string TermId { get; set; } = null!;
        public string? TermName { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
