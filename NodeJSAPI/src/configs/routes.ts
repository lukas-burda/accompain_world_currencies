import { application, Router } from "express";
import { CurrencyController } from "../controllers/CurrencyController";

const routes = Router();

// routes to-do
//C# chama o Get
routes.get("/getCurrencyLists", new CurrencyController().GetCurrencyLists)

export { routes };