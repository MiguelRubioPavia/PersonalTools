const express = require('express');

const app = express();

// Cargar fichero de rutas
var prueba_routes = require('./routes/prueba_route');

app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*');
    res.header('Access-Control-Allow-Headers', 'Authorization, X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Allow-Request-Method');
    res.header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, DELETE');
    res.header('Allow', 'GET, POST, OPTIONS, PUT, DELETE');
    next();
});

// Añadir prefijo de ruta
/* app.use('/api/', prueba_routes); */
app.use('/PTapi', prueba_routes);

module.exports = app;