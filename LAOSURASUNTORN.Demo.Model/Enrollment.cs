using System;

namespace LAOSURASUNTORN.Demo.Model
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public enum Course
    {
        Science, Math, Art, English
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual Course Course { get; set; }        
        public virtual Student Student { get; set; }

    }
}
