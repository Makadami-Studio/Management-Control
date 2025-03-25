import { Router } from "express";
import { registerAuth, loginAuth } from "../controllers/authController";

const router = Router();

/**
 * @swagger
 * /api/v1/auth/register:
 *   post:
 *     summary: Rejestracja użytkownika
 *     tags:
 *       - Auth
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               email:
 *                 type: string
 *               password:
 *                 type: string
 *     responses:
 *       201:
 *         description: Użytkownik zarejestrowany
 *       400:
 *         description: Błąd walidacji
 */
router.post("/register", registerAuth);

/**
 * @swagger
 * /api/v1/auth/login:
 *   post:
 *     summary: Logowanie użytkownika
 *     tags:
 *       - Auth
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               email:
 *                 type: string
 *               name:
 *                 type: string
 *               password:
 *                 type: string
 *     responses:
 *       200:
 *         description: Użytkownik zalogowany
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 token:
 *                   type: string
 *       400:
 *         description: Błąd walidacji
 */
router.post("/login", loginAuth);

export default router;
