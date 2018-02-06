const { Pool, Client } = require('pg');
const config = require('../settings');
const pool = new Pool(config.dbSettings);

pool.on('error', (err) => {
    console.error('An idle client has experienced an error', err.stack)
});

module.exports = {
    executeQuery: (queryText, params, callback) => {
        try {
            return pool.query(queryText, params, callback)
        }
        catch (err) {
            console.log(err.stack);
        }
    }
};