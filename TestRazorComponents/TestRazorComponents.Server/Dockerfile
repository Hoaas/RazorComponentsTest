FROM microsoft/dotnet:3.0-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:3.0-sdk-stretch AS build
WORKDIR /src
RUN pwd
RUN ls -l
COPY ["TestRazorComponents/TestRazorComponents.Server/TestRazorComponents.Server.csproj", "TestRazorComponents/TestRazorComponents.Server/"]
COPY ["TestRazorComponents/TestRazorComponents.App/TestRazorComponents.App.csproj", "TestRazorComponents/TestRazorComponents.App/"]
RUN dotnet restore "TestRazorComponents/TestRazorComponents.Server/TestRazorComponents.Server.csproj"
COPY . .
WORKDIR "/src/TestRazorComponents/TestRazorComponents.Server"
RUN dotnet build "TestRazorComponents.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestRazorComponents.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestRazorComponents.Server.dll"]