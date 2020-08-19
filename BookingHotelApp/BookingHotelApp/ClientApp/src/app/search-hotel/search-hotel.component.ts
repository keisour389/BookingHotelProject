import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-search-hotel',
  templateUrl: './search-hotel.component.html',
  styleUrls: ['./search-hotel.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})
export class SearchHotelComponent {
  //Biến nhận và gửi dữ liệu qua URL
  bookingInfo: any = {
    destination: "",
    checkInDate: "",
    checkOutDate: "",
    nightsAmount: 0,
    hotelId: "",
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
    , private titleService: Title, private router: Router,  private auth: AuthService,
    private route?: ActivatedRoute) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    //Nếu gửi theo params thì phải get như thế này
    this.route.queryParams.subscribe(params => {
      this.bookingInfo.destination = params["destination"];
      this.bookingInfo.checkInDate = params["from"];
      this.bookingInfo.checkOutDate = params["to"];
      this.bookingInfo.nightsAmount = params["night"];
      console.log(this.bookingInfo.destination);
      this.searchHotel(); //Gọi API để tìm hotel sau khi get được dữ liệu
    });
    // this.bookingInfo.destination = this.route.snapshot.paramMap.get('search'); //Lấy dữ liệu truyền qua
    
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
          else {
            console.log("failed");
          }
        },
        error => {
          alert("Server error!!")
        });
  }
  choiceHotel(hotelId: String){
    //Gán mã khách sạn khi click vào
    this.bookingInfo.hotelId = hotelId;
    console.log(this.bookingInfo.hotelId);
    this.router.navigate(['/chose-hotel'],
     { queryParams: {
       destination: this.bookingInfo.destination,
       from: this.bookingInfo.checkInDate,
       to: this.bookingInfo.checkOutDate,
       night: this.bookingInfo.nightsAmount,
       hotelid: this.bookingInfo.hotelId
    }});
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