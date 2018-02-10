module.exports = {
    CreateCardQuery: (card) => {
        const text = `SELECT * FROM addcard($1, $2, $3, $4, $5)`;
        const values = [card.userId, card.cardNumber, card.cardType, card.expiryDate, card.isActive];
        return { text, values };
    },
    UpdateCard: (card) => {
        const text = `SELECT * FROM updatecarddetails($1, $2, $3, $4, $5) `;
        const values = [card.userId, card.cardNumber, card.cardType, card.expiryDate, card.isActive];
        return { text, values };
    },
    SelectUser: (userid) => {
        const text = `SELECT * FROM getcarddetails($1)`;
        const values = [userid];
        return { text, values };
    }
};