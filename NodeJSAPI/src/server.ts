import express from "express";
import { routes } from "./configs/routes";

const app = express();

app.use(express.urlencoded());
app.use(express.json());
app.use(routes);

app.listen(3333, () => {
  console.log("Servidor rodando na porta 3333...");
});