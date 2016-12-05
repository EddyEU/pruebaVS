CREATE TABLE [Maestros].[EstadoVuelo] (
    [IdEstado]     TINYINT      NOT NULL,
    [NombreEstado] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_EstadoVuelo] PRIMARY KEY CLUSTERED ([IdEstado] ASC),
    CONSTRAINT [UQ_Estado] UNIQUE NONCLUSTERED ([NombreEstado] ASC)
);

