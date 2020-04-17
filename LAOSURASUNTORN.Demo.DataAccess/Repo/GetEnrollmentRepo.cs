using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAOSURASUNTORN.Demo.Model;
using System.Data.Entity;

namespace LAOSURASUNTORN.Demo.DataAccess.Repo
{
    public class GetEnrollmentRepo : GetEntityRepo<IQueryable<Enrollment>>
    {
        public GetEnrollmentRepo(Context context) : base(context) { }

        public override IQueryable<IQueryable<Enrollment>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Enrollment> GetItemById(int id)
        {
            return this.context.Enrollments.Include(p => p.Student)
                .Where(p => p.StudentID == id);
        }
    }
}
