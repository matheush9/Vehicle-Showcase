import { Component } from '@angular/core';
import { Admin } from '../../interfaces/admin-interface';
import { AdminAuthService } from '../../services/admin-auth.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { catchError } from 'rxjs';

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

  submitErrorMessage = '';
  formSubmitted = false;

  constructor(
    private adminAuthService: AdminAuthService,
    private router: Router
  ) {}

  register(form: NgForm) {
    this.formSubmitted = true;
    if (form.valid) {
      this.adminAuthService.register(this.admin).subscribe(() => {
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
      });
    }
  }
}
