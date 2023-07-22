import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

import { AdminAuthService } from '../../admin/services/admin-auth.service';

export function authGuard(): CanActivateFn {
  return () => {
    const adminAuthService: AdminAuthService = inject(AdminAuthService);
    const router: Router = inject(Router);

    if (adminAuthService.adminIsLogged()) return true;

    alert('Precisa estar logado como administrador para acessar esse recurso!');
    router.navigate(['admin/login']);

    return false;
  };
}