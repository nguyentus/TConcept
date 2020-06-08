import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})


export class ProductComponent implements OnInit {
  public list: any={
    data: []
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post('https://eatenapi.azurewebsites.net/api/Posts/get-all-post-info', null).subscribe(result => {
    this.list = result;
    this.list = this.list.data;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
