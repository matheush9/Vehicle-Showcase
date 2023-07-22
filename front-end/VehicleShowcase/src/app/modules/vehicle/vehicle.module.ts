import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MatTableModule } from '@angular/material/table'
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { VehicleCardComponent } from './components/vehicle-card/vehicle-card.component';
import { VehiclePanelComponent } from './components/vehicle-panel/vehicle-panel.component';
import { VehicleRoutingModule } from './vehicle-routing.module';
import { VehicleEditComponent } from './components/vehicle-edit/vehicle-edit.component';
import { VehicleAddComponent } from './components/vehicle-add/vehicle-add.component';


@NgModule({
  declarations: [
    VehicleCardComponent,
    VehiclePanelComponent,
    VehicleEditComponent,
    VehicleAddComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    VehicleRoutingModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule
  ],
  exports: [VehicleCardComponent]
})
export class VehicleModule { }