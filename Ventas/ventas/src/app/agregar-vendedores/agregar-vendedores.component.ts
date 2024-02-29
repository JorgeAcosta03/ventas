import { Component, Input } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-agregar-vendedores',
  templateUrl: './agregar-vendedores.component.html',
  styleUrls: ['./agregar-vendedores.component.css']
})
export class AgregarVendedoresComponent {

  @Input() agregar3:any;
  id_vendedor!:string;
  nombre!:string;
  email!:string;
  telefono!:string;
  direccion!:string;
  constructor(private service:CompartidoService){}

  ngOnInit(): void {
   this.id_vendedor=this.agregar3.id_vendedor;
   this.nombre=this.agregar3.nombre;
   this.email=this.agregar3.email;
   this.telefono=this.agregar3.telefono;
   this.direccion=this.agregar3.direccion;
    
  }

agregarVendedor(){
  var val={
    nombre:this.nombre,
    email:this.email,
    telefono:this.telefono,
    direccion:this.direccion
  };
    this.service.agregarVendedores(val).subscribe(res=>{
      alert(res.toString());
    })

  }

  actualizarVendedor(){
    var val={id_vendedor:this.id_vendedor,
      nombre:this.nombre,
      email:this.email,
      telefono:this.telefono,
      direccion:this.direccion};
      this.service.actualizarVendedores(val).subscribe(res=>{
        alert(res.toString());
      })
  
    }



}
