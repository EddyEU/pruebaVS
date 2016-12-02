CREATE TABLE [Maestros].[Usuario] (
    [IdUsuario]     INT           IDENTITY (1, 1) NOT NULL,
    [Login]         VARCHAR (100) NOT NULL,
    [Clave]         VARCHAR (100) NOT NULL,
    [FechaCreacion] DATETIME      CONSTRAINT [DF_Usuario_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);

