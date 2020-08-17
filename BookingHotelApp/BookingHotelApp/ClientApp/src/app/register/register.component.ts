import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router } from "@angular/router";
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'], //Dùng file css ở đây, không dùng ở thẻ <head>
    providers: [DatePipe]
})

export class RegisterComponent {
    //Biến này map với ngModel
    phoneNumber: String = "";
    password: "";
    passwordConfirm: "";
    birthDay: "";

    date: Date = new Date();
    checkPassword: Boolean; //Hàm này để kiểm tra phần mật khẩu giống nhau
    genderSelect:any = [
        {
            genderName: "Nam",
            genderValue: "Nam"
        },
        {
            genderName: "Nữ",
            genderValue: "Nữ"
        },
        {
            genderName: "Khác",
            genderValue: "Khác"
        }
    ]
    private customerAccount: any = {
        phoneNumber: null,
        password: null,
        accountType: "Khách hàng", //Mặc định
        accountCreatedDate: this.date.toJSON(), //Biến thời gian hiện tại được Parse sang JSON
        accountStatus: "Bình thường",
        note: null
    }

    private customerInfo: any = {
        phoneNumber: null,
        lastName: null,
        firstName: null,
        cusBirthDay: null,
        cusEmail: null,
        cusGender: "Nam", //Set mặc định là nam trong option
        cusType: "1",
        cusNote: null
    }
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string
        , private titleService: Title, private router: Router, private datePipe: DatePipe) {
        this.setTitle(); //Đưa lên phương thức khởi tạo
    }
    //Title phải set ở đây, không được set trong thẻ <title>
    public setTitle() {
        this.titleService.setTitle("Đăng kí");
    }
    checkUserExist(username: String) {
        //Trả về file JSON
        return this.http.get<any>('https://localhost:44359/api/Customer/check-account-exist/' + username);
    }
    createNewCustomer() {
        //Gán lại giá trị sau khi Phone Number được nhập từ input
        this.customerAccount.phoneNumber = this.phoneNumber;
        this.customerInfo.phoneNumber = this.phoneNumber;
        //Gán lại giá trị ngày sinh sau khi được nhập từ input
        this.customerInfo.cusBirthDay = this.parseTimeStringToTimeJSON(this.birthDay), //Biến birthDay sẽ nhận giá trị từ ngModel sau đó sẽ parse về JSON
        //Xác nhận mật khẩu
        this.checkPassword = this.confirmPasswordSuccess();
        console.log(this.checkPassword);
        //Nếu xác nhận mật khẩu đúng thì mới gửi API, không thì xuất thông báo ở HTML
        if (this.checkPassword) {
            //Gửi API
            this.http.get<any>('https://localhost:44359/api/Customer/check-account-exist/' + this.phoneNumber).subscribe(
                result => {
                    var res: any = result;
                    if (res.exist) {
                        alert("Tài khoản này đã tồn tại");
                    }
                    else {
                        //Tạo bảng account trước
                        this.http.post('https://localhost:44359/api/CusAccount/create-account', this.customerAccount).subscribe(
                            result => {
                                var res: any = result;
                                if (res.success) {
                                    //Nếu tạo tài khoản thành công sẽ tiếp tục tạo thông tin
                                    this.http.post('https://localhost:44359/api/Customer/create-customer', this.customerInfo).subscribe(
                                        result => {
                                            var res: any = result;
                                            if (res.success) {
                                                alert("Chúc mừng bạn đã tạo tài khoản thành công");
                                                this.router.navigate(['/']);
                                            }
                                            else {
                                                console.log("Lỗi tạo thông tin trong API");
                                            }
                                        },
                                        error => {
                                            alert("Lỗi tạo thông tin khác");
                                        });
                                }
                                else {
                                    console.log("Lỗi tạo tài khoản trong API");
                                }
                            },
                            error => {
                                alert("Lỗi tạo tài khoản khác");
                            });
                    }
                },
                error => {
                    alert("Lỗi kiểm tra tài khoản khác");
                }
            );
        }


    }
    //Các hàm khác
    private parseTimeStringToTimeJSON(timeString: string) {
        var dateString = this.datePipe.transform(timeString, 'yyyy-MM-dd');
        var date = new Date(dateString);
        return date.toJSON();
    }
    private confirmPasswordSuccess() {
        if (this.password == this.passwordConfirm) {
            this.customerAccount.password = this.password; //Khi xác nhận thành công sẽ gán vào file JSON
            return true;
        }
        else {
            return false;
        }
    }
}