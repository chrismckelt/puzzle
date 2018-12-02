
export interface Customer
    {
        Id: string;
        FirstName: string;
        Surname: string;
        CreatedUtcDateTime: Date | string;
        CurrencyRate: CurrencyRateType;
        Email: string;
    }
