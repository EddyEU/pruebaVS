CREATE TABLE [Maestros].[Ciudad] (
    [IdCiudad]      SMALLINT     IDENTITY (1, 1) NOT NULL,
    [NombreCiudad]  VARCHAR (50) NOT NULL,
    [FechaCreacion] DATETIME     NOT NULL,
    [Activa]        BIT          CONSTRAINT [DF__Ciudad__Activa] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED ([IdCiudad] ASC),
    CONSTRAINT [UK_Ciudad] UNIQUE NONCLUSTERED ([NombreCiudad] ASC)
);

