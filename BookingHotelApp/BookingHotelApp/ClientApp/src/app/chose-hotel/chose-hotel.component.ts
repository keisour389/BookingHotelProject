import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";

declare var $: any;

@Component({
    selector: 'app-chose-hotel',
    templateUrl: './chose-hotel.component.html',
    styleUrls: ['./chose-hotel.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})
export class ChoseHotelComponent {
    //Biến gửi
    private hotelId: String = "ATTICA";
    //Biến nhận
    private roomOfHotelResult: [];
    // private roomOfHotel: any = {
    //     roomID: ""
    //     hotelID: "",
    //     image: "",
    //     peopleAmount: 0,
    //     roomAmount: 0,
    //     bedAmount: 0,
    //     policyApply: "",
    //     policyNotApply: "",
    //     discount: 0,
    //     roomOfHotelNote: "",
    //     roomPriceForNight: 0,
    //     roomsCreatedDate: "",
    // }
    //Biến xử lí
    priceAfterDiscountList = new Array(); //Dùng array không dùng list thuần
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
        , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
        this.setTitle(); //Đưa lên phương thức khởi tạo

        this.searchRoomOfHotel();
        //this.autoMoveImage(); //Đưa hàm tự động chuyển ảnh lên constructor
    }
    //Title phải set ở đây, không được set trong thẻ <title>
    public setTitle() {
        this.titleService.setTitle("Khách sạn");
    }
    //API
    searchRoomOfHotel() {
        this.http.get<any>('https://localhost:44359/api/RoomOfHotel/search-room-of-hotel-by-id' +
          '?hotelId=' + this.hotelId).subscribe(
            result => {
              var res: any = result;
              this.roomOfHotelResult = res.data; //Result sẽ có đủ dữ liệu
              var index = 0;
              //Tính giá sau khi giảm
              for(let data in res.data)
              {
                // this.priceAfterDiscount.push(parseFloat(res.data[index].roomPriceForNight * (1 - res.data[index].discount));
                this.priceAfterDiscountList.push(parseFloat(res.data[index].roomPriceForNight) * (1 - parseFloat(res.data[index].discount))).toString();
              }
              console.log(this.priceAfterDiscount);
              console.log(res);
            },
            error => {
              alert("Server error!!")
            });
      }
    //Các hàm image slide show
    autoMoveImage()
    {
        // $('.carousel').carousel({
        //     interval: 1500
        //   })
    }
    //Các hàm khác
   
}