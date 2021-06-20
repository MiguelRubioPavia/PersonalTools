const app = require('./server');
const port = 3000;

// Tenemos el servidor a la espera de peticiones http
app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`);
})