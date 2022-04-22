import { Currency } from "../models/Currency";

const axios = require('axios')

const extCurrencyApi_base = 'https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@';
const apiVersion = '1/';
const date = 'latest/'

let currency:string;
export class CurrencyServices{
    
    async GetCurrencyLists(): Promise<String>{
        
        await axios.get(extCurrencyApi_base + apiVersion + date + 'currencies.min.json')
            .then(async function(res:any){
                return currency = res.data;
            })
            .catch(function(error:Error){
                return currency = error.message;
            })
        return currency;
    }
    async GetCurrencyListsByDate(date:String){
         axios.get(extCurrencyApi_base + apiVersion + date + 'currencies.min.json')
        .then(async function(response:Response){
            console.log(response.json());
            return response.json();
        }) 
    }
    async GetCurrencyByCode(currencyCode:String){
        axios.get(extCurrencyApi_base + apiVersion + date + 'currencies/' + currencyCode)
        .then(async function(response:Response){
            console.log(response.json())
            return response.json();
        })
    }
}