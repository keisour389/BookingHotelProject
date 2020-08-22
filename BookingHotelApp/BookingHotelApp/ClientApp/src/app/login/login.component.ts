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
    private defaultURL: String = "https://localhost:44359/api";

    returnUrl: string;
    private data: any ={
        username: "0902725706",
        password: "123456789",
    }
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
        , private titleService: Title, private router: Router, private route?: ActivatedRoute) {
        this.setTitle(); //Đưa lên phương thức khởi tạo
        //Nếu gửi theo params thì phải get như thế này
        this.route.queryParams.subscribe(params =>{
            this.returnUrl = params["returnUrl"];
            console.log(params);
        });

    }

    //Title phải set ở đây, không được set trong thẻ <title>
    public setTitle() {
        this.titleService.setTitle("Đăng nhập");
    }

    public validateUser(){
        this.http.post(this.defaultURL + '/CusAccount/validate-user', this.data)
        .subscribe(result =>{
            var res: any = result;
            if(res.data != null){
                alert("Bạn đã đăng nhập thành công.");
                //this.router.navigate(['/']); //Quay về trang chủ
                //Không get được params do đăng kí từ trang chủ
                if(this.returnUrl == null){
                    window.location.href = '/';
                } 
                else{
                    window.location.href = this.returnUrl;
                }   
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