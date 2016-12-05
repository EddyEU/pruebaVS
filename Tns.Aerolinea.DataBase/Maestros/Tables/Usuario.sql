CREATE TABLE [Maestros].[Usuario] (
    [IdUsuario]       INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]          VARCHAR (20)  NOT NULL,
    [Apellido]        VARCHAR (20)  NOT NULL,
    [Cedula]          VARCHAR (20)  NOT NULL,
    [FechaNacimiento] DATE          NOT NULL,
    [Login]           VARCHAR (100) NOT NULL,
    [Clave]           VARCHAR (100) NOT NULL,
    [FechaCreacion]   DATETIME      CONSTRAINT [DF_Usuario_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [UQ_Cedula] UNIQUE NONCLUSTERED ([Cedula] ASC),
    CONSTRAINT [UQ_Login] UNIQUE NONCLUSTERED ([Login] ASC)
);





