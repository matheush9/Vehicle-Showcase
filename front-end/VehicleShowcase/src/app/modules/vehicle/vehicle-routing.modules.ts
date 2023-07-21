import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehiclePanelComponent } from './components/vehicle-panel/vehicle-panel.component';

const routes: Routes = [
  {
    path: '',
    children: [
        { path: 'painel', component: VehiclePanelComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VehicleRoutingModule {}
