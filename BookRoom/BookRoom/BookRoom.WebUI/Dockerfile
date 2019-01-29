FROM microsoft/dotnet:2.2-aspnetcore-runtime AS Base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

# Install node and npm
ENV NODE_VERSION 8.12.0
ENV NODE_DOWNLOAD_SHA 3df19b748ee2b6dfe3a03448ebc6186a3a86aeab557018d77a0f7f3314594ef6
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz

RUN wget "$NODE_DOWNLOAD_URL" -O nodejs.tar.gz \
	&& echo "$NODE_DOWNLOAD_SHA  nodejs.tar.gz" | sha256sum -c - \
	&& tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
	&& rm nodejs.tar.gz \
	&& ln -s /usr/local/bin/node /usr/local/bin/nodejs

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

# Install npm packages first, this is slow so we want to minimise the number of un-cached runs
WORKDIR /src/BookRoom.WebUI/ClientApp/
COPY BookRoom.WebUI/ClientApp/package.json .
COPY BookRoom.WebUI/ClientApp/package-lock.json .

RUN npm install

# Restore dotnet before build to allow for caching
WORKDIR /
COPY BookRoom.Application/BookRoom.Application.csproj /src/BookRoom.Application/
COPY BookRoom.Common/BookRoom.Common.csproj /src/BookRoom.Common/
COPY BookRoom.Domain/BookRoom.Domain.csproj /src/BookRoom.Domain/
COPY BookRoom.Infrastructure/BookRoom.Infrastructure.csproj /src/BookRoom.Infrastructure/
COPY BookRoom.Persistence/BookRoom.Persistence.csproj /src/BookRoom.Persistence/
COPY BookRoom.WebUI/BookRoom.WebUI.csproj /src/BookRoom.WebUI/

RUN dotnet restore /src/BookRoom.WebUI/BookRoom.WebUI.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/BookRoom.WebUI/BookRoom.WebUI.csproj --no-restore -c Release
RUN dotnet publish /src/BookRoom.WebUI/BookRoom.WebUI.csproj --no-restore -c Release -o /app

# Copy compiled app to runtime container
FROM base AS final
COPY --from=build /app .
CMD ["dotnet", "BookRoom.WebUI.dll"]