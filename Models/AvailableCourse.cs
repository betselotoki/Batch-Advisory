namespace Batch_Advisory.Models
{
    public class AvailableCourse
    {
        public string CourseCode { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int? CreditHour { get; set; }
        public string? PrerequsiteCourse { get; set; }
        public string BatchTakingCourse { get; set; } = null!;
    }
}
