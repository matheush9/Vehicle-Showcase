import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Vehicle } from '../../interfaces/vehicle-interface';
import { VehicleService } from '../../services/vehicle.service';


@Component({
  selector: 'app-vehicle-add',
  templateUrl: './vehicle-add.component.html',
  styleUrls: ['./vehicle-add.component.css']
})
export class VehicleAddComponent {
  veiculo: Vehicle = {
    id: 0,
    nome: '',
    modelo: '',
    marca: '',
    foto: '',
    preco: 0,
  };

  imageSrc: string | ArrayBuffer | null = null;
  imageFile?: File;

  constructor(
    private vehicleService: VehicleService,
    private router: Router,
  ) {}

  addVehicle() {
    this.vehicleService.addVehicle(this.veiculo).subscribe((addedVeiculo) => {
      if (this.imageFile) 
        this.vehicleService.uploadVehicleImage(addedVeiculo.id, this.imageFile).subscribe();    

      this.router.navigate(['veiculos/painel']);
    });
  }
  
  uploadVehicleImage(event: any) {
    alert('O veículo em questão ainda não foi adicionado, então a imagem será carregada temporariamente!');  
    this.imageFile = event.target.files[0];      
    this.onImageSelected(event);     
  }

  onImageSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files.length > 0) {
      const file = inputElement.files[0];
      this.previewImage(file);
    }
  }

  previewImage(file: File) {
    const reader = new FileReader();
    reader.onload = (e: ProgressEvent) => {
      this.imageSrc = (e.target as FileReader).result;
    };
    reader.readAsDataURL(file);
  }
}