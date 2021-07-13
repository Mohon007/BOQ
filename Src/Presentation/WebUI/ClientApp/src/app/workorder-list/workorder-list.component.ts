import { HttpClient, HttpEventType } from '@angular/common/http';
import { AfterViewInit, Inject, OnInit, Optional } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { API_BASE_URL, WorkOrderClient, WorkOrderListModel, WorkOrderModel } from '../boq-api';


@Component({
  selector: 'app-workorder-list',
  templateUrl: './workorder-list.component.html',
  styleUrls: ['./workorder-list.component.scss'],
  providers: [WorkOrderClient]
})
/** workorder-list component*/
export class WorkorderListComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'workOrderno', 'productCode', 'productName', 'unit', 'quantity', 'unitPrice', 'createdDate'];
  /*  data: WorkOrderModel[] = [];*/
  dataSource: MatTableDataSource<WorkOrderModel>;
  public baseUrl: string;
  /** workorder-list ctor */
  constructor(public service: WorkOrderClient, public http: HttpClient
    , @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.baseUrl = baseUrl;
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

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
  
    this.http.post(this.baseUrl + '/' + "api/WorkOrder/Upload", formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        this.LoadData();
        }
      );
  }
}
