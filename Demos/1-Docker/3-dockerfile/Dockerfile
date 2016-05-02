FROM ubuntu:trusty

RUN apt-get update -q \
    && apt-get install -y libunwind8 libunwind8-dev gettext libicu-dev liblttng-ust-dev libcurl4-openssl-dev libssl-dev uuid-dev unzip \
    && rm -rf /var/lib/apt/lists/*
    

CMD /bin/bash