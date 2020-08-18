import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";

@Component({
  selector: 'app-fill-in-information',
  templateUrl: './fill-in-information.component.html',
  styleUrls: ['./fill-in-information.component.css']
})
export class FillInInformationComponent {
  //Các biến tính toán
  discountPrice = 0;
  priceAfterDiscount = 0;
  policyApplyList: any;
  policyNotApplyList: any;
  //Các biến sẽ nhận được từ URL truyền qua
  customerId = "string";
  roomOfHotelId = "string";
  nightAmount = 1;
  checkInDate = "18/08/2020";
  checkOutDate = "19/08/2020";

  fullNameToContact = null;
  fullNameOfCus = null;
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
    , private titleService: Title, private router: Router) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    this.getCustomerInfoById();
    this.getRoomOfHotelById();
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Điền thông tin");
  }

  public getCustomerInfoById() {
    this.http.get<any>('https://localhost:44359/api/Customer?customerId=' + this.customerId)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.customer = res.data; //Gán dữ liệu để hiển thị
          console.log(this.customer);
          //Ghép thành họ tên đầy đủ
          //Ban đầu sẽ mặc định tên khách và tên người liên hệ là giống nhau
          this.fullNameToContact = this.customer.lastName + " " + this.customer.firstName;
          this.fullNameOfCus = this.customer.lastName + " " + this.customer.firstName;
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
    this.http.get<any>('https://localhost:44359/api/RoomOfHotel/search-room-by-id?roomOfHotelId=' + this.roomOfHotelId)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.roomOfHotel = res.data; //Gán dữ liệu để hiển thị
          console.log(this.roomOfHotel);
          //Tính số tiền được giảm và giá khi giảm
          this.discountPrice = this.roomOfHotel.discount * this.roomOfHotel.roomPriceForNight;
          this.priceAfterDiscount = this.roomOfHotel.roomPriceForNight - this.discountPrice;
          //Split policy ra
          this.policyApplyList = this.splitStringToArray(this.roomOfHotel.policyApply);
          this.policyNotApplyList = this.splitStringToArray(this.roomOfHotel.policyNotApply);
        }
        else {
          console.log("Client error!!");
        }

      },
        error => {
          alert("Server error!!");
        });
  }
  //Các hàm khác
  private splitStringToArray(stringToSplit: String){
    try{
      var result = stringToSplit.split(','); //Cách theo dấu phẩy
      console.log(result);
      return result;
    }
    catch{
      return stringToSplit; //Không thể split
    }
  }

}
