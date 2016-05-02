FROM buildpack-deps:trusty-scm

# install dotnet into our image
RUN echo "deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet/ trusty main" > /etc/apt/sources.list.d/dotnet.list \
    && apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893 \
    && apt-get update -q \
    && apt-get install -y dotnet-dev-1.0.0-rc2-002520 \
    && rm -rf /var/lib/apt/lists/*