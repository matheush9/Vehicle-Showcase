import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Admin } from '../interfaces/admin-interface';
import { JwtTokenService } from '../../core/services/jwt-token.service';
import { JwtToken } from '../../core/interfaces/jwt-token-interface';

@Injectable({
  providedIn: 'root',
})
export class AdminAuthService {
  constructor(
    private httpClient: HttpClient,
    private jwtTokenService: JwtTokenService
  ) {}

  register(admin: Admin) {
    return this.httpClient.post<Admin>(environment.apiUrl + '/Admin', admin);
  }

  login(admin: Admin): Observable<JwtToken> {
    return this.httpClient
      .post<JwtToken>(environment.apiUrl + '/Admin/auth', admin)
      .pipe(
        tap((jwtToken) => {
          this.jwtTokenService.setToken(jwtToken.acessToken);
        })
      );
  }

  logOut() {
    this.jwtTokenService.removeToken();
  }

  adminIsLogged(): boolean {
    return !!this.jwtTokenService.getToken();
  }
}
