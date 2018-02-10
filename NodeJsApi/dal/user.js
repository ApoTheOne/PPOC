module.exports = function SelectAllQuery() {
    const selectAllQuery = {
        text: 'SELECT * FROM consumer '
    };
    return selectAllQuery;
};

module.exports = {
    Login: (email, pass) => {
        const text = `SELECT * FROM getconsumerdetails($1, $2)`;
        const values = [email, pass];
        return { text, values };
    },
    InsertQuery: (user) => {
        const text = `SELECT * FROM addconsumer($1, $2, $3, $4) `;
        const values = [user.email, user.first_name, user.last_name, user.password];
        return { text, values };
    }
};