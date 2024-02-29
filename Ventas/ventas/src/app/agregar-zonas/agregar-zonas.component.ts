import { Component, Input } from '@angular/core';
import { CompartidoService } from 'src/app/compartido.service';

@Component({
  selector: 'app-agregar-zonas',
  templateUrl: './agregar-zonas.component.html',
  styleUrls: ['./agregar-zonas.component.css']
})
export class AgregarZonasComponent {

  @Input() agregar4:any;
  id_zona!:string;
  nombre_zona!:string;
  descripcion!:string;
  constructor(private service:CompartidoService){}

  ngOnInit(): void {
   this.id_zona=this.agregar4.id_zona;
   this.nombre_zona=this.agregar4.nombre_zona;
   this.descripcion=this.agregar4.descripcion;
    
  }

agregarZona(){
  var val={
    nombre_zona:this.nombre_zona,
    descripcion:this.descripcion

  };
    this.service.agregarZonas(val).subscribe(res=>{
      alert(res.toString());
    })

  }

  actualizarZona(){
    var val={id_zona:this.id_zona,
      nombre_zona:this.nombre_zona,
     descripcion:this.descripcion,
     };
      this.service.actualizarZonas(val).subscribe(res=>{
        alert(res.toString());
      })
  
    }

}
