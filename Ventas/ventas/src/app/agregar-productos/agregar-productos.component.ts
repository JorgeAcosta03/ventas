import { Component, Input } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-agregar-productos',
  templateUrl: './agregar-productos.component.html',
  styleUrls: ['./agregar-productos.component.css']
})
export class AgregarProductosComponent {

  @Input() agregar2:any;
  id_producto!:string;
  nombre!:string;
  descripcion!:string;
  precio!:string;
  stock!:string;
  categoria!:string;
  constructor(private service:CompartidoService){}

  ngOnInit(): void {
   this.id_producto=this.agregar2.id_producto;
   this.nombre=this.agregar2.nombre;
   this.descripcion=this.agregar2.descripcion;
   this.precio=this.agregar2.precio;
   this.stock=this.agregar2.stock;
   this.categoria=this.agregar2.categoria;
    
  }

agregarProducto(){
  var val={
    nombre:this.nombre,
    descripcion:this.descripcion,
    precio:this.precio,
    stock:this.stock,
    categoria:this.categoria
  };
    this.service.agregarProductos(val).subscribe(res=>{
      alert(res.toString());
    })

  }

  actualizarProducto(){
    var val={id_producto:this.id_producto,
      nombre:this.nombre,
    descripcion:this.descripcion,
    precio:this.precio,
    stock:this.stock,
    categoria:this.categoria};
      this.service.actualizarProductos(val).subscribe(res=>{
        alert(res.toString());
      })
  
    }

}
