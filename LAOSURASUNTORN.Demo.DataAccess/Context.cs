using LAOSURASUNTORN.Demo.Model;
using System.Data.Entity;

namespace LAOSURASUNTORN.Demo.DataAccess
{
    public class Context : DbContext
    {
        public Context(){}
        public Context(string constr) : base(constr) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
