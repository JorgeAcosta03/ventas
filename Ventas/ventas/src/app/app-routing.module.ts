import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {ClientesComponent} from './clientes/clientes.component';
import {VendedoresComponent} from './vendedores/vendedores.component';
import {ZonasComponent} from './zonas/zonas.component'; 
import {ProductosComponent} from './productos/productos.component';
import { ReportesComponent } from './reportes/reportes.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {path:'dashboard',component:DashboardComponent},
  {path:'clientes',component:ClientesComponent},
  {path:'vendedores',component:VendedoresComponent},
  {path:'zonas',component:ZonasComponent},
  {path:'productos',component:ProductosComponent},
  {path:'reportes',component:ReportesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
