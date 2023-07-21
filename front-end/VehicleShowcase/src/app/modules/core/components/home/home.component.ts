import { Observable } from 'rxjs';
import { Component } from '@angular/core';
import { VehicleService } from 'src/app/modules/vehicle/services/vehicle.service';
import { Vehicle } from 'src/app/modules/vehicle/interfaces/vehicle-interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  vehicles$?: Observable<Vehicle[]>;
  
  constructor(private vehicleService: VehicleService) {}

  ngOnInit() {
    this.getAllVehiclesOrderedByPrice();
  }

  getAllVehiclesOrderedByPrice() {
    this.vehicles$ = this.vehicleService.getAllVehiclesOrderedByPrice();
  }
}