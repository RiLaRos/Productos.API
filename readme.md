# Products API

Este proyecto es una aplicación de gestión de productos que utiliza .NET 8.

## Arquitectura y Patrones de Diseño

El proyecto sigue el model de arquitectura limpia usando varias capas:

- Capa de Dominio: Contiene todas las entidades y enumerados que se usando en el proyecto.
- Capa de Aplicación: Contiene toda la lógica de la aplicación y se encarga de coordinar las capas de dominio y persistencia, ademas contiene los contratos tanto como para persistencia y servicios que se usan en la capa de infraestructura.
- Capa de Persistencia: Contiene todas las clases de implementación para acceder a la base de datos, en este caso se ha usado solo la memoria como mecanismo de persistencia.
- Capa de Infraestructura: Contiene todas las clases de implementación para acceder a servicios externos, en este caso el servicio de descuentos.
- Capa de Presentación: Contiene los endpoints de la API y se encarga de recibir las peticiones y enviar las respuestas.

Además, se utilizan principalmente los siguientes patrones:

- Repositorio: Se utiliza para encapsular las consultas a la base de datos y promover la reutilización del código.
- Inyección de Dependencias: Se utiliza para mantener el código desacoplado y mejorar la mantenibilidad y la capacidad de prueba.
- Mediador: Se utiliza para desacoplar la lógica de negocio de los controladores y promover la reutilización de código.
- CQRS: Se utiliza para separar las operaciones de lectura y escritura para mejorar el rendimiento y la escalabilidad.

También se ha tomado como referencia los principios SOLID para su implementación.

## Cómo ejecutar el proyecto localmente

1. Clonar el repositorio en tu máquina local.
2. Abrir el proyecto en Visual Studio 2022.
3. Verificar que se tenga el SDK de .NET 8 instalado en la máquina.
4. Ejecuta el comando `dotnet restore` para restaurar todas las dependencias del proyecto.
5. Ejecuta el comando `dotnet run --project Products.API` para iniciar la aplicación.

## Información Adicional

Este proyecto utiliza xUnit para las pruebas unitarias, Moq para los mocks y Shouldly para las aserciones. Para ejecutar las pruebas, utiliza el comando `dotnet test`