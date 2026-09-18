import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { ILocation } from '../shared/models/location';
import { IType } from '../shared/models/type';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IChargingPoint } from '../shared/models/chargingPoint';

//Decorated with the Injectable decorator
@Injectable({
  //So that it is provided in the app module and initialised when the app starts
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:44374/api/';
  shopParams = new ShopParams();

  constructor(private http: HttpClient) { }

  //Method to return charging points
  getChargingPoints(shopParams: ShopParams) {
    let params = new HttpParams();
    

    if (shopParams.locationId != 0) params = params.append('locationId', shopParams.locationId.toString());
    if (shopParams.typeId != 0) params = params.append('typeId', shopParams.typeId.toString());
    if (shopParams.search) params = params.append('search', shopParams.search);    

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'chargingpoints', { observe: 'response', params })
      .pipe(map(response => {
          return response.body;
        }));
  }

  getChargingPoint(id: number) {
    return this.http.get<IChargingPoint>(this.baseUrl + 'chargingpoints/' + id);
  }

  getChargingPointLocations() {
    return this.http.get<ILocation[]>(this.baseUrl + 'chargingpoints/locations');
  }

  getChargingPointTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'chargingpoints/types');
  }

  getShopParams() {
    return this.shopParams;
  }
}
