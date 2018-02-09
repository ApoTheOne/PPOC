exports.PerformCeasar = function (inputStr, lengthToConvert, encrypt) {
    var arrOfChars = inputStr.split('');
    var arrLength = arrOfChars.length;
    if (encrypt) {
        for (i = 0; i < arrLength; i++) {
            if (i < lengthToConvert) {
                arrOfChars[i] = String.fromCharCode(inputStr.charCodeAt(i) - arrLength);
            }
            else {
                break;
            }
        }
    }
    else {
        for (i = 0; i < arrLength; i++) {
            if (i < lengthToConvert) {
                arrOfChars[i] = String.fromCharCode(inputStr.charCodeAt(i) + arrLength);
            }
            else {
                break;
            }
        }
    }
    return arrOfChars.join('');
}


exports.SuccessfulGetJsonResponse = function (request, response, data) {
    response.writeHead(200, { 'Content-type': 'application/json' });
    if (data) {
        response.write(JSON.stringify(data.rows));
    }
    response.end();
}

exports.SuccessfulPostResponse = function (request, response, msg) {
    response.writeHead(201, { 'Content-type': 'application/json' });
    if (msg && msg.rows && msg.rows[0]) {
        //response.end(JSON.stringify(Object.values(msg.rows[0])[0]));
        response.end(JSON.stringify(msg.rows));
    }
    else {
        response.end();
    }
}

exports.Error500 = function (request, response, err) {
    response.writeHead(500, 'Internal server error!', { 'Content-type': 'application/json' });
    response.write(JSON.stringify({ error: `Internal server error: ${err}` }));
    response.end();
}

exports.Error400 = function (request, response, err) {
    response.writeHead(400, 'Bad request!', { 'Content-type': 'application/json' });
    response.write(JSON.stringify({ error: `Bad request: ${err}` }));
    response.end();
}

exports.Error401 = function (request, response, err) {
    response.writeHead(401, 'Missing or bad authentication!', { 'Content-type': 'application/json' });
    response.write(JSON.stringify({ error: `Missing or bad authentication: ${err}` }));
    response.end();
}