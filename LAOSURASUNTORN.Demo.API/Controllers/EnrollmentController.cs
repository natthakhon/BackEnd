using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    [RoutePrefix("api/enrollment")]
    public class EnrollmentController : ApiController
    {
        private Context context = new Context(ConfigurationManager.ConnectionStrings["constr"].ToString());
        
        private ICUDEntityRepo<Enrollment> repo;
        private IGetEntityRepo<IQueryable<Enrollment>> getEnrollmentRepo;
        private IGetEntityRepo<Enrollment> getitemEnrollRepo;
        public EnrollmentController()
        {
            this.getEnrollmentRepo = new GetEnrollmentRepo(context);
            this.getitemEnrollRepo = new GetItemEnrollmentRepo(context);
            this.repo = new CUDEntityRepo<Enrollment>(context, this.getitemEnrollRepo);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(Enrollment enrollment)
        {
            try
            {
                repo.Create(enrollment);
                await repo.Save();
                return Ok(enrollment.EnrollmentID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Enrollment enrollment)
        {
            try
            {
                repo.Update(enrollment);
                await repo.Save();
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                return Ok();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{i}")]
        public async Task<IHttpActionResult> Delete(int i)
        {
            try
            {
                repo.Delete(i);
                await repo.Save();
                return Ok();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Fetch(int id)
        {
            try
            {
                var items = getEnrollmentRepo.GetItemById(id);
                if (items == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    return Ok(items.ToList());
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
