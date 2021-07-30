using Application.Model.WorkOrders;
using Application.WorkOrders.Command;
using Application.WorkOrders.Model;
using Application.WorkOrders.Queries;
using Infrastructure.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class WorkOrderController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkOrderModel>> Get(int id)
        {
            WorkOrderViewModel vm = new WorkOrderViewModel
            {
                Model = await Mediator.Send(new GetWorkOrderDetailQuery
                {
                    Id = id
                })
            };
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upload()
        {

            var file = Request.Form.Files[0];
            //var folderName = Path.Combine("Resources", "Images");
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\workorder", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                List<int> ids = new List<int>();
                var value = CsvFileHelper.ReadCsvFile<WorkOrderDummyModel>("wwwroot/workorder/" + fileName);
                foreach (var item in value)
                {
                    UpsertWorkOrderCommand command = new UpsertWorkOrderCommand();
                    command.Id = 0;
                    command.ProductCode = item.CODE;
                    command.ProductName = item.NAME;
                    command.Quantity = item.QUANTITY;
                    command.Unit = item.UNIT;
                    command.UnitPrice = item.UNITPRICE;
                    command.CreatedDate = DateTime.Now;
                    command.WorkOrderno = item.WONO;
                    var id = await Mediator.Send(command);
                    ids.Add(id);
                }
                return Ok(ids);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WorkOrderListModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetWorkOrderListQueries()));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteWorkOrderCommand { Id = id });

            return NoContent();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IList<int>>> Update(List<UpsertWorkOrderCommand> command)
        {
            List<int> ids = new List<int>();
            foreach (var cmd in command)
            {
                var id = await Mediator.Send(cmd);
                ids.Add(id);
            }
            return Ok(ids);
        }
    }
}



