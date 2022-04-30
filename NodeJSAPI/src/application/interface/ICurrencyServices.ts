import { Currency } from "../models/Currency";

export interface ICurencyServices{
    GetCurrencyLists(): Promise<Currency[]>;
    GetCurrencyListsByDate(base:string, date: string): Promise<Currency[]>;
    GetCurrencyByCode(base: String, code: String): Promise<String>;
    TransformResponseList(data: String):Currency[];
}