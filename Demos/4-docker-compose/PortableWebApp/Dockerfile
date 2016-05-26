FROM microsoft/dotnet:1.0.0-preview1

RUN apt-get update -qq \
    && apt-get install -y netcat \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /opt/app

ENV ASPNETCORE_ENVIRONMENT Production

COPY "./bin/Release/netcoreapp1.0/publish/" .
EXPOSE 5000

CMD chmod +x ./docker-start.sh
CMD ./docker-start.sh
