import { IAzureQueueServices } from "../interface/IAzureQueueServices";
import { Currency } from "../models/Currency";
import { CurrencyServices } from "./CurrencyServices";

var _currencyService = new CurrencyServices();
var currencies:Currency[] = [];

export class AzureQueueServices implements IAzureQueueServices{

    SubscriptCurrencyList(): Promise<Currency[]> {

        /*  TO-DO
        * Enviar para fila do Service Bus
        */
        return _currencyService.GetCurrencyLists();
    }

} 