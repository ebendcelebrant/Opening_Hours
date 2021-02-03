using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenHoursInterviewQuestion.Domain.Models;
using OpenHoursInterviewQuestion.Domain.Services;
using Newtonsoft.Json;
using static OpenHoursInterviewQuestion.Logging.AppExceptionLog;

namespace OpenHoursInterviewQuestion.Controllers
{
    [RoutePrefix("api/v1/openinghours")]
    public class OpeningHoursController : ApiController
    {
        public IOpeningHoursService _service;
        public OpeningHoursController(IOpeningHoursService service)
        {
            _service = service;
        }

        [Route("FromJson/Display")]
        [HttpPost]
        public IHttpActionResult DisplayFormattedOpeningHours(OpeningHours openingHours)
        {
            try
            {
                var response = _service.FormatOpeningHours(openingHours);
                return Ok(response);
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                return new System.Web.Http.Results.ResponseMessageResult(
                   Request.CreateResponse(HttpStatusCode.BadRequest));

            }
        }

        [Route("FromString/Display")]
        [HttpPost]
        public IHttpActionResult DisplayFormattedOpeningHours([FromBody]string openingHours)
        {
            try
            {
                var jsonModel = JsonConvert.DeserializeObject<OpeningHours>(openingHours);
                var response = _service.FormatOpeningHours(jsonModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                return new System.Web.Http.Results.ResponseMessageResult(
                   Request.CreateResponse(HttpStatusCode.BadRequest));

            }
        }
    }
}
