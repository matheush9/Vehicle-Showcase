import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AdminLoginComponent } from './components/admin-login/admin-login.component';
import { NewAdminComponent } from './components/new-admin/new-admin.component';

const routes: Routes = [
  {
    path: '',
    children: [
        { path: 'login', component: AdminLoginComponent},
        { path: 'new-admin', component: NewAdminComponent},
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
