CREATE TABLE [Maestros].[Avion] (
    [IdAvion]    INT           NOT NULL,
    [Modelo]     VARCHAR (100) NOT NULL,
    [Fabricante] VARCHAR (100) NOT NULL,
    [Capacidad]  INT           NOT NULL,
    [Siglas]     VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Avion] PRIMARY KEY CLUSTERED ([IdAvion] ASC)
);

