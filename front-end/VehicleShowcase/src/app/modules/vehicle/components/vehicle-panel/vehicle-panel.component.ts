import { Component } from '@angular/core';
import { Observable } from 'rxjs';

import { Vehicle } from '../../interfaces/vehicle-interface';
import { VehicleService } from '../../services/vehicle.service';


@Component({
  selector: 'app-vehicle-panel',
  templateUrl: './vehicle-panel.component.html',
  styleUrls: ['./vehicle-panel.component.css'],
})
export class VehiclePanelComponent {
  columns: string[] = ['id', 'nome', 'marca', 'modelo', 'preco', 'editar', 'excluir'];
  vehicles$?: Observable<Vehicle[]>;

  constructor(private vehicleService: VehicleService) {}

  ngOnInit() {
    this.vehicles$ = this.vehicleService.getAllVehiclesOrderedDescending();
  }

  deleteVehicle(vehicleId: number) {
    this.vehicleService.deleteVehicle(vehicleId).subscribe(() => {
      this.vehicles$ = this.vehicleService.getAllVehiclesOrderedDescending();
    });        
  }
}
