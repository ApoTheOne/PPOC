const express = require('express');
const router = express.Router();

router.get('/', (req, res) => {
    res.send('Testing call success');
});

module.exports = router;