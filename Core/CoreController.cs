using System.Net;
using CalculoCDB.Crosscutting;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Core
{
    public class CoreController : Controller
    {

        protected ActionResult<T> Result<T>(T ReturnAPI)
            where T : ReturnAPI
        {
            return new ObjectResult(ReturnAPI);
        }

        protected ActionResult<T> Result<T>(T ReturnAPI, HttpStatusCode Status)
            where T : ReturnAPI
        {
            ReturnAPI.Status = Status;
            return Result(ReturnAPI);
        }
    }
}
