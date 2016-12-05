CREATE TABLE [Reserva].[Tarifa] (
    [IdVuelo]       BIGINT       NOT NULL,
    [IdTipoAsiento] SMALLINT     NOT NULL,
    [ValorTiquete]  NUMERIC (18) NOT NULL,
    CONSTRAINT [PK_Tarifa] PRIMARY KEY CLUSTERED ([IdVuelo] ASC, [IdTipoAsiento] ASC),
    CONSTRAINT [FK_Tarifa_TipoAsiento] FOREIGN KEY ([IdTipoAsiento]) REFERENCES [Maestros].[TipoAsiento] ([IdTipoAsiento]),
    CONSTRAINT [FK_Tarifa_Vuelo] FOREIGN KEY ([IdVuelo]) REFERENCES [Reserva].[Vuelo] ([IdVuelo])
);

