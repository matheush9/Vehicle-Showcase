import { Component } from '@angular/core';
import { Admin } from '../../interfaces/admin-interface';
import { AdminAuthService } from '../../services/admin-auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-admin',
  templateUrl: './new-admin.component.html',
  styleUrls: ['./new-admin.component.css'],
})
export class NewAdminComponent {
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

  register() {
    this.adminAuthService.register(this.admin).subscribe();
    this.adminAuthService
      .login(this.admin)
      .subscribe(() => this.router.navigate(['veiculos/painel']));
  }
}