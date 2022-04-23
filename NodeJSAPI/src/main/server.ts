import express from "express";
import swaggerUi from 'swagger-ui-express';

import swaggerFile from '../swagger.json';

import { routes } from "./configs/routes";

const app = express();

app.use(express.json());
app.use("/api-documentation", swaggerUi.serve, swaggerUi.setup(swaggerFile))
app.use(routes);

app.listen(3333, () => {
  console.log("Servidor rodando na porta 3333...");
});