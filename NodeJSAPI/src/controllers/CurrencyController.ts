import { Request, Response } from "express";
import { CurrencyServices } from "../application/service/CurrencyServices";
import { AzureQueueServices } from "../application/service/AzureQueueServices";

const currencyServices = new CurrencyServices();
const azureQueueServices = new AzureQueueServices();

export class CurrencyController{
    async GetCurrencyListsByDate(req:Request, res:Response) {
        res.status(200).json({ data: await currencyServices.GetCurrencyListsByDate(req.params.baseCurrencyCode,req.params.date) })
    }
    async GetCurrencyByCode(req:Request, res:Response) {
        res.status(200).json({ data: await currencyServices.GetCurrencyByCode(req.params.baseCurrencyCode,req.params.CurrencyCode) })
    }

    async GetCurrencyLists(req:Request, res:Response){
        res.status(200).json({ data: await currencyServices.GetCurrencyLists() })
    }

    async PostQueueMessage(req:Request, res:Response){
        res.status(200).json({ data: await azureQueueServices.SubscriptCurrencyList() })
    }
}