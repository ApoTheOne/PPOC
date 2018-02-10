const express = require('express');
const router = express.Router();
const cardController = require('../controllers/cards');
const auth = require('../middlewares/authorization');

router.get('/:userId', auth.Authenticate, cardController.GetCards);

router.post('/', auth.Authenticate, cardController.CreateCards);

router.put('/', auth.Authenticate, cardController.UpdateCard);

module.exports = router;