import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";
import { AuthService } from '../auth.service';
import { AuthGuard } from '../auth.guard';

declare var $: any;

@Component({
  selector: 'app-chose-hotel',
  templateUrl: './chose-hotel.component.html',
  styleUrls: ['./chose-hotel.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})
export class ChoseHotelComponent {
  private defaultURL: String = "https://localhost:44359/api";
  //Biến nhận và gửi dữ liệu qua URL
  bookingInfo: any = {
    destination: "",
    checkInDate: "",
    checkOutDate: "",
    nightsAmount: 0,
    hotelId: "",
  }
  //Biến nhận
  private roomOfHotelResult: [];
  private hotel: any = {
    hotelID: null,
    hotelName: null,
    quality: null,
    hotelCreatedDate: null,
    hotelPhoneNumber: null,
    hotelEmail: null,
    street: null,
    ward: null,
    district: null,
    province: null,
    country: null,
    image: null,
    hotelDescription: null,
    hotelStatus: null,
    rank: null,
    hotelPaymentMethods: null,
    partnerID: null,
    hotelNote: null,
  }
  //Biến xử lí
  priceAfterDiscountList = new Array(); //Dùng array không dùng list thuần
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router
    , private auth: AuthService, private guard: AuthGuard, private route?: ActivatedRoute) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    //this.autoMoveImage(); //Đưa hàm tự động chuyển ảnh lên constructor
    //Nếu gửi theo params thì phải get như thế này
    this.route.queryParams.subscribe(params => {
      this.bookingInfo.destination = params["destination"];
      this.bookingInfo.checkInDate = params["from"];
      this.bookingInfo.checkOutDate = params["to"];
      this.bookingInfo.nightsAmount = params["night"];
      this.bookingInfo.hotelId = params["hotelid"];
      //Gọi API để tìm room of hotel sau khi get được dữ liệu
      this.searchRoomOfHotel();
      this.searchHotelByHotelId();

    });
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Khách sạn");
  }
  //API
  searchHotelByHotelId() {
    this.http.get<any>(this.defaultURL + '/Hotel/search-hotel-by-hotel-id' +
      '?hotelId=' + this.bookingInfo.hotelId).subscribe(
        result => {
          var res: any = result;
          this.hotel = res.data; //Result sẽ có đủ dữ liệu
          console.log(res);
        },
        error => {
          alert("Server error!!")
        });
  }
  searchRoomOfHotel() {
    this.http.get<any>(this.defaultURL + '/RoomOfHotel/search-room-of-hotel-by-hotel-id' +
      '?hotelId=' + this.bookingInfo.hotelId).subscribe(
        result => {
          var res: any = result;
          this.roomOfHotelResult = res.data; //Result sẽ có đủ dữ liệu
          var index = 0;
          //Tính giá sau khi giảm
          for (let data in res.data) {
            // this.priceAfterDiscount.push(parseFloat(res.data[index].roomPriceForNight * (1 - res.data[index].discount));
            this.priceAfterDiscountList.push(parseFloat(res.data[index].roomPriceForNight) * (1 - parseFloat(res.data[index].discount))).toString();
          }
          console.log(res);
        },
        error => {
          alert("Server error!!")
        });

  }
  choiceThisHotel(roomOfHotelId: String) {
    this.router.navigate(['/fill-in-information'],
      {
        queryParams: {
            customerid: this.guard.getUserName, //Lấy username sau khi đã xác thực đăng nhập
            destination: this.bookingInfo.destination,
            from: this.bookingInfo.checkInDate,
            to: this.bookingInfo.checkOutDate,
            night: this.bookingInfo.nightsAmount,
            hotelid: this.bookingInfo.hotelId,
            roomid: roomOfHotelId
        }
      });
  }
  //Các hàm image slide show
  autoMoveImage() {
    // $('.carousel').carousel({
    //     interval: 1500
    //   })
  }
  //Các hàm khác
  counter(i: number) {
    return new Array(i);
  }
}