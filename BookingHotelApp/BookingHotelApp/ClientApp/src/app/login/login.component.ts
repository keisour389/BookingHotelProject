import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'] //Dùng file css ở đây, không dùng ở thẻ <head>
})

export class LoginComponent {
    private data: any ={
        username: "",
        password: "",
    }
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
        , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
        this.setTitle(); //Đưa lên phương thức khởi tạo
    }

    //Title phải set ở đây, không được set trong thẻ <title>
    public setTitle() {
        this.titleService.setTitle("Đăng nhập");
    }

    public validateUser(){
        this.http.post('https://localhost:44359/api/CusAccount/validate-user', this.data)
        .subscribe(result =>{
            var res: any = result;
            if(res.success){
                alert("Bạn đã đăng nhập thành công.");
                this.router.navigate(['/']); //Quay về trang chủ
            }
            else{
                alert("Tài khoản hoặc mật khẩu bị sai.");
            }
           
        },
        error =>{
            alert("Server error!!");
        });
    }
}