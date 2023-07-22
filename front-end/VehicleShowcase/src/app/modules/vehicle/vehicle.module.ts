import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatTable, MatTableModule } from '@angular/material/table'

import { VehicleCardComponent } from './components/vehicle-card/vehicle-card.component';
import { VehiclePanelComponent } from './components/vehicle-panel/vehicle-panel.component';
import { VehicleRoutingModule } from './vehicle-routing.module';


@NgModule({
  declarations: [
    VehicleCardComponent,
    VehiclePanelComponent
  ],
  imports: [
    CommonModule,
    VehicleRoutingModule,
    MatTableModule
  ],
  exports: [VehicleCardComponent]
})
export class VehicleModule { }