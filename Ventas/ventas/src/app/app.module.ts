import { NgModule ,NO_ERRORS_SCHEMA} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ClientesComponent } from './clientes/clientes.component';
import { VendedoresComponent } from './vendedores/vendedores.component';
import { ZonasComponent } from './zonas/zonas.component';



import { CompartidoService } from './compartido.service';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductosComponent } from './productos/productos.component';
import { AgregarComponent } from './clientes/agregar/agregar.component';
import { AgregarProductosComponent } from './agregar-productos/agregar-productos.component';
import { AgregarZonasComponent } from './agregar-zonas/agregar-zonas.component';
import { AgregarVendedoresComponent } from './agregar-vendedores/agregar-vendedores.component';
import { ReportesComponent } from './reportes/reportes.component';
import { AgregarVentaComponent } from './agregar-venta/agregar-venta.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ClientesComponent,
    VendedoresComponent,
    ZonasComponent,

   
    ProductosComponent,
    AgregarComponent,
    AgregarProductosComponent,
    AgregarZonasComponent,
    AgregarVendedoresComponent,
    ReportesComponent,
    AgregarVentaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [CompartidoService],
  bootstrap: [AppComponent],
  schemas:[
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
