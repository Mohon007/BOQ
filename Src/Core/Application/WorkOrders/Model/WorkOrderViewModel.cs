﻿using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.WorkOrders.Model
{
    public class WorkOrderViewModel
    {
        public WorkOrderModel Model { get; set; }
    }
    public class WorkOrderModel:IMapFrom<WorkOrder>
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public string Specification { get; set; }
        public double UnitPrice { get; set; }
        public string WorkOrderno { get; set; }
        public DateTime CreatedDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<WorkOrder, WorkOrderModel>();
            profile.CreateMap<WorkOrderModel, WorkOrder>();
        }
    }
    public class WorkOrderListModel
    {
        public IList<WorkOrderModel> WorkOrders { get; set; }
    }
}
