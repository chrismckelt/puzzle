import {
  Customer
} from './customer'
import {
  Product
} from './product'

export class Order {
  id: string;
  customer: Customer;
  productQuantities: Map < Product, number > ; // typescript has no inbuilt dictionary with an object index
  orderItems: {
    [key: string]: number
  };

  public makeRequestPayload() {
    this.orderItems = {};
    this.productQuantities.forEach((quantity: number,prod: Product) => {
      this.orderItems[prod.id] = quantity;
    });

  }
}
