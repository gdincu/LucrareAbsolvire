import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IChargingPoint } from './models/chargingPoint';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'EVCharge';
  chargingPoints: IChargingPoint[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:44374/api/chargingpoints?pageSize=3').subscribe((response: IPagination) => {
      this.chargingPoints = response.data;
    }, error => {
        console.log(error);
    });
  }

}
