
exports.GetAllCards = (req, res, next) => {
    res.status(200).json({
        message: 'Get all cards list!'
    });
}

exports.GetCard = (req, res, next) => {
    const id = req.params.id;
    res.status(200).json({
        message: `Get card detail with id : ${id}`
    });
}

exports.CreateCard = (req, res, next) => {
    const card = {
        userId: req.body.userId,
        cardNumber: req.body.cardNumber,
        expiryDate: req.body.expiryDate
    };
    res.status(200).json({
        message: 'Post Cards Api called!',
        createdCard: card
    });
}

exports.UpdateCard = (req, res, next) => {
    res.status(200).json({
        message: 'Put Card Api called!'
    });
}