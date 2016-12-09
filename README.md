# AerolineaTNS - Prueba Tecnica TNS

Proyecto desarrollado utilizando:

- Visual studio 2015 - Framework 4.6.1
- Servicios Rest expuestos en el BackEnd con Web.Api (usando un proyecto Asp.Net Core Web Application (.NET Core). lo que permite levantar los servicios usando un .exe que se encuentra en la carpeta "..\Tns.Aerolinea.WebApi\bin\Debug\net461\win7-x64\Tns.Aerolinea.WebApi.exe" corriendo por defecto en el puerto 5000.
- AngularJs en el FrontEnd consumiendo los servicios rest.
- Sql server 2014 (se adjunta en el proyecto un .bak de la BD y dentro de la solucion hay un proyecto tipo DataBase con toda la estructura de la misma).
- Incluye proyecto de pruebas unitarias (Tns.Aerolinea.UnitTest).
- Adicional se incluye el archivo Pruebas.postman_ServiciosRest.json que contiene el set de pruebas de algunos de los servicios REST contruidos y consumidos desde PostMan.
- GitHub para la administracion del codigo fuente y con la ventaja que desde visual studio 2015 ya viene integrado GIT. por lo que se puede clonar la solucion muy facilmente sin usar otras herramientas.
- Nuget Package para la administracion de todos los componentes de terceros requeridos en algunas capas como por ejemplo Autofac (Inyeccion de dependnecias), AngularJs, EntityFramwork (ORM para acceso a datos), Nlog para logue de errores, etc.
- Bootstrap para el desieño de la interfaz gráfica.

Consideraciones del proyecto:

- Se intento usar la nueva guia de estilo de desarrollo propuesto por Jhon Papa y adoptada por Vidual studio en sus ultimas versiones.
	https://github.com/johnpapa/angular-styleguide/tree/master/a1
	
- Base de la arquitectura. https://blogs.msdn.microsoft.com/cesardelatorre/2010/03/11/nuestro-nuevo-libro-guia-de-arquitectura-n-capas-ddd-net-4-0-y-aplicacion-ejemplo-en-disponibles-para-download-en-msdn-y-codeplex/


Arquitectura implementada:

- Se utilizo como base una arquitectura de N-Capas Oriantada al Dominio propuesta por microsoft Ibérica (incluido una diagrama general de este tipo de arquitectura en la carpeta de documentación Arquitectura de n-Capas orientada al dominio con .net.png). El objetivo de una arquitectura basada en Domain Driven Design (DDD) es conseguir un modelo orientado a objetos que refleje el conocimiento de un dominio dado y que sea completamente independiente de cualquier concepto de comunicación, ya sea con elementos de infraestructura como de interfaz gráfica, o de la tecnologia de la base de datos, etc. Por esto, el centro de la arquitectura el la capa de Dominio, que cuando la miramos a mas detalle vemos que no es la tipica capa de "Negocio" que muchas veces se vuelve de transicion en la tipica arquitectura de 3 capas, sino que solo acudimos a ella cuando debemos aplicar realmente reglas de negocio y en caso de requerir ir a base de datos hacemos uso de la inyeccion de dependencias para no hacer depender el Dominio de una capa de acceso a datos. Uno de los principales beneficios de este tipo de arquitectura es que los cambios de tecnologías de infraestructura de una aplicación no afecten a capas de alto nivel de la aplicación, especialmente, que afecten lo mínimo posible a la capa del Dominio de la aplicación.

- Iyecciónn de dependencias tanto en el FrontEnd (con angularjs) como en el BackEnd (usando Autofac) es una forma de evitar el alto acoplamiento entre componentes , especialmente en la arquitectura basada en DDD donde una de sus principales funciones es hacer la capa de dominio lo mas indepnendiete posible de cualquier otro componente. En este patron no debemos de instanciar de forma explícita las dependencias. En este caso, se puede hacer uso de una interfaz
que defina una abstracción común que pueda ser utilizada para inyectar instancias de objetos en componentes que interactúen con la interfaz abstracta compartida.
Para dar solucion en el proyecto a este patron use un contenedor de dependencia (DI) en el componente "Application" de la solucion, que es como un orquestador entre las peticiones y el core de la aplicaion y desde el cual puedo ir al Domain a aplicar una regla de negocio o directaente a la capa de datos a consultar la informacion requerida o a ambas en caso de requerir informacion de la BD y aplicar una regla de negocio al mismo tiempo.

- Repository es normalmente una clase encargada de realizar las operaciones de persistencia y acceso a datos, y esta ligado por lo tanto a una tecnología concreta n este caso Entity Framework. Esto con el fin de centralizar la funcionalidad de acceso a datos, lo cual hace más directo y sencillo el
mantenimiento y configuración de la aplicación. Para el manejo de estos repositorios, tambien use la inyeccion de dependencias y estas las alojamos en la capa de Dominio.

- Use DTO's para exponer en los servicios Rest en el Web.Api.

- EntityFramework 6.1.3 (ultima version estable). En este sentido, las entidades de negocio son generadas automaticamnete a partir del modelo usando las platillas T4, pero por defecto estas quedan en la cada Data, donde se encuentra el archivo .edmx que es el que contiene todo el modelo de la base de datos, para esto use un pequeño truco para permitir llevarme la plantilla a otro emsamblado y quede las entidades en una capa transversal y no necesariamente tener que hacer la capa de datos transversal.


Notas:

- Por temas de tiempo, no todas las pantallas en FrontEnd fueron terminadas, pero si en el BackEnd se encuentran expuestos todos los servicios requeridos por la aplicacion. Igualmente intente hacer algunas pantallas que muestren varias facetas, como lo es consultas sencillas, consultas de onjetos mas complejos (metodos GET) y actualizacion o inserciones en la base de datos (metodos PUT).

- En la carpeta Documentacion en la raiz del proyecto se encuentra : Diagrama de base de datos, BackUp de Sql Server 2014 de la base de datos, diagrama base de la Arquitectura de n-Capas orientada al dominio con .net.png y archivo Pruebas.postman_ServiciosRest.json con las pruebas de los servicios rest.