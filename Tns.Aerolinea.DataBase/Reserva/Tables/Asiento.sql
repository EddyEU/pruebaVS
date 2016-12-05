CREATE TABLE [Reserva].[Asiento] (
    [IdAsiento]        INT         IDENTITY (1, 1) NOT NULL,
    [IdAvion]          INT         NOT NULL,
    [IdTipoAsiento]    SMALLINT    NOT NULL,
    [Codigo]           VARCHAR (5) NOT NULL,
    [SalidaEmergencia] NCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Asiento] PRIMARY KEY CLUSTERED ([IdAsiento] ASC),
    CONSTRAINT [FK_Asiento_Avion] FOREIGN KEY ([IdAvion]) REFERENCES [Maestros].[Avion] ([IdAvion]),
    CONSTRAINT [FK_Asiento_TipoAsiento] FOREIGN KEY ([IdTipoAsiento]) REFERENCES [Maestros].[TipoAsiento] ([IdTipoAsiento])
);

