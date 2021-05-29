import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const defaultUrl = "https://localhost:44359/api/Booking";

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) {}

  //Start date and end date use format yyyy-MM-dd
  getOrderByBookingDate(hotelId: string, startDate: string, endDate: String): Observable<any>{
    return this.http.get<any>(defaultUrl + "/search-by-booking-date?hotelId=" + hotelId
     + "&startDate=" + startDate + "&endDate=" + endDate);
  }
}