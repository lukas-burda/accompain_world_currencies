import { Request, Response } from "express";
import { CurrencyServices } from "../domain/service/CurrencyServices";
import { CurrencyRepository } from "../repositories/CurrencyRepository";

const currencyServices = new CurrencyServices();

export class CurrencyController{
    async GetCurrencyLists(req:Request, res:Response){
        res.status(200).json({ message: "Available Currencies", data: await currencyServices.GetCurrencyLists() })
    }

    GetCurrencyListsByCode(req:Request, res:Response){
        const currencies = currencyServices.GetCurrencyListsByDate(req.params.date);
        res.status(200).json({message: "Available Currencies", data: currencies})
    }

    GetCurrencyByCode(req:Request, res:Response){
        const currency = currencyServices.GetCurrencyByCode(req.params.currencyCode);
        res.status(200).json({message:'Price'})
    }
}