import uuid from 'uuid/v4';

export interface IBasket {
  id: string;
  items: IBasketItem[];
}

export interface IBasketItem {
  id: number;
  productName: string;
  price: number;
  start: Date;
  end: Date;
  quantity: number;
  photoUrl: string;
  location: string;
  type: string;
}

export class Basket implements IBasket {
  id = uuid();
  items: IBasketItem[] = [];
}

export interface IBasketTotals {
  total: number;
}
