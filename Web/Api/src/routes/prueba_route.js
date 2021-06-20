var express = require('express');

// Cargar controlador
var PruebaController = require('../controllers/prueba_controller');

var router = express.Router();

// Rutas de prueba
router.get('/', PruebaController.testGet);


module.exports = router;