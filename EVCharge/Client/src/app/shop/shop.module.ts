import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ChargingpointItemComponent } from './chargingpoint-item/chargingpoint-item.component';



@NgModule({
  declarations: [ShopComponent, ChargingpointItemComponent],
  imports: [
    CommonModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
