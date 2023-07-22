import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './modules/core/components/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },

  {
    path: 'veiculos',
    loadChildren: () =>
      import('./modules/vehicle/vehicle.module').then((m) => m.VehicleModule),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
