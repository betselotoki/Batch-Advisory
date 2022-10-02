using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Advisory.Models
{
    internal class EligibleCourse
    {

        [DisplayName("SRC")]
        public string Src { get; set; } = null!;

        public Student student { get; set; } = null!;
        public List<CheckboxEligibleCourses> CoursesList { get; set; }=null!;
    }
}
