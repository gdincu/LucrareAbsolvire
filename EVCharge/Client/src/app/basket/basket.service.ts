import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { IBasket, IBasketItem, Basket, IBasketTotals } from '../shared/models/basket';
import { map } from 'rxjs/operators';
import { IChargingPoint } from '../shared/models/chargingPoint';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl = 'https://localhost:44374/api/';
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          console.log(basket);
          //this.calculateTotals();
        })
      );
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const total = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    this.basketTotalSource.next({ total });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  setBasket(basket: IBasket) {
    return this.http.post(this.baseUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
      //this.calculateTotals();
    }, error => {
      console.log(error);
    });
  }

  addItemToBasket(chargingPoint: IChargingPoint, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(chargingPoint, quantity);
    let basket = this.getCurrentBasketValue();
    if (basket === null) basket = this.createBasket();
    basket.items= new Array<IBasketItem>();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }
 
  private mapProductItemToBasketItem(item: IChargingPoint, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.productName,
      price: item.price,
      start: item.start,
      end: item.end,
      photoUrl: item.photoUrl,
      location: item.location,
      quantity,
      type: item.type
    };
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  removeItemFromBasket(item: IBasketItem) {
    const basket = this.createBasket();
    if (basket.items.some(x => x.id === item.id)) {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteLocalBasket(id: string) {
    this.basketSource.next(null);
    localStorage.removeItem('basket_id');
  }

  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    });
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    //const index = 0;
    itemToAdd.quantity = quantity;
    items.push(itemToAdd);

    return items;
  }
 
 }
