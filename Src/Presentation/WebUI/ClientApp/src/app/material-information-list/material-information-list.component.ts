import { Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { StandardSpecificationClient, StandardSpecificationListModel } from '../boq-api';

@Component({
    selector: 'app-material-information-list',
    templateUrl: './material-information-list.component.html',
  styleUrls: ['./material-information-list.component.scss'],
  providers: [StandardSpecificationClient]
})
/** material-information-list component*/
export class MaterialInformationListComponent{
  id: number=0;
  displayedColumns: string[] = ['id', 'productCode', 'productName', 'unit', 'productType', 'averageRate', 'quantityInPack', 'procurementSource', 'openingBalance','remarks'];
  dataSource: MatTableDataSource<StandardSpecificationListModel>;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  detailRecordId: number = 0;
  showDetail: boolean = false;
  /** material-information-list ctor */
  constructor(public service: StandardSpecificationClient) {
    this.LoadData();
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  LoadData() {
    this.service.getAll().subscribe(data => {
      console.log(data,"Data");
      this.dataSource = new MatTableDataSource(data.listModel);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }
  AddNew(event: any) {
    this.showDetail = true;
    this.id = 0;
  }
  CloseDetail(event: any) {
    this.showDetail = false;
    this.LoadData();
  }
  Clear(event: any) {

  }
  EditDetail(data: any) {
    this.showDetail = true;
    this.id = data.id;
  }
}
