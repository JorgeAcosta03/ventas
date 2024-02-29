import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompartidoService {

  readonly APIUrl="http://localhost:1201/api";
  constructor(private http:HttpClient) { }
//tabla clientes
  obtenerClientesLista():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Clientes');
  }

  agregarClientes(val:any){
    return this.http.post(this.APIUrl+'/Clientes',val);
  }
  actualizarClientes(val:any){
    return this.http.put(this.APIUrl+'/Clientes',val);
  }
  eliminarClientes(val:any){
    return this.http.delete(this.APIUrl+'/Clientes/'+val);
  }

  //tabla productos

  obtenerProductosLista():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Productos');
  }

  agregarProductos(val:any){
    return this.http.post(this.APIUrl+'/Productos',val);
  }
  actualizarProductos(val:any){
    return this.http.put(this.APIUrl+'/Productos',val);
  }
  eliminarProductos(val:any){
    return this.http.delete(this.APIUrl+'/Productos/'+val);
  }

  //tabla vendedores

  obtenerVendedoresLista():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Vendedores');
  }

  agregarVendedores(val:any){
    return this.http.post(this.APIUrl+'/Vendedores',val);
  }
  actualizarVendedores(val:any){
    return this.http.put(this.APIUrl+'/Vendedores',val);
  }
  eliminarVendedores(val:any){
    return this.http.delete(this.APIUrl+'/Vendedores/'+val);
  }

  //tabla zonas

  obtenerZonasLista():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Zonas');
  }

  agregarZonas(val:any){
    return this.http.post(this.APIUrl+'/Zonas',val);
  }
  actualizarZonas(val:any){
    return this.http.put(this.APIUrl+'/Zonas',val);
  }
  eliminarZonas(val:any){
    return this.http.delete(this.APIUrl+'/Zonas/'+val);
  }

  //Reportes

  obtenerZonasxVentas():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Venta/GetZonasxVentas');
  }
  obtenerZonasSinVentas(val:any):Observable<any>{
      return this.http.get<any>(this.APIUrl+'/Venta/GetZonasSinVentas',val);
  }

  obtenerVendedorSinVentas(val:any):Observable<any>{
    return this.http.get<any>(this.APIUrl+'/Venta/GetVendedorSinVentas',val);
}

obtenerVentasxCliente(val:any):Observable<any>{
  return this.http.get<any>(this.APIUrl+'/Venta/GetVentasxCliente',val);
}
  
//tabla ventas
obtenerVentas():Observable<any[]>{
  return this.http.get<any>(this.APIUrl+'/Venta');
}
//tabla Detalle Ventas
obtenerDetalles():Observable<any[]>{
  return this.http.get<any>(this.APIUrl+'/Detalle_ventas');
}
//Proceso ventas
agregarVenta(val:any){
  return this.http.post(this.APIUrl+'/Detalle/PostVenta',val);
}

agregarDetalle(val:any){
  return this.http.post(this.APIUrl+'/Detalle/PostDetalle',val);
}
}

