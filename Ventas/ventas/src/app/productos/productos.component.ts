import { Component } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent {
  constructor(private service:CompartidoService){

  }
  ProductosList:any=[];
  
  
  ModalTitle!:string;
  ActivateAgregar2Comp:boolean=false;
  agregar2:any;
  
 
  
  ngOnInit():void{
   this.refreshProductos()
  }
  
  refreshProductos(){
    this.service.obtenerProductosLista().subscribe(data=>{
      this.ProductosList=data;
    });
  }
  
  addclick(){
    this.agregar2={
      id_producto:0,
      nombre:"",
      descripcion:"",
      precio:"",
      stock:"",
      categoria:"",
    }
    this.ModalTitle="Añadir Producto";
    this.ActivateAgregar2Comp=true;
    
  }
  

  closeClick(){
    this.ActivateAgregar2Comp=false;
    this.refreshProductos();
  }
  editClick(item:any){
    console.log(item)
    this.agregar2=item;
    this.ModalTitle="Editar Producto";
    this.ActivateAgregar2Comp=true;
  }
  deleteClick(item:any){
    if(confirm('¿Eliminar Producto?')){
      this.service.eliminarProductos(item.id_producto).subscribe(data=>{
        alert(data.toString());
        this.refreshProductos();
      })
    }
    }
  
  
}
