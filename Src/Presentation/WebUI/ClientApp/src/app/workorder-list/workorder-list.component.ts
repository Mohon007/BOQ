import { SelectionModel } from '@angular/cdk/collections';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { AfterViewInit, Inject, OnInit, Optional } from '@angular/core';
import { ElementRef } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { API_BASE_URL, WorkOrderClient, WorkOrderListModel, WorkOrderModel } from '../boq-api';
import * as XLSX from 'xlsx';
import { ExcelService } from '../../Services/excel.service';
import { datepickerAnimation } from 'ngx-bootstrap/datepicker/datepicker-animations';

@Component({
  selector: 'app-workorder-list',
  templateUrl: './workorder-list.component.html',
  styleUrls: ['./workorder-list.component.scss'],
  providers: [WorkOrderClient, ExcelService]
})
/** workorder-list component*/
export class WorkorderListComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['select', 'id', 'workOrderno', 'productCode', 'productName', 'unit', 'quantity', 'unitPrice', 'createdDate', 'matName', 'matUnit','ups', 'qtyPersheet', 'sheetInReem', 'rimPrice'];
  /*  data: WorkOrderModel[] = [];*/
  dataSource: MatTableDataSource<WorkOrderModel>;
  selection = new SelectionModel<WorkOrderModel>(true, []);
  public baseUrl: string;
  /** workorder-list ctor */
  constructor(public service: WorkOrderClient, public http: HttpClient, public excelservice: ExcelService
    , @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.baseUrl = baseUrl;
    this.LoadData();
  }
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild('table', { static: true }) table: ElementRef;
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
      this.paginator.pageSize = 10;
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

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }
  GenerateReport() {
    this.service.update(this.selection.selected).subscribe(data => {
      if (data != null) {
        this.Export();
      }
    });
  }
  Export() {
  /*workOrders ?: WorkOrderModel[]*/
    var exportData: ReportModel[] = [];
    for (var item of this.selection.selected) {
      let rptdata = new ReportModel();
      rptdata.OrderNo = item.workOrderno;
      rptdata.ProductCode = item.productCode;
      rptdata.ProductName = item.productName;
      rptdata.OrderQty = item.quantity;
      rptdata.MaterialsName = item.matName;
      rptdata.MaterialsUnit = item.matUnit;
      rptdata.UPS = item.ups;
      rptdata.TotalSheets = item.quantity / item.qtyPersheet;
      rptdata.TotalPackPerRIM = rptdata.TotalSheets / item.sheetInReem;
      rptdata.RIMPricePerUnit = item.rimPrice;
      rptdata.TotalPriceofPaper = item.rimPrice * rptdata.TotalPackPerRIM;
      exportData.push(rptdata);
    }
    var filename = '';
  var wolist=  exportData.map(item => item.OrderNo)
      .filter((value, index, self) => self.indexOf(value) === index)

    for (var i = 0; i < wolist.length; i++) {
      if (i == 0) {
        filename = wolist[i];
      }
      else {
        filename = filename+','+ wolist[i];
      }
     
    }
    this.excelservice.exportAsExcelFile(exportData, filename);
  }

  Calculate(model: WorkOrderModel) {
    var paperorboardinqty = model.quantity / model.qtyPersheet;
    var TotalPackperrim = paperorboardinqty / model.sheetInReem;
    var TotalPriceOfpaper = model.rimPrice * TotalPackperrim;
  }

}

class ReportModel {
  OrderNo?: string;
  ProductCode?: string;
  ProductName?: string;
  OrderQty?: number;
  MaterialsName?: string;
  MaterialsUnit?: string;
  UPS?: number;
  TotalSheets?: number;
  TotalPackPerRIM?: number;
  RIMPricePerUnit?: number;
  TotalPriceofPaper?: number;
}

