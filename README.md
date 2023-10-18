## Sobre
Aplicação feita em ASP.NET Core 7.0 + MS SQL Server e Angular 15.

O backend é uma Web API modelada em camadas, seguindo o conceito da clean architecture. Com Models para representar a camada de dados, Services para encapsular a lógica e regras de negócios, e Controllers para gerenciar o fluxo da aplicação e declarar os endpoints.

O frontend foi construído de forma modularizada, assim empregando o lazy load. Além disso, foram criados componentes reutilizáveis, proporcionando maior escalabilidade e manutenibilidade ao sistema.

## Ambiente de produção

Você pode acessar o site hospedado aqui: http://154.41.228.116:81/  
A documentação online aqui: http://154.41.228.116:8002/swagger/index.html

Ambos estão hospedados em uma VPS Linux Ubuntu.  
O front-end está rodando no NGINX e o back-end no docker-compose.

## Como preparar o Back-end

Escolha um dos dois caminhos:

### Docker-Compose (maneira mais simples):
- Certifique-se de que tenha o Docker
- Clone o repositório
- Entre na pasta back-end/VehicleShowCase
- Abra um terminal e execute o comando:  
```
docker-compose -f docker-compose.yml up --build
```

<br>

### Aplicação e servidor separadamente: 
Você pode instalar o SQL Server em sua máquina atual ou utilizar o docker para subir ele.  
Escolha uma das duas maneiras abaixo para prosseguir:

**Instalando SQL Server na máquina atual**:
- Caso não tenha o SQL Server, baixe [aqui](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) e instale
- Clone o repositório
- Abra o arquivo back-end/VehicleShowCase/VehicleShowcase.Web/appsettings.json
- Em seguida, troque a connection string que está lá por essa:  
```
Data Source=.\\SqlExpress;Initial Catalog=VehicleShowcaseDB;TrustServerCertificate=true;Trusted_Connection=True;
```

**Subindo o servidor em um docker**:
- Certifique-se de que tenha o Docker
- Abra um terminal e execute o comando:  
```
docker run --name vehicleshowcaseDB -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```
- Clone o repositório
- Abra o arquivo back-end/VehicleShowCase/VehicleShowcase.Web/appsettings.json
- Em seguida, troque a connection string que está lá por essa:  
```
Data Source=localhost, 1433;Initial Catalog=VehicleShowcaseDB;TrustServerCertificate=true;User Id=SA;Password=yourStrong(!)Password
```  

<br>

**Aplicação:**
- Certifique-se de que tenha o sdk do .NET 7.0
- Entre na pasta back-end/VehicleShowCase
- Abra um terminal e execute os comandos de instalar dependencias e rodar:  
```
> dotnet restore .\VehicleShowcase.sln  
> cd VehicleShowcase.Web  
> dotnet run --urls "http://localhost:8002"
```

<br>

Obs: As migrações serão aplicadas automaticamente ao iniciar caso utilize qualquer um dos caminhos. Por isso esse erro (ou outro muito parecido) pode acontecer algumas vezes até conectar:  

```
Migration failed: A network-related or instance-specific error occurred while establishing a connection to SQL Server.  
The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. 
(provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)
```

## Como preparar o Front-end

- Clone o repositório
- Entre na pasta front-end/VehicleShowCase
- Abra um terminal e execute os comandos de instalar dependencias e rodar:  
```
> npm install  
> ng serve
```

## Para você não perder tempo:

Endereço local front-end: http://localhost:4200  
Endereço local back-end: http://localhost:8002  

<br>
<br>
<br>
caboo
