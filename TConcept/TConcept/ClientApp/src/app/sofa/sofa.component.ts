import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-sofa',
  templateUrl: './sofa.component.html',
  styleUrls: ['./sofa.component.css']
})
export class SofaComponent implements OnInit {
  listSofa: any={
    data: []
  };

  public formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits:0
  })
  public result:any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.loadProduct();
  }

  
  loadProduct(){
    //Tất cả sản phẩm   
    this.http.post('https://eatenapi.azurewebsites.net/api/Posts/get-all-post-info',null).subscribe(res=>{
      this.listSofa=res;
      this.listSofa=this.listSofa.data;
    },err=>console.log(err));
  }

  // handleOnClickTheme=(id)=>{
  //   //console.log(id);
  //   this._router.navigate(['/flower-by-theme/theme',id])
  // }
  // handleClickProduct=(idProduct)=>{
  //   console.log(idProduct)
  //   this._router.navigate(['/product-detail',idProduct])
  // }


  ngOnInit() {
    
  }
}

