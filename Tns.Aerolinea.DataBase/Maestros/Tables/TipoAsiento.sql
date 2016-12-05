CREATE TABLE [Maestros].[TipoAsiento] (
    [IdTipoAsiento] SMALLINT      NOT NULL,
    [Nombre]        VARCHAR (100) NOT NULL,
    [Observaciones] VARCHAR (500) NULL,
    CONSTRAINT [PK_TipoAsiento] PRIMARY KEY CLUSTERED ([IdTipoAsiento] ASC)
);

