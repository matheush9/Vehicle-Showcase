import { Component } from '@angular/core';

import { Admin } from '../../interfaces/admin-interface';
import { AdminAuthService } from '../../services/admin-auth.service';
import { Router } from '@angular/router';
import { catchError } from 'rxjs';
import { NgForm } from '@angular/forms';

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

  submitErrorMessage = '';
  formSubmitted = false;

  constructor(
    private adminAuthService: AdminAuthService,
    private router: Router
  ) {}

  login(form: NgForm) {
    this.formSubmitted = true;
    if (form.valid) {
      this.adminAuthService
        .login(this.admin)
        .pipe(
          catchError((error) => {
            if (error.status == 401) {
              this.submitErrorMessage = 'Usuário ou senha inválido';
            } else console.error(error);
            throw error;
          })
        )
        .subscribe(() => this.router.navigate(['veiculos/painel']));
    }
  }
}
