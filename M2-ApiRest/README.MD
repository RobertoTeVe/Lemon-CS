# Laboratorio Api Rest

Laboratorio de API REST con persistencia en base de datos relacional SQL Server.

## Instrucciones

---

Existen dos modelos:

### Author

 - Author
    - Id (Type int)
    - Name (Type string)
    - LastName (Type string)
    - Birth (Type string)
    - CountryCode (Type string)

- Id: PK Auto incremental.
- Name: Nombre del autor.
- LastName: Apellido/-s del autor.
- Birth: Fecha de nacimiento de tipo DateTime. Puede ser null ya que existen libros cuyo autor es desconocido. Por ello existirá un "autor" que sea "Anónimo".
- CountryCode: De tipo string, este código sigue la normativa ISO'3166. Existe lógica que gestiona que el código introducido es válido.


### Book

 - Book
    - Id (Type int)
    - Title (Type string)
    - Published (Type DateTime)
    - Description (Type string)
    - AuthorId (Type int)

- Id: PK Auto incremental.
- Title: Título del libro.
- Published: Fecha de publicación de tipo DateTime. Al igual que el autor, existen libros cuya fecha exacta se desconoce, por ello puede tener valor null.
- Description: descripcción del libro.
- AuthorId: ID del autor del libro.

---

Para poder usar este repositorio se deberá proceder a los siguientes pasos:

### Arrancar un servidor SQL con Docker

1. Habrá que tener instalado [Docker](https://www.docker.com/), pudiendo acceder a su descarga presionanado en el enlace.
2. Depués crearemos el contenedor:
    1. Desde la consola de comandos introduciremos:
    `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Lem0nCode!" -p 1433:1433 --name sqlserver2019 -d mcr.microsoft.com/mssql/server:2019-latest`.
    Con esta línea de código se creará el contenedor. Se ha de tener en cuenta que el usuario para poder acceder a este docker es "sa" y que la contraseña es "Lem0nCode!". En caso de querer cambiarla, se deberá hacer también en el `appsettings.json` del proyecto principal "BookManager".
    2. Con `docker logs sqlserver2019` podrás ver el registro de errores, en caso de haberlos tenido.

### Instalar Dotnet EF

Teniendo el [SDK de .NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0), accede al CMD e introduce:

1. `dotnet tool install --global dotnet-ef`
2. Compruéba que se ha instalado correctamente escribiendo: `dotnet ef --version`.
    Mostrará algo de este estilo: 
    >Entity Framework Core .NET Command-line Tools
    >
    >7.0.0

3. En caso de ya tener alguna version instalada, actualizala con `dotnet tool update --global dotnet-ef`.

---

Una vez tenemos todo listo, tan solo queda almacenar el proyecto en local (de la manera que se prefiera) abrirlo (con VS2022) y ejecutar el proyecto principal `BookManager`.

Importante mencionar que deberémos de tener el contenedor de Docker funcionando para que el proyecto se puede ejecutar de manera correcta.

Se nos habrirá un entorno amigable proporcionado por Swagger, desde el que podremos hacer las llamadas a todos los endpoints que queramos.