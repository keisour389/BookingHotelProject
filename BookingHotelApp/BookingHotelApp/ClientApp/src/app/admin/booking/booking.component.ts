import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/service/booking.service';

declare const $: any;

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  startDate!: string;
  endDate!: string;
  isDataResponseUndefined: boolean = true;
  dataResponse!: any;
  selectedStatus: string = 'Chờ duyệt';
  bookingStatus: Array<string> = ['Chờ duyệt', 'Đã tiếp nhận'];
  dataIndex: any = {
    bookingID: null,
    bookingDate: null,
    bookingStatus: null,
    customerPaymentMethods: null,
    checkInDate: null,
    checkOutDate: null,
    totalPrice: null,
    customerID: null,
    employeeID: null,
    bookingNote: null,
    customerName: null
  };

  constructor(private datePipe: DatePipe, private bookingService: BookingService) { }

  getOrderByHotelIdAndBookingDate(hotelId: string, startDate: string, endDate: string): void {
    this.bookingService.getOrderByBookingDate(hotelId, startDate, endDate).subscribe(
      result => {
        let res: any = result;
        if (res.success) {
          this.dataResponse = res;
          console.log(this.dataResponse);
          //This moment system can get data from response
          this.isDataResponseUndefined = false;
        }
        else {
          console.error("Response error.");
        }
      },
      error => {
        console.error("Server error.")
      }
    );
  }

  cancelBookingOfCus(index: number): void {
    let check: any = confirm('Bạn chắc chắn muốn hủy phòng này?');
    if (check) {
      //Set status of booking
      this.dataIndex.bookingStatus = 'Đã hủy';
      this.dataIndex.checkInDate = new Date(this.dataIndex.checkInDate).toJSON();
      this.dataIndex.checkOutDate = new Date(this.dataIndex.checkOutDate).toJSON();
      this.dataIndex.bookingDate = new Date(this.dataIndex.bookingDate).toJSON();
      console.log(this.dataResponse.data[index])
      this.bookingService.updateBookingOfCus(this.dataResponse.data[index]).subscribe(
        result => {
          let res: any = result;
          if (res.success) {
            alert('Hủy phòng thành công');
          }
          else {
            console.error("Response error.");
          }
        },
        error => {
          console.error("Server error.")
        }
      );
    }
  }

  approveBookingOfCus(): void {
    //Set status of booking
    this.dataIndex.bookingStatus = 'Đã tiếp nhận';
    this.dataIndex.checkInDate = new Date(this.dataIndex.checkInDate).toJSON();
    this.dataIndex.checkOutDate = new Date(this.dataIndex.checkOutDate).toJSON();
    this.dataIndex.bookingDate = new Date(this.dataIndex.bookingDate).toJSON();
    this.bookingService.updateBookingOfCus(this.dataIndex).subscribe(
      result => {
        let res: any = result;
        if (res.success) {
          //Close modal
          this.closeUserInformationModal();
          alert('Duyệt phòng thành công');
        }
        else {
          console.error("Response error.");
        }
      },
      error => {
        console.error("Server error.")
      }
    );
  }

  onSubmit(): void {
    console.log(this.startDate);
    this.getOrderByHotelIdAndBookingDate('RHDL', this.startDate, this.endDate);
  }

  //offset is the numbers will be increase from today
  createTodayString(offset: number): string {
    let date = new Date();
    date.setDate(date.getDate() + offset);
    if (date.getMonth() + 1 < 10) {
      if (date.getDate() < 10) {
        return date.getFullYear() + '-0' + (date.getMonth() + 1) + '-0' + date.getDate();
      }
      return date.getFullYear() + '-0' + (date.getMonth() + 1) + '-' + date.getDate();
    }
    else {
      if (date.getDate() < 10) {
        return date.getFullYear() + '-' + (date.getMonth() + 1) + '-0' + date.getDate();
      }
      return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();
    }

  }
  openUserInformationModal(index: number): void {
    $('#userInfoModal').modal('show');
    this.dataIndex = this.dataResponse.data[index];
    //parse date
    this.dataIndex.bookingDate = this.datePipe.transform(this.dataIndex.bookingDate, 'yyyy-MM-dd');
    this.dataIndex.checkInDate = this.datePipe.transform(this.dataIndex.checkInDate, 'yyyy-MM-dd');
    this.dataIndex.checkOutDate = this.datePipe.transform(this.dataIndex.checkOutDate, 'yyyy-MM-dd');
  }

  closeUserInformationModal(): void {
    $('#userInfoModal').modal('toggle');
  }

  ngOnInit() {
    //Set default date
    this.startDate = this.createTodayString(-7);
    this.endDate = this.createTodayString(1);
    this.isDataResponseUndefined = this.dataResponse !== 'undefined' ? true : false;
    this.getOrderByHotelIdAndBookingDate('RHDL', this.startDate, this.endDate);
  }

}
