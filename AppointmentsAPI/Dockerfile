#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppointmentsAPI.Web/AppointmentsAPI.Web.csproj", "AppointmentsAPI.Web/"]
COPY ["AppointmentsAPI.Application.Abstraction/AppointmentsAPI.Application.Abstraction.csproj", "AppointmentsAPI.Application.Abstraction/"]
COPY ["AppointmentsAPI.Application/AppointmentsAPI.Application.csproj", "AppointmentsAPI.Application/"]
COPY ["AppointmentsAPI.Domain/AppointmentsAPI.Domain.csproj", "AppointmentsAPI.Domain/"]
COPY ["AppointmentsAPI.Persistence/AppointmentsAPI.Persistence.csproj", "AppointmentsAPI.Persistence/"]
COPY ["AppointmentsAPI.Presentation/AppointmentsAPI.Presentation.csproj", "AppointmentsAPI.Presentation/"]
RUN dotnet restore "AppointmentsAPI.Web/AppointmentsAPI.Web.csproj"
COPY . .
WORKDIR "/src/AppointmentsAPI.Web"
RUN dotnet build "AppointmentsAPI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppointmentsAPI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppointmentsAPI.Web.dll"]