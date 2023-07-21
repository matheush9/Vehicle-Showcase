import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeComponent } from './components/home/home.component';
import { VehicleModule } from '../vehicle/vehicle.module';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';

@NgModule({
  declarations: [HomeComponent, FooterComponent, NavbarComponent],
  imports: [CommonModule, VehicleModule],
  exports: [HomeComponent, FooterComponent],
})
export class CoreModule {}
