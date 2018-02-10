const dataAccess = require('../../dal/dataAccess');
const userQueryHelper = require('../../dal/user');
const util = require('../helpers/util');
const config = require('../../settings');

exports.getAllUsers = function (request, response, next) {
    try {
        dataAccess.executeQuery('SELECT * FROM consumer', (err, data) => {
            if (err) {
                util.Error500(request, response, err);
            }
            else {
                util.SuccessfulGetJsonResponse(request, response, data);
            }
        });
    }
    catch (err) {
        util.Error500(request, response, err);
    }
};


exports.CreateUser = (req, res, next) => {
    const user = {
        email: req.body.email,
        first_name: req.body.first_name,    
        last_name: req.body.last_name,
        password: req.body.password
    };

    if (user.email && user.first_name && user.last_name && user.password) {
        user.password = util.PerformCeasar(user.password, user.password.length, true);
        const queryObj = userQueryHelper.InsertQuery(user);
        dataAccess.executeQuery(queryObj, (err, resp) => {
            if (err) {
                util.Error500(req, res, err);
            }
            else {
                util.SuccessfulPostResponse(req, res, resp);
            }
        });
    }
    else {
        util.Error400(req, res, new Error('Invalid json body!'))
    }
};

exports.Login = (req, res, next) => {

    const user = {
        email: req.body.email,
        password: req.body.password
    };

    if (user.email && user.password) {
        user.password = util.PerformCeasar(user.password, user.password.length, true);
        const objQuery = userQueryHelper.Login(user.email, user.password);
         dataAccess.executeQuery(objQuery.text, objQuery.values, (err, resp) => {
            if (err) {
                util.Error500(req, res, err);
            }
            else {
                util.SuccessfulGetJsonResponse(req, res, resp);
            }
        });
    }
    else {
        util.Error400(req, res, new Error('Invalid json body!'))
    }
};

exports.GetUser = (req, res, next) => {
    const id = req.params.id;
    const objQuery = userQueryHelper.SelectUser(id);
    dataAccess.executeQuery(queryObj, (err, resp) => {
        if (err) {
            util.Error500(req, res, err);
        }
        else {
            util.SuccessfulPostResponse(req, res);
        }
    });
};

exports.UpdateUser = (req, res, next) => {
    res.status(200).json({
        message: 'Put User Api called and user updated!'
    });
};