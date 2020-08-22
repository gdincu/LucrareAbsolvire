import { Component, OnInit } from '@angular/core';
import { IChargingPoint } from '../shared/models/chargingPoint';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  chargingPoints: IChargingPoint[];

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.shopService.getChargingPoints().subscribe(response => {
      this.chargingPoints = response.data;
    },
      error => {
        console.log(error);
      }
    );
  }

}
