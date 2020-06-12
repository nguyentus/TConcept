import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  account = {
    userName: "",
    userPassword: ""
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router:Router) {
    
  }

  loginAccount(){
    let x : any = {
      userName: this.account.userName,
      userPassword: this.account.userPassword
    };
    this.http.post('https://tconcept.azurewebsites.net/api/Customers/get-id-login', x).subscribe(result => {
      var res: any = result;
      if (res.customerID != null) {
        //this.products = res.data;
        console.log(res.customerID)
        localStorage.setItem("customerId",JSON.stringify(res.customerID));
        this.router.navigateByUrl('/confirm-order');
        alert("Đăng nhập thành công!");
      }
      else {
        alert("Đăng nhập thất bại, tài khoản hoặc mật khẩu chưa đúng!");
      }
    }, error => {
      console.error(error)
      alert("Đăng nhập thất bại!");
    });
  }

  ngOnInit(){
  }

}
