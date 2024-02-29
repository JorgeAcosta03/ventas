import { Component } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent {
  constructor(private service:CompartidoService){

  }
  fecha!:string;
  fecha2!: string;
  fecha3!:string;
  fecha4!: string;
  fecha5!:string;
  fecha6!: string;
  CanZonasList:any=[];
  ZonasSinVentas:any=[];
  VendedorSinVentas:any=[];
  VentasClienteList:any=[];
  ngOnInit():void{
    this.fecha=this.fecha;
    this.fecha2=this.fecha2;
    this.obtenerCantidadZonas();
   }
   
   obtenerCantidadZonas(){
     this.service.obtenerZonasxVentas().subscribe(data=>{
       this.CanZonasList=data;
     });
   }

   agregarZonasSinVenta() {
    var val = {
      fecha: this.fecha,
      fecha2: this.fecha2
    };
    this.service.obtenerZonasSinVentas(val).subscribe(res => {
      this.ZonasSinVentas=res;
     
        });
   
  }

  agregarVendedorSinVentas() {
    var val = {
      fecha3: this.fecha3,
      fecha4: this.fecha4
    };
    this.service.obtenerVendedorSinVentas(val).subscribe(res => {
      this.VendedorSinVentas=res;
     
        });
  }
  VentasCliente(){
    var val = {
      fecha5: this.fecha5,
      fecha6: this.fecha6
    };
    this.service.obtenerVendedorSinVentas(val).subscribe(res => {
      this.VentasClienteList=res;
     
        });
  }
  
  
}
