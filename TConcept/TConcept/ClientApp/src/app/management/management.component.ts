import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;
@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.css']
})
export class ManagementComponent {

  path: any = 'https://thetconcept.azurewebsites.net/api/Products/search-products';
  size: number = 5;
  products: any = {
    data: [],
    page: 0,
    size: this.size,
    totalPages: 0,
    totalRecord: 0,
  };
  isEdit: boolean = false;
  product = {
    productId: 0,
    productName: "",
    categoryId: "",
    height: "",
    width: "",
    length: "",
    material: "",
    color: "",
    price: "",
    stock: "",
    image: "",
    notes: ""
  };
  public formatter = new Intl.NumberFormat('de-DE', {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits:0
  })
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.searchProduct(1);
  }

  searchProduct(cPage) {
    let x = {
      page: cPage,
      size: this.size,
      keyword: ""
    };
    this.http.post(this.path, x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        console.log(res)
        this.products = res.data;
        // console.log(this.products)
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error)
      alert(error);
    });
  }
  searchNext() {
    if (this.products.page < this.products.totalPages) {
      let nextPage = this.products.page + 1;
      let x = {
        page: nextPage,
        size: this.size,
        keyword: ""
      };
      this.http.post(this.path, x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
        console.log(this.products);
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang cuối");
    }
  }
  searchPrevious() {
    if (this.products.page > 1) {
      let nextPage = this.products.page - 1;
      let x = {
        page: nextPage,
        size: this.size,
        keyword: ""
      };
      this.http.post(this.path, x).subscribe(result => {
        this.products = result;
        this.products = this.products.data;
        console.log(this.products);
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang đầu");
    }
  }
  openModal(isEdit, index) {
    this.isEdit = isEdit;
    if (isEdit) {
      var item = this.products.data[index];
      this.product = {
        productId: item.productId,
        productName: item.productName,
        categoryId: item.categoryId.toString(),
        height: item.height,
        width: item.width,
        length: item.length,
        material: item.material,
        color: item.color,
        price: item.price,
        stock: item.stock,
        image: item.image,
        notes: item.notes
      };
    }
    $('#modalProduct').modal('show');
  }
  createProduct() {
    var x = {
      productId: 0,
      productName: this.product.productName,
      categoryId: parseInt(this.product.categoryId),
      height: parseFloat(this.product.height),
      width: parseFloat(this.product.width),
      length: parseInt(this.product.length),
      material: this.product.material,
      color: this.product.color,
      price: parseFloat(this.product.price),
      stock: parseInt(this.product.stock),
      image: this.product.image,
      notes: this.product.notes
    };
    this.http.post('https://thetconcept.azurewebsites.net/api/Products/create-product', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.products = res.data;
        this.isEdit = true;
        this.searchProduct(1);
        alert("Thêm mới một sản phẩm thành công!");
        $('#modalProduct').modal('hide');
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error)
      alert(error);
    });
  }
  saveProduct() {
    var x = {
      productId: this.product.productId,
      productName: this.product.productName,
      categoryId: parseInt(this.product.categoryId),
      height: parseFloat(this.product.height),
      width: parseFloat(this.product.width),
      length: parseInt(this.product.length),
      material: this.product.material,
      color: this.product.color,
      price: parseFloat(this.product.price),
      stock: parseInt(this.product.stock),
      image: this.product.image,
      notes: this.product.notes
    };
    this.http.post('https://thetconcept.azurewebsites.net/api/Products/update-product', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.products = res.data;
        this.searchProduct(1);
        alert("Sản phẩm đã được cập nhật thành công!");
        $('#modalProduct').modal('hide');
      }
      else {
        alert(res.message);
      }
    }, error => {
      console.error(error)
      alert(error);
    });
  }
  deleteProduct(id){
    let x: any = {
      id: id,
      keyword: ""
    }
    this.http.post('https://thetconcept.azurewebsites.net/api/Products/delete-product-by-id', x).subscribe(result => {
        var res : any = result
        if (res.success) {
          this.products = res.data;
          this.searchProduct(1);
          alert("Sản phẩm đã được xóa thành công!");
        }
        else {
          alert(res.message);
        }
      });
      console.log(id)
    }
}
