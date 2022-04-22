import { Currency } from "../domain/models/Currency";

const currencies: Currency[] = [];

export class CurrencyRepository{
    Add(currency: Currency): Currency[]{
        
        currencies.push(currency)
        
        return currencies;
    }

    Get(): Currency[]{

        return currencies;
    }
}