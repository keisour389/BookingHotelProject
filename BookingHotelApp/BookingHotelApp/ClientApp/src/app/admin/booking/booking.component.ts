import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/service/booking.service';

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

  constructor(private bookingService: BookingService) { }

  getOrderByHotelIdAndBookingDate(hotelId: string, startDate: string, endDate: string): void {
    this.bookingService.getOrderByBookingDate(hotelId, startDate, endDate).subscribe(
      result => {
        let res: any = result;
        if(res.success){
          this.dataResponse = res;
          console.log(this.dataResponse);
          //This moment system can get data from response
          this.isDataResponseUndefined = false;
        }
        else{
          console.error("Response error.");
        }
      },
      error => {
        console.error("Server error.")
      }
    );
  }

  onSubmit(): void{
    console.log(this.startDate);
    this.getOrderByHotelIdAndBookingDate('RHDL', this.startDate, this.endDate);
  }

  //offset is the numbers will be increase from today
  createTodayString(offset: number): string{
    let date = new Date();
    date.setDate(date.getDate() + offset);
    if(date.getMonth() + 1 < 10){
      return date.getFullYear() + '-0' + (date.getMonth() + 1) + '-' + date.getDate();
    }
    else{
      return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); 
    }
    
  }

  ngOnInit() {
    //Set default date
    this.startDate = this.createTodayString(0);
    console.log(this.startDate)
    this.endDate = this.createTodayString(1);
    this.isDataResponseUndefined = this.dataResponse !== 'undefined' ? true : false;
    this.getOrderByHotelIdAndBookingDate('RHDL', this.startDate, this.endDate);
  }

}
