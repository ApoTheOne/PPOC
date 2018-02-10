const express = require('express');
const router = express.Router();
const userController = require('../controllers/users');

router.get('/', userController.getAllUsers);

router.get('/:id', userController.GetUser);

router.post('/', userController.CreateUser);

router.put('/', userController.UpdateUser);

module.exports = router;