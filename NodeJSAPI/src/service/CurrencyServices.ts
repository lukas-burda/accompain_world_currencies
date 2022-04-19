import { Currency } from "../domain/models/Currency";

const axios = require('axios')

const extCurrencyApi_base = 'https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@';
const apiVersion = '1/';
const date = 'latest/'
const endpoint = "/"
//const externalCurrencyApi_finalUrl = `${externalCurrencyApi_base}@${apiVersion}/${date}/${endpoint}`;
let currency = new Currency();

export class CurrencyServices{
    
    async GetCurrencyLists(): Promise<Currency>{
        await axios.get(extCurrencyApi_base + apiVersion + date + 'currencies.json')
        .then(async function(res:any){
            currency = res.data;
            return await currency;
        })
        .catch(function(error:Error){
            return error;
        })
        return currency;
    }
    GetCurrencyListsByDate(date:String){
        axios.get(extCurrencyApi_base + apiVersion + date + 'currencies')
        .then(function(response:Response){
            console.log(response.json());
            return response.json();
        }) 
    }
    GetCurrencyByCode(currencyCode:String){
        axios.get(extCurrencyApi_base + apiVersion + date + 'currencies/' + currencyCode)
        .then(function(response:Response){
            console.log(response.json())
            return response.json();
        })
    }
}