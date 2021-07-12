using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.StandardSpecifications.Model
{
    public class StandardSpecificationViewModel
    {
        public StandardSpecificationModel Model { get; set; }
    }
    public class StandardSpecificationModel : IMapFrom<StandardSpecification>
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string ProductType { get; set; }
        public double AverageRate { get; set; }
        public double QuantityInPack { get; set; }
        public string ProcurementSource { get; set; }
        public double OpeningBalance { get; set; }
        public string Remarks { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StandardSpecificationModel, StandardSpecification>();
            profile.CreateMap<StandardSpecification, StandardSpecificationModel>();
        }
    }
    public class StandardSpecificationListModel
    {
        public IList<StandardSpecificationModel> ListModel { get; set; }
    }
}
