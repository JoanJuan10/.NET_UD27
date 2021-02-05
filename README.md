# Ejercicios UD27
Proyecto base usado: Netflix_API (ER + SQL) [https://github.com/JoseMarin/Netflix_API]

#### 1. Description
```
Demo API REST creada con .NET COre 3.1 utilizando varias entidades ER y conectada con base de datos 
MS Sql Virtualizada sobre Fedora 32  y VMWare Workstation.
```

#### 2. Lista con los pasos mínimos que se necesitan para clonar exitosamente el proyecto

###### Install
```
IDE               Visual Studio 2019 Community Version
Core              C# 
Framework         NET Core 3.1
DataBase          Microsoft Sql Server 
Virtual           VMWare Workstation
SO                Fedora 32
```
###### packages Nuget 
```
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design  -Version 3.1.4
Install-Package Microsoft.EntityFrameworkCore.Tools               -Version 3.1.8
Install-Package Microsoft.EntityFrameworkCore.SqlServer           -Version 3.1.8
```
###### Cadena de Conexión Base de datos en los diferentes proyectos
appsettings.json
```
"AllowedHosts": "*",
  "ConnectionStrings": {
    "NetflixDatabase": "Server=<IP LOCAL>;Database=<ex1|ex2|ex3|ex4>;User ID=<DB USER>;Password=<DB PASSWORD>"
    }
```
* Substituir los valores entre <> por los suyos locales *
#### 4. URIs endpoints.
EX1
```
Piezas
GET       /api/Piezas
POST      /api/Piezas
GET       /api/Piezas/{id}
PUT       /api/Piezas/{id}
DELETE    /api/Piezas/{id}

Proveedores
GET       /api/Proveedores
POST      /api/Proveedores
GET       /api/Proveedores/{id}
PUT       /api/Proveedores/{id}
DELETE    /api/Proveedores/{id}

Suministras
GET       /api/Suministras
POST      /api/Suministras
GET       /api/Suministras/{id}
PUT       /api/Suministras/{id}
DELETE    /api/Suministras/{id}

```

#### 5. Screenshot imagen que indique cómo debe verse el proyecto.
![image](https://i.imgur.com/ldKpJAs.png)
