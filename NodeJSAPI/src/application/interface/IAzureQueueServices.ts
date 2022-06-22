import { Currency } from "../models/Currency";

export interface IAzureQueueServices {
    SubscriptCurrencyList(): Promise<Currency[]>;
}