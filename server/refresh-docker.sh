#! /bin/bash

docker stop TEMPLATE_PLACEHOLDER_LOWER
docker rm TEMPLATE_PLACEHOLDER_LOWER
docker build -t TEMPLATE_PLACEHOLDER_LOWER .
docker run -d --name TEMPLATE_PLACEHOLDER_LOWER -p127.0.0.1:5061:80 -v /var/db:/var/db TEMPLATE_PLACEHOLDER_LOWER
