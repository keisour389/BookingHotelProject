import { Component, Inject, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";
import { DatePipe } from '@angular/common';
import { AuthService } from '../auth.service';
import { state } from '@angular/animations';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'], //Dùng file css ở đây, không dùng ở thẻ <head>
  providers: [DatePipe]
})
export class HomePageComponent implements AfterViewInit {

  ngAfterViewInit() {
    //(document.getElementById("myDate") as HTMLInputElement).value = this.nowDate;
  }
  today: String;
  tomorrow: String;
  
  //Biến gửi dữ liệu
  bookingInfo: any={
    destination: "Đà Lạt",
    checkinDate: "",
    checkoutDate: "",
    peopleAmount: 0,
    nightsAmount: 0
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
    // this.http.get<any>('https://localhost:44359/api/Account/had-login').subscribe(
    //     result => {
    //       var res: any = result;
    //       if (res.success) {
    //         //this.router.navigate(['/search-hotel', { search: this.bookingInfo.destination }]);
    //         console.log(res);
    //       }
    //       else{
    //         if(!res.login){
    //           this.router.navigate(['/login']).then(e => {
    //             if(e){
    //               console.log("Navigation is successful!");
    //             }
    //             else{
    //               console.log("Navigation has failed!");
    //             }
    //           });
    //         }
    //       }
    //     },
    //     error => {
    //       alert("Server error!!")
    //     });
    // this.auth.getUserDetails().subscribe(
    //     data => {
    //       if(data.success){
    //         this.auth.setLoggedIn(true);
    //         this.router.navigate(['/search-hotel', { search: this.bookingInfo.destination }]);
    //         console.log("Logged In");
    //       }
    //       else{
    //         this.router.navigate(['/login', {queryParams:{returnURL: this.router.url}}]); //Trả về theo URL hiện tại
    //         console.log("Not Logged In");
    //       }
         
    //     });
    //window.location.href="./search-hotel";//Chuyển trang

    this.router.navigate(['/search-hotel', { search: this.bookingInfo.destination }]);
    // this.auth.getUserDetails().subscribe(
    //     data => {
    //       console.log("data " + data.success);
    //       if(data.success){
    //         this.auth.setLoggedIn(true);
    //         this.router.navigate(['/search-hotel', { search: this.bookingInfo.destination }]);
    //       }
    //       else{
    //         this.router.navigate(['/login'], {queryParams: {returnUrl: this.router.url}});
    //       }
          
    //     });
  }
  //Các hàm xử lí khác
  filterDateToInput(){        
    let tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    this.tomorrow = this.datePipe.transform(tomorrow, 'yyyy-MM-dd');
    this.today=this.datePipe.transform(new Date(), 'yyyy-MM-dd');
 }
}