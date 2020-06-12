import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';
import {Router} from '@angular/router';
@Component({
  selector: 'app-sofa-detail',
  templateUrl: './sofa-detail.component.html',
  styleUrls: ['./sofa-detail.component.css']
})

export class SofaDetailComponent implements OnInit {
  public productId:number;
  public product:any;
  content = {
    quantity: 1
  };
  public formatter = new Intl.NumberFormat('de-DE', {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits:0
  })
  constructor(private route:ActivatedRoute, private router:Router, http:HttpClient, @Inject('BASE_URL') baseUrl:string)
  { 
      //this.productId = parseInt(this.route.snapshot.params['productId']);
      //console.log(this.productId);
      this.productId = JSON.parse(localStorage.getItem("productId"));
      let x = {
          id: this.productId,
          keyword: ""
      }
      http.post('https://tconcept.azurewebsites.net/api/Products/get-product-by-id', x).subscribe(result=>{
        this.product=result;
        ///console.log(this.product);
      },err=>console.log(err))
  }

  handleAddProduct(productId){
    localStorage.setItem("quantity",JSON.stringify(this.content.quantity));
    setTimeout(()=>{
      this.router.navigateByUrl('/login');
    },1000)
  } 
  
  ngOnInit() {
  }

}
