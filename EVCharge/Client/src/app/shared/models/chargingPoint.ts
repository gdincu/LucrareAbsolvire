export interface IChargingPoint {
  id: number;
  productName: string;
  price: number;
  start: Date;
  end: Date;
  photoUrl: string;
  location: string;
  type: string;
}
