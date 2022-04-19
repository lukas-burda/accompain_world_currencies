import { Request, response, Response } from "express";
import { CurrencyRepository } from "../repositories/CurrencyRepository";
import { CurrencyServices } from "../service/CurrencyServices";

const currencyRepository = new CurrencyRepository();
const currencyServices = new CurrencyServices();

export class CurrencyController{
    async GetCurrencyLists(req:Request, res:Response){
        let currencies = await currencyServices.GetCurrencyLists();
        console.log(currencies);
        await res.status(200).json({message: "Available Currencies", data: currencies})
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