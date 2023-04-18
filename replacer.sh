#! /bin/bash

set -e
set -u

arg=$1

lower=${arg,,}
capital=${lower^}

find client server -type f -print0 | xargs -0 sed -i "s/TEMPLATE_PLACEHOLDER_LOWER/$lower/g"
find client server -type f -print0 | xargs -0 sed -i "s/TEMPLATE_PLACEHOLDER_CAPITAL/$capital/g"

find client server -depth -name '*TEMPLATE_PLACEHOLDER_CAPITAL*' | while read file; do
	destination="$(echo $file | sed "s/\\(.*\\)TEMPLATE_PLACEHOLDER_CAPITAL/\\1$capital/")"
	mv "$file" "$destination"
done
