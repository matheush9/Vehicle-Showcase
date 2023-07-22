import { Component, Input } from '@angular/core';

import { Vehicle } from '../../interfaces/vehicle-interface';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-vehicle-card',
  templateUrl: './vehicle-card.component.html',
  styleUrls: ['./vehicle-card.component.css']
})
export class VehicleCardComponent {
  @Input() vehicle?: Vehicle;
  imagesProviderUrl: string = environment.imagesProviderUrl;
}
