import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";


@Component({
  selector: 'app-booking-history',
  templateUrl: './booking-history.component.html',
  styleUrls: ['./booking-history.component.css']
})
export class BookingHistoryComponent {
  private defaultURL: String = "https://localhost:44359/api";

  customerId: String = "0902725706";

  customerDetails: any = {
    phoneNumber: null,
    cusAccount: null,
    lastName: null,
    firstName: null,
    cusBirthDay: null,
    cusEmail: null,
    cusGender: null,
    cusType: null,
    cusNote: null,
  }

  bookingDetailsList: any = [];

  bookingDetails: any = {
    bookingID: null,
    bookingDate: null,
    bookingStatus: null,
    customerPaymentMethods: null,
    checkInDate: null,
    checkOutDate: null,
    totalPrice: 0,
    customerName: null,
    customerID: null,
    roomOfHotelID: null,
    nightAmount: 0,
    price: 0,
    specialRequirements: null,
    roomName: null,
    bedAmount: 0,
    peopleAmount: 0,
    checkInTime: null,
    checkOutTime: null,
    hotelID: null,
    hotelName: null
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    this.getCustomerBookingHistory();

  }
  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Lịch sử đặt phòng");
  }
  public getCustomerBookingHistory() {
    this.http.get<any>(this.defaultURL + '/Customer/customer-booking-history' +
      '?customerId=' + this.customerId).subscribe(
        result => {
          var res: any = result;
          if (res.success) {
            this.customerDetails = res.data.customerDetails;
            this.bookingDetailsList = res.data.bookingDetails;
          }
          else {
            console.error("Get history error !!")
          }
        },
        error => {
          alert("Server error!!")
        });
  }

}
