import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoqReportComponent } from './boq-report/boq-report.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { MaterialInformationDetailComponent } from './material-information-detail/material-information-detail.component';
import { MaterialInformationListComponent } from './material-information-list/material-information-list.component';
import { WorkorderListComponent } from './workorder-list/workorder-list.component';
const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'material-info', component: MaterialInformationListComponent },
  { path: 'workorder-info', component: WorkorderListComponent },
  { path: 'material-detail', component: MaterialInformationDetailComponent },
  { path: 'boq-report', component: BoqReportComponent },
];
@NgModule({
  declarations: [
  ],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]})
export class AppRoutingModule {
}
