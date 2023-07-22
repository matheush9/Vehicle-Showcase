import { Component } from '@angular/core';

import { Admin } from '../../interfaces/admin-interface';
import { AdminAuthService } from '../../services/admin-auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css'],
})
export class AdminLoginComponent {
  admin: Admin = {
    id: 0,
    nome: '',
    usuario: '',
    senha: '',
  };

  constructor(
    private adminAuthService: AdminAuthService,
    private router: Router
  ) {}

  login() {
    this.adminAuthService
      .login(this.admin)
      .subscribe(() => this.router.navigate(['veiculos/painel']));
  }
}
