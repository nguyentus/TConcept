import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;
@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrls: ['./product-management.component.css']
})
export class ProductManagementComponent{
  path: any = 'https://tconcept.azurewebsites.net/api/Products/search-products';
  size: number = 10;
  products: any={
    data:[],
    page: 0,
    size: this.size,
    totalPages: 0,
    totalRecord: 0,
  };
  isEdit: boolean = false;

  product ={
    productId: 0,
    productName: "",
    categoryName: "",
    categoryId: "0",
    height: "0",
    width: "0",
    length: "0",
    material: "",
    color: "",
    price: "0",
    stock: "0",
    image: "",
    notes: "",
  };
  list: any
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.searchProduct(1);
    // let x ={
    //   page:1,
    //   size: this.size,
    //   keyword:""
    // };
    // http.post('https://tconcept.azurewebsites.net/api/Products/search-products', x).subscribe(result => {
    //   console.log(result);
    //   this.list = result;
    //   console.log(this.list)
    // }, error => console.error(error));
  }
  

  searchProduct(cPage)
  {
    let x ={
      page:cPage,
      size: this.size,
      keyword:""
    };
    this.http.post(this.path, x).subscribe(result => {
      var res: any = result;
      if(res.success)
      {
        this.products = res.data;
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error)
      alert(error);
    });
  }

  searchNext()
  {
    if( this.products.page < this.products.totalPages)
    {
      let nextPage = this.products.page + 1;
      let x ={
        page:nextPage,
        size:this.size,
        keyword:""
      };
      this.http.post(this.path, x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
        console.log(this.products);
      }, error => console.error(error));
    }
    else
    {
      alert("Bạn đang ở trang cuối");
    }
  }
  searchPrevious()
  {
    if( this.products.page > 1)
    {
      let nextPage = this.products.page - 1;
      let x ={
        page:nextPage,
        size:this.size,
        keyword:""
      };
      this.http.post(this.path, x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
        console.log(this.products);
      }, error => console.error(error));
    }
    else
    {
      alert("Bạn đang ở trang đầu");
    }
  }

  openModal(isEdit, index)
  {
    this.isEdit = isEdit;
    if(isEdit)
    {
      var item = this.products.data[index];
      this.product = {
        productId: item.productId,
        productName: item.productName,
        categoryId: item.categoryId.toString(),
        categoryName: item.categoryName,
        height: item.height,
        width: item.width,
        length: item.length,
        material: item.material,
        color: item.color,
        price: item.price,
        stock: item.stock.toString(),
        image: item.image,
        notes: item.notes
      };
    }
    $('#modalProduct').modal('show');
  }

  createProduct()
  {
    var x = {
      productId: 0,
      productName: this.product.productName,
      categoryId: parseInt(this.product.categoryId),
      categoryName: this.product.categoryName,
      height: parseFloat(this.product.height),
      width: parseFloat(this.product.width),
      length: parseFloat(this.product.length),
      material: this.product.material,
      color: this.product.color,
      price: parseFloat(this.product.price),
      stock: parseInt(this.product.stock),
      image: this.product.image,
      notes: this.product.notes
    };
    this.http.post(this.path, x).subscribe(result => {
      var res: any = result;
      if(res.success)
      {
        this.products = res.data;
        this.isEdit = true;
        this.searchProduct(1);
        alert("New product has been added! Now you can modified! ");
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error)
      alert(error);
    });
  }

  saveProduct()
  {
    var x = {
      productId: this.product.productId,
      productName: this.product.productName,
      categoryId: parseInt(this.product.categoryId),
      categoryName: this.product.categoryName,
      height: parseFloat(this.product.height),
      width: parseFloat(this.product.width),
      length: parseFloat(this.product.length),
      material: this.product.material,
      color: this.product.color,
      price: parseFloat(this.product.price),
      stock: parseInt(this.product.stock),
      image: this.product.image,
      notes: this.product.notes
    };
    this.http.post(this.path, x).subscribe(result => {
      var res: any = result;
      if(res.success)
      {
        this.products = res.data;
        this.searchProduct(1);
        alert("A product has been updated successfully");
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error)
      alert(error);
    });
  }
}
