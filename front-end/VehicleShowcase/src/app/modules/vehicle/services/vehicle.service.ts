import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Vehicle } from '../interfaces/vehicle-interface';
import { JwtTokenService } from '../../core/services/jwt-token.service';

@Injectable({
  providedIn: 'root',
})
export class VehicleService {
  constructor(
    private httpClient: HttpClient,
    private jwtTokenService: JwtTokenService
  ) {}

  getVehicle(id: number): Observable<Vehicle> {
    return this.httpClient.get<Vehicle>(environment.apiUrl + '/Vehicle/' + id);
  }

  getAllVehiclesOrderedByPrice(): Observable<Vehicle[]> {
    return this.httpClient.get<Vehicle[]>(environment.apiUrl + '/Vehicle/ordered-by-price');
  }
  
  getAllVehiclesOrderedDescending(): Observable<Vehicle[]> {
    return this.httpClient.get<Vehicle[]>(environment.apiUrl + '/Vehicle/ordered-by-descending');
  }

  addVehicle(newVehicle: Vehicle): Observable<Vehicle> {
    return this.httpClient.post<Vehicle>(environment.apiUrl + '/Vehicle', newVehicle, {
      headers: this.jwtTokenService.getAuthHeader(),
    });
  }

  updateVehicle(id: number, newVehicle: Vehicle): Observable<Vehicle> {
    return this.httpClient.put<Vehicle>(environment.apiUrl + '/Vehicle/' + id, newVehicle, {
      headers: this.jwtTokenService.getAuthHeader(),
    });
  }

  deleteVehicle(id: number): Observable<Vehicle> {
    return this.httpClient.delete<Vehicle>(environment.apiUrl + '/Vehicle/' + id, {
      headers: this.jwtTokenService.getAuthHeader(),
    });
  }
}