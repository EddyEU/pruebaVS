CREATE TABLE [Maestros].[Aerolinea] (
    [IdAerolinea] INT           IDENTITY (1, 1) NOT NULL,
    [Nit]         VARCHAR (20)  NOT NULL,
    [Nombre]      VARCHAR (100) NOT NULL,
    [Telefono]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Aerolinea] PRIMARY KEY CLUSTERED ([IdAerolinea] ASC),
    CONSTRAINT [UQ_Aerolinea] UNIQUE NONCLUSTERED ([Nit] ASC)
);





