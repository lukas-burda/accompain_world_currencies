const axios = require('axios')

const external_url = 'https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/';
const date = 'latest/'

let currency: string;
export class CurrencyServices {

    async GetCurrencyListsByDate(base:string, date: string): Promise<String> {
        await axios.get(external_url + date + '/currencies/' + base + '.json')
            .then(async function (res: any) {
                return currency = res.data;
            })
            .catch(function (error: Error) {
                return currency = error.message;
            })
        return currency;
    }

    async GetCurrencyByCode(base: String, code: String) {
        await axios.get(external_url + date + '/currencies/' + base + '/' + code +'.json')
            .then(async function (res: any) {
                return currency = res.data;
            })
            .catch(function (error: Error) {
                return currency = error.message;
            })
        return currency;
    }

    async GetCurrencyLists(): Promise<String[]> {

        await axios.get(external_url + date + 'currencies.min.json')
            .then(async function (res: any) {
                return currency = res.data;
            })
            .catch(function (error: Error) {
                return currency = error.message;
            })
        return currency;
    }
}