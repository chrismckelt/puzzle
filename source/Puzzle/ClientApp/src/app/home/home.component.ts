import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../shared/api.service';
import { CurrencyRateType } from './../models/currencyratetype';
import { Customer } from '../models/customer';
import { Product } from '../models/product';
import { Order } from '../models/order';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public api:ApiService;
  public products: Product[];
  public selectedProducts:Product[];
  public customer:Customer;
  public order:Order;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.api = new ApiService(this.http,this.baseUrl);
    this.api.listProducts()
    .subscribe(result => {
      this.products = result;
    }, error => console.error(error));

    this.customer = new Customer();
    this.order = new Order();

    this.order.customer = this.customer;
    this.order.productQuantities = new Map<Product,number>();
  }

  onSelectCurrency(currencyRate: string): void {
    console.log(currencyRate);
    this.api.getProducts(currencyRate)
    .subscribe(result => {
      this.products = result;
    }, error => console.error(error));

    this.order.customer.currencyRate = <CurrencyRateType>CurrencyRateType[currencyRate];
  }

  onSelectProduct(prod: Product): void {
    if (this.selectedProducts == null){
      this.selectedProducts = [];
    }

    if (this.selectedProducts.indexOf(prod) == -1)
      this.selectedProducts.push(prod);

    if (this.order.productQuantities.has(prod)){
      this.order.productQuantities.set(prod, (this.order.productQuantities.get(prod)+1));
    }else{
      this.order.productQuantities.set(prod, 1);
    }
  }

  public getProductQuantity(prod:Product){
    var found = this.order.productQuantities.get(prod)
    return found;
  }

  public submitOrder(){
    console.log('submitOrder');
    console.log(JSON.stringify(this.order));
    this.api.createOrder(this.order)
    .subscribe(orderId => {
    }, error => console.error(error));
;
  }
}
