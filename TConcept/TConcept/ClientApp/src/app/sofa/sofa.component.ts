import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-sofa',
  templateUrl: './sofa.component.html',
  styleUrls: ['./sofa.component.css']
})
export class SofaComponent implements OnInit {
  listProduct: any;

  public formatter = new Intl.NumberFormat('de-DE', {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits:0
  })
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router:Router) {
    this.loadProduct();
  }

  loadProduct(){
    //Tất cả sản phẩm   
    this.http.post('https://thetconcept.azurewebsites.net/api/Products/get-all-products-by-stored',null).subscribe(result=>{
      this.listProduct = result;
    },err=>console.log(err));
  }

  handleClickProduct(productId){
    localStorage.setItem("productId",JSON.stringify(productId));
    this.router.navigateByUrl('/sofa-detail');
    //this.router.navigateByUrl(`/sofa-detail/${productId}`)
  }

  ngOnInit() {
    
  }
}

