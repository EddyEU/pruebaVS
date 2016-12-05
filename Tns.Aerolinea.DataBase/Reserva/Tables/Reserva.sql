CREATE TABLE [Reserva].[Reserva] (
    [IdReserva]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [IdUsuario]         INT          NOT NULL,
    [IdVuelo]           BIGINT       NOT NULL,
    [ValorTotalReserva] NUMERIC (18) NOT NULL,
    [FechaReserva]      DATETIME     CONSTRAINT [DF_Tiquete_FechaReserva] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Tiquete] PRIMARY KEY CLUSTERED ([IdReserva] ASC),
    CONSTRAINT [FK_Tiquete_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Maestros].[Usuario] ([IdUsuario]),
    CONSTRAINT [FK_Tiquete_Vuelo] FOREIGN KEY ([IdVuelo]) REFERENCES [Reserva].[Vuelo] ([IdVuelo])
);

