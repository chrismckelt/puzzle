import {Customer} from './customer'
import {Product} from './product'

export interface Order
{
    Id: string;
    Customer: Customer;
    ProductQuantities: { [key: string]: number };
}
