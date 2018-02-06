const settings = require('../../settings');
const util = require('../helpers/util');

exports.Authenticate = function (req, res, next) {
    if (req.headers.key === settings.ApiKey && req.headers.pass === settings.ApiPassword) {
        next();
    }
    else {
       util.Error401(req, res, new Error('Unauthorized!'));
    }
}