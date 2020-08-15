import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-search-hotel',
  templateUrl: './search-hotel.component.html',
  styleUrls: ['./search-hotel.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})
export class SearchHotelComponent {
  //Biến nhận dữ liệu
  bookingInfo: any = {
    destination: "",
    checkinDate: "",
    checkoutDate: "",
    peopleAmount: 0,
    nightsAmount: 0
  }
  //Biến lưu danh sách hotel
  //Các biến giống tên với file JSON
  hotelSearchResult: [];
  // hotelSearchResult: any={
  //   discount: 0,
  //   hotelAddress: "",
  //   hotelCountry: "",
  //   hotelId: "",
  //   hotelImage: "",
  //   hotelName: "",
  //   quality: "",
  //   rank: "",
  //   roomPriceForNight: 0
  // }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    this.bookingInfo.destination = this.route.snapshot.paramMap.get('search'); //Lấy dữ liệu truyền qua
    this.searchHotel(); //Gọi API để tìm hotel
  }

  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Tìm phòng");
  }
  searchHotel() {
    this.http.get<any>('https://localhost:44359/api/RoomOfHotel/customer-search-room-by-keyword/' +
      '?keyWord=' + this.bookingInfo.destination).subscribe(
        result => {
          var res: any = result;
          if (res.success) {
            this.hotelSearchResult = res.data; //Result sẽ có đủ dữ liệu
            console.log(res);
          }
          else{
            console.log("failed");
            // if(!res.login){
            //   this.router.navigate(['/login']).then(e => {
            //     if(e){
            //       console.log("Navigation is successful!");
            //     }
            //     else{
            //       console.log("Navigation has failed!");
            //     }
            //   });
            // }
          }
        },
        error => {
          alert("Server error!!")
        });
  }
  //Các hàm khác
  addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
      x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
  }
}