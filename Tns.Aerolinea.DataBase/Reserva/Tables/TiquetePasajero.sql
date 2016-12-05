CREATE TABLE [Reserva].[TiquetePasajero] (
    [IdReserva]    BIGINT       NOT NULL,
    [IdPasajero]   BIGINT       NOT NULL,
    [IdAsiento]    INT          NULL,
    [ValorTiquete] NUMERIC (18) NOT NULL,
    CONSTRAINT [PK_TiquetePasajero_1] PRIMARY KEY CLUSTERED ([IdReserva] ASC, [IdPasajero] ASC),
    CONSTRAINT [FK_TiquetePasajero_Asiento] FOREIGN KEY ([IdAsiento]) REFERENCES [Reserva].[Asiento] ([IdAsiento]),
    CONSTRAINT [FK_TiquetePasajero_Pasajero] FOREIGN KEY ([IdPasajero]) REFERENCES [Reserva].[Pasajero] ([IdPasajero]),
    CONSTRAINT [FK_TiquetePasajero_Tiquete] FOREIGN KEY ([IdReserva]) REFERENCES [Reserva].[Reserva] ([IdReserva])
);





