#! bash

if [[ "$#" != "1" ]]; then
    echo "Wrong number of arguments"
    exit 1
fi

dotnet ef migrations --startup-project TEMPLATE_PLACEHOLDER_CAPITAL.Api --project TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure add $1