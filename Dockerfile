# Берёт базовый образ
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build

WORKDIR /src
# Копирует файл в директорию контейнера src
COPY ["src/EidosTestWork.S3Api/EidosTestWork.S3Api.csproj","src/EidosTestWork.S3Api/"]

# Восстанавливает зависимости
RUN dotnet restore "src/EidosTestWork.S3Api/EidosTestWork.S3Api.csproj"

# Копирует из первого контекста в текущий workdir /src
COPY . .

WORKDIR "/src/src/EidosTestWork.S3Api"

RUN dotnet build "EidosTestWork.S3Api.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "EidosTestWork.S3Api.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

WORKDIR /app

# EXPOSE 80
# EXPOSE 443

FROM runtime as final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet","EidosTestWork.S3Api.dll" ]