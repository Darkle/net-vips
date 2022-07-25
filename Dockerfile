FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
LABEL maintainer="Kleis Auke Wolthuizen <info@kleisauke.nl>"

RUN apk add bash ttf-dejavu --update-cache

WORKDIR /app

CMD ["./build.sh"]
