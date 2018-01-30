const express = require('express');
const router = express.Router();

router.get('/', (req, res, next) => {
    res.status(200).json({
        messgae: 'Get all users list!'
    });
});

router.get('/:id', (req, res, next) => {
    const id = req.params.id;
    res.status(200).json({
        messgae: `Get user detail with id : ${id}`
    });
});

router.post('/', (req, res, next) => {
    const user = {
        name: req.body.name,
        email: req.body.email
    };
    res.status(200).json({
        messgae: 'Post User Api called!',
        createdUser: user
    });
});

router.put('/', (req, res, next) => {
    res.status(200).json({
        messgae: 'Put User Api called!'
    });
});

module.exports = router;