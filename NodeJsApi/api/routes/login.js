const express = require('express');
const router = express.Router();
const userController = require('../controllers/users');

router.post('/', userController.Login);

module.exports = router;