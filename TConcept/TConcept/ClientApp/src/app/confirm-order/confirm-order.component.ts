import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';
import {Router} from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-confirm-order',
  templateUrl: './confirm-order.component.html',
  styleUrls: ['./confirm-order.component.css']
})
export class ConfirmOrderComponent implements OnInit {
  public productId:number;
  public customerId:number;
  public quantity:number;
  public product:any;
  public customer:any;
  notes = {
    content: ""
  };
  public formatter = new Intl.NumberFormat('de-DE', {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits:0
  })
  constructor(private route:ActivatedRoute, private router:Router, private http:HttpClient, @Inject('BASE_URL') baseUrl:string)
  { 
    setTimeout(()=>{
      this.loadProduct();
    },1000);

    setTimeout(()=>{
      this.loadCustomer();
    },1000);
  }

  loadProduct(){
    //Load thông tin sản phẩm mua
    this.productId = JSON.parse(localStorage.getItem("productId"));
    //Load số lượng sản phẩm
    this.quantity = JSON.parse(localStorage.getItem("quantity"));
    let x = {
        id: this.productId,
        keyword: ""
    }
    this.http.post('https://tconcept.azurewebsites.net/api/Products/get-product-by-id', x).subscribe(result=>{
      this.product=result;
    },err=>console.log(err))
  }

  loadCustomer(){
    //Load thông tin người mua
    this.customerId = JSON.parse(localStorage.getItem("customerId"));
    console.log(this.customerId)
    let y = {
      id: this.customerId,
      keyword: ""
    }
    this.http.post('https://tconcept.azurewebsites.net/api/Customers/get-by-id', y).subscribe(result=>{
      var res: any = result;
      this.customer = res.data;
  },err=>console.log(err))
  }

  confirmOrder(){
    let pipe = new DatePipe('en-US');
    const now = Date.now();
    const myFormattedDate = pipe.transform(now, 'yyyy-dd-mm');

    let z : any = {
      customerId: JSON.parse(localStorage.getItem("customerId")),
      notes: this.notes.content,
      productId: JSON.parse(localStorage.getItem("productId")),
      quantity: this.quantity,
    };
    console.log(z);
    this.http.post('https://tconcept.azurewebsites.net/api/Orders/create-order', z).subscribe(result => {
      var res: any = result;
      if (res.success) {
        alert("Đơn hàng của bạn đã đặt thành công, chúng tôi sẽ giao hàng sớm nhất!");
        setTimeout(()=>{
          this.router.navigateByUrl('/home');
        },2000)
      }
      else {
        alert("Mua hàng thất bại!");
      }
    }, error => {
      console.error(error)
      alert("Mua hàng thất bại!");
    });
  }

  ngOnInit() {
  }

}
