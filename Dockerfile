FROM microsoft/dotnet:3.0-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:3.0-sdk-stretch AS build
WORKDIR /src
COPY ["ShibaPower.csproj", ""]
RUN dotnet restore "/ShibaPower.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ShibaPower.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ShibaPower.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShibaPower.dll"]