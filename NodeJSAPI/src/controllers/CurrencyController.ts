import { Request, Response } from "express";
import { CurrencyServices } from "../domain/service/CurrencyServices";

const currencyServices = new CurrencyServices();

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
}