import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-search-hotel',
  templateUrl: './search-hotel.component.html',
  styleUrls: ['./search-hotel.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})
export class SearchHotelComponent {
  //Các biến phân trang
  //Mặc định
  size: number = 20;
  page: number = 1;
  keyWord: String = "";
  //Biến lưu danh sách hotel
  //Các biến giống tên với file JSON
  hotels: any={
    data: [],
    page: 0,
    size: 0,
    totalPages: 0,
    totalRecords: 0,
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
    , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
    this.setTitle(); //Đưa lên phương thức khởi tạo
    var res = this.route.snapshot.paramMap.get('result'); //Lấy dữ liệu truyền qua
    this.searchHotel(); //Gọi API để tìm hotel
  }

  //Title phải set ở đây, không được set trong thẻ <title>
  public setTitle() {
    this.titleService.setTitle("Tìm phòng");
  }
  searchHotel() {
    this.http.get<any>('https://localhost:44359/api/Hotel/search-hotel-pagination/' +
      this.size + ',' + this.page + '?keyWord=' + this.keyWord).subscribe(
        result => {
          var res: any = result;
          this.hotels = res; //Hotels sẽ có đủ dữ liệu
          console.log(this.hotels);
        },
        error => {
          alert("Server error!!")
        });
  }
}