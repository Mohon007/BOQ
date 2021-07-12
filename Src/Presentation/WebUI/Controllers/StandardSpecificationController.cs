using Application.StandardSpecifications.Command;
using Application.StandardSpecifications.Model;
using Application.StandardSpecifications.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class StandardSpecificationController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StandardSpecificationViewModel>> Get(int id)
        {
            StandardSpecificationViewModel vm = new StandardSpecificationViewModel
            {
                Model = await Mediator.Send(new GetStandardSpecificationDetailsQuery
                {
                    Id = id
                })
            };
            return Ok(vm);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertStandardSpecificationCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StandardSpecificationListModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetStandardSpecificationListQuries()));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteStandardSpecificationCommand { Id = id });

            return NoContent();
        }

    }
}