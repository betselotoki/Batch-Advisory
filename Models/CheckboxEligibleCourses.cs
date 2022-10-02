using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Advisory.Models
{
    internal class CheckboxEligibleCourses
    {
        public string CourseCode { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int? CreditHour { get; set; }


        public string BatchTakingCourse { get; set; } = null!;
        public bool isRegistered { get; set; } = false;
    }
}
