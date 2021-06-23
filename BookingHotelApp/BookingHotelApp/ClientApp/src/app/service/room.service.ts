import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const defaultUrl = "https://localhost:44359/api/RoomOfHotel";

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private http: HttpClient) { }

  getRoomByHotelId(hotelId: string): Observable<any> {
    return this.http.get<any>(defaultUrl + '/search-room-of-hotel-by-hotel-id?hotelId=' + hotelId);
  }
}
