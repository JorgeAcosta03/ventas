import { Component } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  constructor(private service:CompartidoService){

  }
  VentasTotalesList:any=[];
  DetalleList:any=[];
  
  ModalTitle!:string;
  ActivateAgregarComp:boolean=false;
  agregar6:any;
  
  
  
  ngOnInit():void{
   this.refreshVentas()
   this.refreshDetalle()
  }
  
  refreshVentas(){
    this.service.obtenerVentas().subscribe(data=>{
      this.VentasTotalesList=data;
    });
  }
  refreshDetalle(){
    this.service.obtenerDetalles().subscribe(data=>{
      this.DetalleList=data;
    });
  }

  

   
  

}
