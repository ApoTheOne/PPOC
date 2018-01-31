const settings = {};
settings.Port = process.env.port || 8080;
settings.DatabaseServer = process.env.PGDatabase;
settings.DatabaseServer = process.env.PGPassword;

module.exports = settings;