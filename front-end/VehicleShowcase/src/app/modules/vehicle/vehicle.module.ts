import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleCardComponent } from './components/vehicle-card/vehicle-card.component';
import { VehiclePanelComponent } from './components/vehicle-panel/vehicle-panel.component';
import { VehicleRoutingModule } from './vehicle-routing.modules';


@NgModule({
  declarations: [
    VehicleCardComponent,
    VehiclePanelComponent
  ],
  imports: [
    CommonModule,
    VehicleRoutingModule
  ],
  exports: [VehicleCardComponent]
})
export class VehicleModule { }