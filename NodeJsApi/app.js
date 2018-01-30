const express = require('express');
const app = express();
const bodyParser = require('body-parser');

const usersRouter = require('./api/routes/users');
const cardsRouter = require('./api/routes/users');

app.use(bodyParser.urlencoded({
    extended: false
}));
app.use(bodyParser.json());

app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
    if(req.method === 'OPTIONS'){
        res.header('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
        return res.status(200).json({});
    }
    next();
});

app.use('/users', usersRouter);
app.use('/cards', cardsRouter);

app.use((req, res, next) => {
    const error = new Error('Resource not found!');
    error.status = 404;
    next(error);
})

app.use((error, req, res, next) => {
    res.status(error.status || 500);
    res.json({
        error: {
            message: error.message
        }
    });
})

module.exports = app;