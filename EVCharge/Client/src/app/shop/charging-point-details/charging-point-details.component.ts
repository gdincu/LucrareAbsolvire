import { Component, OnInit } from '@angular/core';
import { IChargingPoint } from '../../shared/models/chargingPoint';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-charging-point-details',
  templateUrl: './charging-point-details.component.html',
  styleUrls: ['./charging-point-details.component.css']
})
export class ChargingPointDetailsComponent implements OnInit {
  chargingPoint: IChargingPoint;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.loadChargingPoint();
  }

  loadChargingPoint() {
    this.shopService.getChargingPoint(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(chargingPoint => {
      this.chargingPoint = chargingPoint;
    }, error => {
      console.log(error);
    });
  }

}
