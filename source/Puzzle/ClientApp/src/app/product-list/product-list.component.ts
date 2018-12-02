import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  public products: Product[];
  public selectedProduct:Product;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'api/product/list').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  onSelect(prod: Product): void {
    this.selectedProduct = prod;
  }
}

