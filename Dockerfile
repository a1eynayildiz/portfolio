FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY AleynaPortfolio.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
ENV PORT=8080
EXPOSE 8080
ENTRYPOINT ["sh", "-c", "dotnet AleynaPortfolio.dll --urls http://+:${PORT:-8080}"]