import { Component, OnInit, Input } from '@angular/core';
import { IChargingPoint } from '../../shared/models/chargingPoint';

@Component({
  selector: 'app-chargingpoint-item',
  templateUrl: './chargingpoint-item.component.html',
  styleUrls: ['./chargingpoint-item.component.css']
})
export class ChargingpointItemComponent implements OnInit {
  @Input() chargingPoint: IChargingPoint;

  constructor() { }

  ngOnInit() {
  }

}
