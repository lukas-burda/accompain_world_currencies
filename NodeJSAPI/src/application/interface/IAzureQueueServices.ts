import { Currency } from "../models/Currency";

export interface IAzureQueueServices {
    SubscriptCurrencyList(base: string, date: string): Promise<Currency[]>;
}