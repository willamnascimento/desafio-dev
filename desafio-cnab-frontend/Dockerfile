FROM node:12-alpine as desafio-angular
WORKDIR /app
COPY package.json /app
RUN npm install
COPY  . .
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=desafio-angular app/dist /usr/share/nginx/html
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf
