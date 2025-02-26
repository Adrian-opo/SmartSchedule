# SmartSchedule

## Instalação

1. Clone o repositório:

   ```sh
   git clone https://github.com/niliotiii/SmartSchedule.git
   cd SmartSchedule
   ```

2. Instale as dependências:
   ```sh
   dotnet restore
   ```

## Build

Para buildar o projeto, execute:

```sh
dotnet build
```

## Migrations

Para adicionar uma nova migration, execute:

```sh
dotnet ef migrations add InitDb --output-dir DataContext/Migrations --project SmartSchedule/SmartSchedule.csproj
```

Para atualizar o banco de dados com as migrations, execute:

```sh
dotnet ef database update --project SmartSchedule/SmartSchedule.csproj
```

## Executar a Aplicação

Para executar a aplicação, execute:

```sh
dotnet run --project SmartSchedule/SmartSchedule.csproj
```
