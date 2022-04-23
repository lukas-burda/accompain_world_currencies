import { Currency } from "../models/Currency";

const axios = require('axios')

const extCurrencyApi_base = 'https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@';
const apiVersion = '1/';
const date = 'latest/'

let currency: string;
export class CurrencyServices {

    async GetCurrencyListsByDate(date: string) {
        console.log(date)
        //1/2020-11-24/
        axios.get(extCurrencyApi_base + apiVersion + date + 'currencies/btc.json')
            .then(async function (res: any) {
                return currency = res.data;
            })
            .catch(function (error: Error) {
                return currency = error.message;
            })
        return currency;
    }

    async GetCurrencyByCode(base: String,code: String) {
    //     /currencies/{currencyCode}/{currencyCode}
        axios.get(extCurrencyApi_base+'')
    //     https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/{base}/{code}.json
    }

    async GetCurrencyLists(): Promise<String> {

        await axios.get(extCurrencyApi_base + apiVersion + date + 'currencies.min.json')
            .then(async function (res: any) {
                return currency = res.data;
            })
            .catch(function (error: Error) {
                return currency = error.message;
            })
        return currency;
    }
}