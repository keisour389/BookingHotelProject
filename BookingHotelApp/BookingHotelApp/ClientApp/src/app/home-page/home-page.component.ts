import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})
export class HomePageComponent {

  bookingInfo: any={
    destination: "Đà Lạt",
    checkinDate: "",
    checkoutDate: "",
    peopleAmount: 0,
    nightsAmount: 0
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Trang chủ");
  }
  searchHotel() {
    this.router.navigate(['/search-hotel', { search: this.bookingInfo.destination }]);
    //window.location.href="./search-hotel";//Chuyển trang
  }
}