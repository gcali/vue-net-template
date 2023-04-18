#! /bin/bash

set -e

npm install
npm run build
timestamp=$(date +%s)
cp -rv dist/* /var/html/TEMPLATE_PLACEHOLDER_LOWER


