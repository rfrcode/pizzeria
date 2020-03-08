# Pizzería  

_Proyecto realizado en el Curso de Programación web. Aplicación web sobre una Pizzería_

## Comenzando 🚀


_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

### Pre-requisitos 📋

_Para poder utilizar la apliación debes tener instalado lo siguiente:_

.Net Core SDK v.3.1   [descargar](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.102-windows-x64-installer)

Entity Framework

```
dotnet add package EntityFramework --version 6.4.0
```

Entity Framework Core

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

Redis   https://github.com/MicrosoftArchive/redis/releases/download/win-3.0.504/Redis-x64-3.0.504.msi

Redily  https://www.redily.app/download/win 

_go to File - New Connection. We put the name of the connection and leave the data that is 127.0.0.1 and port 6379, which are what Redis uses. Press "Test Connection" to see if it works and then to "Add"._


_Node   y ejecutar lo siguiente_

```
npm init
```

```
npm install --save multer
```
```
npm install body-parser --save
```

```
npm install express --save
```

### Instalación 🔧

_Una serie de ejemplos paso a paso que te dice lo que debes ejecutar para tener un entorno de desarrollo ejecutandose_


_Para Crear las migraciones de la bbdd ejecutar el siguiente comando desde la carpeta src/pizzeria

```
dotnet ef migrations add InitialCreate --startup-project ./src/pizzeria --project ./src/pizzeriainfraestrure/ 
```
_Actualizar la bbdd
```
dotnet ef database update
```

## Ejecutando las pruebas ⚙️

_Para ejecutar la aplicación desde visual Studio Code  arrancar 

```
Image Server
```

```
Pizzeria - .NET Core Launch
```

## Herramientas utilizadas 🛠️

Postman   https://www.postman.com/
Visual Studio Code  https://visualstudio.microsoft.com/es/downloads
 
## Autores ✒️

* **David Trigo** - [davidtrigo](https://github.com/davidtrigo)
* **Raúl**  - [rfrcode](https://github.com/rfrcode)
* **Sergio** - [Sfalla87](https://github.com/sfalla87)
* **Jonatan Piñero** - [majonny](https://github.com/majonny)
T 