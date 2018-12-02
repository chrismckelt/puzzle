import { Order } from '../models/order';
import { Injectable } from '@angular/core';
import { CurrencyRateType } from '../models/currencyratetype';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { HttpHeaders } from '@angular/common/http';
import 'rxjs/add/observable/throw';
import {map, catchError} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {_throw} from 'rxjs/observable/throw';

@Injectable()
export class ApiService {

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {

  }

  public listProducts(){
    return this.http.get<Product[]>(this.baseUrl + 'api/product/list');
  }

  public getProducts(currencyRateType){
    return this.http.get<Product[]>(this.baseUrl + 'api/product/getproducts/' + currencyRateType);
  }

  public createOrder(order:Order){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };
    order.makeRequestPayload();
    return this.http.post<Order>(this.baseUrl + 'api/order/create', order,httpOptions)
    .pipe(
      map((res) => alert('ORDER MADE -- order id ' + res),
      catchError((err) => {
        return Observable.throw(err);
      })
    ));
  }}
