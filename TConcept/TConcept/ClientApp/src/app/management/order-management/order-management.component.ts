import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-order-management',
  templateUrl: './order-management.component.html'
})
export class OrderManagementComponent {
  lstOrder: any

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.post('https://localhost:44356/api/Products/get-all-products-by-stored', null).subscribe(result => {
      var res :any = result;
      this.lstOrder = res.data;
      console.log(result);
    }, error => console.error(error));
  }
}
