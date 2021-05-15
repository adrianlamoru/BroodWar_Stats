FROM node

RUN mkdir /bs_frontend
WORKDIR /bs_frontend

COPY ./e2e /bs_frontend/e2e
COPY ./src /bs_frontend/src
COPY package.json /bs_frontend/package.json

RUN npm install