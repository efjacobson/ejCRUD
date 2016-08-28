using Jacobson.Web.Models.Domain;
using Jacobson.Web.Models.Response;
using Jacobson.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Jacobson.Web.Controllers.Api
{
    [RoutePrefix("api/thing")]
    public class ThingApiController : ApiController
    {
        [Route]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(Thing thing)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                try
                {
                    int id = await ThingService.Create(thing);
                    return Request.CreateResponse(HttpStatusCode.Created, id);
                }
                catch (Exception exception)
                {
                    ErrorResponse errorResponse = new ErrorResponse(exception.Message);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
                }
            }
        }

        [Route]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                List<Thing> allThings = new List<Thing>();
                allThings = await ThingService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, allThings);
            }
            catch (Exception exception)
            {
                ErrorResponse errorResponse = new ErrorResponse(exception.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
            }
        }
    }
}
