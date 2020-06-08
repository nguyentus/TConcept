import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html'
})
export class ProductManagementComponent {
  lstPro: any

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.post('https://localhost:44356/api/Products/get-all-products-by-stored', null).subscribe(result => {
      var res :any = result;
      this.lstPro = res.data;
      console.log(result);
    }, error => console.error(error));
  }
}
