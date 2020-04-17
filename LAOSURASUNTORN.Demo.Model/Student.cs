using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAOSURASUNTORN.Demo.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public string FullName { get { return LastName + ", " + FirstName; } }
    }
}
