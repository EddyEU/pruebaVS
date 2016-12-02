CREATE TABLE [Reserva].[Tiquete] (
    [IdTiquete]    BIGINT   IDENTITY (1, 1) NOT NULL,
    [IdUsuario]    INT      NOT NULL,
    [IdVuelo]      BIGINT   NOT NULL,
    [FechaReserva] DATETIME CONSTRAINT [DF_Tiquete_FechaReserva] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Tiquete] PRIMARY KEY CLUSTERED ([IdTiquete] ASC)
);

