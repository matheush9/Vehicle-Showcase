import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VehicleEditComponent } from './components/vehicle-edit/vehicle-edit.component';
import { VehiclePanelComponent } from './components/vehicle-panel/vehicle-panel.component';
import { VehicleAddComponent } from './components/vehicle-add/vehicle-add.component';

import { authGuard } from '../core/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    children: [
        { path: 'painel', component: VehiclePanelComponent, canActivate: [authGuard()] },
        { path: 'adicionar', component: VehicleAddComponent, canActivate: [authGuard()] },
        { path: 'editar/:id', component: VehicleEditComponent, canActivate: [authGuard()] }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VehicleRoutingModule {}
