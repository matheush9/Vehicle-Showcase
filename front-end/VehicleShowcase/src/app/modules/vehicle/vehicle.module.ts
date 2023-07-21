import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleCardComponent } from './components/vehicle-card/vehicle-card.component';


@NgModule({
  declarations: [
    VehicleCardComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [VehicleCardComponent]
})
export class VehicleModule { }