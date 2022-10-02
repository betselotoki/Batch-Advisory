using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class Student
    {
        public string Src { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Batch { get; set; } = null!;
        public double? Gpa { get; set; }
        public string Password { get; set; } = null!;
        public int? CoursesCompleted { get; set; }
        public int? CoursesRegistered { get; set; }

        public virtual Batch BatchNavigation { get; set; } = null!;
    }
}
