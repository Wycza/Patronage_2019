FROM microsoft/dotnet:2.2-sdk
WORKDIR /

# Restore dotnet before build to allow for caching
COPY Northwind.Common/Northwind.Common.csproj /src/Northwind.Common/
COPY BookRoom.Domain/BookRoom.Domain.csproj /src/BookRoom.Domain/
COPY BookRoom.Domain.Tests/BookRoom.Domain.Tests.csproj /src/BookRoom.Domain.Tests/

RUN dotnet restore /src/BookRoom.Domain.Tests/BookRoom.Domain.Tests.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/BookRoom.Domain.Tests/BookRoom.Domain.Tests.csproj --no-restore -c Release -o /app

WORKDIR /src/BookRoom.Domain.Tests
ENTRYPOINT ["dotnet", "test"]