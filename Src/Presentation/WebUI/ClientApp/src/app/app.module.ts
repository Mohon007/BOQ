import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MaterialInformationListComponent } from './material-information-list/material-information-list.component';
import { AngularMaterialModule } from './angular-material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WorkorderListComponent } from './workorder-list/workorder-list.component';
import { environment } from '../environments/environment';
import { API_BASE_URL } from './boq-api';
import { MaterialInformationDetailComponent } from './material-information-detail/material-information-detail.component';
import { InputTextComponent } from './input-text/input-text.component';
import { BoqReportComponent } from './boq-report/boq-report.component';
import { MatTableExporterModule } from 'mat-table-exporter';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MaterialInformationListComponent,
    WorkorderListComponent,
    MaterialInformationDetailComponent,
    InputTextComponent,
    BoqReportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AngularMaterialModule,
    BrowserAnimationsModule,
    MatTableExporterModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'material-info', component: MaterialInformationListComponent },
      { path: 'workorder-info', component: WorkorderListComponent },
      { path: 'material-detail', component: MaterialInformationDetailComponent },
      { path: 'boq-report', component: BoqReportComponent },
    ])
  ],
  providers: [{ provide: API_BASE_URL, useValue: environment.apiBaseUrl },],
  bootstrap: [AppComponent]
})
export class AppModule { }
