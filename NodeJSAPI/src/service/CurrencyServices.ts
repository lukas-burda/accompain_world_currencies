import { Currency } from "../domain/models/Currency";

const axios = require('axios')

const extCurrencyApi_base = 'https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@';
const apiVersion = '1/';
const date = 'latest/'
const endpoint = "/"
//const externalCurrencyApi_finalUrl = `${externalCurrencyApi_base}@${apiVersion}/${date}/${endpoint}`;

export class CurrencyServices{
    
    GetCurrencyLists(){
        var currencies;
        axios.get(extCurrencyApi_base + apiVersion + date + 'currencies.json')
        .then(function(res:any){
            console.log(res.data)
        })
        .catch(function(error:Error){
            return error;
        })
        return currencies;
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