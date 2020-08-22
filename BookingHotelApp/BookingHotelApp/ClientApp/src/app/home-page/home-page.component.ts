import { Component, Inject, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";
import { DatePipe } from '@angular/common';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'], //Dùng file css ở đây, không dùng ở thẻ <head>
  providers: [DatePipe]
})
export class HomePageComponent implements AfterViewInit {
  private defaultURL: String = "https://localhost:44359/api";
  ngAfterViewInit() {
    //(document.getElementById("myDate") as HTMLInputElement).value = this.nowDate;
  }
  today: String;
  tomorrow: String;
  
  //Biến gửi dữ liệu
  bookingInfo: any={
    destination: "Đà Lạt",
    checkInDate: "",
    checkOutDate: "",
    nightsAmount: 1
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router, private datePipe: DatePipe,
    private auth: AuthService) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
   
    this.filterDateToInput(); //Filter date đúng định dạng để đưa lên thẻ input
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Trang chủ");
  }
  searchHotel() {
    this.router.navigate(['/search-hotel'],
     { queryParams: {
       destination: this.bookingInfo.destination,
       from: this.bookingInfo.checkInDate,
       to: this.bookingInfo.checkOutDate,
       night: this.bookingInfo.nightsAmount,
    }});
  }
 
  //Các hàm xử lí khác
  filterDateToInput(){        
    let tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    this.bookingInfo.checkOutDate = this.datePipe.transform(tomorrow, 'yyyy-MM-dd');
    this.bookingInfo.checkInDate=this.datePipe.transform(new Date(), 'yyyy-MM-dd');
 }
}