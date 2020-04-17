using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using LAOSURASUNTORN.Demo.DataAccess;
using LAOSURASUNTORN.Demo.DataAccess.Repo;
using LAOSURASUNTORN.Demo.Model;
using LAOSURASUNTORN.Demo.Repository;

namespace LAOSURASUNTORN.Demo.API.Controllers
{
    [EnableCors(origins: "https://localhost:44303", headers: "*", methods: "*")]
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private Context context = new Context(ConfigurationManager.ConnectionStrings["constr"].ToString());
        private ICUDEntityRepo<Student> repo;
        private IGetEntityRepo<Student> getEntityRepo;

        public StudentController()
        {
            repo = new CUDEntityRepo<Student>(context);
            getEntityRepo = new GetStudentRepo(context);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(Student student)
        {
            try
            {
                repo.Create(student);
                await repo.Save();
                return Ok(student.ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IHttpActionResult> Fetch(string name)
        {
            try
            {
                var items = getEntityRepo.GetByName(name);
                if (items == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return Ok(await items.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Fetch(int id)
        {
            try
            {
                var item = getEntityRepo.GetItemById(id);
                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return Ok(item);
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> FetchAll()
        {
            try
            {
                var items = getEntityRepo.GetAll();
                if (items == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return Ok(await items.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}
