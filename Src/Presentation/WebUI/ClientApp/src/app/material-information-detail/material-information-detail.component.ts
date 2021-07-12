import { Component, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { StandardSpecificationClient, StandardSpecificationModel } from '../boq-api';

@Component({
  selector: 'app-material-information-detail',
  templateUrl: './material-information-detail.component.html',
  styleUrls: ['./material-information-detail.component.scss'],
  providers: [StandardSpecificationClient]
})
/** material-information-detail component*/
export class MaterialInformationDetailComponent implements OnInit {
  @Output() closeDetail = new EventEmitter();
  saveButtonText: string = "Save";
  private _id: number;
  get Id(): number {
    return this._id;
  }
  @Input()
  set Id(value: number) {
    this._id = value;
  }
  model: StandardSpecificationModel;
  /** material-information-detail ctor */
  constructor(public service: StandardSpecificationClient) {
    this.model = new StandardSpecificationModel();

  }
  ngOnInit(): void {
    if (this._id != 0) {
      this.saveButtonText = 'Update';
    }
    else {
      this.saveButtonText = 'Save';
    }
    this.service.get(this._id).subscribe(data => {
      this.model = data.model;
    });
  }
  onSubmit(f: NgForm) {
    this.model = f.value;
    if (this._id !== 0) {
      this.model.id = this._id;
    }
    this.service.upsert(this.model).subscribe(data => {
      if (data) {
        this.model = null;
        this.closeDetail.emit("0");
      }
    });
  }
  NewEntry() {
    this.model = null;
  }
  Close() {
    this.model = null;
    this.closeDetail.emit("0");
  }
}
