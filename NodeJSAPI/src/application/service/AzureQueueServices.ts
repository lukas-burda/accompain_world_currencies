import { IAzureQueueServices } from "../interface/IAzureQueueServices";
import { Currency } from "../models/Currency";
import { CurrencyServices } from "./CurrencyServices";
import * as asb from "@azure/service-bus";
import { json } from "express";

var _currencyService = new CurrencyServices();
var currencies : Currency[] = [];

export class AzureQueueServices implements IAzureQueueServices{

    async SubscriptCurrencyList(base: string, date: string): Promise<Currency[]> {

        const connectionString = "Endpoint=sb://dconto.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=aDAmnosCtn3w9p91CBhuKy6ezLctiwsYwRCNhfq67yo=";

        const serviceBus = new asb.ServiceBusClient(connectionString);

        const sender = serviceBus.createSender("availablecurrencies-queue");

        currencies = await _currencyService.GetCurrencyListsByDate(base, date);

        await sender.sendMessages(
            {
                body: JSON.stringify({currencies})
            })
        return currencies;
    }

} 