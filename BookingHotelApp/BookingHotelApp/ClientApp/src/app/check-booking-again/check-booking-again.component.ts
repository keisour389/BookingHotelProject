import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";
import { DatePipe } from '@angular/common';

declare var $: any;

@Component({
  selector: 'app-check-booking-again',
  templateUrl: './check-booking-again.component.html',
  styleUrls: ['./check-booking-again.component.css'],
  providers: [DatePipe]
})
export class CheckBookingAgainComponent {
  date: Date = new Date();
  //Biến lấy từ cookie
  specialRequirements: "Yêu cầu đặc biệt";
  //Các biến tính toán
  discountPrice = 0;
  priceAfterDiscount = 0;
  policyApplyList: any;
  policyNotApplyList: any;
  //Biến nhận từ URL
  customerId = "0902725706";
  roomOfHotelId = "TR";
  nightAmount = 1;
  checkInDate = "2020-08-18";
  checkOutDate = "2020-08-19";
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
  private setValueToBooking() {
    this.booking.customerName = this.customer.lastName + " " + this.customer.firstName;
    this.booking.checkInDate = this.parseTimeStringToTimeJSON(this.checkInDate);
    this.booking.checkOutDate = this.parseTimeStringToTimeJSON(this.checkOutDate);
    this.booking.totalPrice = this.priceAfterDiscount;
    this.booking.customerID = this.customerId;
    this.booking.employeeID = null;
    this.booking.note = null;
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
  booking: any = {
    //bookingID: 0, //Khóa chính tự động tăng
    bookingDate: this.date.toJSON(), //Ngày hôm nay
    bookingStatus: "Chờ duyệt", //Mặc định
    customerName: null,
    customerPaymentMethods: "Thanh toán trực tuyến", //Tạm thời chưa thể làm phương thức khác
    checkInDate: null,
    checkOutDate: null,
    totalPrice: 0,
    customerID: null,
    employeeID: null,
    bookingNote: null
  }
  private setValueToBookingDetails(bookingId: Number) {
    //Set mã đặt phòng sau khi tạo booking và nhận được response 
    this.bookingDetails.bookingID = bookingId;
    this.bookingDetails.roomOfHotelID = this.roomOfHotel.roomOfHotelID;
    this.bookingDetails.nightAmount = this.nightAmount;
    this.bookingDetails.price = this.priceAfterDiscount;
    this.bookingDetails.specialRequirements = this.specialRequirements;
  }
  bookingDetails: any = {
    bookingID: null,
    roomOfHotelID: null,
    nightAmount: 0,
    price: 0,
    specialRequirements: null
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router, private datePipe: DatePipe) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    this.getCustomerInfoById();
    this.getRoomOfHotelById();
  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Kiểm tra lại");
  }
  public getCustomerInfoById() {
    this.http.get<any>('https://localhost:44359/api/Customer?customerId=' + this.customerId)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.customer = res.data; //Gán dữ liệu để hiển thị
          console.log(this.customer);
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
    this.http.get<any>('https://localhost:44359/api/RoomOfHotel/search-room-by-id?roomOfHotelId='
      + this.roomOfHotelId)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.roomOfHotel = res.data; //Gán dữ liệu để hiển thị
          console.log(this.roomOfHotel);
          //Tính số tiền được giảm và giá khi giảm
          this.discountPrice = this.roomOfHotel.discount * this.roomOfHotel.roomPriceForNight;
          this.priceAfterDiscount = this.roomOfHotel.roomPriceForNight - this.discountPrice;
          //Split policy ra
          // this.policyApplyList = this.splitStringToArray(this.roomOfHotel.policyApply);
          // this.policyNotApplyList = this.splitStringToArray(this.roomOfHotel.policyNotApply);
        }
        else {
          console.log("Client error!!");
        }

      },
        error => {
          alert("Server error!!");
        });
  }
  public createCustomerBooking() {
    //Gán giá trị trước khi tạo
    this.setValueToBooking();
    this.http.post('https://localhost:44359/api/Booking/create-booking', this.booking)
      .subscribe(result => {
        var res: any = result;
        if (res.success) {
          console.log(res);
          //Tiếp tục tạo Booking Details
          //Gán giá trị trước khi tạo
          this.setValueToBookingDetails(res.data.bookingID);
          this.http.post('https://localhost:44359/api/BookingDetails/create-booking-details', this.bookingDetails)
            .subscribe(result => {
              var res: any = result;
              if (res.success) {
                console.log(res);
                alert("Chúc mừng bạn đã đặt phòng thành công");
              }
              else {
                console.log("Booking details client error!!");
              }

            },
              error => {
                console.log("Booking details server error!!");
              });
        }
        else {
          console.log("Booking client error!!");
        }

      },
        error => {
          console.log("Booking server error!!");
        });
  }
  //Các hàm khác
  private parseTimeStringToTimeJSON(timeString: string) {
    var dateString = this.datePipe.transform(timeString, 'yyyy-MM-dd');
    var date = new Date(dateString);
    return date.toJSON();
  }

  //Modal Bootstrap
  openConformBookingModal() {
    $('#comform-booking-modal').modal('show');
  }
}
