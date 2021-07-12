import { AfterViewInit, OnInit } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { WorkOrderClient, WorkOrderListModel, WorkOrderModel } from '../boq-api';


@Component({
    selector: 'app-workorder-list',
    templateUrl: './workorder-list.component.html',
  styleUrls: ['./workorder-list.component.scss'],
  providers: [WorkOrderClient]
})
/** workorder-list component*/
export class WorkorderListComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'workOrderno', 'productCode', 'productName', 'unit', 'quantity', 'unitPrice','createdDate'];
/*  data: WorkOrderModel[] = [];*/
  dataSource: MatTableDataSource<WorkOrderModel>;
  /** workorder-list ctor */
  constructor(public service: WorkOrderClient) {
    this.LoadData();
  }
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  ngAfterViewInit() {
  }
  ngOnInit(): void {
 
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  LoadData() {
    this.service.getAll().subscribe(data => {
      this.dataSource = new MatTableDataSource(data.workOrders);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  csvInputChange(fileInputEvent: any) {
    var file = fileInputEvent.target.files[0];
    this.service.upsert(file.name).subscribe(data => {
    });
  }
}
