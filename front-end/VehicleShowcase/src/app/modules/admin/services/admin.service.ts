import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Admin } from '../interfaces/admin-interface';

import { JwtTokenService } from '../../core/services/jwt-token.service';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  constructor(
    private httpClient: HttpClient,
    private jwtTokenService: JwtTokenService
  ) {}

  getAdmin(id: number): Observable<Admin> {
    return this.httpClient.get<Admin>(environment.apiUrl + '/Admin/' + id, {
      headers: this.jwtTokenService.getAuthHeader(),
    });
  }

  addAdmin(newAdmin: Admin): Observable<Admin> {
    return this.httpClient.post<Admin>(environment.apiUrl + '/Admin', newAdmin);
  }

  updateAdmin(id: number, newAdmin: Admin): Observable<Admin> {
    return this.httpClient.put<Admin>(environment.apiUrl + '/Admin/' + id, newAdmin, {
      headers: this.jwtTokenService.getAuthHeader(),
    });
  }

  deleteAdmin(id: number): Observable<Admin> {
    return this.httpClient.delete<Admin>(environment.apiUrl + '/Admin/' + id, {
      headers: this.jwtTokenService.getAuthHeader(),
    });
  }

}