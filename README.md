# AerolineaTNS
Prueba Tecnica TNS

Proyecto desarrollado con:

- Visual studio 2015 - framework 4.6.1
- Servicios Rest expuestos en el BackEnd con Web.Api (usando un proyecto Asp.Net Core.)
- AngularJs en el FrontEnd consumiendo los servicios rest.
- Sql server 2014 (se adjunta en el proyecto un .bak de la BD y dentro de la solucion hay un proyecto tipo DataBase con toda la estructura de la misma).
- Incluye proyecto de pruebas unitarias
- Adicional se incluye el archivo Pruebas.postman_ServiciosRest.json que contiene el set de pruebas de algunos de los servicios REST contruidos y consumidos desde PostMan.


Consideraciones del proyecto:
- Se intento usar la nueva guia de estilo de desarrollo propuesto por Jhon Papa y adoptada por Vidual studio en sus ultimas versiones.
	https://github.com/johnpapa/angular-styleguide/tree/master/a1
- 

Arquitectura implementada:

- DDD
- Repository
- Iyecciónn de dependencias tanto en el FrontEnd (con angularjs) como en el BackEnd (usando Autofac).
- DTO para exponer en los servicios Rest.
- EntityFramework 6.1.3 (ultima version estable). En este sentido, las entidades de negocio son generadas automaticamnete a partir del modelo usando las platillas T4, pero por defecto estas quedan en la cada Data, donde se encuentra el archivo .edmx que es el que contiene todo el modelo de la base de datos, para esto use un pequeño truco para permitir llevarme la plantilla a otro emsamblado y quede las entidades en una capa transversal y no necesariamente tener que hacer la capa de datos transversal.

Notas:

- Por temas de tiempo, no todas las pantallas en FrontEnd fueron terminadas, pero si en el BackEnd se encuentran expuestos todos los servicios requeridos por la aplicacion. Igualmente intente hacer algunas pantallas que muestren varias facetas, como lo es consultas sencillas, consultas de onjetos mas complejos (metodos GET) y actualizacion o inserciones en la base de datos (metodos PUT).


- En la carpeta Documentacion en la raiz del proyecto se encuentra : Diagrama de base de datos, BackUp de Sql Server 2014 de la base de datos, archivo Pruebas.postman_ServiciosRest.json con las pruebas de los servicios rest.