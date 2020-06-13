import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;

@Component({
  selector: 'app-order-management',
  templateUrl: './order-management.component.html',
  styleUrls: ['./order-management.component.css']
})

export class OrderManagementComponent {
  path: any = 'https://tconcept.azurewebsites.net/api/Orders/search-orders';
  size: number = 9;
  content = {
    keyword: ""
  }
  
  orders: any = {
    data: [],
    page: 0,
    size: this.size,
    totalPages: 0,
    totalRecord: 0,
  };
  isEdit: boolean = false;
  order = {
    orderId: 0,
    fullName: "",
    productName: "",
    orderDate: "",
    address: "",
    notes: "",
    price: 0
  };
  public formatter = new Intl.NumberFormat('de-DE', {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits:0
  })
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.searchOrder(1);
  }

  searchOrder(cPage) {
    let x = {
      page: cPage,
      size: this.size,
      keyword: this.content.keyword
    };
    this.http.post(this.path, x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        console.log(res)
        this.orders = res.data;
        // console.log(this.orders)
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
    if (this.orders.page < this.orders.totalPages) {
      let nextPage = this.orders.page + 1;
      let x = {
        page: nextPage,
        size: this.size,
        keyword: ""
      };
      this.http.post(this.path, x).subscribe(result => {
        this.orders = result;
        this.orders = this.orders.data;
        console.log(this.orders);
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang cuối");
    }
  }
  searchPrevious() {
    if (this.orders.page > 1) {
      let previousPage = this.orders.page - 1;
      let x = {
        page: previousPage,
        size: this.size,
        keyword: ""
      };
      this.http.post(this.path, x).subscribe(result => {
        this.orders = result;
        this.orders = this.orders.data;
        console.log(this.orders);
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang đầu");
    }
  }
  openModal(isEdit, index) {
    this.isEdit = isEdit;
    if (isEdit) {
      var item = this.orders.data[index];
      this.order = {
        orderId: item.orderId,
        fullName: item.fullName,
        productName: item.productName,
        orderDate: item.orderDate,
        address: item.address,
        notes: item.notes,
        price: item.price
      };
    }
    $('#modalOrder').modal('show');
  }
  deleteOrder(id){
    let x: any = {
      id: id,
      keyword: ""
    }
      this.http.post('https://tconcept.azurewebsites.net/api/Orders/delete-order', x).subscribe(result => {
        var res : any = result
        if (res.success) {
          this.orders = res.data;
          alert("Đơn hàng đã được xóa thành công!");
          this.searchOrder(1);
        }
        else {
          alert(res.message);
        }
      });
      console.log(id)
    }

    ngOnInit(){
      setTimeout(
        function(){ 
        location.reload(); 
        }, 30000);
    }
}
