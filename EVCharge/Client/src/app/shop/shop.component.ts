import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IChargingPoint } from '../shared/models/chargingPoint';
import { ShopService } from './shop.service';
import { IType } from '../shared/models/type';
import { ILocation } from '../shared/models/location';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: true }) searchValue: ElementRef;
  chargingPoints: IChargingPoint[];
  types: IType[];
  locations: ILocation[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getChargingPoints();
    this.getLocations();
    this.getTypes();
  }

  getChargingPoints() {
    this.shopService.getChargingPoints(this.shopParams).subscribe(response => {
      this.chargingPoints = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
       console.log(error);
      });
  }

  getTypes() {
    this.shopService.getChargingPointTypes().subscribe(response => {
      this.types = [{id: 0, name: 'All'}, ...response];
    }, error => {
        console.log(error);
      });
  }

  getLocations() {
    this.shopService.getChargingPointLocations().subscribe(response => {
      this.locations = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getChargingPoints();
  }

  onLocationSelected(locationId: number) {
    this.shopParams.locationId = locationId;
    this.shopParams.pageNumber = 1;
    this.getChargingPoints();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.shopParams.pageNumber = 1;
    this.getChargingPoints
  }

  onPageChanged(event: any) {
    const params = this.shopService.getShopParams();
    if (params.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.shopParams.pageNumber = 1;
      this.getChargingPoints();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchValue.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getChargingPoints();
  }

  onReset() {
    this.searchValue.nativeElement.value = '';
    this.shopParams.pageNumber = 1;
    this.shopParams = new ShopParams;
    this.getChargingPoints();
  } 
}
