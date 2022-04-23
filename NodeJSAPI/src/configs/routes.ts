import { Router } from "express";
import { CurrencyController } from "../controllers/CurrencyController";

const routes = Router();

routes.get('/availablecurrencies', new CurrencyController().GetCurrencyLists)
routes.get('/currency/:base/:date', new CurrencyController().GetCurrencyListsByDate)
routes.get('/currency/:base/:code', new CurrencyController().GetCurrencyListsByCode)

export { routes };