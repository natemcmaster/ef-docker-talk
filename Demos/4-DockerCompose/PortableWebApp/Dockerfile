FROM natemcmaster/dotnet:rc2

WORKDIR /opt/app

ENV ASPNETCORE_ENVIRONMENT Production

ADD "./bin/Release/netcoreapp1.0/publish/" .
EXPOSE 5000

CMD ./docker-start.sh

