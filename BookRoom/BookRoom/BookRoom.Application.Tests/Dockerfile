FROM microsoft/dotnet:2.2-sdk
WORKDIR /

# Restore dotnet before build to allow for caching
COPY BookRoom.Application/BookRoom.Application.csproj /src/BookRoom.Application/
COPY BookRoom.Application.Tests/BookRoom.Application.Tests.csproj /src/BookRoom.Application.Tests/
COPY Northwind.Common/Northwind.Common.csproj /src/Northwind.Common/
COPY BookRoom.Domain/BookRoom.Domain.csproj /src/BookRoom.Domain/
COPY BookRoom.Persistence/BookRoom.Persistence.csproj /src/BookRoom.Persistence/

RUN dotnet restore /src/BookRoom.Application.Tests/BookRoom.Application.Tests.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/BookRoom.Application.Tests/BookRoom.Application.Tests.csproj --no-restore -c Release -o /app

WORKDIR /src/BookRoom.Application.Tests
ENTRYPOINT ["dotnet", "test"]   