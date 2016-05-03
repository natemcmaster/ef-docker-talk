FROM natemcmaster/dotnet:rc2

WORKDIR /opt/app

ENV ASPNETCORE_ENVIRONMENT Production

COPY "./bin/Release/netcoreapp1.0/publish/" .
EXPOSE 5000

CMD chmod +x ./docker-start.sh
CMD ./docker-start.sh
