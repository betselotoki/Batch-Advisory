using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class Course
    {
        public Course()
        {
            InversePrerequsiteCourseNavigation = new HashSet<Course>();
        }

        public string CourseCode { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int? CreditHour { get; set; }
        public string? PrerequsiteCourse { get; set; }
        public int OnYear { get; set; }
        public string OnTerm { get; set; } = null!;

        public virtual Term OnTermNavigation { get; set; } = null!;
        public virtual Course? PrerequsiteCourseNavigation { get; set; }
        public virtual ICollection<Course> InversePrerequsiteCourseNavigation { get; set; }
    }
}
