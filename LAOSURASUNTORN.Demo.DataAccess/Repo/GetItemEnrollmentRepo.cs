using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAOSURASUNTORN.Demo.Model;

namespace LAOSURASUNTORN.Demo.DataAccess.Repo
{
    public class GetItemEnrollmentRepo : GetEntityRepo<Enrollment>
    {
        public GetItemEnrollmentRepo(Context context) : base(context) { }
        public override IQueryable<Enrollment> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override Enrollment GetItemById(int id)
        {
            return this.context.Enrollments.FirstOrDefault(p => p.EnrollmentID == id);
        }
    }
}
