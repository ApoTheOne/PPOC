const settings = {};
settings.Port = process.env.port || 8080;
settings.DatabaseServer = process.env.PGDatabase;
settings.DatabaseServer = process.env.PGPassword;
settings.ApiKey = process.env.Apikey;
settings.ApiPassword = process.env.Apipassword;

settings.dbSettings = {
    user: 'postgres',
    host: 'localhost',
    database: process.env.PGDatabase,
    password: process.env.PGPassword,
    port: process.env.POCAPIPORT || 5432
}

module.exports = settings;