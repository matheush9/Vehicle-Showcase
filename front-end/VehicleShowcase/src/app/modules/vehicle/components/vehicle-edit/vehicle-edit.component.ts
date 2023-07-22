import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Vehicle } from '../../interfaces/vehicle-interface';
import { VehicleService } from '../../services/vehicle.service';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-vehicle-edit',
  templateUrl: './vehicle-edit.component.html',
  styleUrls: ['./vehicle-edit.component.css'],
})
export class VehicleEditComponent {
  veiculo: Vehicle = {
    id: 0,
    nome: '',
    modelo: '',
    marca: '',
    foto: '',
    preco: 0,
  };

  imagesProviderUrl: string = environment.imagesProviderUrl;

  constructor(
    private vehicleService: VehicleService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap
      .subscribe((params) => {
        const vehicleId = params.get('id');
        this.vehicleService
          .getVehicle(Number(vehicleId))
          .subscribe((vehicle) => {
            this.veiculo = vehicle;
          });
      }); 
  }

  updateVehicle() {
    this.vehicleService
      .updateVehicle(this.veiculo.id, this.veiculo)
      .subscribe();
  }

  uploadVehicleImage(event: any) {
    const image = event.target.files[0];
    this.vehicleService
      .uploadVehicleImage(this.veiculo.id, image)
      .subscribe((vehicle) => {
        this.veiculo = vehicle;
      });
  }
}