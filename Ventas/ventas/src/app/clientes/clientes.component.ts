import { Component } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent {
  constructor(private service:CompartidoService){

  }
  ClientesList:any=[];
  
  
  ModalTitle!:string;
  ActivateAgregarComp:boolean=false;
  agregar:any;
  
  
  
  ngOnInit():void{
   this.refreshClientes()
  }
  
  refreshClientes(){
    this.service.obtenerClientesLista().subscribe(data=>{
      this.ClientesList=data;
    });
  }
  
  addclick(){
    this.agregar={
      id_cliente:0,
      nombre:"",
      email:"",
      telefono:"",
      direccion:"",
    }
    this.ModalTitle="Añadir Cliente";
    this.ActivateAgregarComp=true;
    
  }
  
  ViewClick2(item:any){
    console.log(item)
    this.agregar=item;
    this.ModalTitle="Mostrar Cliente";
    this.ActivateAgregarComp=true;
  }
  closeClick(){
    this.ActivateAgregarComp=false;
    this.refreshClientes();
  }
  editClick(item:any){
    console.log(item)
    this.agregar=item;
    this.ModalTitle="Editar Cliente";
    this.ActivateAgregarComp=true;
  }
  deleteClick(item:any){
    if(confirm('¿Eliminar Cliente?')){
      this.service.eliminarClientes(item.id_cliente).subscribe(data=>{
        alert(data.toString());
        this.refreshClientes();
      })
    }
    }
  
   
  
}
