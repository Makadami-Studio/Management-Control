import express from "express";
import cors from "cors";
import dotenv from "dotenv";
import authRoutes from "./routes/authRoutes";
import { setupSwagger } from "./docs/swagger";

dotenv.config();

const app = express();

setupSwagger(app);

const env = process.env.NODE_ENV || "development";

const corsOptions =
  env === "production"
    ? {
        origin: [""], // tutaj bedzie URL do api (produkcja)
        methods: ["GET", "POST", "PUT", "PATCH", "DELETE"],
        allowedHeaders: [
          "Origin",
          "X-Requested-With",
          "Content-Type",
          "Accept",
          "Authorization",
        ],
        credentials: true,
      }
    : {
        origin: "*",
      };

env === "production"
  ? console.log("Working on PRODUCTION")
  : console.log("Working on DEV MODE!");

  
app.use(cors(corsOptions));
app.use(express.json());

app.use("/api/v1/auth", authRoutes);

/* app.use("/api/v1/flat", )
 */

const PORT = process.env.PORT || 3000;

app.get("/", (_req, res) => {
  res.send("Hell yeah");
});

app.listen(PORT, () => {
  console.log(`Server working on: http://localhost:${PORT}`);
});
