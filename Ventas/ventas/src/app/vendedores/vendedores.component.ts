import { Component } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-vendedores',
  templateUrl: './vendedores.component.html',
  styleUrls: ['./vendedores.component.css']
})
export class VendedoresComponent {

  constructor(private service:CompartidoService){

  }
  VendedoresList:any=[];
  
  
  ModalTitle!:string;
  ActivateAgregar3Comp:boolean=false;
  agregar3:any;
  

  
  ngOnInit():void{
   this.refreshVendedores()
  }
  
  refreshVendedores(){
    this.service.obtenerVendedoresLista().subscribe(data=>{
      this.VendedoresList=data;
    });
  }
  
  addclick(){
    this.agregar3={
      id_vendedor:0,
      nombre:"",
      email:"",
      telefono:"",
      direccion:"",
    }
    this.ModalTitle="Añadir Vendedor";
    this.ActivateAgregar3Comp=true;
    
  }
  
  ViewClick2(item:any){
    console.log(item)
    this.agregar3=item;
    this.ModalTitle="Mostrar Vendedor";
    this.ActivateAgregar3Comp=true;
  }
  closeClick(){
    this.ActivateAgregar3Comp=false;
    this.refreshVendedores();
  }
  editClick(item:any){
    console.log(item)
    this.agregar3=item;
    this.ModalTitle="Editar Vendedor";
    this.ActivateAgregar3Comp=true;
  }
  deleteClick(item:any){
    if(confirm('¿Eliminar Vendedor?')){
      this.service.eliminarVendedores(item.id_vendedor).subscribe(data=>{
        alert(data.toString());
        this.refreshVendedores();
      })
    }
    }
  
}
