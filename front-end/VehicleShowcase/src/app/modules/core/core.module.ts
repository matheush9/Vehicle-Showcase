import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { VehicleModule } from '../vehicle/vehicle.module';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [HomeComponent, FooterComponent, NavbarComponent],
  imports: [RouterModule, CommonModule, VehicleModule],
  exports: [HomeComponent, FooterComponent, NavbarComponent],
})
export class CoreModule {}
