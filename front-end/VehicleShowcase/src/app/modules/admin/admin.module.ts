import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AdminRoutingModule } from './admin-routing.module';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { AdminLoginComponent } from './components/admin-login/admin-login.component';
import { NewAdminComponent } from './components/new-admin/new-admin.component';

@NgModule({
  declarations: [AdminLoginComponent, NewAdminComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    AdminRoutingModule,
  ],
})
export class AdminModule {}
