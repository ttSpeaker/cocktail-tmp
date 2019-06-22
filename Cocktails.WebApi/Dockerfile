FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Cocktails.WebApi/Cocktails.WebApi.csproj", "Cocktails.WebApi/"]
COPY ["Cocktails.Domain/Cocktails.Domain.csproj", "Cocktails.Domain/"]
COPY ["ViewModels/ViewModels.csproj", "ViewModels/"]
COPY ["Cocktail.DataAccess/Cocktails.Persistance.csproj", "Cocktail.DataAccess/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["ConsoleApp1/ApiClientConsoleApp.csproj", "ConsoleApp1/"]
RUN dotnet restore "Cocktails.WebApi/Cocktails.WebApi.csproj"
COPY . .
WORKDIR "/src/Cocktails.WebApi"
RUN dotnet build "Cocktails.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cocktails.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cocktails.WebApi.dll"]