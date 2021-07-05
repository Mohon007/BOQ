using Application.Model.WorkOrders;
using Application.WorkOrders.Command;
using Infrastructure.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class WorkOrderController: BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(string path)
        {
            List<int> ids = new List<int>();
            var value = CsvFileHelper.ReadCsvFile<WorkOrderDummyModel>("wwwroot/WorkOrder.csv");
            foreach (var item in value)
            {
                UpsertWorkOrderCommand command = new UpsertWorkOrderCommand();
                command.Id = 0;
                command.ProductCode = item.CODE;
                command.ProductName = item.NAME;
                command.Quantity = item.QUANTITY;
                command.Unit = item.UNIT;
                var id = await Mediator.Send(command);
                ids.Add(id);
            }
         
            return Ok(ids);
        }
    }
}
