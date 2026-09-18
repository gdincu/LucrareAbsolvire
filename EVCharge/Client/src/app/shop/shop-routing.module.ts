import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ChargingPointDetailsComponent } from './charging-point-details/charging-point-details.component';

const routes: Routes = [
  { path: '', component: ShopComponent },
  { path: ':id', component: ChargingPointDetailsComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
