FROM node:9

WORKDIR /usr/src/cardsapi

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 8080

CMD [ "pm2", "start" ]