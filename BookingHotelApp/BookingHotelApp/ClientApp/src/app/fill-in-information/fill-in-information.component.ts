import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-fill-in-information',
  templateUrl: './fill-in-information.component.html',
  styleUrls: ['./fill-in-information.component.css']
})
export class FillInInformationComponent {
  private defaultURL: String = "https://localhost:44359/api";

  //Các biến tính toán
  discountPrice = 0;
  priceAfterDiscount = 0;
  policyApplyList: any;
  policyNotApplyList: any;
  //Các biến sẽ nhận được từ URL truyền qua
  bookingInfo: any = {
    customerId: "",
    destination: "",
    checkInDate: "",
    checkOutDate: "",
    nightsAmount: 0,
    hotelId: "",
    roomOfHotelId: ""
  }
  // customerId = "string";
  // roomOfHotelId = "string";
  // nightAmount = 1;
  // checkInDate = "18/08/2020";
  // checkOutDate = "19/08/2020";
  fullNameToContact = "";
  fullNameOfCus = "";
  //Biến nhận dữ liệu từ JSON
  customer: any = {
    phoneNumber: null,
    lastName: null,
    firstName: null,
    cusBirthDay: null,
    cusEmail: null,
    cusGender: null,
    cusType: null,
    cusNote: null,
  }
  roomOfHotel: any = {
    roomOfHotelID: null,
    roomName: null,
    roomAmount: 0,
    bedAmount: 0,
    peopleAmount: 0,
    policyApply: null,
    policyNotApply: null,
    checkInTime: null,
    checkOutTime: null,
    roomPriceForNight: 0,
    discount: 0,
    hotelName: null,
    image: null
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router, private auth: AuthService,
    private route?: ActivatedRoute) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    //Nếu gửi theo params thì phải get như thế này
    this.auth.getUserDetails().toPromise().then(
      data => {
        if (data.success) {
          this.bookingInfo.customerId = data.username; //Có customerId mới get được
          this.getCustomerInfoById();
        }
        else {
          console.error("Get customer session error in fill form");
        }
      });
    this.route.queryParams.subscribe(params => {
      this.bookingInfo.destination = params["destination"];
      this.bookingInfo.checkInDate = params["from"];
      this.bookingInfo.checkOutDate = params["to"];
      this.bookingInfo.nightsAmount = params["night"];
      this.bookingInfo.hotelId = params["hotelid"];
      this.bookingInfo.roomOfHotelId = params["roomid"];
      //Gọi API để tìm room of hotel sau khi get được dữ liệu
    });
    this.getRoomOfHotelById();
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Điền thông tin");
  }

  public getCustomerInfoById() {
    this.http.get<any>(this.defaultURL + '/Customer?customerId=' + this.bookingInfo.customerId)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.customer = res.data; //Gán dữ liệu để hiển thị
          console.log(this.customer);
          //Ghép thành họ tên đầy đủ
          //Ban đầu sẽ mặc định tên khách và tên người liên hệ là giống nhau
          try {
            this.fullNameToContact = this.customer.lastName + " " + this.customer.firstName;
            this.fullNameOfCus = this.customer.lastName + " " + this.customer.firstName;
          }
          catch{
            this.fullNameToContact = "";
            this.fullNameOfCus = "";
            console.error("Can't not get fullname of cus and contact in fill");
          }
        }
        else {
          console.log("Client error!!");
        }

      },
        error => {
          alert("Server error!!");
        });
  }
  public getRoomOfHotelById() {
    this.http.get<any>(this.defaultURL + '/RoomOfHotel/search-room-by-id?roomOfHotelId='
      + this.bookingInfo.roomOfHotelId)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.roomOfHotel = res.data; //Gán dữ liệu để hiển thị
          console.log(this.roomOfHotel);
          //Tính số tiền được giảm và giá khi giảm
          try {
            this.discountPrice = this.roomOfHotel.discount * this.roomOfHotel.roomPriceForNight;
            this.priceAfterDiscount = this.roomOfHotel.roomPriceForNight - this.discountPrice;
          }
          catch{
            this.discountPrice = 0;
            this.priceAfterDiscount = 0;
            console.error("Can't not get price after discount in fill");
          }
          //Split policy ra
          //Đã kiểm tra lỗi trong hàm
          try {
            this.policyApplyList = this.splitStringToArray(this.roomOfHotel.policyApply);
            this.policyNotApplyList = this.splitStringToArray(this.roomOfHotel.policyNotApply);
          }
          catch{
            this.policyApplyList = "";
            this.policyNotApplyList = "";
            console.error("Can't not get policy in fill");
          }

        }
        else {
          console.log("Client error!!");
        }

      },
        error => {
          alert("Server error!!");
        });
  }
  public comformInfo() {
    this.router.navigate(['/check-booking-again'],
      {
        queryParams: {
          customerid: this.bookingInfo.customerId,
          destination: this.bookingInfo.destination,
          from: this.bookingInfo.checkInDate,
          to: this.bookingInfo.checkOutDate,
          night: this.bookingInfo.nightsAmount,
          hotelid: this.bookingInfo.hotelId,
          roomid: this.bookingInfo.roomOfHotelId
        }
      });
  }
  //Các hàm khác
  private splitStringToArray(stringToSplit: String) {
    try {
      var result = stringToSplit.split(','); //Cách theo dấu phẩy
      console.log(result);
      return result;
    }
    catch{
      return stringToSplit; //Không thể split
    }
  }

}
