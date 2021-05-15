FROM mcr.microsoft.com/dotnet/core/sdk:3.1.408-alpine3.13

LABEL mantainer = "Adrian A. Lamorú Ferrás"

WORKDIR /usr/src/brood-stats-api

COPY ./  /usr/src/brood-stats-api

RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer
RUN dotnet tool install --global dotnet-ef
RUN dotnet add package Microsoft.EntityFrameworkCore
RUN dotnet add package Microsoft.EntityFrameworkCore.Design
RUN dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

CMD ["/bin/sh"]