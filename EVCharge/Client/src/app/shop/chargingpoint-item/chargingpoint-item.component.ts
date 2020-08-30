import { Component, OnInit, Input } from '@angular/core';
import { IChargingPoint } from '../../shared/models/chargingPoint';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-chargingpoint-item',
  templateUrl: './chargingpoint-item.component.html',
  styleUrls: ['./chargingpoint-item.component.css']
})
export class ChargingpointItemComponent implements OnInit {
  @Input() chargingPoint: IChargingPoint;

  constructor(private basketService: BasketService) { }

  ngOnInit() { }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.chargingPoint);
  }

}
