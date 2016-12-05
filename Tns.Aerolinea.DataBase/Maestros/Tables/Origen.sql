CREATE TABLE [Maestros].[Origen] (
    [IdOrigen]   INT           IDENTITY (1, 1) NOT NULL,
    [IdCiudad]   INT           NOT NULL,
    [Aeropuerto] VARCHAR (500) NOT NULL,
    [Activo]     BIT           CONSTRAINT [DF_Origen_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Origen] PRIMARY KEY CLUSTERED ([IdOrigen] ASC),
    CONSTRAINT [FK_Origen_Ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [Maestros].[Ciudad] ([IdCiudad])
);



