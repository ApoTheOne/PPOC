
exports.GetAllUsers = (req, res, next) => {
    console.log('reached user controller');
    res.status(200).json({
        message: 'Get all users list!'
    });
}

exports.GetUser = (req, res, next) => {
    const id = req.params.id;
    res.status(200).json({
        message: `Get user detail with id : ${id}`
    });
}

exports.CreateUser = (req, res, next) => {
    const user = {
        name: req.body.name,
        email: req.body.email
    };
    res.status(200).json({
        message: 'Post User Api called, user created!',
        createdUser: user
    });
}

exports.UpdateUser = (req, res, next) => {
    res.status(200).json({
        message: 'Put User Api called and user updated!'
    });
}