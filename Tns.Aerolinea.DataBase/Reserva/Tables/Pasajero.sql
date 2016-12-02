CREATE TABLE [Reserva].[Pasajero] (
    [IdPasajero] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Cedula]     VARCHAR (100) NOT NULL,
    [Direccion]  VARCHAR (100) NOT NULL,
    [Sexo]       CHAR (1)      NOT NULL,
    [Telefono]   VARCHAR (20)  NULL,
    [Celular]    VARCHAR (15)  NOT NULL,
    [Correo]     VARCHAR (100) NULL,
    CONSTRAINT [PK_Pasajero] PRIMARY KEY CLUSTERED ([IdPasajero] ASC)
);

