import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';

//Decorated with the Injectable decorator
@Injectable({
  //So that it is provided in the app module and initialised when the app starts
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:44374/api/';

  constructor(private http: HttpClient) { }

  //Method to return charging points
  getChargingPoints() {
    return this.http.get<IPagination>(this.baseUrl + 'chargingpoints');
  }
}
