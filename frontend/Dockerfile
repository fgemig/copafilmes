FROM node:10-alpine as node
WORKDIR /app
COPY . .
RUN npm install --silent
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=node app/dist/frontend /usr/share/nginx/html
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf