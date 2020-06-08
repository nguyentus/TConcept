import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-custom',
  templateUrl: './custom.component.html',
  styleUrls: ['./custom.component.css']
})
export class CustomComponent implements OnInit {

  [x: string]: any;

  public products: any={
    data:[]
  };

  public categories: any=[];

  public product: any={
    "productId": 0,
        "productName": "",
        "categoryId": 0,
        "supplierId": 0,
        "quantityPerUnit": "",
        "unitPrice": 0
  };

  public isEdit: boolean = true;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   
  }

  ngOnInit() {
    console.log("init");
    this.searchProduct(1);
    this.loadCategoryName();
  }
  
  searchProduct(cPage){
    let x = {
      page:cPage,
      size:8,
      keyword:""
    }
    this.http.post('http://localhost:5000/' + 'api/Products/search-product', x).subscribe(result => {
      this.products = result;
      this.products = this.products.data;
    }, error => console.error(error));
  }
  
  loadCategoryName(){
    this.http.post<Categories>('https://eatenapi.azurewebsites.net/api/FoodCategories/get-all', null).subscribe(result => {
      this.categories = result.data;
    }, error => console.error(error));
  }

  searchNext(){
    if(this.products.pageNumber < this.products.totalPages){
      let nextPage = this.products.pageNumber + 1;
      let x = {
        page:nextPage,
        size:8,
        keyword:""
      }
      this.http.post('http://localhost:5000/' + 'api/Products/search-product', x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
        console.log(this.products);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious(){
    if(this.products.pageNumber > 1){
      let nextPage = this.products.pageNumber - 1;
      let x = {
        page:nextPage,
        size:8,
        keyword:""
      }
      this.http.post('http://localhost:5000/' + 'api/Products/search-product', x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
        console.log(this.products);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang đầu tiên!");
    }
  }

  openModal(isNew, index){
    if(isNew){
      this.isEdit = false;      
      this.product = {
        "productId": 0,
        "productName": "",
        "categoryId": 0,
        "supplierId": 0,
        "quantityPerUnit": "",
        "unitPrice": 0
      }
    }
    else{
      this.isEdit = true;
      this.product = index;
    }
    $('#exampleModal').modal("show");
  }

  addProduct(){
    var x = this.product;
    //Convert x.categoryId to integer value
    x.categoryId = +x.categoryId;

    this.http.post('http://localhost:5000/' + 'api/Products/create-product', x).subscribe(result => {
        var res:any = result;
        if(res.success){
          $('#exampleModal').modal("hide");
          alert("New product have been added successfully!")
        }  
      }, error => console.error(error));
      this.searchProduct(1);  
  }

  updateProduct(){
    var x = this.product;
    //Convert x.categoryId to integer value
    x.categoryId = +x.categoryId;

    this.http.post('http://localhost:5000/' + 'api/Products/update-product', x).subscribe(result => {
        var res:any = result;
        if(res.success){
          $('#exampleModal').modal("hide");           
          alert("Product has been changed!");
        }        
      }, error => console.error(error));
      this.searchProduct(1);
  }

  deleteProduct(){
    var x = this.product;
    this.http.post('http://localhost:5000/' + 'api/Products/delete-product', x).subscribe(result => {
        var res:any = result;
        if(res.success){
          $('#exampleModal').modal("hide");    
          alert("Product has been deleted!");
        }        
      }, error => console.error(error));

      setTimeout(()=>{ 
        this.searchProduct(1);
   }, 3000);
  }

}

interface Categories {
  data: Object;
}