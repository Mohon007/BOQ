import { Component, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { BOQReportClient, BOQReportModel } from '../boq-api';
import * as XLSX from 'xlsx';
@Component({
  selector: 'app-boq-report',
  templateUrl: './boq-report.component.html',
  styleUrls: ['./boq-report.component.scss'],
  providers: [BOQReportClient]
})
/** boq-report component*/
export class BoqReportComponent {
  WoOrd: string='';
  displayedColumns: string[] = ['slNo', 'orderNo', 'productCode', 'productName', 'orderQty', 'matCode', 'matName', 'matUnit', 'ups', 'paperQty', 'totalPack', 'approxUnitRate', 'totalAmountIncludeCarrying'];
  /** boq-report ctor */
  dataSource: MatTableDataSource<BOQReportModel>;
  constructor(public service: BOQReportClient) {
    this.LoadData();
  }
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild('table', { static: true }) table: ElementRef;
  //applyFilter(filterValue: string) {
  //  this.dataSource.filter = filterValue.trim().toLowerCase();
  //}
  LoadData() {
    console.log(this.WoOrd,'Wo');
    this.service.get(this.WoOrd).subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  Export(evetnt: any) {
    console.log(this.table, 'Event');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(this.table.nativeElement);//converts a DOM TABLE element to a worksheet
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, 'SheetJS.xlsx');
  }
}
