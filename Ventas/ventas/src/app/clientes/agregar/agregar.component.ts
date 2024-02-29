import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.component.html',
  styleUrls: ['./agregar.component.css']
})
export class AgregarComponent {

  @Input() agregar:any;
  id_cliente!:string;
  nombre!:string;
  email!:string;
  telefono!:string;
  direccion!:string;
  constructor(private service:CompartidoService){}

  ngOnInit(): void {
   this.id_cliente=this.agregar.id_cliente;
   this.nombre=this.agregar.nombre;
   this.email=this.agregar.email;
   this.telefono=this.agregar.telefono;
   this.direccion=this.agregar.direccion;
    
  }

agregarCliente(){
  var val={
    nombre:this.nombre,
    email:this.email,
    telefono:this.telefono,
    direccion:this.direccion
  };
    this.service.agregarClientes(val).subscribe(res=>{
      alert(res.toString());
    })

  }

  actualizarCliente(){
    var val={id_cliente:this.id_cliente,
      nombre:this.nombre,
      email:this.email,
      telefono:this.telefono,
      direccion:this.direccion};
      this.service.actualizarClientes(val).subscribe(res=>{
        alert(res.toString());
      })
  
    }

}
