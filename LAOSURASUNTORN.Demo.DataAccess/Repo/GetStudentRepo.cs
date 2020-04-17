using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAOSURASUNTORN.Demo.Model;

namespace LAOSURASUNTORN.Demo.DataAccess.Repo
{
    public class GetStudentRepo : GetEntityRepo<Student>
    {
        public GetStudentRepo(Context context) : base(context) { }

        public override IQueryable<Student> GetByName(string name)
        {
            return this.context.Student.Where(p => p.FirstName.Contains(name) || 
             p.LastName.Contains(name));
        }

        public override Student GetItemById(int id)
        {
            return this.context.Student.FirstOrDefault(p => p.ID == id);
        }
    }
}
