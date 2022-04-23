import { Router } from "express";
import { CurrencyController } from "../../controllers/CurrencyController";

const routes = Router();

routes.get('/availablecurrencies', new CurrencyController().GetCurrencyLists)
routes.get('/currenciesbydate/:baseCurrencyCode/:date', new CurrencyController().GetCurrencyListsByDate)
routes.get('/currencyvaluebased/:baseCurrencyCode/:CurrencyCode', new CurrencyController().GetCurrencyByCode)

export { routes };