import { Component } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-zonas',
  templateUrl: './zonas.component.html',
  styleUrls: ['./zonas.component.css']
})
export class ZonasComponent {
  constructor(private service:CompartidoService){

  }
  ZonasList:any=[];
  
  
  ModalTitle!:string;
  ActivateAgregar4Comp:boolean=false;
  agregar4:any;
  

  
  ngOnInit():void{
   this.refreshZonas()
  }
  
  refreshZonas(){
    this.service.obtenerZonasLista().subscribe(data=>{
      this.ZonasList=data;
    });
  }
  
  addclick(){
    this.agregar4={
      id_zona:0,
      nombre_zona:" ",
      descripcion:" ",

    }
    this.ModalTitle="Añadir Zona";
    this.ActivateAgregar4Comp=true;
    
  }
  

  closeClick(){
    this.ActivateAgregar4Comp=false;
    this.refreshZonas();
  }
  editClick(item:any){
    console.log(item)
    this.agregar4=item;
    this.ModalTitle="Editar Zonas";
    this.ActivateAgregar4Comp=true;
  }
  deleteClick(item:any){
    if(confirm('¿Eliminar Zona?')){
      this.service.eliminarZonas(item.id_zona).subscribe(data=>{
        alert(data.toString());
        this.refreshZonas();
      })
    }
    }
  

}