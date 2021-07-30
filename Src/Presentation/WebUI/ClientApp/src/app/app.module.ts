import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableExporterModule } from 'mat-table-exporter';
import { AppSharedModule } from '../app-shared/app-shared.module';
import { environment } from '../environments/environment';
import { ExcelService } from '../Services/excel.service';
import { AngularMaterialModule } from './angular-material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { API_BASE_URL } from './boq-api';
import { BoqReportComponent } from './boq-report/boq-report.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { InputTextComponent } from './input-text/input-text.component';
import { MaterialInformationDetailComponent } from './material-information-detail/material-information-detail.component';
import { MaterialInformationListComponent } from './material-information-list/material-information-list.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { WorkorderListComponent } from './workorder-list/workorder-list.component';

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
    BoqReportComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AngularMaterialModule,
    BrowserAnimationsModule,
    MatTableExporterModule,
    FormsModule,
    AppRoutingModule,
    AppSharedModule
  ],
  providers: [{ provide: API_BASE_URL, useValue: environment.apiBaseUrl }, ExcelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
