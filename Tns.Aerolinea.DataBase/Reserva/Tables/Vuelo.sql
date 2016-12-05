CREATE TABLE [Reserva].[Vuelo] (
    [IdVuelo]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [IdOrigen]      INT           NOT NULL,
    [IdDestino]     INT           NOT NULL,
    [IdAerolinea]   INT           NOT NULL,
    [IdAvion]       INT           NOT NULL,
    [IdEstado]      TINYINT       NOT NULL,
    [Fecha]         DATETIME      NOT NULL,
    [Observaciones] VARCHAR (500) NULL,
    CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED ([IdVuelo] ASC),
    CONSTRAINT [FK_Vuelo_Aerolinea] FOREIGN KEY ([IdAerolinea]) REFERENCES [Maestros].[Aerolinea] ([IdAerolinea]),
    CONSTRAINT [FK_Vuelo_Avion] FOREIGN KEY ([IdAvion]) REFERENCES [Maestros].[Avion] ([IdAvion]),
    CONSTRAINT [FK_Vuelo_Destino] FOREIGN KEY ([IdDestino]) REFERENCES [Maestros].[Destino] ([IdDestino]),
    CONSTRAINT [FK_Vuelo_EstadoVuelo] FOREIGN KEY ([IdEstado]) REFERENCES [Maestros].[EstadoVuelo] ([IdEstado]),
    CONSTRAINT [FK_Vuelo_Origen] FOREIGN KEY ([IdOrigen]) REFERENCES [Maestros].[Origen] ([IdOrigen])
);









