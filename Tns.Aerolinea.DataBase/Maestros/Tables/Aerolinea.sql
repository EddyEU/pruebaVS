CREATE TABLE [Maestros].[Aerolinea] (
    [IdAerolinea] INT           NOT NULL,
    [Nombre]      VARCHAR (100) NOT NULL,
    [Telefono]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Aerolinea] PRIMARY KEY CLUSTERED ([IdAerolinea] ASC)
);

