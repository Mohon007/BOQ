import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AngularMaterialModule } from '../app/angular-material.module';
import { DataGridComponent } from './data-grid/data-grid.component';
@NgModule({
  imports: [AngularMaterialModule, CommonModule],
  exports: [DataGridComponent],
  declarations: [DataGridComponent],
  providers: []
})
export class AppSharedModule {
}
