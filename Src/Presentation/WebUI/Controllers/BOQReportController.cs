using Application.BOQReport.Model;
using Application.BOQReport.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class BOQReportController : BaseController
    {
        [HttpGet("{wono}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<BOQReportModel>>> Get(string wono)
        {
            IList<BOQReportModel> model = new List<BOQReportModel>();

            model = await Mediator.Send(new GetBoqReportQuery {WoOrd=wono });
           
            return Ok(model);
        }
    }
}
