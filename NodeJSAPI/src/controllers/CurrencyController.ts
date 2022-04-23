import { Request, Response } from "express";
import { CurrencyServices } from "../domain/service/CurrencyServices";

const currencyServices = new CurrencyServices();

export class CurrencyController{
    async GetCurrencyListsByDate(req:Request, res:Response) {
        console.log(req.query.date)
        res.status(200).json({ data: await currencyServices.GetCurrencyListsByDate(req.params.date) })
    }
    async GetCurrencyListsByCode(req:Request, res:Response) {
        throw new Error("Method not implemented.");
    }

    async GetCurrencyLists(req:Request, res:Response){
        res.status(200).json({ data: await currencyServices.GetCurrencyLists() })
    }
}