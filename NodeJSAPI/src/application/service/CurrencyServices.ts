import { ICurencyServices } from "../interface/ICurrencyServices";
import { Currency } from "../models/Currency";

const axios = require('axios')

const external_url = 'https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/';
const date = 'latest/'

var currency: Currency
var currencyValue: string;
var currencies: Currency[] = [];
export class CurrencyServices implements ICurencyServices {
    TransformResponseList(data: String): Currency[] {
        // For GET/currenciesbydate response
        if (Object.keys(data)[0] == 'date') {
            currencies = [];
            var list = Object.values(data)
            var keys = Object.keys(list[1]);
            var names = Object.values(list[1]);

            for (let index = 0; index < keys.length; index++) {
                currency = new Currency(keys[index], names[index]);
                currencies.push(currency);
            }
            return currencies;
        }
        // For GET /availablecurrencies response
        else {
            currencies = [];
            var keys = Object.keys(data);
            var names = Object.values(data);

            for (let index = 0; index < keys.length; index++) {
                currency = new Currency(names[index], keys[index])
                currencies.push(currency);
            }
            return currencies;
        }
    }

    async GetCurrencyListsByDate(base: string, date: string): Promise<Currency[]> {
        await axios.get(external_url + date + '/currencies/' + base + '.json')
            .then(async function (res: any) {
                return currencyValue = res.data;
            })
            .catch(function (error: Error) {
                return currencyValue = error.message;
            })
        return this.TransformResponseList(currencyValue);
    }

    async GetCurrencyByCode(base: string, code: string) {
        await axios.get(external_url + date + '/currencies/' + base + '/' + code + '.json')
            .then(async function (res: any) {
                return currencyValue = res.data;
            })
            .catch(function (error: Error) {
                return currencyValue = error.message;
            })
        return currencyValue;
    }

    async GetCurrencyLists(): Promise<Currency[]> {

        await axios.get(external_url + date + 'currencies.min.json')
            .then(async function (res: any) {
                return currencyValue = res.data;
            })
            .catch(function (error: Error) {
                return currencyValue = error.message;
            })

        return this.TransformResponseList(currencyValue);
    }
}