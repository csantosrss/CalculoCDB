using System.Net;
using CalculoCDB.Crosscutting;
using CalculoCDB.Models;
using CalculoCDB.Core;
using Microsoft.AspNetCore.Mvc;
using CalculoCDB.Service;

namespace CalculoCDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularController : CoreController
    {
        [HttpGet]
        public ActionResult<ReturnAPI<Response>> Calcular([FromQuery] Request request)
        {

            var result = new ReturnAPI<Response>();

            try
            {
                CDB cdb = new CDB();

                result.Content = cdb.Calcular(request);

                if (result.Content == null)
                {
                    result.Status = HttpStatusCode.NotFound;
                }
            }
            catch (Exception e)
            {
                result.Exception = e.ToString();
                result.Status = HttpStatusCode.InternalServerError;
            }

            return Result(result);
        }
    }
}
