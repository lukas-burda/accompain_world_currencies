import { Router } from "express";
import { CurrencyController } from "../../controllers/CurrencyController";

const routes = Router();

routes.get('/availablecurrencies', new CurrencyController().GetCurrencyLists)
routes.get('/currenciesbydate/:baseCurrencyCode/:date', new CurrencyController().GetCurrencyListsByDate)
routes.get('/currencyconversion/:baseCurrencyCode/:CurrencyCode', new CurrencyController().GetCurrencyByCode)
routes.post('/enqueueavailablecurrencies', new CurrencyController().PostQueueMessage)

export { routes };