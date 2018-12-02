import { CurrencyRateType } from './currencyratetype';
export class Customer
    {
        id: string;
        firstName: string;
        surname: string;
        createdUtcDateTime: Date | string;
        currencyRate: CurrencyRateType;
        email: string;
    }
