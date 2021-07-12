using Application.BOQReport.Model;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BOQReport.Queries
{
    public class GetBoqReportQuery:IRequest<IList<BOQReportModel>>
    {
        public string WoOrd { get; set; }
        public class Handler : IRequestHandler<GetBoqReportQuery, IList<BOQReportModel>>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<IList<BOQReportModel>> Handle(GetBoqReportQuery request, CancellationToken cancellationToken)
            {
                List<BOQReportModel> mo = new List<BOQReportModel>();

                var woord = from wo in _context.workOrders
                            join mtinfo in _context.standardSpecifications
                            on wo.ProductCode equals mtinfo.ProductCode
                            where(wo.WorkOrderno==request.WoOrd)
                            select new 
                            {
                             wo.ProductCode
                            ,woProd=wo.ProductName
                            ,wo.UnitPrice
                            ,wo.Quantity
                            ,wo.Unit
                            ,wo.WorkOrderno
                            ,mtinfo.ProductName
                            ,mtinfo.ProcurementSource
                            ,mtinfo.OpeningBalance
                            ,mtinfo.ProductType
                            ,mtunit=mtinfo.Unit
                            ,mtinfo.AverageRate
                            ,mtinfo.QuantityInPack
                            ,mtinfo.Remarks
                            };

                foreach (var item in woord)
                {
                    var highestId = mo.Any() ? mo.Max(x => x.SlNo) : 0;
                    BOQReportModel model= new BOQReportModel();
                    model.ApproxUnitRate = (decimal)item.AverageRate;
                    model.MatCode = item.ProductCode;
                    model.MatName = item.ProductName;
                    model.MatUnit = item.mtunit;
                    model.OrderNo = item.WorkOrderno;
                    model.OrderQty = item.Quantity;
                    model.PaperQty = item.QuantityInPack;
                    model.ProductCode = item.ProductCode;
                    model.ProductName = item.ProductName;
                    model.SlNo = highestId+1;
                    model.TotalAmountIncludeCarrying = (decimal)(item.Quantity * item.AverageRate);
                    model.TotalPack = item.QuantityInPack;
                    model.Ups = item.woProd;
                    mo.Add(model);
                }
                return mo;

            }
        }
    }
}
