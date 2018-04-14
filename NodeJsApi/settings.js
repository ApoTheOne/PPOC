const settings = {};
settings.Port = process.env.PORT;
settings.ApiKey = process.env.APIKEY;
settings.ApiPassword = process.env.APIPWD;

settings.dbSettings = {
    user: process.env.PGUSER,
    host: process.env.DBHOST,
    database: process.env.PGDB,
    password: process.env.PGPWD,
    port: process.env.PGDBPORT
}

module.exports = settings;