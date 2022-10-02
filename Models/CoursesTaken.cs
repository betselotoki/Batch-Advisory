using System;
using System.Collections.Generic;

namespace Batch_Advisory.Models
{
    public partial class CoursesTaken
    {
        public string Src { get; set; } = null!;
        public string CourseCode { get; set; } = null!;
        public string Grade { get; set; } = null!;

        public virtual Course CourseCodeNavigation { get; set; } = null!;
        public virtual Student SrcNavigation { get; set; } = null!;
    }
}
