# Products API

Este proyecto es una aplicaci�n de gesti�n de productos que utiliza .NET 9.

## Arquitectura y Patrones de Dise�o

El proyecto sigue el model de arquitectura limpia usando varias capas:

- Capa de Dominio: Contiene todas las entidades y enumerados que se usando en el proyecto.
- Capa de Aplicaci�n: Contiene toda la l�gica de la aplicaci�n y se encarga de coordinar las capas de dominio y persistencia, ademas contiene los contratos tanto como para persistencia y servicios que se usan en la capa de infraestructura.
- Capa de Persistencia: Contiene todas las clases de implementaci�n para acceder a la base de datos, en este caso se ha usado solo la memoria como mecanismo de persistencia.
- Capa de Infraestructura: Contiene todas las clases de implementaci�n para acceder a servicios externos, en este caso el servicio de descuentos.
- Capa de Presentaci�n: Contiene los endpoints de la API y se encarga de recibir las peticiones y enviar las respuestas.

Adem�s, se utilizan principalmente los siguientes patrones:

- Repositorio: Se utiliza para encapsular las consultas a la base de datos y promover la reutilizaci�n del c�digo.
- Inyecci�n de Dependencias: Se utiliza para mantener el c�digo desacoplado y mejorar la mantenibilidad y la capacidad de prueba.
- Mediador: Se utiliza para desacoplar la l�gica de negocio de los controladores y promover la reutilizaci�n de c�digo.
- CQRS: Se utiliza para separar las operaciones de lectura y escritura para mejorar el rendimiento y la escalabilidad.

Tambi�n se ha tomado como referencia los principios SOLID para su implementaci�n.

## C�mo ejecutar el proyecto localmente

1. Clonar el repositorio en tu m�quina local.
2. Abrir el proyecto en Visual Studio 2022.
3. Verificar que se tenga el SDK de .NET 9 instalado en la m�quina.
4. Ejecuta el comando `dotnet restore` para restaurar todas las dependencias del proyecto.
5. Ejecuta el comando `dotnet run --project Products.API` para iniciar la aplicaci�n.

## Informaci�n Adicional

Este proyecto utiliza xUnit para las pruebas unitarias, Moq para los mocks y Shouldly para las aserciones. Para ejecutar las pruebas, utiliza el comando `dotnet test`