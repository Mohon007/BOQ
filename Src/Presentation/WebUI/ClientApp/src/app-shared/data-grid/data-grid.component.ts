import { ViewChild } from '@angular/core';
import { Component, Input, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { strict } from 'assert';

@Component({
  selector: 'app-data-grid',
  templateUrl: './data-grid.component.html',
  styleUrls: ['./data-grid.component.scss']
})
/** data-grid component*/
export class DataGridComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  dataSource: any;
  @Input() title: string='';
  private _data: any;
  displayedColumns: string[] = [];
  get data() {
    return this._data;
  }
  @Input('data') set data(value: any) {
    this._data = value;
    this.dataSource = new MatTableDataSource(this._data);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if (this.data) {
      for (var colmn in this._data[0]) {
        this.displayedColumns.push(colmn);
      }

    }
  }

  /** data-grid ctor */
  constructor() {
  }
  ngOnInit(): void {

  }
}
