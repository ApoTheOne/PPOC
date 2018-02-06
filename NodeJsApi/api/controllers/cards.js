const dataAccess = require('../../dal/dataAccess');
const cardQueryHelper = require('../../dal/cards');
const util = require('../helpers/util');
const config = require('../../settings');

exports.GetCards = (req, res, next) => {
    const id = req.params.userId;
    const objQuery = cardQueryHelper.SelectUser(id);
    dataAccess.executeQuery(objQuery, (err, data) => {
        if (err) {
            util.Error500(req, res, err);
        }
        else {
            util.SuccessfulGetJsonResponse(req, res, data);
        }
    });
}

exports.CreateCards = (req, res, next) => {
    const card = {
        userId: req.body.userId,
        cardNumber: req.body.cardNumber,
        cardType: req.body.cardType,
        expiryDate: req.body.expiryDate,
        isActive: req.body.isActive
    };
    if (card.userId && card.cardNumber && card.expiryDate && card.isActive) {
        card.cardNumber = util.PerformCeasar(card.cardNumber, 12, true);
        const queryObj = cardQueryHelper.CreateCardQuery(card);
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
        util.Error404(req, res, new Error('Invalid json body!'));
    }
}

exports.UpdateCard = (req, res, next) => {
    const card = {
        userId: req.body.userId,
        cardId: req.body.cardId,
        cardNumber: req.body.cardNumber,
        cardType: req.body.cardType,
        expiryDate: req.body.expiryDate,
        isActive: req.body.isActive
    };
    if (card.userId && card.cardId && card.cardNumber && card.cardType && card.expiryDate) {
        const queryObj = cardQueryHelper.UpdateCard(card);
        dataAccess.executeQuery(queryObj.text, queryObj.values, (err, resp) => {
            if (err) {
                util.Error500(req, res, err);
            }
            else {
                util.SuccessfulGetJsonResponse(req, res, resp);
            }
        });
    }
    else {
        util.Error400(req, res, new Error('Invalid json body!'));
    }
}