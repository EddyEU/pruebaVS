CREATE TABLE [Maestros].[Destino] (
    [IdDestino]  INT           IDENTITY (1, 1) NOT NULL,
    [IdCiudad]   INT           NOT NULL,
    [Aeropuerto] VARCHAR (500) NOT NULL,
    [Activo]     BIT           CONSTRAINT [DF_Destino_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Destino] PRIMARY KEY CLUSTERED ([IdDestino] ASC),
    CONSTRAINT [FK_Destino_Ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [Maestros].[Ciudad] ([IdCiudad])
);



