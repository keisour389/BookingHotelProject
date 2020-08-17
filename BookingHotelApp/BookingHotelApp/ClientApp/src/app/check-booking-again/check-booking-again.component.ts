import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";

@Component({
  selector: 'app-check-booking-again',
  templateUrl: './check-booking-again.component.html',
  styleUrls: ['./check-booking-again.component.css']
})
export class CheckBookingAgainComponent {

  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Kiểm tra lại");
  }

}