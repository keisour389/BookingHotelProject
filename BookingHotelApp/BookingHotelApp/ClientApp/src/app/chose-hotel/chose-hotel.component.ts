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
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
        , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
        this.setTitle(); //Đưa lên phương thức khởi tạo

        //this.autoMoveImage(); //Đưa hàm tự động chuyển ảnh lên constructor
    }
    //Title phải set ở đây, không được set trong thẻ <title>
    public setTitle() {
        this.titleService.setTitle("Khách sạn");
    }
    //Các hàm image slide show
    autoMoveImage()
    {
        // $('.carousel').carousel({
        //     interval: 1500
        //   })
    }
   
}